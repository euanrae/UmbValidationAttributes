using Umbraco.Web;

namespace UmbValidationAttributes.Services
{
    public class UmbracoDictionaryValidationMessageService : IValidationMessageService
    {
        private readonly UmbracoHelper _umbracoHelper;

        public UmbracoDictionaryValidationMessageService()
        {
            this._umbracoHelper = Umbraco.Web.Composing.Current.UmbracoHelper;
        }

        public string GetValue(string key, string defaultValue = "")
        {
            return this._umbracoHelper.GetDictionaryValue(key, defaultValue);
        }

        public string GetValue(string key, string defaultItemKey, string defaultValue = "")
        {
            string dictionaryValue = this._umbracoHelper.GetDictionaryValue(key);
            if (string.IsNullOrWhiteSpace(dictionaryValue) == false)
            {
                return dictionaryValue;
            }

            return this.GetValue(defaultItemKey, defaultValue);
        }
    }
}
