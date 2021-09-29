using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public string Document { get; private set; }
        public string Address { get; private set; }
    }

    public class CreditCardPayment : Payment
    {
        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }

    public class BoletoPayment : Payment
    {
        public string BarCode { get; private set; }
        public string Email { get; private set; }
        public string BoletoNumber { get; private set; }
    }

    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; private set; }
    }
}