using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Modelador.Modelo
{
    public class CRegion : CBaseModelo
    {
        #region Propiedades
        public string Nombre
        {
            get;
            set;
        }
        public int ID_Region
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
        public Color BkColor
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
        public int ID_RegionPadre
        {
            get;
            set;
        }
        public int ID_Capa
        {
            get;
            set;
        }
        public Color ForeColor
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Update()
        {
            Modelo.Update_Region(ID_Region, Nombre, X, Y, Ancho, Alto, BkColor, Visible, Modo, ID_RegionPadre, ID_Capa, ForeColor);
        }
        public void Delete()
        {
            if (Modelo.Get_RegionesHijas(this.ID_Region).Count > 0)
            {
                throw new Exception("No se puede eliminar porque contiene regiones asociadas");
            }
            if (Modelo.Get_TablasRegion(ID_Region).Count > 0)
            {
                throw new Exception("No se puede eliminar porque contiene tablas asociadas");
            }
            Modelo.Delete_Region(ID_Region);
        }
        public void DeleteCascade()
        {
            foreach (CRegion region in Get_Regiones())
            {
                region.DeleteCascade();
            }
            foreach (CTabla tabla in Get_Tablas())
            {
                Modelo.Delete_RegionTabla(this.ID_Region, tabla.ID_Tabla);
            }
            Delete();
        }
        public List<CRegion> Get_Regiones()
        {
            return Modelo.Get_RegionesHijas(ID_Region);
        }
        public List<CTabla> Get_Tablas()
        {
            return Modelo.Get_TablasRegion(ID_Region);
        }
        public CRegion Insert_Region(string Nombre, Color BkColor, bool Visible, string Modo, int ID_Capa, Color ForeColor)
        {
            int id_Region = Modelo.Insert_Region(Nombre, BkColor, Visible, Modo, this.ID_Region, ID_Capa, ForeColor);
            return Modelo.Get_Region(id_Region);
        }
        public CTabla Insert_Tabla(string Nombre, int X, int Y, int Ancho, int Alto, Color BKColor, string Modo, int ID_Identidad, string PK_Nombre, int ID_Capa, Color ForeColor,string comentarios)
        {
            int id_Tabla = Modelo.Insert_Tabla(Nombre,  Ancho, Alto, BKColor,  Modo, ID_Identidad, PK_Nombre, ForeColor,comentarios);
            Modelo.Insert_TablaCapa(ID_Capa, id_Tabla, X, Y, Visible);
            Modelo.Insert_RegionTabla(this.ID_Region, id_Tabla);
            return Modelo.Get_Tabla(id_Tabla);
        }
        public void Delete_Tabla(int ID_Tabla)
        {
            Modelo.Delete_RegionTabla(this.ID_Region, ID_Tabla);
        }
        #endregion
    }
}
