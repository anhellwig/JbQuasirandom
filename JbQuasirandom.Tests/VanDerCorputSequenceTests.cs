namespace JbQuasirandom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class VanDerCorputSequenceTests
    {
        private readonly double[] sequenceBase2 = { 0.0, 0.5, 0.25, 0.75, 0.125, 0.625, 0.375, 0.875, 0.0625, 0.5625, 0.3125, 0.8125 };
        private readonly double[] sequenceBase5 = { 0.0, 0.2, 0.4, 0.6, 0.8, 0.04, 0.24, 0.44, 0.64, 0.84, 0.08 };
        private readonly double[] sequenceBase10 = { 0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 0.01, 0.11, 0.21 };

        [Test]
        public void GetElement_PositiveNumber_ReturnsExpectedElement()
        {
            int index = 11;
            double result = VanDerCorputSequence.GetElement(index);
            Assert.That(result, Is.EqualTo(sequenceBase2[index]));
        }

        [Test]
        public void GetElement_PositiveNumberBase5_ReturnsExpectedElement()
        {
            int index = 7;
            double result = VanDerCorputSequence.GetElement(index, 5);
            Assert.That(result, Is.EqualTo(sequenceBase5[index]));
        }

        [Test]
        public void GetElement_PositiveNumberBase10_ReturnsExpectedElement()
        {
            int index = 11;
            double result = VanDerCorputSequence.GetElement(index, 10);
            Assert.That(result, Is.EqualTo(sequenceBase10[index]));
        }

        [Test]
        public void GetElement_NegativeNumber_ReturnsNegativeExpectedElement()
        {
            int index = 11;
            double result = VanDerCorputSequence.GetElement(-index);
            Assert.That(result, Is.EqualTo(-sequenceBase2[index]));
        }

        [Test]
        public void Inverse_BinaryVdcElement_ReturnsExpectedNumber()
        {
            int index = 10;
            int result = VanDerCorputSequence.Invert(sequenceBase2[index]);
            Assert.That(result, Is.EqualTo(index));
        }

        [Test]
        public void Inverse_IrrationalInput_OverflowException()
        {
            Assert.Throws<OverflowException>(() => VanDerCorputSequence.Invert(2.0 / Math.E));
        }

        [Test]
        public void GetNextElement_PositiveSeed_ReturnsExpectedElements()
        {
            int index = 6;
            VanDerCorputSequence vdc = new VanDerCorputSequence(index);
            double result1 = vdc.GetNextElement();
            double result2 = vdc.GetNextElement();
            Assert.That(result1, Is.EqualTo(sequenceBase2[index]));
            Assert.That(result2, Is.EqualTo(sequenceBase2[index + 1]));
        }

        [Test]
        public void GetNextElement_NegativeSeed_ReturnsExpectedElements()
        {
            int index = 6;
            VanDerCorputSequence vdc = new VanDerCorputSequence(-index);
            double result1 = vdc.GetNextElement();
            double result2 = vdc.GetNextElement();
            Assert.That(result1, Is.EqualTo(-sequenceBase2[index]));
            Assert.That(result2, Is.EqualTo(-sequenceBase2[index + 1]));
        }
    }
}
