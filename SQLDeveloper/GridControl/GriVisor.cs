using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GridControl
{
    internal enum ETipoArchivo
    {
        XLS,
        SCV,
        XML
    }
    public partial class GriVisor : UserControl
    {
        private ETipoArchivo TipoArchivo;
        private string FileName;
        private List<CTablaColumnas> TablasSeleccionadas;
        private FormColumnas dlgColumnas;
        private DataTable FTabla;
        private string Filtro;
        public GriVisor()
        {
            InitializeComponent();
            BarraProgreso.Visible = false;
        }
        public DataTable Tabla
        {
            get
            {
                return FTabla;
            }
            set
            {
                FTabla = value;
                Grid.DataSource = FTabla;
                if (FTabla == null)
                {
                    ActivaBotones = false;
                    return;
                }
               // LTabla.Text = FTabla.TableName;
                LRegistros.Text = FTabla.Rows.Count.ToString();
                ActivaBotones = true;
              //  Grid.Rows[0]. = "hola";
            }
        }
        private bool ActivaBotones
        {
            set
            {
                BExportar.Enabled = value;
                BFiltrar.Enabled = value;
                BFiltoCampos.Enabled = value;
            }
        }
        private void BExportar_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            BarraProgreso.Visible = true;
            FileName = saveFileDialog1.FileName;
            switch (saveFileDialog1.FilterIndex)
            {
                case 1:
                    TipoArchivo = ETipoArchivo.XLS;
                    break;
                case 2:
                    TipoArchivo = ETipoArchivo.SCV;
                    break;
                case 3:
                    TipoArchivo = ETipoArchivo.XML;
                    break;
            }

            BKExporter.RunWorkerAsync();
        }
        private void ExportarXml(string fileName)
        {
            DataSet DtSet = new DataSet();
            DtSet.Tables.Add(FTabla.Copy());
            DtSet.WriteXml(fileName);
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            FormQuery dlg = new FormQuery();
            dlg.Texto = Filtro;
            dlg.Tabla = FTabla;
            dlg.OnFiltro += new OnFiltroEvent(OnFiltro);
            dlg.Show(this);
        }
        private void OnFiltro(string filtro)
        {
            try
            {
                Filtro = filtro;
                DataTable dt;
                dt = FTabla.Clone();
                DataRow[] l = FTabla.Select(Filtro);
                foreach (DataRow dr in l)
                {
                    DataRow dr2 = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dr2[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    dt.Rows.Add(dr2);
                }
                Grid.DataSource = dt;
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GriVisor));
                if(Filtro.Trim()=="")
                {
                    this.BFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("BFiltrar.Image")));
                }
                else
                {
                    this.BFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("check")));
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BFiltoCampos_Click(object sender, EventArgs e)
        {
            if (dlgColumnas == null)
            {
                dlgColumnas = new FormColumnas();
                dlgColumnas.OnColumnasSeleccionadas += new OnFormColumnasEvent(OnFormColumnas);
                dlgColumnas.OnFormClose += new OnFormColumnasEvent(OnFormColumnasEvent);
            }
            dlgColumnas.Tabla = FTabla;
            dlgColumnas.TablasSeleccionadas = TablasSeleccionadas;
            dlgColumnas.Show(this);

        }
        public void FiltraColumnas(List<CTablaColumnas> TablasSeleccionadas)
        {
            //recorro los grids para ir riltrando los campos
            //ahora me traigo la tabla que contien el datgris para buscar la que le corresponda
            DataTable dt = (DataTable)Grid.DataSource;
            //ahora busco su tabla
            foreach (CTablaColumnas tc in TablasSeleccionadas)
            {
                if (tc.Tabla == dt.TableName)
                {
                    //ya encontre la tabla
                    //ahora recorro los campos del grid
                    foreach (DataGridViewColumn col in Grid.Columns)
                    {
                        //ahora veo si contiene el campo
                        if (tc.ExisteColumna(col.Name) == false)
                        {
                            //como no esta contemplado, lo quito
                            col.Visible = false;
                        }
                        else
                        {
                            col.Visible = true;

                        }
                    }

                }
            }
        }
        private void OnFormColumnas(FormColumnas dlg)
        {
            TablasSeleccionadas = dlg.TablasSeleccionadas;
            if (TablasSeleccionadas == null)
                return;
            FiltraColumnas(TablasSeleccionadas);
        }
        private void OnFormColumnasEvent(FormColumnas dlg)
        {
            dlgColumnas = null;
        }

        private void BCalculadora_Click(object sender, EventArgs e)
        {
            FormCalculadora dlg = new FormCalculadora();
            dlg.Tabla = FTabla;
            dlg.ShowDialog();
        }
        private void ExportaExcel(string fileName)
        {
            try
            {
                ExportadorExcel.CExportadorExcel obj = new ExportadorExcel.CExportadorExcel();
                obj.OnFinExport += new ExportadorExcel.ExportadorExcelEvent(OnFinExportExcel);
                obj.OnInicioExport += new ExportadorExcel.ExportadorExcelEvent(OnInicioExportExcel);
                obj.OnProgress += new ExportadorExcel.ExportadorExcelEvent(OnProgressExcel);
                DataSet DtSet = new DataSet();
                DataTable dt = (DataTable)Grid.DataSource;
                DtSet.Tables.Add(dt.Copy());
                obj.Exportar(DtSet, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnInicioExportExcel(int nregistros)
        {
            BKExporter.ReportProgress(nregistros, 0);
        }
        private void OnProgressExcel(int pos)
        {
            try
            {
                BKExporter.ReportProgress(pos, 1);
            }
            catch(System.Exception)
            {
                return;
            }

        }
        private void OnFinExportExcel(int fin)
        {
            BKExporter.ReportProgress(fin, 1);

        }

        private void BKExporter_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (TipoArchivo)
            {
                case ETipoArchivo.XLS:
                    ExportaExcel(FileName);
                    break;
                case ETipoArchivo.SCV:
                    ExportaCsv(FileName);
                    break;
                case ETipoArchivo.XML:
                    ExportarXml(FileName);
                    break;
            }
        }

        private void BKExporter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int estado = (int)e.UserState;
            switch (estado)
            {
                case 0: //inicio
                    BarraProgreso.Maximum = e.ProgressPercentage;
                    BarraProgreso.Value = 0;
                    break;
                case 1: //progreso
                    if (BarraProgreso.Maximum > e.ProgressPercentage)
                        BarraProgreso.Value = e.ProgressPercentage;
                    break;
                case 2: //fin
                    BarraProgreso.Value = 0;
                    break;
            }
        }

        private void BKExporter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BarraProgreso.Visible = false;
        }
        private void ExportaCsv(string fileName)
        {
            StreamWriter sw = null;
            bool abierto = false;
            try
            {
                OnInicioExportExcel(FTabla.Rows.Count);
                sw = File.CreateText(fileName);
                abierto = true;
                //primero agrego las cabeceras o nombres de los campos
                string s = "";
                foreach (DataColumn dc in FTabla.Columns)
                {
                    s = s + dc.ColumnName + ",";
                }
                sw.WriteLine(s);
                //ahora recorro todos los registros
                int pos = 0;
                foreach (DataRow dr in FTabla.Rows)
                {
                    OnProgressExcel(pos);
                    pos++;
                    s = "";
                    foreach (DataColumn dc in FTabla.Columns)
                    {
                        s += dr[dc.ColumnName].ToString() + ",";
                    }
                    sw.WriteLine(s);
                }
                sw.Close();
                OnFinExportExcel(0);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (abierto)
                    sw.Close();
                return;
            }
        }
        public bool AllowUserToOrderColumns
        {
            get
            {
                return Grid.AllowUserToOrderColumns;
            }
            set
            {
                Grid.AllowUserToOrderColumns = value;
            }
        }

        private void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int nreg = 1;
            foreach (DataGridViewRow r in Grid.Rows)
            {
                r.HeaderCell.Value = nreg.ToString();
                nreg++;
            }

        }

        private void sIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            LCopiar.Text = "Incluir columnas al compiar";
        }

        private void nOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            LCopiar.Text = "NO Incluir columnas al compiar";
        }

    }
}
