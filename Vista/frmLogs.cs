using Logica;
using Sesion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmLogs : Form
    {
        private readonly L_Logs logica = new L_Logs();

        public frmLogs()
        {
            InitializeComponent();
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            CargarLogs();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarLogs()
        {
            List<Log> listaLogs = logica.ListarLogs();

            if (listaLogs != null && listaLogs.Count > 0)
            {
                dgvLogs.DataSource = null;
                dgvLogs.DataSource = listaLogs;

                dgvLogs.Columns["Usuario"].HeaderText = "Usuario";
                dgvLogs.Columns["Accion"].HeaderText = "Acción";
                dgvLogs.Columns["Fecha"].HeaderText = "Fecha";
            }
            else
            {
                MessageBox.Show("No se encontraron logs.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
