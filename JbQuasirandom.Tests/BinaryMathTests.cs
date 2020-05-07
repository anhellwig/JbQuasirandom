namespace JbQuasirandom.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class BinaryMathTests
    {
        // test data from https://people.sc.fsu.edu/~jburkardt/cpp_src/sobol_test/sobol_test.txt
        private readonly long[] numbers = { 22, 96, 83, 56, 41, 6, 26, 11, 4, 64 };
        private readonly int[] expectedHigh1Bits = { 5, 7, 7, 6, 6, 3, 5, 4, 3, 7 };
        private readonly int[] expectedLow0Bits = { 1, 1, 3, 1, 2, 1, 1, 3, 1, 1 };

        [Test]
        public void GetMostSignificant1BitPosition_SampleValues_ReturnsExpectedBitPosition()
        {
            var result = numbers.Select(i => BinaryMath.GetMostSignificant1BitPosition(i));
            Assert.That(result, Is.EqualTo(expectedHigh1Bits));
        }

        [Test]
        public void GetLeastSignificant0BitPosition_SampleValues_ReturnsExpectedBitPosition()
        {
            var result = numbers.Select(i => BinaryMath.GetLeastSignificant0BitPosition(i));
            Assert.That(result, Is.EqualTo(expectedLow0Bits));
        }
    }
}
