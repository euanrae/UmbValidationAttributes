using Moq;
using NUnit.Framework;
using UmbValidationAttributes.Test.Helpers;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Services;
using System.ComponentModel.DataAnnotations;
using System;

namespace UmbValidationAttributes.Test
{
    [TestFixture]
    public class UmbracoRequiredAttributeTests
    {
        [Test]
        public void WhenMessageServiceReturnsNamedValue_ValidationMessageIsSet()
        {
            // arrange
            string validationMessage = "This is the correct message";

            // message service
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), string.Empty)).Returns(validationMessage);

            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            // Act
            var requiredAttribute = new UmbracoRequiredAttribute("asdf");

            // Assert
            Assert.AreEqual(validationMessage, requiredAttribute.ErrorMessage);
            
        }

        [Test]
        public void WhenMessageServiceReturnsBackupValue_BackupValidationMessageIsSet()
        {
            // arrange
            string validationMessage = string.Empty;
            string defaultKeyValidationMessage = "This is the correct message (from backup)";

            // message service
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), string.Empty)).Returns(validationMessage);
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns(defaultKeyValidationMessage);

            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            // Act
            var requiredAttribute = new UmbracoRequiredAttribute("asdf", "adsfasdf");

            // Assert
            Assert.AreEqual(defaultKeyValidationMessage, requiredAttribute.ErrorMessage);
        }

        [Test]
        public void WhenMessageServiceReturnsEmptyValue_DefaultValidatorMessageIsSet()
        {
            // arrange
            string validationMessage = string.Empty;
            string defaultKeyValidationMessage = string.Empty;

            // message service
            var mockService = new Mock<IValidationMessageService>();
            mockService.Setup(ms => ms.GetValue(It.IsAny<string>(), string.Empty)).Returns(validationMessage);
            

            DependencyResolverHelper.SetValidationMessageServiceIntoResolver(mockService);

            // Act
            var requiredAttribute = new UmbracoRequiredAttribute("asdf", "adsfasdf");
            var standardRequiredAttribute = new RequiredAttribute();

            // Assert
            Assert.IsNotEmpty(requiredAttribute.ErrorMessage);
            Assert.AreEqual(standardRequiredAttribute.ErrorMessage, requiredAttribute.ErrorMessage);
        }
    }
}
