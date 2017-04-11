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
    public partial class Inscription : Form
    {
        public Inscription()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");

        private void Inscription_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter AD = new SqlDataAdapter("select * from stagaires", cnx);
            AD.Fill(ds, "stagaires");

            radGridView1.DataSource = ds.Tables["stagaires"];
           
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            InscriptionAjout insAJout = new InscriptionAjout();
            insAJout.MdiParent = this.MdiParent;
            insAJout.Size = this.Size;
            insAJout.Dock = DockStyle.Fill;
            insAJout.Show();
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(1);
        }
    }
}
