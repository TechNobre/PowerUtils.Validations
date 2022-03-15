namespace PowerUtils.Validations.Contracts
{
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
