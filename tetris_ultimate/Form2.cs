using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tetris_ultimate
{
    public partial class FenetreDemarrePartie : Form
    {
        public FenetrePrincipale Parent;
        public FenetreDemarrePartie(FenetrePrincipale parent)
        {
            InitializeComponent();
            Parent = parent;
            listeSon.Items.Add("Tetris");
            listeSon.Items.Add("Psy");
            listeSon.Items.Add("Pio");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!nomJoueur.Text.Equals("") && (listeSon.SelectedItem!=null))
            {
                String son = listeSon.SelectedItem.ToString();
                Parent.setNomJoueur(nomJoueur.Text);
                Parent.chrono.Start();
                if (son.Equals("Tetris"))
                {

                    Parent.music.SoundLocation = @"tetris.wav";

                }
                else
                {
                    if (son.Equals("Pio"))
                        Parent.music.SoundLocation = @"pio.wav";
                    else
                        if (son.Equals("Psy"))
                            Parent.music.SoundLocation = @"psy.wav";
                }
                Parent.music.PlayLooping();
                Dispose();
            }
        }
    }
}
