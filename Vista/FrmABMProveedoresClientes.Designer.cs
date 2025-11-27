using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Vista
{
    partial class FrmABMProveedoresClientes
    {
        private IContainer components = null;

        private TabControl tabs;
        private TabPage tabProveedores;
        private TabPage tabClientes;

        // Proveedores controls
        private DataGridView dgvProveedores;
        private TextBox txtProvCodigo;
        private TextBox txtProvRazon;
        private TextBox txtProvEmail;
        private TextBox txtProvFormasPago;
        private TextBox txtProvTiemposEntrega;
        private TextBox txtProvDescuentos;
        private Button btnProvNuevo;
        private Button btnProvGuardar;
        private Button btnProvEditar;
        private Button btnProvEliminar;
        private Button btnProvRefrescar;

        // Clientes controls
        private DataGridView dgvClientes;
        private TextBox txtCliCodigo;
        private TextBox txtCliRazon;
        private TextBox txtCliEmail;
        private TextBox txtCliFormasPago;
        private TextBox txtCliDescuentos;
        private TextBox txtCliLimite;
        private Button btnCliNuevo;
        private Button btnCliGuardar;
        private Button btnCliEditar;
        private Button btnCliEliminar;
        private Button btnCliRefrescar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabProveedores = new System.Windows.Forms.TabPage();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.lblProvCodigo = new System.Windows.Forms.Label();
            this.txtProvCodigo = new System.Windows.Forms.TextBox();
            this.lblProvRazon = new System.Windows.Forms.Label();
            this.txtProvRazon = new System.Windows.Forms.TextBox();
            this.lblProvEmail = new System.Windows.Forms.Label();
            this.txtProvEmail = new System.Windows.Forms.TextBox();
            this.lblProvFormasPago = new System.Windows.Forms.Label();
            this.txtProvFormasPago = new System.Windows.Forms.TextBox();
            this.lblProvTiempos = new System.Windows.Forms.Label();
            this.txtProvTiemposEntrega = new System.Windows.Forms.TextBox();
            this.lblProvDescuentos = new System.Windows.Forms.Label();
            this.txtProvDescuentos = new System.Windows.Forms.TextBox();
            this.btnProvNuevo = new System.Windows.Forms.Button();
            this.btnProvGuardar = new System.Windows.Forms.Button();
            this.btnProvEditar = new System.Windows.Forms.Button();
            this.btnProvEliminar = new System.Windows.Forms.Button();
            this.btnProvRefrescar = new System.Windows.Forms.Button();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblCliCodigo = new System.Windows.Forms.Label();
            this.txtCliCodigo = new System.Windows.Forms.TextBox();
            this.lblCliRazon = new System.Windows.Forms.Label();
            this.txtCliRazon = new System.Windows.Forms.TextBox();
            this.lblCliEmail = new System.Windows.Forms.Label();
            this.txtCliEmail = new System.Windows.Forms.TextBox();
            this.lblCliFormas = new System.Windows.Forms.Label();
            this.txtCliFormasPago = new System.Windows.Forms.TextBox();
            this.lblCliDesc = new System.Windows.Forms.Label();
            this.txtCliDescuentos = new System.Windows.Forms.TextBox();
            this.lblCliLimite = new System.Windows.Forms.Label();
            this.txtCliLimite = new System.Windows.Forms.TextBox();
            this.btnCliNuevo = new System.Windows.Forms.Button();
            this.btnCliGuardar = new System.Windows.Forms.Button();
            this.btnCliEditar = new System.Windows.Forms.Button();
            this.btnCliEliminar = new System.Windows.Forms.Button();
            this.btnCliRefrescar = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.tabClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabProveedores);
            this.tabs.Controls.Add(this.tabClientes);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1017, 672);
            this.tabs.TabIndex = 0;
            // 
            // tabProveedores
            // 
            this.tabProveedores.Controls.Add(this.dgvProveedores);
            this.tabProveedores.Controls.Add(this.lblProvCodigo);
            this.tabProveedores.Controls.Add(this.txtProvCodigo);
            this.tabProveedores.Controls.Add(this.lblProvRazon);
            this.tabProveedores.Controls.Add(this.txtProvRazon);
            this.tabProveedores.Controls.Add(this.lblProvEmail);
            this.tabProveedores.Controls.Add(this.txtProvEmail);
            this.tabProveedores.Controls.Add(this.lblProvFormasPago);
            this.tabProveedores.Controls.Add(this.txtProvFormasPago);
            this.tabProveedores.Controls.Add(this.lblProvTiempos);
            this.tabProveedores.Controls.Add(this.txtProvTiemposEntrega);
            this.tabProveedores.Controls.Add(this.lblProvDescuentos);
            this.tabProveedores.Controls.Add(this.txtProvDescuentos);
            this.tabProveedores.Controls.Add(this.btnProvNuevo);
            this.tabProveedores.Controls.Add(this.btnProvGuardar);
            this.tabProveedores.Controls.Add(this.btnProvEditar);
            this.tabProveedores.Controls.Add(this.btnProvEliminar);
            this.tabProveedores.Controls.Add(this.btnProvRefrescar);
            this.tabProveedores.Location = new System.Drawing.Point(4, 22);
            this.tabProveedores.Name = "tabProveedores";
            this.tabProveedores.Padding = new System.Windows.Forms.Padding(3);
            this.tabProveedores.Size = new System.Drawing.Size(1009, 646);
            this.tabProveedores.TabIndex = 0;
            this.tabProveedores.Text = "Proveedores";
            this.tabProveedores.UseVisualStyleBackColor = true;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.Location = new System.Drawing.Point(10, 10);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(560, 480);
            this.dgvProveedores.TabIndex = 1;
            // 
            // lblProvCodigo
            // 
            this.lblProvCodigo.AutoSize = true;
            this.lblProvCodigo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvCodigo.Location = new System.Drawing.Point(590, 10);
            this.lblProvCodigo.Name = "lblProvCodigo";
            this.lblProvCodigo.Size = new System.Drawing.Size(49, 14);
            this.lblProvCodigo.TabIndex = 2;
            this.lblProvCodigo.Text = "Código";
            // 
            // txtProvCodigo
            // 
            this.txtProvCodigo.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtProvCodigo.Location = new System.Drawing.Point(590, 29);
            this.txtProvCodigo.Name = "txtProvCodigo";
            this.txtProvCodigo.Size = new System.Drawing.Size(300, 23);
            this.txtProvCodigo.TabIndex = 3;
            // 
            // lblProvRazon
            // 
            this.lblProvRazon.AutoSize = true;
            this.lblProvRazon.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvRazon.Location = new System.Drawing.Point(590, 55);
            this.lblProvRazon.Name = "lblProvRazon";
            this.lblProvRazon.Size = new System.Drawing.Size(91, 14);
            this.lblProvRazon.TabIndex = 4;
            this.lblProvRazon.Text = "Razón social";
            // 
            // txtProvRazon
            // 
            this.txtProvRazon.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtProvRazon.Location = new System.Drawing.Point(590, 72);
            this.txtProvRazon.Name = "txtProvRazon";
            this.txtProvRazon.Size = new System.Drawing.Size(300, 23);
            this.txtProvRazon.TabIndex = 5;
            // 
            // lblProvEmail
            // 
            this.lblProvEmail.AutoSize = true;
            this.lblProvEmail.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvEmail.Location = new System.Drawing.Point(590, 98);
            this.lblProvEmail.Name = "lblProvEmail";
            this.lblProvEmail.Size = new System.Drawing.Size(42, 14);
            this.lblProvEmail.TabIndex = 6;
            this.lblProvEmail.Text = "Email";
            // 
            // txtProvEmail
            // 
            this.txtProvEmail.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtProvEmail.Location = new System.Drawing.Point(590, 115);
            this.txtProvEmail.Name = "txtProvEmail";
            this.txtProvEmail.Size = new System.Drawing.Size(300, 23);
            this.txtProvEmail.TabIndex = 7;
            // 
            // lblProvFormasPago
            // 
            this.lblProvFormasPago.AutoSize = true;
            this.lblProvFormasPago.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvFormasPago.Location = new System.Drawing.Point(587, 141);
            this.lblProvFormasPago.Name = "lblProvFormasPago";
            this.lblProvFormasPago.Size = new System.Drawing.Size(84, 14);
            this.lblProvFormasPago.TabIndex = 8;
            this.lblProvFormasPago.Text = "Formas pago";
            // 
            // txtProvFormasPago
            // 
            this.txtProvFormasPago.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtProvFormasPago.Location = new System.Drawing.Point(590, 158);
            this.txtProvFormasPago.Name = "txtProvFormasPago";
            this.txtProvFormasPago.Size = new System.Drawing.Size(300, 23);
            this.txtProvFormasPago.TabIndex = 9;
            // 
            // lblProvTiempos
            // 
            this.lblProvTiempos.AutoSize = true;
            this.lblProvTiempos.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvTiempos.Location = new System.Drawing.Point(590, 184);
            this.lblProvTiempos.Name = "lblProvTiempos";
            this.lblProvTiempos.Size = new System.Drawing.Size(112, 14);
            this.lblProvTiempos.TabIndex = 10;
            this.lblProvTiempos.Text = "Tiempos entrega";
            // 
            // txtProvTiemposEntrega
            // 
            this.txtProvTiemposEntrega.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtProvTiemposEntrega.Location = new System.Drawing.Point(590, 201);
            this.txtProvTiemposEntrega.Name = "txtProvTiemposEntrega";
            this.txtProvTiemposEntrega.Size = new System.Drawing.Size(300, 23);
            this.txtProvTiemposEntrega.TabIndex = 11;
            // 
            // lblProvDescuentos
            // 
            this.lblProvDescuentos.AutoSize = true;
            this.lblProvDescuentos.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvDescuentos.Location = new System.Drawing.Point(587, 227);
            this.lblProvDescuentos.Name = "lblProvDescuentos";
            this.lblProvDescuentos.Size = new System.Drawing.Size(77, 14);
            this.lblProvDescuentos.TabIndex = 12;
            this.lblProvDescuentos.Text = "Descuentos";
            // 
            // txtProvDescuentos
            // 
            this.txtProvDescuentos.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtProvDescuentos.Location = new System.Drawing.Point(590, 244);
            this.txtProvDescuentos.Name = "txtProvDescuentos";
            this.txtProvDescuentos.Size = new System.Drawing.Size(300, 23);
            this.txtProvDescuentos.TabIndex = 13;
            // 
            // btnProvNuevo
            // 
            this.btnProvNuevo.BackColor = System.Drawing.Color.Blue;
            this.btnProvNuevo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnProvNuevo.ForeColor = System.Drawing.Color.White;
            this.btnProvNuevo.Location = new System.Drawing.Point(604, 375);
            this.btnProvNuevo.Name = "btnProvNuevo";
            this.btnProvNuevo.Size = new System.Drawing.Size(120, 34);
            this.btnProvNuevo.TabIndex = 14;
            this.btnProvNuevo.Text = "Nuevo";
            this.btnProvNuevo.UseVisualStyleBackColor = false;
            // 
            // btnProvGuardar
            // 
            this.btnProvGuardar.BackColor = System.Drawing.Color.Blue;
            this.btnProvGuardar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnProvGuardar.ForeColor = System.Drawing.Color.White;
            this.btnProvGuardar.Location = new System.Drawing.Point(724, 375);
            this.btnProvGuardar.Name = "btnProvGuardar";
            this.btnProvGuardar.Size = new System.Drawing.Size(120, 34);
            this.btnProvGuardar.TabIndex = 15;
            this.btnProvGuardar.Text = "Guardar";
            this.btnProvGuardar.UseVisualStyleBackColor = false;
            // 
            // btnProvEditar
            // 
            this.btnProvEditar.BackColor = System.Drawing.Color.Blue;
            this.btnProvEditar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnProvEditar.ForeColor = System.Drawing.Color.White;
            this.btnProvEditar.Location = new System.Drawing.Point(604, 415);
            this.btnProvEditar.Name = "btnProvEditar";
            this.btnProvEditar.Size = new System.Drawing.Size(120, 34);
            this.btnProvEditar.TabIndex = 16;
            this.btnProvEditar.Text = "Editar";
            this.btnProvEditar.UseVisualStyleBackColor = false;
            // 
            // btnProvEliminar
            // 
            this.btnProvEliminar.BackColor = System.Drawing.Color.Blue;
            this.btnProvEliminar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnProvEliminar.ForeColor = System.Drawing.Color.White;
            this.btnProvEliminar.Location = new System.Drawing.Point(724, 415);
            this.btnProvEliminar.Name = "btnProvEliminar";
            this.btnProvEliminar.Size = new System.Drawing.Size(120, 34);
            this.btnProvEliminar.TabIndex = 17;
            this.btnProvEliminar.Text = "Eliminar";
            this.btnProvEliminar.UseVisualStyleBackColor = false;
            // 
            // btnProvRefrescar
            // 
            this.btnProvRefrescar.BackColor = System.Drawing.Color.Gray;
            this.btnProvRefrescar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnProvRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnProvRefrescar.Location = new System.Drawing.Point(604, 455);
            this.btnProvRefrescar.Name = "btnProvRefrescar";
            this.btnProvRefrescar.Size = new System.Drawing.Size(240, 34);
            this.btnProvRefrescar.TabIndex = 18;
            this.btnProvRefrescar.Text = "Refrescar";
            this.btnProvRefrescar.UseVisualStyleBackColor = false;
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.dgvClientes);
            this.tabClientes.Controls.Add(this.lblCliCodigo);
            this.tabClientes.Controls.Add(this.txtCliCodigo);
            this.tabClientes.Controls.Add(this.lblCliRazon);
            this.tabClientes.Controls.Add(this.txtCliRazon);
            this.tabClientes.Controls.Add(this.lblCliEmail);
            this.tabClientes.Controls.Add(this.txtCliEmail);
            this.tabClientes.Controls.Add(this.lblCliFormas);
            this.tabClientes.Controls.Add(this.txtCliFormasPago);
            this.tabClientes.Controls.Add(this.lblCliDesc);
            this.tabClientes.Controls.Add(this.txtCliDescuentos);
            this.tabClientes.Controls.Add(this.lblCliLimite);
            this.tabClientes.Controls.Add(this.txtCliLimite);
            this.tabClientes.Controls.Add(this.btnCliNuevo);
            this.tabClientes.Controls.Add(this.btnCliGuardar);
            this.tabClientes.Controls.Add(this.btnCliEditar);
            this.tabClientes.Controls.Add(this.btnCliEliminar);
            this.tabClientes.Controls.Add(this.btnCliRefrescar);
            this.tabClientes.Location = new System.Drawing.Point(4, 22);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientes.Size = new System.Drawing.Size(1009, 646);
            this.tabClientes.TabIndex = 1;
            this.tabClientes.Text = "Clientes";
            this.tabClientes.UseVisualStyleBackColor = true;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(10, 10);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(560, 480);
            this.dgvClientes.TabIndex = 1;
            // 
            // lblCliCodigo
            // 
            this.lblCliCodigo.AutoSize = true;
            this.lblCliCodigo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliCodigo.Location = new System.Drawing.Point(590, 0);
            this.lblCliCodigo.Name = "lblCliCodigo";
            this.lblCliCodigo.Size = new System.Drawing.Size(49, 14);
            this.lblCliCodigo.TabIndex = 2;
            this.lblCliCodigo.Text = "Código";
            // 
            // txtCliCodigo
            // 
            this.txtCliCodigo.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCliCodigo.Location = new System.Drawing.Point(590, 20);
            this.txtCliCodigo.Name = "txtCliCodigo";
            this.txtCliCodigo.Size = new System.Drawing.Size(300, 23);
            this.txtCliCodigo.TabIndex = 3;
            // 
            // lblCliRazon
            // 
            this.lblCliRazon.AutoSize = true;
            this.lblCliRazon.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliRazon.Location = new System.Drawing.Point(590, 46);
            this.lblCliRazon.Name = "lblCliRazon";
            this.lblCliRazon.Size = new System.Drawing.Size(91, 14);
            this.lblCliRazon.TabIndex = 4;
            this.lblCliRazon.Text = "Razón social";
            // 
            // txtCliRazon
            // 
            this.txtCliRazon.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCliRazon.Location = new System.Drawing.Point(590, 67);
            this.txtCliRazon.Name = "txtCliRazon";
            this.txtCliRazon.Size = new System.Drawing.Size(300, 23);
            this.txtCliRazon.TabIndex = 5;
            // 
            // lblCliEmail
            // 
            this.lblCliEmail.AutoSize = true;
            this.lblCliEmail.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliEmail.Location = new System.Drawing.Point(590, 93);
            this.lblCliEmail.Name = "lblCliEmail";
            this.lblCliEmail.Size = new System.Drawing.Size(42, 14);
            this.lblCliEmail.TabIndex = 6;
            this.lblCliEmail.Text = "Email";
            // 
            // txtCliEmail
            // 
            this.txtCliEmail.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCliEmail.Location = new System.Drawing.Point(590, 110);
            this.txtCliEmail.Name = "txtCliEmail";
            this.txtCliEmail.Size = new System.Drawing.Size(300, 23);
            this.txtCliEmail.TabIndex = 7;
            // 
            // lblCliFormas
            // 
            this.lblCliFormas.AutoSize = true;
            this.lblCliFormas.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliFormas.Location = new System.Drawing.Point(590, 136);
            this.lblCliFormas.Name = "lblCliFormas";
            this.lblCliFormas.Size = new System.Drawing.Size(84, 14);
            this.lblCliFormas.TabIndex = 8;
            this.lblCliFormas.Text = "Formas pago";
            // 
            // txtCliFormasPago
            // 
            this.txtCliFormasPago.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCliFormasPago.Location = new System.Drawing.Point(590, 153);
            this.txtCliFormasPago.Name = "txtCliFormasPago";
            this.txtCliFormasPago.Size = new System.Drawing.Size(300, 23);
            this.txtCliFormasPago.TabIndex = 9;
            // 
            // lblCliDesc
            // 
            this.lblCliDesc.AutoSize = true;
            this.lblCliDesc.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliDesc.Location = new System.Drawing.Point(590, 179);
            this.lblCliDesc.Name = "lblCliDesc";
            this.lblCliDesc.Size = new System.Drawing.Size(77, 14);
            this.lblCliDesc.TabIndex = 10;
            this.lblCliDesc.Text = "Descuentos";
            // 
            // txtCliDescuentos
            // 
            this.txtCliDescuentos.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCliDescuentos.Location = new System.Drawing.Point(593, 197);
            this.txtCliDescuentos.Name = "txtCliDescuentos";
            this.txtCliDescuentos.Size = new System.Drawing.Size(300, 23);
            this.txtCliDescuentos.TabIndex = 11;
            // 
            // lblCliLimite
            // 
            this.lblCliLimite.AutoSize = true;
            this.lblCliLimite.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliLimite.Location = new System.Drawing.Point(590, 223);
            this.lblCliLimite.Name = "lblCliLimite";
            this.lblCliLimite.Size = new System.Drawing.Size(105, 14);
            this.lblCliLimite.TabIndex = 12;
            this.lblCliLimite.Text = "Límite crédito";
            // 
            // txtCliLimite
            // 
            this.txtCliLimite.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCliLimite.Location = new System.Drawing.Point(593, 240);
            this.txtCliLimite.Name = "txtCliLimite";
            this.txtCliLimite.Size = new System.Drawing.Size(300, 23);
            this.txtCliLimite.TabIndex = 13;
            // 
            // btnCliNuevo
            // 
            this.btnCliNuevo.BackColor = System.Drawing.Color.Blue;
            this.btnCliNuevo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnCliNuevo.ForeColor = System.Drawing.Color.White;
            this.btnCliNuevo.Location = new System.Drawing.Point(600, 388);
            this.btnCliNuevo.Name = "btnCliNuevo";
            this.btnCliNuevo.Size = new System.Drawing.Size(120, 34);
            this.btnCliNuevo.TabIndex = 14;
            this.btnCliNuevo.Text = "Nuevo";
            this.btnCliNuevo.UseVisualStyleBackColor = false;
            // 
            // btnCliGuardar
            // 
            this.btnCliGuardar.BackColor = System.Drawing.Color.Blue;
            this.btnCliGuardar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnCliGuardar.ForeColor = System.Drawing.Color.White;
            this.btnCliGuardar.Location = new System.Drawing.Point(720, 388);
            this.btnCliGuardar.Name = "btnCliGuardar";
            this.btnCliGuardar.Size = new System.Drawing.Size(120, 34);
            this.btnCliGuardar.TabIndex = 15;
            this.btnCliGuardar.Text = "Guardar";
            this.btnCliGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCliEditar
            // 
            this.btnCliEditar.BackColor = System.Drawing.Color.Blue;
            this.btnCliEditar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnCliEditar.ForeColor = System.Drawing.Color.White;
            this.btnCliEditar.Location = new System.Drawing.Point(600, 422);
            this.btnCliEditar.Name = "btnCliEditar";
            this.btnCliEditar.Size = new System.Drawing.Size(120, 34);
            this.btnCliEditar.TabIndex = 16;
            this.btnCliEditar.Text = "Editar";
            this.btnCliEditar.UseVisualStyleBackColor = false;
            // 
            // btnCliEliminar
            // 
            this.btnCliEliminar.BackColor = System.Drawing.Color.Blue;
            this.btnCliEliminar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnCliEliminar.ForeColor = System.Drawing.Color.White;
            this.btnCliEliminar.Location = new System.Drawing.Point(720, 422);
            this.btnCliEliminar.Name = "btnCliEliminar";
            this.btnCliEliminar.Size = new System.Drawing.Size(120, 34);
            this.btnCliEliminar.TabIndex = 17;
            this.btnCliEliminar.Text = "Eliminar";
            this.btnCliEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCliRefrescar
            // 
            this.btnCliRefrescar.BackColor = System.Drawing.Color.Gray;
            this.btnCliRefrescar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnCliRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnCliRefrescar.Location = new System.Drawing.Point(600, 456);
            this.btnCliRefrescar.Name = "btnCliRefrescar";
            this.btnCliRefrescar.Size = new System.Drawing.Size(240, 34);
            this.btnCliRefrescar.TabIndex = 18;
            this.btnCliRefrescar.Text = "Refrescar";
            this.btnCliRefrescar.UseVisualStyleBackColor = false;
            // 
            // FrmABMProveedoresClientes
            // 
            this.ClientSize = new System.Drawing.Size(1017, 672);
            this.Controls.Add(this.tabs);
            this.Name = "FrmABMProveedoresClientes";
            this.Text = "ABM Proveedores y Clientes";
            this.tabs.ResumeLayout(false);
            this.tabProveedores.ResumeLayout(false);
            this.tabProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.tabClientes.ResumeLayout(false);
            this.tabClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblProvCodigo;
        private Label lblProvRazon;
        private Label lblProvEmail;
        private Label lblProvFormasPago;
        private Label lblProvTiempos;
        private Label lblProvDescuentos;
        private Label lblCliCodigo;
        private Label lblCliRazon;
        private Label lblCliEmail;
        private Label lblCliFormas;
        private Label lblCliDesc;
        private Label lblCliLimite;
    }
}