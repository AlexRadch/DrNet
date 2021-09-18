// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;

namespace DrNet.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for UIntPtr class
    /// </summary>
    public static partial class UIntPtrExt
    {
        public static UIntPtr Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
        => UIntPtr.Parse(s, style, provider);

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out UIntPtr result)
        => UIntPtr.TryParse(s, style, provider, out result);

        public static bool TryParse(ReadOnlySpan<char> s, out UIntPtr result)
        => UIntPtr.TryParse(s, out result);
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
