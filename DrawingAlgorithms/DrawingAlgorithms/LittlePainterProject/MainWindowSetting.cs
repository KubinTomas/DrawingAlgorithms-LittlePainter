using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject
{
    public static class MainWindowSetting
    {
        /// <summary>
        /// Setting window size
        /// </summary>
        private static int windowWidth = 1200;
        private static int windowHeight = 800;

        public static readonly Size WindowSize = new Size(windowWidth, windowHeight);

        public static Size CanvasSize;
    }
}
