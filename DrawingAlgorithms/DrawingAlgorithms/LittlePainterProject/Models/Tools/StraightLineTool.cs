using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject.Models.Tools
{
    public class StraightLineTool : Tool
    {
        public StraightLineTool()
        {
            Identifier = this.GetType().Name;
            Name = "Straight line tool";
            IsEnabled = true;

            Cursor = Cursors.Cross;
        }
    }
}
