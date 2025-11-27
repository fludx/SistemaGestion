using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Datos.DTOs_Stock;

namespace Vista
{
    public partial class FrmPedidos : Form
    {
        private readonly N_Ventas _nVentas = new N_Ventas();

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void BtnCrearOrden_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            var venta = new Datos.DTOs_Stock.OrdenVentaDTO
            {
                IdCliente = (int)numIdCliente.Value,
                Total = numTotal.Value,
                FechaVenta = DateTime.Now,
                MetodoPago = string.Empty,
                Observaciones = string.Empty
            };

            // Llamar a la capa de negocio para crear la orden
            var resultado = _nVentas.CrearOrdenVenta(venta);

            // Manejar resultado
            if (resultado.Success)
            {
                MessageBox.Show("Orden de venta creada exitosamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Errores al crear orden de venta:" + Environment.NewLine + string.Join(Environment.NewLine, resultado.Messages), "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            numIdCliente.Value = 0;
            numTotal.Value = 0;
            // Limpiar otros campos si es necesario
        }
    }
}
