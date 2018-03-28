using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libGesper
{
    public class Employe
    {
        ///  <summary>
        ///  attributs privées
        ///  </summary>
        //Données membres
        private int id;
        private string nom;
        private string prenom;
        private char sexe;
        private byte cadre;
        private decimal salaire;
        private Service leService;


        private List<Diplome> lesDiplomes;

        

        
        /*Accesseurs*/
        /// <summary>
        /// Accesseur sur le numéro de l'employé
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Accesseur sur le nom de l'employé
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Accesseur sur le prénom de l'employé
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        /// <summary>
        /// Accesseur sur le sexe de l'employé
        /// </summary>
        public char Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }

        /// <summary>
        /// Accesseur sur le cadre de l'employé
        /// </summary>
        public byte Cadre
        {
            get { return cadre; }
            set { cadre = value; }
        }

        /// <summary>
        /// Accesseur sur le salaire de l'employé
        /// </summary>
        public decimal Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        /// <summary>
        /// Accesseur sur le service de l'employé
        /// </summary>
        internal Service LeService
        {
            get { return leService; }
            set { leService = value; }
        }

        /// <summary>
        /// Accesseur sur les diplômes de l'employé
        /// </summary>
        internal List<Diplome> LesDiplomes
        {
            get { return lesDiplomes; }
            set { lesDiplomes = value; }
        }
            
      

        /*Constructeur*/
        public Employe(int id, string nom, string prenom, char sexe, byte cadre, decimal salaire, Service leService)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.cadre = cadre;
            this.salaire = salaire;
            this.leService = leService;
        }

        public string ToString()
        {
            return string.Format("Id: {0} Nom: {1} Prénom: {2} Sexe: {3} Cadre: {4} Salaire: {5} Service: {6}", Id, Nom, Prenom, Sexe, Cadre, Salaire, LeService.Id);
        }
    }
}
