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
    /// Extensions methods for IntPtr class
    /// </summary>
    public static partial class IntPtrExt
    {
        public static IntPtr Parse(string s)
        => IntPtr.Parse(s);

        public static IntPtr Parse(string s, NumberStyles style)
        => IntPtr.Parse(s, style);

        public static IntPtr Parse(string s, NumberStyles style, IFormatProvider? provider)
        => IntPtr.Parse(s, style, provider);

        public static IntPtr Parse(string s, IFormatProvider? provider)
        => IntPtr.Parse(s, provider);

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out IntPtr result)
        => IntPtr.TryParse(s, style, provider, out result);

        public static bool TryParse([NotNullWhen(true)] string? s, out IntPtr result)
        => IntPtr.TryParse(s, out result);
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
