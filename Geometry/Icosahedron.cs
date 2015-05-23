using System;

namespace Geometry
{
    public class Icosahedron
    {
        private readonly double _edgeLength;

        public Icosahedron(double edgeLength)
        {
            Pose = new Pose();
            _edgeLength = edgeLength;
        }

        public Pose Pose { get; set; }

        public double EdgeLength
        {
            get { return _edgeLength; }
        }

        public static double CalculateEdgeLengthFromOuterBallDiameter(double diameter)
        {
            return (2 * diameter) / (1 + Math.Sqrt(5));
        }
    }
}
