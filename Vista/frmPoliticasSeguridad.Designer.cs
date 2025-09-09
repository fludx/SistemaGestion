namespace Vista
{
    partial class frmPoliticasSeguridad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPoliticasSeguridad));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPoliticas = new System.Windows.Forms.GroupBox();
            this.chkDatosPersonales = new System.Windows.Forms.CheckBox();
            this.chkEvitarRepetir = new System.Windows.Forms.CheckBox();
            this.chkCaracterEspecial = new System.Windows.Forms.CheckBox();
            this.chkNumerosLetras = new System.Windows.Forms.CheckBox();
            this.chkMayusMinus = new System.Windows.Forms.CheckBox();
            this.nudMinCaracteres = new System.Windows.Forms.NumericUpDown();
            this.lblMinCaracteres = new System.Windows.Forms.Label();
            this.groupBoxAutenticacion = new System.Windows.Forms.GroupBox();
            this.chkAutenticacionDoble = new System.Windows.Forms.CheckBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBoxPoliticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaracteres)).BeginInit();
            this.groupBoxAutenticacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(634, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "POLITICAS DE SEGURIDAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxPoliticas
            // 
            this.groupBoxPoliticas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxPoliticas.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxPoliticas.Controls.Add(this.chkDatosPersonales);
            this.groupBoxPoliticas.Controls.Add(this.chkEvitarRepetir);
            this.groupBoxPoliticas.Controls.Add(this.chkCaracterEspecial);
            this.groupBoxPoliticas.Controls.Add(this.chkNumerosLetras);
            this.groupBoxPoliticas.Controls.Add(this.chkMayusMinus);
            this.groupBoxPoliticas.Controls.Add(this.nudMinCaracteres);
            this.groupBoxPoliticas.Controls.Add(this.lblMinCaracteres);
            this.groupBoxPoliticas.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPoliticas.Location = new System.Drawing.Point(13, 95);
            this.groupBoxPoliticas.Name = "groupBoxPoliticas";
            this.groupBoxPoliticas.Size = new System.Drawing.Size(634, 336);
            this.groupBoxPoliticas.TabIndex = 1;
            this.groupBoxPoliticas.TabStop = false;
            this.groupBoxPoliticas.Text = "POLITICAS DE CONTRASEÑA";
            // 
            // chkDatosPersonales
            // 
            this.chkDatosPersonales.AutoSize = true;
            this.chkDatosPersonales.Location = new System.Drawing.Point(24, 284);
            this.chkDatosPersonales.Name = "chkDatosPersonales";
            this.chkDatosPersonales.Size = new System.Drawing.Size(456, 36);
            this.chkDatosPersonales.TabIndex = 8;
            this.chkDatosPersonales.Text = "NO PERMITIR DATOS PERSONALES";
            this.chkDatosPersonales.UseVisualStyleBackColor = true;
            // 
            // chkEvitarRepetir
            // 
            this.chkEvitarRepetir.AutoSize = true;
            this.chkEvitarRepetir.Location = new System.Drawing.Point(24, 250);
            this.chkEvitarRepetir.Name = "chkEvitarRepetir";
            this.chkEvitarRepetir.Size = new System.Drawing.Size(531, 36);
            this.chkEvitarRepetir.TabIndex = 7;
            this.chkEvitarRepetir.Text = "NO REPETIR CONTRASEÑAS ANTERIORES";
            this.chkEvitarRepetir.UseVisualStyleBackColor = true;
            // 
            // chkCaracterEspecial
            // 
            this.chkCaracterEspecial.AutoSize = true;
            this.chkCaracterEspecial.Location = new System.Drawing.Point(24, 216);
            this.chkCaracterEspecial.Name = "chkCaracterEspecial";
            this.chkCaracterEspecial.Size = new System.Drawing.Size(471, 36);
            this.chkCaracterEspecial.TabIndex = 6;
            this.chkCaracterEspecial.Text = "CONTENER UN CARACTER ESPECIAL";
            this.chkCaracterEspecial.UseVisualStyleBackColor = true;
            // 
            // chkNumerosLetras
            // 
            this.chkNumerosLetras.AutoSize = true;
            this.chkNumerosLetras.Location = new System.Drawing.Point(24, 182);
            this.chkNumerosLetras.Name = "chkNumerosLetras";
            this.chkNumerosLetras.Size = new System.Drawing.Size(411, 36);
            this.chkNumerosLetras.TabIndex = 5;
            this.chkNumerosLetras.Text = "CONTENER NÚMEROS Y LETRAS";
            this.chkNumerosLetras.UseVisualStyleBackColor = true;
            this.chkNumerosLetras.CheckedChanged += new System.EventHandler(this.chkNumerosLetras_CheckedChanged);
            // 
            // chkMayusMinus
            // 
            this.chkMayusMinus.AutoSize = true;
            this.chkMayusMinus.Location = new System.Drawing.Point(24, 148);
            this.chkMayusMinus.Name = "chkMayusMinus";
            this.chkMayusMinus.Size = new System.Drawing.Size(516, 36);
            this.chkMayusMinus.TabIndex = 4;
            this.chkMayusMinus.Text = "COMBINAR MAYÚSCULAS Y MINÚSCULAS";
            this.chkMayusMinus.UseVisualStyleBackColor = true;
            // 
            // nudMinCaracteres
            // 
            this.nudMinCaracteres.Location = new System.Drawing.Point(400, 68);
            this.nudMinCaracteres.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMinCaracteres.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudMinCaracteres.Name = "nudMinCaracteres";
            this.nudMinCaracteres.Size = new System.Drawing.Size(60, 38);
            this.nudMinCaracteres.TabIndex = 1;
            this.nudMinCaracteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinCaracteres.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lblMinCaracteres
            // 
            this.lblMinCaracteres.AutoSize = true;
            this.lblMinCaracteres.Location = new System.Drawing.Point(18, 74);
            this.lblMinCaracteres.Name = "lblMinCaracteres";
            this.lblMinCaracteres.Size = new System.Drawing.Size(314, 32);
            this.lblMinCaracteres.TabIndex = 0;
            this.lblMinCaracteres.Text = "MINIMO DE CARACTERES";
            // 
            // groupBoxAutenticacion
            // 
            this.groupBoxAutenticacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxAutenticacion.Controls.Add(this.chkAutenticacionDoble);
            this.groupBoxAutenticacion.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAutenticacion.Location = new System.Drawing.Point(13, 437);
            this.groupBoxAutenticacion.Name = "groupBoxAutenticacion";
            this.groupBoxAutenticacion.Size = new System.Drawing.Size(634, 100);
            this.groupBoxAutenticacion.TabIndex = 2;
            this.groupBoxAutenticacion.TabStop = false;
            this.groupBoxAutenticacion.Text = "AUTENTICACIÓN";
            // 
            // chkAutenticacionDoble
            // 
            this.chkAutenticacionDoble.AutoSize = true;
            this.chkAutenticacionDoble.Location = new System.Drawing.Point(81, 31);
            this.chkAutenticacionDoble.Name = "chkAutenticacionDoble";
            this.chkAutenticacionDoble.Size = new System.Drawing.Size(561, 68);
            this.chkAutenticacionDoble.TabIndex = 9;
            this.chkAutenticacionDoble.Text = "REQUERIR AUTENTICACIÓN EN DOS PASOS\r\n(2FA) POR CORREO ELECTRONICO";
            this.chkAutenticacionDoble.UseVisualStyleBackColor = true;
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIniciarSesion.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIniciarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarSesion.Image")));
            this.btnIniciarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciarSesion.Location = new System.Drawing.Point(13, 555);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnIniciarSesion.Size = new System.Drawing.Size(150, 45);
            this.btnIniciarSesion.TabIndex = 6;
            this.btnIniciarSesion.Text = "GUARDAR";
            this.btnIniciarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCerrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(506, 555);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCerrar.Size = new System.Drawing.Size(141, 45);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmPoliticasSeguridad
            // 
            this.AcceptButton = this.btnIniciarSesion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(660, 631);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.groupBoxAutenticacion);
            this.Controls.Add(this.groupBoxPoliticas);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPoliticasSeguridad";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPoliticasSeguridad";
            this.Load += new System.EventHandler(this.frmPoliticasSeguridad_Load);
            this.groupBoxPoliticas.ResumeLayout(false);
            this.groupBoxPoliticas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaracteres)).EndInit();
            this.groupBoxAutenticacion.ResumeLayout(false);
            this.groupBoxAutenticacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxPoliticas;
        private System.Windows.Forms.CheckBox chkDatosPersonales;
        private System.Windows.Forms.CheckBox chkEvitarRepetir;
        private System.Windows.Forms.CheckBox chkCaracterEspecial;
        private System.Windows.Forms.CheckBox chkNumerosLetras;
        private System.Windows.Forms.CheckBox chkMayusMinus;
        private System.Windows.Forms.NumericUpDown nudMinCaracteres;
        private System.Windows.Forms.Label lblMinCaracteres;
        private System.Windows.Forms.GroupBox groupBoxAutenticacion;
        private System.Windows.Forms.CheckBox chkAutenticacionDoble;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Button btnCerrar;
    }
}