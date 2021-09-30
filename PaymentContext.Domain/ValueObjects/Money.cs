using System;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public Money(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; private set; }

        public static Money operator +(Money a) => +a;
        public static Money operator -(Money a) => -a;
        public static Money operator -(Money a, Money b) => a - b;
        public static Money operator +(Money a, Money b) => a + b;
        public static Money operator *(Money a, Money b) => a * b;

        public static Money operator /(Money a, Money b)
        {
            if (b.Value == 0)
                throw new DivideByZeroException("Divider cannot be zero");
            return a / b;
        }
    }
}
