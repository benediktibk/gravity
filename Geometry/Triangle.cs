namespace Geometry
{
    public class Triangle
    {
        private readonly Position[] _vertices;

        public Triangle(Position p1, Position p2, Position p3)
        {
            _vertices = new[] { p1, p2, p3 };
        }

        public Position[] Vertices
        {
            get { return _vertices; }
        }
    }
}
