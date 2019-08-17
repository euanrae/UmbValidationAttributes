namespace UmbValidationAttributes.Services
{
    public interface IValidationMessageService
    {
        string GetValue(string key, string defaultValue = "");
        string GetValue(string key, string defaultItemKey, string defaultValue = "");
    }
}
