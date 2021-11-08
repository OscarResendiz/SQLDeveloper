using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoObjetosDB : CNodoBase
    {
        public CNodoObjetosDB()
        {
            Nombre = "Objetos DB";
            ImageIndex = 1;
            SelectedImageIndex = 1;
        }
        public override void ModeloAsignado()
        {
            Modelo.ServidorInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ServidorInsertEvent);
            Modelo.ServidorDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ServidorDeleteEvent);
            Modelo.AbrirModeloEvent += new ObjetosModelo.OnModeloEventDelegate(AbrirModeloEvent);
            Modelo.NuevoModeloEvent += new ObjetosModelo.OnModeloEventDelegate(NuevoModeloEvent);
            //CargaServidores();
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaServidores();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.ServidorInsertEvent -= ServidorInsertEvent;
            Modelo.ServidorDeleteEvent -= ServidorDeleteEvent;
            Modelo.AbrirModeloEvent -= AbrirModeloEvent;
            Modelo.NuevoModeloEvent -= NuevoModeloEvent;
        }
        private void AbrirModeloEvent(ObjetosModelo.AppModel modelo)
        {
            Nodes.Clear();
            CargaServidores();
        }
        private void NuevoModeloEvent(ObjetosModelo.AppModel modelo)
        {
            Nodes.Clear();
        }
        private void CargaServidores()
        {
            List<ObjetosModelo.CServidor> l = Modelo.GetServidores();
            foreach(ObjetosModelo.CServidor obj in l)
            {
                CNodoServidor nodo = new CNodoServidor(obj.ID_Servidor);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }
        }
        private void ServidorInsertEvent(ObjetosModelo.CObjetoBase obj)
        {
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoServidor))
                {
                    CNodoServidor n2 = (CNodoServidor)n;
                    if (n2.ID_Servidor == obj.IdObjeto)
                        return;
                }
            }
            CNodoServidor nodo = new CNodoServidor(obj.IdObjeto);
            nodo.Modelo = this.Modelo;
            Nodes.Add(nodo);

        }
        private void ServidorDeleteEvent(ObjetosModelo.CObjetoBase obj)
        {
            foreach(CNodoServidor servidor in Nodes )
            {
                if(servidor.ID_Servidor==obj.IdObjeto)
                {
                    servidor.Free();
                    Nodes.Remove(servidor);
                    return;
                }
            }
        }
    }
}
   