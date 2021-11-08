using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CUnique : CBaseModelo
    {
        #region Propiedades
        public int ID_Unique
        {
            get;
            set;
        }
        public string Nombre
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
        public void Update()
        {
            Modelo.Update_Unique(ID_Unique, ID_Tabla, Nombre);
        }
        public List<CCampoUnique> Get_Campos()
        {
            return Modelo.Get_CamposUnique(this.ID_Unique);
        }
        public void Delete()
        {
            foreach (CCampoUnique obj in Get_Campos())
            {
                obj.Delete();
            }
        }
        public CTabla Get_Tabla()
        {
            return Modelo.Get_Tabla(this.ID_Tabla);
        }
        #endregion
    }
}
