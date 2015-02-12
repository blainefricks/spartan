using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan_HUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            // p1 values
            Console.WriteLine("Point 1 x value:");
            double a1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 1 y value:");
            double a2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 1 z value:");
            double a3 = Convert.ToDouble(Console.ReadLine());

            // p2 values
            Console.WriteLine("Point 2 x value:");
            double b1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 2 y value:");
            double b2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 2 z value:");
            double b3 = Convert.ToDouble(Console.ReadLine());

            // Distance from p2 to p3
            Console.WriteLine("Distance from Point 2 to Point 3:");
            double distanceBC = Convert.ToDouble(Console.ReadLine());

            // Angle at p2
            Console.WriteLine("Point 2's Angle:");
            double angleB = Convert.ToDouble(Console.ReadLine());

            // Three Points
            double[] pointA = { a1, a2, a3 }; // eye coordinate
            double[] pointB = { b1, b2, b3 }; // aim coordinate

            double distanceAB = distanceBetween(pointA,pointB);

            double[] p1p3Distance = triangleAngleSides(angleB, distanceAB, distanceBC);

            double  angleA      = p1p3Distance[0];
            double  distanceAC = p1p3Distance[1];
            double  angleC      = p1p3Distance[2];

            // double angleCAB = angleBetweenVectors(p1,p2);

            double[] pointC = findPointCoordinates(pointA, pointB, distanceAB, angleA); // target coordinate

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
        private static double[] findPointCoordinates(double[] pointA, double[] pointB, double distanceAC, double angleCAB)
        {
            // Find the Coordinates of Point C based on Point A, Point B, distance of AB, and distance of BC
            double v1 = (Math.Cos(angleCAB) * (pointB[0] - pointA[0]) + Math.Sin(angleCAB) * (pointB[1] - pointA[1])) / distanceBetween(pointA, pointB);
            double v2 = (Math.Cos(angleCAB) * (pointB[1] - pointA[1]) - Math.Sin(angleCAB) * (pointB[0] - pointA[0])) / distanceBetween(pointA, pointB);

            // Point C
            double c1 = pointA[0] + distanceAC * v1; // x
            double c2 = pointA[1] + distanceAC * v2; // y
            double c3 = 0; // z

            double[] pointC = { c1, c2, c3 };
            return pointC;
        }
        private static double sideAngleSide(double distanceAB, double distanceBC, double angleABC)
        {
            // Calculate distance of Unkown Side of Triangle using Side Angle Side (SAS)
            // AC^2 = AB^2 + BC^2 - 2(AB*BC)cos(angleABC)
            double distanceAC = Math.Sqrt( Math.Pow(distanceAB,2) + Math.Pow(distanceBC,2) - 2*distanceAB*distanceBC*Math.Cos(angleABC) );
            return distanceAC;
        }
        private static double dotProduct(double[] vector1, double[] vector2)
        {
            double dotProd = vector1[0] * vector2[0] + vector1[1] * vector2[1] + vector1[2] * vector2[2];
            return dotProd;
        }
        private static double magnitude(double[] vector)
        {
            // a^2 = b^2 + c^2 + d^2
            double b = vector[0];
            double c = vector[1];
            double d = vector[2];
            double magOfVector = Math.Sqrt( Math.Pow(b, 2) + Math.Pow(c, 2) + Math.Pow(d, 2) );
            return magOfVector;
        }
        private static double angleBetweenVectors(double[] vector1, double[] vector2)
        {
            double angleV1V2 = Math.Acos(dotProduct(vector1,vector2)/(magnitude(vector1)*magnitude(vector2)));
            return angleV1V2;
        }
        private static double[] triangleAngleSides(double angleB, double distanceAB, double distanceBC)
        {
            double distanceAC = Math.Sqrt(Math.Cos(angleB) * 2 * distanceBC * distanceAB - Math.Pow(distanceBC,2) - Math.Pow(distanceAB,2)); // b = arccos((y^2 + z^2 - x^2)/2yz)
            double angleA = Math.Acos((Math.Pow(distanceAC, 2) + Math.Pow(distanceAB, 2) - Math.Pow(distanceBC, 2)) / (2 * distanceAC * distanceAB)); // a = arccos((x^2 + z^2 - y^2)/2xz)
            double angleC = Math.Acos((Math.Pow(distanceAC, 2) + Math.Pow(distanceBC, 2) - Math.Pow(distanceAB, 2)) / (2 * distanceAC * distanceBC)); // c = arccos((x^2 + y^2 - z^2)/2xy)
            double[] foundASA = { angleA, distanceAC, angleC };
            return foundASA;
        }
    }
}