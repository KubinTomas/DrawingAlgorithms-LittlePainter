using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.DrawingModels
{
    public class TriangleModel : IPaintObjectRestictions
    {
        public IBPoint Center { get; private set; }

        public int Radius { get; private set; }
        public int zIndex { get; set; }
        public int Size { get; set; }

        private List<IBPoint> _points;

        public TriangleModel(List<IBPoint> points, IBPoint center, int radius)
        {
            Center = center;
            Radius = radius;

            _points = points;
            Size = Setting.SelectedPixelSize;
        }

        public List<IBPoint> GetPoints()
        {
            return _points;
        }
    }
}
