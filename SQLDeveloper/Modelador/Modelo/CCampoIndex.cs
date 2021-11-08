using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CCampoIndex : CBaseModelo
    {
        #region Propiedades
        public int ID_Index
        {
            get;
            set;
        }
        public int ID_Campo
        {
            get;
            set;
        }
        public bool Descendente
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Update()
        {
            Modelo.Update_CampoIndex(ID_Index, ID_Campo, Descendente);
        }
        public void Delete()
        {
            Modelo.Delete_CampoIndex(ID_Index, ID_Campo);
        }
        public CCampo Get_Campo()
        {
            return Modelo.Get_Campo(ID_Campo);
        }
        public CIndex Get_Index()
        {
            return Modelo.Get_Index(ID_Index);
        }
        #endregion
    }
}