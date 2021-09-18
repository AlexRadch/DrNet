using Xunit;


namespace DrNet.Math.Tests
{
    public class DrNetMathTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 23)]
        [InlineData(0, uint.MaxValue)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 25)]
        [InlineData(1, uint.MaxValue)]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        [InlineData(-1, 2)]
        [InlineData(-1, 25)]
        [InlineData(-1, uint.MaxValue)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 17)]
        [InlineData(2, 62)]
        [InlineData(-2, 0)]
        [InlineData(-2, 1)]
        [InlineData(-2, 2)]
        [InlineData(-2, 14)]
        [InlineData(-2, 17)]
        [InlineData(-2, 63)]
        [InlineData(17, 0)]
        [InlineData(17, 1)]
        [InlineData(17, 2)]
        [InlineData(17, 7)]
        [InlineData(-15, 0)]
        [InlineData(-15, 1)]
        [InlineData(-15, 2)]
        [InlineData(-15, 7)]
        [InlineData(int.MaxValue, 0)]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, 0)]
        [InlineData(int.MinValue, 1)]
        public void IntPowerLong(long x, uint exp)
            => Assert.Equal(System.Math.Pow(x, exp), MathExt.IntPower(x, exp));
    }
}
