using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class Icosahedron
    {
        private readonly double _edgeLength;
        private static readonly double GoldenRatio = (1 + Math.Sqrt(5))/2;

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
            return diameter / GoldenRatio;
        }

        public IReadOnlyList<Triangle> CreateFaces()
        {
            var b = EdgeLength/2;
            var a = b * GoldenRatio;
            var verticesWithoutOffsets = new Position[12];
            verticesWithoutOffsets[0] = new Position(0, b, a);
            verticesWithoutOffsets[1] = new Position(0, (-1)*b, a);
            verticesWithoutOffsets[2] = new Position(0, b, (-1)*a);
            verticesWithoutOffsets[3] = new Position(0, (-1)*b, (-1)*a);
            verticesWithoutOffsets[4] = new Position(b, a, 0);
            verticesWithoutOffsets[5] = new Position((-1)*b, a, 0);
            verticesWithoutOffsets[6] = new Position(b, (-1)*a, 0);
            verticesWithoutOffsets[7] = new Position((-1)*b, (-1)*a, 0);
            verticesWithoutOffsets[8] = new Position(a, 0, b);
            verticesWithoutOffsets[9] = new Position(a, 0, (-1)*b);
            verticesWithoutOffsets[10] = new Position((-1)*a, 0, b);
            verticesWithoutOffsets[11] = new Position((-1)*a, 0, (-1)*b);

            var vertices = verticesWithoutOffsets.Select(vertex => Position.Add(Pose.Position, vertex)).ToList();

            var faces = new Triangle[20];
            faces[0] = new Triangle(vertices[2], vertices[4], vertices[5]);
            faces[1] = new Triangle(vertices[0], vertices[5], vertices[4]);
            faces[2] = new Triangle(vertices[0], vertices[1], vertices[10]);
            faces[3] = new Triangle(vertices[0], vertices[8], vertices[1]);
            faces[4] = new Triangle(vertices[2], vertices[3], vertices[9]);
            faces[5] = new Triangle(vertices[2], vertices[11], vertices[3]);
            faces[6] = new Triangle(vertices[1], vertices[6], vertices[7]);
            faces[7] = new Triangle(vertices[3], vertices[7], vertices[6]);
            faces[8] = new Triangle(vertices[5], vertices[10], vertices[11]);
            faces[9] = new Triangle(vertices[7], vertices[11], vertices[10]);
            faces[10] = new Triangle(vertices[4], vertices[9], vertices[8]);
            faces[11] = new Triangle(vertices[6], vertices[8], vertices[9]);
            faces[12] = new Triangle(vertices[0], vertices[10], vertices[5]);
            faces[13] = new Triangle(vertices[0], vertices[4], vertices[8]);
            faces[14] = new Triangle(vertices[2], vertices[5], vertices[11]);
            faces[15] = new Triangle(vertices[2], vertices[9], vertices[4]);
            faces[16] = new Triangle(vertices[3], vertices[11], vertices[7]);
            faces[17] = new Triangle(vertices[3], vertices[6], vertices[9]);
            faces[18] = new Triangle(vertices[1], vertices[7], vertices[10]);
            faces[19] = new Triangle(vertices[1], vertices[8], vertices[6]);

            return faces;
        }
    }
}
