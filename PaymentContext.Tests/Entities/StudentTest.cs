using PaymentContext.Domain.Entities;
using System;
using Xunit;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        [Fact]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(expireDate: null);
            var student = new Student(firstName: "Lucas",
                                      lastName: "Pereira",
                                      document: "51566495806",
                                      email: "lucas.p.oliveira@outlook.pt");
            student.AddSubscription(subscription);

            var payment = new PayPalPayment(transactionCode: "2500001",
                                            paidDate: DateTime.UtcNow.AddHours(-3),
                                            expireDate: DateTime.UtcNow.AddMonths(3),
                                            total: 150.00M,
                                            totalPaid: 150.00M,
                                            payer: "Lucas Pereira",
                                            document: "51566495806",
                                            address: "SP");
        }
    }
}
