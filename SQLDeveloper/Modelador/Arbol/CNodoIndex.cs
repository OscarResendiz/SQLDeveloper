using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelador.UI;


namespace Modelador.Arbol
{
    public class CNodoIndex : CNodoBase
    {
        public int ID_Index
        {
            get;
            set;
        }
        public Modelo.CIndexX GetIndex()
        {
            return Modelo.Get_Index(ID_Index);
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Nombre = GetIndex().Nombre;
            CargaCampos();
            Modelo.OnCampoIndexInsert += new DelegateModeloDatosEvent2(CampoIndexInsert);
            Modelo.OnIndexDelete += new DelegateModeloDatosEvent(IndexDelete);
        }
        private void IndexDelete(ModeloDatos modelo, int id_Index)
        {
            if (ID_Index == id_Index)
            {
                Free();
                Remove();
            }

        }
        public override void Free()
        {
            Modelo.OnCampoIndexInsert -= CampoIndexInsert;
            Modelo.OnIndexDelete -= IndexDelete;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuSeparator();
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }

        private void CargaCampos()
        {
            List<CCampoIndex> l = GetIndex().Get_CamposIndex();
            foreach (CCampoIndex obj in l)
            {
                CNodoCampoIndex nodo = new CNodoCampoIndex();
                nodo.ID_Index = ID_Index;
                nodo.ID_Campo = obj.ID_Campo;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void CampoIndexInsert(ModeloDatos modelo, int id_index, int id_campo)
        {
            if (ID_Index == id_index)
            {
                CNodoCampoIndex nodo = new CNodoCampoIndex();
                nodo.ID_Index = ID_Index;
                nodo.ID_Campo = id_campo;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar el Indice " + Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                GetIndex().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<CCampoIndex> camposIndex;
        //private List<CCampo> Campos;
        private List<CCampo> CamposSeleccionados;
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            CIndexX index = GetIndex();
            CTabla tabla = Modelo.Get_Tabla(index.ID_Tabla);
            FormPropiedadesIndex dlg = new FormPropiedadesIndex();
            dlg.Nombre = index.Nombre;
            dlg.GenerarFuncion = index.GenerarFuncionX;
            dlg.MultiplesObjetos = index.MultiplesObjetos;
            dlg.OnCampoIndex += new OnFormPropiedadesCampoIndexEvent(CampoSeleccionado);
            dlg.OnIndex += new OnFormPropiedadesIndexEvent(IndiceSeleccionado);
            dlg.OnFinIndex += new OnFormPropiedadesIndexEvent(FinIndiceSeleccionado);
            List<CCampo>  Campos = tabla.Get_Campos();
            CamposSeleccionados = new List<CCampo>();
            foreach (CCampo campo in Campos)
            {
                dlg.AddCampoTabla(campo.Nombre);
            }
            camposIndex = index.Get_CamposIndex();
            foreach(CCampoIndex campo in camposIndex)
            {
                dlg.AddCampoIndex(campo.Get_Campo().Nombre, campo.Descendente);
            }
            dlg.ShowDialog();

        }
        private void CampoSeleccionado(string NomCampo, bool descendente)
        {
            try
            {
                CIndexX index = GetIndex();
                CTabla tabla = Modelo.Get_Tabla(index.ID_Tabla);
                List<CCampo> camposTabla = tabla.Get_Campos();
                //primero veo si ya existe en los campos seleccionados
                foreach (CCampoIndex campo in camposIndex)
                {
                    CCampo campo2 = campo.Get_Campo();
                    if (campo2.Nombre == NomCampo)
                    {
                        CamposSeleccionados.Add(campo2);
                        camposIndex.Remove(campo);
                        return;
                    }
                }
                //ahora checo si esta en la tabla
                foreach (CCampo campo in camposTabla)
                {
                    if (campo.Nombre == NomCampo)
                    {
                        index.Insert_Campo(campo.ID_Campo, descendente);
                        CamposSeleccionados.Add(campo);
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void IndiceSeleccionado(string nombre, bool pk, bool generarFuncion,bool MultiplesObjetos)
        {
            try
            {
                CIndexX index = GetIndex();
                index.Nombre = nombre;
                index.GenerarFuncionX = generarFuncion;
                index.MultiplesObjetos = MultiplesObjetos;
                index.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FinIndiceSeleccionado(string nombre, bool pk, bool generarFuncion, bool MultiplesObjetos)
        {
            CIndexX index = GetIndex();
            //elimino los campos sobrantes
            foreach (CCampoIndex campo in camposIndex)
            {
                index.Delete_Campo(campo.ID_Campo);
            }
        }
    }
}
