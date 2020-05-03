namespace JbQuasirandom.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class PrimeNumberMathTests
    {
        [Test]
        public void PrimeGreaterOrEqual_SampleValues_ReturnsExpectedValues()
        {
            int[] numbers = { -10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, PrimeNumberMath.Primes[^1] };
            int[] expected = { 2, 2, 2, 3, 5, 5, 7, 7, 11, 11, 11, PrimeNumberMath.Primes[^1] };
            var result = numbers.Select(PrimeNumberMath.PrimeGreaterOrEqual);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PrimeGreaterOrEqual_LargeValue_ReturnsNegativeMaximumPrime()
        {
            int maxPrime = PrimeNumberMath.Primes[^1];
            int result = PrimeNumberMath.PrimeGreaterOrEqual(2 * maxPrime);
            Assert.That(result, Is.EqualTo(-maxPrime));
        }
    }
}
