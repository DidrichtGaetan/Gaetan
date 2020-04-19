using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    [Serializable]
    public class Polygone : CartoObj, IPointy,ICartoObj
    {
        [NonSerialized]
        private Color _remplissage;
        [NonSerialized]
        private Color _contour;
        private double _opacite;
        private List<Coordonnees> _Liste;
        private List<double> _bBox;
        private string _couleurContourString;
        private string _couleurRemplissageString;

        #region PROPRIETE
        public Color Remplissage
        {
            get { return _remplissage; }
            set { _remplissage = value; CouleurRemplissageString = _remplissage.ToString(); }
        }

        public Color Contour
        {
            get { return _contour; }
            set { _contour = value; CouleurContourString = _contour.ToString(); }
        }

        public double Opacite
        {
            get { return _opacite; }
            set { _opacite = value; }
        }

        public int NbPoints
        {
            get
            {
                return this.Liste.Select(a => a.Id).Distinct().Count();
            }
        }


        public List<Coordonnees> Liste { get => _Liste; set => _Liste = value; }
        public string CouleurRemplissageString { get => _couleurRemplissageString; set => _couleurRemplissageString = value; }
        public string CouleurContourString { get => _couleurContourString; set => _couleurContourString = value; }
        #endregion

        public Polygone(List<Coordonnees> L, Color contour, Color remplissage, double opacite, int id) : base()
        {
            _Liste = L;
            Contour = contour;
            Remplissage = remplissage;
            _opacite = opacite;
        }
        public Polygone()
        {
            _Liste = null;
            Contour = Color.FromRgb(255, 255, 255);
            Remplissage = Color.FromRgb(0, 0, 0);
            _opacite = 0.0;

        }

        #region ToString()
        public override string ToString()
        {
            return base.ToString() + "( Opacite: " + _opacite + ")" + "(remplissage: " + _remplissage + ")" + "(contour: " + _contour + ")";
        }
        public override void Draw()
        {
            _Liste.ForEach(item => Console.WriteLine(item));
            Console.WriteLine(this.ToString());
        }

        private void BoundingBox()
        {
            double xmax = _Liste.ToArray()[0].longitude, xmin = _Liste.ToArray()[0].longitude, ymax = _Liste.ToArray()[0].latitude, ymin = Liste.ToArray()[0].latitude;
            foreach (Coordonnees point in _Liste)
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
            #endregion
         
        }

        public void RTransforString()
        {
            _contour = (Color)ColorConverter.ConvertFromString(_couleurContourString);
            _remplissage = (Color)ColorConverter.ConvertFromString(_couleurRemplissageString);
        }
    }
}
