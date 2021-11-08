using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    public class CServidor : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// clave interna del servidor
        /// </summary>
        public int ID_Servidor
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
        /// nombre del servidor o grupo de conexiones
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// regresa la lista de conexiones asociadas al servidor
        /// </summary>
        /// <returns></returns>
        public List<CConexion> getConexiones()
        {
            return Modelo.GetConexiones(this.ID_Servidor);
        }
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void update()
        {
            Modelo.UpdateServidor(this.ID_Servidor,this.Nombre);
        }
        /// <summary>
        /// elimina el servidor si no tiene conexiones asignados
        /// </summary>
        public void delete()
        {
            if (getConexiones().Count > 0)
                throw new Exception("No se puede eliminar porque tiene conexiones asociadas");
            Modelo.DeleteServidor(this.ID_Servidor);
        }
        /// <summary>
        /// elimina el servidor y todos sus objetos asociados
        /// </summary>
        public void deleteCascade()
        {
            foreach(CConexion obj in getConexiones())
            {
                obj.deleteCascade();
            }
            delete();
        }
        /// <summary>
        /// agrega la conexion al servidor
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="ConecctionString"></param>
        /// <param name="MotorDB"></param>
        public void createConexion(string Nombre, string ConecctionString, string MotorDB)
        {
            Modelo.InsertConexion(ID_Servidor, Nombre, ConecctionString, MotorDB);
        }
        public override string ToString()
        {
            return Nombre;
        }
        #endregion
    }
}
   