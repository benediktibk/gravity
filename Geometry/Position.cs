using System.Collections.Generic;

namespace Geometry
{
    public class Position : Vector3D
    {
        public Position()
        { }

        public Position(double x, double y, double z) :
            base(x, y, z)
        { }

        private Position(Vector3D position) :
            base(position)
        { }

        public static Position Add(Position a, Position b)
        {
            return new Position(Vector3D.Add(a, b));
        }
    }
}
