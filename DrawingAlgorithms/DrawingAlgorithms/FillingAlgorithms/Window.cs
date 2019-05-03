using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingAlgorithms
{


    public partial class Window : Form
    {
        private Bitmap bitmap;

        private Point[] points = new Point[5];

        int count = 0;

        public Window()
        {
            InitializeComponent();

            InitSettings();
        }
        private void InitSettings()
        {
            this.Size = new Size(800, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(600, 400, PixelFormat.Format24bppRgb);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(175, 175, 175));

            pictureBox.Image = bitmap;

        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            int x = bitmap.Width / 2;
            int y = bitmap.Height / 2;

            int size = 200;

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawEllipse(Pens.Red, x - size / 2, y - size / 2, size, size);
            pictureBox.Image = bitmap;
        }

        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            //// Seminko dam do prostred bitmapy a ve stredu je kruznice takze mame seminko uvnitr a zacne se vykreslovat, nez dojde k jeji hranici
            //FloodFill(pictureBox.Image.Width / 2, pictureBox.Image.Height / 2);
            //pictureBox.Image = bitmap;

            //var point = new Point(pictureBox.Image.Width / 2, pictureBox.Image.Height / 2);
            //FloodFill2(point, Color.Red);

            //pictureBox.Image = bitmap;

            var point = new Point(pictureBox.Image.Width / 2, pictureBox.Image.Height / 2);
            FloodFill3(point, Color.Red);

            pictureBox.Image = bitmap;
        }
        /// <summary>
        /// Will overflow stack, on bigger circle, this is simple, but not so effective 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void FloodFill(int x, int y)
        {
            Color color = Color.Red;

            if (Color.Equals(bitmap.GetPixel(x, y).ToArgb(), color.ToArgb())) return;

            bitmap.SetPixel(x, y, color);

            FloodFill(x + 1, y);
            FloodFill(x - 1, y);
            FloodFill(x, y + 1);
            FloodFill(x, y - 1);
        }
        /// <summary>
        /// Improved function of FloodFill
        /// Filling with stack using
        /// </summary>
        private void FloodFill2(Point coordinates, Color newColor)
        {
            Stack<Point> pixels = new Stack<Point>();

            pixels.Push(coordinates);

            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();

                // Check if we are inside bitmap
                if (a.X < bitmap.Width && a.X >= 0 && a.Y < bitmap.Height && a.Y >= 0)
                {

                    if (bitmap.GetPixel(a.X, a.Y).ToArgb() != newColor.ToArgb())
                    {
                        bitmap.SetPixel(a.X, a.Y, newColor);

                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y + 1));
                        pixels.Push(new Point(a.X, a.Y - 1));
                    }

                }
            }
        }

        private void FloodFill3(Point coordinates, Color newColor)
        {
            var pattern = new Color[3, 3] { { Color.Aquamarine, Color.Aquamarine, Color.Aquamarine }, { Color.Aquamarine, Color.White, Color.Aquamarine }, { Color.Aquamarine, Color.Aquamarine, Color.Aquamarine } };
            bool[,] template = new bool[bitmap.Width, bitmap.Height];
            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(coordinates);

            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();
                if (a.X < bitmap.Width && a.X >= 0 && a.Y < bitmap.Height && a.Y >= 0)
                {
                    if ((bitmap.GetPixel(a.X, a.Y).ToArgb() != newColor.ToArgb()) && (!template[a.X, a.Y]))
                    {
                        template[a.X, a.Y] = true;
                        bitmap.SetPixel(a.X, a.Y, pattern[a.X % 3, a.Y % 3]);
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));

                        // Uncomment to see slow, animated color filling.. Hah animated, just way to much to process, so it is slow :D 
                        //pictureBox.Image = bitmap;
                        //pictureBox.Refresh();
                    }
                }
            }
            return;
        }
        /// <summary>
        /// metoda radkoveho vyplnovani vezme vrcholy a pak je je vyplni barvou
        /// </summary>
        /// <param name="vrcholy"></param>
        /// <param name="c"></param>
        /// <param name="krok"></param>
        void VyplnPolygon(Point[] vrcholy, Color c, int krok)
        {

            if (vrcholy.Length < 2) return;                         // m�lo bod� pro vytvo�en� oblasti
            int ymax = vrcholy[0].Y - 1;                            // nastaven� po��te�n�ch hodnot pro zji�t�n� v�ech ��dk�
            int ymin = vrcholy[0].Y + 1;
            int pCount = 0;                                         // po��tadlo �se�ek

            // vytvo�en� orientovan�ch hrani�n�ch �se�ek (v�echny jako dvojice bod�)
            Point[] p = new Point[vrcholy.Length * 2 + 2];          // hrani�n� �se�ky (po dvojic�ch bod�, orientovan� podle y)
            for (int i = 0; i < vrcholy.Length; i++)                // p�es v�echny vrcholy hranice
            {
                int j = (i == vrcholy.Length - 1) ? 0 : i + 1;      // j je o jedni�ku v�t�� (kdyz i posledni, je j = 0)
                // odstran�n� vodorovn�ch
                if (vrcholy[i].Y == vrcholy[j].Y) continue;         // kdy� vodorovn� (na stejn�m ��dku), vyhodi se
                // orientov�n� shora dol�
                if (vrcholy[i].Y > vrcholy[j].Y)                    // roste - prvn� (i) m� v�t�� Y ne� j=i+1 (orientuje shora dol�)
                {
                    p[pCount++] = vrcholy[j];                       // do seznamu se d� nejd��ve s men��m y
                    p[pCount++] = vrcholy[i];                       // potom s v�t��m y
                    ymax = Math.Max(ymax, vrcholy[i].Y);
                    ymin = Math.Min(ymin, vrcholy[j].Y);            // aktualizuje se min a max
                }
                else
                {
                    p[pCount++] = vrcholy[i];                       // do seznamu se d� nejd��ve s men��m y
                    p[pCount++] = vrcholy[j];                       // potom s v�t��m y
                    ymax = Math.Max(ymax, vrcholy[j].Y);
                    ymin = Math.Min(ymin, vrcholy[i].Y);            // aktualizuje se min a max
                }
            }

            // pr�se��ky ��dk� s hrani�n�mi �se�kami
            int intersCount;                                        // pr�se��ky pro jednotliv� ��dky
            Point[] inters = new Point[vrcholy.Length + 1];
            for (int y = ymin; y <= ymax; y += krok)                // po v�ech ��dc�ch
            {
                intersCount = 0;                                    // po��tadlo pr�se��k� pro dan� ��dek - v�dy od nuly
                inters = new Point[vrcholy.Length + 1];             // pole pr�se��k� pro dan� ��dek
                for (int k = 0; k < pCount - 1; k += 2)             // hled�n� pr�se��k� pro dan� ��dek se v�emi hrani�n�mi �se�kami
                {
                    float t = (y - p[k].Y) / (float)(p[k + 1].Y - p[k].Y);      // kdyby bylo = 1, bylo by y = p[k + 1].Y (hrani�n� �se�ka kon��) - vyhodit
                    if (t >= 0 && t < 1)                                        // t=1 nen� zapo�teno
                    {
                        float f = (p[k].X + (p[k + 1].X - p[k].X) * t);         // dopo��t� se x
                        int x = (int)Math.Round(f);                             // zaokrouhlen�
                        inters[intersCount++] = new Point(x, y);
                    }
                }
                Array.Sort(inters, 0, intersCount, new PointComparer());        // t��d�n� podle x (pro dan� ��dek)

                Graphics g = Graphics.FromImage(pictureBox.Image);
                //Graphics g = pictureBox1.CreateGraphics();

                for (int k = 0; k < intersCount - 1; k += 2)                    // vlastn� vypln�n� pomoc� �se�ek - spojov�n� po dvou
                {
                    g.DrawLine(Pens.Brown, inters[k].X, inters[k].Y, inters[k + 1].X, inters[k + 1].Y);

                    //for (int m = 0; m < inters[k + 1].X - inters[k].X; m++)       // vodorovn� �se�ka p�es SetPixel
                    //bmp.SetPixel(inters[k].X + m, inters[k].Y, c);
                }
                //pictureBox1.Refresh();

            }       // for (int l = 0; l < pointsCount - 1; l += 2)

        }

        private void btnRowFlling_Click(object sender, EventArgs e)
        {
            if (count < 3)
            {
                Point[] points = new Point[]
                {
                new Point(2,150), new Point(100,140), new Point(80,5), new Point(50,170) , new Point(10,1)
                };

                VyplnPolygon(points, Color.Purple, 1);
                pictureBox.Refresh();
            }
            else
            {
                VyplnPolygon(points.ToList().GetRange(0, count).ToArray(), Color.Blue, 1);  // pos�l� se bez p��padn�ch pr�zdn�ch
                pictureBox.Refresh();
                count = 0;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
                return;
            Graphics g = pictureBox.CreateGraphics();
            //Graphics g = Graphics.FromImage(pictureBox1.Image);

            MouseEventArgs e1 = (MouseEventArgs)e;
            bitmap.SetPixel(e1.X, e1.Y, Color.Blue);
            pictureBox.Refresh();
            g.DrawEllipse(Pens.Black, e1.X - 5, e1.Y - 5, 10, 10);

            if (count < 5)
            {
                points[count] = new Point(e1.X, e1.Y);
                count++;
            }
            else
            {
                VyplnPolygon(points, Color.Blue, 1);
                pictureBox.Refresh();
                count = 0;
            }
        }
    }
    public class PointComparer : IComparer
    {
        int IComparer.Compare(object p1, object p2)
        {
            return Compare((Point)p1, (Point)p2);
        }
        public int Compare(Point p1, Point p2)
        {
            return p1.X.CompareTo(p2.X);
        }
    }

}
