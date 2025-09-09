using Logica;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmCambiarContra : Form
    {
        private MostrarToolTip mostrarTT = new MostrarToolTip();
        private L_Restriccion restriccion = new L_Restriccion();
        private EstadoRestricciones estadoRestricciones;

        public frmCambiarContra()
        {
            InitializeComponent();

            btnCambiarContra.Enabled = false;
            txtContra.TextChanged += txtContra_TextChanged;

            chkMinCaracteres.AutoCheck = false;
            chkNumeros.AutoCheck = false;
            chkMayuscula.AutoCheck = false;
            chkEspeciales.AutoCheck = false;
            chkHistorial.AutoCheck = false;
            chkDatosPersonales.AutoCheck = false;

            estadoRestricciones = restriccion.ConseguirRestricciones();
            ConfigurarVisibilidadRestricciones();
            ValidarRestricciones();
        }

        private void frmCrearRespuesta_Load(object sender, EventArgs e)
        {
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {
            ValidarRestricciones();
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            string contra = txtContra.Text;
            string confContra = txtConfContra.Text;

            if (contra != confContra)
            {
                mostrarTT.MostrarTooltip(txtConfContra, "Las contraseñas no son iguales.");
                return;
            }

            L_CambioObligatorio cambio = new L_CambioObligatorio();
            cambio.CambiaContra(SesionUsuario.IdUsuario, SesionUsuario.Usuario, contra, confContra);

            MessageBox.Show(
                "Contraseña cambiada exitosamente",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnMostrarContra_Click(object sender, EventArgs e)
        {
            txtContra.UseSystemPasswordChar = !txtContra.UseSystemPasswordChar;
            btnMostrarContra.Image = txtContra.UseSystemPasswordChar
                ? Properties.Resources.nomoscon
                : Properties.Resources.moscon;
        }

        private void btnMostrarContraC_Click(object sender, EventArgs e)
        {
            txtConfContra.UseSystemPasswordChar = !txtConfContra.UseSystemPasswordChar;
            btnMostrarContraC.Image = txtConfContra.UseSystemPasswordChar
                ? Properties.Resources.nomoscon
                : Properties.Resources.moscon;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarVisibilidadRestricciones()
        {
            chkMinCaracteres.Visible = estadoRestricciones.CaracteresUtilizados > 0;
            chkMinCaracteres.TabStop = false;

            chkNumeros.Visible = estadoRestricciones.NumeroLetras == 1;
            chkNumeros.TabStop = false;

            chkMayuscula.Visible = estadoRestricciones.MayusMinus == 1;
            chkMayuscula.TabStop = false;

            chkEspeciales.Visible = estadoRestricciones.CaracterEsp == 1;
            chkEspeciales.TabStop = false;

            chkHistorial.Visible = estadoRestricciones.ContrasenaAnterior == 1;
            chkHistorial.TabStop = false;

            chkDatosPersonales.Visible = estadoRestricciones.DatosPersonales == 1;
            chkDatosPersonales.TabStop = false;
        }

        private void ValidarRestricciones()
        {
            string contra = txtContra.Text;

            bool usarMin = estadoRestricciones.CaracteresUtilizados > 0;
            bool usarNum = estadoRestricciones.NumeroLetras == 1;
            bool usarMay = estadoRestricciones.MayusMinus == 1;
            bool usarEsp = estadoRestricciones.CaracterEsp == 1;
            bool usarHist = estadoRestricciones.ContrasenaAnterior == 1;
            bool usarDatos = estadoRestricciones.DatosPersonales == 1;

            if (usarMin)
            {
                chkMinCaracteres.Checked = restriccion.ObtenerMinimoCaracteres(contra);
                chkMinCaracteres.Text = $"Debe tener al menos \n{estadoRestricciones.CaracteresUtilizados} caracteres";
            }
            else
            {
                chkMinCaracteres.Checked = true;
            }

            chkNumeros.Checked = usarNum ? restriccion.ObtenerNumeros(contra) : true;
            chkMayuscula.Checked = usarMay ? restriccion.ObtenerMayusculas(contra) : true;
            chkEspeciales.Checked = usarEsp ? restriccion.ObtenerCaracteresEspeciales(contra) : true;

            if (usarHist)
            {
                L_HistorialContras l = new L_HistorialContras();
                var historial = l.HistorialDeContrasenas(SesionUsuario.Usuario);
                
                string contraEncriptada = HashconUsu.Hashconusu(SesionUsuario.Usuario, contra);

                bool contraValida = true;

                if (historial != null && historial.Count > 0 && !string.IsNullOrEmpty(contra))
                {
                    contraValida = !historial.Any(c =>
                        !string.IsNullOrEmpty(c.Value) &&
                        c.Value.Equals(contraEncriptada, StringComparison.Ordinal));
                }

                chkHistorial.Checked = contraValida;
            }
            else
            {
                chkHistorial.Checked = true;
            }

            if (usarDatos)
            {
                string resultadoVerificacion = restriccion.VerificarContraContraDatosPersonales(SesionUsuario.IdUsuario, contra);
                chkDatosPersonales.Checked = (resultadoVerificacion == "OK");
            }
            else
            {
                chkDatosPersonales.Checked = true;
            }

            btnCambiarContra.Enabled =
                chkMinCaracteres.Checked &&
                chkNumeros.Checked &&
                chkMayuscula.Checked &&
                chkEspeciales.Checked &&
                chkHistorial.Checked &&
                chkDatosPersonales.Checked;
        }
    }
}
