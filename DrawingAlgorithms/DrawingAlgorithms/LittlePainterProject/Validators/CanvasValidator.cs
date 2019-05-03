using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Validators
{
    public static class CanvasValidator
    {
        public static bool IsCursorOutsideCanvas(Point mousePosition)
        {
            return mousePosition.Y <= 0 || mousePosition.Y >= MainWindowSetting.CanvasSize.Height || mousePosition.X <= 0 || mousePosition.X >= MainWindowSetting.CanvasSize.Width;
        }
    }
}
