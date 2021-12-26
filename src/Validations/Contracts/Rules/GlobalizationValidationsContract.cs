using System;
using PowerUtils.Globalization;

namespace PowerUtils.Validations.Contracts
{
    public static class GlobalizationValidationsContract
    {
        private const double MAX_LATITUDE = 90;
        private const double MIN_LATITUDE = MAX_LATITUDE * -1;

        private const double MAX_LONGITUDE = 180;
        private const double MIN_LONGITUDE = MAX_LONGITUDE * -1;

        public static IPropertyRule<TSource, string> CountryCodeISO2<TSource>(this IPropertyRule<TSource, string> propertyRule)
        { // DONE
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
        { // DONE
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue > MAX_LATITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(Convert.ToInt64(MAX_LATITUDE)));
                return propertyRule; // Prevent next comparation
            }
            if(propertyRule.PropertyValue < MIN_LATITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(Convert.ToInt64(MIN_LATITUDE)));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, double> Longitude<TSource>(this IPropertyRule<TSource, double> propertyRule)
        { // DONE
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue > MAX_LONGITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(Convert.ToInt64(MAX_LONGITUDE)));
                return propertyRule; // Prevent next comparation
            }
            if(propertyRule.PropertyValue < MIN_LONGITUDE)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(Convert.ToInt64(MIN_LONGITUDE)));
            }

            return propertyRule;
        }
    }
}
