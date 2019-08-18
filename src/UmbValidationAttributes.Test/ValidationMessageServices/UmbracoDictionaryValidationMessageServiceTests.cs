using Moq;
using NUnit.Framework;
using UmbValidationAttributes.Services;
using UmbValidationAttributes.ServiceWrappers;

namespace UmbValidationAttributes.Test.ValidationMessageServices
{
    [TestFixture]
    public class UmbracoDictionaryValidationMessageServiceTests
    {
        [Test]
        [TestCase("asdfasdf", "asdfasdf asdfasdf asdf asdf")]
        public void WhenServiceReturnsValue_ValidationServiceReturnsValue(string messageKey, string messageValue)
        {
            // arrange
            var dictionaryService = new Mock<IDictionaryService>();
            dictionaryService.Setup(x => x.GetDictionaryValue(messageKey)).Returns(messageValue);

            var serviceToTest = new UmbracoDictionaryValidationMessageService(dictionaryService.Object);

            // act
            var result = serviceToTest.GetValue(messageKey);

            // assert
            Assert.AreEqual(messageValue, result);

        }

        [Test]
        [TestCase("asdfa sfasdfasdfasdfasdf sd", "asdfasdf", "asdfasdf asdfasdf asdf asdf")]
        public void WhenServiceReturnsFallbackValue_ValidationServiceReturnsFallbackValue(string messageKey, string fallbackMessageKey, string fallbackMessageValue)
        {
            // arrange
            var dictionaryService = new Mock<IDictionaryService>();
            dictionaryService.Setup(x => x.GetDictionaryValue(messageKey)).Returns(string.Empty);
            dictionaryService.Setup(x => x.GetDictionaryValue(fallbackMessageKey)).Returns(fallbackMessageValue);

            var serviceToTest = new UmbracoDictionaryValidationMessageService(dictionaryService.Object);

            // act
            var result = serviceToTest.GetValue(messageKey, fallbackMessageKey);

            // assert
            Assert.AreEqual(fallbackMessageValue, result);

        }
    }
}
