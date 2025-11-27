using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Negocio;
using Datos.DTOs_Stock;

namespace Vista
{
    public partial class FrmBuscarProveedor : Form
    {
        private readonly N_Productos _nProductos = new N_Productos();
        private List<string> _codeList = new List<string>();
        private int? _currentProductId;

        public FrmBuscarProveedor()
        {
            InitializeComponent();

            // Suscribir eventos de forma segura (control puede venir del Designer)
            Load += FrmBuscarProveedor_Load;
            try { if (TXTCod != null) TXTCod.KeyDown += TXTCod_KeyDown; } catch { }
            try { if (cmbCodigo != null) { cmbCodigo.KeyDown += CmbCodigo_KeyDown; cmbCodigo.SelectedIndexChanged += CmbCodigo_SelectedIndexChanged; } } catch { }
            try { if (button1 != null) button1.Click += button1_Click; } catch { }
            try { if (button2 != null) button2.Click += button2_Click; } catch { }
            try { if (button3 != null) button3.Click += button3_Click; } catch { }
            try { if (btnNuevo != null) btnNuevo.Click += BtnNuevo_Click; } catch { }
        }

        private void FrmBuscarProveedor_Load(object sender, EventArgs e)
        {
            ClearFields();
            PopulateCodeCombo();
            // Cargar categorías si el designer expone cmbCategoria desde el .Designer
            try { if (cmbCategoria != null) { /* si es necesario, cargar datasource aquí */ } } catch { }
        }

        // Buscar por Enter en TXTCod (si existe)
        private void TXTCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.Handled = true;
            e.SuppressKeyPress = true;
            var cod = (sender as TextBox)?.Text?.Trim();
            if (string.IsNullOrEmpty(cod)) return;
            var p = SearchProduct(cod);
            if (p != null) FillFields(p);
        }

