using System;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class PaginationValidationRules
    {
        public static IPropertyRule<TSource, string> OrderingDirectionIgnoreCase<TSource>(this IPropertyRule<TSource, string> propertyRule)
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(string.IsNullOrEmpty(propertyRule.PropertyValue))
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.ToLower() != "asc" && propertyRule.PropertyValue.ToLower() != "desc")
            {
                propertyRule.AddNotification(ErrorCodes.INVALID);
            }

            return propertyRule;
        }
    }
}
