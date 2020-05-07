namespace JbQuasirandom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class HammersleySequenceTests
    {
        // test data from https://people.sc.fsu.edu/~jburkardt/c_src/hammersley_test/hammersley_test.html
        private readonly double[][] hammersleySequence3DBase16 =
        {
            new double[] { 0.0, 0.0, 0.0 },
            new double[] { 0.0625, 0.5, 0.333333 },
            new double[] { 0.125, 0.25, 0.666667 },
            new double[] { 0.1875, 0.75, 0.111111 },
            new double[] { 0.25, 0.125, 0.444444 },
            new double[] { 0.3125, 0.625, 0.777778 },
            new double[] { 0.375, 0.375, 0.222222 },
            new double[] { 0.4375, 0.875, 0.555556 },
            new double[] { 0.5, 0.0625, 0.888889 },
            new double[] { 0.5625, 0.5625, 0.037037 },
            new double[] { 0.625, 0.3125, 0.37037 }
        };

        [Test]
        public void GetElement_3DNonzeroIndex_ReturnsExpectedElement()
        {
            int index = 10;
            double[] result = HammersleySequence.GetElement(3, 16, index);
            Assert.That(result, Is.EqualTo(hammersleySequence3DBase16[index]).Within(6E-7));
        }

        [Test]
        public void Next_3DZeroSeed_ReturnsExpectedSequence()
        {
            int count = 11;
            HammersleySequence sequence = new HammersleySequence(3, 16);
            double[][] result = new double[count][];
            for (int i = 0; i < count; i++)
            {
                result[i] = sequence.Next();
            }
            Assert.That(result, Is.EqualTo(hammersleySequence3DBase16).Within(6E-7));
        }

        [Test]
        public void Invert_NonzeroIndex_ReturnsExpectedIndex()
        {
            int index = 7;
            int result = HammersleySequence.Invert(hammersleySequence3DBase16[index], 16);
            Assert.That(result, Is.EqualTo(index));
        }

        [Test]
        public void Invert_ElementIsNull_Throws()
        {
            Assert.That(() => HammersleySequence.Invert(null, 16), Throws.ArgumentNullException);
        }

        [Test]
        public void Invert_EmptyElement_Throws()
        {
            Assert.That(() => HammersleySequence.Invert(new double[0], 16), Throws.ArgumentException);
        }

        [Test]
        public void Invert_InvalidBase_Throws()
        {
            Assert.That(() => HammersleySequence.Invert(hammersleySequence3DBase16[1], 0), Throws.ArgumentException);
        }

        [Test]
        public void Invert_ValuesTooLarge_Throws()
        {
            Assert.That(() => HammersleySequence.Invert(new double[] { 2.0, 4.0, 8.0 }, 0), Throws.ArgumentException);
        }

        [Test]
        public void Invert_NonrationalNumber_Overflows()
        {
            Assert.That(() => HammersleySequence.Invert(new double[] { 1.0 / Math.PI, 1.0 / Math.E }, 16), Throws.TypeOf<OverflowException>());
        }

        [Test]
        public void GetElement_InvalidIndex_Throws()
        {
            Assert.That(() => HammersleySequence.GetElement(1, 16, -1), Throws.ArgumentException);
        }

        [Test]
        public void GetElement_InvalidBase_Throws()
        {
            Assert.That(() => HammersleySequence.GetElement(1, 0, 0), Throws.ArgumentException);
        }

        [Test]
        public void GetElement_InvalidDimensions_Throws()
        {
            Assert.That(() => HammersleySequence.GetElement(0, 16, 0), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_InvalidIndex_Throws()
        {
            Assert.That(() => new HammersleySequence(1, 16, -1), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_InvalidBase_Throws()
        {
            Assert.That(() => HammersleySequence.GetElement(1, 0, 0), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_InvalidDimensions_Throws()
        {
            Assert.That(() => HammersleySequence.GetElement(1, 16, -1), Throws.ArgumentException);
        }
    }
}
