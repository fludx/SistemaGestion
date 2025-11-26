using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using Negocio;
using Datos.DTOs_Stock;
using Datos.Od_Stock;

namespace Vista
{
    public partial class FrmABMPRodu2 : Form
    {
        // Controles
        private Label label21;
        private Label label20;
        private Label label19;

        private TextBox TXTStockMinimo;
        private TextBox TXTProximovenc;
        private TextBox TXTDescripcion;

        private Button button1; //Agregar
        private Button button2; //Modificar
        private Button button3; //Eliminar
        private Button btnNuevo; // botón para limpiar/deseleccionar código

        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;

        private TextBox TXTStockMaximo;
        private TextBox TXTStockIdeal;
        private TextBox TXTStockActual;
        private TextBox TXTPrecioVenta;
        private TextBox TXTPrecioCompra;
        private TextBox TXTLote;
        // sustituido: private TextBox TXTVencimiento;
        private DateTimePicker dtpVencimiento;
        private TextBox TXTMarca;
        private TextBox TXTNombre;
        private TextBox TXTCod; // si existe en diseñador, lo mantenemos para compatibilidad a nivel runtime

        private ComboBox cmbTipo;
        private ComboBox cmbCategoria;

        // Nuevo: ComboBox para códigos (sustituye la entrada de texto para código)
        private ComboBox cmbCodigo;
        private List<string> _codeList = new List<string>();

        private readonly N_Productos _nProductos = new N_Productos();

        // Guardar Id del producto encontrado para modificar/eliminar
        private int? _currentProductId = null;

        public FrmABMPRodu2()
        {
            // Inicializa lo generado por el diseñador (archivo .Designer.cs)
            InitializeComponent();

            // Inicialización adicional sin colisionar con el diseñador
            InitializeCustomComponents();

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            // Eventos para selección/entrada de código
            if (cmbCodigo != null)
            {
                cmbCodigo.SelectedIndexChanged += cmbCodigo_SelectedIndexChanged;
                cmbCodigo.KeyDown += cmbCodigo_KeyDown;
            }
            else if (TXTCod != null)
            {
                TXTCod.KeyDown += TXTCod_KeyDown;
            }

            Load += FrmABMPRodu2_Load;
        }

        private void FrmABMPRodu2_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadCategories();
            PopulateCodeCombo();
        }

