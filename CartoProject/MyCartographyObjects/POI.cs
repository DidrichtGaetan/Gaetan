using System;
using System.Collections.Generic;
using System.Text;
using Math_library;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCartographyObjects

{
    [Serializable]
    public class POI: Coordonnees,ICartoObj
    {
        #region VARIABLES MEMBRES
        private string _description;
        #endregion
        #region PROPRIETES
        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion
        #region CONSTRUCTEURS
        public POI(string description, double latitude, double longitude) : base(latitude,longitude)
        {
            _description = description;
        }
        #endregion
        #region ToString()
        public POI(): this("HEPL",50.611205,5.510085)
        {
        
        }
        public override string ToString() 
        {
            return "(Description:  " + _description + ")" + base.ToString();      
        }

        #endregion

        public int IsPointCLose(double Latitude, double Longitude, double precision)
        {
            if (MathUtil.DistancePoint(Longitude, longitude, latitude, Latitude) <= precision)
                return 1;
            else
                return 0;
        }

        public void RTransforString()
        {
            Console.WriteLine("1");
        }
    }
   
}
