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
        #region IntPtr

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

        #endregion

        #region UIntPtr

        public static UIntPtr ParseUIntPtr(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
#if !NoIntPtrParsing
            => UIntPtr.Parse(value, numberStyles, provider);
#else
            => UIntPtr.Size switch
            {
                4 => (UIntPtr)uint.Parse(value, numberStyles, provider),
                8 => (UIntPtr)ulong.Parse(value, numberStyles, provider),
                _ => throw new NotImplementedException(),
            };
#endif

        public static UIntPtr ParseUIntPtrInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
#if !NoIntPtrParsing
            => UIntPtr.Parse(value, numberStyles, CultureInfo.InvariantCulture);
#else
            => UIntPtr.Size switch
            {
                4 => (UIntPtr)uint.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                8 => (UIntPtr)ulong.Parse(value, numberStyles, CultureInfo.InvariantCulture),
                _ => throw new NotImplementedException(),
            };
#endif

        public static bool TryParseUIntPtr(this string? value, out UIntPtr result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
#if !NoIntPtrParsing
            => UIntPtr.TryParse(value, numberStyles, provider, out result);
#else
            => UIntPtr.Size switch
            {
                4 => uint.TryParse(value, numberStyles, provider, out UnsafeOut.As<UIntPtr, uint>(out result)),
                8 => ulong.TryParse(value, numberStyles, provider, out UnsafeOut.As<UIntPtr, ulong>(out result)),
                _ => throw new NotImplementedException(),
            };
#endif

        public static bool TryParseUIntPtrInvariant(this string? value, out UIntPtr result, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static UIntPtr? TryParseUIntPtr(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, provider, out UIntPtr result) ? result : default;

        public static UIntPtr? TryParseUIntPtrInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
            => UIntPtr.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out UIntPtr result) ? result : default;

#endregion
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
