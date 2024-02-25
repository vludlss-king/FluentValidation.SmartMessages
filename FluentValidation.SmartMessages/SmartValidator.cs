using FluentValidation.SmartMessages.Collections;
using FluentValidation.SmartMessages.Impl;

namespace FluentValidation.SmartMessages
{
    public abstract class SmartValidator<T> : AbstractValidator<T>
    {
        public WhenConditionBuilder When(Func<T, bool> predicate, Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            var conditionBuilder = When(predicate, () => action(ruleBag));
            var rulesComponents = ruleBag.ExtractRulesComponents();

            return new WhenConditionBuilder(conditionBuilder, ruleBag);
        }

        public GroupBuilder Group(Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            action(ruleBag);

            return new GroupBuilder(ruleBag);
        }
    }
}
