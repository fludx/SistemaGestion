using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Logica.Logica_Clientes;
using Datos.DTOs_Stock;

namespace Vista
{
    public class FrmABMProveedoresClientes : Form
    {
        private TabControl tabs;
        private TabPage tabProveedores;
        private TabPage tabClientes;

        // Proveedores controls
        private DataGridView dgvProveedores;
        private TextBox txtProvCodigo, txtProvRazon, txtProvEmail, txtProvFormasPago, txtProvTiemposEntrega, txtProvDescuentos;
        private Button btnProvNuevo, btnProvGuardar, btnProvEditar, btnProvEliminar, btnProvRefrescar;

        // Clientes controls
        private DataGridView dgvClientes;
        private TextBox txtCliCodigo, txtCliRazon, txtCliEmail, txtCliFormasPago, txtCliDescuentos, txtCliLimite;
        private Button btnCliNuevo, btnCliGuardar, btnCliEditar, btnCliEliminar, btnCliRefrescar;

        private readonly N_Proveedores _nProveedores = new N_Proveedores();
        private readonly LogicClientes _logicClientes = new LogicClientes();

        // Track current selected ids
        private int? _currentProvId;
        private int? _currentCliId;

        public FrmABMProveedoresClientes()
        {
            Text = "ABM Proveedores y Clientes";
            Size = new Size(920, 600);
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            Load += FrmABMProveedoresClientes_Load;
        }

        private void InitializeComponent()
        {
            tabs = new TabControl { Dock = DockStyle.Fill };

            tabProveedores = new TabPage("Proveedores");
            tabClientes = new TabPage("Clientes");

            InitProveedoresTab();
            InitClientesTab();

            tabs.TabPages.Add(tabProveedores);
            tabs.TabPages.Add(tabClientes);

            Controls.Add(tabs);
        }

