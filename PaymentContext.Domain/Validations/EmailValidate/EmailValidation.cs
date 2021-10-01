using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations.EmailValidate
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .EmailAddress()
                .WithMessage("Invalid {PropertyName}");
        }
    }
}
