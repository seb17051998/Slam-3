using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libGesper
{
    public class Diplome
    {
        /* Attributs privés*/
        private int id;
        private string libelle;        
        private List<Employe> lesEmployesDuDiplome;

        /* Accesseurs */
        /// <summary>
        /// accesseurs sur l'id du diplôme
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// accesseurs sur le libellé du diplôme
        /// </summary>
        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        /// <summary>
        /// accesseurs sur la liste des employés qui ont un diplomes
        /// </summary>
        public List<Employe> LesEmployesDuDiplome
        {
            get { return lesEmployesDuDiplome; }
            set { lesEmployesDuDiplome = value; }
        }
        /* Constructeur */
        public Diplome(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
            lesEmployesDuDiplome = new List<Employe>();
        }

        public string ToString(){
            return string.Format("IdDiplome: {0} Libellé du diplome: {1}", Id, Libelle);
        }

       
    }
}
