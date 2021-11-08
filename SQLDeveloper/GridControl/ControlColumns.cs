using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridControl
{
    public partial class ControlColumns : UserControl
    {
        private DataTable FTabla;
        private DataTable TablaColumnas;
        public ControlColumns()
        {
            InitializeComponent();
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
                InicializaColumnas();
            }
        }
        public string TableName
        {
            get
            {
                return LTabla.Text;
            }
        }
        private void InicializaColumnas()
        {
            if (FTabla == null)
                return;
            //ahora creo una tabla que va a tener todos los nombres de los campos
            //pero van a ser booleanos
            TablaColumnas = new DataTable();
            foreach(DataColumn col in FTabla.Columns)
            {
                DataColumn col2 = new DataColumn(col.ColumnName, typeof(Boolean));
                TablaColumnas.Columns.Add(col2);
            }
            //agrego el registro
            DataRow dr = TablaColumnas.NewRow();
            foreach (DataColumn col in TablaColumnas.Columns)
            {
                dr[col.ColumnName] = true;
            }
            TablaColumnas.Rows.Add(dr);
            Grid.DataSource = TablaColumnas;
            LTabla.Text = FTabla.TableName;
        }
        public CTablaColumnas Columnas
        {
            get
            {
                //regresa la lista de las columnas
                CTablaColumnas obj = new CTablaColumnas();
                obj.Tabla = LTabla.Text;
                //me traigo el unico registro que contiene la tabla
                DataRow dr = TablaColumnas.Rows[0];
                //ahora recorro todas las columnas para veridficar cuales estan seleccionadas
                foreach (DataColumn col in TablaColumnas.Columns)
                {
                    if((Boolean)dr[col.ColumnName]==true)
                    {
                        //lo agrego
                        obj.Columnas.Add(col.ColumnName);
                    }
                }

                return obj;
            }
            set
            {
                //marca como seleccionadas las columnas
                if (value == null)
                    return;
                CTablaColumnas obj = value;
                //me traigo el unico registro que contiene la tabla
                DataRow dr = TablaColumnas.Rows[0];
                //recorro los campos de la tabla
                foreach (DataColumn col in TablaColumnas.Columns)
                {
                    bool encontrado = false;
                    foreach (string sc in obj.Columnas)
                    {
                        if (sc== col.ColumnName)
                        {
                            dr[col.ColumnName] = true;
                            encontrado = true;
                            break;
                        }
                    }
                    if(encontrado==false)
                    {
                        dr[col.ColumnName] = false;
                    }
                }
            }
        }
    }
}
