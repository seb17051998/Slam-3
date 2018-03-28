using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace gesperControle112016
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            string sCnx;
            MySqlConnection Cnx;
            MySqlCommand Cmd;
            MySqlDataReader Rdr;
            //int pnumService;
            //Decimal salaireMoyen, mtBudget;
            //int pnbPersonnes;

            // chaîne de caractères de connexion
            sCnx = "server=localhost;uid=root;database=gesper;port=3306;pwd=siojjr";

            //création d'un objet connexion
            Cnx = new MySqlConnection(sCnx);
            //ouverture de la connexion
            try
            {
                Cnx.Open();
                Console.WriteLine("connexion réussie");
            }
            catch (Exception e)
            {
                Console.WriteLine("erreur connexion " + e.Message.ToString());
            }
            do
            {
                do
                {

                    Console.WriteLine("1 - liste des employés ne possédant pas de diplome");
                    Console.WriteLine("2 - le salaire moyen des employés d'un service passé en paramètre");
                    Console.WriteLine("3 - budget moyen des services administratifs");
                    Console.WriteLine("4 - liste des employés diplomés(numéro, nom, prenom, nombre de diplomes) ");
                    Console.WriteLine("    qui se trouvent dans un service de plus de n(paramètre à saisir) personnes");
                    Console.WriteLine("5 - fin du traitement");
                    Console.WriteLine();


                    choix = Int32.Parse(Console.ReadLine());

                } while (choix < 0 || choix > 5);

                switch (choix)
                {
                    case 1:
                        Console.WriteLine("1 - liste des employés ne possédant pas de diplome");

                        // la commande
                        Cmd = new MySqlCommand();
                        Cmd.Connection = Cnx;
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "select * from employe where emp_id not in (select pos_employe from posseder);";
                        try
                        {
                            Rdr = Cmd.ExecuteReader();
                            while (Rdr.Read())
                            {
                                // avec le numéro de la colonne                
                                Console.WriteLine(Rdr["emp_id"].ToString() + " " + Rdr["emp_nom"].ToString() + " " + Rdr["emp_prenom"].ToString() + " " + Rdr["emp_salaire"].ToString());
                            }
                            Rdr.Close();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0} ", e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("2 - le salaire moyen des employés d'un service passé en paramètre");
                        Cmd = new MySqlCommand();
                        Cmd.Connection = Cnx;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Console.WriteLine("Entrez le numéro du service : ");
                        int i = Convert.ToInt32(Console.ReadLine());
                        Cmd.CommandText = "salaireMoyenEmploye";
                        Cmd.Parameters.AddWithValue("numservice", i);
                        Cmd.Parameters.AddWithValue("@salMoy", 0);
                        Cmd.Parameters["@salMoy"].Direction = ParameterDirection.Output;
                        
                        Cmd.Prepare();
                           
                       try
                       {
                            Rdr = Cmd.ExecuteReader();
                            Rdr.Read();
                            
                            Console.WriteLine("Le salaire moyen de l'employé du service {0} est de {1} Euros",i,Rdr.GetString(0));
                            
                            Rdr.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0} ", e.Message);
                        }

                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("3 - budget moyen des services administratifs");
                        Cmd = new MySqlCommand();
                        Cmd.Connection = Cnx;
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "select avg(ser_budget) as BudgetMoyen from service;";
                        try
                        {
                            int budgmoy;
                            Console.Write("Le budget moyen des services administratifs est de ");
                            Console.WriteLine(budgmoy = Convert.ToInt32(Cmd.ExecuteScalar()));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0} ", e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("4 - liste des employés diplomés(numéro, nom, prenom, nombre de diplomes) ");
                        // la commande
                        Cmd = new MySqlCommand();
                        Cmd.Connection = Cnx;
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "SELECT emp_id,emp_nom,emp_prenom, count(*) as 'nombre de diplomes' from employe e inner join posseder p on e.emp_id=p.pos_employe where emp_service in (select emp_service from employe group by emp_service having count(*)> @n) group by emp_id,emp_nom,emp_prenom";
                        Console.WriteLine("Liste des employés qui se trouve dans un service de plus de n personnes, entrez n : ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        MySqlParameter Pn = new MySqlParameter("@n", n);
                        Cmd.Parameters.Add(Pn);
                        try
                        {
                            Rdr = Cmd.ExecuteReader();
                            while (Rdr.Read())
                            {
                                Console.Write(Rdr["emp_id"]);
                                Console.Write(" ");
                                Console.Write(Rdr["emp_nom"]);
                                Console.Write(" ");
                                Console.Write(Rdr["emp_prenom"]);
                                Console.Write(" ");
                                Console.Write(Rdr["nombre de diplomes"]);
                                Console.WriteLine();

                            }
                            Rdr.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0} ", e.Message);
                        }

                            
                        Console.WriteLine();



                        break;
                    case 5:

                        Console.WriteLine("Fin du traitement");
                        break;
                }
            }
            while (choix != 5);

            Console.ReadLine();
        }
    }
}
