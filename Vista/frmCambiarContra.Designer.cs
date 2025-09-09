using System.Windows.Forms;

namespace Vista
{
    partial class frmCambiarContra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarContra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMostrarContraC = new System.Windows.Forms.Button();
            this.btnMostrarContra = new System.Windows.Forms.Button();
            this.lblConfContra = new System.Windows.Forms.Label();
            this.txtConfContra = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCambiarContra = new System.Windows.Forms.Button();
            this.lblContra = new System.Windows.Forms.Label();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpRestricciones = new System.Windows.Forms.GroupBox();
            this.chkDatosPersonales = new System.Windows.Forms.CheckBox();
            this.chkHistorial = new System.Windows.Forms.CheckBox();
            this.chkEspeciales = new System.Windows.Forms.CheckBox();
            this.chkMayuscula = new System.Windows.Forms.CheckBox();
            this.chkNumeros = new System.Windows.Forms.CheckBox();
            this.chkMinCaracteres = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.grpRestricciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnMostrarContraC);
            this.groupBox1.Controls.Add(this.btnMostrarContra);
            this.groupBox1.Controls.Add(this.lblConfContra);
            this.groupBox1.Controls.Add(this.txtConfContra);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnCambiarContra);
            this.groupBox1.Controls.Add(this.lblContra);
            this.groupBox1.Controls.Add(this.txtContra);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 114);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(777, 467);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnMostrarContraC
            // 
            this.btnMostrarContraC.Image = global::Vista.Properties.Resources.moscon;
            this.btnMostrarContraC.Location = new System.Drawing.Point(727, 253);
            this.btnMostrarContraC.Name = "btnMostrarContraC";
            this.btnMostrarContraC.Size = new System.Drawing.Size(40, 40);
            this.btnMostrarContraC.TabIndex = 18;
            this.btnMostrarContraC.UseVisualStyleBackColor = true;
            this.btnMostrarContraC.Click += new System.EventHandler(this.btnMostrarContraC_Click);
            // 
            // btnMostrarContra
            // 
            this.btnMostrarContra.Image = global::Vista.Properties.Resources.moscon;
            this.btnMostrarContra.Location = new System.Drawing.Point(727, 115);
            this.btnMostrarContra.Name = "btnMostrarContra";
            this.btnMostrarContra.Size = new System.Drawing.Size(40, 40);
            this.btnMostrarContra.TabIndex = 17;
            this.btnMostrarContra.UseVisualStyleBackColor = true;
            this.btnMostrarContra.Click += new System.EventHandler(this.btnMostrarContra_Click);
            // 
            // lblConfContra
            // 
            this.lblConfContra.AutoSize = true;
            this.lblConfContra.Location = new System.Drawing.Point(18, 205);
            this.lblConfContra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfContra.Name = "lblConfContra";
            this.lblConfContra.Size = new System.Drawing.Size(329, 32);
            this.lblConfContra.TabIndex = 16;
            this.lblConfContra.Text = "CONFIRMAR CONTRASEÑA:";
            // 
            // txtConfContra
            // 
            this.txtConfContra.Location = new System.Drawing.Point(14, 255);
            this.txtConfContra.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfContra.Name = "txtConfContra";
            this.txtConfContra.Size = new System.Drawing.Size(703, 38);
            this.txtConfContra.TabIndex = 15;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(416, 317);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.btnCerrar.Size = new System.Drawing.Size(198, 55);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCambiarContra
            // 
            this.btnCambiarContra.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCambiarContra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarContra.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCambiarContra.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarContra.Image")));
            this.btnCambiarContra.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarContra.Location = new System.Drawing.Point(14, 317);
            this.btnCambiarContra.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarContra.Name = "btnCambiarContra";
            this.btnCambiarContra.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.btnCambiarContra.Size = new System.Drawing.Size(378, 55);
            this.btnCambiarContra.TabIndex = 13;
            this.btnCambiarContra.Text = "CAMBIAR CONTRASEÑA";
            this.btnCambiarContra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarContra.UseVisualStyleBackColor = false;
            this.btnCambiarContra.Click += new System.EventHandler(this.btnCambiarContra_Click);
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Location = new System.Drawing.Point(8, 57);
            this.lblContra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(314, 32);
            this.lblContra.TabIndex = 11;
            this.lblContra.Text = "INGRESAR CONTRASEÑA:";
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(14, 115);
            this.txtContra.Margin = new System.Windows.Forms.Padding(4);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(703, 38);
            this.txtContra.TabIndex = 9;
            this.txtContra.TextChanged += new System.EventHandler(this.txtContra_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1256, 66);
            this.label1.TabIndex = 4;
            this.label1.Text = "CAMBIAR CONTRASEÑA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpRestricciones
            // 
            this.grpRestricciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpRestricciones.Controls.Add(this.chkDatosPersonales);
            this.grpRestricciones.Controls.Add(this.chkHistorial);
            this.grpRestricciones.Controls.Add(this.chkEspeciales);
            this.grpRestricciones.Controls.Add(this.chkMayuscula);
            this.grpRestricciones.Controls.Add(this.chkNumeros);
            this.grpRestricciones.Controls.Add(this.chkMinCaracteres);
            this.grpRestricciones.Font = new System.Drawing.Font("Consolas", 13.75F, System.Drawing.FontStyle.Bold);
            this.grpRestricciones.Location = new System.Drawing.Point(797, 114);
            this.grpRestricciones.Name = "grpRestricciones";
            this.grpRestricciones.Size = new System.Drawing.Size(472, 467);
            this.grpRestricciones.TabIndex = 6;
            this.grpRestricciones.TabStop = false;
            this.grpRestricciones.Text = "RESTRICCIONES DE CONTRASEÑA";
            // 
            // chkDatosPersonales
            // 
            this.chkDatosPersonales.AutoSize = true;
            this.chkDatosPersonales.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkDatosPersonales.Location = new System.Drawing.Point(17, 368);
            this.chkDatosPersonales.Margin = new System.Windows.Forms.Padding(20);
            this.chkDatosPersonales.Name = "chkDatosPersonales";
            this.chkDatosPersonales.Size = new System.Drawing.Size(246, 68);
            this.chkDatosPersonales.TabIndex = 5;
            this.chkDatosPersonales.Text = "Contiene datos\r\npersonales";
            this.chkDatosPersonales.UseVisualStyleBackColor = true;
            // 
            // chkHistorial
            // 
            this.chkHistorial.AutoSize = true;
            this.chkHistorial.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkHistorial.Location = new System.Drawing.Point(17, 293);
            this.chkHistorial.Margin = new System.Windows.Forms.Padding(20);
            this.chkHistorial.Name = "chkHistorial";
            this.chkHistorial.Size = new System.Drawing.Size(381, 68);
            this.chkHistorial.TabIndex = 4;
            this.chkHistorial.Text = "No contiene contraseñas\r\nanteriores";
            this.chkHistorial.UseVisualStyleBackColor = true;
            // 
            // chkEspeciales
            // 
            this.chkEspeciales.AutoSize = true;
            this.chkEspeciales.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkEspeciales.Location = new System.Drawing.Point(17, 218);
            this.chkEspeciales.Margin = new System.Windows.Forms.Padding(20);
            this.chkEspeciales.Name = "chkEspeciales";
            this.chkEspeciales.Size = new System.Drawing.Size(321, 68);
            this.chkEspeciales.TabIndex = 3;
            this.chkEspeciales.Text = "Contiene caracteres\r\nespeciales";
            this.chkEspeciales.UseVisualStyleBackColor = true;
            // 
            // chkMayuscula
            // 
            this.chkMayuscula.AutoSize = true;
            this.chkMayuscula.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkMayuscula.Location = new System.Drawing.Point(17, 175);
            this.chkMayuscula.Margin = new System.Windows.Forms.Padding(20);
            this.chkMayuscula.Name = "chkMayuscula";
            this.chkMayuscula.Size = new System.Drawing.Size(321, 36);
            this.chkMayuscula.TabIndex = 2;
            this.chkMayuscula.Text = "Contiene mayúsculas";
            this.chkMayuscula.UseVisualStyleBackColor = true;
            // 
            // chkNumeros
            // 
            this.chkNumeros.AutoSize = true;
            this.chkNumeros.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkNumeros.Location = new System.Drawing.Point(17, 132);
            this.chkNumeros.Margin = new System.Windows.Forms.Padding(20);
            this.chkNumeros.Name = "chkNumeros";
            this.chkNumeros.Size = new System.Drawing.Size(276, 36);
            this.chkNumeros.TabIndex = 1;
            this.chkNumeros.Text = "Contiene numeros";
            this.chkNumeros.UseVisualStyleBackColor = true;
            // 
            // chkMinCaracteres
            // 
            this.chkMinCaracteres.AutoSize = true;
            this.chkMinCaracteres.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkMinCaracteres.Location = new System.Drawing.Point(17, 57);
            this.chkMinCaracteres.Margin = new System.Windows.Forms.Padding(20);
            this.chkMinCaracteres.Name = "chkMinCaracteres";
            this.chkMinCaracteres.Size = new System.Drawing.Size(336, 68);
            this.chkMinCaracteres.TabIndex = 0;
            this.chkMinCaracteres.Text = "Contiene caracteres \r\nminimos";
            this.chkMinCaracteres.UseVisualStyleBackColor = true;
            // 
            // frmCambiarContra
            // 
            this.AcceptButton = this.btnCambiarContra;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1281, 594);
            this.ControlBox = false;
            this.Controls.Add(this.grpRestricciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambiarContra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCrearRespuesta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCrearRespuesta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpRestricciones.ResumeLayout(false);
            this.grpRestricciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCambiarContra;
        private System.Windows.Forms.Label lblContra;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConfContra;
        private System.Windows.Forms.TextBox txtConfContra;
        private Button btnMostrarContra;
        private Button btnMostrarContraC;
        private GroupBox grpRestricciones;
        private CheckBox chkDatosPersonales;
        private CheckBox chkHistorial;
        private CheckBox chkEspeciales;
        private CheckBox chkMayuscula;
        private CheckBox chkNumeros;
        private CheckBox chkMinCaracteres;
    }
}