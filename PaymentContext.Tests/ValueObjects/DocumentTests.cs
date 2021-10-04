using FluentAssertions;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {
        // Red, green, refactor
        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document(number: "111223",type: EDocumentType.CNPJ);

            document.Invalid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document(number: "09978805000189", type: EDocumentType.CNPJ);

            document.Valid.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document(number: "5156649580", type: EDocumentType.CPF);

            document.Invalid.Should().BeTrue();
        }

        [Theory]
        [InlineData("32535155087")]
        [InlineData("84004040094")]
        [InlineData("40615111068")]
        [InlineData("07856319097")]
        [InlineData("29564832004")]
        [InlineData("64828772065")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(number: cpf, type: EDocumentType.CPF);

            document.Valid.Should().BeTrue();
        }
    }
}
