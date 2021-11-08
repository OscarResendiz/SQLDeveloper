using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoGroupCodigoEditable : CNodoFolder
    {
        public CNodoGroupCodigoEditable(int id_Objeto)
        {
            this.ID_Objeto = id_Objeto;
            Nombre = "Codigo Editable";
        }
        public override void ModeloAsignado()
        {
            Modelo.CodigoEditableInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(CodigoEditableInsert);
            Modelo.CodigoEditableDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(CodigoEditableDelete);
            //CargaObjetos();
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaObjetos();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.CodigoEditableInsertEvent -= CodigoEditableInsert;
            Modelo.CodigoEditableDeleteEvent -= CodigoEditableDelete;
        }
        private void CargaObjetos()
        {
            List<ObjetosModelo.CCodigoEditable> l = Modelo.GetCodigoEditables(this.ID_Objeto);
            foreach(ObjetosModelo.CCodigoEditable obj in l)
            {
                CNodoCodigoEditable nodo = new CNodoCodigoEditable(obj.ID_CodigoEditable);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }
        }
        private void CodigoEditableInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCodigoEditable objeto = (ObjetosModelo.CCodigoEditable)obj;
            if (objeto.ID_Objeto == this.ID_Objeto)
            {
                foreach (CNodoBase n in Nodes)
                {
                    if (n.GetType() == typeof(CNodoCodigoEditable))
                    {
                        CNodoCodigoEditable n2 = (CNodoCodigoEditable)n;
                        if (n2.ID_CodigoEditable == objeto.ID_CodigoEditable)
                           return;
                    }
                }
                CNodoCodigoEditable nodo = new CNodoCodigoEditable(objeto.ID_CodigoEditable);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }
        }
        private void CodigoEditableDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCodigoEditable objeto = (ObjetosModelo.CCodigoEditable)obj;
            if (objeto.ID_Objeto != this.ID_Objeto)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoCodigoEditable))
                {
                    if (nodo.ID_Objeto == objeto.ID_CodigoEditable)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }

        }
    }
}
   