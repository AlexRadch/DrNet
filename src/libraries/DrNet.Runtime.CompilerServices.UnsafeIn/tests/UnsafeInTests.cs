// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;

namespace System.Runtime.CompilerServices
{
    public class UnsafeTests
    {
        [Fact]
        public static unsafe void CopyToVoidPtr()
        {
            int value = 10;
            int destination = -1;
            UnsafeIn.Copy(UnsafeIn.AsPointer(in destination), value);
            Assert.Equal(10, destination);
            Assert.Equal(10, value);

            int destination2 = -1;
            UnsafeIn.Copy(&destination2, value);
            Assert.Equal(10, destination2);
            Assert.Equal(10, value);
        }

        [Theory]
        [MemberData(nameof(CopyBlockData))]
        public static unsafe void CopyBlockRef(int numBytes)
        {
            byte* source = stackalloc byte[numBytes];
            byte* destination = stackalloc byte[numBytes];

            for (int i = 0; i < numBytes; i++)
            {
                byte value = (byte)(i % 255);
                source[i] = value;
            }

            UnsafeIn.CopyBlock(ref destination[0], source[0], (uint)numBytes);

            for (int i = 0; i < numBytes; i++)
            {
                byte value = (byte)(i % 255);
                Assert.Equal(value, destination[i]);
                Assert.Equal(source[i], destination[i]);
            }
        }

        [Theory]
        [MemberData(nameof(CopyBlockData))]
        public static unsafe void CopyBlockUnalignedRef(int numBytes)
        {
            byte* source = stackalloc byte[numBytes + 1];
            byte* destination = stackalloc byte[numBytes + 1];
            source += 1;      // +1 = make unaligned
            destination += 1; // +1 = make unaligned

            for (int i = 0; i < numBytes; i++)
            {
                byte value = (byte)(i % 255);
                source[i] = value;
            }

            UnsafeIn.CopyBlockUnaligned(ref destination[0], source[0], (uint)numBytes);

            for (int i = 0; i < numBytes; i++)
            {
                byte value = (byte)(i % 255);
                Assert.Equal(value, destination[i]);
                Assert.Equal(source[i], destination[i]);
            }
        }

        public static IEnumerable<object[]> CopyBlockData()
        {
            yield return new object[] { 0 };
            yield return new object[] { 1 };
            yield return new object[] { 10 };
            yield return new object[] { 100 };
            yield return new object[] { 100000 };
        }

        [Fact]
        public static void ByteOffsetArray()
        {
            var a = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            Assert.Equal(new IntPtr(0), UnsafeIn.ByteOffset(a[0], a[0]));
            Assert.Equal(new IntPtr(1), UnsafeIn.ByteOffset(a[0], a[1]));
            Assert.Equal(new IntPtr(-1), UnsafeIn.ByteOffset(a[1], a[0]));
            Assert.Equal(new IntPtr(2), UnsafeIn.ByteOffset(a[0], a[2]));
            Assert.Equal(new IntPtr(-2), UnsafeIn.ByteOffset(a[2], a[0]));
            Assert.Equal(new IntPtr(3), UnsafeIn.ByteOffset(a[0], a[3]));
            Assert.Equal(new IntPtr(4), UnsafeIn.ByteOffset(a[0], a[4]));
            Assert.Equal(new IntPtr(5), UnsafeIn.ByteOffset(a[0], a[5]));
            Assert.Equal(new IntPtr(6), UnsafeIn.ByteOffset(a[0], a[6]));
            Assert.Equal(new IntPtr(7), UnsafeIn.ByteOffset(a[0], a[7]));
        }

