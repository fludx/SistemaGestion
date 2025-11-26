using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Datos.DTOs_Stock;
using Negocio;

namespace Vista
{
    public partial class FrmABMPRodu : Form
    {
        private readonly N_Productos _nProductos = new N_Productos();

        // Controles añadidos en tiempo de ejecución
        private ComboBox cmbCategoria;
        private ComboBox cmbTipoProducto;
        private Label lblCategoria;
        private Label lblTipoProducto;

        public FrmABMPRodu()
        {
            InitializeComponent();
            Load += FrmABMPRodu_Load;

            button1.Click += button1_Click;   // Agregar
            button3.Click += button3_Click;   // Eliminar
            TXTCod.KeyDown += TXTCod_KeyDown; // Buscar enter

            // Crear combobox de categorías y tipo de producto dinámicamente
            // (se agregan al formulario para no depender del diseñador)
            cmbCategoria = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 180
            };
            lblCategoria = new Label
            {
                Text = "Categoría:",
                AutoSize = true
            };

            cmbTipoProducto = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 120
            };
            cmbTipoProducto.Items.AddRange(new[] { "Existencia", "JIT" });
            lblTipoProducto = new Label
            {
                Text = "Tipo producto:",
                AutoSize = true
            };

            // Intentar ubicar los nuevos controles cerca de los existentes si existen
            try
            {
                // Si existe TXTCat en el diseñador, colocamos el combo en su lugar y ocultamos el textbox
                if (this.Controls.ContainsKey("TXTCat"))
                {
                    var tx = this.Controls["TXTCat"];
                    lblCategoria.Location = new System.Drawing.Point(tx.Location.X, tx.Location.Y - 18);
                    cmbCategoria.Location = tx.Location;
                    tx.Visible = false;
                }
                else
                {
                    // fallback: colocarlo a la derecha del TXTNombre si existe
                    if (this.Controls.ContainsKey("TXTNombre"))
                    {
                        var nameCtl = this.Controls["TXTNombre"];
                        lblCategoria.Location = new System.Drawing.Point(nameCtl.Location.X + nameCtl.Width + 10, nameCtl.Location.Y - 18);
                        cmbCategoria.Location = new System.Drawing.Point(nameCtl.Location.X + nameCtl.Width + 10, nameCtl.Location.Y);
                    }
                    else
                    {
                        lblCategoria.Location = new System.Drawing.Point(350, 20);
                        cmbCategoria.Location = new System.Drawing.Point(350, 35);
                    }
                }

                // Ubicar tipo de producto a la derecha del combo de categoría
                lblTipoProducto.Location = new System.Drawing.Point(cmbCategoria.Location.X, cmbCategoria.Location.Y + 30);
                cmbTipoProducto.Location = new System.Drawing.Point(cmbCategoria.Location.X, cmbCategoria.Location.Y + 48);
            }
            catch
            {
                lblCategoria.Location = new System.Drawing.Point(350, 20);
                cmbCategoria.Location = new System.Drawing.Point(350, 35);
                lblTipoProducto.Location = new System.Drawing.Point(350, 65);
                cmbTipoProducto.Location = new System.Drawing.Point(350, 80);
            }

