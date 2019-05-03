using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line.LineAlgorithms
{
    /// <summary>
    /// Algorithm for line drawing
    /// </summary>
    public class Bresenham
    {
        public byte[,] R, G, B;

        Size windowSize = new Size(300, 200);

        Point startingPoint = new Point(5, 10);
        Point endingPoint = new Point(100, 30);

        public Bresenham()
        {
            InitRGB();
        }
        /// <summary>
        /// Should call algorithm
        /// </summary>
        public void DrawLine()
        {
            PaintBackground(200, 200, 200, windowSize);     
            DrawLine(startingPoint, endingPoint);               

            PaintPixel(startingPoint.X, startingPoint.Y, 255, 0, 0);       
            PaintPixel(endingPoint.X, endingPoint.Y, 0, 150, 0);        
            SaveBmp(windowSize.Width, windowSize.Height, 30);                     
        }
        private void InitRGB()
        {
            // Init RGB in one line of code
            R = G = B = new Byte[windowSize.Width, windowSize.Height];

            //R = new Byte[windowSize.Width, windowSize.Height];
            //G = new Byte[windowSize.Width, windowSize.Height];
            //B = new Byte[windowSize.Width, windowSize.Height];
        }
        /// <summary>
        /// Paint backgournd of our map
        /// </summary>
        /// <param name="r">value of red</param>
        /// <param name="g">value of green</param>
        /// <param name="b">value of b</param>
        /// <param name="windowSize">size of our screen / 'canvas', where we will be painting</param>
        private void PaintBackground(byte r, byte g, byte b, Size windowSize)
        {
            for (int dx = 0; dx < windowSize.Width; dx++)
            {
                for (int dy = 0; dy < windowSize.Height; dy++)
                {
                    this.R[dx, dy] = r;
                    this.G[dx, dy] = g;
                    this.B[dx, dy] = b;
                }
            }
        }
        private void PaintBackground(Color color, Size windowSize)
        {
            PaintBackground(color.R, color.G, color.B, windowSize);
        }
        /// <summary>
        /// Set color of pixel
        /// </summary>
        /// <param name="x">x position on our map</param>
        /// <param name="y">y position on our map</param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        private void PaintPixel(int x, int y, byte r, byte g, byte b)
        {
            R[x, y] = r;
            G[x, y] = g;
            B[x, y] = b;
        }
        private void PaintPixel(int x, int y, Color color)
        {
            PaintPixel(x, y, color.R, color.G, color.B);
        }
        private void DrawLine(Point startPosition, Point endPosition)
        {
            //test sklonu, zda to pujde k ose x a nebo y
            if (Math.Abs(endPosition.Y - startPosition.Y) > Math.Abs(endPosition.X - startPosition.X))
            {
                if ((startPosition.Y - endPosition.Y) < 0)
                    BresenhamMethod(startPosition.Y, startPosition.X, endPosition.Y, endPosition.X, false);
                else
                    BresenhamMethod(endPosition.Y, endPosition.X, startPosition.Y, startPosition.X, false);
            }
            else
            {
                if ((startPosition.Y - endPosition.Y) > 0)
                    BresenhamMethod(endPosition.X, endPosition.Y, startPosition.X, startPosition.Y, true);
                else
                    BresenhamMethod(startPosition.X, startPosition.Y, endPosition.X, endPosition.Y, true);
            }

        }
        private void BresenhamMethod(int startX, int startY, int endX, int endY, bool isByAxisX)
        {
            int x = startX, y = startY, p = -(endX - startX);
            int k1 = Math.Abs(2 * (endY - startY));
            int k2 = -2 * (endX - startX);
            int growthBy = ((endY - startY) > 0) ? 1 : -1;

            for (int i = 0; i <= endX - startX; i++)
            {
                if (isByAxisX) PaintPixel(x, y, 0, 0, 255);
                else PaintPixel(y, x, 0, 0, 255);

                x++;
                p += k1;

                if(p > 0)
                {
                    y += growthBy;
                    p += k2;
                }
            }
        }

        public void SaveBmp(int w, int h, int tloustka)
        {
            w *= tloustka;                          // zv�t�en� velikosti "pixelu"
            h *= tloustka;

            string f = "test.bmp";
            int filesize = 54 + 3 * w * h;          // w ���ka, h v��ka obr�zku, 3 kan�ly, velikost hlavi�ky
            byte[] img = new byte[filesize];        // nov� pole, jednorozm�rn�

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int x = i;
                    int y = (h - 1) - j;

                    img[(x + y * w) * 3 + 2] = R[i / tloustka, j / tloustka];       // celo��seln� d�len�; po�ad� B, G, R
                    img[(x + y * w) * 3 + 1] = G[i / tloustka, j / tloustka];       // budou ozna�eny v�echny pixely ve �tverci tloustka � tloustka
                    img[(x + y * w) * 3 + 0] = B[i / tloustka, j / tloustka];
                }
            }

            byte[] bmpfileheader = new byte[14] { (byte)'B', (byte)'M', 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 0 };
            byte[] bmpinfoheader = new byte[40] { 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] bmppad = new byte[3] { 0, 0, 0 };

            bmpfileheader[2] = (byte)(filesize);
            bmpfileheader[3] = (byte)(filesize >> 8);
            bmpfileheader[4] = (byte)(filesize >> 16);
            bmpfileheader[5] = (byte)(filesize >> 24);

            bmpinfoheader[4] = (byte)(w);
            bmpinfoheader[5] = (byte)(w >> 8);
            bmpinfoheader[6] = (byte)(w >> 16);
            bmpinfoheader[7] = (byte)(w >> 24);
            bmpinfoheader[8] = (byte)(h);
            bmpinfoheader[9] = (byte)(h >> 8);
            bmpinfoheader[10] = (byte)(h >> 16);
            bmpinfoheader[11] = (byte)(h >> 24);

            using (FileStream fs = File.Create(f))
            {
                fs.Write(bmpfileheader, 0, 14);
                fs.Write(bmpinfoheader, 0, 40);
                fs.Write(img, 0, 3 * w * h);
                fs.Write(bmppad, 0, 3);
            }
        }
    }
}
