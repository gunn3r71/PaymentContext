using PaymentContext.Domain.Validations.EmailValidate;
using PaymentContext.Shared.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            var result = Validator.Validate(new EmailValidation(), this);
            if (result.HasErrors) result.Errors.ForEach(error => AddNotification(error.PropertyName, error.ErrorMessage));
        }

        public string Address { get; private set; }
    }
}
