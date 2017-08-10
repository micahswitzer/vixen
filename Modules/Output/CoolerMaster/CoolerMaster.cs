using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Vixen.Commands;
using Vixen.Module;
using Vixen.Module.Controller;

namespace VixenModules.Output.CoolerMaster
{
    public class CoolerMaster : ControllerModuleInstanceBase
    {
        private CoolerMasterData _data;

        private Dictionary<int, byte> _lastValues;
        private Dictionary<int, int> _nullCommands;
        private Stopwatch _timeoutStopwatch;
        private int _outputCount;
        private int _channelCount;
        private int _ledCount; // Shouldn't be needed
        private bool _connected = false;

        public CoolerMaster()
        {
            _data = new CoolerMasterData();
            _lastValues = new Dictionary<int, byte>();
            _nullCommands = new Dictionary<int, int>();
            _timeoutStopwatch = new Stopwatch();
            DataPolicyFactory = new DataPolicyFactory();
        }

        public override int OutputCount
        {
            get
            {
                return _outputCount;
            }
            set
            {
                _outputCount = value;
                _setupDataBuffers();
            }
        }

        private void UpdateCounts()
        {
            _ledCount = CoolerMasterSDK.MAX_LED_COUNT;
            _channelCount = 3;
            switch (_data.DeviceType)
            {
                case CoolerMasterData.DeviceIndex.MKeys_S:
                case CoolerMasterData.DeviceIndex.MKeys_M:
                case CoolerMasterData.DeviceIndex.MKeys_L:
                    break; // Most common case (in my opinion)
                case CoolerMasterData.DeviceIndex.MKeys_S_White:
                case CoolerMasterData.DeviceIndex.MKeys_M_White:
                case CoolerMasterData.DeviceIndex.MKeys_L_White:
                    _channelCount = 1; // Only White LEDs
                    break;
                case CoolerMasterData.DeviceIndex.MMouse_S:
                    _ledCount = 2; // Two RGB LEDs
                    break;
                case CoolerMasterData.DeviceIndex.MMouse_L:
                    _ledCount = 4; // Four RGB LEDs
                    break;
            }
        }

        public override void UpdateState(int chainIndex, ICommand[] outputStates)
        {
            if (!_connected)
            {
                // Try to open the connection
                if (!OpenConnection()) return;
            }

            COLOR_MATRIX matrix = COLOR_MATRIX.Create();

            bool changed = false;
            for (int i = 0; i < outputStates.Length; i++)
            {
                byte newValue = 0;

                if (outputStates[i] != null)
                {
                    _8BitCommand command = outputStates[i] as _8BitCommand;
                    if (command == null)
                        continue;
                    newValue = command.CommandValue;
                    _nullCommands[i] = 0;
                }
                else
                {
                    // it was a null command. We should turn it off; however, to avoid some potentially nasty flickering,
                    // we will keep track of the null commands for this output, and ignore the first one. Any after that will
                    // actually be sent through.
                    if (_nullCommands[i] == 0)
                    {
                        _nullCommands[i] = 1;
                        newValue = _lastValues[i];
                    }
                }

                if (_lastValues[i] != newValue)
                {
                    changed = true;
                    matrix.SetKeyValue(i, _channelCount, newValue);
                    _lastValues[i] = newValue;
                }
            }

            // don't bother writing anything if we haven't acutally *changed* any values...
            // also, send at least a 'null' update command every 10 seconds.
            if (changed || _timeoutStopwatch.ElapsedMilliseconds >= 10000)
            {
                try
                {
                    _timeoutStopwatch.Restart();
                    // Write Data
                    if (!CoolerMasterSDK.SetAllLedColor(matrix)) throw new Exception("SetAllLedColor() Failed");
                    CoolerMasterSDK.RefreshLed();
                }
                catch (Exception ex)
                {
                    //Logging.Warn(LogTag + "failed to write data to device during update", ex);
                    CloseConnection();
                }
            }
        }

        private void _setupDataBuffers()
        {
            for (int i = 0; i < this.OutputCount; i++)
            {
                if (!_lastValues.ContainsKey(i))
                    _lastValues[i] = 0;
                if (!_nullCommands.ContainsKey(i))
                    _nullCommands[i] = 0;
            }
        }

        public override void Start()
        {
            _setupDataBuffers();
            base.Start();
        }

        private bool OpenConnection()
        {
            CloseConnection();

            CoolerMasterSDK.SetControlDevice(_data.DeviceType);

            // Detect if device is connected
            if (!CoolerMasterSDK.IsDevicePlug()) return false;

            // Try to enable control of keyboard/mouse
            if (!CoolerMasterSDK.EnableLedControl(true)) return false;
            _connected = true;

            // reset the last values. That means that *any* values that come in will be 'new', and be sent out.
            _lastValues = new Dictionary<int, byte>();
            _nullCommands = new Dictionary<int, int>();
            _setupDataBuffers();

            _timeoutStopwatch.Reset();
            _timeoutStopwatch.Start();

            return true;
        } 

        private void CloseConnection()
        {
            CoolerMasterSDK.EnableLedControl(false);
            _connected = false;
        }

        public override IModuleDataModel ModuleData
        {
            get { return _data; }
            set
            {
                _data = value as CoolerMasterData;
                CloseConnection();
                UpdateCounts();
            }
        }

        public override bool HasSetup => true;

        public override bool Setup()
        {
            using (SetupDialog setup = new SetupDialog(_data))
            {
                if (setup.ShowDialog() == DialogResult.OK)
                {
                    _data.DeviceType = setup.DeviceType;
                    CloseConnection();
                    UpdateCounts();
                    return true;
                }
            }

            return false;
        }
    }
}