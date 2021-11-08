using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Modelador.Modelo
{
    public class CTabla : CBaseModelo
    {
        #region Propiedades
        public int ID_Tabla
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Ancho
        {
            get;
            set;
        }
        public int Alto
        {
            get;
            set;
        }
        public Color BKColor
        {
            get;
            set;
        }
        public bool Visible
        {
            get;
            set;
        }
        public string Modo
        {
            get;
            set;
        }
        public int ID_Identidad
        {
            get;
            set;
        }
        public string PK_Nombre
        {
            get;
            set;
        }
        public Color ForeColor
        {
            get;
            set;
        }
        public string Comentarios
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Update()
        {
            Modelo.Update_Tabla(ID_Tabla, Nombre, Ancho, Alto, BKColor, Modo, ID_Identidad, PK_Nombre, ForeColor,Comentarios);
        }
        public void Delete()
        {
            if (Get_FKHijas().Count > 0)
            {
                throw new Exception("No se puede eliminar porque hay dependecias de otras tablas con esta");
            }
            foreach (CCampo campo in Get_Campos())
            {
                campo.Delete();
            }
            foreach (CCheck check in Get_Checks())
            {
                check.Delete();
            }
            foreach (CIndex index in Get_Indexs())
            {
                index.Delete();
            }
            foreach (CUnique unique in Get_Uniques())
            {
                unique.Delete();
            }
            CRegion region = Get_Region();
            if(region!=null)
            {
                Modelo.Delete_RegionTabla(region.ID_Region, ID_Tabla);
            }
            Modelo.Delete_Tabla(this.ID_Tabla);
        }
        public void DeleteCascade()
        {
            foreach (CLlaveForanea fk in Get_FKHijas())
            {
                fk.Delete();
            }
            Delete();
        }
        public List<CCheck> Get_Checks()
        {
            return Modelo.Get_ChecksTabla(this.ID_Tabla);
        }
        public List<CIndex> Get_Indexs()
        {
            return Modelo.Get_IndexTabla(ID_Tabla);
        }
        /// <summary>
        /// regresa las llaves foraneas que apuntan a los padres de esta tabla
        /// </summary>
        /// <returns></returns>
        public List<CLlaveForanea> Get_FkPadres()
        {
            return Modelo.Get_LlavesForaneasHijas(ID_Tabla);
        }
        /// <summary>
        /// regresa las llaves foraneas que apuntan a las hijas de esta tabla
        /// </summary>
        /// <returns></returns>
        public List<CLlaveForanea> Get_FKHijas()
        {
            return Modelo.Get_LlavesForaneasPadre(ID_Tabla);
        }
        public List<CCampo> Get_Campos()
        {
            return Modelo.Get_CamposTabla(ID_Tabla);
        }
        public List<CUnique> Get_Uniques()
        {
            return Modelo.Get_UniquesTabla(ID_Tabla);
        }
        public CRegion Get_Region()
        {
            return Modelo.Get_RegionTabla(ID_Tabla);
        }
        public CCampo Get_CampoIdentidad()
        {
            return Modelo.Get_Campo(this.ID_Identidad);
        }
        public void Insert_Campo(string Nombre, int ID_TipoDato, int Longitud, bool PK, bool AceptaNulos, bool Calculado, string Formula, bool EsDefault, string DefaultName, string comentarios)
        {
            List<CCampo> l = Get_Campos();
            Modelo.Insert_Campo(Nombre, ID_Tabla, ID_TipoDato, Longitud, PK, AceptaNulos, Calculado, Formula, EsDefault, DefaultName,l.Count,comentarios);
        }
        public CCampo Get_Campo(string campo)
        {
            foreach(CCampo obj in Get_Campos())
            {
                if(obj.NombreX.ToUpper().Trim()==campo.ToUpper().Trim())
                {
                    return obj;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return Nombre;
        }
        public CIndex Get_PrimaryKeyIndex()
        {
            CIndex obj = null;                
            foreach (CIndex index in Get_Indexs())
            {
                if(index.Nombre==PK_Nombre)
                {
                    obj = index;
                    break;
                }
            }
            return obj;
        }
        #endregion
    }
}
