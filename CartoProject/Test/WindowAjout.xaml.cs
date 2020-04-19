using MyCartographyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Logique d'interaction pour WindowAjout.xaml
    /// </summary>
    public partial class WindowAjout : Window
    {
        private string _type;
        public POI P = new POI();
        public Coordonnees C= new Coordonnees();
        public Polygon _polygon = new Polygon();
        public MyCartographyObjects.Polyline Poly = new MyCartographyObjects.Polyline();

        private string v;
        private MyPersonalMapData user;

        public WindowAjout()
        {
            InitializeComponent();
        }

        public WindowAjout(string v, ref MyPersonalMapData user) : this()
        {
             _type = v;
            this.user = user;

            
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            
            Console.WriteLine("1");
            Console.WriteLine(_type);

            if(String.Equals( _type,"POI"))
            {
                
                P.latitude = Double.Parse(LatitudeTB.Text);
                P.longitude = Double.Parse(LongitudeTB.Text);
                P.Description = DescriptionTB.Text;
                user.ObservableCollection.Add(P);
                
           }

            if (String.Equals(_type, "Polyline"))
            {
                
                Poly.Epaisseur = Int32.Parse(EpaisseurTB.Text);
                Console.WriteLine(CouleurPoly.Text);
                Poly.Couleur = (Color)ColorConverter.ConvertFromString(CouleurPoly.Text);
                user.ObservableCollection.Add(Poly);
            }

           /** if(String.Equals(_type,"Polygon"))
            {
              // _polygon.Couleur = (Color)ColorConverter.ConvertFromString(CouleurContourTB.Text);
              // _polygon.Opacite = Double.Parse(OpaciteTB.Text);
            }*/
            WindowPrincipal w = new WindowPrincipal(user);
            w.Show();
            this.Close();
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
           /* if (String.Equals(_type, "Polyline"))
            {
                C = new Coordonnees( Double.Parse(LatitudeTB.Text), Double.Parse(LongitudeTB.Text));
                Console.WriteLine(C.ToString());
                Poly.Liste.Add(C);
           }*/
        }
            
    }
}
