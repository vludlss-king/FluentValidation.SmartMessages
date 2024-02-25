using FluentValidation.Internal;
using FluentValidation.SmartMessages.Contracts;

namespace FluentValidation.SmartMessages.Impl
{
    public class SmartConditionBuilder : ISmartConditionBuilder
    {
        private IReadOnlyList<IRuleComponent> _rulesComponents;
        private readonly IConditionBuilder _conditionBuilder;

        public SmartConditionBuilder(IConditionBuilder conditionBuilder, IReadOnlyList<IRuleComponent> rulesComponents)
        {
            _rulesComponents = rulesComponents;
            _conditionBuilder = conditionBuilder;
        }

        public ISmartConditionBuilder Otherwise(Action<RuleBag> action)
        {
            var conditionBag = new RuleBag();

            _conditionBuilder.Otherwise(() => action(conditionBag));
            _rulesComponents = conditionBag.ExtractRulesComponents();
            
            return this;
        }

        public ISmartConditionBuilder WithMessage(Func<string, string> func)
        {
            var bagWithMessage = new BagWithMessage<ISmartConditionBuilder>(this, _rulesComponents);
            return bagWithMessage.WithMessage(func);
        }
    }
}
