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
    public partial class FrmABMProveedoresClientes : Form
    {
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

            // Llama al InitializeComponent generado por el diseñador (.Designer.cs)
            InitializeComponent();

            // Asocia eventos a los controles creados por el diseñador
            Load += FrmABMProveedoresClientes_Load;

            // Proveedores events
            btnProvNuevo.Click += BtnProvNuevo_Click;
            btnProvGuardar.Click += BtnProvGuardar_Click;
            btnProvEditar.Click += BtnProvEditar_Click;
            btnProvEliminar.Click += BtnProvEliminar_Click;
            btnProvRefrescar.Click += BtnProvRefrescar_Click;
            dgvProveedores.CellClick += DgvProveedores_CellClick;

            // Clientes events
            btnCliNuevo.Click += BtnCliNuevo_Click;
            btnCliGuardar.Click += BtnCliGuardar_Click;
            btnCliEditar.Click += BtnCliEditar_Click;
            btnCliEliminar.Click += BtnCliEliminar_Click;
            btnCliRefrescar.Click += BtnCliRefrescar_Click;
            dgvClientes.CellClick += DgvClientes_CellClick;
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

            }
            {
                MessageBox.Show("Operación exitosa.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------- Public helpers to allow external selection --------------------
        /// <summary>
        /// Busca proveedor por código en la fuente de datos y selecciona/llena los campos.
        /// Útil para invocar desde formularios de búsqueda.
        /// </summary>
        public void SelectProveedorByCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return;
            try
            {
                var res = _nProveedores.ListarProveedores();
                if (res == null || !res.Success || res.Data == null)
                {
                    MessageBox.Show("No se pudieron obtener proveedores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var item = res.Data.FirstOrDefault(p => string.Equals(p.Codigo, codigo, StringComparison.OrdinalIgnoreCase));
                if (item == null)
                {
                    MessageBox.Show("Proveedor no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Seleccionar en la grilla si está visible
                try
                {
                    dgvProveedores.DataSource = res.Data;
                    for (int i = 0; i < dgvProveedores.Rows.Count; i++)
                    {
                        var rowItem = dgvProveedores.Rows[i].DataBoundItem as ProveedorListadoDTO;
                        if (rowItem != null && string.Equals(rowItem.Codigo, codigo, StringComparison.OrdinalIgnoreCase))
                        {
                            dgvProveedores.ClearSelection();
                            dgvProveedores.Rows[i].Selected = true;
                            dgvProveedores.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                    }
                }
                catch { /* ignore UI selection errors */ }

                // Llenar campos
                _currentProvId = item.IdProveedor;
                txtProvCodigo.Text = item.Codigo;
                txtProvRazon.Text = item.RazonSocial;
                txtProvEmail.Text = item.Email;
                txtProvFormasPago.Text = item.FormasPago;
                txtProvTiemposEntrega.Text = item.TiemposEntrega;
                txtProvDescuentos.Text = item.Descuentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}