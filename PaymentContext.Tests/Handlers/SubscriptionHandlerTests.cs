using FluentAssertions;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
using System;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            command.StudentName = new Name("João","Paulo");
            command.StudentDocument = new Document("78608644010", EDocumentType.CPF);
            command.StudentEmail = new Email("lucas@lc.com");
            command.BarCode = Guid.NewGuid().ToString().Replace("-","");
            command.Email = new Email("cont@cont.com");
            command.BoletoNumber = new Random().Next(11111111, 130111111).ToString();
            command.PaidDate = DateTime.UtcNow.AddHours(-3);
            command.ExpireDate = DateTime.UtcNow.AddHours(-3).AddMonths(1);
            command.Total = new Money(300);
            command.TotalPaid = new Money(300);
            command.Payer = "João Paulo";
            command.PayerDocument = new Document("78608644010", EDocumentType.CPF);
            command.PayerAddress = new Address("Rua 123",
                                               "225",
                                               "Legla",
                                               "SP",
                                               "SP",
                                               "Brazil",
                                               "00034330");

            handler.Handle(command);
            
            handler.Invalid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnSuccessWhenDocumentDoesNotExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            command.StudentName = new Name("João", "Paulo");
            command.StudentDocument = new Document("51566495806", EDocumentType.CPF);
            command.StudentEmail = new Email("lucas@lc.com");
            command.BarCode = Guid.NewGuid().ToString().Replace("-", "");
            command.Email = new Email("cont@cont.com");
            command.BoletoNumber = new Random().Next(11111111, 130111111).ToString();
            command.PaidDate = DateTime.UtcNow.AddHours(-3);
            command.ExpireDate = DateTime.UtcNow.AddHours(-3).AddMonths(1);
            command.Total = new Money(300);
            command.TotalPaid = new Money(300);
            command.Payer = "João Paulo";
            command.PayerDocument = new Document("78608644010", EDocumentType.CPF);
            command.PayerAddress = new Address("Rua 123",
                                               "225",
                                               "Legla",
                                               "SP",
                                               "SP",
                                               "Brazil",
                                               "00034330");

            handler.Handle(command);

            handler.Valid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnErrorWhenEmailExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            command.StudentName = new Name("João", "Paulo");
            command.StudentDocument = new Document("51566495806", EDocumentType.CPF);
            command.StudentEmail = new Email("lc@lc.com");
            command.BarCode = Guid.NewGuid().ToString().Replace("-", "");
            command.Email = new Email("cont@cont.com");
            command.BoletoNumber = new Random().Next(11111111, 130111111).ToString();
            command.PaidDate = DateTime.UtcNow.AddHours(-3);
            command.ExpireDate = DateTime.UtcNow.AddHours(-3).AddMonths(1);
            command.Total = new Money(300);
            command.TotalPaid = new Money(300);
            command.Payer = "João Paulo";
            command.PayerDocument = new Document("78608644010", EDocumentType.CPF);
            command.PayerAddress = new Address("Rua 123",
                                               "225",
                                               "Legla",
                                               "SP",
                                               "SP",
                                               "Brazil",
                                               "00034330");

            handler.Handle(command);

            handler.Invalid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnSuccessWhenEmailDoesNotExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            command.StudentName = new Name("João", "Paulo");
            command.StudentDocument = new Document("51566495806", EDocumentType.CPF);
            command.StudentEmail = new Email("lucky@lc.com");
            command.BarCode = Guid.NewGuid().ToString().Replace("-", "");
            command.Email = new Email("cont@cont.com");
            command.BoletoNumber = new Random().Next(11111111, 130111111).ToString();
            command.PaidDate = DateTime.UtcNow.AddHours(-3);
            command.ExpireDate = DateTime.UtcNow.AddHours(-3).AddMonths(1);
            command.Total = new Money(300);
            command.TotalPaid = new Money(300);
            command.Payer = "João Paulo";
            command.PayerDocument = new Document("78608644010", EDocumentType.CPF);
            command.PayerAddress = new Address("Rua 123",
                                               "225",
                                               "Legla",
                                               "SP",
                                               "SP",
                                               "Brazil",
                                               "00034330");

            handler.Handle(command);

            handler.Valid.Should().BeTrue();
        }
    }
}
