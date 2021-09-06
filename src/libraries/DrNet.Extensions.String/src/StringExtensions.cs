// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;
using System.Text;

namespace DrNet.Extensions.String
{
    /// <summary>
    /// Extensions methods for string class
    /// </summary>
    public static class StringExtensions
    {
        #region Fast static methods access

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length)
            => string.Compare(strA, indexA, strB, indexB, length);

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase)
#if !StringNoCompareCulture
            => string.Compare(strA, indexA, strB, indexB, length, ignoreCase);
#else
        {
            // Ideally we would just forward to the string.Compare overload that takes
            // a StringComparison parameter, and just pass in CurrentCulture/CurrentCultureIgnoreCase.
            // That function will return early if an optimization can be applied, e.g. if
            // (object)strA == strB && indexA == indexB then it will return 0 straightaway.
            // There are a couple of subtle behavior differences that prevent us from doing so
            // however:
            // - string.Compare(null, -1, null, -1, -1, StringComparison.CurrentCulture) works
            //   since that method also returns early for nulls before validation. It shouldn't
            //   for this overload.
            // - Since we originally forwarded to CompareInfo.Compare for all of the argument
            //   validation logic, the ArgumentOutOfRangeExceptions thrown will contain different
            //   parameter names.
            // Therefore, we have to duplicate some of the logic here.

            int lengthA = length;
            int lengthB = length;

            if (strA != null)
            {
                lengthA = Math.Min(lengthA, strA.Length - indexA);
            }

            if (strB != null)
            {
                lengthB = Math.Min(lengthB, strB.Length - indexB);
            }

            CompareOptions options = ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None;
            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, options);
        }
#endif

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase, CultureInfo? culture)
#if !StringNoCompareCulture
            => string.Compare(strA, indexA, strB, indexB, length, ignoreCase, culture);
#else
        {
            CompareOptions options = ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None;
            return Compare(strA, indexA, strB, indexB, length, culture, options);
        }
#endif

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, CultureInfo? culture, CompareOptions options)
#if !StringNoCompareCulture
            => string.Compare(strA, indexA, strB, indexB, length, culture, options);
#else
        {
            CultureInfo compareCulture = culture ?? CultureInfo.CurrentCulture;
            int lengthA = length;
            int lengthB = length;

            if (strA != null)
            {
                lengthA = Math.Min(lengthA, strA.Length - indexA);
            }

            if (strB != null)
            {
                lengthB = Math.Min(lengthB, strB.Length - indexB);
            }

            return compareCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, options);
        }
#endif

        public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, StringComparison comparisonType)
            => string.Compare(strA, indexA, strB, indexB, length, comparisonType);

        public static int Compare(this string? strA, string? strB)
            => string.Compare(strA, strB);

        public static int Compare(this string? strA, string? strB, bool ignoreCase)
#if !StringNoCompareCulture
            => string.Compare(strA, strB, ignoreCase);
#else
        {
            StringComparison comparisonType = ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
            return Compare(strA, strB, comparisonType);
        }
#endif

        public static int Compare(this string? strA, string? strB, bool ignoreCase, CultureInfo? culture)
#if !StringNoCompareCulture
        => string.Compare(strA, strB, ignoreCase, culture);
#else
        {
            CompareOptions options = ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None;
            return Compare(strA, strB, culture, options);
        }
#endif

        public static int Compare(this string? strA, string? strB, CultureInfo? culture, CompareOptions options)
#if !StringNoCompareCulture
            => string.Compare(strA, strB, culture, options);
#else
        {
            CultureInfo compareCulture = culture ?? CultureInfo.CurrentCulture;
            return compareCulture.CompareInfo.Compare(strA, strB, options);
        }
#endif

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

#if !StringNoIntern
        public static string Intern(this string str)
            => string.Intern(str);
#endif

#if !StringNoIntern
        public static string? IsInterned(this string str)
            => string.IsInterned(str);
#endif

        //public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
        public static bool IsNullOrEmpty(this string? value)
            => string.IsNullOrEmpty(value);

        //public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
        public static bool IsNullOrWhiteSpace(this string? value)
            => string.IsNullOrWhiteSpace(value);

#endregion

        #region Contains

        public static bool Contains(this string str, char value)
            => str.IndexOf(value) >= 0;

        public static bool Contains(this string str, char value, StringComparison comparisonType)
