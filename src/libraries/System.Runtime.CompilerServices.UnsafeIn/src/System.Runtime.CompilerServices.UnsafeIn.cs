// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Contains generic, low-level functionality for manipulating readonly pointers.
    /// </summary>
    public static unsafe class UnsafeIn
    {
        //public static void* Add<T>(void* source, int elementOffset);

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
        public static ref readonly T Add<T>(in T source, int elementOffset)
            => ref Unsafe.Add(ref Unsafe.AsRef(in source), elementOffset);

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
        public static ref readonly T Add<T>(in T source, IntPtr elementOffset)
            => ref Unsafe.Add(ref Unsafe.AsRef(in source), elementOffset);

#if UNSAFE6P
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
#endif

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
        public static ref readonly T AddByteOffset<T>(in T source, IntPtr byteOffset)
            => ref Unsafe.AddByteOffset(ref Unsafe.AsRef(in source), byteOffset);

#if UNSAFE6P
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
#endif

        /// <summary>
        /// Determines whether the specified references point to the same location.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of reference.</typeparam>
        /// 
        /// <param name="left">The first reference to compare.</param>
        /// 
        /// <param name="right">The second reference to compare.</param>
        /// 
        /// <returns>true if left and right point to the same location; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreSame<T>(in T left, in T right)
            => Unsafe.AreSame(ref Unsafe.AsRef(in left), ref Unsafe.AsRef(in right));

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
        public static ref readonly TTo As<TFrom, TTo>(in TFrom source)
            => ref Unsafe.As<TFrom, TTo>(ref Unsafe.AsRef(in source));

        //[return: NotNullIfNotNull("o")]
        //public static readonly T? As<T>(in object? o) where T : class
        //    => Unsafe.As<T>(o);

        /// <summary>
        /// Returns a pointer to the given by-ref parameter.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of object.</typeparam>
        /// 
        /// <param name="value">The object whose pointer is obtained.</param>
        /// 
        /// <returns>A pointer to the given value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* AsPointer<T>(in T value)
            => Unsafe.AsPointer(ref Unsafe.AsRef(in value));

        //public static ref T AsRef<T>(in T source);

        /// <summary>
        /// Reinterprets the given location as a reference to a value of type T.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the interpreted location.</typeparam>
        /// 
        /// <param name="source">The location of the value to reference.</param>
        /// 
        /// <returns>A reference to a value of type T.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T AsRef<T>(void* source)
            => ref Unsafe.AsRef<T>(source);

        /// <summary>
        /// Determines the byte offset from origin to target from the given references.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of reference.</typeparam>
        /// 
        /// <param name="origin">The reference to origin.</param>
        /// 
        /// <param name="target">The reference to target.</param>
        /// 
        /// <returns>Byte offset from origin to target i.e. target - origin.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ByteOffset<T>([AllowNull] in T origin, [AllowNull] in T target)
            => Unsafe.ByteOffset(ref Unsafe.AsRef(in origin), ref Unsafe.AsRef(in target));

        /// <summary>
        /// Copies a value of type T to the given location.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of value to copy.</typeparam>
        /// 
        /// <param name="destination">The location to copy to.</param>
        /// 
        /// <param name="source">A reference to the value to copy.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<T>(void* destination, in T source)
            => Unsafe.Copy(destination, ref Unsafe.AsRef(in source));

        //public static void Copy<T>(ref T destination, void* source)
        //    => Unsafe.Copy(ref destination, source);

        /// <summary>
        /// Copies bytes from the source address to the destination address.
        /// </summary>
        /// 
        /// <param name="destination">The destination address to copy to.</param>
        /// 
        /// <param name="source">The source address to copy from.</param>
        /// 
        /// <param name="byteCount">The number of bytes to copy.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyBlock(ref byte destination, in byte source, uint byteCount)
            => Unsafe.CopyBlock(ref destination, ref Unsafe.AsRef(in source), byteCount);

        //public static void CopyBlock(void* destination, void* source, uint byteCount);

        /// <summary>
        /// Copies bytes from the source address to the destination address without assuming architecture dependent alignment of the addresses.
        /// </summary>
        /// 
        /// <param name="destination">The destination address to copy to.</param>
        /// 
        /// <param name="source">The source address to copy from.</param>
        /// 
        /// <param name="byteCount">The number of bytes to copy.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyBlockUnaligned(ref byte destination, in byte source, uint byteCount)
            => Unsafe.CopyBlockUnaligned(ref destination, ref Unsafe.AsRef(in source), byteCount);

        //public static void CopyBlockUnaligned(void* destination, void* source, uint byteCount);

        //public static void InitBlock(void* startAddress, byte value, uint byteCount);
        //public static void InitBlock(ref byte startAddress, byte value, uint byteCount);
        //public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount);
        //public static void InitBlockUnaligned(void* startAddress, byte value, uint byteCount);

        /// <summary>
        /// Returns a value that indicates whether a specified reference is greater than another specified reference.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the reference.</typeparam>
        /// 
        /// <param name="left">The first value to compare.</param>
        /// 
        /// <param name="right">The second value to compare.</param>
        /// 
        /// <returns>true if left is greater than right; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressGreaterThan<T>([AllowNull] in T left, [AllowNull] in T right)
            => Unsafe.IsAddressGreaterThan(ref Unsafe.AsRef(in left), ref Unsafe.AsRef(in right));

        /// <summary>
        /// Returns a value that indicates whether a specified reference is less than another specified reference.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the reference.</typeparam>
        /// 
        /// <param name="left">The first value to compare.</param>
        /// 
        /// <param name="right">The second value to compare.</param>
        /// 
        /// <returns>true if left is less than right; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressLessThan<T>([AllowNull] in T left, [AllowNull] in T right)
            => Unsafe.IsAddressLessThan(ref Unsafe.AsRef(in left), ref Unsafe.AsRef(in right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullRef<T>(in T source)
            => Unsafe.IsNullRef(ref Unsafe.AsRef(in source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T NullRef<T>()
            => ref Unsafe.NullRef<T>();

        //public static T Read<T>(void* source);

        /// <summary>
        /// Reads a value of type T from the given location without assuming architecture dependent alignment of the addresses.
        /// </summary>
        /// 
        /// <typeparam name="T">The type to read.</typeparam>
        /// 
        /// <param name="source">The location to read from.</param>
        /// 
        /// <returns>An object of type T read from the given location.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadUnaligned<T>(in byte source)
            => Unsafe.ReadUnaligned<T>(ref Unsafe.AsRef(in source));

        //public static T ReadUnaligned<T>(void* source);
        //public static int SizeOf<T>();
        //public static void SkipInit<T>(out T value);
        //public static void* Subtract<T>(void* source, int elementOffset);

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
        public static ref readonly T Subtract<T>(in T source, int elementOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), elementOffset);

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
        public static ref readonly T Subtract<T>(in T source, IntPtr elementOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), elementOffset);

#if UNSAFE6P
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
#endif

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
        public static ref readonly T SubtractByteOffset<T>(in T source, IntPtr byteOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), byteOffset);

#if UNSAFE6P
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
#endif

        /// <summary>
        /// Returns a mutable ref to a boxed value.
        /// </summary>
        /// 
        /// <typeparam name="T">The type to be unboxed.</typeparam>
        /// 
        /// <param name="box">The value to unbox.</param>
        /// 
        /// <returns>An unmutable ref to the boxed value box.</returns>
        /// 
        /// <exception cref="System.NullReferenceException">box is null, and T is a non-nullable value type.</exception>
        /// 
        /// <exception cref="System.InvalidCastException">box is not a boxed value type. -or- box is not a boxed T.</exception>
        /// 
        /// <exception cref="System.TypeLoadException">T cannot be found.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Unbox<T>(in object box) where T : struct
            => ref Unsafe.Unbox<T>(box);

        //public static void Write<T>(void* destination, T value);
        //public static void WriteUnaligned<T>(ref byte destination, T value);
        //public static void WriteUnaligned<T>(void* destination, T value);
    }
}
