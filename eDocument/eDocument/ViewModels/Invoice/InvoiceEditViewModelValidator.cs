using FluentValidation;
namespace eDocument.ViewModels.Invoice
{
    public class InvoiceEditViewModelValidator : AbstractValidator<InvoiceEditViewModel>
    {
        public InvoiceEditViewModelValidator()
        {
            //Validation logic here
            //RuleFor(user => user.UserName).NotEmpty().WithMessage("Username cannot be empty");
            //RuleFor(user => user.Email).EmailAddress().NotEmpty();
            //RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty").Length(4, 20);
        }
    }
}