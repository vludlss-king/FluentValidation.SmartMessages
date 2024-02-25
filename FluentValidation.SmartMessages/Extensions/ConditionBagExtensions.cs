namespace FluentValidation.SmartMessages.Extensions
{
    public static class ConditionBagExtensions
    {
        public static void AttachTo<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, RuleBag bag)
            => bag.Attach(rule);
    }
}
