using Logica;
using Sesion;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmRegistrarPersonas : Form
    {
        private MostrarToolTip mostrarTT = new MostrarToolTip();
        public frmRegistrarPersonas()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchImg_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigoPostal.Text, out int cp))
            {
                bool encontrado = L_EjecutarBusquedaCP.BuscarCP(cp);

                if (encontrado)
                {
                    txtLocalidad.Text = L_EjecutarBusquedaCP.Localidad;
                    txtPartido.Text = L_EjecutarBusquedaCP.Partido;
                    txtProvincia.Text = L_EjecutarBusquedaCP.Provincia;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para ese código postal.");
                    txtLocalidad.Text = "";
                    txtPartido.Text = "";
                    txtProvincia.Text = "";
                }
            }
            else
            {
                mostrarTT.MostrarTooltip(txtCodigoPostal, "Ingrese un código postal válido.");
            }
        }

        private void btnCrearPersona_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mostrarTT.MostrarTooltip(txtNombre, "Debe ingresar un nombre.");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                mostrarTT.MostrarTooltip(txtApellido, "Debe ingresar un apellido.");
                txtApellido.Focus();
                return;
            }

            if (cbTipoDocumento.SelectedItem == null)
            {
                mostrarTT.MostrarTooltip(cbTipoDocumento, "Debe seleccionar un tipo de documento.");
                cbTipoDocumento.Focus();
                return;
            }

            if (txtNumeroDocumento.Visible && string.IsNullOrWhiteSpace(txtNumeroDocumento.Text))
            {
                mostrarTT.MostrarTooltip(txtNumeroDocumento, "Debe ingresar un número de documento.");
                txtNumeroDocumento.Focus();
                return;
            }

            if (txtCUIL.Visible && string.IsNullOrWhiteSpace(txtCUIL.Text))
            {
                mostrarTT.MostrarTooltip(txtCUIL, "Debe ingresar un CUIL.");
                txtCUIL.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                mostrarTT.MostrarTooltip(txtCalle, "Debe ingresar una calle.");
                txtCalle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                mostrarTT.MostrarTooltip(txtAltura, "Debe ingresar una altura.");
                txtAltura.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoPostal.Text))
            {
                mostrarTT.MostrarTooltip(txtCodigoPostal, "Debe ingresar un código postal.");
                txtCodigoPostal.Focus();
                return;
            }

            if (cbGenero.SelectedItem == null)
            {
                mostrarTT.MostrarTooltip(cbGenero, "Debe seleccionar un género.");
                cbGenero.Focus();
                return;
            }

            if (cbSexo.SelectedItem == null)
            {
                mostrarTT.MostrarTooltip(cbSexo, "Debe seleccionar un sexo.");
                cbSexo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
            {
                mostrarTT.MostrarTooltip(txtCorreoElectronico, "Debe ingresar un correo electrónico.");
                txtCorreoElectronico.Focus();
                return;
            }

            if (!txtCorreoElectronico.Text.Contains("@") || !txtCorreoElectronico.Text.Contains("."))
            {
                mostrarTT.MostrarTooltip(txtCorreoElectronico, "El correo electrónico debe contener '@' y un dominio válido.");
                txtCorreoElectronico.Focus();
                return;
            }

            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string tipoDocumento = cbTipoDocumento.SelectedItem.ToString();
                string numDocumento = txtNumeroDocumento.Text.Trim();
                string cuil = txtCUIL.Text.Trim();
                string calle = txtCalle.Text.Trim();
                string altura = txtAltura.Text.Trim();
                string piso = txtPiso.Text.Trim();
                string departamento = txtDepartamento.Text.Trim();
                string codigoPostal = txtCodigoPostal.Text.Trim();
                string genero = cbGenero.SelectedItem.ToString();
                bool sexo = cbSexo.SelectedItem.ToString() == "Masculino";
                string email = txtCorreoElectronico.Text.Trim();
                int provincia = L_EjecutarBusquedaCP.idLocalidad;
                int partido = L_EjecutarBusquedaCP.idPartido;
                int localidad = L_EjecutarBusquedaCP.idProvincia;
                DateTime fechaAlta = DateTime.Now;

                var traerGenero = new L_Traer_Genero();
                traerGenero.Genero = genero;

                if (!traerGenero.BuscarGenero())
                {
                    MessageBox.Show("No se encontró el ID del género seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idGenero = traerGenero.IdGenero;

                Logica.L_Registro logica = new Logica.L_Registro();

                bool resultado = logica.RegistrarPersona(
                    nombre, apellido, tipoDocumento, numDocumento, cuil,
                    calle, altura, piso, departamento, codigoPostal,
                    provincia, partido, localidad, idGenero,
                    sexo, email, fechaAlta
                );

                if (resultado)
                {
                    Logica.L_Logs logicaLogs = new Logica.L_Logs();
                    logicaLogs.InsertarLog(SesionUsuario.Usuario, $"Registro de la persona {nombre} {apellido} exitosamente");

                                MessageBox.Show("Persona registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmRegistrarUsuarios frmRegistrarUsuarios = new frmRegistrarUsuarios();
                    frmRegistrarUsuarios.ShowDialog();
                }
                else
                    MessageBox.Show("Ocurrió un error al registrar la persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccionado = cbTipoDocumento.SelectedItem?.ToString();

            if (seleccionado == "DNI")
            {
                txtNumeroDocumento.Visible = true;
                lblNumeroDocumento.Visible = true;
                txtCUIL.Visible = false;
                lblCUIL.Visible = false;
            }
            else if (seleccionado == "CUIL")
            {
                txtCUIL.Visible = true;
                lblCUIL.Visible = true;
                txtNumeroDocumento.Visible = false;
                lblNumeroDocumento.Visible = false;
            }
            else
            {
                txtNumeroDocumento.Visible = false;
                lblNumeroDocumento.Visible = false;
                txtCUIL.Visible = false;
                lblCUIL.Visible = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloLetras(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloLetras(sender, e);
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloNumeros(sender, e);
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloNumeros(sender, e);
        }

        private void txtCUIL_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloNumeros(sender, e);
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloNumeros(sender, e);
        }

        private void txtDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloNumeros(sender, e);
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorTextBox.SoloNumeros(sender, e);
        }
    }
}
