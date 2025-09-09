using System.Windows.Forms;

namespace Vista
{
    partial class frmResponderPreguntas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResponderPreguntas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.lblPreguntaLista = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnResponderPregunta = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lblProgreso);
            this.groupBox1.Controls.Add(this.lblPreguntaLista);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnResponderPregunta);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.txtRespuesta);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 117);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1063, 357);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RESPONDE LAS PREGUNTAS DE SEGURIDAD";
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Location = new System.Drawing.Point(928, 35);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(29, 32);
            this.lblProgreso.TabIndex = 16;
            this.lblProgreso.Text = " ";
            // 
            // lblPreguntaLista
            // 
            this.lblPreguntaLista.AutoSize = true;
            this.lblPreguntaLista.Location = new System.Drawing.Point(271, 86);
            this.lblPreguntaLista.Name = "lblPreguntaLista";
            this.lblPreguntaLista.Size = new System.Drawing.Size(29, 32);
            this.lblPreguntaLista.TabIndex = 15;
            this.lblPreguntaLista.Text = " ";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(772, 235);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.btnCerrar.Size = new System.Drawing.Size(185, 55);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnResponderPregunta
            // 
            this.btnResponderPregunta.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnResponderPregunta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResponderPregunta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnResponderPregunta.ForeColor = System.Drawing.SystemColors.Control;
            this.btnResponderPregunta.Image = ((System.Drawing.Image)(resources.GetObject("btnResponderPregunta.Image")));
            this.btnResponderPregunta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResponderPregunta.Location = new System.Drawing.Point(120, 235);
            this.btnResponderPregunta.Margin = new System.Windows.Forms.Padding(4);
            this.btnResponderPregunta.Name = "btnResponderPregunta";
            this.btnResponderPregunta.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.btnResponderPregunta.Size = new System.Drawing.Size(251, 55);
            this.btnResponderPregunta.TabIndex = 13;
            this.btnResponderPregunta.Text = "RESPONDER";
            this.btnResponderPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResponderPregunta.UseVisualStyleBackColor = false;
            this.btnResponderPregunta.Click += new System.EventHandler(this.btnResponderPregunta_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(115, 86);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(149, 32);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "PREGUNTA:";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(121, 150);
            this.txtRespuesta.Margin = new System.Windows.Forms.Padding(4);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(836, 38);
            this.txtRespuesta.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1063, 66);
            this.label1.TabIndex = 4;
            this.label1.Text = "RESPONDER PREGUNTAS DE SEGURIDAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmResponderPreguntas
            // 
            this.AcceptButton = this.btnResponderPregunta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1089, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmResponderPreguntas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmResponderPreguntas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmResponderPreguntas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnResponderPregunta;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPreguntaLista;
        private System.Windows.Forms.Label lblProgreso;
    }
}