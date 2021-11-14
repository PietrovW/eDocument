using FluentValidation;
using Notifikation.Infrastructure.Command;

namespace Notifikation.Infrastructure.CommandValidator
{
    public class CreateNotifikationCommandValidator : AbstractValidator<CreateNotifikationCommand>
    {
        public CreateNotifikationCommandValidator()
        {
            RuleFor(x => x.Notifikation).NotNull();
            RuleFor(x => x.Notifikation.Message).NotEmpty().NotNull();
        }
    }
}
