using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Customize
{
    /// <summary>
    /// Contains specific color methods, random color, etc. 
    /// </summary>
    public static class MagicColor
    {
        private static Random _random = new Random();

        public static Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }
    }
}
