using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;

namespace tetris_ultimate
{
    
    public partial class FenetrePrincipale : Form
    {
        public SoundPlayer music;
        private Assembly _Assembly;
        private StreamReader fichier;
        private StreamWriter fichier1;
        private Grille espaceDechute;
        private Color[] tabCouleur;
        private int generateurCouleur = 0;
        private int pause = 0;
        private int finPartie = 0;
        private int score1;
        private int score2;
        private int score3;
        private int record;
        private FenetreDemarrePartie enregistrement;



        public FenetrePrincipale()
        {
            espaceDechute = new Grille();
            tabCouleur = new Color[7];
            music = new SoundPlayer();
            //tableau de couleur qui va nous permettre de générer 
            //la couleur avec laquelle on va initialiser le te
            //tromino suivant
            tabCouleur[0] = Color.Gray;
            tabCouleur[1] = Color.Brown;
            tabCouleur[2] = Color.Magenta;
            tabCouleur[3] = Color.Blue;
            tabCouleur[4] = Color.Red;
            tabCouleur[5] = Color.Cyan;
            tabCouleur[6] = Color.Green;
            dessiner();
            //initilisation des composantes graphiques
            InitializeComponent();
            chrono.Stop();
            //formulaire 2
            enregistrement = new FenetreDemarrePartie(this);
            enregistrement.ShowDialog();
            labelPause.Hide();
            labelPerdu.Hide();
          
            /*//combobox
            comboBox1.Items.Add("Tetris");
            comboBox1.Items.Add("Psy");
            comboBox1.Items.Add("Pio");

            //initilisation du score et du niveau
            textScore.Text = "Score   " + espaceDechute.Score.ToString();
            textNiveau.Text = "Niveau " + espaceDechute.niveau;
            label1.Hide();
            //on arrête le chrono
            chrono.Stop();*/
         
            //initialisation du tétromino

        }
        
        //ACCESSEURS ET MUTATEURS
        public void setNomJoueur(String nom)
        {
            affichageNom.Text = nom;
        }
        public void dessiner()
        {

            // On crée et on initialise le buffer graphique
            BufferedGraphics bg = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), ClientRectangle);
            
            // On crée un objet de type graphique lié au buffer graphique
            Graphics g = bg.Graphics;
            
            
            // On rempli de blanc la surface graphique
            g.Clear(Color.Beige);
            // On dessine les objets graphiques de la liste dans le buffer
            // graphique en mémoire pour éviter les problèmes de scintillements
            int x = 0;
            int y = 0;

