using LittlePainterProject.Algorithms.Line;
using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.Optimalizators;
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
    public class PenLineManager : DrawingManager
    {

        private List<PenLine> _penLines;
        private ILineAlgorithm _bresenhamLine;

        public static readonly Tool Tool = new PenLineTool();

        public PenLineManager(ICustomBitmap bitmap) : base(bitmap)
        {
            _penLines = new List<PenLine>();
            _bresenhamLine = new BresenhamLine();
        }
        public void AddPenLine(PenLine penLine)
        {
            _penLines.Add(penLine);
        }
        public void RemovePenLine(PenLine penLine)
        {
            _penLines.Remove(penLine);
        }
        public void RemovePenLine(int penLineId)
        {
            throw new NotImplementedException();
        }
        public override void SaveDrawing(HashSet<Point> mousePositions)
        {
            var temPoints = new List<IBPoint>();

            var mousePointsCount = mousePositions.Count;

            for (int i = 0; i < mousePointsCount - 1; i++)
            {
                var startPoint = mousePositions.ElementAt(i);
                var endPoint = mousePositions.ElementAt(i + 1);

                var linePoints = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

                foreach (var point in linePoints)
                {
                    mousePositions.Add(new Point(point.X, point.Y));
                }
            }
            var finalPoints = new List<IBPoint>();

            foreach (var point in mousePositions)
            {
                finalPoints.Add(new BPoint(point.X, point.Y));
            }

            var penLine = new PenLine(finalPoints);

            _penLines.Add(penLine);
        }
     
        public override void PreviewDrawing(HashSet<Point> points)
        {
            if (points.Count < 0) return;

            if (points.Count == 1)
            {
                var point = points.ElementAt(0);

                _bitmap.SetPixel(new BPoint(point.X, point.Y));
            }
            else
            {
                var startPoint = points.ElementAt(points.Count - 2);
                var endPoint = points.ElementAt(points.Count - 1);

                var linePoints = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

                _bitmap.SetPixel(BPoint.ConvertPointToIBPoint(startPoint));
                _bitmap.SetPixel(BPoint.ConvertPointToIBPoint(endPoint));

                foreach (var point in linePoints)
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

                            _bitmap.SetPixel(newPoint);
                        }
                    }
                }

            }
        }
        public override void Draw()
        {
            foreach (var penLine in _penLines)
            {
                foreach (var point in penLine.GetPoints())
                {
                    var pixelSize = penLine.Size;
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

        public override void DestroySavedObjects()
        {
            _penLines = new List<PenLine>();
        }
    }
}
