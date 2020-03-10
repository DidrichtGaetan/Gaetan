using System;
using System.Collections.Generic;
using System.Text;
using Math_library;

namespace MyCartographyObjects

{
    public class Coordonnees : CartoObj
    {
        #region VARIABLES MEMBRES
        private double _latitude;
        private double _longitude;
        #endregion

        #region PROPRIETES
        public double latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public double longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public object Longitude { get; private set; }
        public object Latitude { get; private set; }
        #endregion

        #region CONSTRUCTEUR
        public Coordonnees(double latitude, double longitude) : base()
        {
            _latitude = latitude;
            _longitude = longitude;
        }
        
        public Coordonnees() 
        {
            _latitude = 0;
            _longitude = 0;
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return base.ToString() + " ( Voici la latitude: " + _latitude + ")"+ " (Voici la longitude: " + _longitude + ")";
        }

        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
        public int IsPointCLose(double Latitude, double Longitude, double precision)
        {
            if (MathUtil.DistancePoint(Longitude, longitude, latitude, Latitude)<=precision)
                return 1;
            else
                return 0;
        }
    }

}
