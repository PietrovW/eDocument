using FluentValidation;
using Notifikation.Infrastructure.Command;

namespace Notifikation.Infrastructure.CommandValidator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.User).NotNull();
            RuleFor(x => x.User.Name).NotEmpty().NotNull();
        }
    }
}
