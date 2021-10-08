using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable,
        ICommandHandler<CreateBoletoSubscriptionCommand>,
        ICommandHandler<CreateCreditCardSubscriptionCommand>,
        ICommandHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Unable to register.");
            }

            if (_studentRepository.DocumentExists(command.StudentDocument.Number))
                AddNotification("Student.Document", "This document is already registered.");
            
            if (_studentRepository.EmailExists(command.StudentEmail.Address))
                AddNotification("Student.Email", "This email is already registered.");

            var name = command.StudentName;
            var document = command.StudentDocument;
            var email = command.StudentEmail;
            var address = command.PayerAddress;

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.UtcNow.AddHours(-3).AddMonths(1));

            var payment = new BoletoPayment(command.BarCode,
                                            command.Email,
                                            command.BoletoNumber,
                                            command.PaidDate,
                                            command.ExpireDate,
                                            command.Total,
                                            command.TotalPaid,
                                            command.Payer,
                                            command.PayerDocument,
                                            command.PayerAddress);

            subscription.AddPayment(payment);

            student.AddSubscription(subscription);

            AddNotifications(document, email, address, student, subscription, payment);

            _studentRepository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(),
                               student.Email.Address,
                               "Welcome to Lucas.IO",
                               "Sucessful subscription, enjoy your course.");

            return new CommandResult(true, "successful subscription");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Unable to register.");
            }

            if (_studentRepository.DocumentExists(command.StudentDocument.Number))
                AddNotification("Student.Document", "This document is already registered.");

            if (_studentRepository.EmailExists(command.StudentEmail.Address))
                AddNotification("Student.Email", "This email is already registered.");

            var name = command.StudentName;
            var document = command.StudentDocument;
            var email = command.StudentEmail;
            var address = command.PayerAddress;

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.UtcNow.AddHours(-3).AddMonths(1));

            var payment = new CreditCardPayment(command.CardHolderName,
                                                command.CardNumber,
                                                command.LastTransactionNumber,
                                                command.PaidDate,
                                                command.ExpireDate,
                                                command.Total,
                                                command.TotalPaid,
                                                command.Payer,
                                                command.PayerDocument,
                                                command.PayerAddress);

            subscription.AddPayment(payment);

            student.AddSubscription(subscription);

            AddNotifications(document, email, address, student, subscription, payment);

            _studentRepository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(),
                               student.Email.Address,
                               "Welcome to Lucas.IO",
                               "Sucessful subscription, enjoy your course.");

            return new CommandResult(true, "successful subscription");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Unable to register.");
            }

            if (_studentRepository.DocumentExists(command.StudentDocument.Number))
                AddNotification("Student.Document", "This document is already registered.");

            if (_studentRepository.EmailExists(command.StudentEmail.Address))
                AddNotification("Student.Email", "This email is already registered.");

            var name = command.StudentName;
            var document = command.StudentDocument;
            var email = command.StudentEmail;
            var address = command.PayerAddress;

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.UtcNow.AddHours(-3).AddMonths(1));

            var payment = new PayPalPayment(command.TransactionCode,
                                            command.PaidDate,
                                            command.ExpireDate,
                                            command.Total,
                                            command.TotalPaid,
                                            command.Payer,
                                            command.PayerDocument,
                                            command.PayerAddress);

            subscription.AddPayment(payment);

            student.AddSubscription(subscription);

            AddNotifications(document, email, address, student, subscription, payment);

            _studentRepository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(),
                               student.Email.Address,
                               "Welcome to Lucas.IO",
                               "Sucessful subscription, enjoy your course.");

            return new CommandResult(true, "successful subscription");
        }
    }
}
