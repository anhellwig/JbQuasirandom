using JbQuasirandom;
using SampleApplication.Domain;
using System.Collections.Generic;

namespace SampleApplication.Applications.Sequences
{
    public class FaureSequenceModel : SequenceModelBase
    {
        public FaureSequenceModel()
        {
            Description = "Faure";
        }

        public override IList<Point> GeneratePoints(int dimensions, int count, int xDimension, int yDimension)
        {
            FaureSequence sequence = new FaureSequence(dimensions);
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
