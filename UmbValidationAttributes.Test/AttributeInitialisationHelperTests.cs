using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Moq;
using NUnit.Framework;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Helpers;
using UmbValidationAttributes.Services;
using UmbValidationAttributes.Test.Helpers;

namespace UmbValidationAttributes.Test
{
    [TestFixture]
    public class AttributeInitialisationHelperTests
    {
        [Test]
        public void WhenHelperReturnsMessage_AttributeMessageIsSet()
        {
            // arrange
            var serviceMessage = "I'm the service message";
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns(serviceMessage);
            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            // act
            var validator = new RequiredAttribute();
            validator.Initialise("asdf", "asefasdf"); // can be any validation attribute

            // assert
            Assert.AreEqual(serviceMessage, validator.ErrorMessage);
        }

        [Test]
        [TestCase("    ", "I'm fhte default message")]
        [TestCase(null, "This is the default test for this thingy")]
        public void WhenHelperReturnsNoMessage_FallbackMessageIsSet(string nullOrEmptyString, string fallBackMessage)
        {
            // arrange
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns(nullOrEmptyString);
            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            // act
            var validator = new RequiredAttribute();
            validator.Initialise("asdf", "asefasdf", fallBackMessage); // can be any validation attribute

            // assert
            Assert.AreEqual(fallBackMessage, validator.ErrorMessage);
        }

        [Test]
        [TestCaseSource(typeof(AttributeGeneratorHelper), "GenerateDefaultAttributeTypes")]
        public void WhenNoMessage_DefaultAttributeMessageIsSet(Type type)
        {
            // arrange
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns(string.Empty);
            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            var testInstance = Activator.CreateInstance(type) as ValidationAttribute;
            var controlInstance = Activator.CreateInstance(type) as ValidationAttribute;

            // act
            testInstance.Initialise("asdf", "asefasdf", string.Empty); // can be any validation attribute

            // assert
            Assert.AreEqual(controlInstance.ErrorMessage, testInstance.ErrorMessage);
        }

        [Test]
        [TestCaseSource(typeof(AttributeGeneratorHelper), "GenerateUmbracoAttributeTypes")]
        public void WhenNoMessage_DefaultAttributeMessageIsSet_UmbracoValidators(Type type)
        {
            // arrange
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns(string.Empty);
            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            var fakeParams = new []{ "Test" };

            var testInstance = Activator.CreateInstance(type, fakeParams) as ValidationAttribute;
            var controlInstance = Activator.CreateInstance(type, fakeParams) as ValidationAttribute;

            // act
            testInstance.Initialise("asdf", "asefasdf", string.Empty); // can be any validation attribute

            // assert
            Assert.AreEqual(controlInstance.ErrorMessage, testInstance.ErrorMessage);
        }
    }
}
