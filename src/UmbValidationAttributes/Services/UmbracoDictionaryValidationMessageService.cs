using Umbraco.Web;
using UmbValidationAttributes.ServiceWrappers;

namespace UmbValidationAttributes.Services
{
    public class UmbracoDictionaryValidationMessageService : BaseValidationMessageService, IValidationMessageService
    {
        private readonly IDictionaryService _dictionaryService;

        public UmbracoDictionaryValidationMessageService(IDictionaryService dictionaryService)
        {
            this._dictionaryService = dictionaryService;
        }

        public override string GetValueFromSource(string key)
        {
            return this._dictionaryService.GetDictionaryValue(key);
        }
    }
}
