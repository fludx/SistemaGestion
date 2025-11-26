using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Datos.DTOs_Stock;
using Negocio;

namespace Vista
{
    public partial class FrmABMPRodu : Form
    {
        private readonly N_Productos _nProductos = new N_Productos();

        public FrmABMPRodu()
        {
            InitializeComponent();
            Load += FrmABMPRodu_Load;

            // Conectar eventos (button2 ya está conectado en el diseñador)
            button1.Click += button1_Click; // Agregar producto
            button3.Click += button3_Click; // Eliminar
            TXTCod.KeyDown += TXTCod_KeyDown; // Buscar por Enter
        }

        private void FrmABMPRodu_Load(object sender, EventArgs e)
        {
            // Inicializar combo de tipo de stock (si lo usas)
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Existencia");
            comboBox1.Items.Add("JIT");
            comboBox1.SelectedIndex = 0;

            ClearFields();
        }

        // Buscar por código al presionar Enter en TXTCod
        private void TXTCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SearchAndFillByCode(TXTCod.Text?.Trim());
            }
        }

        // Realiza búsqueda y completa los campos si encuentra producto
        private ProductoBuscarDTO SearchAndFillByCode(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingresa un código para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            try
            {
                var res = _nProductos.BuscarProducto(codigo, null, null);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                if (res.Data == null || res.Data.Count == 0)
                {
                    MessageBox.Show("No se encontró el producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                var dto = res.Data.First();
                FillFieldsFromBuscar(dto);
                return dto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Rellena los campos disponibles desde ProductoBuscarDTO
        private void FillFieldsFromBuscar(ProductoBuscarDTO dto)
        {
            if (dto == null) return;

            TXTCod.Text = dto.Codigo;
            TXTNombre.Text = dto.Nombre;
            TXTMarca.Text = dto.Marca;
            // TXTCat contiene el nombre de categoría en ProductoBuscarDTO; si aquí guardas ID, ajusta.
            TXTCat.Text = dto.Categoria;
            TXTPrecioCompra.Text = dto.PrecioCompra.ToString("0.00", CultureInfo.CurrentCulture);
            TXTPrecioVenta.Text = dto.PrecioVenta.ToString("0.00", CultureInfo.CurrentCulture);
            TXTStockActual.Text = dto.StockActual.ToString();
            // Otros campos (descripcion, stock min/ideal/max) quedan para completar manualmente si el SP no los devuelve.
        }

        // Agregar producto
        private void button1_Click(object sender, EventArgs e)
        {
            var errores = ValidateRequiredFields(out ProductoDTO nuevo);
            if (errores.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, errores), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var res = _nProductos.CrearProducto(nuevo);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Producto creado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modificar producto (usa el código para buscar el id)
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
                IdCategoria = TryParseCategoriaId(TXTCat.Text),
                Activo = existing.Activo
            };

            if (string.IsNullOrWhiteSpace(mod.Nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var res = _nProductos.ModificarProducto(mod);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Producto modificado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificando producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar producto (usa el código para buscar el id)
        private void button3_Click(object sender, EventArgs e)
        {
            var existing = SearchAndFillByCode(TXTCod.Text?.Trim());
            if (existing == null) return;

            var ans = MessageBox.Show($"Confirma eliminar producto '{existing.Nombre}' (ID {existing.IdProducto})?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans != DialogResult.Yes) return;

            try
            {
                var res = _nProductos.EliminarProducto(existing.IdProducto);
                if (!res.Success)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, res.Messages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Producto eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validaciones mínimas y mapeo a DTO para crear
        private List<string> ValidateRequiredFields(out ProductoDTO dto)
        {
            var errors = new List<string>();
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
                IdCategoria = TryParseCategoriaId(TXTCat.Text),
                Activo = true
            };

            if (string.IsNullOrWhiteSpace(dto.Codigo)) errors.Add("El código es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Nombre)) errors.Add("El nombre es obligatorio.");
            if (dto.PrecioCompra < 0) errors.Add("Precio compra inválido.");
            if (dto.PrecioVenta < 0) errors.Add("Precio venta inválido.");

            return errors;
        }

        private string NullIfEmpty(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private decimal ParseDecimal(string txt)
        {
            if (string.IsNullOrWhiteSpace(txt)) return 0m;
            if (decimal.TryParse(txt, NumberStyles.Any, CultureInfo.CurrentCulture, out var d)) return d;
            if (decimal.TryParse(txt.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            return 0m;
        }

        private int ParseInt(string txt)
        {
            if (string.IsNullOrWhiteSpace(txt)) return 0;
            if (int.TryParse(txt, out var i)) return i;
            return 0;
        }

        private int TryParseCategoriaId(string txt)
        {
            // Si TXTCat contiene id entero, lo devolvemos.
            // Si contiene nombre, queda para implementar búsqueda de categorías.
            if (int.TryParse(txt, out var id)) return id;
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
            TXTCat.Text = "";
            TXTStockActual.Text = "0";
            TXTProximovenc.Text = "";
            TXTLote.Text = "";
        }
    }
}
