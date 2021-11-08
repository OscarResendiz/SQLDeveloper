using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Dibujable
{
    public class DCapa : CObjetoDibujable
    {
        public event BuscaTablaDelegate OnBuscaTabla;
        Modelo.CCapa Capa;
        MiGraphics FMiGraphics;
        public int ID_Capa
        {
            get;
            set;
        }
        protected override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.OnCapaUpdate += new Modelo.DelegateModeloDatosEvent(CapaUpdate);
            Modelo.OnRegionInsert += new Modelo.DelegateModeloDatosEvent(RegionInsert);
            Modelo.OnMoveRegionCapa += new Modelo.DelegateModeloDatosEvent3(MoveRegionCapa);
            Modelo.OnMoveRegionRegion += new Modelo.DelegateModeloDatosEvent3(MoveRegionRegion);
            Modelo.OnTablaDelete += new Modelo.DelegateModeloDatosEvent(TablaDelete);
            Modelo.OnTablaCapaMove += new Modelo.DelegateModeloDatosEvent3(TablaCapaMove);
            Modelo.OnRegionTablaInsert += new Modelo.DelegateModeloDatosEvent2(RegionTablaInsert);
            Modelo.OnRegionDelete += new Modelo.DelegateModeloDatosEvent(RegionDelete);
            Modelo.OnCapaTablaInsert += new Modelo.DelegateModeloDatosEvent2(CapaTablaInsert);
            Modelo.OnCapaTablaDelete += new Modelo.DelegateModeloDatosEvent2(CapaTablaDelete);

            Capa = Modelo.Get_Capa(ID_Capa);
            CargaRegiones();
            Cargatablas();
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnCapaUpdate -= CapaUpdate;
            Modelo.OnRegionInsert -= RegionInsert;
            Modelo.OnMoveRegionCapa -= MoveRegionCapa;
            Modelo.OnMoveRegionRegion -= MoveRegionRegion;
            Modelo.OnTablaDelete -= TablaDelete;
            Modelo.OnTablaCapaMove -= TablaCapaMove;
            Modelo.OnRegionTablaInsert -= RegionTablaInsert;
            Modelo.OnRegionDelete -= RegionDelete;
            Modelo.OnCapaTablaInsert -= CapaTablaInsert;
            Modelo.OnCapaTablaDelete -= CapaTablaDelete;
        }
        private void CapaUpdate(Modelo.ModeloDatos modelo, int id_Capa)
        {
            if (ID_Capa == id_Capa)
            {
                Capa = Modelo.Get_Capa(id_Capa);
                Redibuja();
            }
        }
        public override void Dibuja(MiGraphics graphics)
        {
            FMiGraphics = graphics;
            if (Capa.Visible)
            {
                base.Dibuja(graphics);

                //dibujo las tablas primero
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa tabla = (DTablaCapa)obj;
                        if (Modelo.Get_TablaCapa(tabla.ID_Capa, tabla.ID_Tabla).Get_Region() == null)
                        {
                            tabla.Dibuja(graphics);
                            //dibujo sus laves foraneas
                            tabla.DibujaFinal(graphics);
                        }
                    }
                    if (obj.GetType() == typeof(DRegion))
                        obj.Dibuja(graphics);
                }
                //ahora las regiones
                //                foreach (CObjetoDibujable obj in hijos)
                //              {
                //                if (obj.GetType() == typeof(DRegion))
                //                  obj.Dibuja(graphics);
                //        }
                //ahora las regiones
                //mando a dibujar todos os objetos
            }
        }
        public void DibujaTablas(MiGraphics graphics)
        {
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DTablaCapa))
                    obj.Dibuja(graphics);
                /*                if(obj.GetType()==typeof(DRegion))

                                {
                                    DRegion region = (DRegion)obj;
                                    region.DibujaTablas(graphics);
                                }
                  */
            }
        }
        private void CargaRegiones()
        {
            List<Modelo.CRegion> regiones = Modelo.Get_RegionesCapa(Capa.ID_Capa);
            foreach (Modelo.CRegion region in regiones)
            {
                if (region.ID_RegionPadre == 0)
                {
                    DRegion dregion = new DRegion();
                    dregion.ID_Region = region.ID_Region;
                    dregion.CapaPadre = this;
                    dregion.OnBuscaTabla += OnBuscaTabla;
                    dregion.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
                    dregion.Modelo = Modelo;
                    hijos.Add(dregion);
                    AgregaObjetoControl(dregion);
                }
            }
        }
        private void RegionInsert(Modelo.ModeloDatos modelo, int ID_Region)
        {
            Modelo.CRegion region = Modelo.Get_Region(ID_Region);
            if (region.ID_Capa != ID_Capa)
                return;
            if (region.ID_RegionPadre != 0)
                return;
            DRegion dregion = new DRegion();
            dregion.ID_Region = region.ID_Region;
            dregion.CapaPadre = this;
            dregion.OnBuscaTabla += OnBuscaTabla;
            dregion.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
            dregion.Modelo = Modelo;
            hijos.Add(dregion);
            AgregaObjetoControl(dregion);
        }
        public bool Visible
        {
            get
            {
                return Capa.Visible;
            }
        }
        public override bool IsVisible()
        {
            return Visible;
        }
        private void MoveRegionCapa(Modelo.ModeloDatos modelo, int ID_Region, int ID_CapaOrigen, int ID_CapaDestino)
        {
            if (ID_Capa == ID_CapaOrigen)
            {
                //lo quito de mi lista
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DRegion))
                    {
                        DRegion region = (DRegion)obj;
                        if (region.ID_Region == ID_Region)
                        {
                            //hay que eliminarlo
                            hijos.Remove(region);
                            QuitaObjetoControl(region);
                            return;
                        }
                    }
                }
            }
            if (ID_Capa == ID_CapaDestino)
            {
                RegionInsert(modelo, ID_Region);
            }
        }
        private void MoveRegionRegion(Modelo.ModeloDatos modelo, int id_region, int id_regionOrigen, int id_regionDestino)
        {
            //busco la region hija dentro de mis nodos
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DRegion))
                {
                    DRegion nodoRegion = (DRegion)obj;
                    if (nodoRegion.ID_Region == id_region)
                    {
                        hijos.Remove(obj);
                        QuitaObjetoControl(obj);
                        Redibuja();
                        return;
                    }
                }
            }
        }
        private void Cargatablas()
        {
            List<Modelador.Modelo.CTabla> tablas = Modelo.Get_TablasCapa(ID_Capa);
            foreach (Modelador.Modelo.CTabla tabla in tablas)
            {
                //veo si no esta dentro de una region
                if (tabla.Get_Region() == null || tabla.Get_Region().ID_Capa != ID_Capa)
                {
                    DTablaCapa obj = new DTablaCapa();
                    obj.ID_Tabla = tabla.ID_Tabla;
                    obj.ID_Capa = ID_Capa;
                    obj.OnBuscaTabla += OnBuscaTabla;
                    obj.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
                    obj.CapaPadre = this;
                    obj.Modelo = Modelo;
                    hijos.Add(obj);
                    AgregaObjetoControl(obj);
                }
            }
        }
        private void TablaDelete(Modelo.ModeloDatos modelo, int id_tabla)
        {
            //busco si tengo la tabla
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DTablaCapa))
                {
                    DTablaCapa nodotabla = (DTablaCapa)obj;
                    if (nodotabla.ID_Tabla == id_tabla)
                    {
                        hijos.Remove(obj);
                        QuitaObjetoControl(obj);
                        Redibuja();
                        return;
                    }
                }
            }
        }
        private void RegionDelete(Modelo.ModeloDatos modelo, int id_region)
        {
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DRegion))
                {
                    DRegion nodoRegion = (DRegion)obj;
                    if (nodoRegion.ID_Region == id_region)
                    {
                        hijos.Remove(obj);
                        QuitaObjetoControl(obj);
                        Redibuja();
                        return;
                    }
                }
            }
        }
        public DTablaCapa BuscaTabla(int id_tabla)
        {
            if (hijos != null)
            {
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DRegion))
                    {
                        DRegion nodoRegion = (DRegion)obj;
                        DTablaCapa tabla = nodoRegion.BuscaTablaCapa(ID_Capa, id_tabla);
                        if (tabla != null)
                            return tabla;
                    }
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa tabla = (DTablaCapa)obj;
                        tabla = tabla.BuscaTablaCapa(ID_Capa, id_tabla);
                        if (tabla != null)
                            return tabla;
                    }
                }
            }
            return null;
        }
        private Point GetPosicionReal(DRectangulo obj)
        {
            return obj.Posicion;
        }
        private void RegionTablaInsert(Modelo.ModeloDatos modelo, int id_region, int ID_Tabla)
        {

            Modelo.CTabla tabla = Modelo.Get_Tabla(ID_Tabla);
            Modelo.CRegion r = Modelo.Get_Region(id_region);
            if (r.ID_Capa == ID_Capa)
            {
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa nodotabla = (DTablaCapa)obj;
                        if (nodotabla.ID_Tabla == ID_Tabla)
                        {
                            hijos.Remove(nodotabla);
                            QuitaObjetoControl(obj);
                            Redibuja();
                            return;
                        }
                    }
                }
            }
        }
        private void TablaCapaMove(Modelo.ModeloDatos modelo, int ID_Tabla, int ID_CapaOrigen, int ID_CapaDestino)
        {
            //caso especial
            if (ID_Capa == ID_CapaOrigen && ID_CapaOrigen == ID_CapaDestino)
            {
                //veo si ya existe el nodo
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa tabla = (DTablaCapa)obj;
                        if (tabla.ID_Tabla == ID_Tabla)
                        {
                            return;
                        }
                    }
                }
                //como no existe, lo agrego
                Modelo.Insert_TablaCapa(ID_Capa, ID_Tabla, 0, 0, true);
                return;
            }
            if (ID_Capa == ID_CapaOrigen)
            {
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa tabla = (DTablaCapa)obj;
                        if (tabla.ID_Tabla == ID_Tabla)
                        {
                            hijos.Remove(tabla);
                            QuitaObjetoControl(obj);
                            Redibuja();
                            return;
                        }
                    }
                }
            }
            if (ID_Capa == ID_CapaDestino)
            {
                Modelo.Insert_TablaCapa(ID_Capa, ID_Tabla, 0, 0, true);
            }
        }
        private void CapaTablaInsert(Modelo.ModeloDatos modelo, int id_Capa, int id_tabla)
        {
            if (ID_Capa != id_Capa)
                return;
            //verifico que no lo tenga agregado ya
            foreach(CDibujable obj1 in hijos)
            {
                if(obj1.GetType()==typeof(DTablaCapa))
                {
                    DTablaCapa tbl = (DTablaCapa)obj1;
                    if (tbl.ID_Tabla == id_tabla && tbl.ID_Capa == id_Capa)
                        return;
                }
            }
            Modelo.CTabla tabla = Modelo.Get_TablaCapa(ID_Capa, id_tabla);
            DTablaCapa obj = new DTablaCapa();
            obj.ID_Tabla = tabla.ID_Tabla;
            obj.ID_Capa = ID_Capa;
            obj.OnBuscaTabla += OnBuscaTabla;
            obj.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
            obj.CapaPadre = this;
            obj.Modelo = Modelo;
            obj.Posicion = new Point(tabla.X, tabla.Y);
            hijos.Add(obj);
            AgregaObjetoControl(obj);
        }
        private void CapaTablaDelete(Modelo.ModeloDatos modelo, int id_Capa, int id_tabla)
        {
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DTablaCapa))
                {
                    DTablaCapa tabla = (DTablaCapa)obj;
                    if (tabla.ID_Tabla == id_tabla && tabla.ID_Capa == ID_Capa)
                    {
                        hijos.Remove(tabla);
                        QuitaObjetoControl(obj);
                        Redibuja();
                        return;
                    }
                }
            }
        }
    }
}
