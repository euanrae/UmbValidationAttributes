using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UmbValidationAttributes.Services;

namespace UmbValidationAttributes.Helpers
{
    public static class AttributeInitialisationHelper
    {
        public static void Initialise(this ValidationAttribute attribute, string messageKey, string fallbackMessageKey = "")
        {
            if (string.IsNullOrWhiteSpace(messageKey))
            {
                throw new InvalidOperationException("Message key cannot be an empty string");
            }
            var validationMessageService =
                (IValidationMessageService)DependencyResolver.Current.GetService(typeof(IValidationMessageService));

            string errorMessage = validationMessageService.GetValue(messageKey, fallbackMessageKey);

            // don't set if it doesn't exist - allow default message
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                attribute.ErrorMessage = errorMessage;
            }
        }
    }
}
