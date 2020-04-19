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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyCartographyObjects;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;

namespace Test
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
           MyPersonalMapData utilisateur = new MyPersonalMapData(NomTB.Text, PrenomTB.Text, emailTB.Text);
           WindowPrincipal w = new WindowPrincipal(utilisateur);
           Coordonnees A = new Coordonnees(40.25, 48.25);
           MyCartographyObjects.Polyline Poly1 = new MyCartographyObjects.Polyline(new List<Coordonnees>() {A}, 10, Color.FromArgb(255, 201, 200, 152), 1);
           ObservableCollection<ICartoObj> ListeTest = new ObservableCollection<ICartoObj>();
           ListeTest.Add(Poly1);
           utilisateur.ObservableCollection = ListeTest;

            Coordonnees B = new Coordonnees(40.25, 48.25);
            Coordonnees D = new Coordonnees(3.25, 10.45);
            Coordonnees E = new Coordonnees(4.254, 5.2545);
            Polygone Polygone = new Polygone(new List<Coordonnees>() { B, D, E }, Color.FromArgb(165, 187, 195, 0), Color.FromArgb(165, 200, 140, 165), 1, 1);
            
            ListeTest.Add(Polygone);
            utilisateur.ObservableCollection = ListeTest;
            

            string filename = utilisateur.Nom + utilisateur.Prenom + ".dat";

            if (NomTB.Text.Length < 1 || PrenomTB.Text.Length < 1 || emailTB.Text.Length < 1)
            {
                ApresConnexion.Text = "Erreur : Veuillez remplir tous les champs";
                MessageBox.Show("Erreur : Veuillez remplir tous les champs");

            }
            else
            {
               // ApresConnexion.Text = filename;
                if(!(File.Exists(@"C:\Users\gaetan\source\repos\CartoProject\Test\bin\Debug\"+filename)))
                {
                   

                    ApresConnexion.Text = "Utilisateur n'existe pas";
                    MessageBox.Show("Utilisateur n'existe pas");
                    utilisateur.Save();
                    w.Show();
                    this.Close();
                }
                else
                {

                    ApresConnexion.Text = "Utilisateur existe deja";
                    MessageBox.Show("Utilisateur existe deja");
                   // utilisateur.Load();
                    w.Show();
                    this.Close();

                }
            }
        }

        private void emailTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void o(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
