using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePainterProject.Interfaces
{
    interface IPainterObject
    {
        int Id { get; }

        Point Position { get; }

        Size Size { get; }

        Color Color { get; }
    }
}
