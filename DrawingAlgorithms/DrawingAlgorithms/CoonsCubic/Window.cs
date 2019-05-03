using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoonsCubic
{
    public partial class Window : Form
    {

        public double[] splineX;
        public double[] splineY;

        public Point[] point = new Point[4];
        public int pointCount = 0;

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

        private void Window_MouseClick(object sender, MouseEventArgs e)
        {
            var graphics = Graphics.FromHwnd(this.Handle);

            if (pointCount > 2)
            {
                if (pointCount > 3)
                {
                    point[0] = point[1];
                    point[1] = point[2];
                    point[2] = point[3];
                }

                point[3].X = e.X;
                point[3].Y = e.Y;

                var division = (int)(Math.Sqrt(Math.Pow(point[3].X - point[1].X, 2) + Math.Pow(point[3].Y - point[1].Y, 2))) + 1;

                division = division / 5 + 2;

                Bspline(point[0], point[1], point[2], point[3], division);

                for (int i = 1; i <= division; i++)
                {
                        graphics.DrawLine(
                         new Pen(Color.Blue, 1),
                         (int)splineX[i - 1], (int)splineY[i - 1],
                         (int)splineX[i], (int)splineY[i]
                         );
                }
            }else
            {
                point[pointCount].X = e.X;
                point[pointCount].Y = e.Y;
            }

            pointCount++;

            DrawCross(e.X, e.Y, 1, Color.Red);
        }
        private void DrawCross(int x, int y, int penWidth, Color penColor)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.DrawLine(new Pen(penColor, penWidth), x - 3, y, x + 3, y);
            g.DrawLine(new Pen(penColor, penWidth), x, y - 3, x, y + 3);
        }
        public void Bspline(Point p1, Point p2, Point p3, Point p4, int divisions)
        {
            splineX = new double[divisions + 1];
            splineY = new double[divisions + 1];

            double[] ax = new double[4];
            double[] ay = new double[4];

            // z definice Coonsovy kubiky vypocitat koeficienty ai a bi polynomu
            // Q(t) = 1/6 (t^3  t^2  t   1)  *   M   *   P

            //          M =    -1   3  -3   1
            //                  3  -6   3   0
            //                 -3  �0   3   0
            //                  1   4   1   0
            //          P = (p1, p2, p3, p4)T

            ax[0] = (-p1.X + 3 * p2.X - 3 * p3.X + p4.X) / 6.0;
            ax[1] = (3 * p1.X - 6 * p2.X + 3 * p3.X) / 6.0;
            ax[2] = (-3 * p1.X + 3 * p3.X) / 6.0;
            ax[3] = (p1.X + 4 * p2.X + p3.X) / 6.0;

            ay[0] = (-p1.Y + 3 * p2.Y - 3 * p3.Y + p4.Y) / 6.0;
            ay[1] = (3 * p1.Y - 6 * p2.Y + 3 * p3.Y) / 6.0;
            ay[2] = (-3 * p1.Y + 3 * p3.Y) / 6.0;
            ay[3] = (p1.Y + 4 * p2.Y + p3.Y) / 6.0;

            splineX[0] = ax[3];      // t=0, zustane posledni clen
            splineY[0] = ay[3];

            // vypocet hodnot mezi 
            for (int i = 1; i <= divisions; i++)
            {
                float t;
                t = ((float)i) / ((float)divisions);

                splineX[i] = ax[3] + t * (ax[2] + t * (ax[1] + t * ax[0]));
                splineY[i] = ay[3] + t * (ay[2] + t * (ay[1] + t * ay[0]));
            }
        }

        private void newCurveBtn_Click(object sender, EventArgs e)
        {
            pointCount = 0;
        }

        private void deleteCurveBtn_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.Clear(this.BackColor);
        }
    }
}
