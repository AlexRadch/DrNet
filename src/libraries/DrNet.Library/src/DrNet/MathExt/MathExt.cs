#nullable enable

namespace DrNet
{
    /// <summary>
    /// TODO: MathDr
    /// </summary>
    public static class MathExt
    {
        #region IntPower

        /// <summary>
        /// TODO: IntPower
        /// </summary>
        /// <param name="x"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static long IntPower(long x, uint exp)
        {
            long result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    result *= x;
                exp >>= 1;
                x *= x;
            }
            return result;
        }

        /// <summary>
        /// TODO: IntPower
        /// </summary>
        /// <param name="x"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static ulong IntPower(ulong x, uint exp)
        {
            ulong result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    result *= x;
                exp >>= 1;
                x *= x;
            }
            return result;
        }

        /// <summary>
        /// TODO: IntPower
        /// </summary>
        /// <param name="x"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static long IntPowerChecked(long x, uint exp)
        {
            long result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    checked { result *= x; }
                exp >>= 1;
                if (exp > 0)
                    checked { x *= x; }
            }
            return result;
        }

        /// <summary>
        /// TODO: IntPower
        /// </summary>
        /// <param name="x"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static ulong IntPowerChecked(ulong x, uint exp)
        {
            ulong result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    checked { result *= x; }
                exp >>= 1;
                if (exp > 0)
                    checked { x *= x; }
            }
            return result;
        }

        #endregion
    }
}
