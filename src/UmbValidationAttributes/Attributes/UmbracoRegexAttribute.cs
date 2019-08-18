using System;
using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Helpers;

namespace UmbValidationAttributes.Attributes
{
    /// <summary>
    /// RequiredAttribute that gets error message from Umbraco
    /// </summary>
    public class UmbracoRegexAttribute : RegularExpressionAttribute
    {
        /// <summary>
        /// Create with a message key - will fallback to RequiredAttribute default message if none found
        /// </summary>
        /// <param name="messageKey">Key for the message when validation fails</param>
        public UmbracoRegexAttribute(string pattern, string messageKey) : this(pattern, messageKey, "", "")
        {

        }
        /// <summary>
        /// Create with a message key - will fallback to RequiredAttribute default message if none found
        /// </summary>
        /// <param name="messageKey">Key for the message when validation fails</param>
        /// <param name="fallbackMessageKey">Key for a default message if 'messageKey' value returns null</param>
        /// <param name="defaultMessage">Hard coded default message if none is found from messageKey + fallbackMessageKey</param>
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
