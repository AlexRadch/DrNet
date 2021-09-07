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
        #region bool

        public static bool ParseBool(this string value)
        => bool.Parse(value);

        public static bool TryParseBool(this string? value, out bool result)
        => bool.TryParse(value, out result);

        public static bool? TryParseBool(this string? value)
#pragma warning disable IDE0075 // Simplify conditional expression
        => bool.TryParse(value, out bool result) ? result : false;
#pragma warning restore IDE0075 // Simplify conditional expression

        #endregion

        #region byte

        public static byte ParseByte(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.Parse(value, numberStyles, provider);

        public static byte ParseByteInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseByte(this string? value, out byte result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseByteInvariant(this string? value, out byte result, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static byte? TryParseByte(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.TryParse(value, numberStyles, provider, out byte result) ? result : default;

        public static byte? TryParseByteInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => byte.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out byte result) ? result : default;

        #endregion

        #region sbyte

        public static sbyte ParseSByte(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => sbyte.Parse(value, numberStyles, provider);

        public static sbyte ParseSByteInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => sbyte.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseSByte(this string? value, out sbyte result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => sbyte.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseSByteInvariant(this string? value, out sbyte result, NumberStyles numberStyles = NumberStyles.Integer)
        => sbyte.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static sbyte? TryParseSByte(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => sbyte.TryParse(value, numberStyles, provider, out sbyte result) ? result : default;

        public static sbyte? TryParseSByteInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => sbyte.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out sbyte result) ? result : default;

        #endregion

        #region short

        public static short ParseShort(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => short.Parse(value, numberStyles, provider);

        public static short ParseShortInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => short.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseShort(this string? value, out short result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => short.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseShortInvariant(this string? value, out short result, NumberStyles numberStyles = NumberStyles.Integer)
        => short.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static short? TryParseShort(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => short.TryParse(value, numberStyles, provider, out short result) ? result : default;

        public static short? TryParseShortInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => short.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out short result) ? result : default;

        #endregion

        #region ushort

        public static ushort ParseUShort(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => ushort.Parse(value, numberStyles, provider);

        public static ushort ParseUShortInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => ushort.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseUShort(this string? value, out ushort result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => ushort.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseUShortInvariant(this string? value, out ushort result, NumberStyles numberStyles = NumberStyles.Integer)
        => ushort.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static ushort? TryParseUShort(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => ushort.TryParse(value, numberStyles, provider, out ushort result) ? result : default;

        public static ushort? TryParseUShortInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => ushort.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out ushort result) ? result : default;

        #endregion

        #region int

        public static int ParseInt(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => int.Parse(value, numberStyles, provider);

        public static int ParseIntInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => int.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseInt(this string? value, out int result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => int.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseIntInvariant(this string? value, out int result, NumberStyles numberStyles = NumberStyles.Integer)
        => int.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static int? TryParseInt(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => int.TryParse(value, numberStyles, provider, out int result) ? result : default;

        public static int? TryParseIntInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => int.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out int result) ? result : default;

        #endregion

        #region long

        public static long ParseLong(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => long.Parse(value, numberStyles, provider);

        public static long ParseLongInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => long.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseLong(this string? value, out long result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => long.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseLongInvariant(this string? value, out long result, NumberStyles numberStyles = NumberStyles.Integer)
        => long.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static long? TryParseLong(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => long.TryParse(value, numberStyles, provider, out long result) ? result : default;

        public static long? TryParseLongInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => long.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out long result) ? result : default;

        #endregion

        #region ulong

        public static ulong ParseULong(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => ulong.Parse(value, numberStyles, provider);

        public static ulong ParseULongInvariant(this string value, NumberStyles numberStyles = NumberStyles.Integer)
        => ulong.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseULong(this string? value, out ulong result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => ulong.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseULongInvariant(this string? value, out ulong result, NumberStyles numberStyles = NumberStyles.Integer)
        => ulong.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static ulong? TryParseULong(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Integer)
        => ulong.TryParse(value, numberStyles, provider, out ulong result) ? result : default;

        public static ulong? TryParseULongInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Integer)
        => ulong.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out ulong result) ? result : default;

        #endregion

        #region double

        public static double ParseDouble(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.Parse(value, numberStyles, provider);

        public static double ParseDoubleInvariant(this string value, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseDouble(this string? value, out double result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseDoubleInvariant(this string? value, out double result, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static double? TryParseDouble(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, numberStyles, provider, out double result) ? result : default;

        public static double? TryParseDoubleInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => double.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out double result) ? result : default;

        #endregion

        #region float

        public static float ParseFloat(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.Parse(value, numberStyles, provider);

        public static float ParseFloatInvariant(this string value, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseFloat(this string? value, out float result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseFloatInvariant(this string? value, out float result, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static float? TryParseFloat(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, numberStyles, provider, out float result) ? result : default;

        public static float? TryParseFloatInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
        => float.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out float result) ? result : default;

        #endregion

        #region decimal

        public static decimal ParseDecimal(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Number)
        => decimal.Parse(value, numberStyles, provider);

        public static decimal ParseDecimalInvariant(this string value, NumberStyles numberStyles = NumberStyles.Number)
        => decimal.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseDecimal(this string? value, out decimal result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Number)
        => decimal.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseDecimalInvariant(this string? value, out decimal result, NumberStyles numberStyles = NumberStyles.Number)
        => decimal.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static decimal? TryParseDecimal(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Number)
        => decimal.TryParse(value, numberStyles, provider, out decimal result) ? result : default;

        public static decimal? TryParseDecimalInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Number)
        => decimal.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out decimal result) ? result : default;

        #endregion

        #region DateTime

        public static DateTime ParseDateTime(this string value, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        => DateTime.Parse(value, provider, dateTimeStyles);

        public static DateTime ParseDateTimeInvariant(this string value, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        => DateTime.Parse(value, CultureInfo.InvariantCulture, dateTimeStyles);

        public static bool TryParseDateTime(this string? value, out DateTime result, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        => DateTime.TryParse(value, provider, dateTimeStyles, out result);

        public static bool TryParseDateTimeInvariant(this string? value, out DateTime result, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, dateTimeStyles, out result);

        public static DateTime? TryParseDateTime(this string? value, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        => DateTime.TryParse(value, provider, dateTimeStyles, out DateTime result) ? result : default;

        public static DateTime? TryParseDateTimeInvariant(this string? value, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, dateTimeStyles, out DateTime result) ? result : default;

        #region Exact

        public static DateTime ParseExactDateTime(this string value, string format, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.ParseExact(value, format, provider, dateTimeStyles);

        public static DateTime ParseExactDateTime(this string value, string[] formats, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.ParseExact(value, formats, provider, dateTimeStyles);

        public static DateTime ParseExactDateTimeInvariant(this string value, string format, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.ParseExact(value, format, CultureInfo.InvariantCulture, dateTimeStyles);

        public static DateTime ParseExactDateTimeInvariant(this string value, string[] formats, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.ParseExact(value, formats, CultureInfo.InvariantCulture, dateTimeStyles);

        public static bool TryParseExactDateTime(this string? value, string format, out DateTime result, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, provider, dateTimeStyles, out result);

        public static bool TryParseExactDateTime(this string? value, string[] formats, out DateTime result, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, provider, dateTimeStyles, out result);

        public static bool TryParseExactDateTimeInvariant(this string? value, string format, out DateTime result, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, dateTimeStyles, out result);

        public static bool TryParseExactDateTimeInvariant(this string? value, string[] formats, out DateTime result, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, dateTimeStyles, out result);

        public static DateTime? TryParseExactDateTime(this string? value, string format, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, provider, dateTimeStyles, out DateTime result) ? result : default;

        public static DateTime? TryParseExactDateTime(this string? value, string[] formats, IFormatProvider? provider = default, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, provider, dateTimeStyles, out DateTime result) ? result : default;

        public static DateTime? TryParseExactDateTimeInvariant(this string? value, string format, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, dateTimeStyles, out DateTime result) ? result : default;

        public static DateTime? TryParseExactDateTimeInvariant(this string? value, string[] formats, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
            => DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, dateTimeStyles, out DateTime result) ? result : default;

        #endregion

        #endregion

        #region Guid

        public static Guid ParseGuid(this string value)
        => Guid.Parse(value);

        public static bool TryParseGuid(this string? value, out Guid result)
        => Guid.TryParse(value, out result);

        public static Guid? TryParseGuid(this string? value)
        => Guid.TryParse(value, out Guid result) ? result : default;

        public static Guid ParseExactGuid(this string value, string format)
        => Guid.ParseExact(value, format);

        public static bool TryParseExactGuid(this string? value, string? format, out Guid result)
        => Guid.TryParseExact(value, format, out result);

        public static Guid? TryParseExactGuid(this string? value, string? format)
        => Guid.TryParseExact(value, format, out Guid result) ? result : default;

        #endregion
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
