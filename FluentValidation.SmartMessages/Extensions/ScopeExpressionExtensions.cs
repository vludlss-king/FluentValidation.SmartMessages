using FluentValidation.Internal;
using FluentValidation.SmartMessages.Enums;

namespace FluentValidation.SmartMessages.Extensions
{
    public static class ScopeExpressionExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> Scope<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Func<string, string> func, ApplyScopeTo applyScopeTo = ApplyScopeTo.AllValidators)
        {
            return rule.Configure(cfg =>
            {
                if (applyScopeTo == ApplyScopeTo.AllValidators)
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
