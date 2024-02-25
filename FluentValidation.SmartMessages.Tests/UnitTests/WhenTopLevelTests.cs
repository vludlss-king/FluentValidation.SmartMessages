using FluentValidation.TestHelper;
using FluentValidation.SmartMessages.Extensions;

namespace FluentValidation.SmartMessages.Tests.UnitTests
{
    public class WhenTopLevelTests
    {
        public WhenTopLevelTests()
        {
            
        }

        [Fact]
        public void Test()
        {
            var validator = new WhenTopLevelModelValidator();
            var model = new WhenTopLevelModel()
            {
                FirstName = null,
                SecondName = "test"
            };

            var result = validator.TestValidate(model);
        }

        public class WhenTopLevelModel
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
        }

        public class WhenTopLevelModelValidator : SmartValidator<WhenTopLevelModel>
        {
            public WhenTopLevelModelValidator()
            {
                When(model => model.FirstName != null, bag =>
                {
                    RuleFor(model => model.FirstName).Equal("FirstName1").AttachTo(bag);
                })
                .WithMessage(msg => $"{msg} Когда FirstName != null")
                .Otherwise(bag =>
                {
                    RuleFor(model => model.SecondName).Equal("SecondName1").AttachTo(bag);
                })
                .WithMessage(msg => $"{msg} Когда FirstName == null");
            }
        }
    }
}
