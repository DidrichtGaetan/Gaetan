using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Math_library
{
   public class MathUtil
    { 
        public static double DistancePoint(double x1,double y1,double x2,double y2)
        { 
            return Math.Sqrt(Math.Pow((x2-x1),2) + Math.Pow((y2-y1),2));

        }
        public static double DistancePointSegment(double sx1, double sy1, double sx2, double sy2, double x, double y)
        {
            return Math.Abs((sx2 - sx1) * (sy1 - y) - (sx1 - x) * (sy2 - sy1)) /
                    Math.Sqrt(Math.Pow(sx2 - sx1, 2) + Math.Pow(sy2 - sy1, 2));
        }
    }
}
