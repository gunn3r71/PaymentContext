using FluentValidation;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Messages;

namespace PaymentContext.Domain.Validations.AddressValidate
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.StreetName)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(5, 150)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            RuleFor(x => x.Number)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(1, 10)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            RuleFor(x => x.Neighborhood)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(5, 150)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            RuleFor(x => x.City)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(2, 25)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            RuleFor(x => x.State)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(2, 25)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            RuleFor(x => x.Country)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(2, 50)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
            RuleFor(x => x.ZipCode)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(5,5)
                .WithMessage(DefaultMessages.GetMessage("MinMaxPropertyLength"));
        }
    }
}