// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DrNet.Extensions.String.Parse
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for string class
    /// </summary>
    public static partial class StringParseExtensions
    {
        #region IntPtr

        public static IntPtr ParseIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                4 => (IntPtr)int.Parse(value, numberStyles, provider),
                8 => (IntPtr)long.Parse(value, numberStyles, provider),
                _ => throw new NotImplementedException(),
            };

        public static IntPtr ParseIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                4 => (IntPtr)int.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                8 => (IntPtr)long.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                _ => throw new NotImplementedException(),
            };

        public static bool TryParseIntPtr(this string? value, out IntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                4 => int.TryParse(value, numberStyles, provider, out UnsafeOut.As<IntPtr, int>(out result)),
                8 => long.TryParse(value, numberStyles, provider, out UnsafeOut.As<IntPtr, long>(out result)),
                _ => throw new NotImplementedException(),
            };

        public static bool TryParseIntPtrInvariant(this string? value, out IntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                4 => int.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<IntPtr, int>(out result)),
                8 => long.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<IntPtr, long>(out result)),
                _ => throw new NotImplementedException(),
            };

        public static IntPtr? TryParseIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                4 => int.TryParse(value, numberStyles, provider, out int result) ? (IntPtr)result : default,
                8 => long.TryParse(value, numberStyles, provider, out long result) ? (IntPtr)result : default,
                _ => throw new NotImplementedException(),
            };

        public static IntPtr? TryParseIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => IntPtr.Size switch
            {
                4 => int.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out int result) ? (IntPtr)result : default,
                8 => long.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out long result) ? (IntPtr)result : default,
                _ => throw new NotImplementedException(),
            };

        #endregion

        #region UIntPtr

        public static UIntPtr ParseUIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                4 => (UIntPtr)uint.Parse(value, numberStyles, provider),
                8 => (UIntPtr)ulong.Parse(value, numberStyles, provider),
                _ => throw new NotImplementedException(),
            };

        public static UIntPtr ParseUIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                4 => (UIntPtr)uint.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                8 => (UIntPtr)ulong.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                _ => throw new NotImplementedException(),
            };

        public static bool TryParseUIntPtr(this string? value, out UIntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                4 => uint.TryParse(value, numberStyles, provider, out UnsafeOut.As<UIntPtr, uint>(out result)),
                8 => ulong.TryParse(value, numberStyles, provider, out UnsafeOut.As<UIntPtr, ulong>(out result)),
                _ => throw new NotImplementedException(),
            };

        public static bool TryParseUIntPtrInvariant(this string? value, out UIntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                4 => uint.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<UIntPtr, uint>(out result)),
                8 => ulong.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UnsafeOut.As<UIntPtr, ulong>(out result)),
                _ => throw new NotImplementedException(),
            };

        public static UIntPtr? TryParseUIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                4 => uint.TryParse(value, numberStyles, provider, out uint result) ? (UIntPtr)result : default,
                8 => ulong.TryParse(value, numberStyles, provider, out ulong result) ? (UIntPtr)result : default,
                _ => throw new NotImplementedException(),
            };

        public static UIntPtr? TryParseUIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.Size switch
            {
                4 => uint.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out uint result) ? (UIntPtr)result : default,
                8 => ulong.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out ulong result) ? (UIntPtr)result : default,
                _ => throw new NotImplementedException(),
            };

#endregion
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
