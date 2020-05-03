using JbQuasirandom;
using System.Collections.Generic;

namespace SampleApplication.Domain.Sequences
{
    public class SobolSequenceGenerator : SequenceGenerator
    {
        public SobolSequenceGenerator()
        {
            Description = "Sobol";
        }

        public override IList<Point> GeneratePoints(int dimensions, int count, int xDimension, int yDimension)
        {
            SobolSequence sequence = new SobolSequence(dimensions);
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
