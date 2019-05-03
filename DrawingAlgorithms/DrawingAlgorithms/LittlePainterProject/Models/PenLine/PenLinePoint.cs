using LittlePainterProject.Interfaces;
using LittlePainterProject.Models.CustomBitmap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.PenLineNamespace
{
    /// <summary>
    /// Single point of pen
    /// </summary>
    public class PenLinePoint : IPainterObject
    {
        public static readonly Color DefaultColor = Color.Black;

        public Point Position { get; private set; }
        public Size Size { get; private set; }
        public Color Color { get; private set; }

        public int Id { get; private set; }

        private Pen _pen;

        public PenLinePoint(Point position, Size size, Color color)
        {
            this.Position = position;
            this.Size = size;
            this.Color = color;

            InitPen();
        }
        public PenLinePoint(Point position, Size size) : this(position, size, PenLinePoint.DefaultColor) { }
        public PenLinePoint(int posX, int posY, Size size, Color color) : this(new Point(posX, posY), size, color) { }
        public PenLinePoint(Point position, int width, int height, Color color) : this(position, new Size(width, height), color) { }
        public PenLinePoint(int posX, int posY, int width, int height, Color color) : this(new Point(posX, posY), new Size(width, height), color) { }

        private void InitPen()
        {
            _pen = new Pen(Brushes.Black);
        }
        private void SetPenColor()
        {
            _pen.Color = Color;
        }
        /// <summary>
        /// Draw point
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(_pen, new Rectangle(Position, Size));
        }
        private void Draw(DirectBitmap directBitmap)
        {
            for (int i = Position.X - Size.Width; i < Position.X + Size.Width; i++)
            {
                for (int j = Position.Y - Size.Height; j < Position.Y + Size.Height; j++)
                {
                    directBitmap.SetPixel(i, j, Color);
                }
            }
        }
        public void ChangeColor(Color newColor)
        {
            SetColor(newColor);
            SetPenColor();
        }
        private void SetColor(Color color)
        {
            this.Color = color;
        }
    }
}
