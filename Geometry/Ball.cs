using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Ball
    {
        private readonly double _diameter;

        public Ball(double diameter)
        {
            Pose = new Pose();
            _diameter = 0;
        }

        public Pose Pose { get; set; }

        public double Diameter
        {
            get { return _diameter; }
        }
    }
}
