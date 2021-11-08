using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Variables
{
    public partial class PropiedadesTabla : UserControl
    {
        public PropiedadesTabla()
        {
            InitializeComponent();
        }
        public CDefinicionTabla Tabla
        {
            set
            {
                if (value == null)
                    return;
                TNombre.Text = value.Nombre;
                List<CDefinicionCampo> campos = value.DameCampos();
                DataTable dt = new DataTable();
                dt.Columns.Add("Campo");
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Acepta Nulos");
                dt.Columns.Add("PK");
                foreach(CDefinicionCampo obj in campos)
                {
                    DataRow dr = dt.NewRow();
                    dr["Campo"] = obj.Nombre;
                    string tipo=obj.Tipo;
                    if(obj.Longitud.Trim()!="")
                        tipo+="("+obj.Longitud+")";
                    dr["Tipo"] = tipo;
                    dr["Acepta Nulos"] = obj.AceptaNulos;
                    dr["PK"] = obj.PrimaryKey;
                    dt.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
}
