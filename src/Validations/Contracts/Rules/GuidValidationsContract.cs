﻿using System;

namespace PowerUtils.Validations.Contracts
{
    public static class GuidValidationsContract
    { // DONE
        public static IPropertyRule<TSource, Guid> Required<TSource>(this IPropertyRule<TSource, Guid> propertyRule)
        { // DONE
            if(propertyRule.PropertyNull)
            {
                return propertyRule;
            }

            if(propertyRule.PropertyValue == Guid.Empty)
            {
                propertyRule.AddNotification(ErrorCodes.REQUIRED);
            }

            return propertyRule;
        }
    }
}