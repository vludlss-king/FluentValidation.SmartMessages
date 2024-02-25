using FluentValidation.SmartMessages.Extensions;
using FluentValidation.TestHelper;

namespace FluentValidation.SmartMessages.Tests.UnitTests
{
    public class GroupTopLevelTests
    {
        [Fact]
        public void Test()
        {
            var validator = new GroupModelValidator();
            var model = new ScopeModel();

            var result = validator.TestValidate(model);
        }

        public class GroupModelValidator : SmartValidator<ScopeModel>
        {
            public GroupModelValidator()
            {
                Group(bag =>
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
