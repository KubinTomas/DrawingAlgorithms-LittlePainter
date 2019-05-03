using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.CustomBitmap.BitmapHistory
{
    public class DirectBitmapHistory
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public GCHandle BitsHandle { get; private set; }

        public DirectBitmapHistory(Bitmap bitmap, Int32[] bits, GCHandle bitsHandle)
        {
            Bitmap = new Bitmap(bitmap);
            Bits = bits;
            BitsHandle = bitsHandle;
        }
    }
}
