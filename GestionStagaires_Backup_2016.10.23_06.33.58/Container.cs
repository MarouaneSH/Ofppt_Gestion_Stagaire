using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionStagaires
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();
        }
        //Forms
        MainMenu mn; // FORM ofppt
        Stagaire sg; //Fomr Stgaire
        Inscription inst;// Form Insciption


        public void FermerFormulaire()
        {
            mn.Close();
            if(sg != null)
            {
                sg.Close();
            }
            if (inst != null)
            {
                inst.Close();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            mn = new MainMenu();
            mn.MdiParent = this;
            mn.Size = mn.MdiParent.Size;
            mn.Dock = DockStyle.Fill;
            mn.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Left == 13)
            {
                pictureBox2.Left = 169;
            }
            else
            {
                pictureBox2.Left = 13;
            }

            if (metroPanel1.Width == 209)
            {
                metroPanel1.Width = 60;
            }
            else
            {
                metroPanel1.Width = 209;
            }
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (pictureBox2.Left == 13)
            {
                pictureBox2.Left = 169;
            }
            else
            {
                pictureBox2.Left = 13;
            }

            if (metroPanel1.Width == 209)
            {
                metroPanel1.Width = 60;
            }
            else
            {
                metroPanel1.Width = 209;
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
         

            FermerFormulaire();
            inst = new Inscription();
            inst.MdiParent = this;
            inst.Size = this.Size;
            inst.Dock = DockStyle.Fill;
            inst.Show();

          
        
        }

        private void btnSTAGAIRE_Click(object sender, EventArgs e)
        {
           
            FermerFormulaire();
            sg = new Stagaire();
            sg.MdiParent = this;
            sg.Size = this.Size;
            sg.Dock = DockStyle.Fill;
            sg.Show();
        }

        private void btnFILLIERE_Click(object sender, EventArgs e)
        {
            FILLIERE fl = new FILLIERE();
            fl.MdiParent = this;
            fl.Size = this.Size;
            fl.Dock = DockStyle.Fill;
            fl.Show();
        }

       
        
    }
}
