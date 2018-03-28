using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libGesper;
using MySql.Data.MySqlClient;

namespace ChargementGesper
{
class Program
{
    static void Main(string[] args)
    {
        Donnees lesDonnees = new Donnees();

        //Connexion à la base de donnée.
        try
        {
            lesDonnees.ConnexionBDD();
            Console.WriteLine("Connexion à la base de donnée réussi");
        }
        catch
        {
            Console.WriteLine("Erreur à la connexion de la base de données");
        }
        
        Console.WriteLine();

        //Chargement des services
        lesDonnees.ChargerServices(lesDonnees.ConnexionBDD());

        //Chargement des données
        lesDonnees.ChargerEmployes(lesDonnees.ConnexionBDD());

        //Chargement des diplomes
        lesDonnees.ChargerDiplomes(lesDonnees.ConnexionBDD());

        //Affichage des services
        lesDonnees.AfficherServices();

        //Affichage des diplômes
        lesDonnees.AfficherDiplomes();

        //Affichage des employés
        lesDonnees.AfficherEmployes();
            

           
           

           
           

           
        Console.ReadLine();
    }
}
}
