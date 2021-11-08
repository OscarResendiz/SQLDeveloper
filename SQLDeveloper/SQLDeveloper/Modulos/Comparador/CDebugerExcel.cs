using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using ICSharpCode.TextEditor.Document;
using System.Windows.Forms;
using System.IO;


namespace SQLDeveloper.Modulos.Comparador
{
    public partial class CDebugerExcel : Component
    {
        public bool Enabled
        {
            get;
            set;
        }
        List<DataTable> Tablas;
        public CDebugerExcel()
        {
            Tablas = new List<DataTable>();
            NombreArchivo = "Debug";
            InitializeComponent();
        }

        public CDebugerExcel(IContainer container)
        {
            Tablas = new List<DataTable>();
            container.Add(this);
            InitializeComponent();
        }
        private bool ExisteTabla(string nombre)
        {
            if (Tablas == null)
                Tablas = new List<DataTable>();
            foreach (DataTable obj in Tablas)
            {
                if (obj.TableName == nombre)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddTable(DataTable tabla, string NombreTabla)
        {
            if (Enabled == false)
                return;
            string nombre;
            int conteo = 0;
            do
            {
                if (conteo == 0)
                {
                    nombre = NombreTabla;
                }
                else
                {
                    nombre = NombreTabla + conteo.ToString();
                }
                if (ExisteTabla(nombre) == false)
                {
                    break;
                }
                conteo++;
            } while (true);
            //ya tengo el nobre unico para exportarlo
            DataTable dt = tabla.Copy();
            dt.TableName = nombre;
            Tablas.Add(dt);
        }
        public string NombreArchivo
        {
            get;
            set;
        }
        public void Exportar()
        {
            if (Enabled == false)
                return;
            
            try
            {
                ExportadorExcel.CExportadorExcel obj = new ExportadorExcel.CExportadorExcel();
//                obj.OnFinExport += new ExportadorExcel.ExportadorExcelEvent(OnFinExportExcel);
  //              obj.OnInicioExport += new ExportadorExcel.ExportadorExcelEvent(OnInicioExportExcel);
    //            obj.OnProgress += new ExportadorExcel.ExportadorExcelEvent(OnProgressExcel);
                DataSet DtSet = new DataSet();
                foreach(DataTable dt in Tablas)
                {
                    DtSet.Tables.Add(dt);
                }

                obj.Exportar(DtSet, Application.StartupPath + "\\" + NombreArchivo + ".xls");
            }
            catch (System.Exception ex)
            {
               // MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
