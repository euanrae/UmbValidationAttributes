using System;
using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Helpers;

namespace UmbValidationAttributes.Attributes
{
    public class UmbracoRequiredAttribute : RequiredAttribute
    {
        public UmbracoRequiredAttribute(string messageKey, string fallbackMessageKey = "", string defaultMessage = "")
        {
            if (string.IsNullOrWhiteSpace(messageKey))
            {
                throw new InvalidOperationException("Message key cannot be an empty string");
            }

            this.Initialise(messageKey, fallbackMessageKey, defaultMessage);
        }
    }
}
