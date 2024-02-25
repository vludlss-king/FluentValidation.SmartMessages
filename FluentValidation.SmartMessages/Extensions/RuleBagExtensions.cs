using FluentValidation.SmartMessages.Collections;

namespace FluentValidation.SmartMessages.Extensions
{
    public static class RuleBagExtensions
    {
        public static void AttachTo<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, RuleBag bag)
            => bag.Attach(rule);
    }
}
