using FluentAssertions.Common;
using FluentValidation.SmartMessages.Enums;
using FluentValidation.SmartMessages.Extensions;
using FluentValidation.TestHelper;

namespace FluentValidation.SmartMessages.Tests.UnitTests
{
    public class GroupExpressionTests
    {
        [Fact]
        public void Test()
        {
            var validator = new ScopeExpressionModelValidator();
            var model = new ScopeExpressionModel()
            {
                FirstName = "test"
            };

            var result = validator.TestValidate(model);
        }

        public class ScopeExpressionModelValidator : SmartValidator<ScopeExpressionModel>
        {
            public ScopeExpressionModelValidator()
            {
                RuleFor(model => model.FirstName).MaximumLength(3)
                    .Equal("str")
                    .Group(msg => $"{msg} Просто область", ApplyGroupTo.CurrentValidator);
            }
        }

        public class ScopeExpressionModel
        {
            public string FirstName { get; set; }
            public StartTimer SecondName { get; set; }
        }
    }
}
