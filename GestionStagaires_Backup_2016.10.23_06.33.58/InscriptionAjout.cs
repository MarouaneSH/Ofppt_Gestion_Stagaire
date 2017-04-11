using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionStagaires
{
    public partial class InscriptionAjout : Form
    {
        public InscriptionAjout()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=vol;Integrated Security=True");

        private void InscriptionAjout_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter AD = new SqlDataAdapter("select * from avion", cnx);
            AD.Fill(ds, "pilote");

            radListView1.DataSource = ds.Tables["pilote"].Columns[0].ToString(); ;
        }
    }
}
