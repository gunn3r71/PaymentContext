using PaymentContext.Domain.Enums;
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

            if (string.IsNullOrEmpty(Number))
                AddNotification(nameof(Number), "The field number cannot be null.");
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}
