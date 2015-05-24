using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Matrix3D
    {
        private readonly double[] _values;

        public Matrix3D()
        {
            _values = new double[9];

            for (var i = 0; i < 9; ++i)
                _values[i] = 0;
        }

        public Matrix3D(IReadOnlyList<int> rows, IReadOnlyList<int> columns, IReadOnlyList<double> values) : this()
        {
            if (rows.Count != columns.Count)
                throw new ArgumentException("count of rows and columns does not match");

            if (rows.Count != values.Count)
                throw new ArgumentException("count of rows and values does not match");

            var n = rows.Count;

            for (var i = 0; i < n; ++i)
                _values[CalculateIndex(rows[i], columns[i])] = values[i];
        }

        public double this[int row, int column]
        {
            get { return _values[CalculateIndex(row, column)]; }
            set { _values[CalculateIndex(row, column)] = value; }
        }

        public static Matrix3D Multiply(Matrix3D a, Matrix3D b)
        {
            var result = new Matrix3D();

            for (var row = 0; row < 3; ++row)
                for (var column = 0; column < 3; ++column)
                {
                    double partialResult = 0;

                    for (var i = 0; i < 3; ++i)
                        partialResult += a[row, i]*b[i, column];

                    result[row, column] = partialResult;
                }

            return result;
        }

        private static int CalculateIndex(int row, int column)
        {
            if (row < 0 || row > 2)
                throw new ArgumentException("invalid row");

            if (column < 0 || column > 2)
                throw new ArgumentException("invalid column");

            return row*3 + column;
        }
    }
}
