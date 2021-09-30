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
    }
}
