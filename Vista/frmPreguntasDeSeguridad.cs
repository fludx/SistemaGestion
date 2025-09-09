using Logica;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmPreguntasDeSeguridad : Form
    {
        private ToolTip tt = new ToolTip();

        public frmPreguntasDeSeguridad()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearPregunta_Click(object sender, EventArgs e)
        {
            string pregunta = txtPregunta.Text.Trim();

            if (string.IsNullOrWhiteSpace(pregunta))
            {
                tt.Show("Por favor, ingrese una pregunta válida.", txtPregunta, 3000);
                return;
            }

            L_Pregunta logica = new L_Pregunta();
            string mensaje;

            bool resultado = logica.CrearPregunta(pregunta, out mensaje);

            if (resultado)
            {
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPregunta.Clear();
                txtPregunta.Focus();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmPreguntasDeSeguridad_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
