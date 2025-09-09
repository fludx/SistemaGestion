using Sesion;
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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;


        private string rolUsuario;

        public MDIParent1(string rol)
        {
            InitializeComponent();

            rolUsuario = rol;


            lblRol.Text = $"CARGO: {rolUsuario}";

            Console.WriteLine($"Rol del usuario: {rolUsuario}");

            AplicarPermisosPorRol(rol);

        }



        private void AplicarPermisosPorRol(string rol)
        {


            if (rol == null)
            {

                frmIniciarSesion loginForm = new frmIniciarSesion();
                loginForm.Show();

                this.Close();

                return;
            }

                switch (rol.ToLower())
            {
                case "administrador":
            
                    break;

                case "usuario normal":
                
                    UsuariosToolStripMenuItem.Enabled = false;
                    UsuariosToolStripMenuItem.Visible = false;

                    PersonasToolStripMenuItem.Enabled = false;
                    PersonasToolStripMenuItem.Visible = false;

                    PoliticasSeguridadToolStripMenuItem.Enabled = false;
                    PoliticasSeguridadToolStripMenuItem.Visible = false;

                    ReportesToolStripMenuItem.Enabled = false;
                    ReportesToolStripMenuItem.Visible = false;

                    CrearPreguntasSeguridadToolStripMenuItem.Enabled = false;
                    CrearPreguntasSeguridadToolStripMenuItem.Visible = false;
                    break;               

                default:
               
                    menuStrip.Enabled = false;
                    break;
            }
        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoras.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("ddd/dd/MM/yyyy");

        }

        private void PoliticasSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmPoliticasSeguridad)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront(); 
                    form.Focus();        
                    return;            
                }
            }

            frmPoliticasSeguridad formularioPoliticas = new frmPoliticasSeguridad();
            formularioPoliticas.MdiParent = this;
            formularioPoliticas.WindowState = FormWindowState.Maximized;
            formularioPoliticas.Show(); 

        }

        private void CrearPreguntasSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form is frmPreguntasDeSeguridad)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }


            frmPreguntasDeSeguridad formularioPreguntas = new frmPreguntasDeSeguridad();
            formularioPreguntas.MdiParent = this;
            formularioPreguntas.WindowState = FormWindowState.Maximized;
            formularioPreguntas.Show();
        }

        private void ListarPreguntasSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmListadoPreguntasDeSeguridad)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }

     
            frmListadoPreguntasDeSeguridad formularioListado = new frmListadoPreguntasDeSeguridad();
            formularioListado.MdiParent = this;
            formularioListado.WindowState = FormWindowState.Maximized;
            formularioListado.Show();
        }

        private void CrearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form is frmRegistrarUsuarios)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }


            frmRegistrarUsuarios formularioRegistrar = new frmRegistrarUsuarios();
            formularioRegistrar.MdiParent = this;
            formularioRegistrar.WindowState = FormWindowState.Maximized;
            formularioRegistrar.Show();
        }

        private void AgregarPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmRegistrarPersonas)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }

 
            frmRegistrarPersonas formularioPersona = new frmRegistrarPersonas();
            formularioPersona.MdiParent = this;
            formularioPersona.WindowState = FormWindowState.Maximized;
            formularioPersona.Show();
        }

        private void ListarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmListadoPersonas)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }


            frmListadoPersonas formularioListadoP = new frmListadoPersonas();
            formularioListadoP.MdiParent = this;
            formularioListadoP.StartPosition = FormStartPosition.Manual;
            formularioListadoP.Location = new Point(
                (this.ClientSize.Width - formularioListadoP.Width) / 2,
                (this.ClientSize.Height - formularioListadoP.Height) / 3
            );

            formularioListadoP.Show();
        }

        private void ListarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form is frmListadoUsuarios)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }


            frmListadoUsuarios formularioListado = new frmListadoUsuarios();
            formularioListado.MdiParent = this;
            formularioListado.WindowState = FormWindowState.Maximized;
            formularioListado.Show();
        }

        private void ConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmLogs)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }

            frmLogs formularioListado = new frmLogs();
            formularioListado.MdiParent = this;
            formularioListado.WindowState = FormWindowState.Maximized;
            formularioListado.Show();
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MensajesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form is frmMensajes)
                {
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }


            frmMensajes formMensajes = new frmMensajes();
            formMensajes.MdiParent = this;
            formMensajes.Show();
        }

        private void MDIParent1_Load_1(object sender, EventArgs e)
        {

        }

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionUsuario.Usuario = null;
            SesionUsuario.IdUsuario = 0;
            SesionUsuario.EsAdmin = false;
            SesionUsuario.Rol = null;

            this.Hide();

            using (frmIniciarSesion loginForm = new frmIniciarSesion())
            {
                DialogResult res = loginForm.ShowDialog();

                if (res == DialogResult.OK && loginForm.Tag != null)
                {
                    this.AplicarPermisosPorRol(loginForm.Tag.ToString());
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void ModificarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmCambiarContra)
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }
            frmCambiarContra frmCambiar = new frmCambiarContra();
            frmCambiar.MdiParent = this;
            frmCambiar.StartPosition = FormStartPosition.Manual;
            frmCambiar.Location = new Point(
                (this.ClientSize.Width - frmCambiar.Width) / 2,
                (this.ClientSize.Height - frmCambiar.Height) / 3
            );

            frmCambiar.Show();
        }


    }
}

