using Logica;
using Sesion;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class frm2FA : Form
    {
        public int Id_Usuario { get; set; }
        private MostrarToolTip mostrarTT = new MostrarToolTip();

        public frm2FA()
        {
            InitializeComponent();
        }

        private void frm2FA_Load(object sender, EventArgs e)
        {
            label1.Text = "Ingrese el código de verificación enviado a su correo electrónico.";
            button1.Text = "Verificar";
            label2.Text = Id_Usuario.ToString();

            string codigo = GeneradorContraseña.Generar(6);

            L_BuscarUsuario logicaBuscar = new L_BuscarUsuario();
            string correo = logicaBuscar.ObtenerCorreoPorId(Id_Usuario);

            if (string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("No se encontró correo para el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            L_CrearCodigo2FA logica2FA = new L_CrearCodigo2FA();
            var fechaHoy = DateTime.Now;
            logica2FA.CrearCodigo2FA(Id_Usuario, codigo, fechaHoy);

            Sesion.ArmarMail.DireccionCorreo = correo;
            Sesion.ArmarMail.Asunto = "Código de verificación - Sistema de Gestión";
            Sesion.ArmarMail.ContrasenaSistema = codigo;
            ArmarMail.Preparar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string codigoIngresado = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                mostrarTT.MostrarTooltip(textBox1, "Por favor, ingrese el código.");
                return;
            }

            L_VerificarCodigo2FA logicaVerificar = new L_VerificarCodigo2FA();
            bool esValido = logicaVerificar.VerificarCodigo(Id_Usuario, codigoIngresado);

            if (esValido)
            {
                MessageBox.Show("Código verificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmResponderPreguntas formrp = new frmResponderPreguntas();
                this.Hide();

                DialogResult res = formrp.ShowDialog();

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
            else
            {
                MessageBox.Show("Código incorrecto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
