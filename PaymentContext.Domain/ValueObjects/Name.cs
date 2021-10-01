using PaymentContext.Domain.Validations.NameValidate;
using PaymentContext.Shared.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            var result = Validator.Validate(new NameValidation(), this);
            if (result.HasErrors) result.Errors.ForEach(x => AddNotification(x.PropertyName, x.ErrorMessage));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
