using JbQuasirandom;

namespace SampleApplication.Domain.Sequences
{
    public class FaureSequenceGenerator : SequenceGenerator
    {
        public FaureSequenceGenerator()
        {
            Description = "Faure";
            MaxDimensions = 13499;
        }

        protected override ISequence GetSequence(int dimensions)
        {
            return new FaureSequence(dimensions);
        }
    }
}
