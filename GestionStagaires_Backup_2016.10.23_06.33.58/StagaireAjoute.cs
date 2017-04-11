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
    public partial class StagaireAjoute : MetroFramework.Forms.MetroForm
    {
        public StagaireAjoute()
        {
            InitializeComponent();
        }

        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");

        private void StagaireAjoute_Load(object sender, EventArgs e)
        {
            txtNUMINSCRIPTION.Text = GetNewNumInscirption();
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


        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(MetroMessageBox.Show(this, "Voulez Vous  vraiment annuler l'ajout ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
             if(cnssSTATUS.Text=="NON")
             {
                 cnssSTATUS.Text = "OUI";
             }
             else
             {
                 cnssSTATUS.Text = "NON";
             }
        }

        SqlCommand cmd = new SqlCommand();
        
        public string  GetNewNumInscirption()
        {
            cnx.Open();
            cmd.Connection=cnx;

            //Selection de La Derniere Numerau de Table Stagiare
            cmd.CommandText = "SELECT TOP 1 Num_INS FROM stagaires ORDER BY Num_INS DESC";

            //get last Num Stagiare Exemple(001/2016)
            string MaxStagaire = cmd.ExecuteScalar().ToString();  

            //Get Annes de formation Actuel Exemple(2016)
            cmd.CommandText="SELECT TOP 1 AnneFormation FROM Anneé ORDER by AnneFormation DESC";
            string annesFormation = cmd.ExecuteScalar().ToString();


            // Avoir le num complet d'inscirption Exemple 001
            string numerau = MaxStagaire.Remove(3);
  
            //Incrementer Le Num D'incription Exemple 2
            int k = int.Parse(numerau);
            k = k + 1;


            if (k < 10)
            {
                numerau = "00" + k.ToString() + "/"+ annesFormation;
            }
            else if (k < 100)
            {
                numerau = "0" + k.ToString() + "/" +  annesFormation;
            }
            else
            {
                numerau = k.ToString() + "/" + annesFormation;
            }

            cnx.Close();

            //Return numerau Exmple : 002/2016
            return numerau;
        }


        public string getDateNaissance()
        {
            return cmbJOUR.Text + "/" + cmbMOIS.Text + "/"+cmbANNES.Text;
        }

        public int getCNSS()
        {
            if(cnssSTATUS.Text=="OUI")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void emptyText()
        {
            txtADRESSE.Clear();
            txtARABENOM.Clear();
            txtARABEPRENOM.Clear();
            txtCIN.Clear();
            txtLIEU.Clear();
            txtNOM.Clear();
            txtNUMINSCRIPTION.Clear();
            txtPRENOM.Clear();
            txtTEL.Clear();
            cmbANNES.Text = "";
            cmbJOUR.Text="";
            cmbMOIS.Text = "";
           
        }

        
        public bool Verify()
        {
             
            if(txtADRESSE.Text =="" || txtARABENOM.Text =="" ||txtARABEPRENOM.Text =="" ||txtCIN.Text =="" ||txtLIEU.Text =="" ||txtNOM.Text =="" ||txtPRENOM.Text =="" ||txtTEL.Text =="" || cmbANNES.Text =="" ||cmbJOUR.Text =="" ||cmbMOIS.Text =="")
            {
                MetroMessageBox.Show(this, "Vous Devez Remplir Tous Les champs obligatoire", "Remplissage Des Champs", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;

            }
            else
            {
                int i;
                if(int.TryParse(txtTEL.Text,out i))
                {
                    return true;
                }
                else{
                 MetroMessageBox.Show(this, "Numerau De Telephone Est Invalide", "Incorrect Saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
            }

        }


        private void btnAJOUT_Click(object sender, EventArgs e)
        {

            if(Verify())
            { 
                        cnx.Open();
                        cmd.Connection = cnx;

           
                     /*   cmd.CommandText = "insert into stagaires values ('"
                            + txtNUMINSCRIPTION.Text + "','"
                            + txtNOM.Text + "','"
                            + txtPRENOM.Text + "','"
                            + txtARABENOM.Text + "','"
                            + txtARABEPRENOM.Text + "','"
                            + getDateNaissance() + "','"
                            + txtLIEU.Text + "','"
                            + txtCIN.Text + "','"
                            + txtADRESSE.Text + "',"
                            + txtTEL.Text + ","
                            + getCNSS() + ");";*/

                        cmd.CommandText = "insert into stagaires values (@NUMins,@Nom,@Prenom,@NomArabe,@PrenomArab,"
                            + "@date,@Lieu,@CIN,@Adress,@Tel,@CNSS);";

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
       
            
                        if (MetroMessageBox.Show(this, "Vous Voulez Ajouter un autre stagaires ?.", "Le Stagaires a été ajouter avec succes", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            emptyText();

                        }
                        else
                        {
                            this.Close();
                        }


            }



        }

       
      
    }
}
