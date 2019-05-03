using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Optimalizators
{
    public static class PointOptimalizator
    {
        public static List<IBPoint> RemoveDuplicatePoints(List<IBPoint> points)
        {
            var nonDuplicatedPoints = points.Distinct().ToList();

            return nonDuplicatedPoints;
        }
        public static HashSet<Point> GetPointsBetween(Point start, Point end)
        {

            var diff_X = end.X - start.X;
            var diff_Y = end.Y - start.Y;
            int pointNum = 8;

            var interval_X = diff_X / (pointNum + 1);
            var interval_Y = diff_Y / (pointNum + 1);

            HashSet<Point> pointList = new HashSet<Point>();
            for (int i = 1; i <= pointNum; i++)
            {
                pointList.Add(new Point(end.X + interval_X * i, end.Y + interval_Y * i));
            }
            return pointList;

        }
        public static double GetDistance(Point start, Point end)
        {
            double xDelta = start.X - end.X;
            double yDelta = start.Y - end.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }
    }
}
