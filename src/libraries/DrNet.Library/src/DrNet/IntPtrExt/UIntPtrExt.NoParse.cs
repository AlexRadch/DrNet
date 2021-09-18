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
    /// Extensions methods for UIntPtr class
    /// </summary>
    public static partial class UIntPtrExt
    {
        public static UIntPtr Parse(string s)
        => UIntPtr.Size switch
        {
            8 => (UIntPtr)ulong.Parse(s),
            _ => (UIntPtr)uint.Parse(s),
        };

        public static UIntPtr Parse(string s, NumberStyles style)
        => UIntPtr.Size switch
        {
            8 => (UIntPtr)ulong.Parse(s, style),
            _ => (UIntPtr)uint.Parse(s, style),
        };

        public static UIntPtr Parse(string s, NumberStyles style, IFormatProvider? provider)
        => UIntPtr.Size switch
        {
            8 => (UIntPtr)ulong.Parse(s, style, provider),
            _ => (UIntPtr)uint.Parse(s, style, provider),
        };

        public static UIntPtr Parse(string s, IFormatProvider? provider)
        => UIntPtr.Size switch
        {
            8 => (UIntPtr)ulong.Parse(s, provider),
            _ => (UIntPtr)uint.Parse(s, provider),
        };

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out UIntPtr result)
        => UIntPtr.Size switch
        {
            8 => ulong.TryParse(s, style, provider, out UnsafeOut.As<UIntPtr, ulong>(out result)),
            _ => uint.TryParse(s, style, provider, out UnsafeOut.As<UIntPtr, uint>(out result)),
        };

        public static bool TryParse([NotNullWhen(true)] string? s, out UIntPtr result)
        => UIntPtr.Size switch
        {
            8 => ulong.TryParse(s, out UnsafeOut.As<UIntPtr, ulong>(out result)),
            _ => uint.TryParse(s, out UnsafeOut.As<UIntPtr, uint>(out result)),
        };
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
