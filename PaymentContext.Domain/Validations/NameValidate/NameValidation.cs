using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Validations;
using FluentValidation;
using PaymentContext.Shared.Messages;

namespace PaymentContext.Domain.Validations.NameValidate
{
    public class NameValidation : AbstractValidator<Name>
    {
        public NameValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(2, 30)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            
            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(2, 30)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
        }
    }
}
