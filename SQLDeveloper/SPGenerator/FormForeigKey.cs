using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace SPGenerator
{
    public partial class FormForeigKey : Form
    {
        IMotorDB DB;
        public FormForeigKey(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }

        private void FormForeigKey_Load(object sender, EventArgs e)
        {

        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
                List<CCampoFK> lista=DB.DameLLaveForanea(value);
                TablaPadre = lista[0].maestra;
                muestraCampos(lista);
            }
        }
        private string TablaPadre
        {
            get
            {
                return TTablaPadre.Text;
            }
            set
            {
                TTablaPadre.Text = value;
            }
        }
        public bool GenerarExcepcion
        {
            get
            {
                return CHExcepdion.Checked;
            }
            set
            {
                CHExcepdion.Checked = value;
            }
        }
        public string Excepcion
        {
            get
            {
                return TExcepcion.Text;
            }
            set
            {
                TExcepcion.Text = value;
            }
        }
        public string Docuemntacion
        {
            get
            {
                return TComentarios.Text;
            }
            set
            {
                TComentarios.Text = value;
            }
        }
        private void muestraCampos(List<CCampoFK> lista)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Tabla");
            //Creando las columnas y agregando los items a la tabla
            DataColumn dccolumnaMaestra = new DataColumn("columnaMaestra");
            DataColumn dccolumnahija = new DataColumn("columnahija");
            //Asignando los campos ala tabla
            dt.Columns.Add(dccolumnaMaestra);
            dt.Columns.Add(dccolumnahija);
            //agregarndo la tabla al data set
            ds.Tables.Add(dt);
            //llenando la tabla con datos
            int i, n;
            n = lista.Count;
            for (i = 0; i < n; i++)
            {
                CCampoFK dato = (CCampoFK)lista[i];
                DataRow drRow = dt.NewRow();
                drRow["columnaMaestra"] = dato.columnaMaestra;
                drRow["columnahija"] = dato.columnahija;
                dt.Rows.Add(drRow);
            }
//            dataGrid1.DataSource = ds.Tables[0];
//            DataGridTableStyle ts = new DataGridTableStyle();
  //          ts.AllowSorting = false;
    //        ts.MappingName = "Tabla";
            //creando las columnas que se van a ver
            //------------------Columna padre---------------------------------------- 
//            DataGridColumnStyle columnaMaestra = new DataGridTextBoxColumn();
  //          columnaMaestra.MappingName = "columnaMaestra";
    //        columnaMaestra.HeaderText = "Columna padre";
      //      columnaMaestra.Width = 100;
        //    columnaMaestra.ReadOnly = true;
          //  ts.GridColumnStyles.Add(columnaMaestra);
            //------------------Columna hija---------------------------------------- 
//            DataGridColumnStyle columnahija = new DataGridTextBoxColumn();
  //          columnahija.MappingName = "columnahija";
    //        columnahija.HeaderText = "Columna hija";
      //      columnahija.Width = 100;
        //    columnahija.ReadOnly = true;
          //  ts.GridColumnStyles.Add(columnahija);
            //finalizando la creacion del data grid
//            ts.MappingName = "Tabla";
  //          dataGrid1.TableStyles.Clear();
    //        dataGrid1.TableStyles.Add(ts);
      //      dataGrid1.AllowSorting = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (CHExcepdion.Checked == true)
            {
                if (TExcepcion.Text.Trim() == "")
                    ok = false;
            }
            BAceptar.Enabled = ok;
        } 

    }
}