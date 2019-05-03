using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.PenLineNamespace
{
    public class PenLine : IPaintObjectRestictions
    {
        public int zIndex { get; set ; }
        public int Size { get; set; }

        private List<IBPoint> _points;

        public PenLine(List<IBPoint> points)
        {
            _points = points;
            Size = Setting.SelectedPixelSize;
        }

        public List<IBPoint> GetPoints()
        {
            return _points;
        }
    }
}