            this.Controls.Add(lblCategoria);
            this.Controls.Add(cmbCategoria);
            this.Controls.Add(lblTipoProducto);
            this.Controls.Add(cmbTipoProducto);
        }

        private void FrmABMPRodu_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadCategories();
        }

        // Carga las categorías desde la BD y las pone en cmbCategoria
        private void LoadCategories()
        {
            var cs = ConfigurationManager.ConnectionStrings["MiConexion"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
            {
                MessageBox.Show("Cadena de conexión 'MiConexion' no encontrada en app.config. Las categorías no se cargarán.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter("SELECT id_categoria, nombre FROM Categorias ORDER BY nombre", conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    cmbCategoria.DisplayMember = "nombre";
                    cmbCategoria.ValueMember = "id_categoria";
                    cmbCategoria.DataSource = dt;
                    cmbCategoria.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Buscar por código con Enter
        private void TXTCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SearchAndFillByCode(TXTCod.Text?.Trim());
            }
        }

        private ProductoBuscarDTO SearchAndFillByCode(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingresa un código.", "Atención");
                return null;
            }

            try
            {
                var res = _nProductos.BuscarProducto(codigo, null, null);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages));
                    return null;
                }

                var dto = res.Data?.FirstOrDefault();
                if (dto == null)
                {
                    MessageBox.Show("No se encontró el producto.");
                    return null;
                }

                FillFieldsFromBuscar(dto);
                return dto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        private void FillFieldsFromBuscar(ProductoBuscarDTO dto)
        {
            TXTCod.Text = dto.Codigo;
            TXTNombre.Text = dto.Nombre;
            TXTMarca.Text = dto.Marca;
            TXTPrecioCompra.Text = dto.PrecioCompra.ToString("0.00");
            TXTPrecioVenta.Text = dto.PrecioVenta.ToString("0.00");
            TXTStockActual.Text = dto.StockActual.ToString();

            try
            {
                if (dto.Categoria != null && cmbCategoria.DataSource != null)
                {
                    cmbCategoria.SelectedValue = dto.Categoria;
                }
            }
            catch { /* ignore */ }

            // tipo de producto: si tu DTO tiene info, mapear aquí. Por ahora no hay.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var errores = ValidateRequiredFields(out ProductoDTO nuevo);

            if (errores.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errores), "Validación");
                return;
            }

            // lectura opcional del tipo seleccionado
            var tipoSeleccionado = cmbTipoProducto.SelectedItem?.ToString();

            try
            {
                var res = _nProductos.CrearProducto(nuevo);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages));
                    return;
                }

                MessageBox.Show("Producto creado.");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando producto: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var existing = SearchAndFillByCode(TXTCod.Text?.Trim());
            if (existing == null) return;

            var mod = new ProductoModificarDTO
            {
                IdProducto = existing.IdProducto,
                Codigo = TXTCod.Text?.Trim(),
                Nombre = TXTNombre.Text?.Trim(),
                Marca = NullIfEmpty(TXTMarca.Text),
                Descripcion = NullIfEmpty(TXTDescripcion.Text),
                PrecioCompra = ParseDecimal(TXTPrecioCompra.Text),
                PrecioVenta = ParseDecimal(TXTPrecioVenta.Text),
                StockMinimo = ParseInt(TXTStockMinimo.Text),
                StockIdeal = ParseInt(TXTStockIdeal.Text),
                StockMaximo = ParseInt(TXTStockMaximo.Text),
                IdCategoria = GetSelectedCategoryId(),
                Activo = existing.Activo
            };

            if (mod.IdCategoria <= 0)
            {
                MessageBox.Show("La categoría debe ser un ID válido.");
                return;
            }

            try
            {
                var res = _nProductos.ModificarProducto(mod);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages));
                    return;
                }

                MessageBox.Show("Producto modificado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificando: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var existing = SearchAndFillByCode(TXTCod.Text?.Trim());
            if (existing == null) return;

            var ans = MessageBox.Show(
                $"¿Eliminar '{existing.Nombre}' (ID {existing.IdProducto})?",
                "Confirmar",
                MessageBoxButtons.YesNo);

            if (ans != DialogResult.Yes) return;

            try
            {
                var res = _nProductos.EliminarProducto(existing.IdProducto);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages));
                    return;
                }

                MessageBox.Show("Producto eliminado.");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando: " + ex.Message);
            }
        }

        private List<string> ValidateRequiredFields(out ProductoDTO dto)
        {
            var errors = new List<string>();
            int idCat = GetSelectedCategoryId();

            dto = new ProductoDTO
            {
                Codigo = TXTCod.Text?.Trim(),
                Nombre = TXTNombre.Text?.Trim(),
                Marca = NullIfEmpty(TXTMarca.Text),
                Descripcion = NullIfEmpty(TXTDescripcion.Text),
                PrecioCompra = ParseDecimal(TXTPrecioCompra.Text),
                PrecioVenta = ParseDecimal(TXTPrecioVenta.Text),
                StockMinimo = ParseInt(TXTStockMinimo.Text),
                StockIdeal = ParseInt(TXTStockIdeal.Text),
                StockMaximo = ParseInt(TXTStockMaximo.Text),
                IdCategoria = idCat,
                Activo = true
            };

            if (string.IsNullOrWhiteSpace(dto.Codigo)) errors.Add("El código es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errors.Add("El nombre es obligatorio.");
            if (dto.IdCategoria <= 0) errors.Add("La categoría debe ser seleccionada.");
            if (cmbTipoProducto.SelectedIndex < 0) errors.Add("El tipo de producto debe seleccionarse (Existencia o JIT).");

            return errors;
        }

        private int GetSelectedCategoryId()
        {
            try
            {
                if (cmbCategoria?.SelectedValue == null) return 0;
                return Convert.ToInt32(cmbCategoria.SelectedValue);
            }
            catch
            {
                return 0;
            }
        }

        private string NullIfEmpty(string s) =>
            string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private decimal ParseDecimal(string txt)
        {
            if (decimal.TryParse(txt, out var d)) return d;
            return 0m;
        }

        private int ParseInt(string txt)
        {
            if (int.TryParse(txt, out var i)) return i;
            return 0;
        }

        private void ClearFields()
        {
            TXTCod.Text = "";
            TXTNombre.Text = "";
            TXTMarca.Text = "";
            TXTDescripcion.Text = "";
            TXTPrecioCompra.Text = "0.00";
            TXTPrecioVenta.Text = "0.00";
            TXTStockMinimo.Text = "0";
            TXTStockIdeal.Text = "0";
            TXTStockMaximo.Text = "0";
            TXTStockActual.Text = "0";
            TXTProximovenc.Text = "";
            TXTLote.Text = "";
            textBox12.Text = "";

            if (cmbCategoria != null) cmbCategoria.SelectedIndex = -1;
            if (cmbTipoProducto != null) cmbTipoProducto.SelectedIndex = -1;
        }
    }
}
