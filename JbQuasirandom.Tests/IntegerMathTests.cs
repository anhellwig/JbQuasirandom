namespace JbQuasirandom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class IntegerMathTests
    {
        [Test]
        public void Log()
        {
            int[][] expected = new int[][]
            {
                new int[] { 0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3 }, // base 2
                new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2 }, // base 3
                new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 }, // base 4
                new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 }  // base 5
            };
            for (int b = 2; b <= 5; b++)
            {
                var result = Enumerable.Range(0, 11).Select(i => IntegerMath.Log(i, b));
                var expectedNumbers = expected[b - 2];
                Assert.That(result, Is.EqualTo(expectedNumbers));
            }
        }
    }
}
