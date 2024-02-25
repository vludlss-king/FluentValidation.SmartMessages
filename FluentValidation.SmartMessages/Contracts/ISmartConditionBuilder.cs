namespace FluentValidation.SmartMessages.Contracts
{
    public interface ISmartConditionBuilder : IBagWithMessage<ISmartConditionBuilder>
    {
        ISmartConditionBuilder Otherwise(Action<RuleBag> action);
    }
}
