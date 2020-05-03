namespace JbQuasirandom
{
    using System;

    internal static class IntegerMath
    {
        /// <summary>Returns the logarithm of an integer to an integer base.</summary>
        /// <param name="value">The value.</param>
        /// <param name="b">The base.</param>
        /// <returns>The logarithm.</returns>
        public static int Log(int value, int b)
        {
            int result = 0;
            int absValue = Math.Abs(value);
            if (absValue >= 2)
            {
                int absBase = Math.Abs(b);
                if (absBase >= 2)
                {
                    while (absValue >= absBase)
                    {
                        absValue /= absBase;
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
