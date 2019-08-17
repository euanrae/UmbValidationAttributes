using Umbraco.Web;

namespace UmbValidationAttributes.ServiceWrappers
{
    public class DictionaryService : IDictionaryService
    {
        private readonly UmbracoHelper _umbracoHelper;

        /// <summary>
        /// This is a kind of fake for DI that allows us to test this
        /// </summary>
        public DictionaryService() : this(Umbraco.Web.Composing.Current.UmbracoHelper)
        {

        }

        public DictionaryService(UmbracoHelper umbracoHelper)
        {
            this._umbracoHelper = umbracoHelper;
        }
        public string GetDictionaryValue(string key)
        {
            return this._umbracoHelper.GetDictionaryValue(key);
        }
    }
}
