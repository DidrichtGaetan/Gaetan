using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
   public class MyPolylineBoundingBoxComparer : IComparer<Polyline>
    {

        public int Compare(Polyline A, Polyline B)
        {
            if (A.AireBoundingBox() > B.AireBoundingBox()) return 1;
            else
            {
                if (A.AireBoundingBox() < B.AireBoundingBox()) return -1;
                if (A.AireBoundingBox() == B.AireBoundingBox()) return 0;
            }
            return 0;
        }

    }
}
