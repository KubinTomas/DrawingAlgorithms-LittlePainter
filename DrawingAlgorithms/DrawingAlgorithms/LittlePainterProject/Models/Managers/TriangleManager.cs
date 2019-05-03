using LittlePainterProject.Algorithms.Line;
using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.DrawingModels;
using LittlePainterProject.Models.PenLineNamespace;
using LittlePainterProject.Models.Share;
using LittlePainterProject.Models.Tools;
using LittlePainterProject.Validators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Managers
{
    public class TriangleManager : DrawingManager
    {
        private List<TriangleModel> _triangles;
        private ILineAlgorithm _bresenhamLine;

        private HashSet<IBPoint> _lastPreviewPoints;

        public static readonly Tool Tool = new TriangleTool();

        public TriangleManager(ICustomBitmap bitmap) : base(bitmap)
        {
            _triangles = new List<TriangleModel>();
            _bresenhamLine = new BresenhamLine();
            _lastPreviewPoints = new HashSet<IBPoint>();
        }
        public void Add(TriangleModel triangle)
        {
            _triangles.Add(triangle);
        }
        public void Remove(TriangleModel triangle)
        {
            _triangles.Remove(triangle);
        }
        public override void Draw()
        {
            foreach (var triangle in _triangles)
            {
                foreach (var point in triangle.GetPoints())
                {
                    var pixelSize = triangle.Size;
                    var pointX = point.X;
                    var pointY = point.Y;

                    for (int i = pointX - pixelSize; i < pointX + pixelSize; i++)
                    {
                        for (int j = pointY - pixelSize; j < pointY + pixelSize; j++)
                        {
                            if (CanvasValidator.IsCursorOutsideCanvas(new Point(i, j))) continue;

                            var newPoint = new BPoint(i, j, point.Color);

                            _bitmap.SetPixel(newPoint);
                        }
                    }
                }
            }
        }

        public override void PreviewDrawing(HashSet<Point> mousePositions)
        {
            if (mousePositions.Count == 1) _lastPreviewPoints = new HashSet<IBPoint>();

            foreach (var point in _lastPreviewPoints)
            {
                _bitmap.SetPixel(point.X, point.Y, point.Color);
            }

            var startPoint = mousePositions.ElementAt(0);
            var endPoint = mousePositions.ElementAt(mousePositions.Count - 1);
            var radius = (int)BPoint.GetDistance(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            var leftPoint = new BPoint(0, 0);
            var rightPoint = new BPoint(0, 0);

            //Check if mouse is under start point or above
            if(startPoint.Y > endPoint.Y)
            {
                leftPoint = new BPoint(startPoint.X - radius, startPoint.Y - radius);
                rightPoint = new BPoint(startPoint.X + radius, startPoint.Y - radius);
            }
            else
            {
                leftPoint = new BPoint(startPoint.X - radius, startPoint.Y + radius);
                rightPoint = new BPoint(startPoint.X + radius, startPoint.Y + radius);
            }

            var pointsFromStartToLeft = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, leftPoint.X, leftPoint.Y);
            var pointsFromStartToRight = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, rightPoint.X, rightPoint.Y);
            var pointsFromLeftToRight = _bresenhamLine.GetPointsOnLine(leftPoint.X, leftPoint.Y, rightPoint.X, rightPoint.Y);

            var megredPoints = pointsFromStartToLeft.Concat(pointsFromStartToRight);
            megredPoints = megredPoints.Concat(pointsFromLeftToRight);

            foreach (var point in megredPoints)
            {
                var pixelSize = Setting.SelectedPixelSize;
                var pointX = point.X;
                var pointY = point.Y;

                for (int i = pointX - pixelSize; i < pointX + pixelSize; i++)
                {
                    for (int j = pointY - pixelSize; j < pointY + pixelSize; j++)
                    {
                        if (CanvasValidator.IsCursorOutsideCanvas(new Point(i, j))) continue;

                        var newPoint = new BPoint(i, j, Setting.SelectedColor);

                        var currentPixel = _bitmap.GetPixel(i, j);

                        var bPoint = new BPoint(i, j, Color.FromArgb(currentPixel.A, currentPixel.R, currentPixel.G, currentPixel.B));
                        _lastPreviewPoints.Add(bPoint);

                        _bitmap.SetPixel(newPoint);
                    }
                }
            }
        }

        public override void SaveDrawing(HashSet<Point> mousePositions)
        {
            var startPoint = mousePositions.ElementAt(0);
            var endPoint = mousePositions.ElementAt(mousePositions.Count - 1);
            var radius = (int)BPoint.GetDistance(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            var leftPoint = new BPoint(0, 0);
            var rightPoint = new BPoint(0, 0);

            //Check if mouse is under start point or above
            if (startPoint.Y > endPoint.Y)
            {
                leftPoint = new BPoint(startPoint.X - radius, startPoint.Y - radius);
                rightPoint = new BPoint(startPoint.X + radius, startPoint.Y - radius);
            }
            else
            {
                leftPoint = new BPoint(startPoint.X - radius, startPoint.Y + radius);
                rightPoint = new BPoint(startPoint.X + radius, startPoint.Y + radius);
            }

            var pointsFromStartToLeft = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, leftPoint.X, leftPoint.Y);
            var pointsFromStartToRight = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, rightPoint.X, rightPoint.Y);
            var pointsFromLeftToRight = _bresenhamLine.GetPointsOnLine(leftPoint.X, leftPoint.Y, rightPoint.X, rightPoint.Y);

            var megredPoints = pointsFromStartToLeft.Concat(pointsFromStartToRight);
            megredPoints = megredPoints.Concat(pointsFromLeftToRight);

            var finalPoints = new List<IBPoint>();

            foreach (var point in megredPoints)
            {
                finalPoints.Add(new BPoint(point.X, point.Y));
            }

            var triangle = new TriangleModel(finalPoints, BPoint.ConvertPointToIBPoint(startPoint), radius);

            Add(triangle);
        }
    }
}
