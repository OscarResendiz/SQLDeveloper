using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class CVisorFk : CVisorBase
    {
        CTabla Tabla;
        CForeignKey Fk;

        public CVisorFk(CTabla tabla, CForeignKey fk)
        {
            Tabla = tabla;
            //Tabla = DBProvider.DB.DameTabla(nombreTabla);
            Fk = fk;
            InitializeComponent();
        }

        private void CVisorFk_Load(object sender, EventArgs e)
        {
            TNombre.Text = Fk.Nombre;
            TBorrar.Text = Fk.AccionBorrar.ToString();
            TActualizar.Text = Fk.AccionActualizar.ToString();
            dataGridView1.Columns[0].HeaderText = Fk.TablaPadre;
            dataGridView1.Columns[1].HeaderText = Fk.TablaHija;
            TTablaPadre.Text = Fk.TablaPadre;
            //me traigo la tabla que muestra los datos en la pantalla
            DataTable dt = dataSet1.Tables["Columnas"];
            //recoor los campos de la llave foranea
            foreach (MotorDB.CCampoFereneces obj in Fk.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["ColumnaPadre"] = obj.CampoPadre;
                dr["ColumnaHija"] = obj.CampoHijo;
                dt.Rows.Add(dr);
            }
        }
    }
}
