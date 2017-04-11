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
using MetroFramework;
using MetroFramework.Forms;
namespace GestionStagaires
{
    public partial class FILLIEREajoute : Form
    {
        public FILLIEREajoute()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter adNIVEAUX;

        private void Niveau_Load(object sender, EventArgs e)
        {
          


            
            adNIVEAUX = new SqlDataAdapter("select * from niveaux", cnx);
            adNIVEAUX.Fill(ds, "niveaux");
            cmbNIveaux.DataSource = ds.Tables["niveaux"];
            cmbNIveaux.ValueMember = "code_niveaux";
            cmbNIveaux.DisplayMember= "niveau";


        }

        private void txtCODEFILLERE_TextChanged(object sender, EventArgs e)
        {
            cbmGROUPE.Items.Clear();
            cbmGROUPE.Items.Add(txtCODEFILLERE.Text + "101");
            cbmGROUPE.Items.Add(txtCODEFILLERE.Text + "102");
            cbmGROUPE.Items.Add(txtCODEFILLERE.Text + "103");



        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void lblGrp2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Label lbl = new Label();
            lbl.Enabled = true;
            lbl.Text = "dsdsds";
            lbl.Left = 0;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into filieres values ('" + txtCODEFILLERE.Text + "','" + txtFILLIERE.Text + "','" + cmbNIveaux.SelectedValue.ToString()+ "');";
            MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();

            cmd.CommandText="select TOP 1 * from Anneé order by AnneFormation DESC";
            //Get Last Annes From Table Annes
            string AnnesActuel = cmd.ExecuteScalar().ToString();

            for(int i =0;i<cbmGROUPE.Items.Count;i++)
            {
                cmd.CommandText = "insert into groupes values ('" + cbmGROUPE.Items[i].ToString() + "','" + AnnesActuel + "','" + txtCODEFILLERE.Text + "');";
                cmd.ExecuteNonQuery();
            }

            cnx.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

          MessageBox.Show(this,"hh","sddssds",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Label namelabel = new Label();
            namelabel.Location = new Point(13, 13);
            namelabel.Text = "zeze";
            namelabel.AutoSize = true;
        }

     
        

     
    }
}
