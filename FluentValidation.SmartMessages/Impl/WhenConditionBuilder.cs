using FluentValidation.SmartMessages.Helpers;

namespace FluentValidation.SmartMessages.Impl
{
    public class WhenConditionBuilder
    {
        private RuleBag _ruleBag;
        private readonly IConditionBuilder _conditionBuilder;

        public WhenConditionBuilder(IConditionBuilder conditionBuilder, RuleBag ruleBag)
        {
            _ruleBag = ruleBag;
            _conditionBuilder = conditionBuilder;
        }

        public FinalConditionBuilder Otherwise(Action<RuleBag> action)
        {
            return new OtherwiseConditionBuilder(_conditionBuilder).Otherwise(action);
        }

        public OtherwiseConditionBuilder WithMessage(Func<string, string> func)
        {
            RuleBagHelper.WithMessage(_ruleBag, func);
            return new OtherwiseConditionBuilder(_conditionBuilder);
        }
    }
}
