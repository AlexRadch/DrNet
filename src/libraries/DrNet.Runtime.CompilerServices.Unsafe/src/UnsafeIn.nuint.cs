// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DrNet.Runtime.CompilerServices
{
    /// <summary>
    /// Contains generic, low-level functionality for manipulating readonly pointers.
    /// </summary>
    public static unsafe partial class UnsafeIn
    {
        /// <summary>
        /// Adds an element offset to the given reference.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of reference.</typeparam>
        /// 
        /// <param name="source">The reference to add the offset to.</param>
        /// 
        /// <param name="elementOffset">The offset to add.</param>
        /// 
        /// <returns>A new reference that reflects the addition of offset to pointer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Add<T>(in T source, nuint elementOffset)
            => ref Unsafe.Add(ref Unsafe.AsRef(in source), elementOffset);

        /// <summary>
        /// Adds a byte offset to the given reference.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of reference.</typeparam>
        /// 
        /// <param name="source">The reference to add the offset to.</param>
        /// 
        /// <param name="byteOffset">The offset to add.</param>
        /// 
        /// <returns>A new reference that reflects the addition of byte offset to pointer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T AddByteOffset<T>(in T source, nuint byteOffset)
            => ref Unsafe.AddByteOffset(ref Unsafe.AsRef(in source), byteOffset);

        /// <summary>
        /// Subtracts an element offset from the given reference.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of reference.</typeparam>
        /// 
        /// <param name="source">The reference to subtract the offset from.</param>
        /// 
        /// <param name="elementOffset">The offset to subtract.</param>
        /// 
        /// <returns>A new reference that reflects the subtraction of offset from pointer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Subtract<T>(in T source, nuint elementOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), elementOffset);

        /// <summary>
        /// Subtracts a byte offset from the given reference.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of reference.</typeparam>
        /// 
        /// <param name="source">The reference to subtract the offset from.</param>
        /// 
        /// <param name="byteOffset">The offset to subtract.</param>
        /// 
        /// <returns>A new reference that reflects the subtraction of byte offset from the given reference.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T SubtractByteOffset<T>(in T source, nuint byteOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), byteOffset);
    }
}
