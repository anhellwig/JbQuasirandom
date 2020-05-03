using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class HaltonSequenceGenerator : SequenceGenerator
    {
        public HaltonSequenceGenerator()
        {
            Description = "Halton";
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new HaltonSequence(dimensions);
        }
    }
}
