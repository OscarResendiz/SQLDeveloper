using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// objeto que representa la relacion entre objetos para ver sus dependencias o jearquia de llamadas
    /// </summary>
    public class CObjetoObjeto : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// identifica al objeto padre
        /// </summary>
        public int ID_ObjetoPadre
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
        /// Identifica al objeto hijo
        /// </summary>
        public int ID_ObjetoHijo
        {
            get;
            set;
        }
        #endregion
        #region metodos
        /// <summary>
        /// elimina la relacion
        /// </summary>
        public void delete()
        {
            Modelo.DeleteObjetoObjeto(this.ID_ObjetoPadre, this.ID_ObjetoHijo);
        }
        public CObjeto getObjeto()
        {
            return Modelo.GetObjeto(this.ID_ObjetoHijo);
        }
        #endregion
    }
}
   