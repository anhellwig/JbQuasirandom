using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class SobolSequenceGenerator : SequenceGenerator
    {
        public SobolSequenceGenerator()
        {
            Description = "Sobol";
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new SobolSequence(dimensions);
        }
    }
}
