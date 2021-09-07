// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Runtime.CompilerServices;
using Xunit;

namespace DrNet.Runtime.CompilerServices.Tests
{
    public class UnsafeOutTests
    {
        [Fact]
        public static void RefAs()
        {
            byte[] b = new byte[4] { 0x42, 0x42, 0x42, 0x42 };

            ref int r = ref UnsafeOut.As<byte, int>(out b[0]);
            Assert.Equal(0x42424242, r);

            r = 0x0EF00EF0;
            Assert.Equal(0xFE, b[0] | b[1] | b[2] | b[3]);
        }
    }
}
