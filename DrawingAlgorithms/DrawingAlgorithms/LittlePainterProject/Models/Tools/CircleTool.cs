using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject.Models.Tools
{
    public class CircleTool : Tool
    {
        public CircleTool()
        {
            Identifier = this.GetType().Name;
            Name = "Circle tool";
            IsEnabled = true;

            Cursor = Cursors.Hand;
        }
    }
}
