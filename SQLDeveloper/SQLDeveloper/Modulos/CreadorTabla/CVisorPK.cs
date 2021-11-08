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
    public partial class CVisorPK : CVisorBase
    {

        CPrimaryKey Pk;
        public CVisorPK(CPrimaryKey pk)
        {
            Pk = pk;
            InitializeComponent();
        }

        private void CVisorFK_Load(object sender, EventArgs e)
        {
            //me traigo la tabla
            DataTable dt = dataSet1.Tables["Campos"];
            //limpio la tabla
            dt.Rows.Clear();
            //recorro todos los campos que pertenecen a la llave primaria
            foreach(CCampoBase obj in Pk.Campos)
            {
                //agrego el registro
                DataRow dr = dt.NewRow();
                dr["Campo"] = obj.Nombre;
                dr["Tipo"] = obj.GetTipoString();
                dt.Rows.Add(dr);
            }
        }
    }
}
