namespace GestionStagaires
{
    partial class InscriptionAjout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radListView1
            // 
            this.radListView1.GroupItemSize = new System.Drawing.Size(200, 40);
            this.radListView1.ItemSize = new System.Drawing.Size(200, 40);
            this.radListView1.Location = new System.Drawing.Point(37, 133);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(264, 375);
            this.radListView1.TabIndex = 0;
            this.radListView1.Text = "radListView1";
            this.radListView1.ThemeName = "TelerikMetroTouch";
            // 
            // InscriptionAjout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(647, 554);
            this.Controls.Add(this.radListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InscriptionAjout";
            this.Text = "InscriptionAjout";
            this.Load += new System.EventHandler(this.InscriptionAjout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView radListView1;
    }
}