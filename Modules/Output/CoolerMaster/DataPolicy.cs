using Vixen.Data.Combinator;
using Vixen.Data.Evaluator;
using Vixen.Data.Policy;
using Vixen.Sys;

namespace VixenModules.Output.CoolerMaster
{
    internal class DataPolicy : ControllerDataPolicy
    {
        protected override ICombinator GetCombinator()
        {
            return new DiscardExcessCombinator();
        }

        protected override IEvaluator GetEvaluator()
        {
            return new _8BitEvaluator();
        }
    }
}