using FluentValidation.SmartMessages.Helpers;

namespace FluentValidation.SmartMessages.Impl
{
    public class FinalConditionBuilder
    {
        private readonly RuleBag _ruleBag;

        public FinalConditionBuilder(RuleBag ruleBag)
        {
            _ruleBag = ruleBag;    
        }

        public void WithMessage(Func<string, string> func)
        {
            RuleBagHelper.WithMessage(_ruleBag, func);
        }
    }
}
