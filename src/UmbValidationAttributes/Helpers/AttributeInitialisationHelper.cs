using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UmbValidationAttributes.Services;

namespace UmbValidationAttributes.Helpers
{
    /// <summary>
    /// Class to help initialise a helper by getting the error message out of the message service
    /// </summary>
    public static class AttributeInitialisationHelper
    {
        /// <summary>
        /// Initialise a validation attribute and set the error message
        /// </summary>
        /// <param name="attribute">validation instance to initialise</param>
        /// <param name="messageKey">Key for the message when validation fails</param>
        /// <param name="fallbackMessageKey">Key for a default message if 'messageKey' value returns null</param>
        /// <param name="defaultMessage">Hard coded default message if none is found from messageKey + fallbackMessageKey</param>
        public static void Initialise(this ValidationAttribute attribute, string messageKey, string fallbackMessageKey = "", string defaultMessage = "")
        {
            if (string.IsNullOrWhiteSpace(messageKey))
            {
                throw new InvalidOperationException("Message key cannot be an empty string");
            }
            var validationMessageService =
                (IValidationMessageService)DependencyResolver.Current.GetService(typeof(IValidationMessageService));

            string errorMessage = validationMessageService.GetValue(messageKey, fallbackMessageKey);

            // finally set the default message if it's been passed
            if (string.IsNullOrWhiteSpace(errorMessage) == true)
            {
                errorMessage = defaultMessage;
            }

            // don't set if it doesn't exist - allow default message from the attribute its self
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                attribute.ErrorMessage = errorMessage;
            }
        }
    }
}
