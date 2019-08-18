using System;
using UmbValidationAttributes.Attributes.BaseAttributes;
using UmbValidationAttributes.Helpers;

namespace UmbValidationAttributes.Attributes
{
    /// <summary>
    /// EmailAttribute that gets error message from Umbraco
    /// </summary>
    public class UmbracoEmailAddressAttribute : BaseEmailAddressAttribute
    {
        /// <summary>
        /// Create with a message key - will fallback to RequiredAttribute default message if none found
        /// </summary>
        /// <param name="messageKey">Key for the message when validation fails</param>
        public UmbracoEmailAddressAttribute(string messageKey) : this(messageKey, "", "")
        {

        }

        /// <summary>
        /// Create with a message key - will fallback to RequiredAttribute default message if none found
        /// </summary>
        /// <param name="messageKey">Key for the message when validation fails</param>
        /// <param name="fallbackMessageKey">Key for a default message if 'messageKey' value returns null</param>
        /// <param name="defaultMessage">Hard coded default message if none is found from messageKey + fallbackMessageKey</param>
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