        // ================================================================
        // Inicialización personalizada (renombrada para evitar duplicados)
        // ================================================================
        private void InitializeCustomComponents()
        {
            // Si el diseñador ya ha creado controles con los mismos nombres,
            // evita recrearlos duplicados: sólo crea los que falten.
            // Aquí creamos controles si no existen en Controls.

            // Si existe TXTCod creado por el diseñador, lo reemplazamos por cmbCodigo en tiempo de ejecución.
            Control existingCod = this.Controls.ContainsKey("TXTCod") ? this.Controls["TXTCod"] : null;
            if (existingCod is TextBox tb)
            {
                var loc = tb.Location;
                var size = tb.Size;
                // remover textbox visual y crear combobox en su lugar
                this.Controls.Remove(tb);
                TXTCod = null;
                cmbCodigo = CreateComboBox(loc.X, loc.Y, size.Width);
                cmbCodigo.Name = "cmbCodigo";
                // permitir escritura y autocompletar para facilitar búsquedas
                cmbCodigo.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (this.Controls.ContainsKey("cmbCodigo"))
            {
                cmbCodigo = this.Controls["cmbCodigo"] as ComboBox;
                if (cmbCodigo != null)
                {
                    cmbCodigo.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (TXTCod != null)
            {
                // Diseñador no creó el textbox pero la variable existe; crear combobox por defecto
                var loc = TXTCod.Location;
                cmbCodigo = CreateComboBox(loc.X, loc.Y, TXTCod.Width);
                cmbCodigo.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            if (this.Controls.ContainsKey("TXTNombre"))
                TXTNombre = this.Controls["TXTNombre"] as TextBox;
            if (this.Controls.ContainsKey("TXTMarca"))
                TXTMarca = this.Controls["TXTMarca"] as TextBox;

            // Si algunos controles no existen, los creamos y añadimos.
            if (cmbCodigo == null) 
            {
                cmbCodigo = CreateComboBox(40, 50, 120);
                cmbCodigo.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            if (cmbCategoria == null) cmbCategoria = CreateComboBox(170, 50, 130);
            if (TXTNombre == null) TXTNombre = CreateTextBox(330, 50, 80);

            if (TXTMarca == null) TXTMarca = CreateTextBox(40, 110, 80);
            if (dtpVencimiento == null) dtpVencimiento = CreateDateTimePicker(165, 110, 140);
            if (TXTLote == null) TXTLote = CreateTextBox(300, 110, 80);

            if (TXTPrecioCompra == null) TXTPrecioCompra = CreateTextBox(40, 180, 80);
            if (TXTPrecioVenta == null) TXTPrecioVenta = CreateTextBox(165, 180, 80);
            if (TXTStockActual == null) TXTStockActual = CreateTextBox(300, 180, 80);

            if (TXTStockIdeal == null) TXTStockIdeal = CreateTextBox(40, 250, 80);
            if (TXTStockMaximo == null) TXTStockMaximo = CreateTextBox(165, 250, 80);
            if (TXTStockMinimo == null) TXTStockMinimo = CreateTextBox(300, 250, 80);

            if (TXTDescripcion == null) TXTDescripcion = CreateTextBox(430, 50, 140);
            if (TXTProximovenc == null) TXTProximovenc = CreateTextBox(430, 110, 90);

            if (cmbTipo == null)
            {
                cmbTipo = CreateComboBox(430, 250, 120);
                cmbTipo.Items.Add("Existencia");
                cmbTipo.Items.Add("JIT");
            }

            if (button1 == null) button1 = CreateButton("Agregar", 620, 40);
            if (button2 == null) button2 = CreateButton("Modificar", 620, 110);
            if (button3 == null) button3 = CreateButton("Eliminar", 620, 180);
            if (btnNuevo == null) btnNuevo = CreateButton("Nuevo", 620, 260);

            // Añadir controles que no estén ya en Controls
            var toAdd = new List<Control>
            {
                cmbCodigo, cmbCategoria, TXTNombre, TXTMarca, dtpVencimiento, TXTLote,
                TXTPrecioCompra, TXTPrecioVenta, TXTStockActual, TXTStockIdeal, TXTStockMaximo,
                TXTStockMinimo, TXTDescripcion, TXTProximovenc, cmbTipo, button1, button2, button3, btnNuevo
            };

            foreach (var c in toAdd)
            {
                if (c != null && !this.Controls.Contains(c))
                    this.Controls.Add(c);
            }

            // Crear y añadir labels descriptivas encima de cada TextBox/ComboBox
            // Sólo se añaden si no existen en Controls (evita duplicados).
            AddLabelIfMissing("lblCodigo", "Código", cmbCodigo);
            AddLabelIfMissing("lblCategoria", "Categoría", cmbCategoria);
            AddLabelIfMissing("lblNombre", "Nombre", TXTNombre);
            AddLabelIfMissing("lblMarca", "Marca", TXTMarca);
            AddLabelIfMissing("lblVencimiento", "Vencimiento", dtpVencimiento);
            AddLabelIfMissing("lblLote", "Lote", TXTLote);
            AddLabelIfMissing("lblPrecioCompra", "Precio compra", TXTPrecioCompra);
            AddLabelIfMissing("lblPrecioVenta", "Precio venta", TXTPrecioVenta);
            AddLabelIfMissing("lblStockActual", "Stock actual", TXTStockActual);
            AddLabelIfMissing("lblStockIdeal", "Stock ideal", TXTStockIdeal);
            AddLabelIfMissing("lblStockMaximo", "Stock máximo", TXTStockMaximo);
            AddLabelIfMissing("lblStockMinimo", "Stock mínimo", TXTStockMinimo);
            AddLabelIfMissing("lblDescripcion", "Descripción", TXTDescripcion);
            AddLabelIfMissing("lblProxVenc", "Próx. venc.", TXTProximovenc);
            AddLabelIfMissing("lblTipo", "Tipo", cmbTipo);
        }

        private void AddLabelIfMissing(string name, string text, Control targetControl)
        {
            if (targetControl == null) return;

            if (!this.Controls.ContainsKey(name))
            {
                int labelX = targetControl.Left;
                int labelY = Math.Max(0, targetControl.Top - 20);
                var lbl = CreateLabel(text, labelX, labelY);
                lbl.Name = name;
                this.Controls.Add(lbl);
            }
        }

        // ================================================================
        // MÉTODOS REUSABLES PARA CREAR CONTROLES
        // ================================================================
        private Label CreateLabel(string txt, int x, int y)
        {
            return new Label
            {
                Text = txt,
                Location = new Point(x, y),
                Font = new Font("Consolas", 10, FontStyle.Bold),
                AutoSize = true
            };
        }

        private TextBox CreateTextBox(int x, int y, int width)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 23),
                Font = new Font("Consolas", 10, FontStyle.Bold)
            };
        }

        private ComboBox CreateComboBox(int x, int y, int width)
        {
            return new ComboBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 23),
                Font = new Font("Consolas", 10, FontStyle.Bold),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
        }

        private DateTimePicker CreateDateTimePicker(int x, int y, int width)
        {
            return new DateTimePicker
            {
                Location = new Point(x, y),
                Size = new Size(width, 23),
                Font = new Font("Consolas", 10, FontStyle.Bold),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                ShowCheckBox = true // permite dejar sin fecha si no aplica
            };
        }

        private Button CreateButton(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(120, 40),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                Font = new Font("Consolas", 10, FontStyle.Bold)
            };
        }

