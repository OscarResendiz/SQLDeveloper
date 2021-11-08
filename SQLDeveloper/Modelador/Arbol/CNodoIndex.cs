using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Arbol
{
    public class CNodoIndex: CNodoBase
    {
        public int ID_Index
        {
            get;
            set;
        }
        public Modelo.CIndex GetIndex()
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
            if(ID_Index==id_Index)
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
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }

        private void CargaCampos()
        {
            List<CCampoIndex> l = GetIndex().Get_CamposIndex();
                foreach(CCampoIndex obj in l)
            {
                CNodoCampoIndex nodo = new CNodoCampoIndex();
                nodo.ID_Index = ID_Index;
                nodo.ID_Campo = obj.ID_Campo;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void CampoIndexInsert(ModeloDatos modelo,int id_index, int id_campo)
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

    }
}
