﻿using FluentValidation.Internal;

namespace FluentValidation.SmartMessages
{
    public class ConditionBag
    {
        private readonly List<IRuleComponent> _rulesComponents;

        public ConditionBag()
        {
            _rulesComponents = new();
        }

        public void Attach<T, TProperty>(IRuleBuilderOptions<T, TProperty> rule)
            => rule.Configure(cfg => _rulesComponents.AddRange(cfg.Components));

        public IReadOnlyList<IRuleComponent> ExtractRulesComponents() => _rulesComponents;
    }
}
