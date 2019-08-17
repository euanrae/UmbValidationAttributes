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
        public string GetValue(string key)
        {
            return GetValueFromCurrentPage(key);
        }

        public string GetValue(string key, string defaultItemKey)
        {
            string value = GetValue(key);
            if (String.IsNullOrWhiteSpace(value) == false)
            {
                return value;
            }
            return GetValue(defaultItemKey);
        }

        private string GetValueFromCurrentPage(string propertyAlias)
        {
            IPublishedContent currentPage = GetCurrentPage();

            if (currentPage == null)
            {
                return string.Empty;
            }

            // return an empty string if nothing found, we don't want
            // this layer returning a default value
            return currentPage.Value<string>(propertyAlias, defaultValue: string.Empty);
        }

        private IPublishedContent GetCurrentPage()
        {
            return Umbraco.Web.Composing.Current.UmbracoContext?.PublishedRequest?.PublishedContent;
        }
    }
}
