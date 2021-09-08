// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace DrNet.Extensions.Cs
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions methods for C# language
    /// </summary>
    public static class CsExtensions
    {
        #region InSet

        public static bool InSet<T>(this T @this, IEnumerable<T> set)
        => set.Contains(@this);

        public static bool InSet<T>(this T @this, IEnumerable<T> set, IEqualityComparer<T>? comparer)
        => set.Contains(@this, comparer);

        public static bool InSet<T>(this T @this, T element1, T element2)
        => EqualityComparer<T>.Default.Equals(element1, @this) || EqualityComparer<T>.Default.Equals(element2, @this);
        public static bool InSet<T>(this T @this, T element1, T element2, T element3)
        => EqualityComparer<T>.Default.Equals(element1, @this) || EqualityComparer<T>.Default.Equals(element2, @this) || EqualityComparer<T>.Default.Equals(element3, @this);

        public static bool InSet<T>(this T @this, T element1, T element2, T element3, T element4)
        => EqualityComparer<T>.Default.Equals(element1, @this) || EqualityComparer<T>.Default.Equals(element2, @this) || EqualityComparer<T>.Default.Equals(element3, @this)
            || EqualityComparer<T>.Default.Equals(element4, @this);

        public static bool InSet<T>(this T @this, params T[] set)
        => set.Contains(@this);

        public static bool InSet<T>(this T @this, IEqualityComparer<T>? comparer, T element1, T element2)
        => comparer is null
            ? EqualityComparer<T>.Default.Equals(element1, @this) || EqualityComparer<T>.Default.Equals(element2, @this)
            : comparer.Equals(element1, @this) || comparer.Equals(element2, @this);

        public static bool InSet<T>(this T @this, IEqualityComparer<T>? comparer, T element1, T element2, T element3)
        => comparer is null
            ? EqualityComparer<T>.Default.Equals(element1, @this) || EqualityComparer<T>.Default.Equals(element2, @this) || EqualityComparer<T>.Default.Equals(element3, @this)
            : comparer.Equals(element1, @this) || comparer.Equals(element2, @this) || comparer.Equals(element3, @this);

        public static bool InSet<T>(this T @this, IEqualityComparer<T>? comparer, T element1, T element2, T element3, T element4)
        => comparer is null
            ? EqualityComparer<T>.Default.Equals(element1, @this) || EqualityComparer<T>.Default.Equals(element2, @this) || EqualityComparer<T>.Default.Equals(element3, @this)
                 || EqualityComparer<T>.Default.Equals(element4, @this)
            : comparer.Equals(element1, @this) || comparer.Equals(element2, @this) || comparer.Equals(element3, @this) || comparer.Equals(element4, @this);

        public static bool InSet<T>(this T @this, IEqualityComparer<T>? comparer, params T[] set)
        => set.Contains(@this, comparer);

        #endregion
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
