using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
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

        public BoletoPayment Payment { get; set; }
        public EDocumentType PayerDocumentType { get; set; }

        public void Validate()
        {
            AddNotifications(StudentName, StudentDocument, StudentEmail, Payment);
        }
    }
}
