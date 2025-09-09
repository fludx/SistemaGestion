using System;
using System.Windows.Forms;
using Sesion;
using Logica;

namespace Vista
{
    public partial class frmUsuarioNombre : Form
    {
        private L_BuscarUsuario logicaBuscar = new L_BuscarUsuario();
        private MostrarToolTip mostrarTT = new MostrarToolTip();

        public frmUsuarioNombre()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                mostrarTT.MostrarTooltip(txtNombreUsuario, "Debe ingresar un nombre de usuario.");
                txtNombreUsuario.Focus();
                return;
            }

            try
            {
                SesionUsuario.Usuario = nombreUsuario;

                int? idUsuario = logicaBuscar.ObtenerIdPorUsuario(nombreUsuario);

                if (!idUsuario.HasValue)
                {
                    mostrarTT.MostrarTooltip(txtNombreUsuario, "Usuario no encontrado.");
                    txtNombreUsuario.Focus();
                    return;
                }

                SesionUsuario.IdUsuario = idUsuario.Value;

                frmResponderRespuesta formRespuestas = new frmResponderRespuesta();
                this.Hide();

                DialogResult res = formRespuestas.ShowDialog();

                if (res == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
