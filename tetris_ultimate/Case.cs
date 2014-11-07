using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace tetris_ultimate
{
    class Case
    {
        private Point cointSuperieurGauche;
        private Color couleur;
        private int largeur = 0;
        private int hauteur = 0;
        //l'indice est la position sur la grille
        private int indiceX = 0;
        private int indiceY = 0;

        public Case(Point p,int h,int l,Color c) {
            largeur = l;
            hauteur = h;
            cointSuperieurGauche = p;
            couleur = c;
        }

        public void setIndiceX(int x)
        {
            indiceX = x;
        }

        public int getIndiceX()
        {
            return indiceX;
        }
        public void setIndiceY(int y)
        {
            indiceY = y;
        }

        public int getIndiceY()
        {
            return indiceY;
        }

        public Point getCointSuperieurGauche() {
        return cointSuperieurGauche;
        }
        public void setCoinSuperieurGauche(Point p)
        {
            cointSuperieurGauche = p;
        }
        public Color getColor() {
        return couleur;
        }
        public void gauche()
        {
            cointSuperieurGauche.X -= 20;
            indiceX -= 1;
        }
        public void droite()
        {
            indiceX += 1;
            cointSuperieurGauche.X += 20;
        }
        public void descente()
        {
            indiceY += 1;
            cointSuperieurGauche.Y += 20;
        }
        public void setColor(Color c)
        {
            couleur = c;
        }
        public void deplacer(Point p) {
        cointSuperieurGauche = p;
        }
        public void dessiner(Graphics g)
        {
            Pen monStylo = new Pen(this.getColor(), 1);
            SolidBrush pinceau = new SolidBrush(this.getColor());
            g.FillRectangle(pinceau, this.getCointSuperieurGauche().X,
            this.getCointSuperieurGauche().Y, largeur, hauteur);
        }
    }
}
