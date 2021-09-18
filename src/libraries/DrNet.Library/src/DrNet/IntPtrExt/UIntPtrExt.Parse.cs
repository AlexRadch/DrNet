// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DrNet.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for UIntPtr class
    /// </summary>
    public static partial class UIntPtrExt
    {
        public static UIntPtr Parse(string s)
        => UIntPtr.Parse(s);

        public static UIntPtr Parse(string s, NumberStyles style)
        => UIntPtr.Parse(s, style);

        public static UIntPtr Parse(string s, NumberStyles style, IFormatProvider? provider)
        => UIntPtr.Parse(s, style, provider);

        public static UIntPtr Parse(string s, IFormatProvider? provider)
        => UIntPtr.Parse(s, provider);

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out UIntPtr result)
        => UIntPtr.TryParse(s, style, provider, out result);

        public static bool TryParse([NotNullWhen(true)] string? s, out UIntPtr result)
        => UIntPtr.TryParse(s, out result);
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
