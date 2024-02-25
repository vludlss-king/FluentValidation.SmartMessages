using FluentValidation.Internal;
using FluentValidation.SmartMessages.Contracts;

namespace FluentValidation.SmartMessages.Impl
{
    public class BagWithMessage<T> : IBagWithMessage<T>
    {
        private readonly T _returnObject;
        protected IReadOnlyList<IRuleComponent> _rulesComponents;

        public BagWithMessage(T returnObject, IReadOnlyList<IRuleComponent> rulesComponents)
        {
            _returnObject = returnObject;
            _rulesComponents = rulesComponents;
        }

        public T WithMessage(Func<string, string> func)
        {
            foreach (dynamic component in _rulesComponents)
            {
                var previousMessage = component.GetUnformattedErrorMessage();
                component.SetErrorMessage(func(previousMessage));
            }

            return _returnObject;
        }
    }
}
