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
    public partial class CVisorCampo : CreadorTabla.CVisorBase
    {
        CCampo Campo;
        CTabla Tabla;
        public CVisorCampo(CTabla tabla, CCampo campo)
        {
            Tabla = tabla;
            Campo = campo;
            InitializeComponent();
        }

        private void CVisorCampo_Load(object sender, EventArgs e)
        {
            //me traigo la columna a la que se hace referencia
            string nombre = "";
            //mando a mostrar las propiedades del campo seleccionado
            CpropiedadesCampo propiedades = new CpropiedadesCampo(Campo, Tabla.Identidad);
            if (Tabla.EsPrimaryKey(Campo))
            {
                propiedades.SetPrimaryKey(Tabla.PrimaryKey);
            }
            propertyGrid1.SelectedObject = propiedades;

        }
    }
}
