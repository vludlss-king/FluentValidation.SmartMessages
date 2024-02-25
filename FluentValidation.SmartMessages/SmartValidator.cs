using FluentValidation.SmartMessages.Contracts;
using FluentValidation.SmartMessages.Impl;

namespace FluentValidation.SmartMessages
{
    public abstract class SmartValidator<T> : AbstractValidator<T>
    {
        public ISmartConditionBuilder When(Func<T, bool> predicate, Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            var conditionBuilder = When(predicate, () => action(ruleBag));
            var rulesComponents = ruleBag.ExtractRulesComponents();

            return new SmartConditionBuilder(conditionBuilder, rulesComponents);
        }

        public IBagWithMessage<object> Scope(Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            action(ruleBag);
            var rulesComponents = ruleBag.ExtractRulesComponents();

            return new BagWithMessage<object>(new object(), rulesComponents);
        }
    }
}
