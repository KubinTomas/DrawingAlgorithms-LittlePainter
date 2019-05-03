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


        //public void FloodFill(int x, int y, Color newColor)
        //{

        //    // Get the old and new colors' components.
        //    byte old_r, old_g, old_b, old_a;
        //    GetPixel(x, y, out old_r, out old_g, out old_b, out old_a);
        //    byte new_r = newColor.R;
        //    byte new_g = newColor.G;
        //    byte new_b = newColor.B;
        //    byte new_a = newColor.A;

        //    // If the colors are the same, we're done.
        //    if ((old_r == new_r) && (old_g == new_g) &&
        //        (old_b == new_b) && (old_a == new_a)) return;

        //    // Start with the original point in the stack.
        //    Stack<Point> points = new Stack<Point>();
        //    points.Push(new Point(x, y));
        //    SetPixel(x, y, new_r, new_g, new_b, new_a);

        //    // While the stack is not empty, process a point.
        //    while (points.Count > 0)
        //    {
        //        Point pt = points.Pop();
        //        if (pt.X > 0) CheckPoint(points, pt.X - 1, pt.Y, old_r, old_g, old_b, old_a, new_r, new_g, new_b, new_a);
        //        if (pt.Y > 0) CheckPoint(points, pt.X, pt.Y - 1, old_r, old_g, old_b, old_a, new_r, new_g, new_b, new_a);
        //        if (pt.X < Width - 1) CheckPoint(points, pt.X + 1, pt.Y, old_r, old_g, old_b, old_a, new_r, new_g, new_b, new_a);
        //        if (pt.Y < Height - 1) CheckPoint(points, pt.X, pt.Y + 1, old_r, old_g, old_b, old_a, new_r, new_g, new_b, new_a);
        //    }
        //}

        public void Fill(IBPoint point)
        {
            _fillingColor = _bitmap.GetPixel(point.X, point.Y);
        }

        //public void Fill(IBPoint point, Color fillingColor)
        //{
        //    _fillingColor = fillingColor;

        //    Fill(point);
        //}
        public void Fill(IBPoint point, Color fillingColor)
        {
            _fillingColor = _bitmap.GetPixel(point.X, point.Y);

            Stack<Point> pixels = new Stack<Point>();
            int counter = 0;
            pixels.Push(new Point(point.X, point.Y));


            //foreach (var p in pixels)
            //{
            //    _bitmap.SetPixel(p.X, p.Y, Color.Red);
            //}
            //var targetColor = _bitmap.GetPixel(point.X, point.Y);

            while (pixels.Count > 0)
            {
                Point a = pixels.Pop();
                if (!CanvasValidator.IsCursorOutsideCanvas(a))
                {
                    var col = _bitmap.GetPixel(a.X, a.Y);

                    if (col.ToArgb().Equals(_fillingColor.ToArgb()) && !col.ToArgb().Equals(Setting.SelectedColor.ToArgb()))
                    {
                        _bitmap.SetPixel(a.X, a.Y, Setting.SelectedColor);
                        counter++;
                        pixels.Push(new Point(a.X - 1, a.Y));
                        pixels.Push(new Point(a.X + 1, a.Y));
                        pixels.Push(new Point(a.X, a.Y - 1));
                        pixels.Push(new Point(a.X, a.Y + 1));
                    }
                }
            }
            //return;
        }

        public void FloodFill(int x, int y, Color newColor)
        {
            throw new NotImplementedException();
        }
    }


}
