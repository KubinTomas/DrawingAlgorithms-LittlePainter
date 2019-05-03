using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curves
{
    /// <summary>
    /// beziers curves
    /// </summary>
    public partial class Window : Form
    {

        private Bitmap bitmap;
        private PointF[] point = new PointF[4];
        private int pressCount = 0;
        Graphics graphics;

        public Window()
        {
            InitializeComponent();

            InitSettings();
            InitValues();
        }
        private void InitValues()
        {
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bitmap;

            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
        }
        private void InitSettings()
        {
            this.Size = new Size(800, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void Curve(PointF[] G, int pixelCount)
        {
            double dr = Math.Pow(G[0].X - G[3].X, 2) + Math.Pow(G[0].Y - G[3].Y, 2);

            if(dr < pixelCount * pixelCount)
            {
                graphics.DrawLine(Pens.Orange, G[0].X, G[0].Y, G[3].X, G[3].Y);
                return;
            }

            var L = new PointF[4];
            var R = new PointF[4];

            SplitCurve(G, L, R);
            Curve(L, pixelCount);
            Curve(R, pixelCount);

            bitmap.SetPixel((int)R[0].X, (int)R[0].Y, Color.Orange);
        }
        void SplitCurve(PointF[] G, PointF[] L, PointF[] R)     // orig, left, right
        {
            // Lze pracovat v int (p�vodn� pole se n�sob� �ty�mi)
            float hX, hY;

            L[0] = G[0];
            L[1].X = (G[0].X + G[1].X) / 2;
            L[1].Y = (G[0].Y + G[1].Y) / 2;
            hX = (G[1].X + G[2].X) / 2;
            hY = (G[1].Y + G[2].Y) / 2;
            L[2].X = (L[1].X + hX) / 2;
            L[2].Y = (L[1].Y + hY) / 2;

            R[3] = G[3];
            R[2].X = (G[2].X + G[3].X) / 2;
            R[2].Y = (G[2].Y + G[3].Y) / 2;
            R[1].X = (hX + R[2].X) / 2;
            R[1].Y = (hY + R[2].Y) / 2;
            R[0].X = (L[2].X + R[1].X) / 2;
            R[0].Y = (L[2].Y + R[1].Y) / 2;

            L[3] = R[0];
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            var mouse = (MouseEventArgs)e;

            if(mouse.Button == MouseButtons.Left)
            {
                point[pressCount].X = mouse.X;
                point[pressCount].Y = mouse.Y;

                bitmap.SetPixel(mouse.X, mouse.Y, Color.Blue);

                graphics.DrawRectangle(Pens.Blue, mouse.X - 3, mouse.Y - 3, 6, 6);

                if (pressCount > 0) graphics.DrawLine(Pens.Cyan, point[pressCount - 1], point[pressCount]);

                if(pressCount < 3)
                {
                    pressCount++;
                }
                else
                {
                    Curve(point, 5);
                    point[0] = point[3];
                    pressCount = 0;
                }

                pictureBox.Refresh();
            }
        }

        private void refreshPictureBoxBtn_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pressCount = 0;

            pictureBox.Refresh();
        }
    }
}
