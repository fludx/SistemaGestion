namespace Vista
{
    partial class MDIParent1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.InicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregarPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListarPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfiguracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PoliticasSeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearPreguntasSeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListarPreguntasSeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ModificarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verElStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblRol = new System.Windows.Forms.ToolStripStatusLabel();
            this.MensajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblHoras = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFecha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InicioToolStripMenuItem,
            this.UsuariosToolStripMenuItem,
            this.PersonasToolStripMenuItem,
            this.ConfiguracionToolStripMenuItem,
            this.ReportesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.verElStockToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1179, 52);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // InicioToolStripMenuItem
            // 
            this.InicioToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InicioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("InicioToolStripMenuItem.Image")));
            this.InicioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem";
            this.InicioToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.InicioToolStripMenuItem.Size = new System.Drawing.Size(121, 48);
            this.InicioToolStripMenuItem.Text = "INICIO";
            this.InicioToolStripMenuItem.Click += new System.EventHandler(this.InicioToolStripMenuItem_Click);
            // 
            // UsuariosToolStripMenuItem
            // 
            this.UsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CrearUsuarioToolStripMenuItem,
            this.ListarUsuariosToolStripMenuItem});
            this.UsuariosToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UsuariosToolStripMenuItem.Image")));
            this.UsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem";
            this.UsuariosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.UsuariosToolStripMenuItem.Size = new System.Drawing.Size(139, 48);
            this.UsuariosToolStripMenuItem.Text = "USUARIOS";
            // 
            // CrearUsuarioToolStripMenuItem
            // 
            this.CrearUsuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CrearUsuarioToolStripMenuItem.Image")));
            this.CrearUsuarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CrearUsuarioToolStripMenuItem.Name = "CrearUsuarioToolStripMenuItem";
            this.CrearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.CrearUsuarioToolStripMenuItem.Text = "CREAR USUARIO";
            this.CrearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.CrearUsuarioToolStripMenuItem_Click);
            // 
            // ListarUsuariosToolStripMenuItem
            // 
            this.ListarUsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListarUsuariosToolStripMenuItem.Image")));
            this.ListarUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ListarUsuariosToolStripMenuItem.Name = "ListarUsuariosToolStripMenuItem";
            this.ListarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.ListarUsuariosToolStripMenuItem.Text = "LISTAR USUARIOS";
            this.ListarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.ListarUsuariosToolStripMenuItem_Click);
            // 
            // PersonasToolStripMenuItem
            // 
            this.PersonasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarPersonaToolStripMenuItem,
            this.ListarPersonasToolStripMenuItem});
            this.PersonasToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PersonasToolStripMenuItem.Image")));
            this.PersonasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PersonasToolStripMenuItem.Name = "PersonasToolStripMenuItem";
            this.PersonasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.PersonasToolStripMenuItem.Size = new System.Drawing.Size(139, 48);
            this.PersonasToolStripMenuItem.Text = "PERSONAS";
            // 
            // AgregarPersonaToolStripMenuItem
            // 
            this.AgregarPersonaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AgregarPersonaToolStripMenuItem.Image")));
            this.AgregarPersonaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AgregarPersonaToolStripMenuItem.Name = "AgregarPersonaToolStripMenuItem";
            this.AgregarPersonaToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.AgregarPersonaToolStripMenuItem.Text = "AGREGAR PERSONA";
            this.AgregarPersonaToolStripMenuItem.Click += new System.EventHandler(this.AgregarPersonaToolStripMenuItem_Click);
            // 
            // ListarPersonasToolStripMenuItem
            // 
            this.ListarPersonasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListarPersonasToolStripMenuItem.Image")));
            this.ListarPersonasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ListarPersonasToolStripMenuItem.Name = "ListarPersonasToolStripMenuItem";
            this.ListarPersonasToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.ListarPersonasToolStripMenuItem.Text = "LISTAR PERSONAS";
            this.ListarPersonasToolStripMenuItem.Click += new System.EventHandler(this.ListarPersonasToolStripMenuItem_Click);
            // 
            // ConfiguracionToolStripMenuItem
            // 
            this.ConfiguracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PoliticasSeguridadToolStripMenuItem,
            this.CrearPreguntasSeguridadToolStripMenuItem,
            this.ListarPreguntasSeguridadToolStripMenuItem});
            this.ConfiguracionToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfiguracionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ConfiguracionToolStripMenuItem.Image")));
            this.ConfiguracionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem";
            this.ConfiguracionToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.ConfiguracionToolStripMenuItem.Size = new System.Drawing.Size(184, 48);
            this.ConfiguracionToolStripMenuItem.Text = "CONFIGURACION";
            this.ConfiguracionToolStripMenuItem.Click += new System.EventHandler(this.ConfiguracionToolStripMenuItem_Click);
            // 
            // PoliticasSeguridadToolStripMenuItem
            // 
            this.PoliticasSeguridadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PoliticasSeguridadToolStripMenuItem.Image")));
            this.PoliticasSeguridadToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PoliticasSeguridadToolStripMenuItem.Name = "PoliticasSeguridadToolStripMenuItem";
            this.PoliticasSeguridadToolStripMenuItem.Size = new System.Drawing.Size(346, 30);
            this.PoliticasSeguridadToolStripMenuItem.Text = "POLITICAS SEGURIDAD";
            this.PoliticasSeguridadToolStripMenuItem.Click += new System.EventHandler(this.PoliticasSeguridadToolStripMenuItem_Click);
            // 
            // CrearPreguntasSeguridadToolStripMenuItem
            // 
            this.CrearPreguntasSeguridadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CrearPreguntasSeguridadToolStripMenuItem.Image")));
            this.CrearPreguntasSeguridadToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CrearPreguntasSeguridadToolStripMenuItem.Name = "CrearPreguntasSeguridadToolStripMenuItem";
            this.CrearPreguntasSeguridadToolStripMenuItem.Size = new System.Drawing.Size(346, 30);
            this.CrearPreguntasSeguridadToolStripMenuItem.Text = "CREAR PREGUNTAS DE SEGURIDAD";
            this.CrearPreguntasSeguridadToolStripMenuItem.Click += new System.EventHandler(this.CrearPreguntasSeguridadToolStripMenuItem_Click);
            // 
            // ListarPreguntasSeguridadToolStripMenuItem
            // 
            this.ListarPreguntasSeguridadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListarPreguntasSeguridadToolStripMenuItem.Image")));
            this.ListarPreguntasSeguridadToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ListarPreguntasSeguridadToolStripMenuItem.Name = "ListarPreguntasSeguridadToolStripMenuItem";
            this.ListarPreguntasSeguridadToolStripMenuItem.Size = new System.Drawing.Size(346, 30);
            this.ListarPreguntasSeguridadToolStripMenuItem.Text = "LISTAR PREGUNTAS DE SEGURIDAD";
            this.ListarPreguntasSeguridadToolStripMenuItem.Click += new System.EventHandler(this.ListarPreguntasSeguridadToolStripMenuItem_Click);
            // 
            // ReportesToolStripMenuItem
            // 
            this.ReportesToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ReportesToolStripMenuItem.Image")));
            this.ReportesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem";
            this.ReportesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.ReportesToolStripMenuItem.Size = new System.Drawing.Size(139, 48);
            this.ReportesToolStripMenuItem.Text = "REPORTES";
            this.ReportesToolStripMenuItem.Click += new System.EventHandler(this.ReportesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModificarContraseñaToolStripMenuItem,
            this.CerrarSesionToolStripMenuItem});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 48);
            this.toolStripMenuItem2.Text = "PERFIL";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ModificarContraseñaToolStripMenuItem
            // 
            this.ModificarContraseñaToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarContraseñaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ModificarContraseñaToolStripMenuItem.Image")));
            this.ModificarContraseñaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ModificarContraseñaToolStripMenuItem.Name = "ModificarContraseñaToolStripMenuItem";
            this.ModificarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ModificarContraseñaToolStripMenuItem.Text = "MODIFICAR CONTRASEÑA";
            this.ModificarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.ModificarContraseñaToolStripMenuItem_Click);
            // 
            // CerrarSesionToolStripMenuItem
            // 
            this.CerrarSesionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CerrarSesionToolStripMenuItem.Image")));
            this.CerrarSesionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem";
            this.CerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.CerrarSesionToolStripMenuItem.Text = "CERRAR SESION";
            this.CerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.CerrarSesionToolStripMenuItem_Click);
            // 
            // verElStockToolStripMenuItem
            // 
            this.verElStockToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verElStockToolStripMenuItem.Name = "verElStockToolStripMenuItem";
            this.verElStockToolStripMenuItem.Size = new System.Drawing.Size(102, 48);
            this.verElStockToolStripMenuItem.Text = "Ver stock";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRol,
            this.MensajesToolStripMenuItem});
            this.statusStrip.Location = new System.Drawing.Point(0, 405);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1179, 48);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // lblRol
            // 
            this.lblRol.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Name = "lblRol";
            this.lblRol.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblRol.Size = new System.Drawing.Size(60, 43);
            this.lblRol.Text = "Rol";
            // 
            // MensajesToolStripMenuItem
            // 
            this.MensajesToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MensajesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MensajesToolStripMenuItem.Image")));
            this.MensajesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MensajesToolStripMenuItem.Name = "MensajesToolStripMenuItem";
            this.MensajesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.MensajesToolStripMenuItem.Size = new System.Drawing.Size(139, 48);
            this.MensajesToolStripMenuItem.Text = "MENSAJES";
            this.MensajesToolStripMenuItem.Click += new System.EventHandler(this.MensajesToolStripMenuItem_Click);
            // 
            // lblHoras
            // 
            this.lblHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHoras.AutoSize = true;
            this.lblHoras.BackColor = System.Drawing.Color.White;
            this.lblHoras.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.Location = new System.Drawing.Point(1025, 0);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(90, 22);
            this.lblHoras.TabIndex = 4;
            this.lblHoras.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(1025, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(122, 18);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "dia, 07/12/2003";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(963, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1179, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent1";
            this.Text = "MDIParent1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParent1_Load_1);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem UsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfiguracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InicioToolStripMenuItem;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStripStatusLabel lblRol;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem PoliticasSeguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearPreguntasSeguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListarPreguntasSeguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AgregarPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListarPersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MensajesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModificarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verElStockToolStripMenuItem;
    }
}



