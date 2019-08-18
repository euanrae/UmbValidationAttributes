namespace UmbValidationAttributes.Services
{
    /// <summary>
    /// Base validation service that has fallback logic and the abstract method that 
    /// must be implemented for interiting classes
    /// </summary>
    public abstract class BaseValidationMessageService
    {
        /// <summary>
        /// Abstract member that must be implemented to get member from the source
        /// This should only access a repository, and have no logic in it
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract string GetValueFromSource(string key);

        /// <summary>
        /// Returns an item from the source given a key. If main item is empty, looks 
        /// for a fallback.  If fallback is empty, it returns empty.
        /// This implementation is purposefully pessimistic to allow default items
        /// to be implemented elsewhere, ie validators
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultItemKey"></param>
        /// <returns></returns>
        public virtual string GetValue(string key, string defaultItemKey = "")
        {
            string value = this.GetValueFromSource(key);
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                return value;
            }

            if (string.IsNullOrWhiteSpace(defaultItemKey))
            {
                return string.Empty;
            }

            return this.GetValueFromSource(defaultItemKey);
        }
    }
}
