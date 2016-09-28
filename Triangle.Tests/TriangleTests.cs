using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Tests
{
    [TestClass]
    public class TriangleTets
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByThreeSides_NegativeSide_ThrowArgumentException()
        {
            Triangle.CreateByThreeSides(5, 6, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByTwoSidesAndAngle_AngleIsGreaterThan180_ThrowArgumentException()
        {
            Triangle.CreateByTwoSidesAndAngle(5, 6, 190);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBySideAndTwoAngle_SumOfAnglesIsGreaterThan180_ThrowArgumentException()
        {
            Triangle.CreateBySideAndTwoAngle(5, 150, 40);
        }

        [TestMethod]
        public void GetArea_SidesAre_3_And_4_And_5_ReturnAreaEquals6()
        {
            Triangle triangle = Triangle.CreateByThreeSides(3, 4, 5);
            Assert.AreEqual(triangle.GetArea(), 6);
        }

        [TestMethod]
        public void GetArea_SidesAre_3_And_4_AngleIs90_ReturnAreaEquals6()
        {
            Triangle triangle = Triangle.CreateByTwoSidesAndAngle(3, 4, 90);
            Assert.AreEqual(triangle.GetArea(), 6);
        }

        [TestMethod]
        public void GetArea_SideIs7_AnglesAre_60_And_60_ReturnAreaEquals12_Point_25()
        {
            Triangle triangle = Triangle.CreateBySideAndTwoAngle(7, 45, 45);
            Assert.AreEqual(triangle.GetArea(), 12.25, 0.001);
        }
    }
}
