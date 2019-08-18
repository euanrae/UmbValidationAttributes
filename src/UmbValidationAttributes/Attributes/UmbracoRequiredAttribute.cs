﻿using System;
using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Helpers;

namespace UmbValidationAttributes.Attributes
{
    /// <summary>
    /// RequiredAttribute that gets error message from Umbraco
    /// </summary>
    public class UmbracoRequiredAttribute : RequiredAttribute
    {
        /// <summary>
        /// Create with a message key - will fallback to RequiredAttribute default message if none found
        /// </summary>
        /// <param name="messageKey">Key for the message when validation fails</param>
        public UmbracoRequiredAttribute(string messageKey) : this(messageKey, "", "")
        {

        }

        /// <summary>
        /// Create with a message key - will fallback to RequiredAttribute default message if none found
        /// </summary>
        /// <param name="messageKey">Key for the message when validation fails</param>
        /// <param name="fallbackMessageKey">Key for a default message if 'messageKey' value returns null</param>
        /// <param name="defaultMessage">Hard coded default message if none is found from messageKey + fallbackMessageKey</param>
        public UmbracoRequiredAttribute(string messageKey, string fallbackMessageKey = "", string defaultMessage = "")
        {
            if (string.IsNullOrWhiteSpace(messageKey))
            {
                throw new InvalidOperationException("Message key cannot be an empty string");
            }

            this.Initialise(messageKey, fallbackMessageKey, defaultMessage);
        }
    }
}
