using System;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class ValidationsContractExtensions
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
