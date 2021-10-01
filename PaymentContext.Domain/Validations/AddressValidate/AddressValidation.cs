using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations.AddressValidate
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.StreetName)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(5, 150)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            RuleFor(x => x.Number)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(1, 10)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            RuleFor(x => x.Neighborhood)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(5, 150)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            RuleFor(x => x.City)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(2, 25)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            RuleFor(x => x.State)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(2, 25)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            RuleFor(x => x.Country)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(2, 50)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
            RuleFor(x => x.ZipCode)
                .NotNull()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(5,5)
                .WithMessage("The {PropertyName} field must have length between {MinLength} and {MaxLength} characters.");
        }
    }
}