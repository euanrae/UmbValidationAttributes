using System;
using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Helpers;

namespace UmbValidationAttributes.Attributes
{
    public class UmbracoRegexAttribute : RegularExpressionAttribute
    {
        public UmbracoRegexAttribute(string pattern, string messageKey) : this(pattern, messageKey, "", "")
        {

        }
        public UmbracoRegexAttribute(string pattern, string messageKey, string fallbackMessageKey = "", string defaultMessage = "")
            :base (pattern)
        {
            if (string.IsNullOrWhiteSpace(messageKey))
            {
                throw new InvalidOperationException("Message key cannot be an empty string");
            }

            this.Initialise(messageKey, fallbackMessageKey, defaultMessage);
        }
    }
}
