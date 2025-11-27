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
    public partial class FrmOrdenCompra : Form
    {
        private ComboBox cmbProveedor;
        private ComboBox cmbProducto;
        private DateTimePicker dtpFecha;
        private TextBox txtObservaciones;
        private NumericUpDown nudCantidad;
        private TextBox txtLote;
        private DateTimePicker dtpVenc;
        private TextBox txtPrecioUnit;
        private Button btnAgregarDetalle;
        private DataGridView dgvDetalles;
        private Button btnGuardarOrden;
        private Button btnCerrar;

        private readonly N_Proveedores _nProv = new N_Proveedores();
        private readonly N_Productos _nProd = new N_Productos();
        private readonly N_OrdenesCompra _nOC = new N_OrdenesCompra();

        // detalles en memoria antes de persistir
        private List<DetalleTemp> detalles = new List<DetalleTemp>();

        public FrmOrdenCompra()
        {
            InitializeComponenta();
            Load += FrmOrdenCompra_Load;
        }

        private void InitializeComponenta()
        {
            this.Text = "Crear Orden de Compra";
            this.Size = new Size(980, 620);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblProv = new Label { Text = "Proveedor:", Location = new Point(16, 14), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            cmbProveedor = new ComboBox { Location = new Point(100, 10), Size = new Size(420, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblFecha = new Label { Text = "Fecha:", Location = new Point(540, 14), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            dtpFecha = new DateTimePicker { Location = new Point(590, 10), Size = new Size(120, 24), Format = DateTimePickerFormat.Short };

            Label lblObs = new Label { Text = "Observaciones:", Location = new Point(16, 46), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            txtObservaciones = new TextBox { Location = new Point(130, 44), Size = new Size(580, 24) };

            // Detalle
            Label lblProd = new Label { Text = "Producto:", Location = new Point(16, 86), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            cmbProducto = new ComboBox { Location = new Point(100, 82), Size = new Size(360, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblCant = new Label { Text = "Cantidad:", Location = new Point(472, 86), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            nudCantidad = new NumericUpDown { Location = new Point(542, 82), Minimum = 1, Maximum = 1000000, Value = 1, Size = new Size(80, 24) };

            Label lblLote = new Label { Text = "Lote:", Location = new Point(636, 86), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            txtLote = new TextBox { Location = new Point(670, 82), Size = new Size(100, 24) };

            Label lblVenc = new Label { Text = "Venc:", Location = new Point(778, 86), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            dtpVenc = new DateTimePicker { Location = new Point(812, 82), Size = new Size(120, 24), Format = DateTimePickerFormat.Short, ShowCheckBox = true };

            Label lblPrecio = new Label { Text = "Precio unit:", Location = new Point(16, 118), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Regular) };
            txtPrecioUnit = new TextBox { Location = new Point(100, 116), Size = new Size(100, 24) };

            btnAgregarDetalle = new Button { Text = "Agregar detalle", Location = new Point(220, 114), Size = new Size(140, 28), BackColor = Color.DodgerBlue, ForeColor = Color.White };
            btnAgregarDetalle.Click += BtnAgregarDetalle_Click;

            dgvDetalles = new DataGridView { Location = new Point(16, 156), Size = new Size(920, 360), ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect };

            btnGuardarOrden = new Button { Text = "Guardar Orden", Location = new Point(620, 528), Size = new Size(140, 36), BackColor = Color.Green, ForeColor = Color.White };
            btnGuardarOrden.Click += BtnGuardarOrden_Click;

            btnCerrar = new Button { Text = "Cerrar", Location = new Point(780, 528), Size = new Size(140, 36) };
            btnCerrar.Click += (s, e) => this.Close();

            this.Controls.Add(lblProv);
            this.Controls.Add(cmbProveedor);
            this.Controls.Add(lblFecha);
            this.Controls.Add(dtpFecha);
            this.Controls.Add(lblObs);
            this.Controls.Add(txtObservaciones);
            this.Controls.Add(lblProd);
            this.Controls.Add(cmbProducto);
            this.Controls.Add(lblCant);
            this.Controls.Add(nudCantidad);
            this.Controls.Add(lblLote);
            this.Controls.Add(txtLote);
            this.Controls.Add(lblVenc);
            this.Controls.Add(dtpVenc);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(txtPrecioUnit);
            this.Controls.Add(btnAgregarDetalle);
            this.Controls.Add(dgvDetalles);
            this.Controls.Add(btnGuardarOrden);
            this.Controls.Add(btnCerrar);
        }

        private void FrmOrdenCompra_Load(object sender, EventArgs e)
        {
            LoadProveedores();
            LoadProductos();
            RefreshGrid();
        }

        private void LoadProveedores()
        {
            try
            {
                var res = _nProv.ListarProveedores();
                cmbProveedor.Items.Clear();
                if (res != null && res.Success && res.Data != null)
                {
                    foreach (var p in res.Data)
                    {
                        cmbProveedor.Items.Add(new ComboboxItem { Id = p.IdProveedor, Text = $"{p.RazonSocial} ({p.Codigo})" });
                    }
                    if (cmbProveedor.Items.Count > 0) cmbProveedor.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductos()
        {
            try
            {
                var res = _nProd.ListarProductos();
                cmbProducto.Items.Clear();
                if (res != null && res.Success && res.Data != null)
                {
                    foreach (var p in res.Data)
                    {
                        cmbProducto.Items.Add(new ComboboxItem { Id = p.IdProducto, Text = $"{p.Codigo} - {p.Nombre}" });
                    }
                    if (cmbProducto.Items.Count > 0) cmbProducto.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (!(cmbProducto.SelectedItem is ComboboxItem prod))
            {
                MessageBox.Show("Seleccione un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProd = prod.Id;
            int cantidad = (int)nudCantidad.Value;
            string lote = txtLote.Text.Trim();
            DateTime? venc = dtpVenc.Checked ? (DateTime?)dtpVenc.Value.Date : null;
            decimal? precio = null;
            if (decimal.TryParse(txtPrecioUnit.Text, out decimal p)) precio = p;

            detalles.Add(new DetalleTemp { IdProducto = idProd, Cantidad = cantidad, Lote = lote, Vencimiento = venc, PrecioUnitario = precio });
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDetalles.Columns.Clear();
            dgvDetalles.Rows.Clear();

            dgvDetalles.Columns.Add("IdProducto", "IdProducto");
            dgvDetalles.Columns.Add("Codigo", "Código");
            dgvDetalles.Columns.Add("Nombre", "Nombre");
            dgvDetalles.Columns.Add("Cantidad", "Cantidad");
            dgvDetalles.Columns.Add("Lote", "Lote");
            dgvDetalles.Columns.Add("Vencimiento", "Vencimiento");
            dgvDetalles.Columns.Add("PrecioUnit", "Precio Unit.");

            foreach (var d in detalles)
            {
                var prodItem = cmbProducto.Items.Cast<ComboboxItem>().FirstOrDefault(x => x.Id == d.IdProducto);
                string codigo = prodItem?.Text?.Split('-')?.FirstOrDefault()?.Trim() ?? "";
                string nombre = prodItem?.Text?.Split('-')?.Skip(1).FirstOrDefault()?.Trim() ?? "";
                dgvDetalles.Rows.Add(d.IdProducto, codigo, nombre, d.Cantidad, d.Lote, d.Vencimiento?.ToString("dd/MM/yyyy") ?? "", d.PrecioUnitario?.ToString("0.00") ?? "");
            }
        }

        private void BtnGuardarOrden_Click(object sender, EventArgs e)
        {
            if (!(cmbProveedor.SelectedItem is ComboboxItem prov))
            {
                MessageBox.Show("Seleccione proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (detalles.Count == 0)
            {
                MessageBox.Show("Agregue al menos un detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var res = _nOC.CrearOrdenCompra(prov.Id, dtpFecha.Value.Date, "Pendiente", txtObservaciones.Text.Trim());
                if (!res.Success || res.Data <= 0)
                {
                    MessageBox.Show("Error creando orden: " + string.Join("\n", res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idOrden = res.Data;
                bool anyError = false;

                foreach (var d in detalles)
                {
                    var rdet = _nOC.AgregarDetalle(idOrden, d.IdProducto, d.Lote, d.Vencimiento, d.Cantidad, d.PrecioUnitario);
                    if (!rdet.Success)
                    {
                        anyError = true;
                        MessageBox.Show("Error agregando detalle: " + string.Join("\n", rdet.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!anyError)
                {
                    MessageBox.Show($"Orden creada. ID: {idOrden}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    detalles.Clear();
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ComboboxItem
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public override string ToString() => Text;
        }

        private class DetalleTemp
        {
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
            public string Lote { get; set; }
            public DateTime? Vencimiento { get; set; }
            public decimal? PrecioUnitario { get; set; }
        }
    }
}