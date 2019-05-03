using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject.Models.Tools
{
    public class ColorFillerTool : Tool
    {
        public ColorFillerTool()
        {
            Identifier = this.GetType().Name;
            Name = "Color tool";
            IsEnabled = true;

            Cursor = Cursors.Default;
        }
    }
}
