namespace PowerUtils.Validations.Contracts
{
    public static class ObjectValidationsContract
    {
        public static IPropertyRule<TSource, T> Required<TSource, T>(this IPropertyRule<TSource, T> propertyRule)
        { // DONE
            if(propertyRule.PropertyValue == null || propertyRule.PropertyNull)
            {
                propertyRule.AddNotification(ErrorCodes.REQUIRED);
            }

            return propertyRule;
        }
    }
}