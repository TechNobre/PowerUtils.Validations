using System.Collections.Generic;
using System.Linq;

namespace PowerUtils.Validations.Contracts
{
    public static class CollectionValidationsContract
    {
        public static IPropertyRule<TSource, TValue> Min<TSource, TValue, TProperty>(this IPropertyRule<TSource, TValue> propertyRule, int min)
            where TValue : IEnumerable<TProperty>
        { // DONE
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Count() < min)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(min));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue> Max<TSource, TValue, TProperty>(this IPropertyRule<TSource, TValue> propertyRule, int max)
            where TValue : IEnumerable<TProperty>
        { // DONE
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Count() > max)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(max));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue> Range<TSource, TValue, TProperty>(this IPropertyRule<TSource, TValue> propertyRule, int min, int max)
            where TValue : IEnumerable<TProperty>
        { // DONE
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Count() < min)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(min));
                return propertyRule; // Prevent next comparation
            }

            if(propertyRule.PropertyValue.Count() > max)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(max));
            }

            return propertyRule;
        }
    }
}