        // ================================================================
        // FUNCIONES DEL ABM
        // ================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            var dto = LoadDTO();

            string code = GetSelectedCode();

            // Si el usuario escribió un código existente, evitar Unique Key: ofrecer generar uno nuevo.
            if (!string.IsNullOrEmpty(code) && _codeList != null && _codeList.Contains(code))
            {
                var dlg = MessageBox.Show("El código seleccionado ya existe en la base. ¿Desea generar automáticamente un nuevo código para evitar conflicto?", "Código existente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.Cancel) return;
                if (dlg == DialogResult.Yes)
                {
                    code = GenerateNewCode();
                    dto.Codigo = code;
                    AddNewCodeToCombo(code);
                    SetSelectedCode(code);
                }
                else
                {
                    // usuario eligió No -> abortar para que cambie el código manualmente
                    MessageBox.Show("Cambie el código antes de crear el producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (string.IsNullOrEmpty(code))
            {
                // generar si no hay código
                code = GenerateNewCode();
                dto.Codigo = code;
                AddNewCodeToCombo(code);
                SetSelectedCode(code);
            }
            else
            {
                dto.Codigo = code;
            }

            var res = _nProductos.CrearProducto(dto);

            MessageBox.Show(res?.Messages != null && res.Messages.Any() ? string.Join(Environment.NewLine, res.Messages) : (res != null && res.Success ? "Operación exitosa" : "Error"));

            if (res != null && res.Success)
            {
                ClearFields();
                PopulateCodeCombo();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_currentProductId.HasValue)
            {
                MessageBox.Show("Primero busque el producto a modificar (por código).");
                return;
            }

            // validar fecha antes de construir DTO
            if (dtpVencimiento != null && dtpVencimiento.ShowCheckBox && dtpVencimiento.Checked)
            {
                if (dtpVencimiento.Value.Date < new DateTime(1900, 1, 1))
                {
                    MessageBox.Show("Fecha de vencimiento inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpVencimiento.Focus();
                    return;
                }
            }

            var dto = new ProductoModificarDTO
            {
                IdProducto = _currentProductId.Value,
                Codigo = GetSelectedCode(),
                Nombre = TXTNombre.Text,
                Marca = TXTMarca.Text,
                Descripcion = TXTDescripcion.Text,
                PrecioCompra = ParseDecimalSafe(TXTPrecioCompra.Text),
                PrecioVenta = ParseDecimalSafe(TXTPrecioVenta.Text),
                StockMinimo = ParseIntSafe(TXTStockMinimo.Text),
                StockIdeal = ParseIntSafe(TXTStockIdeal.Text),
                StockMaximo = ParseIntSafe(TXTStockMaximo.Text),
                IdCategoria = cmbCategoria.SelectedValue is int ? (int)cmbCategoria.SelectedValue : ParseIntSafe(cmbCategoria.SelectedValue?.ToString()),
                Activo = true
            };

            var res = _nProductos.ModificarProducto(dto);

            MessageBox.Show(res?.Messages != null && res.Messages.Any() ? string.Join(Environment.NewLine, res.Messages) : (res != null && res.Success ? "Operación exitosa" : "Error"));

            if (res != null && res.Success)
            {
                ClearFields();
                PopulateCodeCombo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idToDelete = 0;

            if (_currentProductId.HasValue)
            {
                idToDelete = _currentProductId.Value;
            }
            else
            {
                string cod = GetSelectedCode();

                if (string.IsNullOrEmpty(cod))
                {
                    MessageBox.Show("Ingrese o seleccione un código o busque el producto primero.");
                    return;
                }

                var busc = _nProductos.BuscarProducto(cod);
                var found = busc?.Data?.FirstOrDefault();
                if (found == null)
                {
                    MessageBox.Show("Producto no encontrado");
                    return;
                }
                idToDelete = found.IdProducto;
            }

            var res = _nProductos.EliminarProducto(idToDelete);

            MessageBox.Show(res?.Messages != null && res.Messages.Any() ? string.Join(Environment.NewLine, res.Messages) : (res != null && res.Success ? "Operación exitosa" : "Error"));

            if (res != null && res.Success) 
            {
                ClearFields();
                PopulateCodeCombo();
            }
        }

        // Evento cuando el usuario pulsa Enter en el antiguo textbox (compatibilidad)
        private void TXTCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string cod = (sender as TextBox)?.Text.Trim();
            if (string.IsNullOrEmpty(cod)) return;

            var res = _nProductos.BuscarProducto(cod);

            var first = res?.Data?.FirstOrDefault();

            if (first == null)
            {
                MessageBox.Show("Producto no encontrado");
                return;
            }

            FillFields(first);
            if (cmbCodigo != null) cmbCodigo.Enabled = false;
        }

        // Evento para ComboBox de códigos (selección)
        private void cmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = GetSelectedCode();
            if (string.IsNullOrEmpty(cod)) return;

            var res = _nProductos.BuscarProducto(cod);
            var first = res?.Data?.FirstOrDefault();

            if (first == null)
            {
                MessageBox.Show("Producto no encontrado");
                return;
            }

            FillFields(first);
        }

        // Permitir búsqueda cuando el usuario escribe y presiona Enter en el combo (DropDown permite escribir)
        private void cmbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string cod = GetSelectedCode();
            if (string.IsNullOrEmpty(cod)) return;

            var res = _nProductos.BuscarProducto(cod);
            var first = res?.Data?.FirstOrDefault();

            if (first == null)
            {
                MessageBox.Show("Producto no encontrado");
                return;
            }

            FillFields(first);
            if (cmbCodigo != null) cmbCodigo.Enabled = false;
        }

        // ================================================================
        // MÉTODOS AUXILIARES
        // ================================================================
        private ProductoDTO LoadDTO()
        {
            return new ProductoDTO
            {
                Codigo = GetSelectedCode(),
                Nombre = TXTNombre.Text,
                Marca = TXTMarca.Text,
                Descripcion = TXTDescripcion.Text,
                PrecioCompra = ParseDecimalSafe(TXTPrecioCompra.Text),
                PrecioVenta = ParseDecimalSafe(TXTPrecioVenta.Text),
                StockMinimo = ParseIntSafe(TXTStockMinimo.Text),
                StockIdeal = ParseIntSafe(TXTStockIdeal.Text),
                StockMaximo = ParseIntSafe(TXTStockMaximo.Text),
                IdCategoria = cmbCategoria.SelectedValue is int ? (int)cmbCategoria.SelectedValue : ParseIntSafe(cmbCategoria.SelectedValue?.ToString()),
                Activo = true
            };
        }

        private void FillFields(ProductoBuscarDTO p)
        {
            _currentProductId = p.IdProducto;

            SetSelectedCode(p.Codigo);
            TXTNombre.Text = p.Nombre;
            TXTMarca.Text = p.Marca;
            TXTPrecioCompra.Text = p.PrecioCompra.ToString("0.00");
            TXTPrecioVenta.Text = p.PrecioVenta.ToString("0.00");
            TXTStockActual.Text = p.StockActual.ToString();

            try
            {
                if (cmbCategoria.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    // Buscar nombre de columna con tolerancia a mayúsculas/minúsculas
                    string colNombre = dt.Columns.Contains("nombre") ? "nombre" : dt.Columns.Contains("Nombre") ? "Nombre" : null;
                    string colId = dt.Columns.Contains("id_categoria") ? "id_categoria" : dt.Columns.Contains("Id") ? "Id" : dt.Columns.Contains("Id_categoria") ? "Id_categoria" : null;

                    if (colNombre != null && colId != null)
                    {
                        var row = dt.AsEnumerable().FirstOrDefault(r => string.Equals(r.Field<string>(colNombre), p.Categoria, StringComparison.OrdinalIgnoreCase));
                        if (row != null)
                        {
                            cmbCategoria.SelectedValue = row.Field<int>(colId);
                        }
                        else
                        {
                            cmbCategoria.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        // Fallback: intentar seleccionar por texto entre los Items
                        cmbCategoria.SelectedIndex = -1;
                        for (int i = 0; i < cmbCategoria.Items.Count; i++)
                        {
                            if (cmbCategoria.GetItemText(cmbCategoria.Items[i]).Equals(p.Categoria, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbCategoria.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cmbCategoria.SelectedIndex = -1;
                    for (int i = 0; i < cmbCategoria.Items.Count; i++)
                    {
                        if (cmbCategoria.GetItemText(cmbCategoria.Items[i]).Equals(p.Categoria, StringComparison.OrdinalIgnoreCase))
                        {
                            cmbCategoria.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch
            {
                cmbCategoria.SelectedIndex = -1;
            }

            TXTDescripcion.Text = p.Nombre;

            // Si el DTO tuviera fecha de vencimiento, asignarla al DateTimePicker:
            // if (p.FechaVencimiento.HasValue && dtpVencimiento != null) { dtpVencimiento.Value = p.FechaVencimiento.Value; dtpVencimiento.Checked = true; }
        }

        private void PopulateCodeCombo()
        {
            try
            {
                _codeList.Clear();

                var productosRes = _nProductos.ListarProductos();
                if (productosRes != null && productosRes.Success && productosRes.Data != null)
                {
                    _codeList = productosRes.Data
                        .Where(p => !string.IsNullOrEmpty(p.Codigo))
                        .Select(p => p.Codigo)
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList();
                }

                // Usar Items y AutoCompleteCustomSource para evitar problemas con DataSource binding
                if (cmbCodigo != null)
                {
                    cmbCodigo.Items.Clear();
                    cmbCodigo.Items.AddRange(_codeList.ToArray());
                    cmbCodigo.Text = "";
                    // configurar AutoComplete
                    var acs = new AutoCompleteStringCollection();
                    acs.AddRange(_codeList.ToArray());
                    cmbCodigo.AutoCompleteCustomSource = acs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("PopulateCodeCombo: " + ex.Message);
                if (cmbCodigo != null) cmbCodigo.Items.Clear();
            }
        }

        private void AddNewCodeToCombo(string code)
        {
            if (string.IsNullOrEmpty(code)) return;
            if (_codeList == null) _codeList = new List<string>();
            if (!_codeList.Contains(code))
            {
                _codeList.Insert(0, code);
                if (cmbCodigo != null)
                {
                    cmbCodigo.Items.Insert(0, code);
                    var acs = new AutoCompleteStringCollection();
                    acs.AddRange(_codeList.ToArray());
                    cmbCodigo.AutoCompleteCustomSource = acs;
                }
            }
        }

        private string GetSelectedCode()
        {
            if (cmbCodigo != null)
                return cmbCodigo.Text?.Trim() ?? "";
            if (TXTCod != null)
                return TXTCod.Text?.Trim() ?? "";
            return "";
        }

        private void SetSelectedCode(string code)
        {
            if (cmbCodigo == null) return;
            if (string.IsNullOrEmpty(code))
            {
                cmbCodigo.SelectedIndex = -1;
                cmbCodigo.Text = "";
                return;
            }

            // Si existe en la lista, seleccionarlo; si no, añadirlo y seleccionarlo.
            if (_codeList == null) _codeList = new List<string>();
            if (!_codeList.Contains(code))
            {
                _codeList.Insert(0, code);
                if (cmbCodigo != null)
                {
                    cmbCodigo.Items.Insert(0, code);
                }
            }

            if (cmbCodigo.Items.Contains(code))
            {
                cmbCodigo.SelectedItem = code;
                cmbCodigo.Text = code;
            }
            else
            {
                cmbCodigo.Text = code;
            }
        }

        private string GenerateNewCode()
        {
            try
            {
                // Obtener códigos actuales para calcular siguiente sufijo numérico
                var productosRes = _nProductos.ListarProductos();
                var codes = new List<string>();
                if (productosRes != null && productosRes.Success && productosRes.Data != null)
                {
                    codes = productosRes.Data.Where(p => !string.IsNullOrEmpty(p.Codigo)).Select(p => p.Codigo).ToList();
                }

                int maxNumber = 0;
                int maxDigits = 4; // formato por defecto
                foreach (var c in codes)
                {
                    // extraer sufijo numérico
                    var m = Regex.Match(c ?? "", @"(\d+)$");
                    if (m.Success)
                    {
                        if (int.TryParse(m.Value, out int val))
                        {
                            maxNumber = Math.Max(maxNumber, val);
                            maxDigits = Math.Max(maxDigits, m.Value.Length);
                        }
                    }
                }

                int next = maxNumber + 1;
                // prefijo por defecto "P"
                string newCode = "P" + next.ToString("D" + maxDigits);
                return newCode;
            }
            catch
            {
                // fallback simple
                return "P0001";
            }
        }

        private void LoadCategories()
        {
            try
            {
                // Usar Od_Categorias para obtener las categorías desde la tabla Categorias
                var odCat = new Od_Categorias();
                DataTable dt = odCat.ListarCategorias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Asegurar nombres de columnas correctos (tolerancia a mayúsculas/minúsculas)
                    string colNombre = dt.Columns.Contains("nombre") ? "nombre" : dt.Columns.Contains("Nombre") ? "Nombre" : null;
                    string colId = dt.Columns.Contains("id_categoria") ? "id_categoria" : dt.Columns.Contains("Id") ? "Id" : dt.Columns.Contains("Id_categoria") ? "Id_categoria" : null;

                    if (colNombre != null && colId != null)
                    {
                        // Mantener la tabla tal cual para DataSource (evita reconstrucción).
                        cmbCategoria.DataSource = dt;
                        cmbCategoria.DisplayMember = colNombre;
                        cmbCategoria.ValueMember = colId;
                        cmbCategoria.SelectedIndex = -1;
                    }
                    else
                    {
                        // Fallback: mapear a lista simple de nombres si columnas inesperadas
                        var list = dt.AsEnumerable()
                                     .Select(r => r.ItemArray.Select(c => c?.ToString()).FirstOrDefault(s => !string.IsNullOrEmpty(s)))
                                     .Where(s => !string.IsNullOrEmpty(s))
                                     .Distinct()
                                     .Select(n => new { Nombre = n })
                                     .ToList();
                        cmbCategoria.DataSource = list;
                        cmbCategoria.DisplayMember = "Nombre";
                        cmbCategoria.ValueMember = "Nombre";
                        cmbCategoria.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbCategoria.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoadCategories: " + ex.Message);
                cmbCategoria.DataSource = null;
            }
        }

        private void ClearFields()
        {
            _currentProductId = null;

            foreach (Control c in this.Controls)
            {
                if (c is TextBox) c.Text = "";
                if (c is ComboBox combo)
                {
                    combo.SelectedIndex = -1;
                }
            }

            if (cmbCodigo != null)
            {
                cmbCodigo.Enabled = true;
                cmbCodigo.Text = "";
            }

            if (dtpVencimiento != null)
            {
                dtpVencimiento.Checked = false; // dejar sin fecha por defecto
            }
        }

        private int ParseIntSafe(string s)
        {
            int.TryParse(s, out int val);
            return val;
        }

        private decimal ParseDecimalSafe(string s)
        {
            decimal.TryParse(s, out decimal val);
            return val;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            ClearFields();
            // permitir escribir/seleccionar código vacío para nuevo producto
            if (cmbCodigo != null)
            {
                cmbCodigo.Enabled = true;
                cmbCodigo.Text = "";
            }
            _currentProductId = null;
        }
    }
}
