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
    public partial class Stagaire : Form
    {
        public Stagaire()
        {
            InitializeComponent();
           
           
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter AD;
        private void Stagaire_Load(object sender, EventArgs e)
        {
          
            while (this.radGridView1.Rows.Count > 0)
            {
                this.radGridView1.Rows.RemoveAt(this.radGridView1.Rows.Count - 1);
            } 
                 
           AD  = new SqlDataAdapter("select * from stagaires", cnx);
            AD.Fill(ds, "stagaires");

            radGridView1.DataSource = ds.Tables["stagaires"];
           

            
 

            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mn = new MainMenu();
            mn.MdiParent = this.MdiParent;
            mn.Size = this.MdiParent.Size;
            mn.Dock = this.Dock;
            this.Close();
            mn.Show();
            
        }

     

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StagaireAjoute sg = new StagaireAjoute();
            sg.ShowDialog();
            Stagaire_Load(sender, e);
        }

   

       

        private void radGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void radGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            StagaireModifciation sm = new StagaireModifciation();
            sm.txtNUMINSCRIPTION.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
            sm.txtNOM.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            sm.txtPRENOM.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
            sm.txtARABENOM.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
            sm.txtARABEPRENOM.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();    
         
            sm.txtLIEU.Text = radGridView1.CurrentRow.Cells[6].Value.ToString();
            sm.txtCIN.Text = radGridView1.CurrentRow.Cells[7].Value.ToString();
            sm.txtADRESSE.Text = radGridView1.CurrentRow.Cells[8].Value.ToString();
            sm.txtTEL.Text = radGridView1.CurrentRow.Cells[9].Value.ToString();
          
            sm.cmbJOUR.Text = radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(0, 2);
            sm.cmbMOIS.Text=radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(3, 2);
            sm.cmbANNES.Text=radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(6, 4);
            sm.ShowDialog();
            Stagaire_Load(sender, e);
            

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

          


            
        }

        private void txtRECHERCHE_TextChanged(object sender, EventArgs e)
        {

            radGridView1.DataSource = new string[0];
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            if (radNOM.Checked == true)
            {
                cmd.CommandText = "select * from stagaires where Nom like '" + txtRECHERCHE.Text + "%'";
            }
            else
            {

                cmd.CommandText = "select * from stagaires where num_CIN like '" + txtRECHERCHE.Text + "%'";

            }
            SqlDataReader da = cmd.ExecuteReader();

            radGridView1.DataSource = da;
            while (da.Read())
            {
                radGridView1.Rows.Add(da[0]);

            }
            cnx.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Veuillez Selection Au moins un stagaires", "Aucune Selection sur la liste des stagaires", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {

            if( MessageBox.Show(this,"Vous Voulez Vraiment Supprimer Ce Stagaire ?","",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes)
            { 
                string rowSlection = radGridView1.CurrentRow.Cells[0].Value.ToString();
               
                for (int i = 0; i < ds.Tables["stagaires"].Rows.Count-1;i++ )
                {
               
                   
                    if (rowSlection==ds.Tables["stagaires"].Rows[i][0].ToString())
                    {


                        ds.Tables["stagaires"].Rows.RemoveAt(i);
                       
                    }
                }
                

                
                SqlCommandBuilder sql = new SqlCommandBuilder(AD);
                AD.Update(ds,"stagaires");
                ds.AcceptChanges();
              
                Stagaire_Load(sender, e);
                
               

            }
            }

        }

 
    }
}
