using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var w = 192; // largeur carte d'origine
            var h = 264; // hauteur carte d'origine

            // L'original pour l'image des cartes
            var full = new Bitmap(@"..\..\..\..\png\card-game-original.png");

            // Le dos des cartes redimensionné manuellement
            var back = new Bitmap(@"..\..\..\..\png\back-phone.png");

            // Une image pour dessiner les cartes en taille réduite
            var half = new Bitmap(w * 14 / 2, h * 4 / 2, full.PixelFormat);
            var g = Graphics.FromImage(half);
            g.Clear(Color.White);

            // Attribut pour copie transparente
            // (inutile? mais cette syntaxe du DrawImage améliore la qualité)
            var attr = new ImageAttributes();
            attr.SetColorKey(half.GetPixel(0, 0), half.GetPixel(0, 0));

            Rectangle src;
            Rectangle dst;

            // Boucle sur les cartes de l'As au Roi
            for (var r = 0; r < 13; r++)
            {
                // Boucle sur les 4 couleurs
                for (var c = 0; c < 4; c++)
                {
                    // Est-ce qu'il s'agit d'une figure
                    bool head = ((r > 9) && (r < 15));

                    // Coordonnées de l'image source
                    var l = r * w;
                    var t = c * h;

                    // Copie la lettre représentant la valeur de la carte
                    src = new Rectangle(l + 5, t + 10, 24, 32);
                    if (r > 6) src.Width = 22;
                    if (head) src = new Rectangle(l + 5, t + 10, 20, 30);
                    var x = r * w / 2;
                    var y = c * h / 2;
                    dst = new Rectangle(x + 3, y + 5, src.Width, src.Height);
                    g.DrawImage(full, dst, src.Left, src.Top, src.Width, src.Height, GraphicsUnit.Pixel, attr);

                    // Copie la mini couleur de la carte en haut à droite (depuis la couleur de l'as)
                    src = new Rectangle(5, t + 10 + 32, 24, 24);
                    dst = new Rectangle(x + (w / 2) - src.Width - 8, y + 5, src.Width, src.Height);
                    g.DrawImage(full, dst, src.Left, src.Top, src.Width, src.Height, GraphicsUnit.Pixel, attr);

                    // Copie la mini couleur de la carte en dessous de la valeur de la carte
                    if (head == false)
                    {
                        src = new Rectangle(5, t + 10 + 32, 24, 24);
                        dst = new Rectangle(x + 3, y + (h / 2) - 88, src.Width, src.Height);
                        g.DrawImage(full, dst, src.Left, src.Top, src.Width, src.Height, GraphicsUnit.Pixel, attr);
                    }

                    // Copie la figure de la carte (si figure)
                    if (head == true)
                    {
                        src = new Rectangle(l + 35, t + 30, 80, 80);
                        dst = new Rectangle(x + (w / 2) - 88, y + (h / 2) - 88, src.Width, src.Height);
                        g.DrawImage(full, dst, src.Left, src.Top, src.Width, src.Height, GraphicsUnit.Pixel, attr);
                    }

                    // Sinon, copie la couleur de la carte (depuis l'as)
                    if (head == false)
                    {
                        src = new Rectangle(68, t + 100, 56, 64);
                        x += 25;
                        y += 50;
                        x += 12;
                        y += 12;
                        dst = new Rectangle(x, y, src.Width, src.Height);
                        g.DrawImage(full, dst, src.Left, src.Top, src.Width, src.Height, GraphicsUnit.Pixel, attr);
                    }
                }
            }

            // Copie les dos et les jokers
            dst = new Rectangle(half.Width - back.Width, 0, back.Width, back.Height);
            g.DrawImage(back, dst, 0, 0, back.Width, back.Height, GraphicsUnit.Pixel, attr);

            // Sauvegarde l'image des cartes en taille réduite
            half.Save(@"..\..\..\..\png\card-phone-original.png", ImageFormat.Png);

            MessageBox.Show("Fini !");
        }
    }
}
