using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoHistorial : CNodoBase
    {
        public CNodoHistorial(int id_objeto)
        {
            ImageIndex = 24;
            SelectedImageIndex = 24;
            this.ID_Objeto = id_objeto;
            Nombre = "Historial";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.CodigoObjetoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(CodigoObjetoInsert);
            Modelo.CodigoObjetoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(CodigoObjetoDelete);
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                //agrego los nodos del historial
                List<ObjetosModelo.CCodigoObjeto> l = Modelo.GetCodigoObjetos(this.ID_Objeto);
                foreach (ObjetosModelo.CCodigoObjeto obj in l)
                {
                    CNodoCodigoObjeto nodo = new CNodoCodigoObjeto(obj.ID_Codigo);
                    nodo.Modelo = Modelo;
                    Nodes.Add(nodo);
                }
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.CodigoObjetoInsertEvent -= CodigoObjetoInsert;
            Modelo.CodigoObjetoDeleteEvent -= CodigoObjetoDelete;
        }
        private void CodigoObjetoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCodigoObjeto objeto = (ObjetosModelo.CCodigoObjeto)obj;
            if (this.ID_Objeto != objeto.ID_Objeto)
                return;
            //veo si ya existe
            foreach(CNodoBase n in Nodes)
            {
                if(n.ID_Objeto==obj.IdObjeto)
                {
                    return;
                }
            }
            CNodoCodigoObjeto nodo = new CNodoCodigoObjeto(obj.IdObjeto);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
        private void CodigoObjetoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CCodigoObjeto objeto = (ObjetosModelo.CCodigoObjeto)obj;
            if (this.ID_Objeto != objeto.ID_Objeto)
                return;
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoCodigoObjeto))
                {
                    if (nodo.ID_Objeto == objeto.ID_Codigo)
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
   