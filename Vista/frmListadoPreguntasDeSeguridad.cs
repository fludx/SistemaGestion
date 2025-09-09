using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmListadoPreguntasDeSeguridad : Form
    {
        public frmListadoPreguntasDeSeguridad()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListadoPreguntasDeSeguridad_Load(object sender, EventArgs e)
        {
            CargarPreguntas();
        }

        private void CargarPreguntas()
        {
            L_ListarPreguntas logica = new L_ListarPreguntas();
            List<PreguntaVista> preguntas = logica.ListarPreguntas();

            if (preguntas != null && preguntas.Count > 0)
            {
                dgvPreguntas.DataSource = null;
                dgvPreguntas.DataSource = preguntas;

                dgvPreguntas.Columns["Pregunta"].HeaderText = "Pregunta";

                if (dgvPreguntas.Columns.Contains("ID"))
                    dgvPreguntas.Columns["ID"].Visible = false;

                if (dgvPreguntas.Columns.Contains("Respuesta"))
                    dgvPreguntas.Columns["Respuesta"].Visible = false;

                if (dgvPreguntas.Columns.Contains("Id_Usuario"))
                    dgvPreguntas.Columns["Id_Usuario"].Visible = false;

                if (dgvPreguntas.Columns.Contains("RespuestaCorrecta"))
                    dgvPreguntas.Columns["RespuestaCorrecta"].Visible = false;
            }
            else
            {
                MessageBox.Show("No se pudieron cargar las preguntas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aca pone para que se pueda eliminar y modificar alexis o aguas

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
