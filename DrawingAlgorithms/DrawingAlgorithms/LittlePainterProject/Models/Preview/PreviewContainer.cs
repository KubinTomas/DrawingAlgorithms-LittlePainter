using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Preview
{
    public abstract class PreviewContainer
    {
        public HashSet<Point> MousePoints { get; set; }

        public IBPoint StartPoint { get; set; }
        public IBPoint EndPoint { get; set; }
    }
}
