﻿using System;
using System.Reflection;
using LightestNight.System.Utilities.Extensions;

namespace LightestNight.System.Utilities
{
    public static class Attributes
    {
        public static TValue GetCustomAttributeValue<TAttributeType, TValue>(MemberInfo type, Func<TAttributeType, TValue> predicate, TValue defaultValue = default)
            where TAttributeType : Attribute
        {
            if (!(Attribute.GetCustomAttribute(type, typeof(TAttributeType)) is TAttributeType attrType))
                return defaultValue;
            
            predicate.ThrowIfNull(nameof(predicate));
            return predicate(attrType);
        }
    }
}