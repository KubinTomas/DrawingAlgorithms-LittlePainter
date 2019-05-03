using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditablePointsOnPolynom
{
    public partial class Window : Form
    {
        private int mPoint;                             // p�esouvan� bod
        private int precision = 10;                     // kolikr�t v�c bod� p�i vykreslov�ni nez ��dic�ch bod�

        private List<ControlPoint> cp = new List<ControlPoint>();   //pole ��dic�ch bod� dynamick� velikosti (zad�no my��)

        public Window()
        {
            InitializeComponent();
        }
        private int PointId(int x, int y)
        {
            for (int i = 0; i < cp.Count; i++)
            {
                if (cp[i].pobliz(x, y))
                    return i;
            }
            return -1;
        }

        private void RefreshGraph(PaintEventArgs e)     // volano z metody Paint - kazde prekresleni panelu
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float[] yc = new float[cp.Count];           // koeficienty Newtonova interpolacniho polynomu
            float[] xc = new float[cp.Count];           // souradnice x nodu

            float oldy = 0, oldx = 0;

            int npp = cp.Count * precision;             // pocet bodu pri vykreslovani, precision ~ 10

            if (cp.Count > 0)                           // jsou zvoleny nejake body
            {
                for (int i = 0; i < cp.Count; i++)      // vykresli zadane ��dic� body polynomu
                {
                    xc[i] = cp[i].x;                    // souradnice zadanych bodu polynomu
                    yc[i] = cp[i].y;
                    g.DrawRectangle(Pens.Red, cp[i].x - cp[i].r, cp[i].y - cp[i].r, cp[i].r * 2, cp[i].r * 2);     // �tvere�ek
                }

                for (int k = 1; k <= cp.Count - 1; k++)             // pomerne diference k-teho radu
                {
                    for (int i = 0; i <= cp.Count - 1 - k; i++)     // vypocet z predchozich bodu
                    {
                        yc[i] = (yc[i + 1] - yc[i]) / (xc[i + k] - xc[i]);  // pomerne diference k-teho radu, ai
                        // yc[i] = (cp[i+1].y - cp[i].y) /  (cp[i+k].x - cp[i].x);
                    }
                }

                // pro body ekvidistantni podle x vyhodnotit polynom a vykreslit usecku
                float dt = ((float)panel1.Width - 1) / npp;         // ���ku panelu rozd�l� na npp(=np*precision) ekvidistantn�ch interval� d�lky dt
                for (int k = 0; k <= npp; k++)
                {
                    float x = k * dt;                               // souradnice x

                    // vyhodnotit polynom v bode x
                    float y = yc[0];
                    for (int i = 1; i <= cp.Count - 1; i++)         // Newton: 
                    {
                        y = y * (x - xc[i]) + yc[i];                // y0 = a0
                        // y1 = a0 * (x-x1) + a1
                        // y2 = (a0 * (x-x1) + a1) * (x-x2) + a2
                        // ...
                        // yn-1 = () * (x-xn-1) + ... + an-1
                    }
                    if (k > 0)                                      // prvni bod neni s cim spojit
                    {
                        try                                         // vykreslit usecku
                        {
                            g.DrawLine(Pens.Orange, (int)oldx, (int)oldy, (int)x, (int)y);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + " x1={0} y1={1} x2={2} y2={3}", oldx, oldy, x, y);
                        }
                    }
                    oldx = x;
                    oldy = y;

                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    int i;
                    for (i = 0; i <= cp.Count - 1 && (cp[i]).x < e.X; i++)  // najde body vlevo (pro set��d�n� podle x)
                    { }
                    ControlPoint pnt = new ControlPoint(e.X, e.Y);
                    cp.Insert(i, pnt);
                    panel1.Invalidate();
                    break;
                case MouseButtons.Middle:
                    mPoint = PointId(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    int deletePt = PointId(e.X, e.Y);
                    if (deletePt >= 0)
                    {
                        cp.RemoveAt(deletePt);
                        panel1.Invalidate();
                    }
                    break;
            }
        }

        private void panel1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle) return;
            if (mPoint >= 0)
            {
                int np = cp.Count;
                // zjisti, zda e.x je mezi cp.elementAt(movingPoint+1) a  cp.elementAt(movingPoint-1)
                if (
                    (mPoint == np - 1 || e.X <= (cp[mPoint + 1]).x) &&    // posledni nebo vlevo od dalsiho
                    (mPoint == 0 || e.X >= (cp[mPoint - 1]).x)            // prvni nebo vpravo od predchoziho
                    )
                {
                    cp[mPoint].x = e.X;
                    cp[mPoint].y = e.Y;
                }
                else
                {
                    // naj�t spravnou pozici, kdyz se preskupi
                    cp.RemoveAt(mPoint);
                    int i;
                    for (i = 0;
                        i <= np - 2 && (cp[i]).x < e.X; i++)
                    { }
                    ControlPoint pnt2 = new ControlPoint(e.X, e.Y);
                    if (i <= np - 1)
                    {
                        cp.Insert(i, pnt2);
                    }
                    else
                    {
                        cp.Add(pnt2);
                    }
                    mPoint = i;
                }
                panel1.Invalidate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            RefreshGraph(e);
        }

    }
    public class ControlPoint
    {
        public int x;
        public int y;
        public int r = 5;               // velikost �tvere�ku

        public ControlPoint(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public bool pobliz(int X, int Y)
        {
            if (X >= x - r && Y >= y - r &&
                X <= x + r && Y <= y + r)
                return true;
            else
                return false;
        }
    }
}
