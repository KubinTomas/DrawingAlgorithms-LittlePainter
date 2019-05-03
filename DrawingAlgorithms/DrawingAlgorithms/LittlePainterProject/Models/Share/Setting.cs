using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Share
{
    public static class Setting
    {
        public static readonly int ToolBarHeight = 150;


        public static readonly Color DefaultColor = Color.Black;
        public static Color SelectedColor = DefaultColor;

        public static readonly int DefaultPixelSize = 1;
        public static int SelectedPixelSize = DefaultPixelSize;
    }
}
