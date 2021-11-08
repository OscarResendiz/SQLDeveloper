using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// representa la relacion de objetos que se encontraron en los archivos
    /// </summary>
    public class CArchivoObjeto : CObjetoBase
    {
        #region propiedades
        /// <summary>
        /// identificador del archivo
        /// </summary>
        public int ID_Archivo
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
        /// identificador del objeto
        /// </summary>
        public int ID_Objeto
        {
            get;
            set;
        }
        #endregion
        #region funciones
        /// <summary>
        /// elimina la relacion entre el objeto y el archivo
        /// </summary>
        public void delete()
        {
            Modelo.DeleteArchivoObjeto(this.ID_Archivo, this.ID_Objeto);
        }
        /// <summary>
        /// elimina la relacion y los objetos relacionados
        /// </summary>
        public void deleteCascade()
        {
            delete();
        }
        #endregion
    }
}
   