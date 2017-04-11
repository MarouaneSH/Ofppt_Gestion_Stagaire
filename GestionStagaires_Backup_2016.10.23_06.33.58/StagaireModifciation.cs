using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Data.SqlClient;

namespace GestionStagaires
{
    public partial class StagaireModifciation : MetroFramework.Forms.MetroForm
    {
        public StagaireModifciation()
        {
            InitializeComponent();
        }

        private void StagaireModifciation_Load(object sender, EventArgs e)
        {



            int i = 1982;
            while (i <= 2016)
            {
                cmbANNES.Items.Add(i);
                i++;
            }
            i = 1;
            while (i <= 31)
            {
                if (i < 10)
                {
                    cmbJOUR.Items.Add("0" + i);
                }
                else
                {
                    cmbJOUR.Items.Add(i);
                }

                i++;
            }

            i = 0;
            while (i <= 12)
            {
                if (i < 10)
                {
                    cmbMOIS.Items.Add("0" + i);
                }
                else
                {
                    cmbMOIS.Items.Add(i);
                }

                i++;
            }
        }
        public int getCNSS()
        {
            if (cnssSTATUS.Text == "OUI")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string getDateNaissance()
        {
            return cmbJOUR.Text + "/" + cmbMOIS.Text + "/" + cmbANNES.Text;
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int cnss=0;
            if(cnssSTATUS.Text=="OUI")
            {
                cnss=1;
            }
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "update stagaires set Nom = @NOM ,Prenom =@Prenom,NomArabe = @NomArabe,prenomArabe = @PrenomArab,datenaissance =@date,LieuNaissance = @Lieu,num_CIN=@CIN,Adresse =@Adress,tel=@Tel,CNSS=@CNSS where Num_INS = @NUMins";
            
         cmd.Parameters.Add("@NUMins", txtNUMINSCRIPTION.Text);
                             cmd.Parameters.Add("@Nom",txtNOM.Text);
                            cmd.Parameters.Add("@Prenom",txtPRENOM.Text);
                            cmd.Parameters.Add("@NomArabe",txtARABENOM.Text);
                            cmd.Parameters.Add("@PrenomArab",txtARABEPRENOM.Text);
                            cmd.Parameters.Add("@date",getDateNaissance());
                            cmd.Parameters.Add("@Lieu",txtLIEU.Text);
                            cmd.Parameters.Add("@CIN",txtCIN.Text);
                            cmd.Parameters.Add("@Adress",txtADRESSE.Text);
                            cmd.Parameters.Add("@Tel",txtTEL.Text);
                            cmd.Parameters.Add("@CNSS",getCNSS());
            
            cmd.ExecuteNonQuery();
            cnx.Close();
            MetroMessageBox.Show(this, "Le Stagaires a été bien  Modifier.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.Close();
        }
    }
}
