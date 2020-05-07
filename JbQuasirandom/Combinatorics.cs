namespace JbQuasirandom
{
    using System;

    /// <summary>Combinatorics math.</summary>
    internal static class Combinatorics
    {
        /// <summary>Computes a table of bionomial coefficients (Pascal's triangle) modulo a specified number.</summary>
        /// <param name="moduloNumber">The base for the modulo operation.</param>
        /// <param name="upperIndex">The upper bound for the row index.</param>
        /// <returns>An jagged array of length <paramref name="upperIndex"/>+1.</returns>
        public static int[][] BinomialTableMod(int moduloNumber, int upperIndex)
        {
            // original code from https://people.sc.fsu.edu/~jburkardt/cpp_src/faure/faure.cpp
            if (upperIndex < 0)
            {
                throw new ArgumentException("Upper bound must not be negative.", nameof(upperIndex));
            }

            int[][] coeff = new int[upperIndex + 1][];
            for (int i = 0; i <= upperIndex; i++)
            {
                coeff[i] = new int[i + 1];
                coeff[i][0] = 1;
                coeff[i][i] = 1;
            }
            for (int i = 2; i <= upperIndex; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    coeff[i][j] = (coeff[i - 1][j - 1] + coeff[i - 1][j]) % moduloNumber;
                }
            }
            return coeff;
        }
    }
}
