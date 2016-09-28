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
            double firstAngle = 150;
            double secondAngle = 40;
            Triangle.CreateBySideAndTwoAngle(goodSide, firstAngle, secondAngle);
        }

        [TestMethod]
        public void GetArea_SidesAre_3_And_4_And_5_ReturnAreaEquals6()
        {
            double firstSide = 3;
            double secondSide = 4;
            double thirdSide = 5;
            Triangle triangle = Triangle.CreateByThreeSides(firstSide, secondSide, thirdSide);
            Assert.AreEqual(triangle.GetArea(), 6);
        }

        [TestMethod]
        public void GetArea_SidesAre_3_And_4_AngleIs90_ReturnAreaEquals6()
        {
            double firstSide = 3;
            double secondSide = 4;
            double angle = 90;
            Triangle triangle = Triangle.CreateByTwoSidesAndAngle(firstSide, secondSide, angle);
            Assert.AreEqual(triangle.GetArea(), 6);
        }

        [TestMethod]
        public void GetArea_SideIs7_AnglesAre_60_And_60_ReturnAreaEquals12_Point_25()
        {
            double side = 7;
            double firstAngle = 45;
            double secondAngle = 45;
            Triangle triangle = Triangle.CreateBySideAndTwoAngle(side, firstAngle, secondAngle);
            Assert.AreEqual(triangle.GetArea(), 12.25, 0.001);
        }
    }
}
