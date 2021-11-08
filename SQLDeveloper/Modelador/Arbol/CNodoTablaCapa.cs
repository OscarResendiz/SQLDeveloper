using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
using ManagerConnect;

namespace Modelador.Arbol
{
    public class CNodoTablaCapa:CNodoTabla
    {
        public int ID_Capa
        {
            get;
            set;
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.OnCapaTablaDelete += new Modelo.DelegateModeloDatosEvent2(CapaTablaDelete);
        }
        private void CapaTablaDelete(Modelo.ModeloDatos modelo, int id_Capa,int id_tabla)
        {
            if(ID_Capa==id_Capa && ID_Tabla==id_tabla)
            {
                Remove();
            }
        }
        protected override void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea quitar la tabla: " + Nombre +" de la capa", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                Modelo.Delete_TablaCapa(ID_Capa, ID_Tabla);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override Modelo.CTabla GetTabla()
        {
            return Modelo.Get_TablaCapa(ID_Capa,ID_Tabla);
        }
        private void MenuVisible_Click(object sender, EventArgs arg)
        {
            Modelo.CTabla tabla = Modelo.Get_TablaCapa(ID_Capa, ID_Tabla);
            Modelo.Update_TablaCapa(ID_Capa, ID_Tabla, tabla.X, tabla.Y, !tabla.Visible);
            //            tabla.Visible = !tabla.Visible;
            //          tabla.Update();
        }
        protected override void InicializaMenu()
        {
            AddMenuItem("Ocultar/Mostrar", "ojo2", MenuVisible_Click);            
            base.InicializaMenu();
            DeleteMenuItem("Eliminar");
            AddMenuItem("Quitar de la capa", "Eliminar", MenuEliminar_Click);
        }

    }
}
