using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Modelador.Arbol
{
    public class CNodoCampos: CNodoFolder
    {
        public int ID_Tabla
        {
            get;
            set;
        }
        public CNodoCampos()
        {
            Nombre = "Campos";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.OnCampoInsert += new DelegateModeloDatosEvent(CampoInsert);
            CargaCampos();
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnCampoInsert -= CampoInsert;

        }
        private void CampoInsert(ModeloDatos modelo, int ID_Campo)
        {
            CCampo campo = Modelo.Get_Campo(ID_Campo);
            if (campo.ID_Tabla == ID_Tabla)
            {
                CNodoCampo nodo = new CNodoCampo();
                nodo.ID_Campo = campo.ID_Campo;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void CargaCampos()
        {
            List<CCampo> campos = GetTabla().Get_Campos();
            foreach (CCampo campo in campos)
            {
                CNodoCampo nodo = new CNodoCampo();
                nodo.ID_Campo = campo.ID_Campo;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        public CTabla GetTabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar Campo", "IconoAgregar", MenuAgregarCampo_Click);
        }
        private void MenuAgregarCampo_Click(object sender, EventArgs e)
        {
            try
            {
                FormPropiedadesCampo dlg = new FormPropiedadesCampo(Modelo);
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                CTabla tabla = GetTabla();
                tabla.Insert_Campo(dlg.NombreX, dlg.ID_TipoDato, dlg.Longitud, dlg.PK, dlg.AceptaNulos, dlg.CampoCalculado, dlg.Formula, dlg.EsDefault, dlg.DefaultName,dlg.Comentarios);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
