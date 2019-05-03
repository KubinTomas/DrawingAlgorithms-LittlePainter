using LittlePainterProject.Models.Customize;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Share
{
    public abstract class CustomPoint : IBPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Color _color;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                SaveOldColor(Color);
                _color = value;
            }
        }
        public Color PreviousColor { get; protected set; }


        public CustomPoint(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
            SaveOldColor(color);
        }

        public bool DoesPointMatchPosition(IBPoint point)
        {
            return X == point.X && Y == point.Y;
        }
        /// <summary>
        /// Set random color for this pixel
        /// </summary>
        public void SetRandomColor()
        {
            Color = MagicColor.GetRandomColor();
        }

        private void SaveOldColor(Color oldColor)
        {
            PreviousColor = oldColor;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 19 + Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as CustomPoint;
            return this.X == other.X && this.Y == other.Y;
        }
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
