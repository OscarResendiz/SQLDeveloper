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
        /// <summary>
        /// Actualiza los datos de la tabla en el modelo
        /// </summary>
        public void Update()
        {
            Modelo.Update_Tabla(ID_Tabla, Nombre, Ancho, Alto, BKColor, Modo, ID_Identidad, PK_Nombre, ForeColor,Comentarios);
        }
        /// <summary>
        /// borra la tabla del modelo
        /// </summary>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// elimina la tabla y todas sus dependencias
        /// </summary>
        public void DeleteCascade()
        {
            foreach (CLlaveForanea fk in Get_FKHijas())
            {
                fk.Delete();
            }
            Delete();
        }

        /// <summary>
        /// regresa la lista de constrains Checks
        /// </summary>
        /// <returns></returns>
        public List<CCheck> Get_Checks()
        {
            return Modelo.Get_ChecksTabla(this.ID_Tabla);
        }
       /// <summary>
       /// Regresa la lista de Indices
       /// </summary>
       /// <returns></returns>
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
        /// <summary>
        /// regresa la lista de campos de la tabla
        /// </summary>
        /// <returns></returns>
        public List<CCampo> Get_Campos()
        {
            return Modelo.Get_CamposTabla(ID_Tabla);
        }
        /// <summary>
        /// regresa la lista de uniques
        /// </summary>
        /// <returns></returns>
        public List<CUnique> Get_Uniques()
        {
            return Modelo.Get_UniquesTabla(ID_Tabla);
        }
        /// <summary>
        /// regresa la region a la que pertenece la tabla
        /// </summary>
        /// <returns></returns>
        public CRegion Get_Region()
        {
            return Modelo.Get_RegionTabla(ID_Tabla);
        }
        /// <summary>
        /// regresa el campo que esta definido como identidad
        /// </summary>
        /// <returns></returns>
        public CCampo Get_CampoIdentidad()
        {
            return Modelo.Get_Campo(this.ID_Identidad);
        }
        /// <summary>
        /// agrega un campo a la tabla
        /// </summary>
        /// <param name="Nombre">nombre del campo</param>
        /// <param name="ID_TipoDato">tipo de dato</param>
        /// <param name="Longitud">longitud del campo</param>
        /// <param name="PK">indica si es parte de la llave primaria</param>
        /// <param name="AceptaNulos">indica si acepta valores nulos</param>
        /// <param name="Calculado">indica si es un campo calculado</param>
        /// <param name="Formula">formula ppor si es campo calculado</param>
        /// <param name="EsDefault">indica si tiene un valor por default</param>
        /// <param name="DefaultName">nombre del contrait default</param>
        /// <param name="comentarios">comentarios sobre el campo</param>
        public void Insert_Campo(string Nombre, int ID_TipoDato, int Longitud, bool PK, bool AceptaNulos, bool Calculado, string Formula, bool EsDefault, string DefaultName, string comentarios)
        {
            List<CCampo> l = Get_Campos();
            Modelo.Insert_Campo(Nombre, ID_Tabla, ID_TipoDato, Longitud, PK, AceptaNulos, Calculado, Formula, EsDefault, DefaultName,l.Count,comentarios);
        }
        /// <summary>
        /// regresa el campo
        /// </summary>
        /// <param name="campo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// comvierte tabla  a cadena
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// regresa la lista de campos que pertenecen a la llave primaria de la tabla
        /// </summary>
        /// <returns></returns>
        public List<CCampo> GetCampoPK()
        {
            List<CCampo> l = new List<CCampo>();
            foreach(CCampo campo in this.Get_Campos())
            {
                if(campo.PK)
                {
                    l.Add(campo);
                }
            }
            return l;

        }
        #endregion
    }
}
