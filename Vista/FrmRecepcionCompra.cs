using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace Vista
{
    public class FrmRecepcionCompra : Form
    {
        private DataGridView dgvOrdenes;
        private DataGridView dgvDetalle;
        private Button btnRefrescar;
        private Button btnRegistrar;
        private readonly N_OrdenesCompra _nOC = new N_OrdenesCompra();

        public FrmRecepcionCompra()
        {
            InitializeComponent();
            Load += FrmRecepcionCompra_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Recepción de Compras";
            this.Size = new Size(1000, 700);
            dgvOrdenes = new DataGridView { Location = new Point(20, 20), Size = new Size(940, 220), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvDetalle = new DataGridView { Location = new Point(20, 260), Size = new Size(940, 340), ReadOnly = true };
            btnRefrescar = new Button { Text = "Refrescar", Location = new Point(20, 620), Size = new Size(100, 30) };
            btnRegistrar = new Button { Text = "Registrar Recepción", Location = new Point(140, 620), Size = new Size(160, 30) };

            btnRefrescar.Click += (s, e) => LoadOrdenes();
            btnRegistrar.Click += BtnRegistrar_Click;
            dgvOrdenes.SelectionChanged += DgvOrdenes_SelectionChanged;

            this.Controls.Add(dgvOrdenes);
            this.Controls.Add(dgvDetalle);
            this.Controls.Add(btnRefrescar);
            this.Controls.Add(btnRegistrar);
        }

        private void FrmRecepcionCompra_Load(object sender, EventArgs e)
        {
            LoadOrdenes();
        }

        private void LoadOrdenes()
        {
            try
            {
                var res = _nOC.ListarOrdenesPendientes();
                if (!res.Success)
                {
                    MessageBox.Show("Error cargando ordenes: " + string.Join("\n", res.Messages));
                    return;
                }
                dgvOrdenes.DataSource = res.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0) return;
            var row = dgvOrdenes.SelectedRows[0];
            if (row.Cells["id_orden_compra"] == null) return;
            int id = Convert.ToInt32(row.Cells["id_orden_compra"].Value);
            LoadDetalle(id);
        }

        private void LoadDetalle(int idOrden)
        {
            try
            {
                var res = _nOC.ObtenerDetalleOrden(idOrden);
                if (!res.Success)
                {
                    MessageBox.Show("Error cargando detalle: " + string.Join("\n", res.Messages));
                    return;
                }
                dgvDetalle.DataSource = res.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0) { MessageBox.Show("Seleccione una orden."); return; }
            int id = Convert.ToInt32(dgvOrdenes.SelectedRows[0].Cells["id_orden_compra"].Value);
            var confirm = MessageBox.Show($"Registrar recepción de OC {id} ?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;
            var res = _nOC.RegistrarRecepcion(id, Environment.UserName);
            if (res.Success) { MessageBox.Show("Recepción registrada."); LoadOrdenes(); dgvDetalle.DataSource = null; }
            else MessageBox.Show("Error: " + string.Join("\n", res.Messages));
        }
    }
}