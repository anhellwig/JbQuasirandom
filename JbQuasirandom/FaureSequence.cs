// original code from https://people.sc.fsu.edu/~jburkardt/cpp_src/faure/faure.cpp

namespace JbQuasirandom
{
    using System;

    /// <summary>Computes elements of the Faure sequence.</summary>
    public class FaureSequence : ISequence
    {
        private readonly int dimensionCount;
        private int seed;
        private int qs;
        private int hisumSave = -1;
        private int[][] coeff;
        private int[] ytemp;

        /// <summary>Initializes a new instance of the <see cref="FaureSequence" /> class.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <exception cref="ArgumentException">Thrown when the number of dimensions is less than 2 or larger than 13499.</exception>
        public FaureSequence(int dimensionCount) : this(dimensionCount, true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FaureSequence" /> class.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <param name="skipInitial">Specified whether an initial part of the sequence shall be skipped.</param>
        /// <exception cref="ArgumentException">Thrown when the number of dimensions is less than 2 or larger than 13499.</exception>
        public FaureSequence(int dimensionCount, bool skipInitial)
        {
            int maxDim = PrimeNumberMath.Primes[PrimeNumberMath.Primes.Count - 1];
            if (dimensionCount < 2  || dimensionCount > maxDim)
            {
                throw new ArgumentException($"The number of dimensions must be larger than 1 and not greather than {maxDim}.", nameof(dimensionCount));
            }
            this.dimensionCount = dimensionCount;
            if (skipInitial)
            {
                seed = -1;
            }
        }

        /// <summary>Gets the next element of the sequence.</summary>
        /// <returns>The next element of the sequence.</returns>
        public double[] Next()
        {
            // Initialization required?
            if (qs <= 0 || seed <= 0)
            {
                qs = PrimeNumberMath.PrimeGreaterOrEqual(dimensionCount);
                hisumSave = -1;
            }

            //  If SEED < 0, reset for recommended initial skip.
            int hisum;
            if (seed < 0)
            {
                hisum = 3;
                seed = (int)Math.Pow(qs, hisum + 1) - 1;
            }
            else if (seed == 0)
            {
                hisum = 0;
            }
            else
            {
                hisum = IntegerMath.Log(seed, qs);
            }

            //  Is it necessary to recompute the coefficient table?
            if (hisumSave != hisum)
            {
                hisumSave = hisum;
                coeff = Combinatorics.BinomialTableMod(qs, hisum);
                ytemp = new int[hisum + 1];
            }

            //  Find QUASI(1) using the method of Faure.
            //  SEED has a representation in base QS of the form: 
            //    Sum ( 0 <= J <= HISUM ) YTEMP(J) * QS**J
            //  We now compute the YTEMP(J)'s.

            int ktemp = (int)Math.Pow(qs, hisum + 1);
            int ltemp = seed;

            for (int i = hisum; 0 <= i; i--)
            {
                ktemp /= qs;
                int mtemp = ltemp % ktemp;
                ytemp[i] = (ltemp - mtemp) / ktemp;
                ltemp = mtemp;
            }

            //  QUASI(K) has the form
            //    Sum ( 0 <= J <= HISUM ) YTEMP(J) / QS**(J+1)
            //  Compute QUASI(1) using nested multiplication.

            double r = ytemp[hisum];
            for (int i = hisum - 1; 0 <= i; i--)
            {
                r = ytemp[i] + r / qs;
            }

            double[] quasi = new double[dimensionCount];
            quasi[0] = r / qs;

            //  Find components QUASI(2:DIM_NUM) using the Faure method.
            for (int k = 1; k < dimensionCount; k++)
            {
                quasi[k] = 0.0;
                r = 1.0 / qs;

                for (int j = 0; j <= hisum; j++)
                {
                    int ztemp = 0;
                    for (int i = j; i <= hisum; i++)
                    {
                        ztemp += ytemp[i] * coeff[i][j];
                    }

                    //  New YTEMP(J) is:
                    //    Sum ( J <= I <= HISUM ) ( old ytemp(i) * binom(i,j) ) mod QS.

                    ytemp[j] = ztemp % qs;
                    quasi[k] += ytemp[j] * r;
                    r /= qs;
                }
            }

            seed++;
            return quasi;
        }

        internal int CurrentSeed => seed;
    }
}
