using PaymentContext.Domain.Entities;
using System.Linq;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
        void UpdateSubscription(Student student);
    }
}