#if !StringNoIndexOfCharComparisonType
            => str.IndexOf(value, comparisonType) >= 0;
#else
            => str.IndexOf(value.ToString(), comparisonType) >= 0;
#endif

        public static bool Contains(this string str, string value, StringComparison comparisonType)
            => str.IndexOf(value, comparisonType) >= 0;

        #endregion

        #region StartsWith EndWith

        public static bool EndsWith(this string str, char value)
        {
            int lastPos = str.Length - 1;
            return ((uint)lastPos < (uint)str.Length) && str[lastPos] == value;
        }

        public static bool EndsWith(this string @this, string value, bool ignoreCase, CultureInfo? culture)
        {
            if (null == value)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if ((object)@this == (object)value)
            {
                return true;
            }

            CultureInfo referenceCulture = culture ?? CultureInfo.CurrentCulture;
            return referenceCulture.CompareInfo.IsSuffix(@this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
        }

        public static bool StartsWith(this string str, char value)
             => str.Length != 0 && str[0] == value;

        public static bool StartsWith(this string @this, string value, bool ignoreCase, CultureInfo? culture)
        {
            if (null == value)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if ((object)@this == (object)value)
            {
                return true;
            }

            CultureInfo referenceCulture = culture ?? CultureInfo.CurrentCulture;
            return referenceCulture.CompareInfo.IsPrefix(@this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
        }

        #endregion

        #region Not

        public static bool NotContains(this string str, char value)
            => !str.Contains(value);

        public static bool NotContains(this string str, char value, StringComparison comparisonType)
            => !str.Contains(value, comparisonType);

        public static bool NotContains(this string str, string value)
            => !str.Contains(value);

        public static bool NotContains(this string str, string value, StringComparison comparisonType)
            => !str.Contains(value, comparisonType);

        public static bool NotEndsWith(this string str, char value)
            => !str.EndsWith(value);

        public static bool NotEndsWith(this string str, string value)
            => !str.EndsWith(value);

        public static bool NotEndsWith(this string str, string value, bool ignoreCase, CultureInfo? culture)
            => !str.EndsWith(value, ignoreCase, culture);

        public static bool NotEndsWith(this string str, string value, StringComparison comparisonType)
            => !str.EndsWith(value, comparisonType);

        public static bool NotEquals(this string? a, string? b)
            => !string.Equals(a, b);

        public static bool NotEquals(this string? a, string? b, StringComparison comparisonType)
            => !string.Equals(a, b, comparisonType);

#if !StringNoNormalization
        public static bool IsNotNormalized(this string str)
            => !str.IsNormalized();
#endif

#if !StringNoNormalization
        public static bool IsNotNormalized(this string str, NormalizationForm normalizationForm)
            => !str.IsNormalized(normalizationForm);
#endif

        //public static bool IsNotNullAndNotEmpty([NotNullWhen(false)] this string? value)
        public static bool IsNotNullAndNotEmpty(this string? value)
            => !string.IsNullOrEmpty(value);

        //public static bool IsNotNullAndNotWhiteSpace([NotNullWhen(false)] this string? value)
        public static bool IsNotNullAndNotWhiteSpace(this string? value)
            => !string.IsNullOrWhiteSpace(value);

        public static bool NotStartsWith(this string str, char value)
            => !str.StartsWith(value);

        public static bool NotStartsWith(this string str, string value)
            => !str.StartsWith(value);

        public static bool NotStartsWith(this string str, string value, bool ignoreCase, CultureInfo? culture)
            => !str.StartsWith(value, ignoreCase, culture);

        public static bool NotStartsWith(this string str, string value, StringComparison comparisonType)
            => !str.StartsWith(value, comparisonType);

        #endregion

        public static string EmptyIfIsNull(this string? @this)
            => @this.IsNullOrEmpty() ? string.Empty : @this;

        public static string EmptyIfIsNullOrWhiteSpace(this string? @this)
            => @this.IsNullOrWhiteSpace() ? string.Empty : @this;

        public static string RemoveStart(this string @this, string value)
            => @this.StartsWith(value) ? @this.Substring(value.Length) : @this;

        public static string RemoveEnd(this string @this, string value)
            => @this.EndsWith(value) ? @this.Substring(0, @this.Length - value.Length) : @this;
    }
}
