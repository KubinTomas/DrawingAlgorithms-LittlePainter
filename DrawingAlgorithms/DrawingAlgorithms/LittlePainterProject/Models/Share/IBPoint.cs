using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Share
{
    public interface IBPoint
    {
        int X { get; set; }
        int Y { get; set; }

        Color Color { get; set; }
        Color PreviousColor { get; }

        bool DoesPointMatchPosition(IBPoint point);

        void SetRandomColor();

        
    }
}
