using PaymentContext.Domain.Entities;
using Xunit;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        [Fact]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription();
            var student = new Student(firstName: "Lucas",
                                      lastName: "Pere'ira",
                                      document: "51566495806",
                                      email: "lucas.p.oliveira@outlook.pt");
            student.AddSubscription(subscription);
        }
    }
}