            //on affiche le tetromino courant;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (espaceDechute.courant.listCases[i, j].getColor() != Color.White)
                    {
                        x = espaceDechute.courant.listCases[i, j].getIndiceX();
                        y = espaceDechute.courant.listCases[i, j].getIndiceY();
                        espaceDechute.grille[x, y].setColor(espaceDechute.courant.couleur);
                    } 
                }
            }

            //on affiche toute la grille
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 22; j++)
                    //if (espaceDechute.grille[i, j].getColor() != Color.White)
                    {
                        espaceDechute.grille[i, j].dessiner(g);
                    }
            

            // Affichage du buffer à l'écran
            bg.Render();
            // On libère les objets graphique
            g.Dispose();
            bg.Dispose();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            finPartie =espaceDechute.finDePartie();
            if (finPartie!=1)
            {

                dessiner();
                if (espaceDechute.testDescente() == 1)
                {
                    chrono.Interval = 1000 / (espaceDechute.niveau + 1);
                    espaceDechute.descenteTetrominoCourant();
                }
                else
                {
                    
                    generateurCouleur = Hasard.RandomWithMax(6);
                    espaceDechute.supprimerLigne();
                    espaceDechute.courant.intialiser(0, 0, espaceDechute.suivant.couleur, 1);
                    espaceDechute.suivant.intialiser(0, 0, tabCouleur[generateurCouleur], 1);
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                        {
                            int x =espaceDechute.suivant.listCases[i, j].getCointSuperieurGauche().X + 10 ;
                            int y =espaceDechute.suivant.listCases[i, j].getCointSuperieurGauche().Y + 110;
                            espaceDechute.suivant.listCases[i, j].setCoinSuperieurGauche(new Point(x, y));
                        } 
                    textScore.Text = "Score " + espaceDechute.Score.ToString();
                    textNiveau.Text = "Niveau " + espaceDechute.niveau;
                    panel1.Refresh();
                }
            }
            else
            {
                
                chrono.Stop();
                labelPerdu.Show();
                dessiner();
                music.Stop();

                //imbriquer les if elseif
                if (espaceDechute.Score >= score1)
                    record = 1;
                else
                    if (espaceDechute.Score >= score2)
                        record = 2;
                    else 
                        if (espaceDechute.Score >= score3)
                            record = 3;
                this.OnLoad(new EventArgs());
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            finPartie = espaceDechute.finDePartie();
            if ((pause == 0)&&(finPartie==0))
            {
                switch (e.KeyData)
                {
                    case Keys.Right:
                        if (espaceDechute.testDeplacerDroite() == 1)
                        {
                            espaceDechute.deplaceDroite();
                            dessiner();
                        }
                        break;
                    case Keys.Left:
                        if (espaceDechute.testDeplacerGauche() == 1)
                        {
                            espaceDechute.deplacerGauche();
                            dessiner();
                        }
                        break;
                    case Keys.Down:
                        if (espaceDechute.testDescente() == 1)
                        {
                            espaceDechute.descenteTetrominoCourant();
                            dessiner();
                        }
                        break;
                    case Keys.Up:
                        if (espaceDechute.testChangerPosition() == 1)
                        {
                            espaceDechute.changerPosition();
                            dessiner();
                        }
                        break;
                    case Keys.P:
                        pause = 1;
                        chrono.Stop();
                        labelPause.Show();
                        music.Stop();
                        dessiner();
                        break;
                }
                
            }
            else
            {
                if (e.KeyData == Keys.P)
                {
                    pause = 0;
                    chrono.Start();
                    labelPause.Hide();
                    music.Play();
                    dessiner();
                }
            }
        }
        
        /*private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _Assembly = Assembly.GetExecutingAssembly();
                if(record==0)
                {
                fichier = new StreamReader(@"record.txt");
                textBox1.Text = fichier.ReadLine();
                score1= Convert.ToInt32(fichier.ReadLine());
                textBox1.Text += score1;
                textBox2.Text = fichier.ReadLine();
                score2 = Convert.ToInt32(fichier.ReadLine());
                textBox2.Text += score2;
                textBox3.Text = fichier.ReadLine();
                score3 = Convert.ToInt32(fichier.ReadLine());
                textBox3.Text += score3;
                fichier.Close();
               
                }
                else
                {
                    fichier1 = new StreamWriter(@"record.txt");
                    if (record == 1)
                    {
                        
                        fichier1.WriteLine(affichageNom.Text);
                        fichier1.WriteLine(espaceDechute.Score);
                        fichier1.WriteLine(textBox2.Text);
                        fichier1.WriteLine(textBox3.Text);
                    }
                    else
                        if (record == 2)
                        {

                            fichier1.WriteLine(affichageNom.Text);
                            fichier1.WriteLine(espaceDechute.Score);
                            fichier1.WriteLine(textBox2.Text);
                            fichier1.WriteLine(textBox3.Text);
                        }
                        else
                            if (record == 3)
                            {

                                fichier1.WriteLine(affichageNom.Text);
                                fichier1.WriteLine(espaceDechute.Score);
                                fichier1.WriteLine(textBox2.Text);
                                fichier1.WriteLine(textBox3.Text);
                            }
                    fichier1.Close();
                }
            }
            catch
            {
                MessageBox.Show("impossible d'ouvrir le fichier");
            }
        }*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //BufferedGraphics bgPanel = BufferedGraphicsManager.Current.Allocate(panel1.CreateGraphics(), ClientRectangle);
            Graphics gPanel = e.Graphics;
            
            gPanel.Clear(Color.YellowGreen);
            //on affiche le tetromino suivant;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if(espaceDechute.suivant.listCases[i, j].getColor()!=Color.White)
                        espaceDechute.suivant.listCases[i, j].dessiner(gPanel);
         
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enregistrement = new FenetreDemarrePartie(this);
            enregistrement.Visible = true;
            music.Stop();
            espaceDechute = new Grille();
            dessiner();
            chrono.Stop();
        }  
    }

    public class Hasard
    {
        // Objet utilisé pour le random
        private static Random m_Random = new Random();
        /// <summary>
        /// Calcul un nombre aléatoire entre 0 et Max
        /// </summary>
        /// <param name="max">Maximum que peut atteindre le random</param>
        /// <returns>Retourne un nombre aléatoire entre 0 et Max, ou bien "max" si max n'est pas plus grand que 0</returns>
        public static int RandomWithMax(int max)
        {
            return max > 0 ? Hasard.m_Random.Next(max + 1) : max;
        }
        /// <summary>
        /// Calcul un nombre aléatoire entre Min et 0
        /// </summary>
        /// <param name="max">Minimum que peut atteindre le random (negatif)</param>
        /// <returns>Retourne un nombre aléatoire entre Min et 0, ou bien Min si min n'est pas plus petit que 0</returns>
        public static int RandomWithMin(int min)
        {
            return min < 0 ? -Hasard.m_Random.Next(-min + 1) : min;
        }
        /// <summary>
        /// Calcul un nombre aléatoire entre StartVal et StartVal+etendue
        /// </summary>
        /// <param name="startVal">Valeur de départ, l'une des bornes du random</param>
        /// <param name="etendue">Écart positif ou négatif entre les 2 bornes du random</param>
        /// <returns>Retourne un nombre aléatoire entre Min et Max</returns>
        public static int RandomWithLength(int startVal, int etendue)
        {
            if (etendue == 0)
                return etendue;
            else
                return startVal + etendue > 0 ? Hasard.m_Random.Next(etendue) : -Hasard.m_Random.Next(-etendue);
        }
        /// <summary>
        /// Calcul un nombre aléatoire entre Min et Max
        /// </summary>
        /// <param name="min">Borne inférieure du random</param>
        /// <param name="max">Borne supérieure du random</param>
        /// <returns>Retourne un nombre aléatoire entre Min et Max</returns>
        public static int RandomMinMax(int min, int max)
        {
            if (min == max)
                return min;
            int theMin = Math.Min(min, max);
            int theMax = Math.Max(min, max);
            return min + Hasard.m_Random.Next((max - min) + 1);
        }
        /// <summary>
        /// Calcul une valeur aléatoire entre true et false
        /// </summary>
        /// <returns>Retourne aléatoirement true ou false</returns>
        public static bool RandomBool()
        {
            return Hasard.m_Random.Next(2) == 0;
        }
    } 
}
