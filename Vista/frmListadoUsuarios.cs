using Logica;
using Sesion;
using System;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmListadoUsuarios : Form
    {
        public frmListadoUsuarios()
        {
            InitializeComponent();
            this.Load += frmListadoUsuarios_Load;
        }

        private void frmListadoUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.EditMode = DataGridViewEditMode.EditProgrammatically;

            label2.Visible = false;
            btnEliminar.Enabled = false; 
            btnModificar.Text = "EDITAR USUARIO";
            btnEliminar.Text = "ELIMINAR USUARIO";
            btnModificar.Enabled = false;
            btnModificar.BackColor = System.Drawing.Color.LightGray;
            btnEliminar.BackColor = System.Drawing.Color.LightGray;
        }

        private void CargarUsuarios()
        {
            L_ListarUsuarios logica = new L_ListarUsuarios();
            DataTable usuarios = logica.ListarUsuarios();

            if (usuarios != null)
            {
                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.AutoResizeColumns();

                dgvUsuarios.Columns[0].Visible = false; 
                dgvUsuarios.Columns[1].Visible = false; 
                dgvUsuarios.Columns[3].Visible = false;
                dgvUsuarios.Columns[8].Visible = false;
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvUsuarios.Rows[e.RowIndex];

                int idUsuario = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                string usuario = filaSeleccionada.Cells[2].Value.ToString();

        

                label2.Text = idUsuario.ToString();

                btnModificar.Enabled = true;
                btnModificar.Text = $"EDITAR USUARIO";
                btnModificar.ForeColor = System.Drawing.Color.White;
                btnModificar.BackColor = System.Drawing.Color.RoyalBlue;
                btnEliminar.BackColor = System.Drawing.Color.Red;
                btnEliminar.ForeColor = System.Drawing.Color.White;
                btnEliminar.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(label2.Text);
            frmEditarUsuario frmEditar = new frmEditarUsuario();
            frmEditar.IdUsuario = id;

            var resultado = frmEditar.ShowDialog();


            CargarUsuarios();

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnModificar.BackColor = System.Drawing.Color.LightGray;
            btnEliminar.BackColor = System.Drawing.Color.LightGray;
        }

        private void txtPregunta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(label2.Text);
            frmEditarUsuario frmEditar = new frmEditarUsuario();
            frmEditar.IdUsuario = id;

            var resultado = frmEditar.ShowDialog();

            CargarUsuarios();

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string nombreUsuario = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                CargarUsuarios();
                return;
            }

            try
            {
                L_BuscarUsuario logicaBuscar = new L_BuscarUsuario();
                int? idUsuario = logicaBuscar.ObtenerIdPorUsuario(nombreUsuario);

                if (idUsuario.HasValue)
                {
                    L_ListarUsuarios logicaListar = new L_ListarUsuarios();
                    DataTable dt = logicaListar.ListarUsuarios(); 
                    DataView dv = new DataView(dt);

                    dv.RowFilter = $"Id_Usuario = {idUsuario.Value}";

                    dgvUsuarios.DataSource = dv;
                }
                else
                {
                    dgvUsuarios.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
