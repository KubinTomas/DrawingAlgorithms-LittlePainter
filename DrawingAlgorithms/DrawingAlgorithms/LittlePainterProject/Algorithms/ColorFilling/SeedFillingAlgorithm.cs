using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.Share;
using LittlePainterProject.Validators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Algorithms.ColorFilling
{
    public class SeedFillingAlgorithm : IColorFillingAlgorithm
    {
        private readonly ICustomBitmap _bitmap;
        private Color _fillingColor;

        public SeedFillingAlgorithm(ICustomBitmap bitmap)
        {
            _bitmap = bitmap;
            _fillingColor = Color.White;
        }

        public void Fill(IBPoint point)
        {
            _fillingColor = _bitmap.GetPixel(point.X, point.Y);
        }

        public void Fill(IBPoint point, Color fillingColor)
        {
            _fillingColor = _bitmap.GetPixel(point.X, point.Y);

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(point.X, point.Y));

            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();
                if (!CanvasValidator.IsCursorOutsideCanvas(a))
                {
                    var col = _bitmap.GetPixel(a.X, a.Y);

                    if (col.ToArgb().Equals(_fillingColor.ToArgb()) && !col.ToArgb().Equals(Setting.SelectedColor.ToArgb()))
                    {
                        _bitmap.SetPixel(a.X, a.Y, Setting.SelectedColor);
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                }
            }
        }

        public void FloodFill(int x, int y, Color newColor)
        {
            throw new NotImplementedException();
        }
    }


}
