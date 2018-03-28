using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace libGesper
{
    public class Donnees 
    {
        /* Données membres */

        private List<Diplome> LesDiplomes;
        private List<Employe> LesEmployes;
        private List<Service> LesServices;
        private List<Employe> LesEmployesDuService;
              
        /* Accesseurs */
        /// <summary>
        /// Accesseurs sur la liste des diplomes
        /// </summary>
        internal List<Diplome> LesDiplomes1
        {
            get { return LesDiplomes; }
            set { LesDiplomes = value; }
        }

        /// <summary>
        /// Accesseurs sur la liste des Employés
        /// </summary>
        public List<Employe> LesEmployes1
        {
            get { return LesEmployes; }
            set { LesEmployes = value; }
        }

        /// <summary>
        /// Accesseurs sur la liste des Services
        /// </summary>
        public List<Service> LesServices1
        {
            get { return LesServices; }
            set { LesServices = value; }
        }


        /* Constructeur */
        public Donnees() 
        {
            LesDiplomes = new List<Diplome>();
            LesEmployes = new List<Employe>();
            LesServices = new List<Service>();
            LesEmployesDuService = new List<Employe>();

        }
        
        /* Méthodes */
        public void AfficherDiplomes()
        { 
            Console.WriteLine("LISTE DES DIPLOMES");
            Console.WriteLine();
            for (int i = 0; i < LesDiplomes.Count; i++)
            {
                Console.WriteLine(LesDiplomes[i].ToString());
                Console.WriteLine();
            }
        }

        public void AfficherEmployes()
        {
            Console.WriteLine("LISTE DES EMPLOYEES");
            Console.WriteLine();
            for (int i = 0; i < LesEmployes.Count; i++)
            {
                Console.WriteLine(LesEmployes[i].ToString());
                Console.WriteLine();
            }

        }
        public void AfficherServices()
        {
            Console.WriteLine("Affichage de la liste des services");
            Console.WriteLine();
            for (int i = 0; i < LesServices.Count; i++)
            {
                Console.WriteLine(LesServices[i].ToString());
                Console.WriteLine();
            }
        }
        public void Charger()
        {
        }
        public void ChargerDiplomes(MySqlConnection Cnx)
        {
            MySqlCommand Cmd = new MySqlCommand();
            MySqlDataReader Rdr;
            Diplome unDiplome;
            Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandText = "select * from diplome;";
            Rdr = Cmd.ExecuteReader();
            while (Rdr.Read())
            {
                unDiplome= new Diplome(Convert.ToInt32(Rdr["dip_id"]),Convert.ToString(Rdr["dip_libelle"]));
                LesDiplomes.Add(unDiplome);
            }
            Rdr.Close();
        }
        public void ChargerEmployes(MySqlConnection Cnx)
        {
            
            MySqlCommand Cmd = new MySqlCommand();
            MySqlDataReader Rdr;
            Employe unEmploye;
            Service unService;
            Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandText = "select * from employe";
            Rdr = Cmd.ExecuteReader();
            while (Rdr.Read())
            {
                for (int i = 0; i < LesServices.Count(); i++)
                {
                    if (LesServices[i].Id == Convert.ToInt32(Rdr["emp_service"]))
                    {
                        unService = LesServices[i];
                        unEmploye = new Employe(Convert.ToInt32(Rdr["emp_id"]), Convert.ToString(Rdr["emp_nom"]), Convert.ToString(Rdr["emp_prenom"]), Convert.ToChar(Rdr["emp_sexe"]), Convert.ToByte(Rdr["emp_cadre"]), Convert.ToDecimal(Rdr["emp_salaire"]), unService);
                        LesEmployes.Add(unEmploye);
                    }
                }
            }
            Rdr.Close();
               
            
        } 
        public void ChargerLesDiplomesDesEmployes(MySqlConnection Cnx)
        {
            

        }
        public void ChargerLesEmployesDesServices(MySqlConnection Cnx)
        {
            MySqlCommand Cmd = new MySqlCommand();
            MySqlDataReader Rdr;
            Cmd.Connection = Cnx;
            foreach (Service s in LesServices)
            {

           
            Cmd.CommandText = "select * from employe where emp_service=s.id;";
            Rdr = Cmd.ExecuteReader();
            int i;
            while (Rdr.Read())
            {
                i = 0;
                while (i < LesEmployes.Count && LesEmployes[i].Id != Int32.Parse(Rdr.GetString(0)))
                {
                    i++;
                }

                if(LesEmployes[i].Id == Int32.Parse(Rdr.GetString(0))){
                    s.LesEmployesDuService.Add(LesEmployes[i]);

                }
                Rdr.Close();
            }
            }

        }
        public void ChargerLesEmployesTitulairesDesDiplomes(MySqlConnection Cnx)
        {
        }
        public void ChargerServices(MySqlConnection Cnx)
        {
            MySqlCommand Cmd = new MySqlCommand();
            MySqlDataReader Rdr;
            Service unServiceProduction;
            Service unServiceCommercial;
            
            Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandText = "select * from service;";
            Rdr = Cmd.ExecuteReader();
            while (Rdr.Read())
            {
                if (!Rdr.IsDBNull(3) && !Rdr.IsDBNull(4))
                {
                    unServiceProduction = new Service(Convert.ToInt32(Rdr["ser_id"]), Convert.ToString(Rdr["ser_designation"]), Convert.ToChar(Rdr["ser_type"]), Convert.ToString(Rdr["ser_produit"]), Convert.ToInt32(Rdr["ser_capacite"]));
                    LesServices.Add(unServiceProduction);
                }

                if (!Rdr.IsDBNull(5) && Rdr.IsDBNull(3) && Rdr.IsDBNull(4))
                {
                    unServiceCommercial = new Service(Convert.ToInt32(Rdr["ser_id"]), Convert.ToString(Rdr["ser_designation"]), Convert.ToChar(Rdr["ser_type"]), Convert.ToInt32(Rdr["ser_budget"]));
                    LesServices.Add(unServiceCommercial);
                }

                
            }
            Rdr.Close();
        }
        public void ChargerXml()
        {
        }

        /// <summary>
        /// Se connecter à la base de données;
        /// </summary>
        /// <returns></returns>
        public MySqlConnection ConnexionBDD()
        {
            string sCnx = "server=localhost;user=root;database=gesper;port=3306;password=siojjr";
            MySqlConnection Cnx = new MySqlConnection(sCnx);
            Cnx.Open();
            return Cnx;
        }
        public void deConnexionBDD(MySqlConnection Cnx)
        {
            Cnx.Close();
        }

        public void Sauver()
        {
        }
        public void SauverXml()
        {
        }

        public void ToutCharger(MySqlConnection Cnx)
        {
        }
        public void ToutSauvegarder(MySqlConnection Cnx)
        {
        }
        


    }
}
