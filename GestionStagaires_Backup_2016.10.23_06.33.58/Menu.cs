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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void Menu_MouseHover(object sender, EventArgs e)
        {
     
        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
           
            Stagaire sg = new Stagaire();
            sg.MdiParent = this.MdiParent;
            this.Close();
            sg.Size = sg.MdiParent.Size;
            sg.Dock = DockStyle.Fill;
            sg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    metroTile1.Style = MetroColorStyle.Magenta;
       
           
        }

        private void Menu_Load(object sender, EventArgs e)
        {
                string MaxStagaire = "150/2016";  //get last Num Stagiare



                string numerau = MaxStagaire.Remove(3);  // Avoir le num complet d'inscirption
                int k = int.Parse(numerau);
                k = k + 1;
                if(k<10)
                {
                    numerau = "00" + k.ToString() + "/2016";
                }
                else if(k<100)
                {
                    numerau = "0" + k.ToString() + "/2016";
                }
                else
                {
                    numerau = k.ToString() + "/2016";
                }
                
            
        }
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-30T9GB1;Initial Catalog=Gst_COURSDESOIR;Integrated Security=True");

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
    }
}
