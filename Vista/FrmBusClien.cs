using Logica.Logica_Clientes;
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
    public partial class FrmBusClien : Form
    {
        public FrmBusClien()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void FrmBusClien_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                LogicClientes logica = new LogicClientes();
                var resultado = logica.ListarClientes();

                if (!resultado.Success)
                {
                    string errores = string.Join("\n", resultado.HasErrors);
                    MessageBox.Show("Error al cargar clientes:\n\n" + errores);
                    return;
                }

                dgvClientes.DataSource = resultado.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dgvClientes.DataSource as DataTable).DefaultView.RowFilter =
        $"NombreProducto LIKE '%{textBox1.Text}%'";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
