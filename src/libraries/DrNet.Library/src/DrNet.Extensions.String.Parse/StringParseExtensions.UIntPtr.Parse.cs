// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;

namespace DrNet.Extensions.String.Parse
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for string class
    /// </summary>
    public static partial class StringParseExtensions
    {
        public static UIntPtr ParseUIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Parse(value, numberStyles, provider);

        public static UIntPtr ParseUIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseUIntPtr(this string? value, out UIntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseUIntPtrInvariant(this string? value, out UIntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static UIntPtr? TryParseUIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, provider, out UIntPtr result) ? result : default;

        public static UIntPtr? TryParseUIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UIntPtr result) ? result : default;
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
