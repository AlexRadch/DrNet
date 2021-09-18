// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DrNet.Extensions.String.Parse
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for string class
    /// </summary>
    public static partial class StringParseExtensions
    {
        #region bool

        public static bool ParseBool(this string value)
        => bool.Parse(value);

        public static bool TryParseBool([NotNullWhen(true)] this string? value, out bool result)
        => bool.TryParse(value, out result);

        public static bool? TryParseBool(this string? value)
        => bool.TryParse(value, out bool result) ? result : null;

        #endregion

        #region byte

        public static byte ParseByte(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => byte.Parse(value, style, provider);

        public static byte ParseByteInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => byte.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseByte(this string? value, out byte result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => byte.TryParse(value, style, provider, out result);

        public static bool TryParseByteInvariant(this string? value, out byte result, NumberStyles style = NumberStyles.Integer)
        => byte.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static byte? TryParseByte(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => byte.TryParse(value, style, provider, out byte result) ? result : null;

        public static byte? TryParseByteInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => byte.TryParse(value, style, CultureInfo.InvariantCulture, out byte result) ? result : null;

        #endregion

        #region sbyte

        public static sbyte ParseSByte(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => sbyte.Parse(value, style, provider);

        public static sbyte ParseSByteInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => sbyte.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseSByte(this string? value, out sbyte result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => sbyte.TryParse(value, style, provider, out result);

        public static bool TryParseSByteInvariant(this string? value, out sbyte result, NumberStyles style = NumberStyles.Integer)
        => sbyte.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static sbyte? TryParseSByte(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => sbyte.TryParse(value, style, provider, out sbyte result) ? result : null;

        public static sbyte? TryParseSByteInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => sbyte.TryParse(value, style, CultureInfo.InvariantCulture, out sbyte result) ? result : null;

        #endregion

        #region short

        public static short ParseShort(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => short.Parse(value, style, provider);

        public static short ParseShortInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => short.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseShort(this string? value, out short result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => short.TryParse(value, style, provider, out result);

        public static bool TryParseShortInvariant(this string? value, out short result, NumberStyles style = NumberStyles.Integer)
        => short.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static short? TryParseShort(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => short.TryParse(value, style, provider, out short result) ? result : null;

        public static short? TryParseShortInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => short.TryParse(value, style, CultureInfo.InvariantCulture, out short result) ? result : null;

        #endregion

        #region ushort

        public static ushort ParseUShort(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ushort.Parse(value, style, provider);

        public static ushort ParseUShortInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => ushort.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseUShort(this string? value, out ushort result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ushort.TryParse(value, style, provider, out result);

        public static bool TryParseUShortInvariant(this string? value, out ushort result, NumberStyles style = NumberStyles.Integer)
        => ushort.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static ushort? TryParseUShort(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ushort.TryParse(value, style, provider, out ushort result) ? result : null;

        public static ushort? TryParseUShortInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => ushort.TryParse(value, style, CultureInfo.InvariantCulture, out ushort result) ? result : null;

        #endregion

        #region int

        public static int ParseInt(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => int.Parse(value, style, provider);

        public static int ParseIntInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => int.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseInt(this string? value, out int result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => int.TryParse(value, style, provider, out result);

        public static bool TryParseIntInvariant(this string? value, out int result, NumberStyles style = NumberStyles.Integer)
        => int.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static int? TryParseInt(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => int.TryParse(value, style, provider, out int result) ? result : null;

        public static int? TryParseIntInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => int.TryParse(value, style, CultureInfo.InvariantCulture, out int result) ? result : null;

        #endregion

        #region long

        public static long ParseLong(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => long.Parse(value, style, provider);

        public static long ParseLongInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => long.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseLong(this string? value, out long result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => long.TryParse(value, style, provider, out result);

        public static bool TryParseLongInvariant(this string? value, out long result, NumberStyles style = NumberStyles.Integer)
        => long.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static long? TryParseLong(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => long.TryParse(value, style, provider, out long result) ? result : null;

        public static long? TryParseLongInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => long.TryParse(value, style, CultureInfo.InvariantCulture, out long result) ? result : null;

        #endregion

        #region ulong

        public static ulong ParseULong(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ulong.Parse(value, style, provider);

        public static ulong ParseULongInvariant(this string value, NumberStyles style = NumberStyles.Integer)
        => ulong.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseULong(this string? value, out ulong result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ulong.TryParse(value, style, provider, out result);

        public static bool TryParseULongInvariant(this string? value, out ulong result, NumberStyles style = NumberStyles.Integer)
        => ulong.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static ulong? TryParseULong(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ulong.TryParse(value, style, provider, out ulong result) ? result : null;

        public static ulong? TryParseULongInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
        => ulong.TryParse(value, style, CultureInfo.InvariantCulture, out ulong result) ? result : null;

        #endregion

        #region IntPtr

        public static IntPtr ParseIntPtr(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => IntPtrExt.Parse(value, style, provider);

        public static IntPtr ParseIntPtrInvariant(this string value, NumberStyles style = NumberStyles.Integer)
            => IntPtrExt.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseIntPtr(this string? value, out IntPtr result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => IntPtrExt.TryParse(value, style, provider, out result);

        public static bool TryParseIntPtrInvariant(this string? value, out IntPtr result, NumberStyles style = NumberStyles.Integer)
            => IntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static IntPtr? TryParseIntPtr(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => IntPtrExt.TryParse(value, style, provider, out IntPtr result) ? result : null;

        public static IntPtr? TryParseIntPtrInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
            => IntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out IntPtr result) ? result : null;

        #endregion

        #region UIntPtr

        public static UIntPtr ParseUIntPtr(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => UIntPtrExt.Parse(value, style, provider);

        public static UIntPtr ParseUIntPtrInvariant(this string value, NumberStyles style = NumberStyles.Integer)
            => UIntPtrExt.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseUIntPtr(this string? value, out UIntPtr result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => UIntPtrExt.TryParse(value, style, provider, out result);

        public static bool TryParseUIntPtrInvariant(this string? value, out UIntPtr result, NumberStyles style = NumberStyles.Integer)
            => UIntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static UIntPtr? TryParseUIntPtr(this string? value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => UIntPtrExt.TryParse(value, style, provider, out UIntPtr result) ? result : null;

        public static UIntPtr? TryParseUIntPtrInvariant(this string? value, NumberStyles style = NumberStyles.Integer)
            => UIntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out UIntPtr result) ? result : null;

        #endregion

        #region double

        public static double ParseDouble(this string value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => double.Parse(value, style, provider);

        public static double ParseDoubleInvariant(this string value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseDouble(this string? value, out double result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
            IFormatProvider? provider = default)
        => double.TryParse(value, style, provider, out result);

        public static bool TryParseDoubleInvariant(this string? value, out double result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static double? TryParseDouble(this string? value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => double.TryParse(value, style, provider, out double result) ? result : null;

        public static double? TryParseDoubleInvariant(this string? value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, style, CultureInfo.InvariantCulture, out double result) ? result : null;

        #endregion

        #region float

        public static float ParseFloat(this string value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => float.Parse(value, style, provider);

        public static float ParseFloatInvariant(this string value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseFloat(this string? value, out float result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
            IFormatProvider? provider = default)
        => float.TryParse(value, style, provider, out result);

        public static bool TryParseFloatInvariant(this string? value, out float result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static float? TryParseFloat(this string? value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => float.TryParse(value, style, provider, out float result) ? result : null;

        public static float? TryParseFloatInvariant(this string? value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, style, CultureInfo.InvariantCulture, out float result) ? result : null;

        #endregion

        #region decimal

        public static decimal ParseDecimal(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = default)
        => decimal.Parse(value, style, provider);

        public static decimal ParseDecimalInvariant(this string value, NumberStyles style = NumberStyles.Number)
        => decimal.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseDecimal(this string? value, out decimal result, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = default)
        => decimal.TryParse(value, style, provider, out result);

        public static bool TryParseDecimalInvariant(this string? value, out decimal result, NumberStyles style = NumberStyles.Number)
        => decimal.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static decimal? TryParseDecimal(this string? value, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = default)
        => decimal.TryParse(value, style, provider, out decimal result) ? result : null;

        public static decimal? TryParseDecimalInvariant(this string? value, NumberStyles style = NumberStyles.Number)
        => decimal.TryParse(value, style, CultureInfo.InvariantCulture, out decimal result) ? result : null;

        #endregion

        #region DateTime

        public static DateTime ParseDateTime(this string value, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.Parse(value, provider, style);

        public static DateTime ParseDateTimeInvariant(this string value, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.Parse(value, CultureInfo.InvariantCulture, style);

        public static bool TryParseDateTime(this string? value, out DateTime result, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, provider, style, out result);

        public static bool TryParseDateTimeInvariant(this string? value, out DateTime result, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, style, out result);

        public static DateTime? TryParseDateTime(this string? value, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, provider, style, out DateTime result) ? result : null;

        public static DateTime? TryParseDateTimeInvariant(this string? value, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, style, out DateTime result) ? result : null;

        #region Exact

        public static DateTime ParseExactDateTime(this string value, string format, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, format, provider, style);

        public static DateTime ParseExactDateTime(this string value, string[] formats, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, formats, provider, style);

        public static DateTime ParseExactDateTimeInvariant(this string value, string format, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, format, CultureInfo.InvariantCulture, style);

        public static DateTime ParseExactDateTimeInvariant(this string value, string[] formats, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, formats, CultureInfo.InvariantCulture, style);

        public static bool TryParseExactDateTime(this string? value, string format, out DateTime result, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, provider, style, out result);

        public static bool TryParseExactDateTime(this string? value, string[] formats, out DateTime result, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, provider, style, out result);

        public static bool TryParseExactDateTimeInvariant(this string? value, string format, out DateTime result, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, style, out result);

        public static bool TryParseExactDateTimeInvariant(this string? value, string[] formats, out DateTime result, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, style, out result);

        public static DateTime? TryParseExactDateTime(this string? value, string format, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, provider, style, out DateTime result) ? result : null;

        public static DateTime? TryParseExactDateTime(this string? value, string[] formats, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, provider, style, out DateTime result) ? result : null;

        public static DateTime? TryParseExactDateTimeInvariant(this string? value, string format, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, style, out DateTime result) ? result : null;

        public static DateTime? TryParseExactDateTimeInvariant(this string? value, string[] formats, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, style, out DateTime result) ? result : null;

        #endregion

        #endregion

        #region Guid

        public static Guid ParseGuid(this string value)
        => Guid.Parse(value);

        public static bool TryParseGuid([NotNullWhen(true)] this string? value, out Guid result)
        => Guid.TryParse(value, out result);

        public static Guid? TryParseGuid(this string? value)
        => Guid.TryParse(value, out Guid result) ? result : null;

        public static Guid ParseExactGuid(this string value, string format)
        => Guid.ParseExact(value, format);

        public static bool TryParseExactGuid(this string? value, string? format, out Guid result)
        => Guid.TryParseExact(value, format, out result);

        public static Guid? TryParseExactGuid(this string? value, string? format)
        => Guid.TryParseExact(value, format, out Guid result) ? result : null;

        #endregion
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
