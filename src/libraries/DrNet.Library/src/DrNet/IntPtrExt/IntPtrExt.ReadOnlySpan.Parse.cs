// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Globalization;

namespace DrNet.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for IntPtr class
    /// </summary>
    public static partial class IntPtrExt
    {
        public static IntPtr Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
        => IntPtr.Parse(s, style, provider);

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out IntPtr result)
        => IntPtr.TryParse(s, style, provider, out result);

        public static bool TryParse(ReadOnlySpan<char> s, out IntPtr result)
        => IntPtr.TryParse(s, out result);
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
