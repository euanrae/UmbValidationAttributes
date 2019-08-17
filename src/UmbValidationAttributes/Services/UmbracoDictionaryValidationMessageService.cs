using Umbraco.Web;

namespace UmbValidationAttributes.Services
{
    public class UmbracoDictionaryValidationMessageService : BaseValidationMessageService, IValidationMessageService
    {
        private readonly UmbracoHelper _umbracoHelper;

        /// <summary>
        /// This is a kind of fake for DI that allows us to test this
        /// </summary>
        public UmbracoDictionaryValidationMessageService() : this(Umbraco.Web.Composing.Current.UmbracoHelper)
        {
            
        }

        public UmbracoDictionaryValidationMessageService(UmbracoHelper umbracoHelper)
        {
            this._umbracoHelper = umbracoHelper;
        }

        public override string GetValueFromSource(string key)
        {
            return this._umbracoHelper.GetDictionaryValue(key, string.Empty);
        }
    }
}
