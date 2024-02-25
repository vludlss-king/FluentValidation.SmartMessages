namespace FluentValidation.SmartMessages.Contracts
{
    public interface ISmartConditionBuilder
    {
        ISmartConditionBuilder WithMessage(Func<string, string> func);
        ISmartConditionBuilder Otherwise(Action<ConditionBag> action);
    }
}
