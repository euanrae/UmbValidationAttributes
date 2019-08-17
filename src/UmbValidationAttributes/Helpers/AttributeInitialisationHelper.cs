using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UmbValidationAttributes.Services;

namespace UmbValidationAttributes.Helpers
{
    public static class AttributeInitialisationHelper
    {
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
