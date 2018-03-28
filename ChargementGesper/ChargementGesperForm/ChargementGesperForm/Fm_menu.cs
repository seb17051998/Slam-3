using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libGesper;
using MySql.Data.MySqlClient;

namespace ChargementGesperForm
{
    public partial class Fm_menu : Form
    {
        private Donnees bd;
        MySqlConnection Cnx = new MySqlConnection();
        public Fm_menu()
        {
            InitializeComponent();
            bd = new Donnees();
            Cnx = bd.ConnexionBDD();
            bd.ToutCharger(Cnx);
            this.bt_employes.Click += new EventHandler(bt_employes_Click);
            this.bt_services.Click += new EventHandler(bt_services_Click);
            this.bt_diplomes.Click += new EventHandler(bt_diplomes_Click);
        }

        void bt_services_Click(object sender, EventArgs e)
        {
            Fm_service fsce = new Fm_service(bd,Cnx);
            fsce.ShowDialog();

        }

        void bt_employes_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void bt_diplomes_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
