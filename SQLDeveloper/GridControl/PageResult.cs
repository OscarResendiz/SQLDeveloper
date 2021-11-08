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
    public delegate void OnMessageEvent(string mensaje);
    public partial class PageResult : UserControl
    {
        public event OnMessageEvent OnMessage;
        private System.Windows.Forms.TabControl Contenedor;
        private DataSet DtSet;
        ListBox Lista;
        public PageResult()
        {
            InitializeComponent();
            Lista = null;
        }
        private void IniciaContendor()
        {
            Controls.Clear();
            this.Contenedor = new System.Windows.Forms.TabControl();
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.SelectedIndex = 0;
            this.Contenedor.Size = new System.Drawing.Size(418, 197);
            this.Contenedor.TabIndex = 0;
            this.Controls.Add(this.Contenedor);
        }
        public DataSet DataSet
        {
            get
            {
                return DtSet;
            }
            set
            {
                DtSet = value;
                IniciaContendor();
                if (DtSet == null)
                {
                    return;
                }
                //recorro todas las tablas
                foreach (DataTable dt in DtSet.Tables)
                {
                    AgregaTabla(dt);
                }
            }
        }
        private void AgregaTabla(DataTable dt)
        {
            GriVisor visor = new GriVisor();
            visor.Tabla = dt;
            visor.Dock = DockStyle.Fill;
            TabPage tab = new TabPage(dt.TableName);
            tab.Controls.Add(visor);
            Contenedor.TabPages.Add(tab);
        }
        public void SetMensaje(List<string> l)
        {
            this.Controls.Clear();
            Lista = new ListBox();
            Lista.Dock = DockStyle.Fill;
            foreach (string s in l)
            {
                Lista.Items.Add(s);
            }
            Lista.ContextMenuStrip = contextMenuStrip1;
            Lista.MouseDoubleClick += new MouseEventHandler(Lista_MouseDoubleClick);
            Controls.Add(Lista);
        }
        private void PageResult_Load(object sender, EventArgs e)
        {

        }
        public void Recargar()
        {
            DataSet = DtSet;
        }
        public void Exportar()
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            switch (saveFileDialog1.FilterIndex)
            {
                case 1:
                    ExportaExcel(saveFileDialog1.FileName);
                    break;
                case 2:
                    ExportaCsv(saveFileDialog1.FileName);
                    break;
                case 3:
                    ExportarXml(saveFileDialog1.FileName);
                    break;
            }
        }
        private void ExportaCsv(string fileName)
        {
            StreamWriter sw = null;
            bool abierto = false;
            try
            {
                sw = File.CreateText(fileName);
                abierto = true;
                foreach (DataTable dt in DtSet.Tables)
                {
                    //primero agrego las cabeceras o nombres de los campos
                    string s = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        s = s + dc.ColumnName + ",";
                    }
                    sw.WriteLine(s);
                    //ahora recorro todos los registros
                    foreach (DataRow dr in dt.Rows)
                    {
                        s = "";
                        foreach (DataColumn dc in dt.Columns)
                        {
                            s += dr[dc.ColumnName].ToString() + ",";
                        }
                        sw.WriteLine(s);
                    }
                }
                sw.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (abierto)
                    sw.Close();
                return;
            }
        }
        private void ExportaExcel(string fileName)
        {
            try
            {
                ExportadorExcel.CExportadorExcel obj = new ExportadorExcel.CExportadorExcel();
                obj.Exportar(DtSet, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportarXml(string fileName)
        {
            DtSet.WriteXml(fileName);
        }
        public void FiltraColumnas(List<CTablaColumnas> TablasSeleccionadas)
        {
            //recorro los grids para ir riltrando los campos
            foreach (DataGridView grid in Controls)
            {
                //ahora me traigo la tabla que contien el datgris para buscar la que le corresponda
                DataTable dt = (DataTable)grid.DataSource;
                //ahora busco su tabla
                foreach (CTablaColumnas tc in TablasSeleccionadas)
                {
                    if (tc.Tabla == dt.TableName)
                    {
                        //ya encontre la tabla
                        //ahora recorro los campos del grid
                        foreach (DataGridViewColumn col in grid.Columns)
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
        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedIndex == -1)
                return;
            string s = lb.SelectedItem.ToString();
            if (OnMessage != null)
                OnMessage(s);
        }

        private void verMensajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Lista == null)
                return;
            if (Lista.SelectedIndex == -1)
                return;
            FormDetalleMensaje dlg = new FormDetalleMensaje();
            dlg.Texto = Lista.SelectedItem.ToString();
            dlg.ShowDialog();
        }

    }
}