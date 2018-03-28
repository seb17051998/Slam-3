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
    public partial class Fm_service : Form
    {
        private Donnees bd;
        public Fm_service(Donnees p_bd,MySqlConnection Cnx)
        {
            InitializeComponent();
            bd = p_bd;
        }
    }
}
