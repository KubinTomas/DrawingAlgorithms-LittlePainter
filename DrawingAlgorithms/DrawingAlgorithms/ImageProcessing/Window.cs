using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Window : Form
    {
        static Bitmap B0, B1, B2;                       // p�vodn�, p�ed transformac�, po
        public enum WarpOperace                         // v��et
        {
            Identita,
            Prevraceni,
            Meritko,
            Vlna,
            DvojitaVlna,
            Trojuhelnik,
            Krouceni,
            RybiOko,
            Spirala,
            Oblouk
        }
        private Bitmap _originalBitmap;

        public Window()
        {
            InitializeComponent();

            _originalBitmap = new Bitmap(pictureBox1.Image);

            comboBox1.DataSource = Enum.GetValues(typeof(WarpOperace));
        }

        private void sharpingBtn_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);

            int[,] array = {{ 0, -2, 0},
                            { -2, 11, -2},
                            { 0, -2, 0}};

            var weight = CountWeight(array);

            this.pictureBox1.Image = Convolution(bitmap, array, weight, 5);
        }

        private int CountWeight(int[,] core)
        {
            int weight = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    weight += core[i, j];
                }
            }

            return weight;
        }

        private Bitmap Convolution(Bitmap bitmapParam, int[,] core, int weight, int shift)
        {
            if (weight == 0) return null;

            var bitmap = new Bitmap(bitmapParam);

            for (int y = 1; y < bitmapParam.Height - 1; y++)
            {
                for (int x = 1; x < bitmapParam.Width - 1; x++)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    Color color;

                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            color = bitmapParam.GetPixel(x + col - 1, y + row - 1);

                            r += color.R * core[row, col];
                            g += color.G * core[row, col];
                            b += color.B * core[row, col];
                        }
                    }

                    r = shift + r / weight;
                    r = CheckOrSetByte(r);

                    g = shift + g / weight;
                    g = CheckOrSetByte(g);

                    b = shift + b / weight;
                    b = CheckOrSetByte(b);

                    color = Color.FromArgb(r, g, b);
                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }

        private byte CheckOrSetByte(float value)
        {
            if (value < 0) value = 0;
            if (value > 255) value = 255;

            return (byte)value;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = _originalBitmap;
        }

        private void noiseReductionBtn_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            var noise = 4;

            //int[,] array = {{ noise, noise, noise},
            //                { noise, noise, noise},
            //                { noise, noise, noise}};

            int[,] array = {{ 0, 1, 0},
                            { 1, 2, 1},
                            { 0, 1, 0}};

            var weight = CountWeight(array);

            this.pictureBox1.Image = Convolution(bitmap, array, weight, 5);
        }

        private void embossBtn_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            int[,] Arr1 = {{-1, 0, 0},
                          {0, 0, 0},
                          {0, 0, 1}};
            int[,] Arr2 = {{2, 0, 0},
                          {0, -1, 0},
                          {0, 0, -1}};


            pictureBox1.Image = Convolution(bitmap, Arr2, 1, 127);
        }

        private void edgesDetecionBtn_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);

            int[,] Arr1 = {{-5, 0, 0},
                          {0, 0, 0},
                          {0, 0, 5}};
            int[,] Arr2 = {{-1, -1, -1},
                          {0, 0, 0},
                          {1, 1, 1}};
            int[,] Arr3 = {{-1, 0, 1},
                          {-1, 0, 1},
                          {-1, 0, 1}};

            pictureBox1.Image = Convolution(bitmap, Arr3, 1, 0);

        }

        private void upperMoveBtn_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);

            int[,] Arr1 = {{-1, -2, -1},
                          {-2, 12, -2},
                          {-1, -2, -1}};

            //pictureBox1.Image = Convolution(bitmap, Arr1, 16, 127);
            //pictureBox1.Image = Convolution(bitmap, Arr1, 1, 127);

            pictureBox1.Image = Convolution(bitmap, Arr1, 1, 0);
        }

        private void warpingBtn_Click(object sender, EventArgs e)
        {
            B1 = (Bitmap)pictureBox1.Image;
            B2 = (Bitmap)B1.Clone();
            //B2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            WarpOperace operace;                    // enum
            Enum.TryParse<WarpOperace>(comboBox1.SelectedValue.ToString(), out operace);
            WarpImage(operace);
            pictureBox1.Image = B2;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = B1;
        }

        private static void WarpImage(WarpOperace warp_op)
        {
            // Generovat v�sledek pro ka�d� v�stupn� pixel
            for (int y = 0; y < B2.Height; y++)                             // cyklus p�es ��dky nov�ho obr�zku
            {
                for (int x = 0; x < B2.Width; x++)                          // cyklus p�es sloupce nov�ho obr�zku
                {
                    double du, dv;                                          // odpov�daj�c� sou�adnice v p�v. obr.
                    MapPixel(warp_op, x, y, out du, out dv);  // mapov�n� jednotliv�ch pixel� (x, y do u, v) - double pro v�po�ty

                    // Interpolace k z�sk�n� v�sledn� hodnoty pixelu
                    int iu = (int)du;                                       // integer - cel� ��st
                    int iv = (int)dv;

                    // Vyhod� pixely mimo obraz                             // rozm�ry star�ho obr�zku
                    if ((iu < 0) || (iu > B1.Width - 2) || (iv < 0) || (iv > B1.Height - 2))
                    {
                        B2.SetPixel(x, y, Color.White);                     // bod je mimo obr�zek - vybarv�me b�le
                    }
                    else                                                    // bod je uvnit� obr�zku - spo�teme jeho hodnotu
                    {
                        // vzd�lenosti od sousedn�ch pixel� (du je p�esn� hosnota, iu cel� ��slo)
                        double u0 = du - iu;                                // od lev�ho pixelu
                        double v0 = dv - iv;                                // od horn�ho
                        double u1 = 1 - u0;                                 // od prav�ho
                        double v1 = 1 - v0;                                 // od spodn�ho

                        byte r1, g1, b1, r2, g2, b2, r3, g3, b3, r4, g4, b4;    // barvy sousedn�ch pixel� do rij, gij, bij (i,j=0,1)
                        Color c;
                        c = B1.GetPixel(iu, iv);                            // vlevo naho�e
                        r1 = c.R; g1 = c.G; b1 = c.B;
                        c = B1.GetPixel(iu, iv + 1);                        // vlevo dole
                        r2 = c.R; g2 = c.G; b2 = c.B;
                        c = B1.GetPixel(iu + 1, iv);                        // vpravo naho�e
                        r3 = c.R; g3 = c.G; b3 = c.B;
                        c = B1.GetPixel(iu + 1, iv + 1);                    // vpravo dole
                        r4 = c.R; g4 = c.G; b4 = c.B;

                        // biline�rn� interpolace: v�po�et v�en�ho pr�m�ru
                        // ry1 = r1*dy1 + r2*dy0, ry2 = r3*dy1 + r4*dy0,   r = ry1*dx1 + ry2*dx0
                        int r = (int)(r1 * u1 * v1 + r2 * u1 * v0 + r3 * u0 * v1 + r4 * u0 * v0);
                        int g = (int)(g1 * u1 * v1 + g2 * u1 * v0 + g3 * u0 * v1 + g4 * u0 * v0);
                        int b = (int)(b1 * u1 * v1 + b2 * u1 * v0 + b3 * u0 * v1 + b4 * u0 * v0);
                        B2.SetPixel(x, y, Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
                    }
                }
            }
        }
        private static void MapPixel(WarpOperace warp_op, int x, int y, out double u, out double v)
        {
            double xs = B2.Width / 2.0;             // st�ed
            double ys = B2.Height / 2.0;

            double dx, dy, r1, r2;                  // pro n�kter� transformace

            switch (warp_op)
            {
                case WarpOperace.Identita:
                    u = x;
                    v = y;
                    break;
                case WarpOperace.Prevraceni:         // podle svisl� osy
                    u = B2.Width - x;
                    v = y;
                    break;
                case WarpOperace.Meritko:            // zm�na m���tka
                    double meritko = (double)B1.Width / (double)B2.Width;       // pro < 1 zvetsi, > 1 zmensi
                    u = meritko * x;
                    v = meritko * y;
                    //u = meritko * (x - xs) + xs;
                    //v = meritko * (y - ys) + ys;
                    break;
                case WarpOperace.Vlna:
                    double A = 10;                  // amplituda (10)
                    double T = 50;                  // perioda   (50)
                    u = x;
                    v = y - A * (Math.Sin(x / T * Math.PI) + 1) + 5;
                    break;
                case WarpOperace.DvojitaVlna:
                    u = x - 10 * (Math.Sin(y / 50.0 * Math.PI) + 1) + 5;
                    v = y - 10 * (Math.Sin(x / 50.0 * Math.PI) + 1) + 5;
                    break;
                case WarpOperace.Trojuhelnik:
                    dx = xs - x;
                    dx = dx * ys * 2 / (y + 1);
                    u = xs - dx;
                    v = y;
                    break;
                case WarpOperace.Krouceni:
                    dx = xs - x;
                    dx = dx * (Math.Sin(y / 50.0 * Math.PI) / 2 + 1.5);
                    u = xs - dx;
                    v = y;
                    break;
                case WarpOperace.RybiOko:
                    dx = x - xs;
                    dy = y - ys;
                    r1 = Math.Sqrt(dx * dx + dy * dy);
                    if (r1 == 0)
                    {
                        u = xs; v = ys;
                    }
                    else
                    {
                        double rmax = xs * 1.5;             // maxim�ln� dosah
                        r2 = rmax / 2 * (1 / (1 - r1 / rmax) - 1);
                        u = dx * r2 / r1 + xs;
                        v = dy * r2 / r1 + ys;
                    }
                    break;
                case WarpOperace.Spirala:
                    const double K = 100.0;                 // konstanta u spir�ly (= 100)
                    dx = x - xs;
                    dy = y - ys;
                    r1 = Math.Sqrt(dx * dx + dy * dy);
                    if (r1 == 0)
                    {
                        u = 0; v = 0;
                    }
                    else
                    {
                        double theta = Math.Atan2(dx, dy) - r1 / K + Math.PI / 2.0;
                        u = r1 * Math.Cos(theta);
                        v = r1 * Math.Sin(theta);
                    }
                    u = u + xs;
                    v = v + ys;
                    break;
                case WarpOperace.Oblouk:
                    dx = xs - x;
                    dx = dx * (10 + ys / (2 * y + 10));
                    u = xs - 0.1 * dx;
                    v = y;
                    break;
                default:                                // soum�rnost pod�l st�edu
                    u = 2 * xs - x;
                    v = 2 * ys - y;
                    break;
            }
        }
    }
}
