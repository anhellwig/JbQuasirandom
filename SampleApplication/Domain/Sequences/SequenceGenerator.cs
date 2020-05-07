using JbQuasirandom;
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

        public IList<Point> GeneratePoints(int dimensions, int count, int xDimension, int yDimension)
        {
            ISequence sequence = GetSequence(dimensions);
            List<Point> points = new List<Point>();
            for (int i = 0; i < count; i++)
            {
                double[] e = sequence.Next();
                points.Add(new Point(e[xDimension], e[yDimension]));
            }
            return points;
        }

        protected abstract ISequence GetSequence(int dimensions);
    }
}