        private void InitProveedoresTab()
        {
            dgvProveedores = new DataGridView { Location = new Point(10, 10), Size = new Size(560, 480), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvProveedores.CellClick += DgvProveedores_CellClick;

            int left = 590, top = 20, w = 300, h = 26, gap = 34;

            txtProvCodigo = LabeledTextBox(tabProveedores, "Código", left, top + gap * 0, w);
            txtProvRazon = LabeledTextBox(tabProveedores, "Razón social", left, top + gap * 1, w);
            txtProvEmail = LabeledTextBox(tabProveedores, "Email", left, top + gap * 2, w);
            txtProvFormasPago = LabeledTextBox(tabProveedores, "Formas pago", left, top + gap * 3, w);
            txtProvTiemposEntrega = LabeledTextBox(tabProveedores, "Tiempos entrega", left, top + gap * 4, w);
            txtProvDescuentos = LabeledTextBox(tabProveedores, "Descuentos", left, top + gap * 5, w);

            btnProvNuevo = CreateButton("Nuevo", left, top + gap * 7);
            btnProvGuardar = CreateButton("Guardar", left + 130, top + gap * 7);
            btnProvEditar = CreateButton("Editar", left, top + gap * 8);
            btnProvEliminar = CreateButton("Eliminar", left + 130, top + gap * 8);
            btnProvRefrescar = CreateButton("Refrescar", left, top + gap * 9);

            btnProvNuevo.Click += BtnProvNuevo_Click;
            btnProvGuardar.Click += BtnProvGuardar_Click;
            btnProvEditar.Click += BtnProvEditar_Click;
            btnProvEliminar.Click += BtnProvEliminar_Click;
            btnProvRefrescar.Click += BtnProvRefrescar_Click;

            tabProveedores.Controls.AddRange(new Control[] {
                dgvProveedores, txtProvCodigo, txtProvRazon, txtProvEmail, txtProvFormasPago, txtProvTiemposEntrega, txtProvDescuentos,
                btnProvNuevo, btnProvGuardar, btnProvEditar, btnProvEliminar, btnProvRefrescar
            });
        }

        private void InitClientesTab()
        {
            dgvClientes = new DataGridView { Location = new Point(10, 10), Size = new Size(560, 480), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvClientes.CellClick += DgvClientes_CellClick;

            int left = 590, top = 20, w = 300, h = 26, gap = 34;

            txtCliCodigo = LabeledTextBox(tabClientes, "Código", left, top + gap * 0, w);
            txtCliRazon = LabeledTextBox(tabClientes, "Razón social", left, top + gap * 1, w);
            txtCliEmail = LabeledTextBox(tabClientes, "Email", left, top + gap * 2, w);
            txtCliFormasPago = LabeledTextBox(tabClientes, "Formas pago", left, top + gap * 3, w);
            txtCliDescuentos = LabeledTextBox(tabClientes, "Descuentos", left, top + gap * 4, w);
            txtCliLimite = LabeledTextBox(tabClientes, "Límite crédito", left, top + gap * 5, w);

            btnCliNuevo = CreateButton("Nuevo", left, top + gap * 7);
            btnCliGuardar = CreateButton("Guardar", left + 130, top + gap * 7);
            btnCliEditar = CreateButton("Editar", left, top + gap * 8);
            btnCliEliminar = CreateButton("Eliminar", left + 130, top + gap * 8);
            btnCliRefrescar = CreateButton("Refrescar", left, top + gap * 9);

            btnCliNuevo.Click += BtnCliNuevo_Click;
            btnCliGuardar.Click += BtnCliGuardar_Click;
            btnCliEditar.Click += BtnCliEditar_Click;
            btnCliEliminar.Click += BtnCliEliminar_Click;
            btnCliRefrescar.Click += BtnCliRefrescar_Click;

            tabClientes.Controls.AddRange(new Control[] {
                dgvClientes, txtCliCodigo, txtCliRazon, txtCliEmail, txtCliFormasPago, txtCliDescuentos, txtCliLimite,
                btnCliNuevo, btnCliGuardar, btnCliEditar, btnCliEliminar, btnCliRefrescar
            });
        }

        private TextBox LabeledTextBox(Control parent, string label, int x, int y, int width)
        {
            var lbl = new Label { Text = label, Location = new Point(x, y - 20), AutoSize = true, Font = new Font("Consolas", 9, FontStyle.Bold) };
            parent.Controls.Add(lbl);
            var tb = new TextBox { Location = new Point(x, y), Size = new Size(width, 24), Font = new Font("Consolas", 10, FontStyle.Regular) };
            parent.Controls.Add(tb);
            return tb;
        }

        private Button CreateButton(string text, int x, int y)
        {
            return new Button { Text = text, Location = new Point(x, y), Size = new Size(120, 34), BackColor = Color.Blue, ForeColor = Color.White, Font = new Font("Consolas", 9, FontStyle.Bold) };
        }

        private void FrmABMProveedoresClientes_Load(object sender, EventArgs e)
        {
            LoadProveedores();
            LoadClientes();
        }

        // -------------------- Proveedores --------------------
        private void LoadProveedores()
        {
            try
            {
                var res = _nProveedores.ListarProveedores();
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvProveedores.DataSource = null;
                    return;
                }
                dgvProveedores.DataSource = res.Data;
                _currentProvId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProvRefrescar_Click(object sender, EventArgs e) => LoadProveedores();

        private void DgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvProveedores.Rows[e.RowIndex].DataBoundItem as ProveedorListadoDTO;
            if (item == null) return;
            _currentProvId = item.IdProveedor;
            txtProvCodigo.Text = item.Codigo;
            txtProvRazon.Text = item.RazonSocial;
            txtProvEmail.Text = item.Email;
            txtProvFormasPago.Text = item.FormasPago;
            txtProvTiemposEntrega.Text = item.TiemposEntrega;
            txtProvDescuentos.Text = item.Descuentos;
        }

        private void BtnProvNuevo_Click(object sender, EventArgs e)
        {
            _currentProvId = null;
            ClearProvFields();
        }

        private void BtnProvGuardar_Click(object sender, EventArgs e)
        {
            var dto = new ProveedorDTO
            {
                Codigo = txtProvCodigo.Text.Trim(),
                RazonSocial = txtProvRazon.Text.Trim(),
                Email = txtProvEmail.Text.Trim(),
                FormasPago = txtProvFormasPago.Text.Trim(),
                TiemposEntrega = txtProvTiemposEntrega.Text.Trim(),
                Descuentos = txtProvDescuentos.Text.Trim()
            };

            // Validaciones básicas
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Codigo)) errors.Add("Código es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.RazonSocial)) errors.Add("Razón social es obligatoria.");
            if (errors.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = _nProveedores.CrearProveedor(dto);
            ShowResult(res);
            if (res.Success) { ClearProvFields(); LoadProveedores(); }
        }

        private void BtnProvEditar_Click(object sender, EventArgs e)
        {
            if (!_currentProvId.HasValue)
            {
                MessageBox.Show("Seleccione un proveedor de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dto = new ProveedorModificarDTO
            {
                IdProveedor = _currentProvId.Value,
                Codigo = txtProvCodigo.Text.Trim(),
                RazonSocial = txtProvRazon.Text.Trim(),
                Email = txtProvEmail.Text.Trim(),
                FormasPago = txtProvFormasPago.Text.Trim(),
                TiemposEntrega = txtProvTiemposEntrega.Text.Trim(),
                Descuentos = txtProvDescuentos.Text.Trim()
            };

            var res = _nProveedores.ModificarProveedor(dto);
            ShowResult(res);
            if (res.Success) { ClearProvFields(); LoadProveedores(); }
        }

        private void BtnProvEliminar_Click(object sender, EventArgs e)
        {
            if (!_currentProvId.HasValue)
            {
                MessageBox.Show("Seleccione un proveedor de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ans = MessageBox.Show("Confirma eliminar el proveedor seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans != DialogResult.Yes) return;

            var res = _nProveedores.EliminarProveedor(_currentProvId.Value);
            ShowResult(res);
            if (res.Success) { ClearProvFields(); LoadProveedores(); }
        }

        private void ClearProvFields()
        {
            txtProvCodigo.Text = "";
            txtProvRazon.Text = "";
            txtProvEmail.Text = "";
            txtProvFormasPago.Text = "";
            txtProvTiemposEntrega.Text = "";
            txtProvDescuentos.Text = "";
            _currentProvId = null;
        }

        // -------------------- Clientes --------------------
        private void LoadClientes()
        {
            try
            {
                var res = _logicClientes.ListarClientes();
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvClientes.DataSource = null;
                    return;
                }
                dgvClientes.DataSource = res.Data;
                _currentCliId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCliRefrescar_Click(object sender, EventArgs e) => LoadClientes();

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvClientes.Rows[e.RowIndex].DataBoundItem as ClienteListadoDTO;
            if (item == null) return;
            _currentCliId = item.IdCliente;
            txtCliCodigo.Text = item.Codigo;
            txtCliRazon.Text = item.RazonSocial;
            txtCliEmail.Text = item.Email;
            txtCliFormasPago.Text = item.FormasPago;
            txtCliDescuentos.Text = item.Descuentos;
            txtCliLimite.Text = item.LimiteCredito.ToString(CultureInfo.CurrentCulture);
        }

        private void BtnCliNuevo_Click(object sender, EventArgs e)
        {
            _currentCliId = null;
            ClearCliFields();
        }

        private void BtnCliGuardar_Click(object sender, EventArgs e)
        {
            var dto = new ClienteDTO
            {
                Codigo = txtCliCodigo.Text.Trim(),
                RazonSocial = txtCliRazon.Text.Trim(),
                Email = txtCliEmail.Text.Trim(),
                FormasPago = txtCliFormasPago.Text.Trim(),
                Descuentos = txtCliDescuentos.Text.Trim(),
                LimiteCredito = decimal.TryParse(txtCliLimite.Text, out var lim) ? lim : 0m
            };

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Codigo)) errors.Add("Código es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.RazonSocial)) errors.Add("Razón social es obligatoria.");
            if (errors.Any()) { MessageBox.Show(string.Join(Environment.NewLine, errors), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var res = _logicClientes.CrearCliente(dto);
            ShowResult(res);
            if (res.Success) { ClearCliFields(); LoadClientes(); }
        }

        private void BtnCliEditar_Click(object sender, EventArgs e)
        {
            if (!_currentCliId.HasValue)
            {
                MessageBox.Show("Seleccione un cliente de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dto = new ClienteModificarDTO
            {
                IdCliente = _currentCliId.Value,
                Codigo = txtCliCodigo.Text.Trim(),
                RazonSocial = txtCliRazon.Text.Trim(),
                Email = txtCliEmail.Text.Trim(),
                FormasPago = txtCliFormasPago.Text.Trim(),
                Descuentos = txtCliDescuentos.Text.Trim(),
                LimiteCredito = decimal.TryParse(txtCliLimite.Text, out var lim) ? lim : 0m
            };

            var res = _logicClientes.ModificarCliente(dto);
            ShowResult(res);
            if (res.Success) { ClearCliFields(); LoadClientes(); }
        }

        private void BtnCliEliminar_Click(object sender, EventArgs e)
        {
            if (!_currentCliId.HasValue)
            {
                MessageBox.Show("Seleccione un cliente de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ans = MessageBox.Show("Confirma eliminar el cliente seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans != DialogResult.Yes) return;

            var res = _logicClientes.EliminarCliente(_currentCliId.Value);
            ShowResult(res);
            if (res.Success) { ClearCliFields(); LoadClientes(); }
        }

        private void ClearCliFields()
        {
            txtCliCodigo.Text = "";
            txtCliRazon.Text = "";
            txtCliEmail.Text = "";
            txtCliFormasPago.Text = "";
            txtCliDescuentos.Text = "";
            txtCliLimite.Text = "0";
            _currentCliId = null;
        }

        // -------------------- Helpers --------------------
        private void ShowResult(BusinessResult res)
        {
            if (res == null)
            {
                MessageBox.Show("Respuesta nula del servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!res.Success)
            {
                MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Operación exitosa.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}