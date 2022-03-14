using System;

namespace PowerUtils.Validations.Contracts
{
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
