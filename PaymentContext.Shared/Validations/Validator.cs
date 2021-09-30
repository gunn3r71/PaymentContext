using FluentValidation;
using FluentValidation.Results;
using PaymentContext.Shared.Models;
using System.Collections.Generic;

namespace PaymentContext.Shared.Validations
{
    public static class Validator
    {
        public static ValidationModel Validate<TValidator, TEntity>(TValidator validator, TEntity entity) where TEntity : class where TValidator : AbstractValidator<TEntity>
        {
            var result = validator.Validate(entity);

            if (!result.IsValid)
                return new ValidationModel(hasErrors: true, errors: result.Errors);

            return new ValidationModel(hasErrors: false,errors: null);
        }
    }
}
