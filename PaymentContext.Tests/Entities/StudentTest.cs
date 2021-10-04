using FluentAssertions;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTest()
        {
            _name = new Name(firstName: "Axl", lastName: "Rose");
            _document = new Document(number: "36849153005", type: EDocumentType.CPF);
            _email = new Email(address: "axl@contatognr.com");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _address = new Address(streetName: "Rua josé 1",
                                  number: "22",
                                  neighborhood: "Cool neigh",
                                  city: "Cool town",
                                  state: "Cool state",
                                  country: "Cool country",
                                  zipCode: "02513335");
        }

        [Fact]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment(transactionCode: Guid.NewGuid().ToString().Replace("-", ""),
                                paidDate: DateTime.UtcNow.AddHours(-3),
                                expireDate: DateTime.UtcNow.AddHours(-3).AddYears(1),
                                total: new Money(100.00M),
                                totalPaid: new Money(100.00M),
                                payer: "GNR corp.",
                                document: new Document("40709904000105", EDocumentType.CNPJ),
                                _address);

            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);

            _student.AddSubscription(_subscription);

            _student.Invalid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            _student.Invalid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment(transactionCode: Guid.NewGuid().ToString().Replace("-", ""),
                    paidDate: DateTime.UtcNow.AddHours(-3),
                    expireDate: DateTime.UtcNow.AddHours(-3).AddYears(1),
                    total: new Money(100.00M),
                    totalPaid: new Money(100.00M),
                    payer: "GNR corp.",
                    document: new Document("40709904000105", EDocumentType.CNPJ),
                    _address);

            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);

            _student.Valid.Should().BeTrue();
        }
    }
}
