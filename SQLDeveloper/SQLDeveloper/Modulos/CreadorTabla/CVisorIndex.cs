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
    public partial class CVisorIndex : CVisorBase
    {
        Cindex Index;
        public CVisorIndex(Cindex i)
        {
            Index = i;
            InitializeComponent();
        }

        private void CVisorIndex_Load(object sender, EventArgs e)
        {
            //limpio el datagrid
            DataTable table = dataSet1.Tables["Campos"];
            table.Rows.Clear();
            //me traigo el nombre indice
            //muestro los datos en el grid
            foreach (MotorDB.CCampoIndex obj in Index.Campos)
            {
                //creo un nuevo registro
                DataRow dr = table.NewRow();
                //lleno los datos de registro
                dr["Campo"] = obj.Nombre;
                dr["Tipo"] = obj.GetTipoString();
                dr["Ordenamiento"] = obj.Ordenamiento;
                table.Rows.Add(dr);
            }
        }
    }
}