        [Fact]
        public static void ByteOffsetStackByte4()
        {
            var byte4 = new Byte4();

            Assert.Equal(new IntPtr(0), UnsafeIn.ByteOffset(byte4.B0, byte4.B0));
            Assert.Equal(new IntPtr(1), UnsafeIn.ByteOffset(byte4.B0, byte4.B1));
            Assert.Equal(new IntPtr(-1), UnsafeIn.ByteOffset(byte4.B1, byte4.B0));
            Assert.Equal(new IntPtr(2), UnsafeIn.ByteOffset(byte4.B0, byte4.B2));
            Assert.Equal(new IntPtr(-2), UnsafeIn.ByteOffset(byte4.B2, byte4.B0));
            Assert.Equal(new IntPtr(3), UnsafeIn.ByteOffset(byte4.B0, byte4.B3));
            Assert.Equal(new IntPtr(-3), UnsafeIn.ByteOffset(byte4.B3, byte4.B0));
        }

        [Fact]
        public static unsafe void AsRef()
        {
            byte[] b = new byte[4] { 0x42, 0x42, 0x42, 0x42 };
            fixed (byte* p = b)
            {
                ref readonly int r = ref UnsafeIn.AsRef<int>(p);
                Assert.Equal(0x42424242, r);

                Unsafe.AsRef(r) = 0x0EF00EF0;
                Assert.Equal(0xFE, b[0] | b[1] | b[2] | b[3]);
            }
        }

        [Fact]
        public static void RefAs()
        {
            byte[] b = new byte[4] { 0x42, 0x42, 0x42, 0x42 };

            ref readonly int r = ref UnsafeIn.As<byte, int>(b[0]);
            Assert.Equal(0x42424242, r);

            Unsafe.AsRef(r) = 0x0EF00EF0;
            Assert.Equal(0xFE, b[0] | b[1] | b[2] | b[3]);
        }

        [Fact]
        public static void RefAdd()
        {
            int[] a = new int[] { 0x123, 0x234, 0x345, 0x456 };

            ref readonly int r1 = ref UnsafeIn.Add(a[0], 1);
            Assert.Equal(0x234, r1);

            ref readonly int r2 = ref UnsafeIn.Add(r1, 2);
            Assert.Equal(0x456, r2);

            ref readonly int r3 = ref UnsafeIn.Add(r2, -3);
            Assert.Equal(0x123, r3);
        }

        [Fact]
        public static void RefAddIntPtr()
        {
            int[] a = new int[] { 0x123, 0x234, 0x345, 0x456 };

            ref readonly int r1 = ref UnsafeIn.Add(a[0], (IntPtr)1);
            Assert.Equal(0x234, r1);

            ref readonly int r2 = ref UnsafeIn.Add(r1, (IntPtr)2);
            Assert.Equal(0x456, r2);

            ref readonly int r3 = ref UnsafeIn.Add(r2, (IntPtr)(-3));
            Assert.Equal(0x123, r3);
        }

        [Fact]
        public static void RefAddNuint()
        {
            int[] a = new int[] { 0x123, 0x234, 0x345, 0x456 };

            ref readonly int r1 = ref UnsafeIn.Add(a[0], (nuint)1);
            Assert.Equal(0x234, r1);

            ref readonly int r2 = ref UnsafeIn.Add(r1, (nuint)2);
            Assert.Equal(0x456, r2);
        }

        [Fact]
        public static void RefAddByteOffset()
        {
            byte[] a = new byte[] { 0x12, 0x34, 0x56, 0x78 };

            ref readonly byte r1 = ref UnsafeIn.AddByteOffset(a[0], (IntPtr)1);
            Assert.Equal(0x34, r1);

            ref readonly byte r2 = ref UnsafeIn.AddByteOffset(r1, (IntPtr)2);
            Assert.Equal(0x78, r2);

            ref readonly byte r3 = ref UnsafeIn.AddByteOffset(r2, (IntPtr)(-3));
            Assert.Equal(0x12, r3);
        }

        [Fact]
        public static void RefAddNuintByteOffset()
        {
            byte[] a = new byte[] { 0x12, 0x34, 0x56, 0x78 };

            ref readonly byte r1 = ref UnsafeIn.AddByteOffset(a[0], (nuint)1);
            Assert.Equal(0x34, r1);

            ref readonly byte r2 = ref UnsafeIn.AddByteOffset(r1, (nuint)2);
            Assert.Equal(0x78, r2);
        }

