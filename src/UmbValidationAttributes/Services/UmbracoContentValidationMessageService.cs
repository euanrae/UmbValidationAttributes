using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace UmbValidationAttributes.Services
{
    public class UmbracoContentValidationMessageService : IValidationMessageService
    {
        public string GetValue(string key, string defaultValue = "")
        {
            return GetValueFromCurrentPage(key, defaultValue);
        }

        public string GetValue(string key, string defaultItemKey, string defaultValue = "")
        {
            string value = GetValueFromCurrentPage(key, string.Empty);
            if (String.IsNullOrWhiteSpace(value) == false)
            {
                return value;
            }
            return GetValueFromCurrentPage(defaultItemKey, string.Empty);
        }

        private string GetValueFromCurrentPage(string propertyAlias, string fallbackText)
        {
            IPublishedContent currentPage = GetCurrentPage();

            if (currentPage == null)
            {
                return string.Empty;
            }

            return currentPage.Value<string>(propertyAlias, defaultValue: fallbackText);
        }

        private IPublishedContent GetCurrentPage()
        {
            return Umbraco.Web.Composing.Current.UmbracoContext?.PublishedRequest?.PublishedContent;
        }
    }
}
