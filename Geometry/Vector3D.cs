using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Vector3D : IEquatable<Vector3D>
    {
        private readonly double[] _values;

        public Vector3D()
        {
            _values = new double[] {0, 0, 0};
        }

        public Vector3D(double x, double y, double z)
        {
            _values = new[] {x, y, z};
        }

        public Vector3D(Vector3D vector)
        {
            _values = new double[3];

            for (var i = 0; i < 3; ++i)
                _values[i] = vector.Values[i];
        }

        private Vector3D(double[] values)
        {
            _values = values;
        }

        public double X
        {
            get { return _values[0]; }
        }

        public double Y
        {
            get { return _values[1]; }
        }

        public double Z
        {
            get { return _values[2]; }
        }

        public IReadOnlyList<double> Values
        {
            get { return _values; }
        }

        public static Vector3D Add(Vector3D a, Vector3D b)
        {
            var values = new double[3];

            for (var i = 0; i < 3; i++)
                values[i] = a.Values[i] + b.Values[i];

            return new Vector3D(values);
        }

        public static Vector3D Subtract(Vector3D a, Vector3D b)
        {
            var values = new double[3];

            for (var i = 0; i < 3; i++)
                values[i] = a.Values[i] - b.Values[i];

            return new Vector3D(values);
        }

        public bool Equals(Vector3D other)
        {
            return  X == other.X && 
                    Y == other.Y && 
                    Z == other.Z;
        }
    }
}