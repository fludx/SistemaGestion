using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Configuration;

namespace TuProyecto
{
    public partial class FrmCategorias : Form
    {
        private Label lblIdCategoria;
        private Label lblNombreCategoria;
        private TextBox txtIdCategoria;
        private TextBox txtNombreCategoria;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvCategorias;

        private readonly string connectionString;

        public FrmCategorias()
        {
            // Inicializar los controles del formulario
            InitializeComponent();

            // Leer cadena de conexión desde app.config (nombre: "MiConexion")
            connectionString = ConfigurationManager.ConnectionStrings["MiConexion"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show(
                    "Cadena de conexión 'MiConexion' no encontrada en app.config.\n" +
                    "Añade en el proyecto de inicio una entrada <connectionStrings> con el nombre 'MiConexion'.",
                    "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Load += FrmCategorias_Load;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                EstadoInicial();
                return;
            }

            CargarCategorias();
            EstadoInicial();
        }

        private void InitializeComponent()
        {
            this.lblIdCategoria = new System.Windows.Forms.Label();
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.txtIdCategoria = new System.Windows.Forms.TextBox();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();

            // lblIdCategoria
            this.lblIdCategoria.AutoSize = true;
            this.lblIdCategoria.Location = new System.Drawing.Point(17, 3);
            this.lblIdCategoria.Name = "lblIdCategoria";
            this.lblIdCategoria.Size = new System.Drawing.Size(21, 15);
            this.lblIdCategoria.TabIndex = 0;
            this.lblIdCategoria.Text = "ID:";

            // txtIdCategoria
            this.txtIdCategoria.Location = new System.Drawing.Point(20, 20);
            this.txtIdCategoria.Name = "txtIdCategoria";
            this.txtIdCategoria.Size = new System.Drawing.Size(80, 23);
            this.txtIdCategoria.TabIndex = 1;
            this.txtIdCategoria.ReadOnly = true;

            // lblNombreCategoria
            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Location = new System.Drawing.Point(120, 3);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Size = new System.Drawing.Size(54, 15);
            this.lblNombreCategoria.TabIndex = 2;
            this.lblNombreCategoria.Text = "Nombre:";

            // txtNombreCategoria
            this.txtNombreCategoria.Location = new System.Drawing.Point(120, 20);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(250, 23);
            this.txtNombreCategoria.TabIndex = 3;

            // btnNuevo
            this.btnNuevo.Location = new System.Drawing.Point(20, 60);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 25);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(105, 60);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnModificar
            this.btnModificar.Location = new System.Drawing.Point(190, 60);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(275, 60);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(360, 60);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // dgvCategorias
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(20, 100);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowTemplate.Height = 25;
            this.dgvCategorias.Size = new System.Drawing.Size(415, 220);
            this.dgvCategorias.TabIndex = 9;
            this.dgvCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellClick);

            // FrmCategorias
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 340);
            this.Controls.Add(this.lblIdCategoria);
            this.Controls.Add(this.txtIdCategoria);
            this.Controls.Add(this.lblNombreCategoria);
            this.Controls.Add(this.txtNombreCategoria);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvCategorias);
            this.Name = "FrmCategorias";
            this.Text = "Gestión de Categorías";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void EstadoInicial()
        {
            txtIdCategoria.Clear();
            txtNombreCategoria.Clear();
            txtNombreCategoria.Enabled = false;

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;

            if (dgvCategorias.DataSource != null && dgvCategorias.Rows.Count > 0)
            {
                dgvCategorias.ClearSelection();
            }
        }

        private void EstadoEdicion()
        {
            txtNombreCategoria.Enabled = true;

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void CargarCategorias()
        {
            string query = "SELECT id_categoria, nombre FROM Categorias ORDER BY nombre";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCategorias.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EstadoEdicion();
            txtIdCategoria.Clear();
            txtNombreCategoria.Clear();
            txtNombreCategoria.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return;
            }

            string query;

            if (txtIdCategoria.Text == "")
            {
                query = "INSERT INTO Categorias (nombre) VALUES (@nombre)";
            }
            else
            {
                query = "UPDATE Categorias SET nombre=@nombre WHERE id_categoria=@id";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", txtNombreCategoria.Text.Trim());

                if (txtIdCategoria.Text != "")
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdCategoria.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Datos guardados correctamente.");
            CargarCategorias();
            EstadoInicial();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtIdCategoria.Text = dgvCategorias.Rows[e.RowIndex].Cells["id_categoria"].Value.ToString();
            txtNombreCategoria.Text = dgvCategorias.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

            txtNombreCategoria.Enabled = true;

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtIdCategoria.Text == "")
            {
                MessageBox.Show("Debe seleccionar una categoría.");
                return;
            }

            EstadoEdicion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdCategoria.Text == "")
            {
                MessageBox.Show("Debe seleccionar una categoría.");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar esta categoría?",
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string query = "DELETE FROM Categorias WHERE id_categoria=@id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", int.Parse(txtIdCategoria.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Categoría eliminada.");

            CargarCategorias();
            EstadoInicial();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private void SetCueBanner(TextBox textBox, string cue)
        {
            const int EM_SETCUEBANNER = 0x1501;
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, cue);
        }
    }
}
