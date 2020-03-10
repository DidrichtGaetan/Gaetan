using Math_library;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;


namespace MyCartographyObjects
{
    public class Polyline : CartoObj, IPointy, IComparable<Polyline>
    {

        private int _epaisseur;
        private Color _couleur;
        private List<Coordonnees> _Liste;
        private List<double> _bBox;

        #region PROPRIETES
        public int Epaisseur
        {
            get { return _epaisseur; }
            set { _epaisseur = value; }

        }
        private Color Couleur
        {
            get { return _couleur; }
            set { _couleur = value; }
        }

        public List<Coordonnees> Liste { get => _Liste; set => _Liste = value; }

        public int NbPoints
        {
            get
            {
                return this.Liste.Select(a => a.Id).Distinct().Count();
            }
        }

        public List<double> BBox { get => _bBox; set => _bBox = value; }


        #endregion

        #region CONSTRUCTEURS
        public Polyline(List<Coordonnees> L, int epaisseur, Color couleur, int id) : base()
        {
            _Liste = L;
            _epaisseur = epaisseur;
            _couleur = couleur;
        }
        public Polyline()
        {
            // _Liste = null;
            _epaisseur = 0;
            _couleur = Color.FromRgb(0, 0, 0);
        }
        #endregion

        #region TOSTRING() and DRAW()
        public override string ToString()
        {
             
            return base.ToString() + "(epaisseur : " + _epaisseur + ")" + "(Couleur: " + _couleur + ")" + "(Longueur :  " + LongueurPoly() + ")";

        }

        public override void Draw()
        {
            _Liste.ForEach(item => Console.WriteLine(item));
            Console.WriteLine(this.ToString());
        }
        public double LongueurPoly()
        {
            double longueur = 0, precedentX = 0, precedentY = 0;
            int i = 0;
            foreach (Coordonnees point in Liste)
            {
                if (i > 0)
                {
                    longueur += MathUtil.DistancePoint(precedentX, precedentY, point.longitude, point.latitude);
                }
                precedentX = point.longitude;
                precedentY = point.latitude;
                i++;
            }
            return longueur;
        }
        public int CompareTo(Polyline other)
        {
            if (other == null)
                return 1;
            if (other.LongueurPoly() > this.LongueurPoly())
            {
                return -1;
            }
            else
            {
                if (other.LongueurPoly().Equals(this.LongueurPoly()))
                {
                    return 0;
                }
                if (other.LongueurPoly() < this.LongueurPoly())
                {
                    return 1;
                }


            }
            return 0;

        }

        public bool Equals(Polyline other)
        {
            if (this.LongueurPoly() == other.LongueurPoly())
                return true;
            else
                return false;
        }

        #endregion

       public int IsPointClose(double latitude, double longitude, double precision)
        {
            double precedentx = 0, precedenty = 0;
            int i = 0;

            foreach (Coordonnees point in _Liste)
            {
                if (MathUtil.DistancePoint(latitude, longitude, point.latitude, point.longitude) <= precision)
                {
                    return 1;
                }
                else
                {
                    if (i > 0)
                    {
                        if(MathUtil.DistancePointSegment(precedentx,precedenty,point.longitude,point.latitude,longitude,latitude)<= precision)
                        {
                            return 1;
                        }
                        precedenty = point.latitude;
                        precedentx = point.longitude;
                    }
                }
                i++;
            }


            return 0;
        }

        private void BoundingBox()
        {
          double xmax = _Liste.ToArray()[0].longitude, xmin = _Liste.ToArray()[0].longitude, ymax = _Liste.ToArray()[0].latitude, ymin = Liste.ToArray()[0].latitude;
            foreach(Coordonnees point in _Liste)
            {
                if (xmax < point.longitude)
                    xmax = point.longitude;
                else
                {
                    if (xmin > point.longitude)
                        xmin = point.longitude;
                }
                if (ymax < point.latitude)
                    ymax = point.latitude;
                else
                {
                    if (ymin > point.latitude)
                        ymin = point.latitude;
                }
                _bBox = new List<double>();
                _bBox.Add(xmax);
                _bBox.Add(xmin);
                _bBox.Add(ymax);
                _bBox.Add(ymin);
            }
        }

        public double AireBoundingBox()
        {
            BoundingBox();
            return (MathUtil.DistancePoint(_bBox.ToArray()[1], _bBox.ToArray()[3], _bBox.ToArray()[1], _bBox.ToArray()[2]) * MathUtil.DistancePoint(_bBox.ToArray()[1], _bBox.ToArray()[2], _bBox.ToArray()[0], _bBox.ToArray()[2]));
  
        }



    }
}
