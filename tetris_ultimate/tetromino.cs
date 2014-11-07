using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace tetris_ultimate
{
    class tetromino
    {
        //Attributs
        public Case[,] listCases;
        public Color couleur;
        public int position;
        public int stopDescente;
        

        public bool testDeplacer;

        //Constructeur qui initialise un tetromino
        //la position d'un tetromino est donnée par celle de sa case située à l'extrémité gauche,
        //en haut
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">a: est la position x de la case à l'extrémité gauche en haut</param>
        /// <param name="b">b: est la position y de la case à l'extrémité gauche en haut</param>
        /// <param name="c">c: est la couleur du tetromino</param>
        /// <param name="t">t: est le type du tétromino</param>
        public tetromino(int a, int b, Color c, int pos)
        {
            listCases = new Case[4, 4];
            //Les positions des case doivent être consécutives
            //Initialisation des cases 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    listCases[i, j] = new Case(new Point(20 * i, 20 * j), 19, 19, Color.White);
                    listCases[i, j].setIndiceX(i);
                    listCases[i, j].setIndiceY(j);
                }
            }
            couleur = c;
            position = pos;
            testDeplacer = true;
            if (c == Color.Gray)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 1, 1, 1, 2, 1, 2, 0);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 2);
                }
                if (position == 3)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 0, 1);
                }


                if (position == 4)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 1, 1, 1, 2);
                }

            }


            if (c == Color.Magenta)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 2, 1);
                }


                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 1, 1, 1, 2, 0, 2);
                }


                if (position == 3)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 1, 1, 2, 1);
                }

                if (position == 4)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 0);
                }

            }

            if (c == Color.Brown)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 1, 1);
                }


                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 1, 1, 1, 2, 0, 1);
                }

                if (position == 3)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 0, 1, 1, 1, 2, 1);
                }

                if (position == 4)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 1);
                }

            }

            if (c == Color.Blue)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 0, 1, 1, 1);
                }
                
            }
            if (couleur == Color.Red)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 1, 0, 2, 0, 0, 0, 3);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 3, 0);
                }
            }
            if (couleur == Color.Cyan)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 1, 1, 2, 1);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 0, 1, 1, 1, 0, 2);
                }
            }
            if (couleur == Color.Green)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 2, 0, 0, 1, 1, 1);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 1, 1, 1, 2);
                }
            }
        }


        //deplacer le tetromino
        public void deplacer(int sens)
        {
            if (sens == 1)//test si on peut se deplacer à droite
            {

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        listCases[i, j].droite();
            }
            if (sens == 0)//test si on peut se deplacer à gauche
            {

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        listCases[i, j].gauche();
            }
        }


        public void changerPosition()
        {
            if (listCases[0, 3].getIndiceY() < 22)
            {
                //si on est à la position 4, on réinitialise position à 4
                if ((couleur == Color.Gray) || (couleur == Color.Magenta) || (couleur == Color.Brown))
                {
                    if (position == 4)
                    {
                        position = 1;
                    }
                    else
                    {
                        position += 1;
                    }
                }
                if (couleur == Color.Blue)
                {
                    position = 1;
                }
                if ((couleur == Color.Red)||(couleur == Color.Cyan)||(couleur == Color.Green))
                {
                    if (position == 2)
                        position = 1;
                    else
                        position += 1;
                }

                if (couleur == Color.Gray)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 1, 1, 1, 2, 1, 2, 0);
                    }
                    if (position == 2)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 2);
                    }
                    if (position == 3)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 1, 0, 2, 0, 0, 1);
                    }


                    if (position == 4)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 1, 0, 1, 1, 1, 2);
                    }

                }


                if (couleur == Color.Magenta)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 1, 0, 2, 0, 2, 1);
                    }


                    if (position == 2)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(1, 0, 1, 1, 1, 2, 0, 2);
                    }


                    if (position == 3)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 0, 1, 1, 1, 2, 1);
                    }

                    if (position == 4)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 0);
                    }

                }

                if (couleur == Color.Brown)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 1, 0, 2, 0, 1, 1);
                    }


                    if (position == 2)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(1, 0, 1, 1, 1, 2, 0, 1);
                    }

                    if (position == 3)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(1, 0, 0, 1, 1, 1, 2, 1);
                    }

                    if (position == 4)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 1);
                    }

                }

                if (couleur == Color.Blue)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 1, 0, 0, 1, 1, 1);
                    }
                    
                }

                if (couleur == Color.Red)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 1, 0, 2, 0, 0, 0, 3);
                    }
                    if (position == 2)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0, 0, 1, 0, 2, 0, 3, 0);
                    }
                }
                if (couleur == Color.Cyan)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0,0,1,0,1,1,2,1);
                    }
                    if (position == 2)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(1,0,0,1,1,1,0,2);
                    }
                }
                if (couleur == Color.Green)
                {
                    if (position == 1)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(1,0,2,0,0,1,1,1);
                    }
                    if (position == 2)
                    {
                        this.decoloreTetromino();
                        this.coloreTetromino(0,0,0,1,1,1,1,2);
                    }
                }
            }
        }

        //je crois que je ne l'ai pas utilisé
        public int caseColoreeExtremeDroite()
        {
            int[] tab = new int[4];
            int k;
            k = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (listCases[i, j].getColor() != Color.White)
                        tab[k] = listCases[i, j].getCointSuperieurGauche().X;
            return tab.Max();
        }


        //
        public int caseColoreePlusBas()
        {
            int[] tab = new int[4];
            int k;
            k = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (listCases[i, j].getColor() != Color.White)
                        // tab[k] = listCases[i, j].getY();
                        tab[k] = i;
            return tab.Max();
        }

        public void intialiser(int a, int b, Color c, int pos)
        {

            stopDescente = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    listCases[i, j] = new Case(new Point(20 * i, 20 * j), 19, 19, Color.White);
                }
            }

            //initialiser les indices
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    listCases[i, j] = new Case(new Point(20 * i, 20 * j), 19, 19, Color.White);
                    listCases[i, j].setIndiceX(3 + i);
                    listCases[i, j].setIndiceY(j);

                }
            }
            couleur = c;
            position = 1;
            if (couleur == Color.Gray)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 1, 1, 1, 2, 1, 2, 0);
                }



                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 2);
                }



                if (position == 3)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 0, 1);
                }

                if (position == 4)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 1, 1, 1, 2);
                }
            }


            if (couleur == Color.Magenta)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 2, 1);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 1, 1, 1, 2, 0, 2);
                }
                if (position == 3)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 1, 1, 2, 1);
                }
                if (position == 4)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 0);
                }
            }

            if (couleur == Color.Brown)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 1, 1);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 1, 1, 1, 2, 0, 1);
                }
                if (position == 3)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 0, 1, 1, 1, 2, 1);
                }
                if (position == 4)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 0, 2, 1, 1);
                }
            }

            if (couleur == Color.Blue)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 0, 1, 1, 1);
                }
                
            }
            if (couleur == Color.Red)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 1, 0, 2, 0, 0, 0, 3);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 2, 0, 3, 0);
                }
            }
            if (couleur == Color.Cyan)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 1, 0, 1, 1, 2, 1);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 0, 1, 1, 1, 0, 2);
                }
            }
            if (couleur == Color.Green)
            {
                if (position == 1)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(1, 0, 2, 0, 0, 1, 1, 1);
                }
                if (position == 2)
                {
                    this.decoloreTetromino();
                    this.coloreTetromino(0, 0, 0, 1, 1, 1, 1, 2);
                }
            }
        }

        //decolore le tétromino
        public void decoloreTetromino()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (listCases[i, j].getColor() != Color.White)
                        listCases[i, j].setColor(Color.White);
        }

        //colore les cases du tétromino
        public void coloreTetromino(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            listCases[x1, y1].setColor(couleur);
            listCases[x2, y2].setColor(couleur);
            listCases[x3, y3].setColor(couleur);
            listCases[x4, y4].setColor(couleur);
        }

        

    }
}
