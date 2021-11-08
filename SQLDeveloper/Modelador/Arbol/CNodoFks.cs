using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Arbol
{
    public class CNodoFks: CNodoFolder
    {
        public int ID_Tabla
        {
            get;
            set;
        }

        public CNodoFks()
        {
            Nombre = "Llaves Foraneas";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.OnLlaveForaneaInsert += new Modelo.DelegateModeloDatosEvent(LlaveForaneaInsert);
            CargaFks();
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnLlaveForaneaInsert -= LlaveForaneaInsert;
        }
        public CTabla GetTabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar LLave Foranea", "IconoAgregar", MenuAgregarFk_Click);
        }
        private void CargaFks()
        {
           foreach(CLlaveForanea fk in Modelo.Get_LlavesForaneasHijas(ID_Tabla))
            {
                CNodoFk nodo = new CNodoFk();
                nodo.ID_FK = fk.ID_FK;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }

        }
        private void LlaveForaneaInsert(ModeloDatos modelo, int ID_fk)
        {
            CLlaveForanea obj = Modelo.Get_LlaveForanea(ID_fk);
            if (obj.ID_TablaHija == ID_Tabla)
            {
                CNodoFk nodo = new CNodoFk();
                nodo.ID_FK = ID_fk;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void MenuAgregarFk_Click(object sender, EventArgs arg)
        {
            try
            {
                FormPropiedadesFK dlg = new FormPropiedadesFK();
                dlg.ID_TablaHija = this.ID_Tabla;
                dlg.Modelo = Modelo;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modelo.CTabla tablaPadre = dlg.TablaPadre;
                List<CCampoProFk> l = dlg.Get_Campos();
                int ID_fk = Modelo.Insert_LlaveForanea(tablaPadre.ID_Tabla, ID_Tabla, dlg.Nombre,dlg.AcctionDelete,dlg.AcctionUpdate, dlg.LineColor);
                foreach (CCampoProFk obj in l)
                {
                    Modelo.Insert_CampoReferencia(ID_fk, obj.ID_CampoPadre, obj.ID_CampoHijo);
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
