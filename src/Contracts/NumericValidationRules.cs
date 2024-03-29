﻿using System;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class NumericValidationRules
    {
        public static IPropertyRule<TSource, TValue> MinZero<TSource, TValue>(this IPropertyRule<TSource, TValue> propertyRule)
           where TValue : IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyValue.CompareTo(0) < 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted("0"));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue?> MinZero<TSource, TValue>(this IPropertyRule<TSource, TValue?> propertyRule)
            where TValue : struct, IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Value.CompareTo(0) < 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted("0"));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue> Min<TSource, TValue>(this IPropertyRule<TSource, TValue> propertyRule, TValue min)
            where TValue : IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyValue.CompareTo(min) < 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(min));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue?> Min<TSource, TValue>(this IPropertyRule<TSource, TValue?> propertyRule, TValue min)
            where TValue : struct, IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Value.CompareTo(min) < 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(min));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue> Max<TSource, TValue>(this IPropertyRule<TSource, TValue> propertyRule, TValue max)
            where TValue : IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyValue.CompareTo(max) > 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(max));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue?> Max<TSource, TValue>(this IPropertyRule<TSource, TValue?> propertyRule, TValue max)
            where TValue : struct, IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Value.CompareTo(max) > 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(max));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue> Range<TSource, TValue>(this IPropertyRule<TSource, TValue> propertyRule, TValue min, TValue max)
            where TValue : IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyValue.CompareTo(min) < 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(min));
                return propertyRule; // Prevent next comparation
            }

            if(propertyRule.PropertyValue.CompareTo(max) > 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(max));
            }

            return propertyRule;
        }

        public static IPropertyRule<TSource, TValue?> Range<TSource, TValue>(this IPropertyRule<TSource, TValue?> propertyRule, TValue min, TValue max)
            where TValue : struct, IComparable<TValue>, IComparable
        {
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue.Value.CompareTo(min) < 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMinFormatted(min));
                return propertyRule; // Prevent next comparation
            }

            if(propertyRule.PropertyValue.Value.CompareTo(max) > 0)
            {
                propertyRule.AddNotification(ErrorCodes.GetMaxFormatted(max));
            }

            return propertyRule;
        }
    }
}
