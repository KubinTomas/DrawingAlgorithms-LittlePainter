using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Algorithms.Circle
{
    interface ICircleAlgorithm
    {
        IEnumerable<Point> GetCirclePoints(IBPoint center, int radius);
    }
}
