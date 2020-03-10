using MyCartographyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestCartographie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            Console.WriteLine("************COORDONNEES************\n");
            Coordonnees A = new Coordonnees(40.25, 48.25);
            Coordonnees B = new Coordonnees(2.25, 12.25);
            Coordonnees C = new Coordonnees(3.45, 50.45);
            Coordonnees D = new Coordonnees(3.25, 10.45);
            Coordonnees Z = new Coordonnees(5.2, 11);

            A.latitude = 41.2;
            Console.WriteLine(A.ToString());
            Console.WriteLine(C.ToString());

            Console.WriteLine("\n**************POI**************\n");
            POI E = new POI();
            POI F = new POI("ici", 25.2, 1.25);
            POI Y = new POI("ok", 14, 2);


            Console.WriteLine(E.ToString());
            Console.WriteLine(F.ToString());

            Console.WriteLine("\n**************** Polyline******************\n");

            Polyline Poly1 = new Polyline(new List<Coordonnees>() { A, D, Y }, 10, Color.FromArgb(255, 255, 255, 255), 1);
            Polyline Poly2 = new Polyline(new List<Coordonnees>() { E,F},15,Color.FromArgb(0,0,0,0),1);
            Polyline Poly3 = new Polyline(new List<Coordonnees>() { Z, A }, 11, Color.FromArgb(254, 0, 211, 0), 0);
            Polyline Poly4 = new Polyline(new List<Coordonnees>() { Z, B }, 11, Color.FromArgb(254, 158, 251, 0), 0);

            Console.WriteLine(Poly1.ToString());
            Console.WriteLine(Poly2.ToString());

            Console.WriteLine("\n**************Polygone**********************\n");
            Polygone Polygone  = new Polygone(new List<Coordonnees>() { A, D, E }, Color.FromArgb(165,187,195,0), Color.FromArgb(165,200,140,165), 1,1) ;
            Polygone P5 = new Polygone();

            Console.WriteLine(Polygone.ToString());

            Console.WriteLine(P5.ToString());



            Console.WriteLine("\n******************Liste CartObj********************\n");
            List<CartoObj> ListeCart = new List<CartoObj>();
            ListeCart.Add(A);
            ListeCart.Add(E);
            ListeCart.Add(F);
            ListeCart.Add(Poly1);
            ListeCart.Add(Poly2);

            //Afficher la liste
           ListeCart.ForEach(item => Console.WriteLine(item));

            //Afficher ceux qui utilise ipointy
            Console.Write("\n****************On affiche ceux qui utilise IPOINTY*************\n");
            foreach(CartoObj item in ListeCart)
            {
                if(!(item  is IPointy))
                {
                    item.Draw();
                }
                
            }

            Console.Write("\n****************On affiche ceux qui n'utilise pas IPOINTY*************\n");
            foreach (CartoObj item in ListeCart)
            {
                if (item is IPointy)
                {
                    item.Draw();
                }

            }


            Console.WriteLine("\n****************Cree une liste de 5 polyline***********************\n");
            List<Polyline> Polyliste = new List<Polyline>();
            Polyliste.Add(Poly1);
            Polyliste.Add(Poly2);
            Polyliste.Add(Poly3);
            Polyliste.Add(Poly4);

            foreach(Polyline item in Polyliste)
            {
                Console.WriteLine(item.ToString());
            }

            Polyliste.Sort();

            Console.WriteLine("\n*************************** On Affiche la liste polyline triee -> longueur********************");
            foreach(Polyline item in Polyliste)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n*************************** On Affiche la liste polyline triee -> AIR Box********************");

            MyPolylineBoundingBoxComparer Compare = new MyPolylineBoundingBoxComparer();
            Polyliste.Sort(Compare);
            foreach (Polyline item in Polyliste)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("\n******************Nombre de point Different Dans poly 1 :    **************************");
            int point = Poly1.NbPoints;
            Console.WriteLine("il y a : " + point + "point(s) différent");
            
            Console.WriteLine("\n**************** Utilisation de IPointCLose*************" );
            Polyline P= Polyliste.Find(i => i.IsPointClose(25.2, 71, 1) == 1); //recherche dans la liste un element qui correspont
            if(P == null) // il ne sera pas proche 
            {
                Console.WriteLine("Le point n'est pas proche.");
            }
            else
            {
                Console.WriteLine("Le point est proche ===>");
                P.Draw();
            }

            Polyline P2 = Polyliste.Find(i => i.IsPointClose(41.2, 48, 1) == 1); //recherche dans la liste un element qui correspont
            if (P2 == null) // il sera proche de la coordonnee A
            {
                Console.WriteLine("Le point n'est pas proche.");
            }
            else
            {
                Console.WriteLine("Le point est proche ===>");
                P2.Draw();
            }

            Console.WriteLine("\n*********************Test Longueur*******************\n");

            double longueur = Poly1.LongueurPoly();
            Console.WriteLine("Voici la longueur:  "+longueur);
            Polyline PP = Polyliste.Find(i => i.LongueurPoly() == longueur);

            if(PP == null)
            {
                Console.WriteLine("Aucun point ne correspond a cette longueur");
            }
            else
            {
                PP.Draw();
            }

            Console.ReadKey();
        }

       
        
    }
}
