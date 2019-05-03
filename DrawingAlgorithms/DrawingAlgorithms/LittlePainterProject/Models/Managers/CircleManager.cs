using LittlePainterProject.Algorithms.Circle;
using LittlePainterProject.Models.Circle;
using LittlePainterProject.Models.CustomBitmap;
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
    public class CircleManager : DrawingManager
    {
        private List<CircleModel> _circles;
        private ICircleAlgorithm _circleAlgorithm;

        private HashSet<IBPoint> _lastPreviewCirclePoints;

        public static readonly Tool Tool = new CircleTool();

        public CircleManager(ICustomBitmap bitmap) : base(bitmap)
        {
            _circles = new List<CircleModel>();
            _circleAlgorithm = new BasicCircleAlgorithm();

            _lastPreviewCirclePoints = new HashSet<IBPoint>();
        }

        public void Add(CircleModel circle)
        {
            _circles.Add(circle);
        }

        public void Remove(CircleModel circle)
        {
            _circles.Remove(circle);
        }

        public override void Draw()
        {
            foreach (var circle in _circles)
            {
                foreach (var point in circle.GetPoints())
                {
                    var pixelSize = circle.Size;
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
            if(mousePositions.Count == 1)  _lastPreviewCirclePoints = new HashSet<IBPoint>();

            foreach (var point in _lastPreviewCirclePoints)
            {
                _bitmap.SetPixel(point.X, point.Y, point.Color);
            }

            _lastPreviewCirclePoints = new HashSet<IBPoint>();

            var startPoint = mousePositions.ElementAt(0);
            var endPoint = mousePositions.ElementAt(mousePositions.Count - 1);

            var center = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            var radius = (int)CustomPoint.GetDistance(startPoint.X, startPoint.Y, center.X, center.Y);

            var points = _circleAlgorithm.GetCirclePoints(BPoint.ConvertPointToIBPoint(center), radius);

            var finalPoints = new List<IBPoint>();

            var pixelSize = Setting.SelectedPixelSize;
            var pixelColor = Setting.SelectedColor;

            foreach (var point in points)
            {
                for (int i = point.X - pixelSize; i < point.X + pixelSize; i++)
                {
                    for (int j = point.Y - pixelSize; j < point.Y + pixelSize; j++)
                    {
                        if (CanvasValidator.IsCursorOutsideCanvas(new Point(i, j))) continue;

                        var newPoint = new BPoint(i, j, pixelColor);

                        var currentPixel = _bitmap.GetPixel(i,j);

                        var bPoint = new BPoint(i, j, Color.FromArgb(currentPixel.A,currentPixel.R, currentPixel.G, currentPixel.B));
                        _lastPreviewCirclePoints.Add(bPoint);

                        _bitmap.SetPixel(newPoint);
                    }
                }
            }
        }

        public override void SaveDrawing(HashSet<Point> mousePositions)
        {
            var startPoint = mousePositions.ElementAt(0);
            var endPoint = mousePositions.ElementAt(mousePositions.Count - 1);

            var center = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            var radius = (int)CustomPoint.GetDistance(startPoint.X, startPoint.Y, center.X, center.Y);

            var points = _circleAlgorithm.GetCirclePoints(BPoint.ConvertPointToIBPoint(center), radius);

            var finalPoints = new List<IBPoint>();

            foreach (var point in points)
            {
                finalPoints.Add(new BPoint(point.X, point.Y));
            }

            var circle = new CircleModel(finalPoints, BPoint.ConvertPointToIBPoint(center), radius);

            Add(circle);
        }

        public override void DestroySavedObjects()
        {
            _circles = new List<CircleModel>();
        }
    }
}
