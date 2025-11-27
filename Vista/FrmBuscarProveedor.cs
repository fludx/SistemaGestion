using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Datos.DTOs_Stock;

namespace Vista
{
    public partial class FrmBuscarProveedor : Form
    {
        private readonly N_Proveedores _nProveedores = new N_Proveedores();
        private List<ProveedorListadoDTO> _provCache = new List<ProveedorListadoDTO>();

        public FrmBuscarProveedor()
        {
            InitializeComponent();

            // Usar los controles definidos por el diseñador:
            // comboBox1 => campo de búsqueda
            // textBox1  => texto de búsqueda
            // button1   => botón Buscar
            // dgvProveedores => grid con resultados

            // Suscribir eventos (seguro si Designer ya declaró los controles)
            try { button1.Click += BtnBuscar_Click; } catch { }
            try { textBox1.KeyDown += TextBox1_KeyDown; } catch { }
            try { dgvProveedores.CellDoubleClick += DgvProveedores_CellDoubleClick; } catch { }

            // Inicializar combo de campos
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new object[] { "Código", "Razón social", "Email" });
                comboBox1.SelectedIndex = 1; // Razón social por defecto
            }
            catch { }
        }

        private void FrmBuscarProveedor_Load(object sender, EventArgs e)
        {
            // Cargar cache inicial (lista completa) para búsquedas rápidas
            LoadProveedores();
        }

        private void LoadProveedores()
        {
            try
            {
                var res = _nProveedores.ListarProveedores();
                if (res == null || !res.Success)
                {
                    _provCache = new List<ProveedorListadoDTO>();
                    dgvProveedores.DataSource = null;
                    return;
                }

                _provCache = res.Data ?? new List<ProveedorListadoDTO>();
                dgvProveedores.DataSource = _provCache.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _provCache = new List<ProveedorListadoDTO>();
                dgvProveedores.DataSource = null;
            }
        }

           private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            var q = textBox1.Text?.Trim();
            if (string.IsNullOrEmpty(q))
            {
                dgvProveedores.DataSource = _provCache.ToList();
                return;
            }

            var field = comboBox1.SelectedItem?.ToString() ?? "Razón social";
            IEnumerable<ProveedorListadoDTO> filtered = _provCache;

            if (field == "Código")
                filtered = _provCache.Where(p => !string.IsNullOrEmpty(p.Codigo) && p.Codigo.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
            else if (field == "Razón social")
                filtered = _provCache.Where(p => !string.IsNullOrEmpty(p.RazonSocial) && p.RazonSocial.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
            else if (field == "Email")
                filtered = _provCache.Where(p => !string.IsNullOrEmpty(p.Email) && p.Email.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);

            dgvProveedores.DataSource = filtered.ToList();
        }

        private void DgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvProveedores.Rows[e.RowIndex].DataBoundItem as ProveedorListadoDTO;
            if (item == null) return;

            // Ejemplo: mostrar detalles o copiar código al portapapeles
            MessageBox.Show($"Proveedor seleccionado:{Environment.NewLine}{item.RazonSocial} ({item.Codigo})", "Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                Clipboard.SetText(item.Codigo ?? "");
            }
            catch { }
        }
    }
}
