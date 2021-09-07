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
        public static UIntPtr ParseUIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                8 => (UIntPtr)ulong.Parse(value, numberStyles, provider),
                _ => (UIntPtr)uint.Parse(value, numberStyles, provider),
            };

        public static UIntPtr ParseUIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                8 => (UIntPtr)ulong.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                _ => (UIntPtr)uint.Parse(value, numberStyles, CultureInfo.InvariantCulture),
            };

        public static bool TryParseUIntPtr(this string? value, out UIntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                8 => ulong.TryParse(value, numberStyles, provider, out UnsafeOut.As<UIntPtr, ulong>(out result)),
                _ => uint.TryParse(value, numberStyles, provider, out UnsafeOut.As<UIntPtr, uint>(out result)),
            };

        public static bool TryParseUIntPtrInvariant(this string? value, out UIntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                8 => ulong.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<UIntPtr, ulong>(out result)),
                _ => uint.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<UIntPtr, uint>(out result)),
            };

        public static UIntPtr? TryParseUIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                8 => ulong.TryParse(value, numberStyles, provider, out ulong result) ? (UIntPtr)result : default,
                _ => uint.TryParse(value, numberStyles, provider, out uint result) ? (UIntPtr)result : default,
            };

        public static UIntPtr? TryParseUIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                8 => ulong.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out ulong result) ? (UIntPtr)result : default,
                _ => uint.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out uint result) ? (UIntPtr)result : default,
            };
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
