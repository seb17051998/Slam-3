using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace libGesper
{
    public class Service
    {
        /* attributs privés */
        private int id;
        private string designation;
        private char type;
        private string produit;
        private int capacite;
        private decimal budget;
        private List<Employe> lesEmployesDuService;

        
        /*                    Accesseurs                     */
        ///<summary>
        ///accesseur sur le numéro du service
        ///</summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        ///<summary>
        ///accesseur sur la désignation
        ///</summary>
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        ///<summary>
        ///accesseur sur le type service
        ///</summary>
        public char Type
        {
            get { return type; }
            set { type = value; }
        }

        ///<summary>
        ///accesseur sur le produit
        ///</summary>
        public string Produit
        {
            get { return produit; }
            set { produit = value; }
        }

        ///<summary>
        ///accesseur sur la capacité du service
        ///</summary>
        public int Capacite
        {
            get { return capacite; }
            set { capacite = value; }
        }

        ///<summary>
        ///accesseur sur le budget du service
        ///</summary>
        public decimal Budget
        {
            get { return budget; }
            set { budget = value; }
        }

        ///<summary>
        ///accesseur sur la liste des employés du service
        ///</summary>
        public List<Employe> LesEmployesDuService
        {
            get { return lesEmployesDuService; }
            set { lesEmployesDuService = value; }
        }

        /*               Constructeurs               */
        /// <summary>
        /// Constructeur d'un service de production
        /// </summary>
        /// <param name="id">n° service</param>
        /// <param name="designation">nom du service</param>
        /// <param name="type">produit fabriqué par le service</param>
        /// <param name="produit">produit fabriqué par le service</param>
        /// <param name="capacite">capacité de production du service</param>       
        public Service(int id, string designation, char type, string produit, int capacite)
        {
            this.id = id;
            this.designation = designation;
            this.type = type;
            this.produit = produit;
            this.capacite = capacite;
            this.budget = 0;
            LesEmployesDuService=new List<Employe>();

        }

        /// <summary>
        /// Constructeur d'un service commerciale
        /// </summary>
        /// <param name="id"></param>
        /// <param name="designation"></param>
        /// <param name="type"></param>
        /// <param name="budget"></param>
        public Service(int id, string designation, char type, decimal budget)
        {
            this.id = id;
            this.designation = designation;
            this.type = type;
            this.budget = budget;
            this.capacite = 0;
            this.produit = "";
            LesEmployesDuService = new List<Employe>();

        }

        public Service(string p, string designation)
        {
            this.produit = p;
            this.designation = designation;
        }

        /* Méthodes */

        public void MajElementXml(XmlDocument xmlDoc, XmlElement xmlLesServices)
        {

        }

        public void PreparerSuppression()
        {
        }

        public string ToString()
        {
            return string.Format("Numéro du service: {0} Désignation: {1} Type de service: {2} Produit: {3} Capacité du service: {4} Budget: {5}", Id, Designation, Type, Produit, Capacite, Budget);
        }

        
    }
}
