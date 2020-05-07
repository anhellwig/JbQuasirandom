using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class HaltonSequenceGenerator : SequenceGenerator
    {
        public HaltonSequenceGenerator()
        {
            Description = "Halton";
            MaxDimensions = 1600;
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new HaltonSequence(dimensions);
        }
    }
}
