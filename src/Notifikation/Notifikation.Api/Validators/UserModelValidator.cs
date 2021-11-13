using FluentValidation;
using Notifikation.Api.Models;

namespace Notifikation.Api.Validators
{
    public class UserModelValidator: AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("{Email} should be not empty. NEVER!");
        }
    }
}
