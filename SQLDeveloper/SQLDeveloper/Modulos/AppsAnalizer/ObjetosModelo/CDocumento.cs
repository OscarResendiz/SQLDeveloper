using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// clase que representa un documento
    /// </summary>
    public class CDocumento : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// identificador del documento
        /// </summary>
        public int ID_Document
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
        /// identificador de la carpeta ala que pertenece el documento
        /// </summary>
        public int ID_Carpeta
        {
            get;
            set;
        }
        /// <summary>
        /// texto del documento
        /// </summary>
        public string Texto
        {
            get;
            set;
        }
        /// <summary>
        /// nombre del documento
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        #endregion
        #region funciones
        /// <summary>
        /// elimina el documento
        /// </summary>
        public void delete()
        {
            Modelo.DeleteDocumento(ID_Document);
        }
        /// <summary>
        /// actualiza el documento
        /// </summary>
        public void update()
        {
            Modelo.UpdateDocumento(this.ID_Document, this.ID_Carpeta, this.Texto, this.Nombre);
        }
        #endregion
    }
}
