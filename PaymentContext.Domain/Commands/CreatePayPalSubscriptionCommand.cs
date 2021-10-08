using Flunt.Notifications;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public Name StudentName { get; set; }
        public Document StudentDocument { get; set; }
        public Email StudentEmail { get; set; }

        public string TransactionCode { get; set; }

        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Money Total { get; set; }
        public Money TotalPaid { get; set; }
        public string Payer { get; set; }
        public Document PayerDocument { get; set; }
        public Address PayerAddress { get; set; }

        public void Validate()
        {
            AddNotifications(StudentName, StudentDocument, StudentEmail, Total, TotalPaid, PayerDocument, PayerAddress);
        }
    }
}
