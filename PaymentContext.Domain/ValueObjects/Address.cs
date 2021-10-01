using PaymentContext.Domain.Validations.AddressValidate;
using PaymentContext.Shared.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string streetName,
                       string number,
                       string neighborhood,
                       string city,
                       string state,
                       string country,
                       string zipCode)
        {
            StreetName = streetName;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            var result = Validator.Validate(new AddressValidation(), this);
            if (result.HasErrors) result.Errors.ForEach(error => AddNotification(error.PropertyName, error.ErrorMessage));
        }

        public string StreetName { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}
