// original code: https://people.sc.fsu.edu/~jburkardt/cpp_src/hammersley/hammersley.cpp

namespace JbQuasirandom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Computes elements of the Hammersley sequence.</summary>
    public class HammersleySequence : ISequence
    {
        private readonly int dimensionCount;
        private readonly int b;
        private int currentIndex;

        /// <summary>Initializes a new instance of the <see cref="HammersleySequence" /> class.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <param name="b">The base.</param>
        /// <exception cref="ArgumentException">Thrown when the specified number of dimensions is less than one.
        /// or
        /// The specified base is less than one.</exception>
        public HammersleySequence(int dimensionCount, int b) : this(dimensionCount, b, 0)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="HammersleySequence" /> class.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <param name="b">The base.</param>
        /// <param name="startIndex">The start index. A value of 0 is assumed when a negative number is given.</param>
        /// <exception cref="ArgumentException">Thrown when the specified index is negative.
        /// or
        /// The specified number of dimensions is less than one.
        /// or
        /// The specified base is less than one.</exception>
        public HammersleySequence(int dimensionCount, int b, int startIndex)
        {
            if (startIndex < 0)
            {
                throw new ArgumentException("Index must not be negative.", nameof(startIndex));
            }
            if (dimensionCount < 1)
            {
                throw new ArgumentException("The number of dimensions must be greater than zero.", nameof(dimensionCount));
            }
            if (b < 1)
            {
                throw new ArgumentException("The base must be greater than zero.", nameof(b));
            }
            this.dimensionCount = dimensionCount;
            this.b = b;
            currentIndex = startIndex - 1;
        }

        /// <summary>Gets the next element.</summary>
        /// <returns></returns>
        public double[] Next()
        {
            currentIndex++;
            return GetElement(dimensionCount, b, currentIndex);
        }

        /// <summary>Gets the element of the Hammersley sequence at the specified index.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <param name="b">The base for the first component.</param>
        /// <param name="index">The index.</param>
        /// <returns>The element of the Hammersley sequence.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified index is negative.
        /// or
        /// The specified number of dimensions is less than 1.
        /// or
        /// The specified base is less than 1.</exception>
        public static double[] GetElement(int dimensionCount, int b, int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index must not be negative.", nameof(index));
            }
            if (dimensionCount < 1)
            {
                throw new ArgumentException("The number of dimensions must be greater than zero.", nameof(dimensionCount));
            }
            if (b < 1)
            {
                throw new ArgumentException("The base must be greater than zero.", nameof(b));
            }

            int[] t = new int[dimensionCount];
            t[0] = 0;
            for (int j = 1; j < dimensionCount; j++)
            {
                t[j] = index;
            }

            double[] primeInv = new double[dimensionCount];
            for (int j = 0; j < dimensionCount; j++)
            {
                primeInv[j] = 1.0 / PrimeNumberMath.Primes[j];
            }

            double[] r = new double[dimensionCount];
            r[0] = (double)(index % (b + 1)) / b;
            for (int j = 1; j < dimensionCount; j++)
            {
                r[j] = 0.0;
            }

            while (t.Sum() > 0)
            {
                for (int j = 1; j < dimensionCount; j++)
                {
                    int basePrime = PrimeNumberMath.Primes[j];
                    r[j] += (t[j] % basePrime) * primeInv[j];
                    primeInv[j] /= basePrime;
                    t[j] /= basePrime;
                }
            }

            return r;
        }

        /// <summary>Gets the original index of an element of the Hammersley sequence.</summary>
        /// <param name="element">The element.</param>
        /// <param name="b">The base.</param>
        /// <returns>The original index.</returns>
        /// <exception cref="OverflowException">Thrown when the resulting integer value is too large.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the specified element is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when the specified element does not contain any values or a component is less than 0 or greater than 1.
        /// or
        /// The specified base is less than 1.</exception>
        public static int Invert(IReadOnlyList<double> element, int b)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            int dimensions = element.Count;
            if (dimensions == 0)
            {
                throw new ArgumentException("The element is empty.", nameof(element));
            }
            for (int j = 0; j < dimensions; j++)
            {
                if (element[j] < 0.0 || 1.0 < element[j])
                {
                    throw new ArgumentException("Each component must be >= 0 and <= 1.", nameof(element));
                }
            }
            if (b < 1)
            {
                throw new ArgumentException("The base must be greater than zero.", nameof(b));
            }

            if (dimensions >= 2)
            {
                //  Invert using the second component only, because working with base 2 is accurate.
                int i = 0;
                double t = element[1];
                int p = 1;
                checked
                {
                    while (t != 0.0)
                    {
                        t *= 2.0;
                        int d = (int)t;
                        i += d * p;
                        p *= 2;
                        t -= d;
                    }
                }
                return i;
            }
            return (int)(Math.Round(b * element[0]));
        }
    }
}
