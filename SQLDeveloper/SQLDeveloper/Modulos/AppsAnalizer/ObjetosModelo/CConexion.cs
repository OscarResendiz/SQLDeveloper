using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// almacena la informacion que representa la conexion a una base de datos
    /// </summary>
    public class CConexion : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// identificador de la conexion
        /// </summary>
        public int ID_Conexion
        {
            get
            {
                return IdObjeto;
            }
            set
            {
                IdObjeto = value;
            }
        }
        /// <summary>
        /// identificador del servidor o grupo al que pertenece
        /// </summary>
        public int ID_Servidor
        {
            get;
            set;
        }
        /// <summary>
        /// nombre de la conexion
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        /// <summary>
        /// cadena de conexion
        /// </summary>
        public string ConecctionString
        {
            get;
            set;
        }
        /// <summary>
        /// Motor de base de datos que utiliza la conexion
        /// </summary>
        public string MotorDB
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// regresa los objetos relacionados a la conexion
        /// </summary>
        /// <returns></returns>
        public List<CObjeto> getObjetos()
        {
            return Modelo.GetObjetos(this.ID_Conexion);
        }
        /// <summary>
        /// regresa todos los escript relacionados a la conexion
        /// </summary>
        /// <returns></returns>
        public List<CScript> getScripts()
        {
            return Modelo.GetScriptsConexion(this.ID_Conexion);
        }
        /// <summary>
        /// actualiza los datos de la conexion
        /// </summary>
        public void update()
        {
            Modelo.UpdateConexion(this.ID_Conexion, this.ID_Servidor, this.Nombre, this.ConecctionString, this.MotorDB);
        }
        /// <summary>
        /// elimina la conexion si es que esta vacia
        /// </summary>
        public void delete()
        {
            if (getScripts().Count > 0)
                throw new Exception("No se puede eliminar porque tiene scrips relacionados");
            if (getObjetos().Count > 0)
                throw new Exception("No se puede eliminar porque tiene objetos relacionados");
            Modelo.DeleteConexion(this.ID_Conexion);
        }
        /// <summary>
        /// elimina la conexion y todos sus objetos relacionados
        /// </summary>
        public void deleteCascade()
        {
            foreach(CScript obj in getScripts())
            {
                obj.delete();
            }
            foreach(CObjeto obj in getObjetos())
            {
                obj.deleteCascade();
            }
            delete();
        }
        public override string ToString()
        {
            return Nombre;
        }
        #endregion
    }
}
   