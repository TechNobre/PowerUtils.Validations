using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PowerUtils.Validations.Contracts
{
    public static class StringValidationsContract
    {
        public static IPropertyRule<TSource, string> Required<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(string.IsNullOrEmpty(propertyRule.PropertyValue) || propertyRule.PropertyNull)
            {
                propertyRule.AddNotification(ErrorCodes.REQUIRED);
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> Options<TSource>(this IPropertyRule<TSource, string> propertyRule, params string[] options)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if(options == null)
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
                return propertyRule;
            }

            if(!options.Any(a => a == propertyRule.PropertyValue))
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> OptionsIgnoreCase<TSource>(this IPropertyRule<TSource, string> propertyRule, params string[] options)
        {
            if (propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if (string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if (options == null)
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
                return propertyRule;
            }

            if (!options.Any(a => a.Equals(propertyRule.PropertyValue, StringComparison.InvariantCultureIgnoreCase)))
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> MaxLength<TSource>(this IPropertyRule<TSource, string> propertyRule, int maxLength)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Length > maxLength)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(maxLength));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> MinLength<TSource>(this IPropertyRule<TSource, string> propertyRule, int minLength)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Length < minLength)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(minLength));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> Length<TSource>(this IPropertyRule<TSource, string> propertyRule, int minLength, int maxLength)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Length < minLength)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(minLength));
                return propertyRule; // Prevent next comparation
            }

            if(propertyRule.PropertyValue.Length > maxLength)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(maxLength));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> EmailAddress<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            // https://jqueryvalidation.org/email-method/
            // the same validation as jquery validation
            var matchRegex = Regex.Match(propertyRule.PropertyValue, @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            if(!matchRegex.Success)
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
                return propertyRule; // Prevent next comparation
            }

            // Secund validation
            var validator = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
            var isValid = validator.IsValid(propertyRule.PropertyValue);
            if(!isValid)
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> ForbiddenValue<TSource>(this IPropertyRule<TSource, string> propertyRule, params string[] forbiddenValues)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule; // Prevent next comparation
            }

            if(forbiddenValues == null)
            {
                return propertyRule; // Prevent next comparation
            }

            if(forbiddenValues.Any(a => a.Equals(propertyRule.PropertyValue, StringComparison.InvariantCultureIgnoreCase)))
            {
                propertyRule.AddNotification(ErrorCodes.FORBIDDEN);
            }

            return propertyRule;
        }
    }
}
