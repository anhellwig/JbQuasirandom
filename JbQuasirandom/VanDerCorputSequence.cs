// original code: https://people.sc.fsu.edu/~jburkardt/cpp_src/van_der_corput/van_der_corput.cpp

namespace JbQuasirandom
{
    using System;

    /// <summary>Computes elements of the van der Corput sequence.</summary>
    public class VanDerCorputSequence : ISequence
    {
        private readonly int sign = 1;
        private readonly int sequenceBase = 2;
        private int currentIndex = -1;

        /// <summary>Initializes a new instance of the <see cref="VanDerCorputSequence" /> class.</summary>
        public VanDerCorputSequence()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="VanDerCorputSequence" /> class. The resulting element has the same sign as the specified value.</summary>
        /// <param name="startIndex">The seed value.</param>
        public VanDerCorputSequence(int startIndex)
        {
            sign = (startIndex < 0) ? -1 : 1;
            currentIndex = startIndex - sign;
        }

        /// <summary>Initializes a new instance of the <see cref="VanDerCorputSequence" /> class.</summary>
        /// <param name="startIndex">The seed value.</param>
        /// <param name="b">The base of the sequence.</param>
        /// <exception cref="ArgumentException">Thrown when the base is less than 2.</exception>
        public VanDerCorputSequence(int startIndex, int b)
        {
            if (b < 2)
            {
                throw new ArgumentException("The base must be equal to or larger than 2.", nameof(b));
            }
            sign = (startIndex < 0) ? -1 : 1;
            currentIndex = startIndex - sign;
            sequenceBase = b;
        }

        /// <summary>Computes an element of the binary van der Corput sequence.</summary>
        /// <param name="index">An integer value.</param>
        /// <returns>The element of the van der Corput sequence.</returns>
        public static double GetElement(int index)
        {
            return GetElement(index, 2);
        }

        /// <summary>Computes an element of the van der Corput sequence in any base. The resulting element has the same sign as the specified value.</summary>
        /// <param name="index">An integer value.</param>
        /// <param name="b">The base to compute the sequence for.</param>
        /// <returns>The element of the van der Corput sequence.</returns>
        /// <exception cref="ArgumentException">Thrown when the base is less than 2.</exception>
        public static double GetElement(int index, int b)
        {
            if (b < 2)
            {
                throw new ArgumentException("The base must be equal to or larger than 2.", nameof(b));
            }

            double sign = (index < 0) ? -1.0 : 1.0;
            int t = Math.Abs(index);
            double baseInv = 1.0 / b;
            double r = 0.0;
            while (t != 0)
            {
                r += (t % b) * baseInv;
                baseInv /= b;
                t /= b;
            }

            return r * sign;
        }

        /// <summary>Gets the original index of an element of the binary van der Corput sequence.</summary>
        /// <param name="value">An element of the binary van der Corput sequence.</param>
        /// <returns>The corresponding index.</returns>
        /// <exception cref="ArgumentException">Thrown when the absolute value of a component is not less than 1.</exception>
        /// <exception cref="OverflowException">Thrown when the resulting integer value is too large.</exception>
        public static int Invert(double value)
        {
            if (Math.Abs(value) >= 1.0)
            {
                throw new ArgumentException("Absolute value must be less than 1.", nameof(value));
            }

            int sign = (value < 0.0) ? -1 : 1;
            double t = Math.Abs(value);
            int i = 0;
            int p = 1;
            checked
            {
                while (t != 0.0)
                {
                    t *= 2.0;
                    i += (int)t * p;
                    p *= 2;
                    t %= 1.0;
                }
            }
            return i * sign;
        }

        /// <summary>Gets the next element from the binary van der Corput sequence.</summary>
        /// <returns>The next element.</returns>
        /// <exception cref="OverflowException">Thrown when the number of elements has exceeded the maximum number of integers.</exception>
        public double GetNextElement()
        {
            checked
            {
                currentIndex += sign;
            }
            return GetElement(currentIndex, sequenceBase);
        }

        /// <inheritdoc />
        double[] ISequence.GetNextElement()
        {
            return new double[] { GetNextElement() };
        }
    }
}
