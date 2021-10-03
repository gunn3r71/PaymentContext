using PaymentContext.Domain.Validations.SubscriptionValidate;
using PaymentContext.Shared.Entities;
using PaymentContext.Shared.Validations;
using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.UtcNow.AddHours(-3);
            LastUpdateDate = DateTime.UtcNow.AddHours(-3);
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();

            var result = Validator.Validate(new SubscriptionValidation(), this);
            if (result.HasErrors) result.Errors.ForEach(error => AddNotification(error.PropertyName, error.ErrorMessage));
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }

        private List<Payment> _payments;
        public IReadOnlyCollection<Payment> Payments { get { return _payments; }}   

        public void AddPayment(Payment payment)
        {
            if (payment.PaidDate > DateTime.UtcNow.AddHours(-3)) AddNotification(nameof(payment.PaidDate), "Payment date is greater than current date.");

            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.UtcNow.AddHours(-3);
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.UtcNow.AddHours(-3);
        }
    }
}