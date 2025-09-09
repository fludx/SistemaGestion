using Logica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Logica.L_ResponderPreguntas;
using Sesion;

namespace Vista
{
    public partial class frmResponderPreguntas : Form
    {
        private List<PreguntaVista> _preguntas;
        private int _indiceActual = 0;
        private bool _todasRespondidas = false;
        private MostrarToolTip mostrarTT = new MostrarToolTip();

        public frmResponderPreguntas()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) =>
            {
                if (!_todasRespondidas && this.DialogResult != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            };
        }

        private void frmResponderPreguntas_Load(object sender, EventArgs e)
        {
            var logica = new L_ListarPreguntas();
            _preguntas = logica.ListarPreguntas();

            if (_preguntas.Count == 0)
            {
                MessageBox.Show("No hay preguntas disponibles.");
                this.Close();
                return;
            }

            MostrarPreguntaActual();
        }

        private void btnResponderPregunta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                mostrarTT.MostrarTooltip(txtRespuesta, "La respuesta no puede estar vacía.");
                txtRespuesta.Focus();
                return;
            }

            var logica = new L_ResponderPregunta();
            string mensaje;

            bool resultado = logica.ResponderPregunta(
                SesionUsuario.IdUsuario,
                _preguntas[_indiceActual].Id,
                txtRespuesta.Text,
                out mensaje
            );

            if (!resultado)
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _indiceActual++;

            if (_indiceActual >= _preguntas.Count)
            {
                _todasRespondidas = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MostrarPreguntaActual();
                txtRespuesta.Clear();
            }
        }

        private void MostrarPreguntaActual()
        {
            lblPreguntaLista.Text = _preguntas[_indiceActual].Pregunta;
            lblProgreso.Text = $"{_indiceActual + 1} de {_preguntas.Count}";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Estás seguro de salir sin completar las preguntas?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
