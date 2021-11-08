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
        public void Delete()
        {
            Modelo.Delete_CampoReferencia(ID_FK, ID_CampoPadre, ID_CampoHijo);
        }
        public CLlaveForanea Get_LaveForanea()
        {
            return Modelo.Get_LlaveForanea(ID_FK);
        }
        public CCampo Get_CampoPadre()
        {
            return Modelo.Get_Campo(ID_CampoPadre);
        }
        public CCampo Get_CampoHijo()
        {
            return Modelo.Get_Campo(ID_CampoHijo);
        }
        #endregion
    }
}
