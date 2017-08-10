using System.Runtime.Serialization;
using Vixen.Module;

namespace VixenModules.Output.CoolerMaster
{
    [DataContract]
    public class CoolerMasterData : ModuleDataModelBase
    {
        [DataMember]
        public DeviceIndex DeviceType { get; set; }

        public override IModuleDataModel Clone()
        {
            CoolerMasterData result = new CoolerMasterData();
            result.DeviceType = DeviceType;
            return result;
        }

        public enum DeviceIndex
        {
            MKeys_S = 1,
            MKeys_M = 6,
            MKeys_L = 0,
            MKeys_S_White = 7,
            MKeys_M_White = 3,
            MKeys_L_White = 2,
            MMouse_S = 5,
            MMouse_L = 4,
        }
    }
}