using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoGrupo : CNodoFolder
    {
        public CNodoGrupo()
        {
            Text = "sin nombre";
        }
        public void AgregaConexion(ManagerConnect.CConexion conexion)
        {
            //busco si existe la conexion
            CNodoConexion Nodo = null;
            foreach (CNodoConexion obj in Nodes)
            {
                if (obj.Nombre == conexion.Nombre)
                {
                    //como ya existe, no hago nada
                    return;
                }
            }
            //creo el nodo
            Nodo = new CNodoConexion();
            Nodo.Conexion = conexion;
            Nodo.Servidor = Nombre;
            //lo agrego al modelo
            Modelo.AgregaConexion(Nombre, Nodo.Nombre, conexion.MotorDB, conexion.ConecctionString);
            Nodo.Modelo = Modelo;
            Nodes.Add(Nodo);
        }
        public override void ModeloAsignado()
        {
            List<CModelConexion> l = Modelo.DameConexiones(Nombre);
            foreach (CModelConexion obj in l)
            {
                CNodoConexion Nodo = new CNodoConexion();
                ManagerConnect.CConexion con = new ManagerConnect.CConexion();
                con.ConecctionString = obj.ConecctionString;
                con.Nombre = obj.Nombre;
                con.MotorDB = obj.MotorDB;
                Nodo.Conexion = con;
                Nodo.Servidor = Nombre;
                Nodo.Modelo = Modelo;
                Nodes.Add(Nodo);

            }
        }
    }
}
