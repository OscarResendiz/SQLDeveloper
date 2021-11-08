using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Modelador.Modelo
{
    public class CCapa : CBaseModelo
    {
        #region Propiedades
        public int ID_Capa
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public bool Visible
        {
            get;
            set;
        }
        public int ID_CapaSuperior
        {
            get;
            set;
        }
        public int ID_CapaInferior
        {
            get;
            set;
        }
        #endregion
        #region Funciones
        public void Update()
        {
            Modelo.Update_Capa(this.ID_Capa, this.Nombre, this.Visible, this.ID_CapaSuperior, this.ID_CapaInferior);
        }
        public List<CRegion> Get_Regiones()
        {
            return Modelo.Get_RegionesCapa(this.ID_Capa);
        }
        public List<CTabla> Get_tablas()
        {
            return Modelo.Get_TablasCapa(this.ID_Capa);
        }
        public void Delete()
        {
            List<CRegion> regiones = Get_Regiones();
            if (regiones.Count > 0)
            {
                throw new Exception("No se puede eliminar la capa porque tiene regiones asociadas");
            }
            List<CTabla> tablas = Get_tablas();
            if (tablas.Count > 0)
            {
                throw new Exception("No se puede eliminar la capa porque tiene tablas asociadas");
            }
            Modelo.Delete_Capa(this.ID_Capa);
        }
        public CRegion Insert_Region(string Nombre, Color BkColor, bool Visible, string Modo, int ID_RegionPadre, Color ForeColor)
        {
            int ID_Region = Modelo.Insert_Region(Nombre, BkColor, Visible, Modo, ID_RegionPadre, this.ID_Capa, ForeColor);
            return Modelo.Get_Region(ID_Region);
        }
        public CTabla Insert_Tabla(string Nombre, int X, int Y, int Ancho, int Alto, Color BKColor, string Modo, int ID_Identidad, string PK_Nombre, Color ForeColor,string comentarios)
        {
            int id_tabla = Modelo.Insert_Tabla(Nombre, Ancho, Alto, BKColor,  Modo, ID_Identidad, PK_Nombre, ForeColor,comentarios);
            Modelo.Insert_TablaCapa(ID_Capa, id_tabla, X, Y, Visible);
            return Modelo.Get_Tabla(id_tabla);
        }
        public void DeleteCascade()
        {
            List<CRegion> regiones = Get_Regiones();
            foreach (CRegion region in regiones)
            {
                region.DeleteCascade();
            }
            List<CTabla> tablas = Get_tablas();
            foreach (CTabla tabla in tablas)
            {
                tabla.DeleteCascade();
            }
            Delete();
        }
        public CCapa Get_CapaSuperior()
        {
            if (ID_CapaSuperior == 0)
                return null;
            return Modelo.Get_Capa(this.ID_CapaSuperior);
        }
        public CCapa Get_CapaInferior()
        {
            if (ID_CapaInferior == 0)
                return null;
            return Modelo.Get_Capa(ID_CapaInferior);
        }
        #endregion
    }
}