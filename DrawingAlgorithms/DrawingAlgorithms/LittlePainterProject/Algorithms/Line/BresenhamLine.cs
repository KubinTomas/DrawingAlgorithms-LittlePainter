using LittlePainterProject.Algorithms.Line;
using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Algorithms.Line
{
    class BresenhamLine : ILineAlgorithm
    {
        private List<IBPoint> _points;

        public byte[,] R, G, B;

        public BresenhamLine()
        {
            _points = new List<IBPoint>();
        }
        /// <summary>
        /// Should call algorithm
        /// </summary>
        public void DrawLine(IBPoint startPoint, IBPoint endPoint)
        {
          

            CreateLine(startPoint, endPoint);

            PaintPixel(startPoint.X, startPoint.Y, 255, 0, 0);
            PaintPixel(endPoint.X, endPoint.Y, 0, 150, 0);
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
        private void CreateLine(IBPoint startPosition, IBPoint endPosition)
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
                //if (isByAxisX) PaintPixel(x, y, 0, 0, 255);
                //else PaintPixel(y, x, 0, 0, 255);

                if (isByAxisX) _points.Add(new BPoint(x, y));
                else _points.Add(new BPoint(y, x));

                x++;
                p += k1;

                if (p > 0)
                {
                    y += growthBy;
                    p += k2;
                }
            }
        }

        public List<IBPoint> GetLinePoints(IBPoint start, IBPoint end)
        {
            _points = new List<IBPoint>();

            CreateLine(start, end);

            return _points;
        }
        /// <summary>
        /// Return all points which creating a line from A to B
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        /// <returns></returns>
        public IEnumerable<Point> GetPointsOnLine(int startX, int startY, int endX, int endY)
        {
            bool steep = Math.Abs(endY - startY) > Math.Abs(endX - startX);

            if (steep)
            {
                int tmp;
                tmp = startX; // swap x0 and y0
                startX = startY;
                startY = tmp;
                tmp = endX; // swap x1 and y1
                endX = endY;
                endY = tmp;
            }
            if (startX > endX)
            {
                int tmp;
                tmp = startX; // swap x0 and x1
                startX = endX;
                endX = tmp;
                tmp = startY; // swap y0 and y1
                startY = endY;
                endY = tmp;
            }
            int dx = endX - startX;
            int dy = Math.Abs(endY - startY);
            int error = dx / 2;
            int ystep = (startY < endY) ? 1 : -1;
            int y = startY;
            for (int x = startX; x <= endX; x++)
            {
                yield return new Point((steep ? y : x), (steep ? x : y));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            yield break;
        }

        public IEnumerable<Point> GetPointsOnLine(IBPoint start, IBPoint end)
        {
            return GetPointsOnLine(start.X, start.Y, end.X, end.Y);
        }
    }
}
