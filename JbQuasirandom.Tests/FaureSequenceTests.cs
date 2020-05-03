namespace JbQuasirandom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class FaureSequenceTests
    {
        // test data from https://people.sc.fsu.edu/~jburkardt/cpp_src/faure_test/faure_test.txt
        private readonly double[][] expected2D = new double[][]
        {
            new double[] { 0.9375, 0.0625 },
            new double[] { 0.03125, 0.53125 },
            new double[] { 0.53125, 0.03125 },
            new double[] { 0.28125, 0.28125 },
            new double[] { 0.78125, 0.78125 },
            new double[] { 0.15625, 0.15625 },
            new double[] { 0.65625, 0.65625 },
            new double[] { 0.40625, 0.90625 },
            new double[] { 0.90625, 0.40625 },
            new double[] { 0.09375, 0.46875 }
        };
        private readonly double[][] expected3D = new double[][]
        {
            new double[] { 0.987654, 0.765432, 0.209877 },
            new double[] { 0.00411523, 0.460905, 0.584362 },
            new double[] { 0.337449, 0.794239, 0.917695 },
            new double[] { 0.670782, 0.127572, 0.251029 },
            new double[] { 0.115226, 0.90535, 0.0288066 },
            new double[] { 0.44856, 0.238683, 0.36214 },
            new double[] { 0.781893, 0.572016, 0.695473 },
            new double[] { 0.226337, 0.0164609, 0.806584 },
            new double[] { 0.559671, 0.349794, 0.139918 },
            new double[] { 0.893004, 0.683128, 0.473251 }
        };
        private readonly double[][] expected4D = new double[][]
        {
            new double[] { 0.9984,  0.3744,  0.1504,  0.0464 },
            new double[] { 0.00032, 0.37472, 0.31712, 0.35552 },
            new double[] { 0.20032, 0.57472, 0.51712, 0.55552 },
            new double[] { 0.40032, 0.77472, 0.71712, 0.75552 },
            new double[] { 0.60032, 0.97472, 0.91712, 0.95552 },
            new double[] { 0.80032, 0.17472, 0.11712, 0.15552 },
            new double[] { 0.04032, 0.41472, 0.75712, 0.99552 },
            new double[] { 0.24032, 0.61472, 0.95712, 0.19552 },
            new double[] { 0.44032, 0.81472, 0.15712, 0.39552 },
            new double[] { 0.64032, 0.01472, 0.35712, 0.59552 }
        };

        [Test]
        public void GetNextElement_2D_ReturnsExpectedElementsAndSeeds()
        {
            FaureSequence faure = new FaureSequence(2);

            var element = faure.GetNextElement();
            int seed = faure.CurrentSeed;
            Assert.That(seed, Is.EqualTo(16));
            Assert.That(element, Is.EqualTo(expected2D[0]).Within(6E-7));

            element = faure.GetNextElement();
            seed = faure.CurrentSeed;
            Assert.That(seed, Is.EqualTo(17));
            Assert.That(element, Is.EqualTo(expected2D[1]).Within(6E-7));
        }

        [Test]
        public void GetNextElement_3D_ReturnsExpectedElementsAndSeeds()
        {
            FaureSequence faure = new FaureSequence(3);

            var element = faure.GetNextElement();
            int seed = faure.CurrentSeed;
            Assert.That(seed, Is.EqualTo(81));
            Assert.That(element, Is.EqualTo(expected3D[0]).Within(6E-7));

            element = faure.GetNextElement();
            seed = faure.CurrentSeed;
            Assert.That(seed, Is.EqualTo(82));
            Assert.That(element, Is.EqualTo(expected3D[1]).Within(6E-7));
        }

        [Test]
        public void GetNextElement_4D_ReturnsExpectedElementsAndSeeds()
        {
            FaureSequence faure = new FaureSequence(4);

            var element = faure.GetNextElement();
            int seed = faure.CurrentSeed;
            Assert.That(seed, Is.EqualTo(625));
            Assert.That(element, Is.EqualTo(expected4D[0]).Within(6E-7));

            element = faure.GetNextElement();
            seed = faure.CurrentSeed;
            Assert.That(seed, Is.EqualTo(626));
            Assert.That(element, Is.EqualTo(expected4D[1]).Within(6E-7));
        }
    }
}
