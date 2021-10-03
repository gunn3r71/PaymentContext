using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, 
                          DateTime expireDate,
                          Money total,
                          Money totalPaid,
                          string payer,
                          Document document,
                          Address address)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public Money Total { get; private set; }
        public Money TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
    }
}