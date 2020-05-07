using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class HammersleySequenceGenerator : SequenceGenerator
    {
        public HammersleySequenceGenerator()
        {
            Description = "Hammersley";
            MaxDimensions = 1600;
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new HammersleySequence(dimensions, 16);
        }
    }
}
