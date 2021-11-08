using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoServidor : CNodoBase
    {
        public int ID_Servidor
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
        public CNodoServidor(int id_Servidor)
        {
            ID_Servidor = id_Servidor;
        }
        public override void ModeloAsignado()
        {
            ObjetosModelo.CServidor obj = Modelo.GetServidor(this.ID_Servidor);
            Nombre = obj.Nombre;
            ImageIndex = 23;
            SelectedImageIndex = 23;
            Modelo.ConexionInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ConexionInsert);
            Modelo.ConexionDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ConexionDelete);
            CargaConexiones();
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaConexiones();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.ConexionInsertEvent -= ConexionInsert;
            Modelo.ConexionDeleteEvent -= ConexionDelete;
        }
        private void CargaConexiones()
        {
            List<ObjetosModelo.CConexion> l = Modelo.GetConexiones(ID_Servidor);
            foreach (ObjetosModelo.CConexion obj in l)
            {
                CNodoConexion nodo = new CNodoConexion(obj.ID_Conexion);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }

        }
        private void ConexionInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CConexion conexion = (ObjetosModelo.CConexion)obj;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoConexion))
                {
                    CNodoConexion n2 = (CNodoConexion)n;
                    if (n2.ID_Conexion == conexion.ID_Conexion)
                        return;
                }
            }
            CNodoConexion nodo = new CNodoConexion(conexion.ID_Conexion);
            nodo.Modelo = this.Modelo;
            Nodes.Add(nodo);
        }
        private void ConexionDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CConexion objeto = (ObjetosModelo.CConexion)obj;
            if (objeto.ID_Servidor != this.ID_Servidor)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoConexion))
                {
                    if (nodo.ID_Objeto == objeto.ID_Conexion)
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