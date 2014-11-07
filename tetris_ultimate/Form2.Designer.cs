namespace tetris_ultimate
{
    partial class FenetreDemarrePartie
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
            this.listeSon = new System.Windows.Forms.ComboBox();
            this.nomJoueur = new System.Windows.Forms.TextBox();
            this.Demarrer = new System.Windows.Forms.Button();
            this.Nom = new System.Windows.Forms.Label();
            this.Musique = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listeSon
            // 
            this.listeSon.FormattingEnabled = true;
            this.listeSon.Location = new System.Drawing.Point(114, 76);
            this.listeSon.Name = "listeSon";
            this.listeSon.Size = new System.Drawing.Size(121, 21);
            this.listeSon.TabIndex = 0;
            // 
            // nomJoueur
            // 
            this.nomJoueur.Location = new System.Drawing.Point(114, 50);
            this.nomJoueur.Name = "nomJoueur";
            this.nomJoueur.Size = new System.Drawing.Size(121, 20);
            this.nomJoueur.TabIndex = 1;
            // 
            // Demarrer
            // 
            this.Demarrer.Location = new System.Drawing.Point(89, 126);
            this.Demarrer.Name = "Demarrer";
            this.Demarrer.Size = new System.Drawing.Size(75, 23);
            this.Demarrer.TabIndex = 2;
            this.Demarrer.Text = "Demarrer";
            this.Demarrer.UseVisualStyleBackColor = true;
            this.Demarrer.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nom
            // 
            this.Nom.AutoSize = true;
            this.Nom.Location = new System.Drawing.Point(26, 53);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(29, 13);
            this.Nom.TabIndex = 3;
            this.Nom.Text = "Nom";
            // 
            // Musique
            // 
            this.Musique.AutoSize = true;
            this.Musique.Location = new System.Drawing.Point(29, 76);
            this.Musique.Name = "Musique";
            this.Musique.Size = new System.Drawing.Size(47, 13);
            this.Musique.TabIndex = 4;
            this.Musique.Text = "Musique";
            // 
            // FenetreDemarrePartie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(284, 198);
            this.Controls.Add(this.Musique);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.Demarrer);
            this.Controls.Add(this.nomJoueur);
            this.Controls.Add(this.listeSon);
            this.Location = new System.Drawing.Point(20, 20);
            this.MaximumSize = new System.Drawing.Size(300, 237);
            this.MinimumSize = new System.Drawing.Size(300, 237);
            this.Name = "FenetreDemarrePartie";
            this.Text = "Nouvelle partie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Demarrer;
        private System.Windows.Forms.Label Nom;
        private System.Windows.Forms.Label Musique;
        public System.Windows.Forms.ComboBox listeSon;
        public System.Windows.Forms.TextBox nomJoueur;
    }
}