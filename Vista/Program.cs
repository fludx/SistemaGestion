using System;
using System.Windows.Forms;

namespace Vista
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool loggedIn = false;
            string rol = null;

            while (!loggedIn)
            {
                using (frmIniciarSesion loginForm = new frmIniciarSesion())
                {
                    DialogResult result = loginForm.ShowDialog();
                    rol = loginForm.Tag?.ToString();

                    if (result == DialogResult.OK && rol != null)
                    {
                        loggedIn = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Se te llevará al inicio de sesión nuevamente.", "Login Fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            Application.Run(new MDIParent1(rol));
        }
    }
}
