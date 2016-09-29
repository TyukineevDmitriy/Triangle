using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByThreeSides_NegativeSide_ThrowArgumentException()
        {
            double goodSide = 5;
            double badSide = -10;
            Triangle.CreateByThreeSides(goodSide, goodSide, badSide);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateByTwoSidesAndAngle_AngleIsGreaterThan180_ThrowArgumentException()
        {
            double goodSide = 5;
            double badAngle = 190;
            Triangle.CreateByTwoSidesAndAngle(goodSide, goodSide, badAngle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBySideAndTwoAngle_SumOfAnglesIsGreaterThan180_ThrowArgumentException()
        {
            double goodSide = 5;
            double badAngle = 95;
            Triangle.CreateBySideAndTwoAngle(goodSide, badAngle, badAngle);
        }

        [TestMethod]
        public void GetArea_GoodSides_ReturnAreaEquals6()
        {
            double firstSide = 3;
            double secondSide = 4;
            double thirdSide = 5;
            Triangle triangle = Triangle.CreateByThreeSides(firstSide, secondSide, thirdSide);
            Assert.AreEqual(triangle.GetArea(), 6);
        }

        [TestMethod]
        public void GetArea_GoodSidesAndAngle_ReturnAreaEquals6()
        {
            double firstSide = 3;
            double secondSide = 4;
            double angle = 90;
            Triangle triangle = Triangle.CreateByTwoSidesAndAngle(firstSide, secondSide, angle);
            Assert.AreEqual(triangle.GetArea(), 6);
        }

        [TestMethod]
        public void GetArea_GoodSideAndAngles_ReturnAreaEquals12p25()
        {
            double side = 7;
            double firstAngle = 45;
            double secondAngle = 45;
            Triangle triangle = Triangle.CreateBySideAndTwoAngle(side, firstAngle, secondAngle);
            Assert.AreEqual(triangle.GetArea(), 12.25, 0.001);
        }
    }
}
