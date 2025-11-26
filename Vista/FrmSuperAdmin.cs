using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmSuperAdmin : Form
    {
        public FrmSuperAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MDIParent1 mdi = Application.OpenForms["MDIParent1"] as MDIParent1;

            if (mdi != null)
            {
                mdi.Enabled = true;    // 🔥 Habilita todo el MDI
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MDIStock mdi = Application.OpenForms["MDIStock"] as MDIStock;

            if (mdi != null)
            {
                mdi.Enabled = true;    // 🔥 Habilita todo el MDI
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MDIParent1 mdi = Application.OpenForms["MDIParent1"] as MDIParent1;

            if (mdi != null)
            {
                mdi.Enabled = false;   // 🔥 Deshabilita todo el MDI
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MDIStock mdi = Application.OpenForms["MDIStock"] as MDIStock;

            if (mdi != null)
            {
                mdi.Enabled = false;   // 🔥 Deshabilita todo el MDI
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAgregAdmin ventana = new FrmAgregAdmin();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }
    }
}
