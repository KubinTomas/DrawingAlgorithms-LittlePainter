using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.Preview;
using LittlePainterProject.Models.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject.Models.Managers
{
    public abstract class DrawingManager
    {
        protected readonly ICustomBitmap _bitmap;

        public DrawingManager(ICustomBitmap bitmap)
        {
            _bitmap = bitmap;
        }
        /// <summary>
        /// Return dictionary of all drawing managers that we can use
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Tool, DrawingManager> GetDrawingManagers(ICustomBitmap bitmap)
        {
            var drawingManagers = new Dictionary<Tool, DrawingManager>();

            drawingManagers.Add(PenLineManager.Tool, new PenLineManager(bitmap));
            drawingManagers.Add(CircleManager.Tool, new CircleManager(bitmap));
            drawingManagers.Add(StraightLineManager.Tool, new StraightLineManager(bitmap));
            drawingManagers.Add(TriangleManager.Tool, new TriangleManager(bitmap));
            drawingManagers.Add(ColorFillerManager.Tool, new ColorFillerManager(bitmap));

            return drawingManagers;
        }

        public abstract void SaveDrawing(HashSet<Point> mousePositions);

        public abstract void PreviewDrawing(HashSet<Point> mousePositions);

        public abstract void Draw();
    }
}
