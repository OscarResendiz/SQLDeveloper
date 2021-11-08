using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoConexion : CNodoBase
    {
        public int ID_Conexion
        {
            get
            {
                return ID_Objeto;
            }
            set
            {
                ID_Objeto = value;
            }
        }
        public CNodoConexion(int id_conexion)
        {
            ID_Conexion = id_conexion;
        }
        public override void ModeloAsignado()
        {
            ObjetosModelo.CConexion obj = Modelo.GetConexion(ID_Conexion);
            Nombre = obj.Nombre;
            Modelo.ObjetoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoInsert);
            Modelo.ObjetoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoDelete);
            //CargaObjetos();
        }
        public override void Free()
        {
            base.Free();
            Modelo.ObjetoInsertEvent -= ObjetoInsert;
            Modelo.ObjetoDeleteEvent -= ObjetoDelete;
        }
        private void CargaObjetos()
        {
            List<ObjetosModelo.CObjeto> l = Modelo.GetObjetos(this.ID_Conexion);
            foreach(ObjetosModelo.CObjeto obj in l)
            {
                CNodoObjeto nodo = new CNodoObjeto(obj.ID_Objeto);
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaObjetos();
            }
        }
        private void ObjetoInsert(ObjetosModelo.CObjetoBase obj1)
        {
            ObjetosModelo.CObjeto obj = (ObjetosModelo.CObjeto)obj1;
            if (obj.ID_Conexion != this.ID_Conexion)
                return;

            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoObjeto))
                {
                    CNodoObjeto n2 = (CNodoObjeto)n;
                    if (n2.ID_Objeto == obj.ID_Objeto)
                        return;
                }
            }
            CNodoObjeto nodo = new CNodoObjeto(obj.IdObjeto);
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
        private void ObjetoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CObjeto objeto = (ObjetosModelo.CObjeto)obj;
            if (objeto.ID_Conexion != this.ID_Conexion)
               return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoObjeto))
                {
                    if (nodo.ID_Objeto == objeto.ID_Objeto)
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
   