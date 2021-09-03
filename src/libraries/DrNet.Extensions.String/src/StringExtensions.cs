// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DrNet.Extensions.String
{
    public static class StringExtensions
    {
        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length)
            => string.Compare(strA, indexA, strB, indexB, length);

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase)
            => string.Compare(strA, indexA, strB, indexB, length, ignoreCase);

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase, CultureInfo? culture)
            => string.Compare(strA, indexA, strB, indexB, length, ignoreCase, culture);

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, CultureInfo? culture, CompareOptions options)
            => string.Compare(strA, indexA, strB, indexB, length, culture, options);

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, StringComparison comparisonType)
            => string.Compare(strA, indexA, strB, indexB, length, comparisonType);

        public static int Compare(this string? strA, string? strB)
            => string.Compare(strA, strB);

        public static int Compare(this string? strA, string? strB, bool ignoreCase)
            => string.Compare(strA, strB, ignoreCase);

        public static int Compare(this string? strA, string? strB, bool ignoreCase, CultureInfo? culture)
            => string.Compare(strA, strB, ignoreCase, culture);

        public static int Compare(this string? strA, string? strB, CultureInfo? culture, CompareOptions options)
            => string.Compare(strA, strB, culture, options);

        public static int Compare(this string? strA, string? strB, StringComparison comparisonType)
            => string.Compare(strA, strB, comparisonType);

        public static int CompareOrdinal(this string? strA, int indexA, string? strB, int indexB, int length)
            => string.CompareOrdinal(strA, indexA, strB, indexB, length);

        public static int CompareOrdinal(this string? strA, string? strB)
            => string.CompareOrdinal(strA, strB);

        public static string Concat(this string? str0, string? str1)
            => string.Concat(str0, str1);

        public static string Concat(this string? str0, string? str1, string? str2)
            => string.Concat(str0, str1, str2);

        public static string Concat(this string? str0, string? str1, string? str2, string? str3)
            => string.Concat(str0, str1, str2, str3);

        public static bool Equals(this string? a, string? b)
            => string.Equals(a, b);

        public static bool Equals(this string? a, string? b, StringComparison comparisonType)
            => string.Equals(a, b, comparisonType);

        public static string Format(this string format, object? arg0)
            => string.Format(format, arg0);

        public static string Format(this string format, object? arg0, object? arg1)
            => string.Format(format, arg0, arg1);

        public static string Format(this string format, object? arg0, object? arg1, object? arg2)
            => string.Format(format, arg0, arg1, arg2);

        public static string Format(this string format, params object?[] args)
            => string.Format(format, args);

        public static string Intern(this string str)
            => string.Intern(str);

        public static string? IsInterned(this string str)
            => string.IsInterned(str);

        //public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
        public static bool IsNullOrEmpty(this string? value)
            => string.IsNullOrEmpty(value);

        //public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
        public static bool IsNullOrWhiteSpace(this string? value)
            => string.IsNullOrWhiteSpace(value);


        public static bool NotEquals(this string? a, string? b)
            => !string.Equals(a, b);

        public static bool NotEquals(this string? a, string? b, StringComparison comparisonType)
            => !string.Equals(a, b, comparisonType);

        //public static bool IsNotNullAndNotEmpty([NotNullWhen(false)] this string? value)
        public static bool IsNotNullAndNotEmpty(this string? value)
            => !string.IsNullOrEmpty(value);

        //public static bool IsNotNullAndNotWhiteSpace([NotNullWhen(false)] this string? value)
        public static bool IsNotNullAndNotWhiteSpace(this string? value)
            => !string.IsNullOrWhiteSpace(value);

        public static string RemoveStart(this string @this, string value)
        {
            if (@this.StartsWith(value))
                return @this.Substring(value.Length);
            return @this;
        }

        public static string RemoveEnd(this string @this, string value)
        {
            if (@this.EndsWith(value))
                return @this.Substring(0, @this.Length - value.Length);
            return @this;
        }
    }
}
