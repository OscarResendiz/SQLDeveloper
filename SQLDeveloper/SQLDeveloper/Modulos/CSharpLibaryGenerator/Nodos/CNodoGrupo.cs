using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    class CNodoGrupo : CNodoFolder
    {
        public int ID_Servidor
        {
            get;
            set;
        }
        public CNodoGrupo()
        {
            Text = "sin nombre";
        }
        public void AgregaConexion(ManagerConnect.CConexion conexion)
        {
            Modelo.AgregaConexion(ID_Servidor, conexion.Nombre, conexion.ConecctionString, conexion.MotorDB);
        }
        public override void ModeloAsignado()
        {
            Modelo.OnConexionChange += new OnModeloNetEvent(ConexionChange);
        }
        private void ConexionChange(ModeloNet sender)
        {
            CargaModelo();
        }
        public override void CargaModelo()
        {
            List<CConexion> l = Modelo.DameConexionesServidor(ID_Servidor);
            //primero quito los que no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoConexion Nodo = (CNodoConexion)Nodes[i];
                bool encontrado = false;
                foreach (CConexion obj in l)
                {
                    if (obj.ID_Conexion == Nodo.ID_Conexion)
                    {
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    //hay que quitarlo
                    Nodes.Remove(Nodo);
                }
            }
            //ahora agrego los que faltan
            foreach (CConexion obj in l)
            {
                bool encontrado = false;
                foreach (CNodoConexion conexion in Nodes)
                {
                    if (conexion.ID_Conexion == obj.ID_Conexion)
                    {
                        //me lo salto
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    //lo agrego
                    CNodoConexion Nodo = new CNodoConexion();
                    ManagerConnect.CConexion con = new ManagerConnect.CConexion();
                    con.ConecctionString = obj.ConecctionString;
                    con.Nombre = obj.Nombre;
                    Nodo.Conexion = con;
                    Nodo.Servidor = Nombre;
                    Nodo.ID_Conexion = obj.ID_Conexion;
                    Nodo.Modelo = Modelo;
                    Nodes.Add(Nodo);
                }
            }

        }
    }
}
