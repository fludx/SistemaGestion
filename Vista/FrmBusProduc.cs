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
    public partial class FrmBusProduc : Form
    {
        public FrmBusProduc()
        {
            InitializeComponent();
        }

        private void FrmBusProduc_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            var logica = new Od_ListarProductos();
            var resultado = logica.ListarProductos();

            if (resultado == null)
            {
                MessageBox.Show("Error al cargar productos: resultado nulo.");
                return;
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = resultado;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dgvProductos.DataSource as DataTable).DefaultView.RowFilter =
        $"NombreProducto LIKE '%{textBox1.Text}%'";
        }
    }
}
