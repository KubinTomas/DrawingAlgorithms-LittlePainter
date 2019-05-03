using LittlePainterProject.Models.CustomBitmap;
using LittlePainterProject.Models.CustomBitmap.BitmapHistory;
using LittlePainterProject.Models.Managers;
using LittlePainterProject.Models.PenLineNamespace;
using LittlePainterProject.Models.Share;
using LittlePainterProject.Models.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject
{
    public partial class MainWindow : Form
    {
        private PainterManager _painterManager;
        private HashSet<Point> _mousePositions;

        private Dictionary<Keys, bool> _actions;

        private DirectBitmap _bitmap;

        public MainWindow()
        {
            InitializeComponent();

            InitializeWindowSetting();

            Initialize();
        }
        private void InitializeWindowSetting()
        {
            this.Size = MainWindowSetting.WindowSize;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Initialize()
        {
            var screenSize = Screen.PrimaryScreen.Bounds.Size;
            this.Size = screenSize;
            this.WindowState = FormWindowState.Maximized;

            controlPanel.BackColor = Color.White;
            canvas.Size = new Size(screenSize.Width, screenSize.Height - Setting.ToolBarHeight);
            canvas.Location = new Point(0, Setting.ToolBarHeight);
            canvas.BackColor = Color.White;

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            _bitmap = new DirectBitmap(canvas.Width, canvas.Height);
            _painterManager = new PainterManager(_bitmap);

            MainWindowSetting.CanvasSize = canvas.Size;

            controlPanel.painterManager = _painterManager;
            controlPanel.BackColor = Color.LightGray;
            controlPanel.Size = new Size(screenSize.Width,Setting.ToolBarHeight);
            controlPanel.Location = new Point(0, 0);

            _actions = new Dictionary<Keys, bool>();
            _mousePositions = new HashSet<Point>();

            _painterManager.IsLeftMouseButtonPressed = false;

            //assing penLineTool for debugging purpose
            _painterManager.SetTool(PenLineManager.Tool);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _painterManager.OnLeftMouseDown();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Perfom action if user end intecating with canvas
                _painterManager.OnLeftMouseUp();

                //Temporaty commented out for massive memory leak
                //draw all stored objects
               // _painterManager.Draw();

               // RefreshCanvas();
            }

        }
        private void DrawObjects()
        {
            _painterManager.Draw();

            RefreshCanvas();
        }
        /// <summary>
        /// Making canvas refresher
        /// Detecting clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasTimer_Tick(object sender, EventArgs e)
        {
            TrackMousePosition();
            //preview drawing
            if (_painterManager.IsLeftMouseButtonPressed)
            {
                _painterManager.DrawPaintPreview();

                RefreshCanvas();
            }
        }
        private void RefreshCanvas()
        {
            canvas.Image = _bitmap.Bitmap;
        }
        /// <summary>
        /// Checking if mouse position is inside canvas and etc as if user iteract then do something
        /// </summary>
        private void TrackMousePosition()
        {
            //getting mouse position relative to canvas
            var cursorPosition = canvas.PointToClient(Cursor.Position);

            if (IsCursorOutsideCanvas(cursorPosition)) return;

           _painterManager.IfUserInteractWithCanvasAddMousePoint(cursorPosition);

            
            //if (IsCursorOnCanvas(cursorPosition))
        }
        private bool IsCursorOnCanvas(Point mousePosition)
        {
            return canvas.Location.X <= mousePosition.X && canvas.Location.X + canvas.Width >= mousePosition.X &&
               canvas.Location.Y <= mousePosition.Y && canvas.Location.Y + canvas.Height >= mousePosition.Y;
        }
        private bool IsCursorOutsideCanvas(Point mousePosition)
        {
            return mousePosition.Y <= 0 || mousePosition.Y >= canvas.Height || mousePosition.X <= 0 || mousePosition.X >= canvas.Width;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C) ClearCanvas();
            if (e.KeyCode == Keys.D) DrawObjects();
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //TrackMousePosition();
            ////preview drawing
            //if (_painterManager.IsLeftMouseButtonPressed)
            //{
            //    _painterManager.DrawPaintPreview();

            //    RefreshCanvas();
            //}
        }

        private void controlPanel_MouseEnter(object sender, EventArgs e)
        {
           Cursor.Current = Cursors.Default;
        }

        private void canvas_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = _painterManager.SelectedTool.Cursor;

            canvas.Cursor = _painterManager.SelectedTool.Cursor;
        }

      
        private void ClearCanvas()
        {
            _bitmap.ClearBitmap();

            RefreshCanvas();
        }
    }
}
