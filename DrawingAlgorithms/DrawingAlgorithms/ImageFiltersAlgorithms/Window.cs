using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFiltersAlgorithms
{
    public partial class Window : Form
    {
        private Bitmap _originalBitmap;

        public Window()
        {
            InitializeComponent();

            InitSettings();

            _originalBitmap = (Bitmap)pictureBox.Image;
        }
        private void InitSettings()
        {
            this.Size = new Size(800, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// Using set pixel - really slow method
        /// Use marshal copy instead 
        /// </summary>
        /// <param name="k">smernice</param>
        /// <param name="q">q posunuti na ose y</param>
        private void EditGradation(double k, double q)
        {
            byte r, g, b;

            Color color;

            Bitmap bitmap = new Bitmap(pictureBox.Image);

            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    color = bitmap.GetPixel(i, j);
                    r = SetColor(color.R, k, q);
                    g = SetColor(color.G, k, q);
                    b = SetColor(color.B, k, q);

                    bitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox.Image = bitmap;

        }
        private byte SetColor(byte originalValue, double k, double q)
        {
            double newValue = k * (originalValue - 127) + q + 127;

            if (newValue < 0) return 0;

            if (newValue > 255) return 255;

            return (byte)newValue;
        }
        private void Thresholding(double limit)
        {
            Color oldColor;

            Bitmap bitmap = new Bitmap(pictureBox.Image);

            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    oldColor = bitmap.GetPixel(i, j);

                    if (oldColor.GetBrightness() > limit)
                        bitmap.SetPixel(i, j, Color.White);

                    if (oldColor.GetBrightness() < limit)
                        bitmap.SetPixel(i, j, Color.Black);
                }
            }
            pictureBox.Image = bitmap;

        }
        private void RandomThresholding()
        {
            Color oldColor;
            Random random = new Random();

            Bitmap bitmap = new Bitmap(pictureBox.Image);

            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    oldColor = bitmap.GetPixel(i, j);

                    double limit = random.NextDouble();

                    if (oldColor.GetBrightness() > limit)
                        bitmap.SetPixel(i, j, Color.White);

                    if (oldColor.GetBrightness() < limit)
                        bitmap.SetPixel(i, j, Color.Black);

                }
            }
            pictureBox.Image = bitmap;

        }
        private void Matrix()
        {
            byte[,] Md = new byte[4, 4]  {{ 0,12, 3,15},
                                          { 8, 4,11, 7},
                                          { 2,14, 1,13},
                                          {10, 6, 9, 5}};

            byte[,] Mp = new byte[4, 4]  {{ 1, 5, 9, 2},
                                          { 8,12,13, 6},
                                          { 4,15,14,10},
                                          { 0,11, 7, 3}};

            Bitmap bitmap = new Bitmap(pictureBox.Image);
            Color oldColor;             // stara barva
            byte old_I;             // stara intenzita
            int i, j;

            for (j = 0; j < bitmap.Height; j++)
                for (i = 0; i < bitmap.Width; i++)
                {
                    oldColor = bitmap.GetPixel(i, j);                      // barva pixelu
                    old_I = (byte)(255 * oldColor.GetBrightness());     // intenzita 0-255; v matici je 0-15, proto na dalsim radku prepocet
                    if (old_I > 16 * Md[i % 4, j % 4])              // porovnava se intenzita pixelu s hodnotou na odpovidajicim miste v matici
                        bitmap.SetPixel(i, j, Color.White);
                    else
                        bitmap.SetPixel(i, j, Color.Black);
                }
            pictureBox.Image = bitmap;
        }


        //*************************** distribuce chyby: Floyd-Steinberg *************************************

        private Bitmap Distribution()
        {
            Bitmap bmpOrig = new Bitmap(pictureBox.Image);    // p�vodn� obr�zek
            int[,] Jas;                                     // pole jas�; nejprve napln�me jasy pixel�, potom redukujeme
            int qnt_err;                                    // kvantiza�n� chyba (jej� �estn�ctina)
            int Vyska = bmpOrig.Height;
            int Sirka = bmpOrig.Width;
            int i, j;

            Jas = new int[Sirka, Vyska];
            Bitmap bmpNovy = new Bitmap(Sirka, Vyska);         // nov� obr�zek

            for (j = 0; j < Vyska; j++)                     // napln�n� matice jas� z p�vodn�ho obr�zku (Orig)
                for (i = 0; i < Sirka; i++)
                {
                    Color pixel = bmpOrig.GetPixel(i, j);
                    Jas[i, j] = (int)(255 * pixel.GetBrightness());
                }

            for (j = 1; j < Vyska - 1; j++)                 // vlastn� v�po�et nastaven� jasu v redukovan�m prostoru
                for (i = 1; i < Sirka - 1; i++)
                {
                    qnt_err = 0;
                    if (Jas[i, j] < 128)                    // n�zk� jas
                    {
                        qnt_err = Jas[i, j] / 16;           // v�po�et kvantiza�n� chyby - ub�r�m jas (na 0)
                        Jas[i, j] = 0;                      // �ern�
                    }
                    else                                    // vysok� jas
                    {
                        qnt_err = (Jas[i, j] - 255) / 16;   // v�po�et kvantiza�n� chyby - p�id�v�m jas (na 255)
                        Jas[i, j] = 1;                      // b�l�
                    }
                    Jas[i + 1, j] += (qnt_err * 7);         // distribuce chyby do nezpracovan�ch pixel�
                    Jas[i - 1, j + 1] += (qnt_err * 3);
                    Jas[i, j + 1] += (qnt_err * 5);
                    Jas[i + 1, j + 1] += (qnt_err);
                }

            for (j = 0; j < Vyska; j++)                     // novy obrazek z pole jas�
                for (i = 0; i < Sirka; i++)
                {
                    if (Jas[i, j] == 1)
                        bmpNovy.SetPixel(i, j, Color.White);
                    else
                        bmpNovy.SetPixel(i, j, Color.Black);
                }

            return bmpNovy;
        }


        private void editGradationBtn_Click(object sender, EventArgs e)
        {
            EditGradation(1, -5);
        }

        private void thresholdingBtn_Click(object sender, EventArgs e)
        {
            Thresholding(0.5);
        }

        private void rndThresholdingBtn_Click(object sender, EventArgs e)
        {
            RandomThresholding();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            pictureBox.Image = _originalBitmap;
        }

        private void matrixBtn_Click(object sender, EventArgs e)
        {
            Matrix();
        }

        private void distributionBtn_Click(object sender, EventArgs e)
        {
            Distribution();
        }
    }
}
