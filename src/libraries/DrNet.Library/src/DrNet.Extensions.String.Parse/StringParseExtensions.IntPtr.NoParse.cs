// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;
using DrNet.Runtime.CompilerServices;

namespace DrNet.Extensions.String.Parse
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for string class
    /// </summary>
    public static partial class StringParseExtensions
    {
        public static IntPtr ParseIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                8 => (IntPtr)long.Parse(value, numberStyles, provider),
                _ => (IntPtr)int.Parse(value, numberStyles, provider),
            };

        public static IntPtr ParseIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                8 => (IntPtr)long.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                _ => (IntPtr)int.Parse(value, numberStyles, CultureInfo.InvariantCulture),
            };

        public static bool TryParseIntPtr(this string? value, out IntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                8 => long.TryParse(value, numberStyles, provider, out UnsafeOut.As<IntPtr, long>(out result)),
                _ => int.TryParse(value, numberStyles, provider, out UnsafeOut.As<IntPtr, int>(out result)),
            };

        public static bool TryParseIntPtrInvariant(this string? value, out IntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                8 => long.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<IntPtr, long>(out result)),
                _ => int.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<IntPtr, int>(out result)),
            };

        public static IntPtr? TryParseIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                8 => long.TryParse(value, numberStyles, provider, out long result) ? (IntPtr)result : default,
                _ => int.TryParse(value, numberStyles, provider, out int result) ? (IntPtr)result : default,
            };

        public static IntPtr? TryParseIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                8 => long.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out long result) ? (IntPtr)result : default,
                _ => int.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out int result) ? (IntPtr)result : default,
            };
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
