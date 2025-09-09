using Logica;
using Sesion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmResponderRespuesta : Form
    {
        private List<PreguntaVista> preguntas;
        private int indiceActual = 0;
        private Dictionary<int, string> respuestasUsuario = new Dictionary<int, string>();
        private L_ResponderRespuestas logica = new L_ResponderRespuestas();
        private MostrarToolTip mostrarTT = new MostrarToolTip();

        public frmResponderRespuesta()
        {
            InitializeComponent();
        }

        private void frmResponderRespuesta_Load(object sender, EventArgs e)
        {
            string usuario = SesionUsuario.Usuario;
            preguntas = logica.ObtenerRespuestasDelUsuario(usuario);

            if (preguntas == null || preguntas.Count == 0)
            {
                MessageBox.Show("No se encontraron respuestas registradas para este usuario.");
                this.Close();
                return;
            }

            MostrarPreguntaActual();
        }

        private void MostrarPreguntaActual()
        {
            if (indiceActual < preguntas.Count)
            {
                lblPreguntaLista.Text = preguntas[indiceActual].Pregunta;
                txtRespuesta.Clear();
                txtRespuesta.Focus();
            }
            else
            {
                ValidarRespuestas();
            }
        }

        private void ValidarRespuestas()
        {
            string mensaje;
            bool valido = logica.ValidarRespuestas(SesionUsuario.Usuario, respuestasUsuario, out mensaje);

            if (valido)
            {
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmCambiarContra cambiarContrasenaForm = new frmCambiarContra();
                DialogResult res = cambiarContrasenaForm.ShowDialog();

                if (res == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                respuestasUsuario.Clear();
                indiceActual = 0;
                MostrarPreguntaActual();
            }
        }

        private void btnResponderPregunta_Click(object sender, EventArgs e)
        {
            string respuestaUsuario = txtRespuesta.Text.Trim();

            if (string.IsNullOrEmpty(respuestaUsuario))
            {
                mostrarTT.MostrarTooltip(txtRespuesta, "Debe ingresar una respuesta.");
                txtRespuesta.Focus();
                return;
            }

            int idPregunta = preguntas[indiceActual].Id;
            respuestasUsuario[idPregunta] = respuestaUsuario;

            indiceActual++;
            MostrarPreguntaActual();
        }
    }
}
