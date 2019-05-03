using LittlePainterProject.Algorithms.Line;
using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.Customize;
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
    public class StraightLineManager : DrawingManager
    {
        private List<PenLine> _penLines;
        private ILineAlgorithm _bresenhamLine;

        private HashSet<IBPoint> _lastPreviewPoints;

        public static readonly Tool Tool = new StraightLineTool();

        public StraightLineManager(ICustomBitmap bitmap) : base(bitmap)
        {
            _penLines = new List<PenLine>();
            _bresenhamLine = new BresenhamLine();
            _lastPreviewPoints = new HashSet<IBPoint>();
        }
        public void AddLine(PenLine penLine)
        {
            _penLines.Add(penLine);
        }
        public void RemoveLine(PenLine penLine)
        {
            _penLines.Remove(penLine);
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

        public override void PreviewDrawing(HashSet<Point> mousePositions)
        {
            if (mousePositions.Count == 1) _lastPreviewPoints = new HashSet<IBPoint>();

            var startPoint = mousePositions.ElementAt(0);
            var endPoint = mousePositions.ElementAt(mousePositions.Count - 1);

            var linePoints = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            if (mousePositions.Count == 1) _lastPreviewPoints = new HashSet<IBPoint>();

            foreach (var point in _lastPreviewPoints)
            {
                _bitmap.SetPixel(point.X, point.Y, point.Color);
            }

            _lastPreviewPoints = new HashSet<IBPoint>();

            var pixelSize = Setting.SelectedPixelSize;
            var pixelColor = Setting.SelectedColor;

            foreach (var point in linePoints)
            {
                for (int i = point.X - pixelSize; i < point.X + pixelSize; i++)
                {
                    for (int j = point.Y - pixelSize; j < point.Y + pixelSize; j++)
                    {
                        if (CanvasValidator.IsCursorOutsideCanvas(new Point(i, j))) continue;

                        var newPoint = new BPoint(i, j, pixelColor);

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
            if (mousePositions.Count < 2) return;

            var startPoint = mousePositions.ElementAt(0);
            var endPoint = mousePositions.ElementAt(mousePositions.Count - 1);

            var linePoints = _bresenhamLine.GetPointsOnLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            var finalPoints = new List<IBPoint>();

            foreach (var point in linePoints)
            {
                finalPoints.Add(new BPoint(point.X, point.Y));
            }

            var penLine = new PenLine(finalPoints);

            _penLines.Add(penLine);
        }

        public override void DestroySavedObjects()
        {
            _penLines = new List<PenLine>();
        }

        public override void RandomizePointColors()
        {
            foreach (var penLine in _penLines)
            {
                foreach (var point in penLine.GetPoints())
                {
                    point.Color = MagicColor.GetRandomColor();
                }
            }
        }

        public override void ReturnPointsPreviousColor()
        {
            foreach (var penLine in _penLines)
            {
                foreach (var point in penLine.GetPoints())
                {
                    point.Color = point.PreviousColor;
                }
            }
        }
    }
}
