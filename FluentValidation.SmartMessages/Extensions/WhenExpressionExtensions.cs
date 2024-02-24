using FluentValidation.Internal;

namespace FluentValidation.SmartMessages.Extensions
{
    public static class WhenExpressionExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> When<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<T, bool> predicate, Func<string, string> func, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
        {
            return rule.When(predicate, applyConditionTo).Configure(cfg =>
            {
                if(applyConditionTo == ApplyConditionTo.AllValidators)
                {
                    foreach(IRuleComponent<T, TProperty> component in cfg.Components)
                    {
                        var previousMessage = component.GetUnformattedErrorMessage();
                        component.SetErrorMessage(func(previousMessage));
                    }
                }
                else
                {
                    var previousMessage = cfg.Current.GetUnformattedErrorMessage();
                    cfg.Current.SetErrorMessage(func(previousMessage));
                }
            });
        }

        public static IRuleBuilderOptions<T, TProperty> When<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<T, ValidationContext<T>, bool> predicate, Func<string, string> func, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators)
        {
            return rule.When(predicate, applyConditionTo).Configure(cfg =>
            {
                if (applyConditionTo == ApplyConditionTo.AllValidators)
                {
                    foreach (IRuleComponent<T, TProperty> component in cfg.Components)
                    {
                        var previousMessage = component.GetUnformattedErrorMessage();
                        component.SetErrorMessage(func(previousMessage));
                    }
                }
                else
                {
                    var previousMessage = cfg.Current.GetUnformattedErrorMessage();
                    cfg.Current.SetErrorMessage(func(previousMessage));
                }
            });
        }
    }
}
