using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CCheck : CBaseModelo
    {
        #region Propiedades
        public int ID_Check
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public string Regla
        {
            get;
            set;
        }
        public int ID_Tabla
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Delete()
        {
            Modelo.Delete_Check(this.ID_Check);
        }
        public void Update()
        {
            Modelo.Update_Check(ID_Check, Nombre, Regla, ID_Tabla);
        }
        public CTabla Get_Tabla()
        {
            return Modelo.Get_Tabla(this.ID_Tabla);
        }
        #endregion

    }
}
