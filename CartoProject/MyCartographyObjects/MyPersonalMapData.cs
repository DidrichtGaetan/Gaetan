using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MyCartographyObjects
{
    [Serializable]
    public class MyPersonalMapData :INotifyPropertyChanged
    {
       private string _email;
       private string _nom;
       private string _prenom;
        private ObservableCollection <ICartoObj> _observableCollection;
        

        public ObservableCollection <ICartoObj> ObservableCollection {get => _observableCollection; set => _observableCollection = value; }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; NotifyPropertyChanged(); }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; NotifyPropertyChanged(); }
        }

        public string Email
        {
           get { return _email; }
            set { _email = value; NotifyPropertyChanged(); }
        }

       /* public MyPersonalMapData() : this("Nom", "Prenom", "Email", new ObservableCollection<ICartoObj> { })
        {


        }*/

        public MyPersonalMapData(string nom, string prenom, string email, ObservableCollection<ICartoObj> Liste)
        {
            _nom = nom;
            _prenom = prenom;
            _email = email;
            _observableCollection = Liste;
        }
        public MyPersonalMapData(string nom, string prenom, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }

        public void Load()
        {
            string NomFichier = Nom + Prenom +".dat";
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = File.OpenRead(NomFichier))
            {
                _observableCollection = (ObservableCollection<ICartoObj>)binFormat.Deserialize(fstream);
            }
            foreach (ICartoObj item in _observableCollection)
            {
                item.RTransforString();
            }
            
        }
        public void Save()
        {
            string NomFichier = Nom + Prenom + ".dat";
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(NomFichier, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, _observableCollection);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
