using System;
using PowerUtils.Globalization;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class GlobalizationValidationRules
    {
        private const double MAX_LATITUDE = 90;
        private const double MIN_LATITUDE = MAX_LATITUDE * -1;

        private const double MAX_LONGITUDE = 180;
        private const double MIN_LONGITUDE = MAX_LONGITUDE * -1;

        public static IPropertyRule<TSource, string> CountryCodeISO2<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Length == 2)
            {
                if(!UtilsGlobalization.IfExistISO2(propertyRule.PropertyValue.ToUpper()))
                {
                    propertyRule.AddNotification(ErrorCodes.INVALID);
                }
            }
            else
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, double> Latitude<TSource>(this IPropertyRule<TSource, double> propertyRule)
        {
            if(propertyRule.PropertyValue > MAX_LATITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(MAX_LATITUDE));
                return propertyRule; // Prevent next comparation
            }
            if(propertyRule.PropertyValue < MIN_LATITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(MIN_LATITUDE));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, double?> Latitude<TSource>(this IPropertyRule<TSource, double?> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue > MAX_LATITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(MAX_LATITUDE));
                return propertyRule; // Prevent next comparation
            }
            if(propertyRule.PropertyValue < MIN_LATITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(MIN_LATITUDE));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, double> Longitude<TSource>(this IPropertyRule<TSource, double> propertyRule)
        {
            if(propertyRule.PropertyValue > MAX_LONGITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(MAX_LONGITUDE));
                return propertyRule; // Prevent next comparation
            }
            if(propertyRule.PropertyValue < MIN_LONGITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(MIN_LONGITUDE));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, double?> Longitude<TSource>(this IPropertyRule<TSource, double?> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue > MAX_LONGITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(MAX_LONGITUDE));
                return propertyRule; // Prevent next comparation
            }
            if(propertyRule.PropertyValue < MIN_LONGITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(MIN_LONGITUDE));
            }

            return propertyRule;
        }
    }
}
