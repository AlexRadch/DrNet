﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DrNet.Extensions.Ptr
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for IntPtr class
    /// </summary>
    public static partial class IntPtrExtensions
    {
        public static IntPtr Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
        => IntPtr.Size switch
        {
            4 => (IntPtr)int.Parse(s, style, provider),
            8 => (IntPtr)long.Parse(s, style, provider),
            _ => throw new NotImplementedException(),
        };

        public static IntPtr Parse(string s)
        => IntPtr.Size switch
        {
            4 => (IntPtr)int.Parse(s),
            8 => (IntPtr)long.Parse(s),
            _ => throw new NotImplementedException(),
        };

        public static IntPtr Parse(string s, NumberStyles style)
        => IntPtr.Size switch
        {
            4 => (IntPtr)int.Parse(s, style),
            8 => (IntPtr)long.Parse(s, style),
            _ => throw new NotImplementedException(),
        };

        public static IntPtr Parse(string s, NumberStyles style, IFormatProvider? provider)
        => IntPtr.Size switch
        {
            4 => (IntPtr)int.Parse(s, style, provider),
            8 => (IntPtr)long.Parse(s, style, provider),
            _ => throw new NotImplementedException(),
        };

        public static IntPtr Parse(string s, IFormatProvider? provider)
        => IntPtr.Size switch
        {
            4 => (IntPtr)int.Parse(s, provider),
            8 => (IntPtr)long.Parse(s, provider),
            _ => throw new NotImplementedException(),
        };

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out IntPtr result)
        => IntPtr.Size switch
        {
            4 => int.TryParse(s, style, provider, out result),
            8 => long.TryParse(s, style, provider, out result),
            _ => throw new NotImplementedException(),
        };

        public static bool TryParse(ReadOnlySpan<char> s, out IntPtr result)
        => IntPtr.Size switch
        {
            4 => int.TryParse(s, out result),
            8 => long.TryParse(s, out result),
            _ => throw new NotImplementedException(),
        };

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out IntPtr result)
        => IntPtr.Size switch
        {
            4 => int.TryParse(s, out result),
            8 => long.TryParse(s, out result),
            _ => throw new NotImplementedException(),
        };

        public static bool TryParse([NotNullWhen(true)] string? s, out IntPtr result)
        => IntPtr.Size switch
        {
            4 => int.TryParse(s, out result),
            8 => long.TryParse(s, out result),
            _ => throw new NotImplementedException(),
        };
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
