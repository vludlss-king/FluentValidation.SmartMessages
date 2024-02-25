using FluentValidation.Internal;
using FluentValidation.SmartMessages.Contracts;

namespace FluentValidation.SmartMessages.Impl
{
    public class SmartConditionBuilder : ISmartConditionBuilder
    {
        private readonly IConditionBuilder _conditionBuilder;
        private IReadOnlyList<IRuleComponent> _rulesComponents;

        public SmartConditionBuilder(IConditionBuilder conditionBuilder, IReadOnlyList<IRuleComponent> rulesComponents)
        {
            _conditionBuilder = conditionBuilder;
            _rulesComponents = rulesComponents;  
        }

        public ISmartConditionBuilder WithMessage(Func<string, string> func)
        {
            foreach(dynamic component in _rulesComponents)
            {
                var previousMessage = component.GetUnformattedErrorMessage();
                component.SetErrorMessage(func(previousMessage));
            }

            return this;
        }

        public ISmartConditionBuilder Otherwise(Action<ConditionBag> action)
        {
            var conditionBag = new ConditionBag();

            _conditionBuilder.Otherwise(() => action(conditionBag));
            _rulesComponents = conditionBag.ExtractRulesComponents();
            
            return this;
        }
    }
}
