// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;

namespace DrNet.Extensions.Span.Parse
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for Span class
    /// </summary>
    public static class SpanParseExtensions
    {
        #region bool

        public static bool ParseBool(this ReadOnlySpan<char> value)
        => bool.Parse(value);

        public static bool TryParseBool(this ReadOnlySpan<char> value, out bool result)
        => bool.TryParse(value, out result);

        public static bool? TryParseBool(this ReadOnlySpan<char> value)
        => bool.TryParse(value, out bool result) ? result : null;

        #endregion

        #region byte

        public static byte ParseByte(this ReadOnlySpan<char> value, NumberStyles numberStyles = NumberStyles.Integer, IFormatProvider? provider = default)
        => byte.Parse(value, numberStyles, provider);

        public static byte ParseByteInvariant(this ReadOnlySpan<char> value, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseByte(this ReadOnlySpan<char> value, out byte result, NumberStyles numberStyles = NumberStyles.Integer, IFormatProvider? provider = default)
        => byte.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseByteInvariant(this ReadOnlySpan<char> value, out byte result, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static byte? TryParseByte(this ReadOnlySpan<char> value, NumberStyles numberStyles = NumberStyles.Integer, IFormatProvider? provider = default)
        => byte.TryParse(value, numberStyles, provider, out byte result) ? result : null;

        public static byte? TryParseByteInvariant(this ReadOnlySpan<char> value, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out byte result) ? result : null;

        #endregion

        #region sbyte

        public static sbyte ParseSByte(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => sbyte.Parse(value, style, provider);

        public static sbyte ParseSByteInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => sbyte.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseSByte(this ReadOnlySpan<char> value, out sbyte result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => sbyte.TryParse(value, style, provider, out result);

        public static bool TryParseSByteInvariant(this ReadOnlySpan<char> value, out sbyte result, NumberStyles style = NumberStyles.Integer)
        => sbyte.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static sbyte? TryParseSByte(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => sbyte.TryParse(value, style, provider, out sbyte result) ? result : null;

        public static sbyte? TryParseSByteInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => sbyte.TryParse(value, style, CultureInfo.InvariantCulture, out sbyte result) ? result : null;

        #endregion

        #region short

        public static short ParseShort(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => short.Parse(value, style, provider);

        public static short ParseShortInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => short.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseShort(this ReadOnlySpan<char> value, out short result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => short.TryParse(value, style, provider, out result);

        public static bool TryParseShortInvariant(this ReadOnlySpan<char> value, out short result, NumberStyles style = NumberStyles.Integer)
        => short.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static short? TryParseShort(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => short.TryParse(value, style, provider, out short result) ? result : null;

        public static short? TryParseShortInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => short.TryParse(value, style, CultureInfo.InvariantCulture, out short result) ? result : null;

        #endregion

        #region ushort

        public static ushort ParseUShort(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ushort.Parse(value, style, provider);

        public static ushort ParseUShortInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => ushort.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseUShort(this ReadOnlySpan<char> value, out ushort result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ushort.TryParse(value, style, provider, out result);

        public static bool TryParseUShortInvariant(this ReadOnlySpan<char> value, out ushort result, NumberStyles style = NumberStyles.Integer)
        => ushort.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static ushort? TryParseUShort(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ushort.TryParse(value, style, provider, out ushort result) ? result : null;

        public static ushort? TryParseUShortInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => ushort.TryParse(value, style, CultureInfo.InvariantCulture, out ushort result) ? result : null;

        #endregion

        #region int

        public static int ParseInt(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => int.Parse(value, style, provider);

        public static int ParseIntInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => int.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseInt(this ReadOnlySpan<char> value, out int result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => int.TryParse(value, style, provider, out result);

        public static bool TryParseIntInvariant(this ReadOnlySpan<char> value, out int result, NumberStyles style = NumberStyles.Integer)
        => int.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static int? TryParseInt(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => int.TryParse(value, style, provider, out int result) ? result : null;

        public static int? TryParseIntInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => int.TryParse(value, style, CultureInfo.InvariantCulture, out int result) ? result : null;

        #endregion

        #region long

        public static long ParseLong(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => long.Parse(value, style, provider);

        public static long ParseLongInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => long.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseLong(this ReadOnlySpan<char> value, out long result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => long.TryParse(value, style, provider, out result);

        public static bool TryParseLongInvariant(this ReadOnlySpan<char> value, out long result, NumberStyles style = NumberStyles.Integer)
        => long.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static long? TryParseLong(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => long.TryParse(value, style, provider, out long result) ? result : null;

        public static long? TryParseLongInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => long.TryParse(value, style, CultureInfo.InvariantCulture, out long result) ? result : null;

        #endregion

        #region ulong

        public static ulong ParseULong(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ulong.Parse(value, style, provider);

        public static ulong ParseULongInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => ulong.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseULong(this ReadOnlySpan<char> value, out ulong result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ulong.TryParse(value, style, provider, out result);

        public static bool TryParseULongInvariant(this ReadOnlySpan<char> value, out ulong result, NumberStyles style = NumberStyles.Integer)
        => ulong.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static ulong? TryParseULong(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
        => ulong.TryParse(value, style, provider, out ulong result) ? result : null;

        public static ulong? TryParseULongInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
        => ulong.TryParse(value, style, CultureInfo.InvariantCulture, out ulong result) ? result : null;

        #endregion

        #region IntPtr

        public static IntPtr ParseIntPtr(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => IntPtrExt.Parse(value, style, provider);

        public static IntPtr ParseIntPtrInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
            => IntPtrExt.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseIntPtr(this ReadOnlySpan<char> value, out IntPtr result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => IntPtrExt.TryParse(value, style, provider, out result);

        public static bool TryParseIntPtrInvariant(this ReadOnlySpan<char> value, out IntPtr result, NumberStyles style = NumberStyles.Integer)
            => IntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static IntPtr? TryParseIntPtr(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => IntPtrExt.TryParse(value, style, provider, out IntPtr result) ? result : null;

        public static IntPtr? TryParseIntPtrInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
            => IntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out IntPtr result) ? result : null;

        #endregion

        #region UIntPtr

        public static UIntPtr ParseUIntPtr(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => UIntPtrExt.Parse(value, style, provider);

        public static UIntPtr ParseUIntPtrInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
            => UIntPtrExt.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseUIntPtr(this ReadOnlySpan<char> value, out UIntPtr result, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => UIntPtrExt.TryParse(value, style, provider, out result);

        public static bool TryParseUIntPtrInvariant(this ReadOnlySpan<char> value, out UIntPtr result, NumberStyles style = NumberStyles.Integer)
            => UIntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static UIntPtr? TryParseUIntPtr(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = default)
            => UIntPtrExt.TryParse(value, style, provider, out UIntPtr result) ? result : null;

        public static UIntPtr? TryParseUIntPtrInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer)
            => UIntPtrExt.TryParse(value, style, CultureInfo.InvariantCulture, out UIntPtr result) ? result : null;

        #endregion

        #region double

        public static double ParseDouble(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => double.Parse(value, style, provider);

        public static double ParseDoubleInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseDouble(this ReadOnlySpan<char> value, out double result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
            IFormatProvider? provider = default)
        => double.TryParse(value, style, provider, out result);

        public static bool TryParseDoubleInvariant(this ReadOnlySpan<char> value, out double result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static double? TryParseDouble(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => double.TryParse(value, style, provider, out double result) ? result : null;

        public static double? TryParseDoubleInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, style, CultureInfo.InvariantCulture, out double result) ? result : null;

        #endregion

        #region float

        public static float ParseFloat(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => float.Parse(value, style, provider);

        public static float ParseFloatInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseFloat(this ReadOnlySpan<char> value, out float result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
            IFormatProvider? provider = default)
        => float.TryParse(value, style, provider, out result);

        public static bool TryParseFloatInvariant(this ReadOnlySpan<char> value, out float result, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static float? TryParseFloat(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = default)
        => float.TryParse(value, style, provider, out float result) ? result : null;

        public static float? TryParseFloatInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, style, CultureInfo.InvariantCulture, out float result) ? result : null;

        #endregion

        #region decimal

        public static decimal ParseDecimal(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = default)
        => decimal.Parse(value, style, provider);

        public static decimal ParseDecimalInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Number)
        => decimal.Parse(value, style, CultureInfo.InvariantCulture);

        public static bool TryParseDecimal(this ReadOnlySpan<char> value, out decimal result, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = default)
        => decimal.TryParse(value, style, provider, out result);

        public static bool TryParseDecimalInvariant(this ReadOnlySpan<char> value, out decimal result, NumberStyles style = NumberStyles.Number)
        => decimal.TryParse(value, style, CultureInfo.InvariantCulture, out result);

        public static decimal? TryParseDecimal(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = default)
        => decimal.TryParse(value, style, provider, out decimal result) ? result : null;

        public static decimal? TryParseDecimalInvariant(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Number)
        => decimal.TryParse(value, style, CultureInfo.InvariantCulture, out decimal result) ? result : null;

        #endregion

        #region DateTime

        public static DateTime ParseDateTime(this ReadOnlySpan<char> value, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.Parse(value, provider, style);

        public static DateTime ParseDateTimeInvariant(this ReadOnlySpan<char> value, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.Parse(value, CultureInfo.InvariantCulture, style);

        public static bool TryParseDateTime(this ReadOnlySpan<char> value, out DateTime result, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, provider, style, out result);

        public static bool TryParseDateTimeInvariant(this ReadOnlySpan<char> value, out DateTime result, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, style, out result);

        public static DateTime? TryParseDateTime(this ReadOnlySpan<char> value, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, provider, style, out DateTime result) ? result : null;

        public static DateTime? TryParseDateTimeInvariant(this ReadOnlySpan<char> value, DateTimeStyles style = DateTimeStyles.None)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, style, out DateTime result) ? result : null;

        #region Exact

        public static DateTime ParseExactDateTime(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, format, provider, style);

        public static DateTime ParseExactDateTime(this ReadOnlySpan<char> value, string[] formats, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, formats, provider, style);

        public static DateTime ParseExactDateTimeInvariant(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, format, CultureInfo.InvariantCulture, style);

        public static DateTime ParseExactDateTimeInvariant(this ReadOnlySpan<char> value, string[] formats, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.ParseExact(value, formats, CultureInfo.InvariantCulture, style);

        public static bool TryParseExactDateTime(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, out DateTime result, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, provider, style, out result);

        public static bool TryParseExactDateTime(this ReadOnlySpan<char> value, string[] formats, out DateTime result, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, provider, style, out result);

        public static bool TryParseExactDateTimeInvariant(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, out DateTime result, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, style, out result);

        public static bool TryParseExactDateTimeInvariant(this ReadOnlySpan<char> value, string[] formats, out DateTime result, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, style, out result);

        public static DateTime? TryParseExactDateTime(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, provider, style, out DateTime result) ? result : null;

        public static DateTime? TryParseExactDateTime(this ReadOnlySpan<char> value, string[] formats, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, provider, style, out DateTime result) ? result : null;

        public static DateTime? TryParseExactDateTimeInvariant(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, style, out DateTime result) ? result : null;

        public static DateTime? TryParseExactDateTimeInvariant(this ReadOnlySpan<char> value, string[] formats, DateTimeStyles style = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, style, out DateTime result) ? result : null;

        #endregion

        #endregion

        #region Guid

        public static Guid ParseGuid(this ReadOnlySpan<char> value)
        => Guid.Parse(value);

        public static bool TryParseGuid(this ReadOnlySpan<char> value, out Guid result)
        => Guid.TryParse(value, out result);

        public static Guid? TryParseGuid(this ReadOnlySpan<char> value)
        => Guid.TryParse(value, out Guid result) ? result : null;

        public static Guid ParseExactGuid(this ReadOnlySpan<char> value, ReadOnlySpan<char> format)
        => Guid.ParseExact(value, format);

        public static bool TryParseExactGuid(this ReadOnlySpan<char> value, ReadOnlySpan<char> format, out Guid result)
        => Guid.TryParseExact(value, format, out result);

        public static Guid? TryParseExactGuid(this ReadOnlySpan<char> value, ReadOnlySpan<char> format)
        => Guid.TryParseExact(value, format, out Guid result) ? result : null;

        #endregion
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
