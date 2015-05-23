using Geometry;

namespace Graphics
{
    class BallToIcosahedron
    {
        private readonly Ball _ball;
        private readonly Icosahedron _icosahedron;

        public BallToIcosahedron(Ball ball)
        {
            _ball = ball;
            _icosahedron = new Icosahedron(Icosahedron.CalculateEdgeLengthFromOuterBallDiameter(ball.Diameter));
        }

        public Icosahedron Icosahedron
        {
            get { return _icosahedron; }
        }

        public void UpdatePose()
        {
            _icosahedron.Pose = _ball.Pose;
        }
    }
}
