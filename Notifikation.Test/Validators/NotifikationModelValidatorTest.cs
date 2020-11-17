using FluentValidation.TestHelper;
using Notifikation.Api.Validators;
using Xunit;

namespace Notifikation.Test.Validators
{
    public class NotifikationModelValidatorTest
    {
        private readonly NotifikationModelValidator _validator = new NotifikationModelValidator();

        [Fact]
        public void GivenAnInvalidNotifikationModelValue_ShouldHaveValidationError() => _validator.ShouldHaveValidationErrorFor(model => model.Message, string.Empty);
    }
}
