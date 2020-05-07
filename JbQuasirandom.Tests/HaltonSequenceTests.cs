namespace JbQuasirandom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HaltonSequenceTests
    {
        // test data from https://people.sc.fsu.edu/~jburkardt/cpp_src/halton_test/halton_test.txt
        private readonly double[][] sequence3D =
        {
            new double[] { 0.0, 0.0, 0.0 },
            new double[] { 0.5, 0.333333, 0.2 },
            new double[] { 0.25, 0.666667, 0.4 },
            new double[] { 0.75, 0.111111, 0.6 },
            new double[] { 0.125, 0.444444, 0.8 },
            new double[] { 0.625, 0.777778, 0.04 },
            new double[] { 0.375, 0.222222, 0.24 },
            new double[] { 0.875, 0.555556, 0.44 },
            new double[] { 0.0625, 0.888889, 0.64 },
            new double[] { 0.5625, 0.037037, 0.84 },
            new double[] { 0.3125, 0.37037, 0.08 }
        };

        [Test]
        public void GetElement_1DNonzeroIndex_ReturnsExpectedElement()
        {
            int index = 10;
            double[] expected = { sequence3D[index][0] };
            double[] result = HaltonSequence.GetElement(1, index);
            Assert.That(result, Is.EqualTo(expected).Within(5E-6));
        }

        [Test]
        public void GetElement_2DNonzeroIndex_ReturnsExpectedElement()
        {
            int index = 10;
            double[] expected = { sequence3D[index][0], sequence3D[index][1] };
            double[] result = HaltonSequence.GetElement(2, index);
            Assert.That(result, Is.EqualTo(expected).Within(5E-6));
        }

        [Test]
        public void GetElement_3DNonzeroIndex_ReturnsExpectedElement()
        {
            int index = 10;
            double[] expected = sequence3D[index];
            double[] result = HaltonSequence.GetElement(3, index);
            Assert.That(result, Is.EqualTo(expected).Within(5E-6));
        }

        [Test]
        public void Next_3DNonzeroSeed_ReturnsExpectedElement()
        {
            int index = 6;
            double[] expected1 = sequence3D[index];
            double[] expected2 = sequence3D[index + 1];
            HaltonSequence halton = new HaltonSequence(3, index);
            var result1 = halton.Next();
            var result2 = halton.Next();
            Assert.That(result1, Is.EqualTo(expected1).Within(5E-6));
            Assert.That(result2, Is.EqualTo(expected2).Within(5E-6));
        }

        [Test]
        public void GetElement_InvalidIndex_Throws()
        {
            Assert.That(() => HaltonSequence.GetElement(-1, 1), Throws.ArgumentException);
        }

        [Test]
        public void GetElement_InvalidDimensions_Throws()
        {
            Assert.That(() => HaltonSequence.GetElement(0, 0), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_InvalidIndex_Throws()
        {
            Assert.That(() => new HaltonSequence(1, -1), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_InvalidDimensions_Throws()
        {
            Assert.That(() => new HaltonSequence(0), Throws.ArgumentException);
        }
    }
}
