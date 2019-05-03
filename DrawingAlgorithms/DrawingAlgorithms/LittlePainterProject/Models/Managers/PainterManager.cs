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
    public class PainterManager
    {
        // Current Tool
        public Tool SelectedTool { get; private set; }

        // Window actions
        private HashSet<Point> _mousePositions;

        public bool IsLeftMouseButtonPressed { get; set; }

        // Tools Managers
        private readonly Dictionary<Tool, DrawingManager> _drawingManagers;

        private ICustomBitmap _bitmap;

        public PainterManager(ICustomBitmap bitmap)
        {
            _mousePositions = new HashSet<Point>();

            _drawingManagers = DrawingManager.GetDrawingManagers(bitmap);

            _bitmap = bitmap;
        }
        public ICustomBitmap GetBitmap()
        {
            return _bitmap;
        }
        public void OnLeftMouseDown()
        {
            IsLeftMouseButtonPressed = true;
        }
        /// <summary>
        /// When user release mouse button
        /// </summary>
        public void OnLeftMouseUp()
        {
            IsLeftMouseButtonPressed = false;

            // clear saved mouse positions and end method if user did not selected tool or tool does not exists 
            if (SelectedTool == null || !_drawingManagers.ContainsKey(SelectedTool))
            {
                ClearMousePoints();
                return;
            }

            //get specific manager, which is related to current drawing tool
            var drawingManager = _drawingManagers[SelectedTool];

            //save our drawing -> create new drawing object and store it in correct manager
            drawingManager.SaveDrawing(_mousePositions);

            ClearMousePoints();
        }
        /// <summary>
        /// Assing empty instance of HashSet
        /// </summary>
        public void ClearMousePoints()
        {
            _mousePositions = new HashSet<Point>();
        }
        private void AddMousePoint(Point mousePoint)
        {
            _mousePositions.Add(mousePoint);
        }
        /// <summary>
        /// If user holds mouse left button, then save his mouse position in HashSet
        /// </summary>
        public void IfUserInteractWithCanvasAddMousePoint(Point mousePoint)
        {
            if (IsLeftMouseButtonPressed) AddMousePoint(mousePoint);
        } 
        public void SetTool(Tool tool)
        {
            SelectedTool = tool;
        }
        public void DrawPaintPreview()
        {
            //get specific manager, which is related to current drawing tool
            var drawingManager = _drawingManagers[SelectedTool];

            drawingManager.PreviewDrawing(_mousePositions);
        }
        public void Draw()
        {
            foreach (var drawingManager in _drawingManagers)
            {
                drawingManager.Value.Draw();
            }
        }
        public void DestroySavedDrawingObjects()
        {
            foreach (var drawingManager in _drawingManagers)
            {
                drawingManager.Value.DestroySavedObjects();
            }
        }
        /// <summary>
        /// Set all points random color
        /// </summary>
        public void RandomizePointColors()
        {
            foreach (var drawingManager in _drawingManagers)
            {
                drawingManager.Value.RandomizePointColors();
            }
        }
        /// <summary>
        /// Return previous color of all points
        /// </summary>
        public void ReturnPreviousPointColor()
        {
            foreach (var drawingManager in _drawingManagers)
            {
                drawingManager.Value.ReturnPointsPreviousColor();
            }
        }
    }
}
