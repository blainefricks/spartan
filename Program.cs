using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Spartan_HUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            // pointA values
            Console.WriteLine("Eye Coordinates");
            Console.Write("x = ");
            double a1 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double a1 = 0; // Debug
            // Console.WriteLine(a1); // Debug
            Console.Write("y = ");
            double a2 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double a2 = 0; // Debug
            // Console.WriteLine(a2); // Debug
            Console.Write("z = ");
            double a3 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double a3 = 0; // Debug
            // Console.WriteLine(a3); // Debug

            Console.WriteLine("");

            // pointB values
            Console.WriteLine("Gun Coordinates");
            Console.Write("x = ");
            double b1 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double b1 = 1; // Debug
            // Console.WriteLine(b1); // Debug
            Console.Write("y = ");
            double b2 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double b2 = 1; // Debug
            // Console.WriteLine(b2); // Debug
            Console.Write("z = ");
            double b3 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double b3 = -1; // Debug
            // Console.WriteLine(b3); // Debug

            Console.WriteLine("");

            // Distance from pointB to pointC
            Console.Write("Distance from Gun to Target: ");
            double distanceBC = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double distanceBC = 20; // Debug
            // Console.WriteLine(distanceBC); // Debug

            Console.WriteLine("");

            // Angle at pointB
            Console.WriteLine("Angle's of Gun ");
            Console.Write("zy angle = ");
            double phiB = DegreeToRadian(Convert.ToDouble(Console.ReadLine())); // Console Input Build
            // double phiB = DegreeToRadian(90); // Debug
            // Console.WriteLine(RadianToDegree(phiB)); // Debug
            Console.Write("xy angle = ");
            double thetaB = DegreeToRadian(Convert.ToDouble(Console.ReadLine())); // Console Input Build
            // double thetaB = DegreeToRadian(110); // Debug
            // Console.WriteLine(RadianToDegree(thetaB)); // Debug

            // Three Points
            double[] pointA = { a1, a2, a3 }; // eye coordinate
            double[] pointB = { b1, b2, b3 }; // gun coordinate
            double[] pointC = SphericalCoordinate(distanceBC, phiB, thetaB, pointB); // target coordinate

            double distanceAB = DistanceBetween(pointA,pointB);

            double[] vectorBA = VectorFromPoints(pointB, pointA);
            double[] vectorBC = VectorFromPoints(pointB, pointC);
            double angleABC = AngleBetweenVectors(vectorBA, vectorBC);
            double distanceAC = SolveTriangleSAS(distanceAB, angleABC, distanceBC);

            Console.WriteLine("");
            Console.WriteLine("Distance From Eye to Gun    =~ {0}ft", distanceAB);
            Console.WriteLine("Distance From Gun to Target =~ {0}ft", distanceBC);
            Console.WriteLine("Distance From Eye to Target =~ {0}ft", distanceAC);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Reticle Placement           =~ ( {0}ft, {1}ft, {2}ft )", pointC[0],pointC[1],pointC[2]);
            Console.ReadLine();
        }
        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        private static double DistanceBetween(double[] point0, double[] point1)
        {
            // Distance Between Two Known Points Formula
            // d = SquareRoot(xd^2 + yd^2 + zd^2)
            double xd = point1[0] - point0[0];
            double yd = point1[1] - point0[1];
            double zd = point1[2] - point0[2];

            double distanceAB = Math.Sqrt( Math.Pow(xd,2) + Math.Pow(yd,2) + Math.Pow(zd,2) );
            return distanceAB;
        }
        private static double[] SphericalCoordinate(double rho, double phi, double theta, double[] origin)
        {
            double x = (rho * Math.Sin(phi) * Math.Cos(theta)) + origin[0];
            double y = (rho * Math.Sin(phi) * Math.Sin(theta)) + origin[1];
            double z = (rho * Math.Cos(phi)) + origin[2];

            double[] point = { x, y, z };
            return point;
        }
        private static double DotProduct(double[] vector0, double[] vector1)
        {
            double dotProd = vector0[0] * vector1[0] + vector0[1] * vector1[1] + vector0[2] * vector1[2];
            return dotProd;
        }
        private static double Magnitude(double[] vector)
        {
            // Magnitude or Length of a Vector
            // |v| = √(x^2 + y^2 + z^2)
            double magOfVector = Math.Sqrt( Math.Pow(vector[0], 2) + Math.Pow(vector[1], 2) + Math.Pow(vector[2], 2) );
            return magOfVector;
        }
        private static double AngleBetweenVectors(double[] vector0, double[] vector1)
        {
            double theta = Math.Acos(DotProduct(vector0,vector1)/(Magnitude(vector0)*Magnitude(vector1)));
            return theta;
        }
        private static double[] VectorFromPoints(double[] point0, double[] point1)
        {
            double x = point1[0] - point0[0];
            double y = point1[1] - point0[1];
            double z = point1[2] - point0[2];
            double[] vector = { x, y, z };
            return vector;
        }
        private static double SolveTriangleSAS(double side0, double angle, double side1)
        {
            // a^2 = b^2 + c^2 − 2bc*cosA
            double side2 = Math.Sqrt(Math.Pow(side0, 2) + Math.Pow(side1, 2) - 2 * side0 * side1 * Math.Cos(angle));
            return side2;
        }
    }
}