using System.Collections.Generic;

namespace PaymentContext.Shared.Messages
{
    public static class DefaultMessages
    {
        private static Dictionary<string, string> Messages = new Dictionary<string, string> {
            {"Required", "The {PropertyName} field needs to be provided."},
            {"MinMaxPropertyLength", "The {PropertyName} field must have length between {MinLength} and {MaxLength} characters."},
            {"MaxPropertyLength", "The {PropertyName} field must be {MaxLength} characters long."},
            {"InvalidProperty", "Invalid {PropertyName}." }
        };

        public static string GetMessage(string key)
        {
            return Messages.GetValueOrDefault(key);
        }
    }
}
