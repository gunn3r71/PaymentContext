using FluentValidation;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Messages;

namespace PaymentContext.Domain.Validations.EmailValidate
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .EmailAddress()
                .WithMessage(DefaultMessages.GetMessage("InvalidProperty"));
        }
    }
}
