using FluentValidation.SmartMessages.Extensions;
using FluentValidation.TestHelper;

namespace FluentValidation.SmartMessages.Tests.UnitTests
{
    public class ScopeTopLevelTests
    {
        [Fact]
        public void Test()
        {
            var validator = new ScopeModelValidator();
            var model = new ScopeModel();

            var result = validator.TestValidate(model);
        }

        public class ScopeModelValidator : SmartValidator<ScopeModel>
        {
            public ScopeModelValidator()
            {
                Scope(bag =>
                {
                    RuleFor(model => model.FirstName).NotNull().AttachTo(bag);
                    RuleFor(model => model.SecondName).NotNull().AttachTo(bag);
                })
                .WithMessage(msg => $"{msg} Просто область");
            }
        }

        public class ScopeModel
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
        }
    }
}
