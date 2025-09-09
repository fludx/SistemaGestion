using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public class MostrarToolTip
    {
        private ToolTip tt = new ToolTip();
        public void MostrarTooltip(Control control, string mensaje, int duracion = 3000)
        {
            tt.Hide(control);
            tt.Show(mensaje, control, 0, 35, duracion);
        }
    }
}
