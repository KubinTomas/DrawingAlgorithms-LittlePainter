using LittlePainterProject.Models.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.CustomBitmap
{
    public interface ICustomBitmap
    {
        void SetPixel(int x, int y, Color colour);

        void SetPixel(IBPoint point);

        Color GetPixel(int x, int y);

        Bitmap GetBitmap();
    }
}
