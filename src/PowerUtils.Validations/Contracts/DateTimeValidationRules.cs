using System;
using System.Globalization;

namespace PowerUtils.Validations.Contracts
{
    public static class DateTimeValidationRules
    {
        public static IPropertyRule<TSource, string> Date<TSource>(this IPropertyRule<TSource, string> propertyRule, DateTime minDate, DateTime maxDate)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            try
            {
                var value = DateTime.ParseExact(propertyRule.PropertyValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                if(value.Date < minDate.Date)
                {
                    propertyRule.AddNotification(ErrorCodes.GetMinFormatted(minDate));
                    return propertyRule; // Prevent next comparation
                }

                if(value.Date > maxDate.Date)
                {
                    propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(maxDate));
                }

            }
            catch
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, DateTime> Date<TSource>(this IPropertyRule<TSource, DateTime> propertyRule, DateTime minDate, DateTime maxDate)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Date < minDate.Date)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(minDate));
                return propertyRule; // Prevent next comparation
            }


            if(propertyRule.PropertyValue.Date > maxDate.Date)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(maxDate));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, DateTime?> Date<TSource>(this IPropertyRule<TSource, DateTime?> propertyRule, DateTime minDate, DateTime maxDate)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.HasValue)
            {
                if(propertyRule.PropertyValue.Value.Date < minDate.Date)
                {
                    propertyRule.AddNotification(ErrorCodes.GetMinFormatted(minDate));
                    return propertyRule; // Prevent next comparation
                }


                if(propertyRule.PropertyValue.Value.Date > maxDate.Date)
                {
                    propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(maxDate));
                }
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> MinDateTimeUtcNow<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(propertyRule.PropertyValue, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            catch
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
                return propertyRule;
            }

            if(dateTime < DateTime.UtcNow)
            {
                propertyRule.AddNotification(ErrorCodes.MIN_DATETIME_UTCNOW);
                return propertyRule; // Prevent next comparation
            }

            return propertyRule;
        }


        public static IPropertyRule<TSource, string> MaxDateTimeUtcNow<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(propertyRule.PropertyValue, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            catch
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
                return propertyRule;
            }

            if(dateTime > DateTime.UtcNow)
            {
                propertyRule.AddNotification(ErrorCodes.MAX_DATETIME_UTCNOW);
                return propertyRule; // Prevent next comparation
            }

            return propertyRule;
        }
    }
}
