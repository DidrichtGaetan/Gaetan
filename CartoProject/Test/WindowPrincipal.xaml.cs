using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

/// <summary>
/// Logique d'interaction pour WindowPrincipal.xaml
/// </summary>
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Maps.MapControl.WPF;
using MyCartographyObjects;


namespace Test
{
    public partial class WindowPrincipal : Window
    {
        private MyPersonalMapData _user;
        
       
        
        
        public WindowPrincipal()
        {
            InitializeComponent();

            MyMap.Mode = new AerialMode(true);
        }

        public WindowPrincipal(MyPersonalMapData user):this()
        {
           _user = user;
           
        }

        private void sauvegarde_Click(object sender,RoutedEventArgs e)
        {
            if (_user.ObservableCollection == null || _user.ObservableCollection.Count < 1)
                MessageBox.Show("la liste est vide");
            else
            {
                MessageBox.Show("Vos données ont été souvegardé avec succès");
                _user.Save();
            }
                
             
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (_user.ObservableCollection == null || _user.ObservableCollection.Count < 1)
                MessageBox.Show("la liste est vide,rien à charger");
            else
            {
                MessageBox.Show("Vos données ont été chargé avec succès");
                _user.Load();
                foreach (ICartoObj item in _user.ObservableCollection)
                {
                    if (item is Polyline)
                    {
                        ListBox1.Items.Add("Polyline:");
                        ListBox1.Items.Add(item); //On ajoute polyline dans la listbox

                    }
                    else if (item is Polygone)
                    {
                        Console.WriteLine("Polygone: \n");
                        ListBox1.Items.Add(item);

                    }
                    else if (item is POI)
                    {
                        ListBox1.Items.Add(item);
                    }
                }
            }


        }

        private void AboutBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Auteur: Didricht Gaëtan\nCopyright: ☺\nDate: Mars 2020");
        }

        private void ImportPoi(object sender, RoutedEventArgs e)
        {
            POI Point = new POI("Test", 50.608231, 5.487558);
           
            Location l = new Location();

            
            

            Pushpin P = new Pushpin();
            P.SetValue(MapLayer.PositionProperty, l);
           // this.MyMap.Children.Add(P);
            ListBox1.Items.Add(Point);




        }

        private void ListBox1_Loaded(object sender, RoutedEventArgs e)
        {
         
            foreach(ICartoObj item in _user.ObservableCollection)
            {
                if(item is Polyline)
                {
                    
                    ListBox1.Items.Add(item); //On ajoute polyline dans la listbox
                   
                }
                else if(item is Polygone)
                {
                    
                    ListBox1.Items.Add(item);
                   
                }
                else if(item is POI)
                {
                    ListBox1.Items.Add(item);
                }
            }

        }

        private void ListBox1_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            /* if(ListBox1.SelectedItem is Polyline)
             {
                 Polyline P = new Polyline();
                 P = (Polyline)ListBox1.SelectedItem;
                 CouleurContour.Content = P.Couleur;
                 Epaisseur.Content = P.Epaisseur;

                 MapPolyline polyline = new MapPolyline();


                 polyline.Stroke = new SolidColorBrush(P.Couleur);
                 polyline.StrokeThickness = 5;
                 polyline.Opacity = 0.7;
                 polyline.Locations = new LocationCollection() {
                 new Location(50.611182, 5.509222), new Location(50.609452, 5.509943),new Location(50.609866, 5.507116) };

                 MyMap.Children.Add(polyline);

             }*/

