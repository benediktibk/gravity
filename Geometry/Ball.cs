namespace Geometry
{
    public class Ball
    {
        private readonly double _diameter;

        public Ball(double diameter)
        {
            Pose = new Pose();
            _diameter = diameter;
        }

        public Pose Pose { get; set; }

        public double Diameter
        {
            get { return _diameter; }
        }
    }
}
