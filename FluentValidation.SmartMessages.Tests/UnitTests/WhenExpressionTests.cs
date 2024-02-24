using FluentAssertions;
using FluentValidation.SmartMessages.Extensions;
using FluentValidation.TestHelper;

namespace FluentValidation.SmartMessages.Tests.UnitTests
{
    public class WhenExpressionTests
    {
        [Fact]
        public void When_expression_apply_to_current_validator_should_replace_previous_message()
        {
            var validator = new WhenExpressionApplyToCurrentValidator();
            var model = new WhenExpressionModel();

            var result = validator.Validate(model);

            result.Errors[0].ErrorMessage.Should().BeEquivalentTo("'First Name' must not be empty. Когда SecondName == null для NotEmpty (CurrentValidator)");
            result.Errors[1].ErrorMessage.Should().BeEquivalentTo("'First Name' must be equal to 'Foo'. Когда SecondName == null для Equal (CurrentValidator)");
        }
        internal class WhenExpressionApplyToCurrentValidator : SmartValidator<WhenExpressionModel>
        {
            public WhenExpressionApplyToCurrentValidator()
            {
                RuleFor(customer => customer.FirstName)
                    .NotEmpty()
                        .When(customer => customer.SecondName == null, msg => $"{msg} Когда SecondName == null для NotEmpty (CurrentValidator)", ApplyConditionTo.CurrentValidator)
                    .Equal("Foo")
                        .When(customer => customer.SecondName == null, msg => $"{msg} Когда SecondName == null для Equal (CurrentValidator)", ApplyConditionTo.CurrentValidator);
            }
        }

        [Fact]
        public void When_expression_apply_to_all_validators_should_replace_previous_message()
        {
            var validator = new WhenExpressionApplyToAllValidators();
            var model = new WhenExpressionModel();

            var result = validator.Validate(model);

            result.Errors[0].ErrorMessage.Should().BeEquivalentTo("'First Name' must not be empty. Когда SecondName == null для всех (AllValidators)");
            result.Errors[1].ErrorMessage.Should().BeEquivalentTo("'First Name' must be equal to 'Foo'. Когда SecondName == null для всех (AllValidators)");
        }

        internal class WhenExpressionApplyToAllValidators : SmartValidator<WhenExpressionModel>
        {
            public WhenExpressionApplyToAllValidators()
            {
                RuleFor(customer => customer.FirstName)
                    .NotEmpty()
                    .Equal("Foo")
                        .When(customer => customer.SecondName == null, msg => $"{msg} Когда SecondName == null для всех (AllValidators)");
            }
        }

        internal class WhenExpressionModel
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
        }
    }

    
}
