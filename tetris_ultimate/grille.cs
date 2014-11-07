using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace tetris_ultimate
{
    class Grille
    {
        //Attributs

        public Case[,] grille;
        public tetromino courant, suivant;
        public int NombreDeLigne;
        public int Score;
        public int niveau = 0;


        public Grille()
        {
            //initialisation de la grille de 220 cases
            grille = new Case[10, 22];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 22; j++)
                    grille[i, j] = new Case(new Point(20 * i + 1, 20 * j + 25), 19, 19, Color.White);
            //fin initialisation de la grille

            courant = new  tetromino(25, 25, Color.Red, 1);
            suivant = new tetromino(0, 0, Color.Blue, 1);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    int x = suivant.listCases[i, j].getCointSuperieurGauche().X + 10;
                    int y = suivant.listCases[i, j].getCointSuperieurGauche().Y + 110;
                    suivant.listCases[i, j].setCoinSuperieurGauche(new Point(x,y));
                }   

                    
            NombreDeLigne = 0;
            Score = 0;
        }

        //cette fonction permet de décolorer les cases de la grille colorer par le 
        //tetromino courant. Le decolorage permet d'afficher le tétromino courant.
        //et d'éviter les conflits de couleurs entre les cases colorées par le courant 
        //qui est entrain de descendre et les cases colorées lors de l'arrêt définitif
        //du tétromino.
        public void decoloreCaseCourante()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {

                    if (courant.listCases[i, j].getColor() != Color.White)
                    {
                        int x = courant.listCases[i, j].getIndiceX();
                        int y = courant.listCases[i, j].getIndiceY();
                        grille[x, y].setColor(Color.White);
                    }
                }
        }



        //la grille fait descendre son tétromino courant
        public void descenteTetrominoCourant()
        {
            //s'il n'y a pas de cases colorées de la grille
            //on décolore les cases occupées par tétromino courant 
            this.decoloreCaseCourante();
            //on fait descendre les cases du tetromino courant
            for (int l = 0; l < 4; l++)
                for (int k = 0; k < 4; k++)
                    courant.listCases[l, k].descente();
        }

        //cette fonction retourne 1 si le tetromino peut descendre 
        //et 0 sinon
        public int testDescente()
        {
            int retour;
            int x, y;

            retour = 1;//on peut descendre


            //on test chaque case du tétromino
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (courant.listCases[i, j].getColor() != Color.White)//case colorée
                    {
                        x = courant.listCases[i, j].getIndiceX();
                        y = courant.listCases[i, j].getIndiceY();
                        if (y == 21)
                            retour = 0;
                        else
                        {
                            if (courant.couleur != Color.Red)
                            {
                                if ((grille[x, y + 1].getColor() != Color.White) && (courant.listCases[i, j + 1].getColor() == Color.White))
                                    //la case de la grille (x,y+1) est colorée et la case du tétromino (i,j+1) n'est pas colorée
                                    retour = 0;//on ne peut pas descendre
                            }
                    
                        }
                    }
            if (courant.couleur == Color.Red)
            {
                x = courant.listCases[0, 3].getIndiceX();
                y = courant.listCases[0, 3].getIndiceY() +1;
               
                if (courant.position == 1)
                {

                    if ((y < 21) && (grille[x, y].getColor() != Color.White))
                        retour = 0;
                    else
                        if ((y == 21) && (grille[x, y].getColor() != Color.White))
                            retour = 0;
                }
                else
                    y = courant.listCases[0, 0].getIndiceY()+1;
                    if ((courant.position == 2)&&(y<22))
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            x = courant.listCases[k, 0].getIndiceX();
                            y = courant.listCases[k, 0].getIndiceY();
                            if (grille[x, y+1].getColor() != Color.White)
                            {
                                retour = 0;
                            }
                        }
                    }
            }

            return retour;
        }


        public void changerPosition()
        {

                this.decoloreCaseCourante();
                courant.changerPosition();
        }

        public void deplaceDroite()
        {
            this.decoloreCaseCourante();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    courant.listCases[i, j].droite();
        }

        public int testDeplacerDroite()
        {
            int retour;
            int x, y;

            retour = 1;//on peut deplacer à droite
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (courant.listCases[i, j].getColor() != Color.White)//case colorée
                    {
                        x = courant.listCases[i, j].getIndiceX();
                        y = courant.listCases[i, j].getIndiceY();
                        if (x == 9)
                            retour = 0;
                        else
                        {
                            if ((grille[x + 1, y].getColor() != Color.White) && (courant.listCases[i + 1, j].getColor() == Color.White))
                                //la case de la grille (x+1,y) est colorée et la case du tétromino (i+1,j) n'est pas colorée
                                retour = 0;//on ne peut pas deplacer à droite
                        }
                    }

            return retour;
        }

        public void deplacerGauche()
        {
            this.decoloreCaseCourante();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    courant.listCases[i, j].gauche();
        }

        public int testDeplacerGauche()
        {
            int retour;
            int x, y;

            retour = 1;//on peut deplacer à gauche
            for (int j = 0; j < 4; j++)
                if (courant.listCases[0, j].getColor() != Color.White)//case colorée
                {
                    x = courant.listCases[0, j].getIndiceX();
                    y = courant.listCases[0, j].getIndiceY();
                    if (x == 0)
                        retour = 0;
                    else
                    {
                        if (grille[x - 1, y].getColor() != Color.White)
                            //la case de la grille (x-1,y) est colorée
                            retour = 0;//on ne peut pas deplacer à droite
                    }
                }

            return retour;
        }

        public int[] ligne()
        {
            int ligneTrouvee = 1;
            int k = 0;
            int[] row = new int[22];
            for (int i = 0; i < 22; i++)
                row[i] = -1;
            for (int j = 0; j < 22; j++)
            {
                for (int i = 0; i < 10; i++)
                    if (grille[i, j].getColor() == Color.White)
                        ligneTrouvee = 0;
                if (ligneTrouvee == 1)
                {
                    row[k] = j;
                    k++;
                }
                else
                    ligneTrouvee = 1;
            }
            return row;
        }

        public void supprimerLigne()
        {
            int[] lign = ligne();
            int k = 0;
            int nbreLigne = 0;
            for (int i = 0; i < 22; i++)
                if (lign[i] != -1)
                {
                    k = lign[i];
                    while (k != 1)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            grille[j, k].setColor(grille[j, k - 1].getColor());
                        }
                        NombreDeLigne = NombreDeLigne + 1;
                        k = k - 1;
                    }
                    nbreLigne = nbreLigne + 1;
                }
            if (nbreLigne == 1)
                Score = Score + 40;
            if (nbreLigne == 2)
                Score = Score + 100;
            if (nbreLigne == 3)
                Score = Score + 200;
            if (nbreLigne == 4)
                Score = Score + 1200;
            if ((Score<1500)&&(Score>=0))
                niveau=0;
            if ((Score<3000)&&(Score>=1500))
                niveau=1;
            if ((Score<4500)&&(Score>=3000))
                niveau=2;
            if ((Score<6000)&&(Score>=4500))
                niveau=3;
            if ((Score<7500)&&(Score>=6000))
                niveau=4;
            if ((Score<9000)&&(Score>=7500))
                niveau=5;
            if ((Score<10500)&&(Score>=9000))
                niveau=6;
            if ((Score<12000)&&(Score>=10500))
                niveau=7;
            if ((Score<13500)&&(Score>=12000))
                niveau= 8;
            if (Score>=13500)
                niveau= 9;
        }

        //modifier après
        public int finDePartie()
        {
            if(((grille[4,2].getColor()!=Color.White)||(grille[3,2].getColor()!=Color.White)||(grille[5,2].getColor()!=Color.White))&&(testDescente()==0))
                return 1;//fin de partie
            else
                return 0;
        }

        public int testChangerPosition()
        {
            int retour = 1;
            tetromino tetTest = new tetromino(0,0,courant.couleur,courant.position);
            tetTest.changerPosition();
            for (int i = 0; i < 4;i++)
                for(int j=0;j<4;j++)
                    if (tetTest.listCases[i, j].getColor() != Color.White)
                    {
                       int x  = courant.listCases[i,j].getIndiceX();
                        int y=courant.listCases[i,j].getIndiceY();
                        if ((x <= 9)&&(y<=21))
                        {
                            if ((courant.listCases[i, j].getColor() == Color.White) && (grille[x, y].getColor() != Color.White))
                                retour = 0;
                        }
                        else
                        {
                            retour = 0;
                        }
                    }

                return retour;
        }
    }
}