        [Fact]
        public static void RefSubtract()
        {
            string[] a = new string[] { "abc", "def", "ghi", "jkl" };

            ref readonly string r1 = ref UnsafeIn.Subtract(a[0], -2);
            Assert.Equal("ghi", r1);

            ref readonly string r2 = ref UnsafeIn.Subtract(r1, -1);
            Assert.Equal("jkl", r2);

            ref readonly string r3 = ref UnsafeIn.Subtract(r2, 3);
            Assert.Equal("abc", r3);
        }

        [Fact]
        public static void RefSubtractIntPtr()
        {
            string[] a = new string[] { "abc", "def", "ghi", "jkl" };

            ref readonly string r1 = ref UnsafeIn.Subtract(a[0], (IntPtr)(-2));
            Assert.Equal("ghi", r1);

            ref readonly string r2 = ref UnsafeIn.Subtract(r1, (IntPtr)(-1));
            Assert.Equal("jkl", r2);

            ref readonly string r3 = ref UnsafeIn.Subtract(r2, (IntPtr)3);
            Assert.Equal("abc", r3);
        }

        [Fact]
        public static void RefSubtractNuint()
        {
            string[] a = new string[] { "abc", "def", "ghi", "jkl" };

            ref readonly string r3 = ref UnsafeIn.Subtract(a[3], (nuint)3);
            Assert.Equal("abc", r3);
        }

        [Fact]
        public static void RefSubtractByteOffset()
        {
            byte[] a = new byte[] { 0x12, 0x34, 0x56, 0x78 };

            ref readonly byte r1 = ref UnsafeIn.SubtractByteOffset(a[0], (IntPtr)(-1));
            Assert.Equal(0x34, r1);

            ref readonly byte r2 = ref UnsafeIn.SubtractByteOffset(r1, (IntPtr)(-2));
            Assert.Equal(0x78, r2);

            ref readonly byte r3 = ref UnsafeIn.SubtractByteOffset(r2, (IntPtr)3);
            Assert.Equal(0x12, r3);
        }

        [Fact]
        public static void RefSubtractNuintByteOffset()
        {
            byte[] a = new byte[] { 0x12, 0x34, 0x56, 0x78 };

            ref readonly byte r3 = ref UnsafeIn.SubtractByteOffset(a[3], (nuint)3);
            Assert.Equal(0x12, r3);
        }

        [Fact]
        public static void RefAreSame()
        {
            long[] a = new long[2];

            Assert.True(UnsafeIn.AreSame(a[0], a[0]));
            Assert.False(UnsafeIn.AreSame(a[0], a[1]));
        }

        [Fact]
        public static unsafe void RefIsAddressGreaterThan()
        {
            int[] a = new int[2];

            Assert.False(UnsafeIn.IsAddressGreaterThan(a[0], a[0]));
            Assert.False(UnsafeIn.IsAddressGreaterThan(a[0], a[1]));
            Assert.True(UnsafeIn.IsAddressGreaterThan(a[1], a[0]));
            Assert.False(UnsafeIn.IsAddressGreaterThan(a[1], a[1]));

            // The following tests ensure that we're using unsigned comparison logic

            Assert.False(UnsafeIn.IsAddressGreaterThan(UnsafeIn.AsRef<byte>((void*)(1)), UnsafeIn.AsRef<byte>((void*)(-1))));
            Assert.True(UnsafeIn.IsAddressGreaterThan(UnsafeIn.AsRef<byte>((void*)(-1)), UnsafeIn.AsRef<byte>((void*)(1))));
            Assert.True(UnsafeIn.IsAddressGreaterThan(UnsafeIn.AsRef<byte>((void*)(int.MinValue)), UnsafeIn.AsRef<byte>((void*)(int.MaxValue))));
            Assert.False(UnsafeIn.IsAddressGreaterThan(UnsafeIn.AsRef<byte>((void*)(int.MaxValue)), UnsafeIn.AsRef<byte>((void*)(int.MinValue))));
            Assert.False(UnsafeIn.IsAddressGreaterThan(UnsafeIn.AsRef<byte>(null), UnsafeIn.AsRef<byte>(null)));
        }

