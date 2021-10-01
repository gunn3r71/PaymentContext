using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validations.DocumentValidate;
using PaymentContext.Shared.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            var result = Validator.Validate(new DocumentValidation(), this);
            if (result.HasErrors) result.Errors.ForEach(x => AddNotification(x.PropertyName, x.ErrorMessage));
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}
