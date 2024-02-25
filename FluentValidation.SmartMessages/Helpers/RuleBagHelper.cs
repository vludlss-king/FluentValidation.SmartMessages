namespace FluentValidation.SmartMessages.Helpers
{
    internal class RuleBagHelper
    {
        public static void WithMessage(RuleBag ruleBag, Func<string, string> func)
        {
            foreach (dynamic component in ruleBag.ExtractRulesComponents())
            {
                var previousMessage = component.GetUnformattedErrorMessage();
                component.SetErrorMessage(func(previousMessage));
            }
        }
    }
}
