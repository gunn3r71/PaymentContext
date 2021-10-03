using FluentValidation;
using PaymentContext.Domain.Entities;
using System;

namespace PaymentContext.Domain.Validations.SubscriptionValidate
{
    public class SubscriptionValidation : AbstractValidator<Subscription>
    {
        public SubscriptionValidation()
        {
            RuleFor(x => x.CreateDate)
                .LessThanOrEqualTo(DateTime.UtcNow.AddHours(-3))
                .WithMessage("The {PropertyName} field cannot be greater than the current date.");
            RuleFor(x => x.ExpireDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddHours(-3))
                .WithMessage("The {PropertyName} field cannot be earlier than the current date");
        }
    }
}
