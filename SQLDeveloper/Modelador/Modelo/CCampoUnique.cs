using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CCampoUnique : CBaseModelo
    {
        #region Propiedades
        public int ID_Unique
        {
            get;
            set;
        }
        public int ID_Campo
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Delete()
        {
            Modelo.Delete_CampoUnique(ID_Unique, ID_Campo);
        }
        public CCampo Get_Campo()
        {
            return Modelo.Get_Campo(ID_Campo);
        }
        public CUnique Get_Unique()
        {
            return Modelo.Get_Unique(ID_Unique);
        }
        #endregion
    }
}
