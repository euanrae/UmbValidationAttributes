//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using Moq;
//using NUnit.Framework;
//using UmbValidationAttributes.Attributes;
//using UmbValidationAttributes.Helpers;
//using UmbValidationAttributes.Services;
//using UmbValidationAttributes.Test.Helpers;

//namespace UmbValidationAttributes.Test
//{
//    [TestFixture]
//    public class CompositionHelperTests
//    {
//        [Test]
//        public void WhenHelperReturnsMessage_AttributeMessageIsSet()
//        {
//            // arrange
//            var composition = new Umbraco.Core.Composing.Composition();

//            // act
//            var validator = new RequiredAttribute();
//            validator.Initialise("asdf", "asefasdf"); // can be any validation attribute

//            // assert
//            Assert.AreEqual(serviceMessage, validator.ErrorMessage);
//        }
//    }
//}
