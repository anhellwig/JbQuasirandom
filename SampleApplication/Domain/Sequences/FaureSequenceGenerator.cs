using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class FaureSequenceGenerator : SequenceGenerator
    {
        public FaureSequenceGenerator()
        {
            Description = "Faure";
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new FaureSequence(dimensions);
        }
    }
}
