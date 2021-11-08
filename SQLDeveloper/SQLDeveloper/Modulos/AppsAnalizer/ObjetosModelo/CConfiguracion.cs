using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// Objeto que representa una configuracion del proyecto
    /// </summary>
    public class CConfiguracion : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// llave de la clave
        /// </summary>
        public string Clave
        {
            get;
            set;
        }
        /// <summary>
        /// valor almacenado por la clave
        /// </summary>
        public string Valor
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// actualiza el objeto 
        /// </summary>
        public void update()
        {
            Modelo.UpdateConfiguracion(this.Clave, this.Valor);
        }
        /// <summary>
        /// elimina la configuracion
        /// </summary>
        public void delete()
        {
            Modelo.DeleteConfiguracion(this.Clave);
        }
        #endregion
    }
}
