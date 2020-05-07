namespace JbQuasirandom
{
    /// <summary>Provides helper methods for binary numbers.</summary>
    internal static class BinaryMath
    {
        /// <summary>Returns the position of the most-significant 1 bit in an integer number.</summary>
        /// <param name="number">The integer to be measured.</param>
        /// <returns>The position of the most-significant bit, starting from 1, or zero if <paramref name="number"/> is non-positive.</returns>
        public static int GetMostSignificant1BitPosition(long number)
        {
            int bit = 0;
            while (number > 0)
            {
                bit++;
                number /= 2L;
            }
            return bit;
        }

        /// <summary>Returns the position of the least-significant 0 bit in an integer number.</summary>
        /// <param name="number">The integer to be measured. n should be nonnegative.</param>
        /// <returns>The position of the least-significant 0 bit, starting from 1.</returns>
        public static int GetLeastSignificant0BitPosition(long number)
        {
            int bit = 0;
            while (true)
            {
                bit++;
                long n2 = number / 2L;
                if (number == 2L * n2)
                {
                    break;
                }

                number = n2;
            }
            return bit;
        }
    }
}
