using System;
using Vixen.Module.Controller;

namespace VixenModules.Output.CoolerMaster
{
    public class CoolerMasterDescriptor : ControllerModuleDescriptorBase
    {
        private static readonly Guid _typeId = new Guid("88CC65FB-88B1-4D44-B92A-1D87A134A9AE");

        public override string Author
        {
            get { return "Micah Switzer"; }
        }

        public override string Description
        {
            get { return "CoolerMaster RGB keyboard and mouse hardware controller module"; }
        }

        public override Type ModuleClass
        {
            get { return typeof(CoolerMaster); }
        }

        public override Type ModuleDataClass
        {
            get { return typeof(CoolerMasterData); }
        }

        public override Guid TypeId
        {
            get { return _typeId; }
        }

        public override string TypeName
        {
            get { return "CoolerMaster Controller"; }
        }

        public override string Version
        {
            get { return "0.1"; }
        }
    }
}