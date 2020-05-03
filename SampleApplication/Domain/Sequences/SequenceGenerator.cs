using System.Collections.Generic;

namespace SampleApplication.Domain.Sequences
{
    public abstract class SequenceGenerator
    {
        public string Description { get; internal set; }

        public override string ToString()
        {
            return Description;
        }

        public abstract IList<Point> GeneratePoints(int dimensions, int count, int xDimension, int yDimension);
    }
}
