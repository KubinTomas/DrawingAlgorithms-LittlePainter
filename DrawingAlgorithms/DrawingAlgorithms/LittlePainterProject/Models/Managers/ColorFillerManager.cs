using LittlePainterProject.Algorithms.ColorFilling;
using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.Share;
using LittlePainterProject.Models.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Managers
{
    public class ColorFillerManager : DrawingManager
    {
        private IColorFillingAlgorithm _colorFillingAlgorithm;
        public static readonly Tool Tool = new ColorFillerTool();

        public ColorFillerManager(ICustomBitmap bitmap) : base(bitmap)
        {
            _colorFillingAlgorithm = new SeedFillingAlgorithm(bitmap);
        }

        public override void Draw() {}

        public override void PreviewDrawing(HashSet<Point> mousePositions) {}

        /// <summary>
        /// On SaveDrawing perform color fill algorithm
        /// </summary>
        /// <param name="mousePositions"></param>
        public override void SaveDrawing(HashSet<Point> mousePositions)
        {
            if (mousePositions.Count == 0) return;

            var startPoint = BPoint.ConvertPointToIBPoint(mousePositions.ElementAt(0));
            startPoint.Color = _bitmap.GetPixel(startPoint.X, startPoint.Y);

            _colorFillingAlgorithm.Fill(startPoint, _bitmap.GetPixel(startPoint.X, startPoint.Y));
        }
    }
}
