using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittlePainterProject.Models.Tools
{
    public class TriangleTool : Tool
    {
        public TriangleTool()
        {
            Identifier = this.GetType().Name;
            Name = "Traingle tool";
            IsEnabled = true;

            Cursor = Cursors.Hand;
        }
    }
}
