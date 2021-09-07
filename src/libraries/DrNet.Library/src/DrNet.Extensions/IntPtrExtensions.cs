// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using DrNet.Runtime.CompilerServices;

namespace DrNet.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for IntPtr class
    /// </summary>
    public static partial class IntPtrExtensions
    {
        public static IntPtr Parse(string s)
        => IntPtr.Size switch
        {
            8 => (IntPtr)long.Parse(s),
            _ => (IntPtr)int.Parse(s),
        };

        public static IntPtr Parse(string s, NumberStyles style)
        => IntPtr.Size switch
        {
            8 => (IntPtr)long.Parse(s, style),
            _ => (IntPtr)int.Parse(s, style),
        };

        public static IntPtr Parse(string s, NumberStyles style, IFormatProvider? provider)
        => IntPtr.Size switch
        {
            8 => (IntPtr)long.Parse(s, style, provider),
            _ => (IntPtr)int.Parse(s, style, provider),
        };

        public static IntPtr Parse(string s, IFormatProvider? provider)
        => IntPtr.Size switch
        {
            8 => (IntPtr)long.Parse(s, provider),
            _ => (IntPtr)int.Parse(s, provider),
        };

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out IntPtr result)
        => IntPtr.Size switch
        {
            8 => long.TryParse(s, style, provider, out UnsafeOut.As<IntPtr, long>(out result)),
            _ => int.TryParse(s, style, provider, out UnsafeOut.As<IntPtr, int>(out result)),
        };

        public static bool TryParse([NotNullWhen(true)] string? s, out IntPtr result)
        => IntPtr.Size switch
        {
            8 => long.TryParse(s, out UnsafeOut.As<IntPtr, long>(out result)),
            _ => int.TryParse(s, out UnsafeOut.As<IntPtr, int>(out result)),
        };
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