            if (ListBox1.SelectedItem is Polyline)
            {
                MyMap.Children.Clear();
                Polyline P = new Polyline();
                P = (Polyline)ListBox1.SelectedItem;
                CouleurContour.Content = P.Couleur;
                Epaisseur.Content = P.Epaisseur;
                
                CouleurRemplissage.Content = "";
                Opacite.Content = "";
                Description.Content = "";

                MapPolyline polyline = new MapPolyline();


                polyline.Stroke = new SolidColorBrush(P.Couleur);
                polyline.StrokeThickness = 5;
                polyline.Opacity = 0.7;
                polyline.Locations = new LocationCollection() {
                 new Location(50.611182, 5.509222), new Location(50.609452, 5.509943),new Location(50.609866, 5.507116) };

                MyMap.Children.Add(polyline);
            }

                if (ListBox1.SelectedItem is POI)
                {
                    MyMap.Children.Clear();
                    POI Point = new POI();
                    Point = (POI)ListBox1.SelectedItem;
                    // MyMap.TryViewportPointToLocation()
                    Location l = new Location
                    {
                        Latitude = Point.latitude,
                        Longitude = Point.longitude
                    };
                    Description.Content = Point.Description;
                    CouleurContour.Content = "";
                    CouleurRemplissage.Content = "";
                    Opacite.Content = "";
                    Epaisseur.Content = "";



                Pushpin Pushin = new Pushpin();

                    Pushin.SetValue(MapLayer.PositionProperty, l);
                    this.MyMap.Children.Add(Pushin);
                }

            if (ListBox1.SelectedItem is MyCartographyObjects.Polygone)
            {

                CouleurContour.BorderThickness = new Thickness(0.8);
                Epaisseur.BorderThickness = new Thickness(0);
                CouleurRemplissage.BorderThickness = new Thickness(0.8);
                Opacite.BorderThickness = new Thickness(0.8);
                MyMap.Children.Clear();
                Polygone P = new Polygone();
                P = (Polygone)ListBox1.SelectedItem;
                CouleurContour.Content =  P.CouleurContourString;
                CouleurRemplissage.Content =  P.CouleurRemplissageString;
                Opacite.Content =  P.Opacite;
                
                Epaisseur.Content = "";
                Description.Content = "";

                MapPolygon polygon = new MapPolygon();
                polygon.Fill = new SolidColorBrush(P.Contour);
                polygon.Stroke = new SolidColorBrush(P.Remplissage);
                polygon.StrokeThickness = 5;
                polygon.Opacity = P.Opacite;
                polygon.Locations = new LocationCollection();
                foreach (Coordonnees item in P.Liste)
                {
                    polygon.Locations.Add(new Location(item.latitude, item.longitude));
                }
                MyMap.Children.Add(polygon);
            }



            }

        private void MouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            POI Point = new POI("Test", 50.608231, 5.487558);
            // MyMap.TryViewportPointToLocation()
            Location l = new Location();
            l.Latitude = 50.608231;
            l.Longitude = 5.487558;
            
          
            
            Pushpin P = new Pushpin();
            
            P.SetValue(MapLayer.PositionProperty, l);
            this.MyMap.Children.Add(P);
           // ListBox2.Items.Add();
        }

        

        private void MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Ajouter(object sender, RoutedEventArgs e)
        {
            
        }

        private void PoiClick(object sender, RoutedEventArgs e)
        {
            WindowAjout fenetreAjout = new WindowAjout("POI",ref _user);
            fenetreAjout.Show();
            this.Close();
        }

        private void PolylineClick(object sender, RoutedEventArgs e)
        {
            WindowAjout fenetreAjout = new WindowAjout("Polyline", ref _user);
            fenetreAjout.Show();
            this.Close();
        }

        private void PolygoneClick(object sender, RoutedEventArgs e)
        {
            WindowAjout fenetreAjout = new WindowAjout("Polygone", ref _user);
            fenetreAjout.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
            this.Close();
            MainWindow w = new MainWindow();
            w.Show();

            
        }

        private void Suppression_click(object sender, RoutedEventArgs e)
        {

            ListBox1.Items.Remove(ListBox1.SelectedItem);
            _user.ObservableCollection.Remove((POI)ListBox1.SelectedItem);

        }
    }
}
