using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryTest
{
    [TestClass]
    public class PoseTest
    {
        [TestMethod]
        public void Constructor_Empty_PositionIsZero()
        {
            var pose = new Pose();

            Assert.IsTrue(new Position().Equals(pose.Position));
        }

        [TestMethod]
        public void Constructor_Empty_OrientationIsZero()
        {
            var pose = new Pose();

            Assert.IsTrue(new Orientation().Equals(pose.Orientation));
        }

        [TestMethod]
        public void Constructor_ValidPosition_PositionIsCorrect()
        {
            var position = new Position(1, 2, 3);
            var orientation = new Orientation(4, 5, 6);

            var pose = new Pose(position, orientation);

            Assert.IsTrue(position.Equals(pose.Position));
        }

        [TestMethod]
        public void Constructor_ValidPosition_OrientationIsCorrect()
        {
            var position = new Position(1, 2, 3);
            var orientation = new Orientation(4, 5, 6);

            var pose = new Pose(position, orientation);

            Assert.IsTrue(orientation.Equals(pose.Orientation));
        }

        [TestMethod]
        public void Equals_EqualValues_True()
        {
            var poseOne = new Pose(new Position(1, 2, 3), new Orientation(4, 5, 6));
            var poseTwo = new Pose(new Position(1, 2, 3), new Orientation(4, 5, 6));

            Assert.IsTrue(poseOne.Equals(poseTwo));
        }

        [TestMethod]
        public void Equals_DifferentPosition_False()
        {
            var poseOne = new Pose(new Position(1, 2, 3), new Orientation(4, 5, 6));
            var poseTwo = new Pose(new Position(2, 2, 3), new Orientation(4, 5, 6));

            Assert.IsFalse(poseOne.Equals(poseTwo));
        }

        [TestMethod]
        public void Equals_DifferentOrientation_False()
        {
            var poseOne = new Pose(new Position(1, 2, 3), new Orientation(4, 5, 6));
            var poseTwo = new Pose(new Position(1, 2, 3), new Orientation(2, 5, 6));

            Assert.IsFalse(poseOne.Equals(poseTwo));
        }

        [TestMethod]
        public void Equals_DifferentPositionAndOrientation_False()
        {
            var poseOne = new Pose(new Position(1, 6, 3), new Orientation(4, 5, 6));
            var poseTwo = new Pose(new Position(1, 2, 3), new Orientation(2, 5, 6));

            Assert.IsFalse(poseOne.Equals(poseTwo));
        }
    }
}
