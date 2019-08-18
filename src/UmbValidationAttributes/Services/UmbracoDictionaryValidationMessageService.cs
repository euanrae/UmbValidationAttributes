using Umbraco.Web;
using UmbValidationAttributes.ServiceWrappers;

namespace UmbValidationAttributes.Services
{
    /// <summary>
    /// Service implementation to get Validation messages out of the Umbraco Dictionary
    /// </summary>
    public class UmbracoDictionaryValidationMessageService : BaseValidationMessageService, IValidationMessageService
    {
        private readonly IDictionaryService _dictionaryService;

        /// <summary>
        /// Default constructor for dictionary validation message service
        /// </summary>
        /// <param name="dictionaryService">An IDictionaryService that gets a value from the corresponding key</param>
        public UmbracoDictionaryValidationMessageService(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        /// <summary>
        /// Implementation of abstract parent class 
        /// </summary>
        /// <param name="key">Dictionary key</param>
        /// <returns></returns>
        public override string GetValueFromSource(string key)
        {
            return _dictionaryService.GetDictionaryValue(key);
        }
    }
}
