using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace Vista
{
    public class FrmReportProductosStock : Form
    {
        private DataGridView dgv;
        private Button btnStockGeneral;
        private Button btnPuntoRepos;
        private Button btnProxVencer;
        private Button btnExport;
        private readonly N_Reportes _nReport = new N_Reportes();
        private readonly N_Productos _nProd = new N_Productos();

        public FrmReportProductosStock()
        {
            InitializeComponent();
            Load += FrmReportProductosStock_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Reportes de Productos - Stock";
            this.Size = new Size(1000, 700);

            btnStockGeneral = new Button { Text = "Stock general", Location = new Point(20, 15), Size = new Size(140, 30) };
            btnPuntoRepos = new Button { Text = "Por debajo punto repos.", Location = new Point(170, 15), Size = new Size(180, 30) };
            btnProxVencer = new Button { Text = "Próximos a vencer (30d)", Location = new Point(360, 15), Size = new Size(180, 30) };
            btnExport = new Button { Text = "Exportar CSV", Location = new Point(560, 15), Size = new Size(120, 30) };

            dgv = new DataGridView { Location = new Point(20, 60), Size = new Size(940, 570), ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            btnStockGeneral.Click += BtnStockGeneral_Click;
            btnPuntoRepos.Click += BtnPuntoRepos_Click;
            btnProxVencer.Click += BtnProxVencer_Click;
            btnExport.Click += BtnExport_Click;

            this.Controls.Add(btnStockGeneral);
            this.Controls.Add(btnPuntoRepos);
            this.Controls.Add(btnProxVencer);
            this.Controls.Add(btnExport);
            this.Controls.Add(dgv);
        }

        private void FrmReportProductosStock_Load(object sender, EventArgs e)
        {
            // por defecto cargar stock general
            BtnStockGeneral_Click(null, null);
        }

        private void BtnStockGeneral_Click(object sender, EventArgs e)
        {
            var res = _nReport.ReporteStockGeneral();
            if (!res.Success) { MessageBox.Show("Error: " + string.Join("\n", res.Messages)); return; }
            dgv.DataSource = res.Data;
        }

        private void BtnPuntoRepos_Click(object sender, EventArgs e)
        {
            var res = _nProd.VerificarPuntoReposicion();
            if (!res.Success) { MessageBox.Show("Error: " + string.Join("\n", res.Messages)); return; }
            dgv.DataSource = res.Data;
        }

        private void BtnProxVencer_Click(object sender, EventArgs e)
        {
            var res = _nProd.ProductosProximosVencer(30);
            if (!res.Success) { MessageBox.Show("Error: " + string.Join("\n", res.Messages)); return; }
            dgv.DataSource = res.Data;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dgv.DataSource == null) { MessageBox.Show("No hay datos para exportar."); return; }
            var dt = dgv.DataSource as DataTable;
            if (dt == null)
            {
                // intentar convertir lista a DataTable via reflection
                dt = new DataTable();
                foreach (DataGridViewColumn col in dgv.Columns) dt.Columns.Add(col.HeaderText);
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    if (r.IsNewRow) continue;
                    var vals = new object[dgv.Columns.Count];
                    for (int i = 0; i < dgv.Columns.Count; i++) vals[i] = r.Cells[i].Value;
                    dt.Rows.Add(vals);
                }
            }

            using (var sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = "reporte_stock.csv" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                using (var sw = new StreamWriter(sfd.FileName))
                {
                    var cols = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
                    sw.WriteLine(string.Join(",", cols));
                    foreach (DataRow row in dt.Rows)
                    {
                        var items = row.ItemArray.Select(i => "\"" + (i?.ToString().Replace("\"", "\"\"") ?? "") + "\"");
                        sw.WriteLine(string.Join(",", items));
                    }
                }
                MessageBox.Show("Exportado.");
            }
        }
    }
}