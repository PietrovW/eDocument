using FluentValidation;
using Notifikation.Api.Models;

namespace Notifikation.Api.Validators
{
    public class NotifikationModelValidator : AbstractValidator<NotifikationModel>
    {
        public NotifikationModelValidator()
        {
            RuleFor(p => p.Message)
               .NotEmpty().WithMessage("{Message} should be not empty. NEVER!");
            RuleFor(p => p.User)
               .NotNull().WithMessage("{User} should be not Null. NEVER!");
        }
    }
}
