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
        public static IntPtr ParseIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Parse(value, numberStyles, provider);

        public static IntPtr ParseIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseIntPtr(this string? value, out IntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseIntPtrInvariant(this string? value, out IntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static IntPtr? TryParseIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.TryParse(value, numberStyles, provider, out IntPtr result) ? result : default;

        public static IntPtr? TryParseIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out IntPtr result) ? result : default;
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
