using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Triangle
    {
        private readonly Position[] _corners;

        public Triangle(Position p1, Position p2, Position p3)
        {
            _corners = new[] { p1, p2, p3 };
        }

        public Position[] Corners
        {
            get { return _corners; }
        }
    }
}
