using FluentValidation.Results;
using System.Collections.Generic;

namespace PaymentContext.Shared.Models
{
    public record ValidationModel
    {
        public ValidationModel(bool hasErrors, List<ValidationFailure> errors)
        {
            HasErrors = hasErrors;
            Errors = errors;
        }

        public bool HasErrors { get; init; }
        public List<ValidationFailure> Errors { get; init; }
    }
}
