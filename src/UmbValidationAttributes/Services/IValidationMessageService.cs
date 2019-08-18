namespace UmbValidationAttributes.Services
{
    /// <summary>
    /// Interface for defining how service to get validation messages
    /// </summary>
    public interface IValidationMessageService
    {
        /// <summary>
        /// Method to return a validation message based on a key, and a fallback key
        /// </summary>
        /// <param name="key">Key of item to get from store</param>
        /// <param name="defaultItemKey">Key of item to get if 'key' value is null or empty</param>
        /// <returns></returns>
        string GetValue(string key, string defaultItemKey = "");
    }
}
