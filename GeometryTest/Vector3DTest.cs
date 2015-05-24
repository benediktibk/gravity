using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryTest
{
    [TestClass]
    public class Vector3DTest
    {
        [TestMethod]
        public void Constructor_Empty_AllValuesZero()
        {
            var vector = new Vector3D();

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        [TestMethod]
        public void Constructor_XYZ_AllValuesCorrect()
        {
            var vector = new Vector3D(1, 2, 3);

            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
            Assert.AreEqual(3, vector.Z);
        }

        [TestMethod]
        public void Constructor_Vector3D_AllValuesZero()
        {
            var vector = new Vector3D(1, 2, 3);
            var copy = new Vector3D(vector);

            Assert.AreEqual(1, copy.X);
            Assert.AreEqual(2, copy.Y);
            Assert.AreEqual(3, copy.Z);
        }

        [TestMethod]
        public void Equals_SameValues_True()
        {
            var vectorOne = new Vector3D(1, 2, 3);
            var vectorTwo = new Vector3D(1, 2, 3);

            Assert.IsTrue(vectorOne.Equals(vectorTwo));
        }

        [TestMethod]
        public void Equals_OneValueDifferent_False()
        {
            var vectorOne = new Vector3D(1, 2, 3);
            var vectorTwo = new Vector3D(10, 2, 3);

            Assert.IsFalse(vectorOne.Equals(vectorTwo));
        }

        [TestMethod]
        public void Add_TwoVectors_CorrectResult()
        {
            var vectorOne = new Vector3D(1, 2, 3);
            var vectorTwo = new Vector3D(4, 5, 6);

            var result = Vector3D.Add(vectorTwo, vectorOne);

            Assert.IsTrue(result.Equals(new Vector3D(5, 7, 9)));
        }

        [TestMethod]
        public void Subtract_TwoVectors_CorrectResult()
        {
            var vectorOne = new Vector3D(1, 2, 3);
            var vectorTwo = new Vector3D(47, 5, 62);

            var result = Vector3D.Subtract(vectorTwo, vectorOne);

            Assert.IsTrue(result.Equals(new Vector3D(46, 3, 59)));
        }
    }
}
