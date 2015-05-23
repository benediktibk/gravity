using System;
using Geometry;

namespace Graphics
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var display = new Display())
            {
                var ball = new Ball(1) {Pose = new Pose(new Position(0, 0, -1), new Orientation())};
                display.AddBall(ball);
                display.Run();
            }
        }
    }
}
