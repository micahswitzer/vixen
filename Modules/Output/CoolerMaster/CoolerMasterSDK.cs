using System.Runtime.InteropServices;

namespace VixenModules.Output.CoolerMaster
{
    internal static class CoolerMasterSDK
    {
#if WIN64
        private const string DllName = "SDKDLL64.dll";
#else
        private const string DllName = "SDKDLL.dll";
#endif
        internal const byte MAX_LED_ROW = 6;
        internal const byte MAX_LED_COLUMN = 22;
        internal const byte MAX_LED_COUNT = MAX_LED_ROW * MAX_LED_COLUMN;

        [DllImport(DllName)]
        static internal extern void SetControlDevice(CoolerMasterData.DeviceIndex devIndex);
        [DllImport(DllName)]
        static internal extern bool IsDevicePlug();
        [DllImport(DllName)]
        static internal extern bool EnableLedControl([In] bool bEnable);
        [DllImport(DllName)]
        static internal extern bool RefreshLed([In] bool bAuto = false);
        [DllImport(DllName)]
        static internal extern bool SetAllLedColor([In] COLOR_MATRIX colorMatrix);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KEY_COLOR
    {
        internal KEY_COLOR(byte _r, byte _g, byte _b) { r = _r; g = _g; b = _b; }
        internal byte r;
        internal byte g;
        internal byte b;
    }

    //  set up/save the whole LED color structure
    [StructLayout(LayoutKind.Sequential)]
    internal struct COLOR_MATRIX
    {
        internal static COLOR_MATRIX Create()
        {
            return new COLOR_MATRIX()
            {
                KeyColor = new KEY_COLOR[CoolerMasterSDK.MAX_LED_COUNT]
            };
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CoolerMasterSDK.MAX_LED_COUNT)]
        internal KEY_COLOR[] KeyColor;
        internal void SetKeyValue(int index, int channelCount, byte value)
        {
            var channel = index % channelCount;
            var pos = index / channelCount;
            switch (channel)
            {
                case 0:
                    KeyColor[pos].r = value;
                    break;
                case 1:
                    KeyColor[pos].g = value;
                    break;
                case 2:
                    KeyColor[pos].b = value;
                    break;
                default:
                    goto case 0;
            }
        }
    }
}