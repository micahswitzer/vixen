using Vixen.Sys;

namespace VixenModules.Output.CoolerMaster
{
    internal class DataPolicyFactory : IDataPolicyFactory
    {
        public IDataPolicy CreateDataPolicy()
        {
            return new DataPolicy();
        }
    }
}