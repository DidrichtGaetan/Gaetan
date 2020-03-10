using System;

namespace Math_Librairie
{
    public class MathUtil
    {
        public static double DistancePoint(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow((x2-x1),2) + Math.Pow((y2-y1),2));
        }
    }
}
