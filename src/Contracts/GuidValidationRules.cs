using System;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class GuidValidationRules
    {
        public static IPropertyRule<TSource, Guid> Required<TSource>(this IPropertyRule<TSource, Guid> propertyRule)
        {
            if(propertyRule.PropertyValue == Guid.Empty)
            {
                propertyRule.AddNotification(ErrorCodes.REQUIRED);
            }

            return propertyRule;
        }
    }
}
