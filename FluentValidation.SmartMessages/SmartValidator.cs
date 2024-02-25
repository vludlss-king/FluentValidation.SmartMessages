using FluentValidation.SmartMessages.Contracts;
using FluentValidation.SmartMessages.Impl;

namespace FluentValidation.SmartMessages
{
    public abstract class SmartValidator<T> : AbstractValidator<T>
    {
        public ISmartConditionBuilder When(Func<T, bool> predicate, Action<ConditionBag> action)
        {
            var whenBag = new ConditionBag();

            var conditionBuilder = When(predicate, () => action(whenBag));
            var rulesComponents = whenBag.ExtractRulesComponents();

            return new SmartConditionBuilder(conditionBuilder, rulesComponents);
        }
    }
}
