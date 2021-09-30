using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.UtcNow.AddHours(-3);
            LastUpdateDate = DateTime.UtcNow.AddHours(-3);
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }

        private List<Payment> _payments;
        public IReadOnlyCollection<Payment> Payments { get { return _payments; }}   

        public void AddPayment(Payment payment)
        {
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