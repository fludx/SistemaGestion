using Logica;
using Sesion;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmRegistrarUsuarios : Form
    {
        private MostrarToolTip mostrarTT = new MostrarToolTip();

        public frmRegistrarUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarUsuarios_Load(object sender, EventArgs e)
        {
            L_Lista logica = new L_Lista();
            var personas = logica.ObtenerPersonasParaCombo();
            var roles = logica.ObtenerRolesParaCombo();

            cbPersona.DataSource = personas;
            cbRolUsuario.DataSource = roles;
            cbPersona.DisplayMember = "Value";
            cbPersona.ValueMember = "Key";
            cbRolUsuario.DisplayMember = "Value";
            cbRolUsuario.ValueMember = "Key";
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                mostrarTT.MostrarTooltip(txtUsuario, "El nombre de usuario no puede estar vacío.");
                txtUsuario.Focus();
                return;
            }

            if (cbPersona.SelectedIndex == -1)
            {
                mostrarTT.MostrarTooltip(cbPersona, "Debe seleccionar una persona.");
                cbPersona.Focus();
                return;
            }

            if (cbRolUsuario.SelectedIndex == -1)
            {
                mostrarTT.MostrarTooltip(cbRolUsuario, "Debe seleccionar un rol.");
                cbRolUsuario.Focus();
                return;
            }

            L_Lista lcorreo = new L_Lista();
            int id_persona = (int)cbPersona.SelectedValue;
            string usuario = txtUsuario.Text.Trim();
            int id_rol = (int)cbRolUsuario.SelectedValue;

            string correo = lcorreo.ObtenerCorreoPorId(id_persona);
            string contrasena = GeneradorContraseña.Generar(6);
            string contra_enctriptada = HashconUsu.Hashconusu(usuario, contrasena);

            L_RegistrarUsuario logica = new L_RegistrarUsuario();
            bool registrado = logica.RegistrarUsuario(id_persona, usuario, id_rol, contra_enctriptada);

            if (registrado)
            {
                Sesion.ArmarMail.DireccionCorreo = correo;
                Sesion.ArmarMail.Asunto = "Credenciales de acceso - Sistema de Gestión";
                Sesion.ArmarMail.ContrasenaSistema = contrasena;

                Sesion.ArmarMail.Preparar();

                Logica.L_Logs logicaLogs = new Logica.L_Logs();
                logicaLogs.InsertarLog(SesionUsuario.Usuario, $"Registro del usuario {usuario} exitosamente");

                MessageBox.Show("Usuario creado y correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario. Revisá la consola para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
