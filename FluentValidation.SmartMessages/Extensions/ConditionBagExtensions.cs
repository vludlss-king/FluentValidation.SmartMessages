namespace FluentValidation.SmartMessages.Extensions
{
    public static class ConditionBagExtensions
    {
        public static void AttachTo<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, ConditionBag bag)
            => bag.Attach(rule);
    }
}
