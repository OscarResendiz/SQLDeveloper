using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CLineaFK : CBaseModelo
    {
        #region Propiedades

        public int ID_FK
        {
            get;
            set;
        }
        public int XI
        {
            get;
            set;
        }
        public int YI
        {
            get;
            set;
        }
        public int XF
        {
            get;
            set;
        }
        public int YF
        {
            get;
            set;
        }
        public int Orden
        {
            get;
            set;
        }
        public int ID_LineaFk
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Delete()
        {
            Modelo.Delete_LineaFK(ID_LineaFk);
        }
        public void Update()
        {
            Modelo.Update_LineaFK(ID_FK, XI, YI, XF, YF, Orden, ID_LineaFk);
        }
        public CLlaveForanea Get_LlaveForanea()
        {
            return Modelo.Get_LlaveForanea(ID_FK);
        }
        #endregion
    }
}
