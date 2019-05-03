using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Models.Share
{
    public interface IPaintObjectRestictions
    {
        int zIndex { get; set; }
        int Size { get; set; }

        List<IBPoint> GetPoints();
    }
}
