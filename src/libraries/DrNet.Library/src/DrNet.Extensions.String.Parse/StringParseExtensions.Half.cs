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
        public static Half ParseHalf(this string value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
            => Half.Parse(value, numberStyles, provider);

        public static Half ParseHalfInvariant(this string value, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
            => Half.Parse(value, numberStyles, CultureInfo.InvariantCulture);

        public static bool TryParseHalf(this string? value, out Half result, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
            => Half.TryParse(value, numberStyles, provider, out result);

        public static bool TryParseHalfInvariant(this string? value, out Half result, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
            => Half.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out result);

        public static Half? TryParseHalf(this string? value, IFormatProvider? provider = default, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
            => Half.TryParse(value, numberStyles, provider, out Half result) ? result : default;

        public static Half? TryParseHalfInvariant(this string? value, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
            => Half.TryParse(value, numberStyles, CultureInfo.InvariantCulture, out Half result) ? result : default;
    }

    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
