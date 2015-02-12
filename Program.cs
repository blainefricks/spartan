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
            // double a1 = 1; // SublimeText 3 console build
            // Console.WriteLine(a1); // SublimeText 3 console build
            Console.Write("y = ");
            double a2 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double a2 = 1; // SublimeText 3 console build
            // Console.WriteLine(a2); // SublimeText 3 console build
            Console.Write("z = ");
            double a3 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double a3 = 1; // SublimeText 3 console build
            // Console.WriteLine(a3); // SublimeText 3 console build

            Console.WriteLine("");

            // pointB values
            Console.WriteLine("Gun Coordinates");
            Console.Write("x = ");
            double b1 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double b1 = 1; // SublimeText 3 console build
            // Console.WriteLine(b1); // SublimeText 3 console build
            Console.Write("y = ");
            double b2 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double b2 = 1; // SublimeText 3 console build
            // Console.WriteLine(b2); // SublimeText 3 console build
            Console.Write("z = ");
            double b3 = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double b3 = -1; // SublimeText 3 console build
            // Console.WriteLine(b3); // SublimeText 3 console build

            Console.WriteLine("");

            // Distance from pointB to pointC
            Console.Write("Distance from Gun to Target: ");
            double distanceBC = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double distanceBC = 10.53205080756888; // SublimeText 3 console build
            // Console.WriteLine(distanceBC); // SublimeText 3 console build

            Console.WriteLine("");

            // Angle at pointB
            Console.WriteLine("Angle's of Gun ");
            Console.Write("zy angle = ");
            double phiB = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double phiB = 85.23; // SublimeText 3 console build
            // Console.WriteLine(phiB); // SublimeText 3 console build
            Console.Write("xy = ");
            double thetaB = Convert.ToDouble(Console.ReadLine()); // Console Input Build
            // double thetaB = 120.45; // SublimeText 3 console build
            // Console.WriteLine(thetaB); // SublimeText 3 console build

            // Three Points
            double[] pointA = { a1, a2, a3 }; // eye coordinate
            double[] pointB = { b1, b2, b3 }; // aim coordinate
            double[] pointC = sphericalCoordinate(distanceBC, phiB, thetaB); // target coordinate

            double distanceAB = distanceBetween(pointA,pointB);
            double distanceAC = distanceBetween(pointA,pointC);

            Console.WriteLine("");
            Console.WriteLine("Distance From Eye to Gun    =~ {0}ft", distanceAB);
            Console.WriteLine("Distance From Gun to Target =~ {0}ft", distanceBC);
            Console.WriteLine("Distance From Eye to Target =~ {0}ft", distanceAC);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Reticle Placement           =~ ({0},{1},{2})", pointC[0],pointC[1],pointC[2]);
            Console.ReadLine();
        }
        private static double distanceBetween(double[] pointA, double[] pointB)
        {
            // Distance Between Two Known Points Formula
            // d = SquareRoot(xd^2 + yd^2 + zd^2)
            double xd = pointB[0] - pointA[0];
            double yd = pointB[1] - pointA[1];
            double zd = pointB[2] - pointA[2];

            double distanceAB = Math.Sqrt( Math.Pow(xd,2) + Math.Pow(yd,2) + Math.Pow(zd,2) );// d = SquareRoot(xd^2 + yd^2 + zd^2)
            return distanceAB;
        }
        private static double[] sphericalCoordinate(double row, double phi, double theta)
        {
            // Point C
            double c1 = row * Math.Sin(phi) * Math.Cos(theta); // x
            double c2 = row * Math.Sin(phi) * Math.Sin(theta); // y
            double c3 = row * Math.Cos(phi); // z

            double[] pointC = { c1, c2, c3 };
            return pointC;
        }
        private static double dotProduct(double[] vector1, double[] vector2)
        {
            double dotProd = vector1[0] * vector2[0] + vector1[1] * vector2[1] + vector1[2] * vector2[2];
            return dotProd;
        }
        private static double magnitude(double[] vector)
        {
            // Magnitude or Length of a Vector
            // |v| = √(x^2 + y^2 + z^2)
            double x = vector[0];
            double y = vector[1];
            double z = vector[2];
            double magOfVector = Math.Sqrt( Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2) );
            return magOfVector;
        }
    }
}