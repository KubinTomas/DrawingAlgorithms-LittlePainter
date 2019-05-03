using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Algorithms.Line
{
    interface ILineAlgorithm
    {
        IEnumerable<Point> GetPointsOnLine(IBPoint start, IBPoint end);
        IEnumerable<Point> GetPointsOnLine(int startX, int startY, int endX, int endY);
    }
}
