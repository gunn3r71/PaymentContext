using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode,
                             DateTime paidDate,
                             DateTime expireDate,
                             Money total,
                             Money totalPaid,
                             string payer,
                             Document document,
                             Address address)
               : base(paidDate,
                      expireDate,
                      total,
                      totalPaid,
                      payer,
                      document,
                      address)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}