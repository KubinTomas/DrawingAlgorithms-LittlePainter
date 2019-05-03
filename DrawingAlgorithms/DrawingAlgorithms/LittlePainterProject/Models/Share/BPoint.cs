using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Share
{
    /// <summary>
    /// Class that represent custom point, color, postion
    /// Objects are created from these points
    /// </summary>
    public class BPoint : CustomPoint
    {
        public BPoint(int x, int y, Color color) : base(x, y, color)
        {
        }
        public BPoint(int x, int y) : base(x, y, Setting.SelectedColor)
        {
        }
        public static IBPoint ConvertPointToIBPoint(Point point)
        {
            return new BPoint(point.X, point.Y);
        }
    }
}
