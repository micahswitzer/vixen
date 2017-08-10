using System;
using Vixen.Module.Controller;

namespace VixenModules.Output.CoolerMaster
{
    public class CoolerMasterDescriptor : ControllerModuleDescriptorBase
    {
        private static Guid _typeId = new Guid("88CC65FB-88B1-4D44-B92A-1D87A134A9AE");

        public override string Author => "Micah Switzer";

        public override string Description => "CoolerMaster RGB keyboard and mouse hardware controller module";

        public override Type ModuleClass => typeof(CoolerMaster);
        public override Type ModuleDataClass => typeof(CoolerMasterData);

        public override Guid TypeId => _typeId;

        public override string TypeName => "CoolerMaster Controller";

        public override string Version => "0.1";
    }
}