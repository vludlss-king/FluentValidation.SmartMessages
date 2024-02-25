namespace FluentValidation.SmartMessages.Contracts
{
    public interface IBagWithMessage<T>
    {
        T WithMessage(Func<string, string> func);
    }
}
