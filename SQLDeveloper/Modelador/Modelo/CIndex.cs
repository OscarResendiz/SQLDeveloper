using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CIndexX : CBaseModelo
    {
        #region Propiedades
        public int ID_Index
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
        public bool GenerarFuncionX
        {
            get;
            set;

        }
        public bool MultiplesObjetos
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public List<CCampoIndex> Get_CamposIndex()
        {
            return Modelo.Get_CamposIndex(this.ID_Index);
        }
        public void Delete()
        {
            foreach (CCampoIndex obj in Get_CamposIndex())
            {
                obj.Delete();
            }
            Modelo.Delete_Index(this.ID_Index);
        }
        public CTabla Get_Tabla()
        {
            return Modelo.Get_Tabla(this.ID_Tabla);
        }
        public void Delete_Campo(int ID_Campo)
        {
            Modelo.Delete_CampoIndex(this.ID_Index, ID_Campo);
        }
        public void Insert_Campo(int id_campo,bool desc)
        {
            Modelo.Insert_CampoIndex(ID_Index, id_campo, desc);
        }
        public void Update()
        {
            Modelo.Update_Index(ID_Index, Nombre, ID_Tabla, GenerarFuncionX, MultiplesObjetos);
        }
        #endregion

    }
}
