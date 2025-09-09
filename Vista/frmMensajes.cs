using Logica;
using MensajeriaApp.Logica;
using System;
using System.Data;
using System.Windows.Forms;
using Sesion;

namespace Vista
{
    public partial class frmMensajes : Form
    {
        private L_ListarUsuarios logicaUsuarios = new L_ListarUsuarios();
        private L_Mensajes logicaMensajes = new L_Mensajes();
        private MostrarToolTip mostrarTT = new MostrarToolTip();

        public frmMensajes()
        {
            InitializeComponent();
        }

        private void CargarUsuarios()
        {
            try
            {
                DataTable dtUsuarios = logicaUsuarios.ListarUsuarios();
                DataView vista = dtUsuarios.DefaultView;
                vista.RowFilter = $"Id_Usuario <> {SesionUsuario.IdUsuario}";

                listPersonas.DisplayMember = "Usuario";
                listPersonas.ValueMember = "Id_Usuario";
                listPersonas.DataSource = vista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void listPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPersonas.SelectedValue != null && int.TryParse(listPersonas.SelectedValue.ToString(), out int receptorId))
            {
                CargarMensajes(receptorId);
            }
        }

        private void CargarMensajes(int receptorId)
        {
            try
            {
                DataTable mensajes = logicaMensajes.ObtenerConversacion(SesionUsuario.IdUsuario, receptorId);
                listMensajes.Items.Clear();

                foreach (DataRow row in mensajes.Rows)
                {
                    string fecha = Convert.ToDateTime(row["Fecha"]).ToString("g");
                    string contenido = row["Contenido"].ToString();
                    string emisor = (Convert.ToInt32(row["EmisorId"]) == SesionUsuario.IdUsuario) ? "Yo" : "Ellos";
                    string texto = $"{fecha} - {emisor}: {contenido}";
                    listMensajes.Items.Add(texto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mensajes: " + ex.Message);
            }
        }

        private void frmMensajes_Load_1(object sender, EventArgs e)
        {
            if (SesionUsuario.IdUsuario > 0)
                CargarUsuarios();
            else
                MessageBox.Show("No se ha iniciado sesión correctamente.");
        }

        private void btnEnviar_Click_2(object sender, EventArgs e)
        {
            if (listPersonas.SelectedValue == null || !int.TryParse(listPersonas.SelectedValue.ToString(), out int receptorId))
            {
                mostrarTT.MostrarTooltip(listPersonas, "Seleccione un usuario para enviar el mensaje.");
                return;
            }

            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrEmpty(mensaje))
            {
                mostrarTT.MostrarTooltip(txtMensaje, "El mensaje no puede estar vacío.");
                return;
            }

            try
            {
                logicaMensajes.Enviar(SesionUsuario.IdUsuario, receptorId, mensaje);
                MessageBox.Show("Mensaje enviado correctamente.");
                txtMensaje.Clear();
                CargarMensajes(receptorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar mensaje: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
