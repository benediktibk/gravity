using System.Collections.Generic;

namespace Geometry
{
    public class Vector3D
    {
        private readonly double[] _directions;

        public Vector3D()
        {
            _directions = new double[] {0, 0, 0};
        }

        public Vector3D(double x, double y, double z)
        {
            _directions = new[] {x, y, z};
        }

        public double X
        {
            get { return _directions[0]; }
        }

        public double Y
        {
            get { return _directions[1]; }
        }

        public double Z
        {
            get { return _directions[2]; }
        }
    }
}