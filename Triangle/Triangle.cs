using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class Triangle
    {
        private double[] Sides;

        private Triangle(double firstSide, double secondSide, double thirdSide)
        {
            Sides = new double[] { firstSide, secondSide, thirdSide };
        }

        public static Triangle CreateByThreeSides(double firstSide, double secondSide, double thirdSide)
        {
            if (!CheckSidesOnValidity(firstSide, secondSide, thirdSide))
                throw new ArgumentException("All sides must be greater than 0");
            return new Triangle(firstSide, secondSide, thirdSide);
                
        }
        public static Triangle CreateByTwoSidesAndAngle(double firstSide, double secondSide, double angle)
        {
            if (!CheckSidesOnValidity(firstSide, secondSide) || !CheckAnglesOnValidity(angle))
                throw new ArgumentException("All sides must be greater than 0 and angle must be in open interval from 0 to 180");
            double thirdSide = Math.Sqrt(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2) 
                - 2 * firstSide * secondSide * Math.Cos(ToRadians(angle)));
            return new Triangle(firstSide, secondSide, thirdSide);
        }
        public static Triangle CreateBySideAndTwoAngle(double side, double firstAngle, double secondAngle)
        {
            if (!CheckSidesOnValidity(side) || !CheckAnglesOnValidity(firstAngle, secondAngle))
                throw new ArgumentException("Side must be greater than 0, angles must be in open interval from 0 to 180 and their sum must be less then 180");
            double thirdAngle = 180 - firstAngle - secondAngle;
            double firstSide = side * Math.Sin(ToRadians(firstAngle)) / Math.Sin(ToRadians(thirdAngle));
            double secondSide = side * Math.Sin(ToRadians(secondAngle)) / Math.Sin(ToRadians(thirdAngle));
            return new Triangle(firstSide, secondSide, side);
        }
        private static double ToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }
        public double GetArea()
        {
            double p = (Sides[0] + Sides[1] + Sides[2]) / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }
        private static bool CheckSidesOnValidity(params double[] sides)
        {
            for (int i = 0; i < sides.Length; i++)
            {
                if (sides[i] <= 0)
                    return false;
            }
            return true;
        }
        private static bool CheckAnglesOnValidity(params double[] angles)
        {
            double sum = 0;
            for (int i = 0; i < angles.Length; i++)
            {
                sum += angles[i];
                if (angles[i] <= 0 || angles[i] >= 180)
                    return false;
            }
            if (sum >= 180)
                return false;
            return true;
        }
    }
}