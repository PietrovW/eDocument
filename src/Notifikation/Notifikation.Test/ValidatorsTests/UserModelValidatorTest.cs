using FluentValidation.TestHelper;
using Notifikation.Api.Validators;
using Xunit;

namespace Notifikation.Api.Test.Validators
{
    public class UserModelValidatorTest
    {
        private readonly UserModelValidator _validator;
        public UserModelValidatorTest()
        {
            _validator = new UserModelValidator();
        }
        

         [Fact]
        public void GivenAnInvalidUserModelValue_ShouldHaveValidationError()  => _validator.ShouldHaveValidationErrorFor(model => model.Email, string.Empty);
    }
}
