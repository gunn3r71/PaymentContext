using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Validations;
using FluentValidation;

namespace PaymentContext.Domain.Validations
{
    public class NameValidation : AbstractValidator<Name>
    {
        public NameValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(2, 30)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            
            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(2, 30)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
        }
    }
}
