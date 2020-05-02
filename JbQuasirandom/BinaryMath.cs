namespace JbQuasirandom
{
    /// <summary>Provides helper methods for binary numbers.</summary>
    internal static class BinaryMath
    {
        /// <summary>Returns the position of the highest 1 bit in an integer number.</summary>
        /// <param name="number">The integer to be measured.</param>
        /// <returns>The position of the high order bit or zero if <paramref name="number"/> is non-positive.</returns>
        public static int GetHighestBit1Position(long number)
        {
            int bit = 0;
            while (number > 0)
            {
                bit++;
                number /= 2L;
            }
            return bit;
        }

        /// <summary>Returns the position of the lowest 0 bit in an integer number.</summary>
        /// <param name="number">The integer to be measured. n should be nonnegative.</param>
        /// <returns>The position of the lowest 0 bit.</returns>
        public static int GetLowestBit0Position(long number)
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
