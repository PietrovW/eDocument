﻿using FluentValidation.TestHelper;
using Notifikation.Api.Validators;
using Xunit;

namespace Notifikation.Api.Test.Validators
{
    public class NotifikationModelValidatorTest
    {
        private readonly UserModelValidator _validator;
        public NotifikationModelValidatorTest()
        {
            _validator = new UserModelValidator();
        }

        [Fact]
        public void GivenAnInvalidNotifikationModelValue_ShouldHaveValidationError() => _validator.ShouldHaveValidationErrorFor(model => model.Message, string.Empty);
    }
}
