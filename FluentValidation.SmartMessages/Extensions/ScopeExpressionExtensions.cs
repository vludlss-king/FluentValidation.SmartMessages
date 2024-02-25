using FluentValidation.Internal;
using FluentValidation.SmartMessages.Enums;

namespace FluentValidation.SmartMessages.Extensions
{
    public static class ScopeExpressionExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> Group<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<string, string> func, ApplyGroupTo applyGroupTo = ApplyGroupTo.AllValidators)
        {
            return rule.Configure(cfg =>
            {
                if (applyGroupTo == ApplyGroupTo.AllValidators)
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
