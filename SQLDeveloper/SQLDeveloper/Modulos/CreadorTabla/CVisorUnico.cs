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
    public partial class CVisorUnico : CVisorBase
    {
        CUnique Unico;
        public CVisorUnico(CUnique u)
        {
            Unico = u;
            InitializeComponent();
        }

        private void CVisorUnico_Load(object sender, EventArgs e)
        {
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            //me traigo el objeto seleccionado
            //recorro los campos que lo componene
            foreach (MotorDB.CCampoBase cb in Unico.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["Campo"] = cb.Nombre;
                dr["Tipo"] = cb.GetTipoString();
                dt.Rows.Add(dr);
            }

        }
    }
}
