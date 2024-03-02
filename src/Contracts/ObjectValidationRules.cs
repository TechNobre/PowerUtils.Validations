using System;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class ObjectValidationRules
    {
        public static IPropertyRule<TSource, T> Required<TSource, T>(this IPropertyRule<TSource, T> propertyRule)
        {
            if(propertyRule.PropertyValue == null || propertyRule.PropertyNull)
            {
                propertyRule.AddNotification(ErrorCodes.REQUIRED);
            }

            return propertyRule;
        }
    }
}
