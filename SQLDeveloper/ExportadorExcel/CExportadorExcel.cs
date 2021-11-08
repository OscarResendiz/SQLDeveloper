using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
namespace ExportadorExcel
{
    public delegate void ExportadorExcelEvent(int n);
    public class CExportadorExcel
    {
        public event ExportadorExcelEvent OnInicioExport;
        public event ExportadorExcelEvent OnProgress;
        public event ExportadorExcelEvent OnFinExport;
        private Microsoft.Office.Interop.Excel.Application Excel;
        private Workbook Libro;
        private Worksheet HojaActual;
        private int NHoja;
        public void Exportar(DataSet DtSet)
        {
            NHoja = 1;
            Excel = new Microsoft.Office.Interop.Excel.Application();
            if (Excel == null)
            {
                throw new Exception("No se puede inicializar Excel");
            }
            Excel.Visible = false;
            //agrega un nuevo libro
            Libro = Excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //recorro cada tabla

            foreach (System.Data.DataTable dt in DtSet.Tables)
            {
                ExportaTabla(dt);
            }
            Excel.Visible = true;
        }
        public void Exportar(DataSet DtSet, string fileName)
        {
            NHoja = 1;
            Excel = new Microsoft.Office.Interop.Excel.Application();
            if (Excel == null)
            {
                throw new Exception("No se puede inicializar Excel");
            }
            Excel.Visible = false;
            //agrega un nuevo libro
            Libro = Excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //recorro cada tabla

            foreach (System.Data.DataTable dt in DtSet.Tables)
            {
                ExportaTabla(dt);
            }
            Excel.Visible = true;
            Libro.SaveAs(ValidaExtencion(fileName));
            //se trae la primer hoja
            //            HojaActual = (Worksheet)Libro[1];
        }
        private string ValidaExtencion(string fileName)
        {
            if (fileName.Contains("."))
                return fileName;
            return fileName + ".xlsx";
        }
        private Worksheet DameHoja()
        {
            //regresa la siguiente hoja
            //si no existe, la agrega al libro
            Worksheet ws = null;
            if (Libro.Worksheets.Count < NHoja)
            {
                //agrego la siguiente hoja
                //                ws = (Worksheet)Excel.ThisWorkbook.Worksheets.Add();
                ws = (Worksheet)Libro.Worksheets.Add();
            }
            else
            {
                ws = (Worksheet)Libro.Worksheets[NHoja];
            }
            NHoja++;
            return ws;
        }
        private string DameLetra(int pos)
        {
            if (pos == 0)
                return "Z";
            int ascii = 64 + pos;
            string letra = Convert.ToChar(ascii).ToString();
            return letra.Trim();
        }
        private string CalculaLetraCelda(int x)
        {
            string s = "";
            int factor = 26;
            int tmp = x;
            while (tmp > 26)
            {
                int tmp2 = tmp / factor;
                int tmp3 = tmp - (tmp2 * factor);
                s = DameLetra(tmp3) + s;
                if (tmp3 == 0)
                    tmp = tmp2 - 1;
                else
                    tmp = tmp2;
            }
            if (tmp > 0)
            {
                s = DameLetra(tmp) + s;
            }
            return s;
        }
        private void EscribeCelda(int x, int y, string texto)
        {
            string s = CalculaLetraCelda(x).Trim() + y.ToString().Trim();
            Range aRange = HojaActual.get_Range(s, s);
            aRange.Value2 = texto;// +"->" + s;
        }
        private void EscribeRegistro(System.Data.DataRow dr,int ncolumnas, int y)
        {
            //int x = 1;
            //foreach (System.Data.DataColumn dc in dr.Table.Columns)
            for (int x = 1; x <= ncolumnas;x++ )
            {
                EscribeCelda(x, y, dr[x-1].ToString());
            }
        }
        private void ExportaTabla(System.Data.DataTable dt)
        {
            //me traigo la hoja actual
            int x;
            int y;
            int ncolumnas;
            HojaActual = DameHoja();
            HojaActual.Name = dt.TableName;
            //recorro los campos para agregar los nombres en la hoja
            x = 1;
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                EscribeCelda(x, 1, dc.ColumnName);
                x++;
            }
            //ahora recorro todos los registros
            y = 2;
            if (OnInicioExport != null)
                OnInicioExport(dt.Rows.Count);
            /*
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                nreg++;
                Task t = Task.Factory.StartNew(() => EscribeRegistro(dr, nreg, y));
                y++;
            }
             * */
            ncolumnas = dt.Columns.Count;
            Dictionary<int, DataRow> l = new Dictionary<int, DataRow>();
            //List<DataRow> l=new List<DataRow>();
            y = 2;
            foreach(DataRow dr in dt.Rows)
            {
                l.Add(y, dr);
                y++;
            }
            y = 2;
            Parallel.ForEach(l, (obj) =>
                {
                    if (OnProgress != null)
                        OnProgress(y);
                    EscribeRegistro(obj.Value,ncolumnas, obj.Key);
                    y++;

                }
                );
            

            if (OnFinExport != null)
                OnFinExport(0);
        }

    }
}
