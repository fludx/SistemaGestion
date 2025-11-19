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
    public partial class MDIStock : Form
    {
        private int childFormNumber = 0;

        public MDIStock()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void buscarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBusClien ventana = new FrmBusClien();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();                              // Ocultar el formulario actual 
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmABM ventana = new FrmABM();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void buscarProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBuscarProveedor ventana = new FrmBuscarProveedor();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void buscarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarProveedor ventana = new FrmBuscarProveedor();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmABM ventana = new FrmABM();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void buscarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBusProduc ventana = new FrmBusProduc();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPedidos ventana = new FrmPedidos();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void verRemitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRem ventana = new FrmRem();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void facturasDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactCom ventana = new FrmFactCom();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void pagosConCreditoYDebitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNot ventana = new FrmNot();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            FrmComp ventana = new FrmComp();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void prodToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmDevolverProductos ventana = new FrmDevolverProductos();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void presupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresuProv ventana = new FrmPresuProv();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrdCom ventana = new FrmOrdCom();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void agregarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmABM ventana = new FrmABM();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void buscarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBusClien ventana = new FrmBusClien();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void emisionregistroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pagosConCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNot ventana = new FrmNot();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void pagosConDebitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNot ventana = new FrmNot();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresuClien ventana = new FrmPresuClien();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void notasDePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotPed ventana = new FrmNotPed();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void devolverProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDevolverProductos ventana = new FrmDevolverProductos();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManejarStock ventana = new FrmManejarStock();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void actualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManejarStock ventana = new FrmManejarStock();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void enScrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScarp ventana = new FrmScarp();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void pendienteDeEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManejarStock ventana = new FrmManejarStock();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void manejoDeScrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScarp ventana = new FrmScarp();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void lotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLote ventana = new FrmLote();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void mercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMercaderia ventana = new FrmMercaderia();  // Crear instancia del formulario
            ventana.Show();                           // Mostrar formulario

            this.Hide();
        }

        private void MDIStock_Load(object sender, EventArgs e)
        {

        }
    }
    }

