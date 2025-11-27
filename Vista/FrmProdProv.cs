using Datos.DTOs_Stock;
using Datos.Od_Stock;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmProdProv : Form
    {
        private ComboBox cmbProveedores;
        private DataGridView dgvAssigned;
        private DataGridView dgvAllProducts;
        private Button btnAsignar;
        private Button btnDesasignar;
        private Button btnRefrescar;
        private Button btnCerrar;
        private Label lblProv;
        private Label lblAssigned;
        private Label lblAll;

        private readonly N_Proveedores _nProveedores = new N_Proveedores();
        private readonly N_Productos _nProductos = new N_Productos();
        private readonly Od_DesasignarProductoProveedor _odDesasignar = new Od_DesasignarProductoProveedor();

        private List<object> _proveedoresRaw = new List<object>();
        private List<object> _productosRaw = new List<object>();

        public FrmProdProv()
        {
            InitializeComponent();
            InitializeComponenta();
            Load += FrmProdProv_Load;
        }

        private void InitializeComponenta()
        {
            this.Text = "Relación Producto - Proveedor";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            lblProv = new Label { Text = "Proveedor:", Location = new Point(20, 15), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Bold) };
            cmbProveedores = new ComboBox { Location = new Point(100, 10), Size = new Size(420, 24), DropDownStyle = ComboBoxStyle.DropDownList };

            btnRefrescar = new Button { Text = "Refrescar", Location = new Point(540, 8), Size = new Size(90, 28) };
            btnRefrescar.Click += (s, e) => RefreshAll();

            btnCerrar = new Button { Text = "Cerrar", Location = new Point(640, 8), Size = new Size(90, 28) };
            btnCerrar.Click += (s, e) => this.Close();

            lblAssigned = new Label { Text = "Productos del proveedor", Location = new Point(20, 50), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Bold) };
            dgvAssigned = new DataGridView { Location = new Point(20, 75), Size = new Size(420, 420), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            lblAll = new Label { Text = "Todos los productos", Location = new Point(460, 50), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Bold) };
            dgvAllProducts = new DataGridView { Location = new Point(460, 75), Size = new Size(400, 360), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            btnAsignar = new Button { Text = "Asignar →", Location = new Point(460, 450), Size = new Size(120, 36) };
            btnDesasignar = new Button { Text = "← Desasignar", Location = new Point(600, 450), Size = new Size(120, 36) };

            btnAsignar.Click += BtnAsignar_Click;
            btnDesasignar.Click += BtnDesasignar_Click;

            this.Controls.Add(lblProv);
            this.Controls.Add(cmbProveedores);
            this.Controls.Add(btnRefrescar);
            this.Controls.Add(btnCerrar);
            this.Controls.Add(lblAssigned);
            this.Controls.Add(dgvAssigned);
            this.Controls.Add(lblAll);
            this.Controls.Add(dgvAllProducts);
            this.Controls.Add(btnAsignar);
            this.Controls.Add(btnDesasignar);

            cmbProveedores.SelectedIndexChanged += CmbProveedores_SelectedIndexChanged;
        }

        private void FrmProdProv_Load(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void RefreshAll()
        {
            LoadProveedores();
            LoadAllProducts();
            LoadAssignedProducts();
        }

        private void LoadProveedores()
        {
            try
            {
                cmbProveedores.Items.Clear();
                _proveedoresRaw.Clear();

                var res = _nProveedores.ListarProveedores();
                if (res != null && res.Success && res.Data != null)
                {
                    foreach (var p in res.Data)
                    {
                        int id = GetIntProperty(p, new[] { "IdProveedor", "Id_Proveedor", "Id", "id_proveedor", "idProveedor" });
                        string txt = GetStringProperty(p, new[] { "RazonSocial", "Razon_Social", "Nombre", "nombre", "razon_social" });
                        if (string.IsNullOrEmpty(txt))
                        {
                            txt = GetStringProperty(p, new[] { "Codigo" }) ?? ("Proveedor " + id);
                        }
                        cmbProveedores.Items.Add(new ComboboxItem { Id = id, Text = $"{txt} ({GetStringProperty(p, new[] { "Codigo", "codigo" })})" });
                        _proveedoresRaw.Add(p);
                    }
                }

                if (cmbProveedores.Items.Count > 0) cmbProveedores.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message);
            }
        }

        private void LoadAllProducts()
        {
            try
            {
                dgvAllProducts.Columns.Clear();
                dgvAllProducts.Rows.Clear();
                _productosRaw.Clear();

                var res = _nProductos.ListarProductos();
                if (res != null && res.Success && res.Data != null)
                {
                    // create columns
                    dgvAllProducts.Columns.Add("IdProducto", "Id");
                    dgvAllProducts.Columns.Add("Codigo", "Código");
                    dgvAllProducts.Columns.Add("Nombre", "Nombre");
                    dgvAllProducts.Columns.Add("Marca", "Marca");
                    dgvAllProducts.Columns.Add("PrecioVenta", "Precio venta");

                    foreach (var p in res.Data)
                    {
                        int id = p.IdProducto;
                        string codigo = p.Codigo ?? "";
                        string nombre = p.Nombre ?? "";
                        string marca = p.Marca ?? "";
                        string precio = p.PrecioVenta.ToString("0.00");

                        dgvAllProducts.Rows.Add(id, codigo, nombre, marca, precio);
                        _productosRaw.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando productos: " + ex.Message);
            }
        }

        private void LoadAssignedProducts()
        {
            try
            {
                dgvAssigned.Columns.Clear();
                dgvAssigned.Rows.Clear();

                int provId = GetSelectedProviderId();
                if (provId <= 0) return;

                var res = _nProveedores.ProductosDeProveedor(provId);
                if (res != null && res.Success && res.Data != null)
                {
                    dgvAssigned.Columns.Add("IdProducto", "Id");
                    dgvAssigned.Columns.Add("Codigo", "Código");
                    dgvAssigned.Columns.Add("Nombre", "Nombre");
                    dgvAssigned.Columns.Add("Marca", "Marca");
                    dgvAssigned.Columns.Add("PrecioVenta", "Precio venta");

                    foreach (var p in res.Data)
                    {
                        dgvAssigned.Rows.Add(p.IdProducto, p.Codigo ?? "", p.Nombre ?? "", p.Marca ?? "", p.PrecioVenta.ToString("0.00"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando productos del proveedor: " + ex.Message);
            }
        }

        private void CmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssignedProducts();
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            int provId = GetSelectedProviderId();
            if (provId <= 0)
            {
                MessageBox.Show("Selecciona un proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvAllProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para asignar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProd = Convert.ToInt32(dgvAllProducts.SelectedRows[0].Cells["IdProducto"].Value);

            var relacion = new RelacionProductoProveedorDTO { IdProveedor = provId, IdProducto = idProd };

            try
            {
                var res = _nProveedores.RelacionarProductoProveedor(relacion);
                if (res != null && res.Success)
                {
                    MessageBox.Show("Producto asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssignedProducts();
                }
                else
                {
                    MessageBox.Show(res?.Messages != null && res.Messages.Any() ? string.Join(Environment.NewLine, res.Messages) : "No se pudo asignar producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error asignando: " + ex.Message);
            }
        }

        private void BtnDesasignar_Click(object sender, EventArgs e)
        {
            int provId = GetSelectedProviderId();
            if (provId <= 0)
            {
                MessageBox.Show("Selecciona un proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvAssigned.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto asignado para desasignar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProd = Convert.ToInt32(dgvAssigned.SelectedRows[0].Cells["IdProducto"].Value);

            try
            {
                bool ok = _odDesasignar.Desasignar(provId, idProd);
                if (ok)
                {
                    MessageBox.Show("Producto desasignado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssignedProducts();
                }
                else
                {
                    MessageBox.Show("No se pudo desasignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error desasignando: " + ex.Message);
            }
        }

        private int GetSelectedProviderId()
        {
            if (cmbProveedores.SelectedItem is ComboboxItem it) return it.Id;
            return 0;
        }

        // reflection helpers: sacan propiedad int/string de un objeto DTO
        private int GetIntProperty(object o, string[] names)
        {
            if (o == null) return 0;
            Type t = o.GetType();
            foreach (var n in names)
            {
                var pi = t.GetProperty(n, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (pi != null)
                {
                    var v = pi.GetValue(o);
                    if (v == null) continue;
                    int.TryParse(v.ToString(), out int r);
                    return r;
                }
            }
            return 0;
        }

        private string GetStringProperty(object o, string[] names)
        {
            if (o == null) return null;
            Type t = o.GetType();
            foreach (var n in names)
            {
                var pi = t.GetProperty(n, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (pi != null)
                {
                    var v = pi.GetValue(o);
                    if (v == null) continue;
                    return v.ToString();
                }
            }
            return null;
        }

        // small simple item for combobox, avoids reflection binding issues
        private class ComboboxItem
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public override string ToString() => Text;
        }
    }
}