        [Fact]
        public static unsafe void RefIsAddressLessThan()
        {
            int[] a = new int[2];

            Assert.False(UnsafeIn.IsAddressLessThan(a[0], a[0]));
            Assert.True(UnsafeIn.IsAddressLessThan(a[0], a[1]));
            Assert.False(UnsafeIn.IsAddressLessThan(a[1], a[0]));
            Assert.False(UnsafeIn.IsAddressLessThan(a[1], a[1]));

            // The following tests ensure that we're using unsigned comparison logic

            Assert.True(UnsafeIn.IsAddressLessThan(UnsafeIn.AsRef<byte>((void*)(1)), UnsafeIn.AsRef<byte>((void*)(-1))));
            Assert.False(UnsafeIn.IsAddressLessThan(UnsafeIn.AsRef<byte>((void*)(-1)), UnsafeIn.AsRef<byte>((void*)(1))));
            Assert.False(UnsafeIn.IsAddressLessThan(UnsafeIn.AsRef<byte>((void*)(int.MinValue)), UnsafeIn.AsRef<byte>((void*)(int.MaxValue))));
            Assert.True(UnsafeIn.IsAddressLessThan(UnsafeIn.AsRef<byte>((void*)(int.MaxValue)), UnsafeIn.AsRef<byte>((void*)(int.MinValue))));
            Assert.False(UnsafeIn.IsAddressLessThan(UnsafeIn.AsRef<byte>(null), UnsafeIn.AsRef<byte>(null)));
        }

        [Fact]
        public static unsafe void ReadUnaligned_ByRef_Int32()
        {
            byte[] unaligned = Int32Double.Unaligned(123456789, 3.42);

            int actual = UnsafeIn.ReadUnaligned<int>(unaligned[1]);

            Assert.Equal(123456789, actual);
        }

        [Fact]
        public static unsafe void ReadUnaligned_ByRef_Double()
        {
            byte[] unaligned = Int32Double.Unaligned(123456789, 3.42);

            double actual = UnsafeIn.ReadUnaligned<double>(unaligned[9]);

            Assert.Equal(3.42, actual);
        }

        [Fact]
        public static unsafe void ReadUnaligned_ByRef_Struct()
        {
            byte[] unaligned = Int32Double.Unaligned(123456789, 3.42);

            Int32Double actual = UnsafeIn.ReadUnaligned<Int32Double>(unaligned[1]);

            Assert.Equal(123456789, actual.Int32);
            Assert.Equal(3.42, actual.Double);
        }

        [Fact]
        public static void Unbox_Int32()
        {
            object box = 42;

            Assert.True(UnsafeIn.AreSame(UnsafeIn.Unbox<int>(box), UnsafeIn.Unbox<int>(box)));

            Assert.Equal(42, (int)box);
            Assert.Equal(42, UnsafeIn.Unbox<int>(box));

            ref readonly int value = ref UnsafeIn.Unbox<int>(box);
            Unsafe.AsRef(value) = 84;
            Assert.Equal(84, (int)box);
            Assert.Equal(84, UnsafeIn.Unbox<int>(box));

            Assert.Throws<InvalidCastException>(() => UnsafeIn.Unbox<Byte4>(box));
        }

        [Fact]
        public static void Unbox_CustomValueType()
        {
            object box = new Int32Double();

            Assert.Equal(0, ((Int32Double)box).Double);
            Assert.Equal(0, ((Int32Double)box).Int32);

            ref readonly Int32Double value = ref UnsafeIn.Unbox<Int32Double>(box);
            Unsafe.AsRef(value).Double = 42;
            Unsafe.AsRef(value).Int32 = 84;

            Assert.Equal(42, ((Int32Double)box).Double);
            Assert.Equal(84, ((Int32Double)box).Int32);

            Assert.Throws<InvalidCastException>(() => UnsafeIn.Unbox<bool>(box));
        }

