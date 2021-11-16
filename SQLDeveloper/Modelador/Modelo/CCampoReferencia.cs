using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CCampoReferencia : CBaseModelo
    {
        #region Propiedades
        public int ID_FK
        {
            get;
            set;
        }
        public int ID_CampoPadre
        {
            get;
            set;
        }
        public int ID_CampoHijo
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// elimina la llave foranea del modelo
        /// </summary>
        public void Delete()
        {
            Modelo.Delete_CampoReferencia(ID_FK, ID_CampoPadre, ID_CampoHijo);
        }
        /// <summary>
        /// regresa la llave foranea
        /// </summary>
        /// <returns></returns>
        public CLlaveForanea Get_LaveForanea()
        {
            return Modelo.Get_LlaveForanea(ID_FK);
        }
        /// <summary>
        /// regresa el nombre del campo que hace referencia a la tabla padre
        /// </summary>
        /// <returns></returns>
        public CCampo Get_CampoPadre()
        {
            return Modelo.Get_Campo(ID_CampoPadre);
        }
        /// <summary>
        /// regresa el campo que hace referencia a la tabla hija
        /// </summary>
        /// <returns></returns>
        public CCampo Get_CampoHijo()
        {
            return Modelo.Get_Campo(ID_CampoHijo);
        }
        #endregion
    }
}
