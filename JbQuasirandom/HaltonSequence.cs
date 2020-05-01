// original code: https://people.sc.fsu.edu/~jburkardt/cpp_src/halton/halton.cpp

namespace JbQuasirandom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Computes elements of the Halton sequence.</summary>
    public class HaltonSequence
    {
        private readonly int dimensionCount;
        private readonly VanDerCorputSequence[] vanDerCorputSequences;

        /// <summary>Initializes a new instance of the <see cref="HaltonSequence" /> class.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        public HaltonSequence(int dimensionCount) : this(dimensionCount, 0)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="HaltonSequence" /> class.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <param name="startIndex">The start index.</param>
        /// <exception cref="ArgumentException">Thrown when the specified index is negative.
        /// or
        /// The specified number of dimensions is less than 1.</exception>
        public HaltonSequence(int dimensionCount, int startIndex)
        {
            if (dimensionCount < 1)
            {
                throw new ArgumentException("The number of dimensions must be greater than zero.", nameof(dimensionCount));
            }
            if (startIndex < 0)
            {
                throw new ArgumentException("The index must not be negative.", nameof(startIndex));
            }
            this.dimensionCount = dimensionCount;
            vanDerCorputSequences = new VanDerCorputSequence[dimensionCount];
            for (int j = 0; j < dimensionCount; j++)
            {
                vanDerCorputSequences[j] = new VanDerCorputSequence(startIndex, PrimeNumberMath.Primes[j + 1]);
            }
        }

        /// <summary>Gets the next element of the sequence.</summary>
        /// <returns>The next element.</returns>
        /// <exception cref="OverflowException">Thrown when the number of elements has exceeded the maximum number of integers.</exception>
        public double[] GetNextElement()
        {
            double[] r = new double[dimensionCount];
            for (int j = 0; j < dimensionCount; j++)
            {
                r[j] = vanDerCorputSequences[j].GetNextElement();
            }
            return r;
        }

        /// <summary>Computes an element of a Halton sequence.</summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <param name="index">The index of the element.</param>
        /// <returns>The element of the sequence with the specified <paramref name="index"/> as array of length <paramref name="dimensionCount"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified index is negative.
        /// or
        /// The specified number of dimensions is less than 1.</exception>
        public static double[] GetElement(int dimensionCount, int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("The index must not be negative.", nameof(index));
            }
            if (dimensionCount < 1)
            {
                throw new ArgumentException("The number of dimensions must be larger than 0.", nameof(dimensionCount));
            }

            int[] t = new int[dimensionCount];
            for (int j = 0; j < dimensionCount; j++)
            {
                t[j] = index;
            }

            double[] primeInv = new double[dimensionCount];
            for (int j = 0; j < dimensionCount; j++)
            {
                primeInv[j] = 1.0 / PrimeNumberMath.Primes[j + 1];
            }

            double[] r = new double[dimensionCount];
            while (t.Sum() > 0)
            {
                for (int j = 0; j < dimensionCount; j++)
                {
                    int basePrime = PrimeNumberMath.Primes[j + 1];
                    r[j] += (t[j] % basePrime) * primeInv[j];
                    primeInv[j] /= basePrime;
                    t[j] /= basePrime;
                }
            }
            return r;
        }

        /// <summary>Gets the original index of an element of the Halton sequence.</summary>
        /// <param name="element">The element of the Halton sequence.</param>
        /// <returns>The corresponding index.</returns>
        /// <exception cref="OverflowException">Thrown when the resulting integer value is too large.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the specified element is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when the specified element does not contain any values.
        /// or
        /// A component is less than 0 or greater than or equal to 1.</exception>
        /// <remarks>Only the first component, assumed to be computed with base 2, is used for computing the index.</remarks>
        public static int Invert(IReadOnlyList<double> element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            if (element.Count == 0)
            {
                throw new ArgumentException("The element is empty.", nameof(element));
            }
            if (element.Any(c => c < 0.0 || c >= 1.0))
            {
                throw new ArgumentException("Each component must be >= 0 and < 1.", nameof(element));
            }

            // Invert using the first component only, because working with base 2 is accurate.
            return VanDerCorputSequence.Invert(element[0]);
        }
    }
}
