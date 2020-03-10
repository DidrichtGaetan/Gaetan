using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public interface IIsPointClose
    {
         int IsPointClose(double latitude, double longitude, double precision);
           
    }
}
