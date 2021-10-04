using Flunt.Notifications;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Commands
{
    internal class CreateCreditCardSubscriptionCommand : Notifiable, ICommand
    {
        public Name StudentName { get; set; }
        public Document StudentDocument { get; set; }
        public Email StudentEmail { get; set; }

        public CreditCardPayment Payment { get; set; }

        public void Validate()
        {
            AddNotifications(StudentName, StudentDocument, StudentEmail, Payment);
        }
    }
}
