using FluentValidation.SmartMessages.Collections;

namespace FluentValidation.SmartMessages.Impl
{
    public class OtherwiseConditionBuilder
    {
        private readonly IConditionBuilder _conditionBuilder;

        public OtherwiseConditionBuilder(IConditionBuilder conditionBuilder)
        {
            _conditionBuilder = conditionBuilder;
        }

        public FinalConditionBuilder Otherwise(Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            _conditionBuilder.Otherwise(() => action(ruleBag));

            return new FinalConditionBuilder(ruleBag);
        }
    }
}
