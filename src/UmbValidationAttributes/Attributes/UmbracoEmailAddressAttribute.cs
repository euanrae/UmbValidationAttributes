using System;
using UmbValidationAttributes.Attributes.BaseAttributes;
using UmbValidationAttributes.Helpers;

namespace UmbValidationAttributes.Attributes
{
    public class UmbracoEmailAddressAttribute : BaseEmailAddressAttribute
    {
        public UmbracoEmailAddressAttribute(string messageKey) : this(messageKey, "", "")
        {

        }
        public UmbracoEmailAddressAttribute(string messageKey, string fallbackMessageKey = "", string defaultMessage = "")
        {
            if (string.IsNullOrWhiteSpace(messageKey))
            {
                throw new InvalidOperationException("Message key cannot be an empty string");
            }

            this.Initialise(messageKey, fallbackMessageKey, defaultMessage);
        }
    }
}
