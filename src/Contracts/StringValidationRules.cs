using System;
using System.Linq;
using PowerUtils.Text;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class StringValidationRules
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

            if(!options.Any(a => a.Equals(propertyRule.PropertyValue, StringComparison.InvariantCultureIgnoreCase)))
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

            if(!propertyRule.PropertyValue.IsEmail())
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
