﻿using FluentValidation.Internal;

namespace FluentValidation.SmartMessages.Collections
{
    public class RuleBag
    {
        private readonly List<IRuleComponent> _rulesComponents;

        public RuleBag()
        {
            _rulesComponents = new();
        }

        public void Attach<T, TProperty>(IRuleBuilderOptions<T, TProperty> rule)
            => rule.Configure(cfg => _rulesComponents.AddRange(cfg.Components));

        public void Attach(RuleBag ruleBag)
        {
            _rulesComponents.AddRange(ruleBag.ExtractRulesComponents());
        }

        public IReadOnlyList<IRuleComponent> ExtractRulesComponents() => _rulesComponents;
    }
}
