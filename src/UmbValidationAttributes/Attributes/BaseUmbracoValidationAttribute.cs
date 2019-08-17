using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UmbValidationAttributes.Services;

namespace UmbValidationAttributes.Attributes
{
    public class BaseUmbracoValidationAttribute : ValidationAttribute
    {
        private readonly IValidationMessageService _validationMessageService;

        public BaseUmbracoValidationAttribute(string messageKey, string fallbackMessageKey = "", string defaultMessage = "")
        {
            this._validationMessageService = DependencyResolver.Current.GetService<IValidationMessageService>();
        }

        public string MessageKey { get; set; }
        public string FallbackMessageKey { get; set; }
        public string DefaultMessage { get; set; }
    }
}
