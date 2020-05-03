namespace JbQuasirandom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CombinatoricsTests
    {
        [Test]
        public void BinomialTableMod_ReturnsExpectedSampleValues()
        {
            // test similar to https://people.sc.fsu.edu/~jburkardt/cpp_src/faure_test/faure_test.cpp

            int[][] expectedCoefficients = new int[][]
            {
                new int[] { 1 },
                new int[] { 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] { 1, 3, 3, 1 },
                new int[] { 1, 4, 6, 4, 1 },
                new int[] { 1, 5, 3, 3, 5, 1 },
                new int[] { 1, 6, 1, 6, 1, 6, 1 },
                new int[] { 1, 0, 0, 0, 0, 0, 0, 1 },
                new int[] { 1, 1, 0, 0, 0, 0, 0, 1, 1 }
            };

            int upperIndex = 8;
            int modulo = 7;
            int[][] result = Combinatorics.BinomialTableMod(modulo, upperIndex);
            Assert.That(result, Is.EqualTo(expectedCoefficients));
        }
    }
}
