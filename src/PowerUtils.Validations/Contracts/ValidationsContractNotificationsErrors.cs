namespace PowerUtils.Validations.Contracts
{
    public static class ValidationsContractNotificationsErrors
    {
        public static void AddErrorMIN<TSource>(this IValidationsContract<TSource> context, string property, int min)
            => context.AddNotification(property, ErrorCodes.GetMinFormatted(min));

        public static void AddErrorMAX<TSource>(this IValidationsContract<TSource> context, string property, int max)
            => context.AddNotification(property, ErrorCodes.GetMaxFormatted(max));

        public static void AddErrorINVALID<TSource>(this IValidationsContract<TSource> context, string property)
            => context.AddNotification(property, ErrorCodes.INVALID);

        public static void AddErrorREQUIRED<TSource>(this IValidationsContract<TSource> context, string property)
            => context.AddNotification(property, ErrorCodes.REQUIRED);
    }
}
