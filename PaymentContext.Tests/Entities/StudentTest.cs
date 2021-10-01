using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;
using Xunit.Abstractions;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        public StudentTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        private readonly ITestOutputHelper _outputHelper;

        [Fact]
        public void AddName()
        {
            var name = new Name("L", "L");

            foreach (var notification in name.Notifications)
            {
                _outputHelper.WriteLine(notification.Message);
            }
        }

        [Fact]
        public void AddDocument()
        {
            var document = new Document("51566495806", EDocumentType.CPF);

            foreach (var notification in document.Notifications)
            {
                _outputHelper.WriteLine(notification.Message);
            }

            document = new Document("5156649580671", EDocumentType.CPF);
            
            foreach (var notification in document.Notifications)
            {
                _outputHelper.WriteLine($"{notification.Property} - {notification.Message}");
            }
        }
    }
}
