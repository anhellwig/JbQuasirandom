using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class SobolSequenceGenerator : SequenceGenerator
    {
        public SobolSequenceGenerator()
        {
            Description = "Sobol";
            MaxDimensions = 1111;
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new SobolSequence(dimensions);
        }
    }
}
