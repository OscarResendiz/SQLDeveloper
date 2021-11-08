using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// objeto que representa la relacion de los objetos que pertenecen a las carpetas
    /// </summary>
    public class CObjetoCarpeta : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// identificador de la carpeta
        /// </summary>
        public int ID_Carpeta
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
        /// Identificador del objeto
        /// </summary>
        public int ID_Objeto
        {
            get;
            set;
        }
        #endregion
        #region funciones
        /// <summary>
        /// elimina la relacion entre objetos y carpetas
        /// </summary>
        public void delete()
        {
            Modelo.DeleteObjetoCarpeta(ID_Carpeta, ID_Objeto);
        }
        #endregion
    }
}
