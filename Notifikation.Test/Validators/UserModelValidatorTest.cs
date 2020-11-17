using FluentValidation.TestHelper;
using Notifikation.Api.Validators;
using Xunit;

namespace Notifikation.Test.Validators
{
    public class UserModelValidatorTest
    {
        private readonly UserModelValidator _validator = new UserModelValidator();

            [Fact]
        public void GivenAnInvalidUserModelValue_ShouldHaveValidationError()  => _validator.ShouldHaveValidationErrorFor(model => model.Email, "");
    }
}
