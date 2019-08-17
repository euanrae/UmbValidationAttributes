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
                    typeof(UmbracoEmailAddressAttribute)
                };

            return items.ToArray();
        }
    }
}
