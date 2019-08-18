using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbValidationAttributes.Attributes;

namespace UmbValidationAttributes.Test.Helpers
{
    public static class AttributeGeneratorHelper
    {
        public static Type[] GenerateDefaultAttributeTypes()
        {
            var items =
                new List<Type>
                {
                    typeof(RequiredAttribute),
                    typeof(EmailAddressAttribute)
                };

            return items.ToArray();
        }

        public static Type[] GenerateUmbracoAttributeTypes()
        {
            var items =
                new List<Type>
                {
                    typeof(UmbracoRequiredAttribute),
                    typeof(UmbracoEmailAddressAttribute),
                    typeof(UmbracoRegexAttribute)
                };

            return items.ToArray();
        }

        public static ValidationAttribute IntialiseAttribute(Type type)
        {
            object[] ctorParams;
                
            if (type == typeof(UmbracoRegexAttribute))
            {
                ctorParams = new[] { "test", "asdfasdfasdf" };
            }
            else
            {
                ctorParams = new[] { "test" };
            }

            return Activator.CreateInstance(type, ctorParams) as ValidationAttribute;

        }
    }
}
