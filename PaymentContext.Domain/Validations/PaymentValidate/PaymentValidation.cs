using FluentValidation;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Messages;
using System;

namespace PaymentContext.Domain.Validations.PaymentValidate
{
    public class PaymentValidation : AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            RuleFor(x => x.Number)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(10,10)
                .WithMessage(DefaultMessages.GetMessage("MaxPropertyLength"));
            RuleFor(x => x.PaidDate)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"));
            RuleFor(x => x.Payer)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Length(2, 90)
                .WithMessage(DefaultMessages.GetMessage("MaxPropertyLength"));
            RuleFor(x => x.Total)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Must(NotBeANegativeValue);
            RuleFor(x => x.TotalPaid)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .Must(NotBeANegativeValue);
            RuleFor(x => x.ExpireDate)
                .NotNull()
                .WithMessage(DefaultMessages.GetMessage("Required"))
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddHours(-3));
        }

        private bool NotBeANegativeValue(Money value)
        {
            return value.Value > 0;
        }
    }
}
