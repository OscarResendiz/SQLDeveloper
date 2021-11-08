using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace SQLDeveloper.Modulos.Visores.Dependencias
{
    public class CDependenciaManager
    {
        private List<string> Agregados;
        public CDependenciaManager()
        {
            Agregados = new List<string>();
        }
        public CNodoDependencia CargaDependientes(string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            //creo mi nodo raiz
            CNodoDependencia  Raiz = new CNodoDependencia();
            Raiz.Nombre = nombre;
            Raiz.Tipo = tipo;
            Agregados.Clear();
            Agregados.Add(nombre);
            //me traigo la lista de dependientes
            List<MotorDB.CObjeto> l = DBProvider.DB.DameDependientesDe(nombre);
            //recorro la lista y verifico si existe
            foreach(MotorDB.CObjeto obj in l)
            {
//                if (Existe(obj.Nombre) == false)
                {
                    //como no existe, lo agrego
                    CNodoDependencia nodo = new CNodoDependencia();
                    nodo.Nombre = obj.Nombre;
                    nodo.Tipo = obj.Tipo;
                    Raiz.Nodes.Add(nodo);
//                    Agregados.Add(obj.Nombre);
                }
            }
            foreach (CNodoDependencia nd in Raiz.Nodes)
            {
                if (Existe(nd.Nombre) == false)
                {
                    Agregados.Add(nd.Nombre);
                    CargaDependientesNodo(nd);
                }
            }
            return Raiz;
        }
        private void CargaDependientesNodo(CNodoDependencia Nodo)
        {
            //me traigo la lista de dependientes
            List<MotorDB.CObjeto> l = DBProvider.DB.DameDependientesDe(Nodo.Nombre);
            //recorro la lista y verifico si existe
            foreach (MotorDB.CObjeto obj in l)
            {
//                if (Existe(obj.Nombre) == false)
                {
                    //como no existe, lo agrego
                    CNodoDependencia nodo = new CNodoDependencia();
                    nodo.Nombre = obj.Nombre;
                    nodo.Tipo = obj.Tipo;
                    Nodo.Nodes.Add(nodo);
//                    Agregados.Add(obj.Nombre);
                }
            }
            foreach (CNodoDependencia nd in Nodo.Nodes)
            {
                if (Existe(nd.Nombre) == false)
                {
                    Agregados.Add(nd.Nombre);
                    CargaDependientesNodo(nd);
                }
            }
        }
        public CNodoDependencia CargaDependencias(string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            //creo mi nodo raiz
            CNodoDependencia Raiz = new CNodoDependencia();
            Raiz.Nombre = nombre;
            Raiz.Tipo = tipo;
            Agregados.Clear();
            Agregados.Add(nombre);
            //me traigo la lista de dependientes
            List<MotorDB.CObjeto> l = DBProvider.DB.DameDependenciasDe(nombre);
            //recorro la lista y verifico si existe
            foreach (MotorDB.CObjeto obj in l)
            {
//                if (Existe(obj.Nombre) == false)
                {
                    //como no existe, lo agrego
                    CNodoDependencia nodo = new CNodoDependencia();
                    nodo.Nombre = obj.Nombre;
                    nodo.Tipo = obj.Tipo;
                    Raiz.Nodes.Add(nodo);
//                    Agregados.Add(obj.Nombre);
                }
            }
            foreach(CNodoDependencia nd in Raiz.Nodes)
            {
                if (Existe(nd.Nombre) == false)
                {
                    Agregados.Add(nd.Nombre);
                    CargaDependenciasNodo(nd);
                }
            }
            return Raiz;
        }
        private void CargaDependenciasNodo(CNodoDependencia Nodo)
        {
            //me traigo la lista de dependientes
            List<MotorDB.CObjeto> l = DBProvider.DB.DameDependenciasDe(Nodo.Nombre);
            //recorro la lista y verifico si existe
            foreach (MotorDB.CObjeto obj in l)
            {
                //if (Existe(obj.Nombre) == false)
                {
                    //como no existe, lo agrego
                    CNodoDependencia nodo = new CNodoDependencia();
                    nodo.Nombre = obj.Nombre;
                    nodo.Tipo = obj.Tipo;
                    Nodo.Nodes.Add(nodo);
//                    Agregados.Add(obj.Nombre);
                    CargaDependientesNodo(nodo);
                }
            }
            foreach (CNodoDependencia nd in Nodo.Nodes)
            {
                if (Existe(nd.Nombre) == false)
                {
                    Agregados.Add(nd.Nombre);
                    CargaDependenciasNodo(nd);
                }
            }

        }
        private bool Existe(string nombre)
        {
            foreach(string s in Agregados)
            {
                if (nombre == s)
                    return true;
            }
            return false;
        }
    }
}
