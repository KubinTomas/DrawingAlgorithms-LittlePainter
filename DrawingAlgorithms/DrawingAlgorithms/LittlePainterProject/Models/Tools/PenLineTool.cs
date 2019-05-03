using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject.Models.Tools
{
    public class PenLineTool : Tool
    {
        public PenLineTool()
        {
            Identifier = this.GetType().Name;
            Name = "Pen line tool";
            IsEnabled = true;

            Cursor = Cursors.Cross;
        }
    }
}