        [Fact]
        public static unsafe void IsNullRef_NotNull()
        {
            // Validate that calling with a primitive type works.

            int intValue = 5;
            Assert.False(UnsafeIn.IsNullRef<int>(intValue));

            // Validate that calling on user-defined unmanaged structs works.

            Int32Double int32DoubleValue = default;
            Assert.False(UnsafeIn.IsNullRef<Int32Double>(int32DoubleValue));

            // Validate that calling on reference types works.

            object objectValue = new object();
            Assert.False(UnsafeIn.IsNullRef<object>(objectValue));

            string stringValue = nameof(IsNullRef_NotNull);
            Assert.False(UnsafeIn.IsNullRef<string>(stringValue));

            // Validate on ref created from a pointer

            int* p = (int*)1;
            Assert.False(UnsafeIn.IsNullRef<int>(UnsafeIn.AsRef<int>(p)));
        }

        [Fact]
        public static unsafe void IsNullRef_Null()
        {
            // Validate that calling with a primitive type works.

            Assert.True(UnsafeIn.IsNullRef<int>(UnsafeIn.AsRef<int>(null)));

            // Validate that calling on user-defined unmanaged structs works.

            Assert.True(UnsafeIn.IsNullRef<Int32Double>(UnsafeIn.AsRef<Int32Double>(null)));

            // Validate that calling on reference types works.

            Assert.True(UnsafeIn.IsNullRef<object>(UnsafeIn.AsRef<object>(null)));
            Assert.True(UnsafeIn.IsNullRef<string>(UnsafeIn.AsRef<string>(null)));

            // Validate on ref created from a pointer

            int* p = (int*)0;
            Assert.True(UnsafeIn.IsNullRef<int>(UnsafeIn.AsRef<int>(p)));
        }

        [Fact]
        public static unsafe void NullRef()
        {
            // Validate that calling with a primitive type works.

            Assert.True(UnsafeIn.IsNullRef<int>(UnsafeIn.NullRef<int>()));

            // Validate that calling on user-defined unmanaged structs works.

            Assert.True(UnsafeIn.IsNullRef<Int32Double>(UnsafeIn.NullRef<Int32Double>()));

            // Validate that calling on reference types works.

            Assert.True(UnsafeIn.IsNullRef<object>(UnsafeIn.NullRef<object>()));
            Assert.True(UnsafeIn.IsNullRef<string>(UnsafeIn.NullRef<string>()));

            // Validate that pinning results in a null pointer

            fixed (void* p = &UnsafeIn.NullRef<int>())
            {
                Assert.True(p == (void*)0);
            }

            // Validate that dereferencing a null ref throws a NullReferenceException

            Assert.Throws<NullReferenceException>(() => Unsafe.AsRef(UnsafeIn.NullRef<int>()) = 42);
            Assert.Throws<NullReferenceException>(() => UnsafeIn.NullRef<int>());
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Byte4
    {
        [FieldOffset(0)]
        public byte B0;
        [FieldOffset(1)]
        public byte B1;
        [FieldOffset(2)]
        public byte B2;
        [FieldOffset(3)]
        public byte B3;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe struct Int32Double
    {
        [FieldOffset(0)]
        public int Int32;
        [FieldOffset(8)]
        public double Double;

        public static unsafe byte[] Unaligned(int i, double d)
        {
            var aligned = new Int32Double { Int32 = i, Double = d };
            var unaligned = new byte[sizeof(Int32Double) + 1];

            fixed (byte* p = unaligned)
            {
                Buffer.MemoryCopy(&aligned, p + 1, sizeof(Int32Double), sizeof(Int32Double));
            }

            return unaligned;
        }
    }
}
