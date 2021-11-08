using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// Superclase dela cual se derivan todas las demas
    /// </summary>
    public class CObjetoBase
    {
        /// <summary>
        /// almacena la referencia al modelo para uso interno del objeto
        /// </summary>
        public AppModel Modelo
        {
            get;
            set;
        }
        /// <summary>
        /// identificador principal del objeto
        /// </summary>
        public int IdObjeto
        {
            get;
            set;
        }
        public virtual void RepoteMapeo(DataTable dt, DataRow dr, int nivel)
        {

        }

    }
}
   