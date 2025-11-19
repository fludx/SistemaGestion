using Datos.Od_Stock;
using Negocio;
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
    public partial class FrmBuscarProveedor : Form
    {
        public FrmBuscarProveedor()
        {
            InitializeComponent();
        }

        private void FrmBuscarProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                var logica = new Od_ListarProveedores(); // tu clase de lógica
                var result = logica.ListarProveedores();

                if (result == null)
                {
                    MessageBox.Show(
                        "Error al cargar proveedores: resultado nulo.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado cargando proveedores: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dgvProveedores.DataSource as DataTable).DefaultView.RowFilter =
        $"NombreProducto LIKE '%{textBox1.Text}%'";
        }
    }
}
