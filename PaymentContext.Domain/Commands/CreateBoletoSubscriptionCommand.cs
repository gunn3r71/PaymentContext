using Flunt.Notifications;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public Name StudentName { get; set; }
        public Document StudentDocument { get; set; }
        public Email StudentEmail { get; set; }

        public string BarCode { get; set; }
        public Email Email { get; set; }
        public string BoletoNumber { get; set; }

        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Money Total { get; set; }
        public Money TotalPaid { get; set; }
        public string Payer { get; set; }
        public Document PayerDocument { get; set; }
        public Address PayerAddress { get; set; }

        public void Validate()
        {
            AddNotifications(StudentName, StudentDocument, StudentEmail, Email, Total, TotalPaid, PayerDocument, PayerAddress);
        }
    }
}
