using JbQuasirandom;
using System.Collections.Generic;

namespace SampleApplication.Domain.Sequences
{
    public class HaltonSequenceGenerator : SequenceGenerator
    {
        public HaltonSequenceGenerator()
        {
            Description = "Halton";
        }

        public override IList<Point> GeneratePoints(int dimensions, int count, int xDimension, int yDimension)
        {
            HaltonSequence sequence = new HaltonSequence(dimensions);
            List<Point> points = new List<Point>();
            for (int i = 0; i < count; i++)
            {
                double[] e = sequence.GetNextElement();
                points.Add(new Point(e[xDimension], e[yDimension]));
            }
            return points;
        }
    }
}
