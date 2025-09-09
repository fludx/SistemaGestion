using Logica;
using Sesion;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmEditarUsuario : Form
    {
        public int IdUsuario { get; set; }

        private UsuarioVista usuarioOriginal;

        public frmEditarUsuario()
        {
            InitializeComponent();
            button2.Click += button2_Click;
        }

        private void frmEditarUsuario_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label4.Text = IdUsuario.ToString();

            label1.Text = "NOMBRE DE USUARIO";
            label2.Text = "FECHA BLOQUEO";
            label3.Text = "CAMBIOS DE CONTRASEÑA";
            label6.Text = "ROL DE USUARIO";
            button1.Text = "BLOQUEAR";
            button2.Text = "GUARDAR";

            textBox2.Enabled = false;
            textBox3.Enabled = false;

            L_Lista logicaRoles = new L_Lista();
            var roles = logicaRoles.ObtenerRolesParaCombo();

            comboBox1.DataSource = roles;
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            L_ModificarUsuario logica = new L_ModificarUsuario();
            usuarioOriginal = logica.ObtenerUsuario(IdUsuario, out string mensaje);

            if (usuarioOriginal != null)
            {
                CargarDatosEnFormulario(usuarioOriginal);
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnFormulario(UsuarioVista usuario)
        {
            textBox1.Text = usuario.Usuario;
            textBox2.Text = usuario.Fecha_Bloqueo?.ToString("dd/MM/yyyy") ?? "";
            textBox3.Text = usuario.CambioContra.ToString();
            comboBox1.SelectedValue = usuario.Id_Rol;

            label4.Text = usuario.Id_Usuario.ToString();
            label4.Visible = false;

            button1.Text = usuario.Bloqueado ? "Desbloquear" : "BLOQUEAR";
        }

        private UsuarioVista ObtenerUsuarioDesdeFormulario()
        {
            return new UsuarioVista
            {
                Id_Usuario = usuarioOriginal.Id_Usuario,
                Id_Persona = usuarioOriginal.Id_Persona,
                Usuario = textBox1.Text.Trim(),
                Fecha_Bloqueo = string.IsNullOrEmpty(textBox2.Text) ? (DateTime?)null :
                                DateTime.ParseExact(textBox2.Text, "dd/MM/yyyy", null),
                CambioContra = int.TryParse(textBox3.Text, out int cambio) ? cambio : 0,
                Id_Rol = (int)comboBox1.SelectedValue,
                Bloqueado = usuarioOriginal.Bloqueado,
                FechaCambioContra = usuarioOriginal.FechaCambioContra
            };
        }

        private bool HayCambios(UsuarioVista original, UsuarioVista actual)
        {
            if (original.Usuario != actual.Usuario) return true;
            if (original.Fecha_Bloqueo != actual.Fecha_Bloqueo) return true;
            if (original.CambioContra != actual.CambioContra) return true;
            if (original.Id_Rol != actual.Id_Rol) return true;
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(textBox2.Text) &&
                !DateTime.TryParseExact(textBox2.Text, "dd/MM/yyyy", null,
                                        System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("La fecha de bloqueo debe tener el formato dd/MM/yyyy.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(textBox3.Text) && !int.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("El campo 'Cambios de contraseña' debe ser un número válido.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            var usuarioActual = ObtenerUsuarioDesdeFormulario();

            if (!HayCambios(usuarioOriginal, usuarioActual))
            {
                MessageBox.Show("No hay cambios para guardar.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            L_ModificarUsuario logica = new L_ModificarUsuario();
            bool exito = logica.ActualizarUsuario(usuarioActual, out string mensaje);

            if (exito)
            {
                Logica.L_Logs logicaLogs = new Logica.L_Logs();
                logicaLogs.InsertarLog(SesionUsuario.Usuario, $"Modificación exitosa del usuario: {usuarioActual.Usuario}");

                MessageBox.Show("Usuario actualizado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuarioOriginal = usuarioActual;
            }
            else
            {
                MessageBox.Show("Error al actualizar usuario: " + mensaje, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string accionConfirmar = usuarioOriginal.Bloqueado ? "desbloquear" : "bloquear";
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea {accionConfirmar} este usuario?",
                "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No) return;

            var logica = new L_ModificarUsuario();

            bool nuevoEstado = !usuarioOriginal.Bloqueado;
            DateTime? nuevaFechaBloqueo = nuevoEstado ? (DateTime?)DateTime.Now : (DateTime?)null;

            bool exito = logica.BloquearUsuario(IdUsuario, nuevoEstado, nuevaFechaBloqueo, out string mensaje);

            if (exito)
            {
                usuarioOriginal.Bloqueado = nuevoEstado;
                usuarioOriginal.Fecha_Bloqueo = nuevaFechaBloqueo;

                CargarDatosEnFormulario(usuarioOriginal);

                string accion = nuevoEstado ? "bloqueado" : "desbloqueado";
                MessageBox.Show($"Usuario {accion} correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar estado del usuario: " + mensaje, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
