using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAlgorithms.Algorithms
{
    class CircleAlg
    {
        public void Draw(Point center, int radius, Bitmap bmp)
        {
            //Init color
            var color = Color.Red;

            //Helping variables
            Point dHelperVar = new Point(3, 2 * radius);
            int p = 1 - radius;

            //First init of coordinates
            Point coordinates = new Point(0, radius);

            
            while(coordinates.X <= coordinates.Y)
            {
                // On base of 1 point, drawing anothers points, symetry by Y, then X, ...
                bmp.SetPixel(center.X + coordinates.X, center.Y + coordinates.Y, color);
                bmp.SetPixel(center.X + coordinates.X, center.Y - coordinates.Y, color);
                bmp.SetPixel(center.X - coordinates.X, center.Y + coordinates.Y, color);
                bmp.SetPixel(center.X - coordinates.X, center.Y - coordinates.Y, color);

                bmp.SetPixel(center.X + coordinates.Y, center.Y + coordinates.X, color);
                bmp.SetPixel(center.X + coordinates.Y, center.Y - coordinates.X, color);
                bmp.SetPixel(center.X - coordinates.Y, center.Y + coordinates.X, color);
                bmp.SetPixel(center.X - coordinates.Y, center.Y - coordinates.X, color);

                if(p > 0)
                {
                    p -= dHelperVar.Y;
                    dHelperVar.Y -= 2;
                    coordinates.Y--;
                }
                p += dHelperVar.X;
                dHelperVar.X += 2;
                coordinates.X++;
            }
        }
    }
}
