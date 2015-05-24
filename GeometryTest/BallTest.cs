using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void Constructor_5_PoseIsZero()
        {
            var ball = new Ball(5);

            Assert.IsTrue(new Pose().Equals(ball.Pose));
        }

        [TestMethod]
        public void Constructor_5_DiameterIs5()
        {
            var ball = new Ball(5);

            Assert.AreEqual(5, ball.Diameter);
        }
    }
}
