using FluentValidation.SmartMessages.Collections;
using FluentValidation.SmartMessages.Helpers;

namespace FluentValidation.SmartMessages.Impl
{
    public class ScopeBuilder
    {
        private readonly RuleBag _ruleBag;

        public ScopeBuilder(RuleBag ruleBag)
        {
            _ruleBag = ruleBag;    
        }

        public void WithMessage(Func<string, string> func)
        {
            RuleBagHelper.WithMessage(_ruleBag, func);
        }
    }
}
