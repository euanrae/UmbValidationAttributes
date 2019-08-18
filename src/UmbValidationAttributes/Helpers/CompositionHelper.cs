using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbValidationAttributes.Services;
using UmbValidationAttributes.ServiceWrappers;

namespace UmbValidationAttributes.Helpers
{
    /// <summary>
    /// Helper extension to register services for validation message from Umbraco
    /// </summary>
    public static class CompositionHelper
    {
        /// <summary>
        /// Register default services using Umbraco Dictionary as the source
        /// </summary>
        /// <param name="composition">Composition to register services for</param>
        public static void RegisterDefaultService(this Composition composition)
        {
            composition.Register<IDictionaryService, DictionaryService>();
            composition.Register<IValidationMessageService, UmbracoDictionaryValidationMessageService>();
        }
    }
}
