using FluentValidation;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations.DocumentValidate
{
    public class DocumentValidation : AbstractValidator<Document>
    {
        public DocumentValidation()
        {
            RuleFor(x => x)
                .Must(x =>
                {
                    bool result = false;
                    if (x.Type.Equals(EDocumentType.CPF))
                        result = DocumentCustomValidator.ValidateCpf(x.Number);
                    else
                        result = DocumentCustomValidator.ValidateCnpj(x.Number);

                    return result;
                })
                .WithMessage("Invalid document."); 
        }
    }
}