        // Manejo de selección en combo (si existe)
        private void CmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCodigo == null) return;
            var cod = cmbCodigo.Text?.Trim();
            if (string.IsNullOrEmpty(cod)) return;
            var p = SearchProduct(cod);
            if (p != null) FillFields(p);
        }

        private void CmbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var cod = cmbCodigo.Text?.Trim();
            if (string.IsNullOrEmpty(cod)) return;
            var p = SearchProduct(cod);
            if (p != null) FillFields(p);
            try { cmbCodigo.Enabled = false; } catch { }
        }

        // Búsqueda usando N_Productos.BuscarProducto; muestra diálogo si hay varios resultados
        private ProductoBuscarDTO SearchProduct(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Ingrese código o nombre para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            try
            {
                var res = _nProductos.BuscarProducto(query, query, null);
                if (res == null || !res.Success)
                {
                    var msg = res?.Messages != null && res.Messages.Any() ? string.Join(Environment.NewLine, res.Messages) : "Error al buscar producto.";
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                var list = res.Data ?? new List<ProductoBuscarDTO>();
                if (list.Count == 0)
                {
                    MessageBox.Show("Producto no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                if (list.Count == 1) return list[0];
                return ShowProductSelectionDialog(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private ProductoBuscarDTO ShowProductSelectionDialog(List<ProductoBuscarDTO> list)
        {
            using (var f = new Form())
            {
                f.Text = "Seleccionar producto";
                f.StartPosition = FormStartPosition.CenterParent;
                f.Size = new Size(700, 420);

                var dgv = new DataGridView
                {
                    Dock = DockStyle.Top,
                    Height = 340,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    DataSource = list.Select(p => new
                    {
                        p.IdProducto,
                        p.Codigo,
                        p.Nombre,
                        p.Marca,
                        p.Categoria,
                        p.PrecioCompra,
                        p.PrecioVenta,
                        p.StockActual
                    }).ToList()
                };

                var btnOk = new Button { Text = "Aceptar", DialogResult = DialogResult.OK, Location = new Point(420, 360), Size = new Size(120, 30) };
                var btnCancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(540, 360), Size = new Size(120, 30) };

                f.Controls.Add(dgv);
                f.Controls.Add(btnOk);
                f.Controls.Add(btnCancel);
                f.AcceptButton = btnOk;
                f.CancelButton = btnCancel;

                if (f.ShowDialog(this) != DialogResult.OK) return null;
                if (dgv.SelectedRows.Count == 0) return null;

                var idObj = dgv.SelectedRows[0].Cells["IdProducto"].Value;
                if (idObj == null) return null;
                var id = Convert.ToInt32(idObj);
                return list.FirstOrDefault(p => p.IdProducto == id);
            }
        }

        // Rellenar campos del formulario con DTO (asume controles definidos en Designer)
        private void FillFields(ProductoBuscarDTO p)
        {
            if (p == null) return;
            _currentProductId = p.IdProducto;

            try { if (cmbCodigo != null) SetSelectedCode(p.Codigo); } catch { }
            try { if (TXTNombre != null) TXTNombre.Text = p.Nombre; } catch { }
            try { if (TXTMarca != null) TXTMarca.Text = p.Marca; } catch { }
            try { if (TXTPrecioCompra != null) TXTPrecioCompra.Text = p.PrecioCompra.ToString("0.00"); } catch { }
            try { if (TXTPrecioVenta != null) TXTPrecioVenta.Text = p.PrecioVenta.ToString("0.00"); } catch { }
            try { if (TXTStockActual != null) TXTStockActual.Text = p.StockActual.ToString(); } catch { }

            // Intentar seleccionar categoría si cmbCategoria tiene DataSource
            try
            {
                if (cmbCategoria != null && cmbCategoria.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    string colNombre = dt.Columns.Contains("nombre") ? "nombre" : dt.Columns.Contains("Nombre") ? "Nombre" : null;
                    string colId = dt.Columns.Contains("id_categoria") ? "id_categoria" : dt.Columns.Contains("Id") ? "Id" : null;
                    if (colNombre != null && colId != null)
                    {
                        var row = dt.AsEnumerable().FirstOrDefault(r => string.Equals(r.Field<string>(colNombre), p.Categoria, StringComparison.OrdinalIgnoreCase));
                        if (row != null) cmbCategoria.SelectedValue = row.Field<int>(colId);
                        else cmbCategoria.SelectedIndex = -1;
                    }
                }
            }
            catch { try { cmbCategoria.SelectedIndex = -1; } catch { } }

            try { if (TXTDescripcion != null) TXTDescripcion.Text = p.Nombre; } catch { }
        }

        // Rellenar combo de códigos
        private void PopulateCodeCombo()
        {
            try
            {
                _codeList.Clear();
                var productosRes = _nProductos.ListarProductos();
                if (productosRes != null && productosRes.Success && productosRes.Data != null)
                {
                    _codeList = productosRes.Data.Where(x => !string.IsNullOrEmpty(x.Codigo)).Select(x => x.Codigo).Distinct().OrderBy(x => x).ToList();
                }

                if (cmbCodigo != null)
                {
                    cmbCodigo.Items.Clear();
                    cmbCodigo.Items.AddRange(_codeList.ToArray());
                    cmbCodigo.Text = "";
                    var acs = new AutoCompleteStringCollection();
                    acs.AddRange(_codeList.ToArray());
                    cmbCodigo.AutoCompleteCustomSource = acs;
                    cmbCodigo.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("PopulateCodeCombo: " + ex.Message);
            }
        }

        private void SetSelectedCode(string code)
        {
            if (cmbCodigo == null) return;
            if (string.IsNullOrEmpty(code)) { cmbCodigo.SelectedIndex = -1; cmbCodigo.Text = ""; return; }
            if (!_codeList.Contains(code)) { _codeList.Insert(0, code); cmbCodigo.Items.Insert(0, code); }
            cmbCodigo.Text = code;
            try { cmbCodigo.SelectedItem = code; } catch { }
        }

        private string GetSelectedCode()
        {
            try { if (cmbCodigo != null) return cmbCodigo.Text?.Trim() ?? ""; } catch { }
            try { if (TXTCod != null) return TXTCod.Text?.Trim() ?? ""; } catch { }
            return "";
        }

        private void ClearFields()
        {
            _currentProductId = null;
            try { if (TXTCod != null) TXTCod.Text = ""; } catch { }
            try { if (TXTNombre != null) TXTNombre.Text = ""; } catch { }
            try { if (TXTMarca != null) TXTMarca.Text = ""; } catch { }
            try { if (TXTPrecioCompra != null) TXTPrecioCompra.Text = "0.00"; } catch { }
            try { if (TXTPrecioVenta != null) TXTPrecioVenta.Text = "0.00"; } catch { }
            try { if (TXTStockActual != null) TXTStockActual.Text = "0"; } catch { }
            try { if (cmbCodigo != null) { cmbCodigo.Enabled = true; cmbCodigo.Text = ""; } } catch { }
            try { if (dtpVencimiento != null) dtpVencimiento.Checked = false; } catch { }
        }

        // Botones mínimos (si existen en Designer)
        private void BtnNuevo_Click(object sender, EventArgs e) => ClearFields();
        private void button1_Click(object sender, EventArgs e) { /* Implementar alta si procede */ }
        private void button2_Click(object sender, EventArgs e) { /* Implementar modificar si procede */ }
        private void button3_Click(object sender, EventArgs e) { /* Implementar eliminar si procede */ }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Evita llamadas pesadas en cada pulsación: sólo habilita/deshabilita el botón Buscar.
            try
            {
                if (button1 != null)
                    button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
            }
            catch
            {
                // Silenciar cualquier problema si algún control no existe en el designer
            }
        }
    }
}
