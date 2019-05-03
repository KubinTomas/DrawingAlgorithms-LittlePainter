using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Algorithms.ColorFilling
{
    interface IColorFillingAlgorithm
    {
        void Fill(IBPoint point);
        void Fill(IBPoint point, Color fillingColor);
        void FloodFill(int x, int y, Color newColor);
    }
}
