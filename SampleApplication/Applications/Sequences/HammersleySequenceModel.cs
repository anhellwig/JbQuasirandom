using JbQuasirandom;
using SampleApplication.Domain;
using System.Collections.Generic;

namespace SampleApplication.Applications.Sequences
{
    public class HammersleySequenceModel : SequenceModelBase
    {
        public HammersleySequenceModel()
        {
            Description = "Hammersley";
        }

        public override IList<Point> GeneratePoints(int dimensions, int count, int xDimension, int yDimension)
        {
            HammersleySequence sequence = new HammersleySequence(dimensions, 16);
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
