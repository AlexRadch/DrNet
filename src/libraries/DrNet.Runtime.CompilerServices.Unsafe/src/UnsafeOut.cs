// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Contains generic, low-level functionality for manipulating out pointers.
    /// </summary>
    public static unsafe class UnsafeOut
    {
        /// <summary>
        /// Reinterprets the given reference as a reference to a value of type TTo.
        /// </summary>
        /// 
        /// <typeparam name="TFrom">The type of reference to reinterpret.</typeparam>
        /// 
        /// <typeparam name="TTo">The desired type of the reference.</typeparam>
        /// 
        /// <param name="source">The reference to reinterpret.</param>
        /// 
        /// <returns>A reference to a value of type TTo.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TTo As<TFrom, TTo>(out TFrom source)
        {
            Unsafe.SkipInit(out source);
            return ref Unsafe.As<TFrom, TTo>(ref source);
        }
    }
}
