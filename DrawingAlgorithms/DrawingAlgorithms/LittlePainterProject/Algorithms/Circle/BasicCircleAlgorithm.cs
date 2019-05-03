using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittlePainterProject.Models.Share;

namespace LittlePainterProject.Algorithms.Circle
{
    public class BasicCircleAlgorithm : ICircleAlgorithm
    {
        public IEnumerable<Point> GetCirclePoints(IBPoint center, int radius)
        {
            var points = new List<Point>();
            //Init color
            var color = Color.Red;

            //Helping variables
            Point dHelperVar = new Point(3, 2 * radius);
            int p = 1 - radius;

            //First init of coordinates
            Point coordinates = new Point(0, radius);


            while (coordinates.X <= coordinates.Y)
            {
                points.Add(new Point(center.X + coordinates.X, center.Y + coordinates.Y));
                points.Add(new Point(center.X + coordinates.X, center.Y - coordinates.Y));
                points.Add(new Point(center.X - coordinates.X, center.Y + coordinates.Y));
                points.Add(new Point(center.X - coordinates.X, center.Y - coordinates.Y));

                points.Add(new Point(center.X + coordinates.Y, center.Y + coordinates.X));
                points.Add(new Point(center.X + coordinates.Y, center.Y - coordinates.X));
                points.Add(new Point(center.X - coordinates.Y, center.Y + coordinates.X));
                points.Add(new Point(center.X - coordinates.Y, center.Y - coordinates.X));

                if (p > 0)
                {
                    p -= dHelperVar.Y;
                    dHelperVar.Y -= 2;
                    coordinates.Y--;
                }
                p += dHelperVar.X;
                dHelperVar.X += 2;
                coordinates.X++;
            }

            return points;
        }
    }
}
