namespace JbQuasirandom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SobolSequenceTests
    {
        // 4-dimensional test data from https://people.sc.fsu.edu/~jburkardt/cpp_src/sobol_test/sobol_test.txt
        private readonly double[][] expectedFromIndex0 = new double[][]
        {
            new double[] { 0.0, 0.0, 0.0, 0.0 },
            new double[] { 0.5, 0.5, 0.5, 0.5 },
            new double[] { 0.75, 0.25, 0.75, 0.25 },
            new double[] { 0.25, 0.75, 0.25, 0.75 },
            new double[] { 0.375, 0.375, 0.625, 0.125 },
            new double[] { 0.875, 0.875, 0.125, 0.625 },
            new double[] { 0.625, 0.125, 0.375, 0.375 },
            new double[] { 0.125, 0.625, 0.875, 0.875 },
            new double[] { 0.1875, 0.3125, 0.3125, 0.6875 },
            new double[] { 0.6875, 0.8125, 0.8125, 0.1875 },
            new double[] { 0.9375, 0.0625, 0.5625, 0.9375 },
            new double[] { 0.4375, 0.5625, 0.0625, 0.4375 }
        };
        private readonly double[][] expectedFromIndex95 = new double[][]
        {
            new double[] { 0.0546875, 0.929688, 0.101562, 0.960938 },
            new double[] { 0.0390625, 0.132812, 0.929688, 0.351562 },
            new double[] { 0.539062, 0.632812, 0.429688, 0.851562 },
            new double[] { 0.789062, 0.382812, 0.179688, 0.101562 },
            new double[] { 0.289062, 0.882812, 0.679688, 0.601562 },
            new double[] { 0.414062, 0.257812, 0.304688, 0.476562 },
            new double[] { 0.914062, 0.757812, 0.804688, 0.976562 },
            new double[] { 0.664062, 0.0078125, 0.554688, 0.226562 },
            new double[] { 0.164062, 0.507812, 0.0546875, 0.726562 },
            new double[] { 0.226562, 0.445312, 0.742188, 0.914062 },
            new double[] { 0.726562, 0.945312, 0.242188, 0.414062 },
            new double[] { 0.976562, 0.195312, 0.492188, 0.664062 },
            new double[] { 0.476562, 0.695312, 0.992188, 0.164062 },
            new double[] { 0.351562, 0.0703125, 0.117188, 0.789062 },
            new double[] { 0.851562, 0.570312, 0.617188, 0.289062 },
            new double[] { 0.601562, 0.320312, 0.867188, 0.539062 }
        };

        [Test]
        public void GetNextElement_4DZeroSeed_ReturnsExpectedSequence()
        {
            SobolSequence sobol = new SobolSequence(4);
            int count = 12;

            for (int i = 0; i < count; i++)
            {
                var element = sobol.GetNextElement();
                Assert.That(element, Is.EqualTo(expectedFromIndex0[i]));
            }

            // fast-forward to index 95
            for (int i = count; i < 95; i++)
            {
                sobol.GetNextElement();
            }

            count = 16;
            for (int i = 0; i < count; i++)
            {
                var element = sobol.GetNextElement();
                Assert.That(element, Is.EqualTo(expectedFromIndex95[i]).Within(6E-7));
            }
        }

        [Test]
        public void GetNextElement_4DNonzeroSeed_ReturnsExpectedSequence()
        {
            SobolSequence sobol = new SobolSequence(4, 95);
            int count = 16;
            for (int i = 0; i < count; i++)
            {
                var element = sobol.GetNextElement();
                Assert.That(element, Is.EqualTo(expectedFromIndex95[i]).Within(6E-7));
            }
        }

        [Test]
        public void Constructor_InvalidDimensions_Throws()
        {
            Assert.That(() => new SobolSequence(-1), Throws.ArgumentException);
            Assert.That(() => new SobolSequence(0), Throws.ArgumentException);
            Assert.That(() => new SobolSequence(1112), Throws.ArgumentException);
        }
    }
}
