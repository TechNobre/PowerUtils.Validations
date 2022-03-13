using System.Linq;

namespace PowerUtils.Validations.Contracts
{
    public static class GeneralValidationsContract
    {
        public static IPropertyRule<TSource, string> Gender<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            switch(propertyRule.PropertyValue.ToUpper())
            {
                case "MALE":
                    // It is valid
                    break;

                case "FEMALE":
                    // It is valid
                    break;

                default:
                    propertyRule.AddNotification(ErrorCodes.INVALID);
                    break;
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, string> GenderWithOther<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            switch(propertyRule.PropertyValue.ToUpper())
            {
                case "OTHER":
                    // It is valid
                    break;

                default:
                    propertyRule.Gender();
                    break;
            }

            return propertyRule;
        }


        public static IPropertyRule<TSource, TValue> ForbiddenValue<TSource, TValue>(this IPropertyRule<TSource, TValue> propertyRule, params TValue[] forbiddenValues)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule; // Prevent next comparation
            }

            if(forbiddenValues == null)
            {
                return propertyRule; // Prevent next comparation
            }

            if(forbiddenValues.Any(a => a.Equals(propertyRule.PropertyValue)))
            {
                propertyRule.AddNotification(ErrorCodes.FORBIDDEN);
            }

            return propertyRule;
        }
    }
}
