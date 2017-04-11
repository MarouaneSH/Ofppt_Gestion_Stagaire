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
    public partial class FILLIERE : Form
    {
        public FILLIERE()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");

        DataSet ds = new DataSet();
        SqlDataAdapter adFilliere;

        private void FILLIERE_Load(object sender, EventArgs e)
        {
            while (this.radGridView1.Rows.Count > 0)
            {
                this.radGridView1.Rows.RemoveAt(this.radGridView1.Rows.Count - 1);
            }

            adFilliere = new SqlDataAdapter("select * from Flr_nbr_groupe", cnx);
            adFilliere.Fill(ds, "Flr_nbr_groupe");
            radGridView1.DataSource = ds.Tables["Flr_nbr_groupe"];
           


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FILLIEREajoute fj = new FILLIEREajoute();
           
            fj.Show();
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
