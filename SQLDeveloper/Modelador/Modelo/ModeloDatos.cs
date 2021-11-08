using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MotorDB;
namespace Modelador.Modelo
{
    #region Delegados
    public delegate void DelegateModeloDatosEvent(ModeloDatos modelo, int ID);
    public delegate void DelegateModeloDatosEvent2(ModeloDatos modelo, int ID, int ID2);
    public delegate void DelegateModeloDatosEvent3(ModeloDatos modelo, int ID, int ID2, int ID3);
    public delegate void DelegateModeloEvent(ModeloDatos modelo);
    #endregion
    public partial class ModeloDatos
    {
        #region eventos
        #region eventos Capa
        public event DelegateModeloDatosEvent OnCapaInsert;
        public event DelegateModeloDatosEvent OnCapaUpdate;
        public event DelegateModeloDatosEvent OnCapaDelete;
        #endregion
        #region Eventos Region
        public event DelegateModeloDatosEvent OnRegionInsert;
        public event DelegateModeloDatosEvent OnRegionUpdate;
        public event DelegateModeloDatosEvent OnRegionDelete;
        public event DelegateModeloDatosEvent3 OnMoveRegionCapa;
        public event DelegateModeloDatosEvent3 OnMoveRegionRegion;
        #endregion
        #region Eventos Tabla
        public event DelegateModeloDatosEvent OnTablaInsert;
        public event DelegateModeloDatosEvent OnTablaUpdate;
        public event DelegateModeloDatosEvent OnTablaDelete;
        public event DelegateModeloDatosEvent3 OnTablaCapaMove;
        public event DelegateModeloDatosEvent2 OnCapaTablaInsert;
        public event DelegateModeloDatosEvent2 OnCapaTablaDelete;
        public event DelegateModeloDatosEvent2 OnCapaTablaUpdate;
        #endregion
        #region Eventos LlaveForanea
        public event DelegateModeloDatosEvent OnLlaveForaneaInsert;
        public event DelegateModeloDatosEvent OnLlaveForaneaUpdate;
        public event DelegateModeloDatosEvent OnLlaveForaneaDelete;
        #endregion
        #region Eventos TipoDato
        public event DelegateModeloDatosEvent OnTipoDatoInsert;
        public event DelegateModeloDatosEvent OnTipoDatoUpdate;
        public event DelegateModeloDatosEvent OnTipoDatoDelete;
        #endregion
        #region Eventos Campo
        public event DelegateModeloDatosEvent OnCampoInsert;
        public event DelegateModeloDatosEvent OnCampoUpdate;
        public event DelegateModeloDatosEvent OnCampoDelete;
        #endregion
        #region Eventos Unique
        public event DelegateModeloDatosEvent OnUniqueInsert;
        public event DelegateModeloDatosEvent OnUniqueUpdate;
        public event DelegateModeloDatosEvent OnUniqueDelete;
        #endregion
        #region Eventos Index
        public event DelegateModeloDatosEvent OnIndexInsert;
        public event DelegateModeloDatosEvent OnIndexUpdate;
        public event DelegateModeloDatosEvent OnIndexDelete;
        #endregion
        #region Eventos Check
        public event DelegateModeloDatosEvent OnCheckInsert;
        public event DelegateModeloDatosEvent OnCheckUpdate;
        public event DelegateModeloDatosEvent OnCheckDelete;
        #endregion
        #region Eventos LineaFK
        public event DelegateModeloDatosEvent OnLineaFKInsert;
        public event DelegateModeloDatosEvent OnLineaFKUpdate;
        public event DelegateModeloDatosEvent OnLineaFKDelete;
        #endregion        
        #region Eventos Check
        public event DelegateModeloDatosEvent2 OnRegionTablaInsert;
        public event DelegateModeloDatosEvent2 OnRegionTablaUpdate;
        public event DelegateModeloDatosEvent2 OnRegionTablaDelete;
        #endregion
        #region Eventos CampoUnique
        public event DelegateModeloDatosEvent2 OnCampoUniqueInsert;
        public event DelegateModeloDatosEvent2 OnCampoUniqueDelete;
        #endregion
        #region Eventos CampoIndex
        public event DelegateModeloDatosEvent2 OnCampoIndexInsert;
        public event DelegateModeloDatosEvent2 OnCampoIndexUpdate;
        public event DelegateModeloDatosEvent2 OnCampoIndexDelete;
        #endregion
        #region Eventos CampoReferencia
        public event DelegateModeloDatosEvent3 OnCampoReferenciaInsert;
        public event DelegateModeloDatosEvent3 OnCampoReferenciaDelete;
        #endregion
        #region Eventos del modelo
        public event DelegateModeloEvent OnNuevo;
        public event DelegateModeloEvent OnAbrir;
        public event DelegateModeloEvent OnFileNameChange;
        #endregion
        #endregion
        #region Funciones
        #region Funciones generales
        private Color GetColor(string Code)
        {
            if (Code == "")
                return Color.White; //no tiene color
            try
            {
                return System.Drawing.ColorTranslator.FromHtml(Code);
            }
            catch (System.Exception)
            {
                return Color.White;
            }

        }
        private string ColorStrng(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2"); ;
        }
        #endregion
        #region Capa
        #region Select1
        private CapaRow Get_CapaRow(int id_capa)
        {
            var l = (from obj in Capa where obj.ID_Capa == id_capa select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        /// <summary>
        /// regresa la capa que esta hasta el tope de todas
        /// </summary>
        /// <returns></returns>
        private CapaRow Get_CapaSuperior()
        {
            var l = (from obj in Capa where obj.ID_CapaSuperior == 0 select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CCapa Get_CapaInferior()
        {
            var l = (from obj in Capa where obj.ID_CapaInferior == 0 select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            var x = l.First();
            return new CCapa()
            {
                ID_Capa = x.ID_Capa,
                ID_CapaInferior = x.ID_CapaInferior,
                ID_CapaSuperior = x.ID_CapaSuperior,
                Modelo = this,
                Nombre = x.Nombre,
                Visible = x.Visible
            };
        }
        /// <summary>
        /// rgresa una capa en especifico
        /// </summary>
        /// <param name="id_capa"></param>
        /// <returns></returns>
        public CCapa Get_Capa(int id_capa)
        {
            var x = Get_CapaRow(id_capa);
            return new CCapa()
            {
                ID_Capa = x.ID_Capa,
                ID_CapaInferior = x.ID_CapaInferior,
                ID_CapaSuperior = x.ID_CapaSuperior,
                Modelo = this,
                Nombre = x.Nombre,
                Visible = x.Visible
            };

        }

        #endregion
        #region SelectN
        /// <summary>
        /// regresa e listado de todas las capas
        /// </summary>
        /// <returns></returns>
        public List<CCapa> Get_Capas()
        {
            List<CCapa> lista = new List<CCapa>();
            int ID_CapaSuperior = 0;
            do
            {
                //me traigo la primer capa hija
                var l = (from obj in Capa where obj.ID_CapaSuperior == ID_CapaSuperior select obj);
                if (l.Count() == 0)
                    return lista;
                var x = l.First();
                CCapa capa = new CCapa()
                {
                    ID_Capa = x.ID_Capa,
                    ID_CapaInferior = x.ID_CapaInferior,
                    ID_CapaSuperior = x.ID_CapaSuperior,
                    Modelo = this,
                    Nombre = x.Nombre,
                    Visible = x.Visible
                };
                lista.Add(capa);
                ID_CapaSuperior = capa.ID_Capa;
            }
            while (ID_CapaSuperior != 0);
            return lista;
        }
        #endregion
        #region Insert
        public int Insert_Capa(string Nombre, bool Visible)
        {
            CapaRow rowsuperior = Get_CapaSuperior();
            CapaRow row = Capa.NewCapaRow();
            row.Nombre = Nombre;
            row.Visible = Visible;
            row.ID_CapaSuperior = 0;// es el nuevo top
            if (rowsuperior != null)
            {
                row.ID_CapaInferior = rowsuperior.ID_Capa; //asigno la capa inferior
                                                           //actualizo la capa superior como inferior
                rowsuperior.ID_CapaSuperior = row.ID_Capa;
                rowsuperior.AcceptChanges();
                if (OnCapaUpdate != null)
                    OnCapaUpdate(this, rowsuperior.ID_Capa);
            }
            else
                row.ID_CapaInferior = 0;
            Capa.Rows.Add(row);
            Fmodificando = true;
            if (OnCapaInsert != null)
                OnCapaInsert(this, row.ID_Capa);
            return row.ID_Capa;
        }
        #endregion
        #region update
        public void Update_Capa(int ID_Capa, string Nombre, bool Visible, int ID_CapaSuperior, int ID_CapaInferior)
        {
            CapaRow obj = Get_CapaRow(ID_Capa);
            if (obj == null)
            {
                throw new Exception("No se encuentra la capa");
            }
            obj.Nombre = Nombre;
            obj.Visible = Visible;
            obj.ID_CapaSuperior = ID_CapaSuperior;
            obj.ID_CapaInferior = ID_CapaInferior;
            obj.AcceptChanges();
            Fmodificando = true;
            if (OnCapaUpdate != null)
                OnCapaUpdate(this, ID_Capa);
        }
        #endregion
        #region Delete
        public void Delete_Capa(int ID_Capa)
        {
            CapaRow obj = Get_CapaRow(ID_Capa);
            if (obj == null)
            {
                throw new Exception("No se encuentra la capa");
            }
            CapaRow CapaSuperior = Get_CapaRow(obj.ID_CapaSuperior);
            CapaRow CapaInferior = Get_CapaRow(obj.ID_CapaInferior);
            obj.Delete();
            Capa.AcceptChanges();
            if (OnCapaDelete != null)
                OnCapaDelete(this, ID_Capa);
            //actualizo las posiciones del siguiente y del anterior
            if (CapaSuperior != null && CapaInferior != null)
            {
                //tiene ambas capas asignadas, por lo que hay que actualizar sus posisiones
                CapaSuperior.ID_CapaInferior = CapaInferior.ID_Capa;
                CapaInferior.ID_CapaSuperior = CapaSuperior.ID_Capa;
                CapaSuperior.AcceptChanges();
                CapaInferior.AcceptChanges();
                if (OnCapaUpdate != null)
                    OnCapaUpdate(this, CapaSuperior.ID_Capa);
                if (OnCapaUpdate != null)
                    OnCapaUpdate(this, CapaInferior.ID_Capa);
            }
            else if (CapaSuperior != null)
            {
                //solo tenia capa superior
                CapaSuperior.ID_CapaInferior = 0;
                CapaSuperior.AcceptChanges();
                if (OnCapaUpdate != null)
                    OnCapaUpdate(this, CapaSuperior.ID_Capa);
            }
            else if (CapaInferior != null)
            {
                CapaInferior.ID_CapaSuperior = 0;
                if (OnCapaUpdate != null)
                    OnCapaUpdate(this, CapaInferior.ID_Capa);
            }
            Fmodificando = true;
        }
        #endregion
        #endregion
        #region Region
        #region Select1
        private RegionRow Get_RegionRown(int ID_Region)
        {
            var l = (from obj in Region where obj.ID_Region == ID_Region select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CRegion Get_Region(int ID_Region)
        {
            var obj = Get_RegionRown(ID_Region);
            if (obj == null)
            {
                throw new Exception("No se encontro la Region");
            }
            return new CRegion()
            {
                Alto = obj.Alto,
                Ancho = obj.Ancho,
                BkColor = GetColor(obj.BkColor),
                ForeColor = GetColor(obj.ForeColor),
                ID_Capa = obj.ID_Capa,
                ID_Region = obj.ID_Region,
                ID_RegionPadre = obj.ID_RegionPadre,
                Modelo = this,
                Modo = obj.Modo,
                Nombre = obj.Nombre,
                Visible = obj.Visible,
                X = obj.X,
                Y = obj.Y
            };
        }
        #endregion
        #region SelectN
        /// <summary>
        /// regresa la lista de regiones que son hijas de la capa
        /// </summary>
        /// <param name="ID_Capa"></param>
        /// <returns></returns>
        public List<CRegion> Get_RegionesCapa(int ID_Capa)
        {
            List<CRegion> lista = new List<CRegion>();
            var l = (from obj in Region where obj.ID_Capa == ID_Capa select obj);
            foreach (var obj in l)
            {
                lista.Add(new CRegion()
                {
                    Alto = obj.Alto,
                    Ancho = obj.Ancho,
                    BkColor = GetColor(obj.BkColor),
                    ForeColor = GetColor(obj.ForeColor),
                    ID_Capa = obj.ID_Capa,
                    ID_Region = obj.ID_Region,
                    ID_RegionPadre = obj.ID_RegionPadre,
                    Modelo = this,
                    Modo = obj.Modo,
                    Nombre = obj.Nombre,
                    Visible = obj.Visible,
                    X = obj.X,
                    Y = obj.Y
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa la lista de regiones hijas de la region 
        /// </summary>
        /// <param name="ID_Region"></param>
        /// <returns></returns>
        public List<CRegion> Get_RegionesHijas(int ID_Region)
        {
            List<CRegion> lista = new List<CRegion>();
            var l = (from obj in Region where obj.ID_RegionPadre == ID_Region select obj);
            foreach (var obj in l)
            {
                lista.Add(new CRegion()
                {
                    Alto = obj.Alto,
                    Ancho = obj.Ancho,
                    BkColor = GetColor(obj.BkColor),
                    ForeColor = GetColor(obj.ForeColor),
                    ID_Capa = obj.ID_Capa,
                    ID_Region = obj.ID_Region,
                    ID_RegionPadre = obj.ID_RegionPadre,
                    Modelo = this,
                    Modo = obj.Modo,
                    Nombre = obj.Nombre,
                    Visible = obj.Visible,
                    X = obj.X,
                    Y = obj.Y
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        //        public int Insert_Region(string Nombre, int X, int Y, int Ancho, int Alto, Color BkColor, bool Visible, string Modo, int ID_RegionPadre, int ID_Capa, Color ForeColor)
        public int Insert_Region(string Nombre, Color BkColor, bool Visible, string Modo, int ID_RegionPadre, int ID_Capa, Color ForeColor)
        {
            RegionRow rown = Region.NewRegionRow();
            rown.Nombre = Nombre;
            rown.X = 0;
            rown.Y = 0;
            rown.Ancho = 700;
            rown.Alto = 400;
            rown.BkColor = ColorStrng(BkColor);
            rown.Visible = Visible;
            rown.Modo = Modo;
            rown.ID_RegionPadre = ID_RegionPadre;
            rown.ID_Capa = ID_Capa;
            rown.ForeColor = ColorStrng(ForeColor);
            Region.Rows.Add(rown);
            Fmodificando = true;
            if (OnRegionInsert != null)
            {
                OnRegionInsert(this, rown.ID_Region);
            }
            return rown.ID_Region;
        }
        public void Insert_RegionTabla(int ID_Region, int ID_Tabla)
        {
            RegionTablaRow row = RegionTabla.NewRegionTablaRow();
            row.ID_Region = ID_Region;
            row.ID_Tabla = ID_Tabla;
            RegionTabla.AddRegionTablaRow(row);
            RegionTabla.AcceptChanges();
            if (OnRegionTablaInsert != null)
                OnRegionTablaInsert(this, ID_Region, ID_Tabla);
        }
        #endregion
        #region update
        public void Update_Region(int ID_Region, string Nombre, int X, int Y, int Ancho, int Alto, Color BkColor, bool Visible, string Modo, int ID_RegionPadre, int ID_Capa, Color ForeColor)
        {
            RegionRow rown = Get_RegionRown(ID_Region);
            if (rown == null)
            {
                throw new Exception("No se encontro la region");
            }
            rown.Nombre = Nombre;
            rown.X = X;
            rown.Y = Y;
            rown.Ancho = Ancho;
            rown.Alto = Alto;
            rown.BkColor = ColorStrng(BkColor);
            rown.Visible = Visible;
            rown.Modo = Modo;
            rown.ID_RegionPadre = ID_RegionPadre;
            rown.ID_Capa = ID_Capa;
            rown.ForeColor = ColorStrng(ForeColor);
            rown.AcceptChanges();
            Fmodificando = true;
            if (OnRegionUpdate != null)
            {
                OnRegionUpdate(this, ID_Region);
            }
        }
        public void Move_RegionCapa(int ID_Region, int ID_CapaOrigen, int ID_CapaDestino)
        {
            if (ID_CapaOrigen != ID_CapaDestino)
                return;

            CRegion reg = Get_Region(ID_Region);
            if (ID_CapaOrigen == ID_CapaDestino && reg.ID_RegionPadre == 0)
                return;
            RegionRow rown = Get_RegionRown(ID_Region);
            if (rown == null)
            {
                throw new Exception("No se encontro la region");
            }
            rown.ID_Capa = ID_CapaDestino;
            rown.ID_RegionPadre = 0;
            rown.AcceptChanges();
            Fmodificando = true;
            if (OnMoveRegionCapa != null)
                OnMoveRegionCapa(this, ID_Region, ID_CapaOrigen, ID_CapaDestino);
        }
        public void Move_RegionRegion(int ID_Region, int ID_RegionOrigen, int ID_RegionDestino)
        {
            if (ID_RegionOrigen == ID_RegionDestino || ID_RegionDestino == ID_Region)
                return;
            RegionRow regionDestino = Get_RegionRown(ID_RegionDestino);
            if (regionDestino == null)
                return;
            RegionRow rown = Get_RegionRown(ID_Region);
            if (rown == null)
            {
                throw new Exception("No se encontro la region");
            }
            if (rown.ID_Capa != regionDestino.ID_Capa)
                return;
            CRegion regiondes = Get_Region(ID_RegionDestino);
            rown.ID_RegionPadre = ID_RegionDestino;
            rown.ID_Capa = regiondes.ID_Capa;
            rown.AcceptChanges();
            Fmodificando = true;
            if (OnMoveRegionCapa != null)
                OnMoveRegionRegion(this, ID_Region, ID_RegionOrigen, ID_RegionDestino);
        }
        #endregion
        #region Delete
        public void Delete_Region(int ID_Region)
        {
            RegionRow rown = Get_RegionRown(ID_Region);
            if (rown == null)
            {
                throw new Exception("No se encontro la region");
            }
            rown.Delete();
            Region.AcceptChanges();
            Fmodificando = true;
            if (OnRegionDelete != null)
                OnRegionDelete(this, ID_Region);
        }
        public void Delete_RegionTabla(int ID_Region, int ID_Tabla)
        {
            var l = (from obj in RegionTabla where obj.ID_Region == ID_Region && obj.ID_Tabla == ID_Tabla select obj);
            if (l.Count() == 0)
            {
                throw new Exception("No se encontro la region tabla");
            }
            RegionTablaRow row = l.First();
            row.Delete();
            RegionTabla.AcceptChanges();
            if (OnRegionTablaDelete != null)
                OnRegionTablaDelete(this, ID_Region, ID_Tabla);
        }
        #endregion
        #endregion
        #region TablaCapa
        public CTabla Get_TablaCapa(int ID_Capa, int ID_Tabla)
        {
            var l = from obj1 in RelCapaTabla
                    join obj in Tabla on obj1.ID_Tabla equals obj.ID_Tabla
                    where obj1.ID_Capa == ID_Capa && obj1.ID_Tabla == ID_Tabla
                    select new
                    {
                        obj.Alto,
                        obj.Ancho,
                        obj.BKColor,
                        obj.ForeColor,
                        obj.ID_Identidad,
                        obj.ID_Tabla,
                        obj.Modo,
                        obj.Nombre,
                        obj.PK_Nombre,
                        obj1.Visible,
                        obj1.X,
                        obj1.Y,
                        obj.Comentarios
                    };
            if (l.Count() == 0)
            {
                return null;
            }
            var row = l.First();
            return new CTabla()
            {
                ID_Tabla = row.ID_Tabla,
                Alto = row.Alto,
                Ancho = row.Ancho,
                BKColor = GetColor(row.BKColor),
                ForeColor = GetColor(row.ForeColor),
                Comentarios = row.Comentarios,
                ID_Identidad = row.ID_Identidad,
                Modelo = this,
                Modo = row.Modo,
                Nombre = row.Nombre,
                PK_Nombre = row.PK_Nombre,
                Visible = row.Visible,
                X = row.X,
                Y = row.Y
            };
        }

        public void Insert_TablaCapa(int ID_Capa, int ID_Tabla, int X, int Y, bool Visible)
        {
            var l = from obj in RelCapaTabla where obj.ID_Capa == ID_Capa && obj.ID_Tabla == ID_Tabla select obj;
            if (l.Count() > 0)
            {
                if (OnCapaTablaInsert != null)
                    OnCapaTablaInsert(this, ID_Capa, ID_Tabla);
                return;
            }
            RelCapaTablaRow row = RelCapaTabla.NewRelCapaTablaRow();
            row.ID_Capa = ID_Capa;
            row.ID_Tabla = ID_Tabla;
            row.X = X;
            row.Y = Y;
            row.Visible = Visible;
            RelCapaTabla.Rows.Add(row);
            if (OnCapaTablaInsert != null)
                OnCapaTablaInsert(this, ID_Capa, ID_Tabla);
        }
        public void Delete_TablaCapa(int ID_Capa, int ID_Tabla)
        {
            var l = from obj in RelCapaTabla where obj.ID_Tabla == ID_Tabla && obj.ID_Capa == ID_Capa select obj;
            if (l.Count() == 0)
                return;
            var r = l.First();
            r.Delete();
            RelCapaTabla.AcceptChanges();
            if (OnCapaTablaDelete != null)
                OnCapaTablaDelete(this, ID_Capa, ID_Tabla);
        }
        public void Update_TablaCapa(int ID_Capa, int ID_Tabla, int X, int Y, bool Visible)
        {
            var l = from obj in RelCapaTabla where obj.ID_Capa == ID_Capa && obj.ID_Tabla == ID_Tabla select obj;
            if (l.Count() == 0)
            {
                throw new Exception("No se encuentra la tabla dentro de la capa");
            }
            var row = l.First();
            row.X = X;
            row.Y = Y;
            row.Visible = Visible;
            row.AcceptChanges();
            if (OnCapaTablaUpdate != null)
                OnCapaTablaUpdate(this, ID_Capa, ID_Tabla);
        }
        #endregion
        #region Tabla
        #region Select1
        private TablaRow Get_TablaRow(int ID_Tabla)
        {
            var l = (from obj in Tabla where obj.ID_Tabla == ID_Tabla select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CTabla Get_Tabla(int ID_Tabla)
        {
            TablaRow row = Get_TablaRow(ID_Tabla);
            if (row == null)
            {
                throw new Exception("No se encontro la tabla");
            }
            return new CTabla()
            {
                ID_Tabla = row.ID_Tabla,
                Alto = row.Alto,
                Ancho = row.Ancho,
                BKColor = GetColor(row.BKColor),
                ForeColor = GetColor(row.ForeColor),
                Comentarios = row.Comentarios,
                ID_Identidad = row.ID_Identidad,
                Modelo = this,
                Modo = row.Modo,
                Nombre = row.Nombre,
                PK_Nombre = row.PK_Nombre
            };
        }
        public CTabla Get_Tabla(string nombre)
        {
            var l = (from obj in Tabla where obj.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim() select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            var row = l.First();
            return new CTabla()
            {
                ID_Tabla = row.ID_Tabla,
                Alto = row.Alto,
                Ancho = row.Ancho,
                BKColor = GetColor(row.BKColor),
                ForeColor = GetColor(row.ForeColor),
                Comentarios = row.Comentarios,
                ID_Identidad = row.ID_Identidad,
                Modelo = this,
                Modo = row.Modo,
                Nombre = row.Nombre,
                PK_Nombre = row.PK_Nombre
            };
        }
        #endregion
        #region SelectN
        public List<CTabla> Get_TablasCapa(int ID_Capa)
        {
            List<CTabla> lista = new List<CTabla>();
            var l = from obj1 in RelCapaTabla
                    join obj in Tabla on obj1.ID_Tabla equals obj.ID_Tabla
                    where obj1.ID_Capa == ID_Capa
                    select new
                    {
                        obj.Alto,
                        obj.Ancho,
                        obj.BKColor,
                        obj.ForeColor,
                        obj.ID_Identidad,
                        obj.ID_Tabla,
                        obj.Modo,
                        obj.Nombre,
                        obj.PK_Nombre,
                        obj1.Visible,
                        obj1.X,
                        obj1.Y
                    };
            foreach (var row in l)
            {
                lista.Add(new CTabla()
                {
                    ID_Tabla = row.ID_Tabla,
                    Alto = row.Alto,
                    Ancho = row.Ancho,
                    BKColor = GetColor(row.BKColor),
                    ForeColor = GetColor(row.ForeColor),
                    //Comentarios = row.Comentarios,
                    ID_Identidad = row.ID_Identidad,
                    Modelo = this,
                    Modo = row.Modo,
                    Nombre = row.Nombre,
                    PK_Nombre = row.PK_Nombre,
                    Visible = row.Visible,
                    X = row.X,
                    Y = row.Y
                });
            }
            return lista;
        }
        public List<CTabla> Get_TablasRegion(int ID_Region)
        {
            List<CTabla> lista = new List<CTabla>();
            var l = (
                        from obj in Tabla
                        join rt in RegionTabla on obj.ID_Tabla equals rt.ID_Tabla
                        where rt.ID_Region == ID_Region
                        select obj);
            foreach (var row in l)
            {
                lista.Add(new CTabla()
                {
                    ID_Tabla = row.ID_Tabla,
                    Alto = row.Alto,
                    Ancho = row.Ancho,
                    BKColor = GetColor(row.BKColor),
                    ForeColor = GetColor(row.ForeColor),
                    Comentarios = row.Comentarios,
                    ID_Identidad = row.ID_Identidad,
                    Modelo = this,
                    Modo = row.Modo,
                    Nombre = row.Nombre,
                    PK_Nombre = row.PK_Nombre
                });
            }
            return lista;
        }
        public List<CRegion> Get_RegionesTabla(int ID_Tabla)
        {
            List<CRegion> lista = new List<CRegion>();
            var l = (
                        from obj in Region
                        join rt in RegionTabla on obj.ID_Region equals rt.ID_Region
                        where rt.ID_Tabla == ID_Tabla
                        select obj);
            foreach (var row in l)
            {
                lista.Add(new CRegion()
                {
                    Alto = row.Alto,
                    Ancho = row.Ancho,
                    ForeColor = GetColor(row.ForeColor),
                    ID_Capa = row.ID_Capa,
                    Modelo = this,
                    Modo = row.Modo,
                    Nombre = row.Nombre,
                    Visible = row.Visible,
                    X = row.X,
                    Y = row.Y,
                    ID_Region = row.ID_Region,
                    BkColor = GetColor(row.BkColor),
                    ID_RegionPadre = row.ID_RegionPadre
                });
            }
            return lista;
        }
        public CRegion Get_RegionTabla(int ID_Tabla)
        {
            var l = (
                        from obj in Region
                        join rt in RegionTabla on obj.ID_Region equals rt.ID_Region
                        where rt.ID_Tabla == ID_Tabla
                        select obj);
            foreach (var row in l)
            {
                return new CRegion()
                {
                    Alto = row.Alto,
                    Ancho = row.Ancho,
                    ForeColor = GetColor(row.ForeColor),
                    ID_Capa = row.ID_Capa,
                    Modelo = this,
                    Modo = row.Modo,
                    Nombre = row.Nombre,
                    Visible = row.Visible,
                    X = row.X,
                    Y = row.Y,
                    ID_Region = row.ID_Region,
                    BkColor = GetColor(row.BkColor),
                    ID_RegionPadre = row.ID_RegionPadre
                };
            }
            return null;
        }
        public CRegion Get_RegionTablaCapa(int ID_Capa, int ID_Tabla)
        {
            var l = (
                        from obj in Region
                        join rt in RegionTabla on obj.ID_Region equals rt.ID_Region
                        where rt.ID_Tabla == ID_Tabla && obj.ID_Capa == ID_Capa
                        select obj);
            foreach (var row in l)
            {
                return new CRegion()
                {
                    Alto = row.Alto,
                    Ancho = row.Ancho,
                    ForeColor = GetColor(row.ForeColor),
                    ID_Capa = row.ID_Capa,
                    Modelo = this,
                    Modo = row.Modo,
                    Nombre = row.Nombre,
                    Visible = row.Visible,
                    X = row.X,
                    Y = row.Y,
                    ID_Region = row.ID_Region,
                    BkColor = GetColor(row.BkColor),
                    ID_RegionPadre = row.ID_RegionPadre
                };
            }
            return null;
        }
        public List<CTabla> Get_Tablas()
        {
            List<CTabla> lista = new List<CTabla>();
            var l = (from obj in Tabla select obj);
            foreach (var row in l)
            {
                lista.Add(new CTabla()
                {
                    ID_Tabla = row.ID_Tabla,
                    Alto = row.Alto,
                    Ancho = row.Ancho,
                    BKColor = GetColor(row.BKColor),
                    ForeColor = GetColor(row.ForeColor),
                    Comentarios = row.Comentarios,
                    ID_Identidad = row.ID_Identidad,
                    Modelo = this,
                    Modo = row.Modo,
                    Nombre = row.Nombre,
                    PK_Nombre = row.PK_Nombre
                });
            }
            return lista;

        }
        #endregion
        #region Insert
        public int Insert_Tabla(string Nombre, int Ancho, int Alto, Color BKColor, string Modo, int ID_Identidad, string PK_Nombre, Color ForeColor, String Comentarios = "")
        {
            TablaRow row = Tabla.NewTablaRow();
            row.Nombre = Nombre;
            row.Ancho = Ancho;
            row.Alto = Alto;
            row.BKColor = ColorStrng(BKColor);
            row.Modo = Modo;
            row.ID_Identidad = ID_Identidad;
            row.PK_Nombre = PK_Nombre;
            row.Comentarios = Comentarios;
            row.ForeColor = ColorStrng(ForeColor);
            Tabla.AddTablaRow(row);
            Fmodificando = true;
            if (OnTablaInsert != null)
                OnTablaInsert(this, row.ID_Tabla);

            return row.ID_Tabla;
        }

        #endregion
        #region update
        public void Update_Tabla(int ID_Tabla, string Nombre, int Ancho, int Alto, Color BKColor, string Modo, int ID_Identidad, string PK_Nombre, Color ForeColor, String Comentarios)
        {
            TablaRow row = Get_TablaRow(ID_Tabla);
            if (row == null)
            {
                throw new Exception("No se encontro a tabla");
            }
            row.Nombre = Nombre;
            row.Ancho = Ancho;
            row.Alto = Alto;
            row.BKColor = ColorStrng(BKColor);
            row.Modo = Modo;
            row.ID_Identidad = ID_Identidad;
            row.PK_Nombre = PK_Nombre;
            row.Comentarios = Comentarios;
            row.ForeColor = ColorStrng(ForeColor);
            row.AcceptChanges();
            Fmodificando = true;
            if (OnTablaUpdate != null)
                OnTablaUpdate(this, ID_Tabla);
        }
        public void Move_TablaCapa(int ID_Tabla, int ID_CapaOrigen, int ID_CapaDestino)
        {
            if (ID_CapaOrigen != ID_CapaDestino)
                return;
            CRegion region = null;
            int x = 0;
            int y = 0;
            bool visible = true;
            var l1 = from obj in RelCapaTabla where obj.ID_Capa == ID_CapaOrigen && obj.ID_Tabla == ID_Tabla select obj;
            if (l1.Count() != 0)
            {
                if (ID_CapaDestino != ID_CapaOrigen)
                {
                    var row = l1.First();
                    x = row.X;
                    y = row.Y;
                    visible = row.Visible;
                    row.Delete();
                    RelCapaTabla.AcceptChanges();
                    if (OnCapaTablaDelete != null)
                        OnCapaTablaDelete(this, ID_CapaOrigen, ID_Tabla);
                }
            }
            var l2 = from obj in RelCapaTabla where obj.ID_Capa == ID_CapaDestino && obj.ID_Tabla == ID_Tabla select obj;
            if (l2.Count() == 0)
            {
                RelCapaTablaRow row1 = RelCapaTabla.NewRelCapaTablaRow();
                row1.ID_Capa = ID_CapaDestino;
                row1.ID_Tabla = ID_Tabla;
                row1.X = x;
                row1.Y = y;
                row1.Visible = visible;
                RelCapaTabla.Rows.Add(row1);
                if (OnCapaTablaInsert != null)
                    OnCapaTablaInsert(this, ID_CapaDestino, ID_Tabla);
            }
            //como se mueve a una capa, le quito la region en la que se encontraba
            region = Get_RegionTablaCapa(ID_CapaOrigen, ID_Tabla);
            if (region != null)
            {
                Delete_RegionTabla(region.ID_Region, ID_Tabla);
            }
            Fmodificando = true;
            if (OnTablaCapaMove != null)
                OnTablaCapaMove(this, ID_Tabla, ID_CapaOrigen, ID_CapaDestino);
        }
        #endregion
        #region Delete
        public void Delete_Tabla(int ID_Tabla)
        {
            TablaRow row = Get_TablaRow(ID_Tabla);
            if (row == null)
            {
                throw new Exception("No se encontro a tabla");
            }
            row.Delete();
            Tabla.AcceptChanges();
            Fmodificando = true;
            if (OnTablaDelete != null)
                OnTablaDelete(this, ID_Tabla);
        }
        #endregion
        #endregion
        #region LlaveForanea
        #region Select1
        private LlaveForaneaRow Get_LlaveForaneaRow(int ID_FK)
        {
            var l = (from obj in LlaveForanea where obj.ID_FK == ID_FK select obj);
            if (l.Count() == 0)
                return null;
            return l.First();
        }
        public CLlaveForanea Get_LlaveForanea(int ID_FK)
        {
            var row = Get_LlaveForaneaRow(ID_FK);
            if (row == null)
            {
                return null;
                //                throw new Exception("No se encontro la llave foranea");
            }
            return new CLlaveForanea()
            {
                ID_FK = row.ID_FK,
                ID_TablaHija = row.ID_TablaHija,
                ID_TablaPadre = row.ID_TablaPadre,
                LineColor = GetColor(row.LineColor),
                Modelo = this,
                Nombre = row.Nombre,
                AcctionDelete = getTipoAcction(row.AcctionDelete),
                AcctionUpdate = getTipoAcction(row.AcctionUpdate)
            };
        }
        private EnumAccionReferencial getTipoAcction(string nombre)
        {
            EnumAccionReferencial r = EnumAccionReferencial.NO_ACTION;
            if (EnumAccionReferencial.NO_ACTION.ToString() == nombre)
                r = EnumAccionReferencial.NO_ACTION;
            if (EnumAccionReferencial.CASCADE.ToString() == nombre)
                r = EnumAccionReferencial.CASCADE;
            if (EnumAccionReferencial.SET_NULL.ToString() == nombre)
                r = EnumAccionReferencial.SET_NULL;
            if (EnumAccionReferencial.SET_DEFAULT.ToString() == nombre)
                r = EnumAccionReferencial.SET_DEFAULT;
            return r;
        }

        public CLlaveForanea Get_LlaveForanea(string nombre)
        {
            var l = (from obj in LlaveForanea where obj.Nombre == nombre select obj);
            if (l.Count() == 0)
                return null;
            var row = l.First();
            return new CLlaveForanea()
            {
                ID_FK = row.ID_FK,
                ID_TablaHija = row.ID_TablaHija,
                ID_TablaPadre = row.ID_TablaPadre,
                LineColor = GetColor(row.LineColor),
                Modelo = this,
                Nombre = row.Nombre,
                AcctionDelete = getTipoAcction(row.AcctionDelete),
                AcctionUpdate = getTipoAcction(row.AcctionUpdate)
            };
        }
        #endregion
        #region SelectN
        /// <summary>
        /// regresa las ligas hacia las tablas padres de la tabla en cuestion
        /// </summary>
        /// <param name="ID_Tabla"></param>
        /// <returns></returns>
        public List<CLlaveForanea> Get_LlavesForaneasPadre(int ID_TablaPadre)
        {
            List<CLlaveForanea> lista = new List<CLlaveForanea>();
            var l = (from obj in LlaveForanea where obj.ID_TablaPadre == ID_TablaPadre select obj);
            foreach (var row in l)
            {
                lista.Add(new CLlaveForanea()
                {
                    ID_FK = row.ID_FK,
                    ID_TablaHija = row.ID_TablaHija,
                    ID_TablaPadre = row.ID_TablaPadre,
                    LineColor = GetColor(row.LineColor),
                    Modelo = this,
                    Nombre = row.Nombre,
                    AcctionDelete = getTipoAcction(row.AcctionDelete),
                    AcctionUpdate = getTipoAcction(row.AcctionUpdate)

                });
            }
            return lista;
        }
        /// <summary>
        /// regresa las ligas hacia las tablas hijas
        /// </summary>
        /// <param name="ID_Tabla"></param>
        /// <returns></returns>
        public List<CLlaveForanea> Get_LlavesForaneasHijas(int ID_TablaHija)
        {
            List<CLlaveForanea> lista = new List<CLlaveForanea>();
            var l = (from obj in LlaveForanea where obj.ID_TablaHija == ID_TablaHija select obj);
            foreach (var row in l)
            {
                lista.Add(new CLlaveForanea()
                {
                    ID_FK = row.ID_FK,
                    ID_TablaHija = row.ID_TablaHija,
                    ID_TablaPadre = row.ID_TablaPadre,
                    LineColor = GetColor(row.LineColor),
                    Modelo = this,
                    Nombre = row.Nombre,
                    AcctionDelete = getTipoAcction(row.AcctionDelete),
                    AcctionUpdate = getTipoAcction(row.AcctionUpdate)
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        public int Insert_LlaveForanea(int ID_TablaPadre, int ID_TablaHija, string Nombre, EnumAccionReferencial AcctionDelete, EnumAccionReferencial AcctionUpdate, Color LineColor)
        {
            LlaveForaneaRow row = LlaveForanea.NewLlaveForaneaRow();
            row.ID_TablaHija = ID_TablaHija;
            row.ID_TablaPadre = ID_TablaPadre;
            row.LineColor = ColorStrng(LineColor);
            row.Nombre = Nombre;
            row.AcctionDelete = AcctionDelete.ToString();
            row.AcctionUpdate = AcctionUpdate.ToString();
            LlaveForanea.AddLlaveForaneaRow(row);
            LlaveForanea.AcceptChanges();
            Fmodificando = true;
            if (OnLlaveForaneaInsert != null)
                OnLlaveForaneaInsert(this, row.ID_FK);
            return row.ID_FK;
        }
        #endregion
        #region update
        public void Update_LlaveForanea(int ID_FK, int ID_TablaPadre, int ID_TablaHija, string Nombre, EnumAccionReferencial AcctionDelete, EnumAccionReferencial AcctionUpdate, Color LineColor)
        {
            var row = Get_LlaveForaneaRow(ID_FK);
            if (row == null)
            {
                throw new Exception("No se encontro la llave foranea");
            }
            row.ID_TablaHija = ID_TablaHija;
            row.ID_TablaPadre = ID_TablaPadre;
            row.LineColor = ColorStrng(LineColor);
            row.Nombre = Nombre;
            row.AcctionDelete = AcctionDelete.ToString();
            row.AcctionUpdate = AcctionUpdate.ToString();
            row.AcceptChanges();
            Fmodificando = true;
            if (OnLlaveForaneaUpdate != null)
                OnLlaveForaneaUpdate(this, row.ID_FK);
        }
        #endregion
        #region Delete
        public void Delete_LlaveForanea(int ID_FK)
        {
            var row = Get_LlaveForaneaRow(ID_FK);
            if (row == null)
            {
                throw new Exception("No se encontro la llave foranea");
            }
            row.Delete();
            LlaveForanea.AcceptChanges();
            Fmodificando = true;
            if (OnLlaveForaneaDelete != null)
                OnLlaveForaneaDelete(this, ID_FK);
        }
        #endregion
        #endregion
        #region TipoDato
        #region Select1
        private TipoDatoRow Get_TipoDatoRow(int ID_TipoDato)
        {
            var l = (from obj in TipoDato where obj.ID_TipoDato == ID_TipoDato select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CTipoDato Get_TipoDato(int ID_TipoDato)
        {
            TipoDatoRow row = Get_TipoDatoRow(ID_TipoDato);
            if (row == null)
            {
                throw new Exception("No se encontro el tipo de dato");
            }
            return new CTipoDato()
            {
                ID_TipoDato = row.ID_TipoDato,
                Modelo = this,
                Nombre = row.Nombre,
                TipoLongitud = StringToTipo(row.TipoLongitud)
            };
        }
        public CTipoDato Get_TipoDato(string nombre)
        {
            var l = (from obj in TipoDato where obj.Nombre == nombre select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            var row = l.First();
            return new CTipoDato()
            {
                ID_TipoDato = row.ID_TipoDato,
                Modelo = this,
                Nombre = row.Nombre,
                TipoLongitud = StringToTipo(row.TipoLongitud)
            };
        }
        private TIPO_LONGITUD StringToTipo(string nombre)
        {
            TIPO_LONGITUD t = TIPO_LONGITUD.NOREQUERIDO;
            if (nombre == TIPO_LONGITUD.NOREQUERIDO.ToString())
                t = TIPO_LONGITUD.NOREQUERIDO;
            if (nombre == TIPO_LONGITUD.OBLIGATORIO.ToString())
                t = TIPO_LONGITUD.OBLIGATORIO;
            if (nombre == TIPO_LONGITUD.OPCIONAL.ToString())
                t = TIPO_LONGITUD.OPCIONAL;
            return t;
        }
        #endregion
        #region SelectN
        public List<CTipoDato> Get_TiposDatos()
        {
            List<CTipoDato> lista = new List<CTipoDato>();
            var l = (from obj in TipoDato select obj);
            foreach (var row in l)
            {
                lista.Add(
                    new CTipoDato()
                    {
                        ID_TipoDato = row.ID_TipoDato,
                        Modelo = this,
                        Nombre = row.Nombre,
                        TipoLongitud = StringToTipo(row.TipoLongitud)
                    });
            }
            return lista;
        }
        public List<CCampo> Get_CamposTipoDato(int ID_TipoDato)
        {
            List<CCampo> lista = new List<CCampo>();
            var l = (from obj in Campo where obj.ID_TipoDato == ID_TipoDato select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampo()
                {
                    AceptaNulos = row.AceptaNulos,
                    Calculado = row.Calculado,
                    DefaultName = row.DefaultName,
                    EsDefault = row.EsDefault,
                    Formula = row.Formula,
                    ID_Campo = row.ID_Campo,
                    ID_Tabla = row.ID_Tabla,
                    ID_TipoDato = row.ID_TipoDato,
                    Longitud = row.Longitud,
                    Modelo = this,
                    NombreX = row.Nombre,
                    Comentarios=row.Comentarios,    
                    Orden = row.Orden,
                    PK = row.PK
                });
            }
            return lista;
        }

        #endregion
        #region Insert
        public int Insert_TipoDato(string Nombre, TIPO_LONGITUD TipoLongitud)
        {
            TipoDatoRow row = TipoDato.NewTipoDatoRow();
            row.Nombre = Nombre;
            row.TipoLongitud = TipoLongitud.ToString();
            TipoDato.AddTipoDatoRow(row);
            Fmodificando = true;
            if (OnTipoDatoInsert != null)
                OnTipoDatoInsert(this, row.ID_TipoDato);
            return row.ID_TipoDato;
        }
        #endregion
        #region update
        public void Update_TipoDato(int ID_TipoDato, string Nombre, TIPO_LONGITUD TipoLongitud)
        {
            TipoDatoRow row = Get_TipoDatoRow(ID_TipoDato);
            if (row == null)
            {
                throw new Exception("No se encontro el tipo de dato");
            }
            row.Nombre = Nombre;
            row.TipoLongitud = TipoLongitud.ToString();
            row.AcceptChanges();
            Fmodificando = true;
            if (OnTipoDatoUpdate != null)
                OnTipoDatoUpdate(this, ID_TipoDato);
        }
        #endregion
        #region Delete
        public void Delete_TipoDato(int ID_TipoDato)
        {
            TipoDatoRow row = Get_TipoDatoRow(ID_TipoDato);
            if (row == null)
            {
                throw new Exception("No se encontro el tipo de dato");
            }
            row.Delete();
            TipoDato.AcceptChanges();
            Fmodificando = true;
            if (OnTipoDatoDelete != null)
                OnTipoDatoDelete(this, ID_TipoDato);
        }
        #endregion
        #endregion
        #region Campo
        #region Select1
        private CampoRow Get_CampoRow(int ID_Campo)
        {
            var l = (from obj in Campo where obj.ID_Campo == ID_Campo select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CCampo Get_Campo(int ID_Campo)
        {
            CampoRow row = Get_CampoRow(ID_Campo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo");
            }
            return new CCampo()
            {
                AceptaNulos = row.AceptaNulos,
                Calculado = row.Calculado,
                DefaultName = row.DefaultName,
                EsDefault = row.EsDefault,
                Formula = row.Formula,
                ID_Campo = row.ID_Campo,
                ID_Tabla = row.ID_Tabla,
                ID_TipoDato = row.ID_TipoDato,
                Longitud = row.Longitud,
                Modelo = this,
                NombreX = row.Nombre,
                Orden = row.Orden,
                PK = row.PK,
                Comentarios = row.Comentarios
            };
        }
        #endregion
        #region SelectN
        public List<CCampo> Get_CamposTabla(int ID_Tabla)
        {
            List<CCampo> lista = new List<CCampo>();
            var l = (from obj in Campo where obj.ID_Tabla == ID_Tabla select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampo()
                {
                    AceptaNulos = row.AceptaNulos,
                    Calculado = row.Calculado,
                    DefaultName = row.DefaultName,
                    EsDefault = row.EsDefault,
                    Formula = row.Formula,
                    ID_Campo = row.ID_Campo,
                    ID_Tabla = row.ID_Tabla,
                    ID_TipoDato = row.ID_TipoDato,
                    Longitud = row.Longitud,
                    Modelo = this,
                    NombreX = row.Nombre,
                    Comentarios = row.Comentarios,
                    Orden = row.Orden,
                    PK = row.PK
                }); 
            }
            return lista;
        }
        #endregion
        #region Insert
        public int Insert_Campo(string Nombre, int ID_Tabla, int ID_TipoDato, int Longitud, bool PK, bool AceptaNulos, bool Calculado, string Formula, bool EsDefault, string DefaultName, int orden, string Comentarios)
        {
            CampoRow row = Campo.NewCampoRow();
            row.Nombre = Nombre;
            row.ID_Tabla = ID_Tabla;
            row.ID_TipoDato = ID_TipoDato;
            row.Longitud = Longitud;
            row.PK = PK;
            row.AceptaNulos = AceptaNulos;
            row.Calculado = Calculado;
            row.Formula = Formula;
            row.EsDefault = EsDefault;
            row.DefaultName = DefaultName;
            row.Orden = orden;
            row.Comentarios = Comentarios;
            Campo.AddCampoRow(row);
            Fmodificando = true;
            if (OnCampoInsert != null)
                OnCampoInsert(this, row.ID_Campo);
            return row.ID_Campo;
        }
        #endregion
        #region update
        public void Update_Campo(int ID_Campo, string Nombre, int ID_Tabla, int ID_TipoDato, int Longitud, bool PK, bool AceptaNulos, bool Calculado, string Formula, bool EsDefault, string DefaultName, int orden,string Comentarios)
        {
            CampoRow row = Get_CampoRow(ID_Campo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo");
            }
            row.Nombre = Nombre;
            row.ID_Tabla = ID_Tabla;
            row.ID_TipoDato = ID_TipoDato;
            row.Longitud = Longitud;
            row.PK = PK;
            row.AceptaNulos = AceptaNulos;
            row.Calculado = Calculado;
            row.Formula = Formula;
            row.EsDefault = EsDefault;
            row.DefaultName = DefaultName;
            row.Orden = orden;
            row.Comentarios = Comentarios;
            row.AcceptChanges();
            Fmodificando = true;
            if (OnCampoUpdate != null)
                OnCampoUpdate(this, ID_Campo);
        }
        #endregion
        #region Delete
        public void Delete_Campo(int ID_Campo)
        {
            CampoRow row = Get_CampoRow(ID_Campo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo");
            }
            row.Delete();
            Campo.AcceptChanges();
            Fmodificando = true;
            if (OnCampoDelete != null)
                OnCampoDelete(this, ID_Campo);
        }
        #endregion
        #endregion
        #region Unique
        #region Select1
        private UniqueRow Get_UniqueRow(int ID_Unique)
        {
            var l = (from obj in Unique where obj.ID_Unique == ID_Unique select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CUnique Get_Unique(int ID_Unique)
        {
            UniqueRow row = Get_UniqueRow(ID_Unique);
            if (row == null)
            {
                throw new Exception("No se encontro el unique");
            }
            return new CUnique()
            {
                ID_Tabla = row.ID_Tabla,
                ID_Unique = row.ID_Unique,
                Modelo = this,
                Nombre = row.Nombre
            };
        }
        #endregion
        #region SelectN
        public List<CUnique> Get_UniquesTabla(int ID_Tabla)
        {
            List<CUnique> lista = new List<CUnique>();
            var l = (from obj in Unique where obj.ID_Tabla == ID_Tabla select obj);
            foreach (var row in l)
            {
                lista.Add(
                    new CUnique()
                    {
                        ID_Tabla = row.ID_Tabla,
                        ID_Unique = row.ID_Unique,
                        Modelo = this,
                        Nombre = row.Nombre
                    });
            }
            return lista;
        }
        #endregion
        #region Insert
        public void Insert_Unique(int ID_Tabla, string Nombre)
        {
            UniqueRow row = Unique.NewUniqueRow();
            row.ID_Tabla = ID_Tabla;
            row.Nombre = Nombre;
            Unique.AddUniqueRow(row);
            Fmodificando = true;
            if (OnUniqueInsert != null)
                OnUniqueInsert(this, row.ID_Unique);
        }
        #endregion
        #region update
        public void Update_Unique(int ID_Unique, int ID_Tabla, string Nombre)
        {
            UniqueRow row = Get_UniqueRow(ID_Unique);
            if (row == null)
            {
                throw new Exception("No se encontro el unique");
            }
            row.ID_Tabla = ID_Tabla;
            row.Nombre = Nombre;
            row.AcceptChanges();
            Fmodificando = true;
            if (OnUniqueUpdate != null)
                OnUniqueUpdate(this, ID_Unique);
        }
        #endregion
        #region Delete
        public void Delete_Unique(int ID_Unique)
        {
            UniqueRow row = Get_UniqueRow(ID_Unique);
            if (row == null)
            {
                throw new Exception("No se encontro el unique");
            }
            row.Delete();
            Unique.AcceptChanges();
            Fmodificando = true;
            if (OnUniqueDelete != null)
                OnUniqueDelete(this, ID_Unique);
        }
        #endregion
        #endregion
        #region Index
        #region Select1
        private IndexRow Get_IndexRow(int ID_Index)
        {
            var l = (from obj in Index where obj.ID_Index == ID_Index select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CIndex Get_Index(int ID_Index)
        {
            IndexRow row = Get_IndexRow(ID_Index);
            if (row == null)
            {
                throw new Exception("No se encontro el Index");
            }
            return new CIndex()
            {
                ID_Index = row.ID_Index,
                ID_Tabla = row.ID_Tabla,
                Modelo = this,
                Nombre = row.Nombre
            };
        }
        public CIndex Get_Index(string nombre)
        {
            var l = (from obj in Index where obj.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim() select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            var row = l.First();
            return new CIndex()
            {
                ID_Index = row.ID_Index,
                ID_Tabla = row.ID_Tabla,
                Modelo = this,
                Nombre = row.Nombre
            };
        }
        #endregion
        #region SelectN
        public List<CIndex> Get_IndexTabla(int ID_Tabla)
        {
            List<CIndex> lista = new List<CIndex>();
            var l = (from obj in Index where obj.ID_Tabla == ID_Tabla select obj);
            foreach (var row in l)
            {
                lista.Add(new CIndex()
                {
                    ID_Index = row.ID_Index,
                    ID_Tabla = row.ID_Tabla,
                    Modelo = this,
                    Nombre = row.Nombre
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        public int Insert_Index(string Nombre, int ID_Tabla)
        {
            IndexRow row = Index.NewIndexRow();
            row.Nombre = Nombre;
            row.ID_Tabla = ID_Tabla;
            Index.AddIndexRow(row);
            Fmodificando = true;
            if (OnIndexInsert != null)
                OnIndexInsert(this, row.ID_Index);
            return row.ID_Index;

        }
        #endregion
        #region update
        public void Update_Index(int ID_Index, string Nombre, int ID_Tabla)
        {
            IndexRow row = Get_IndexRow(ID_Index);
            if (row == null)
            {
                throw new Exception("No se encontro el Index");
            }
            row.Nombre = Nombre;
            row.ID_Tabla = ID_Tabla;
            row.AcceptChanges();
            Fmodificando = true;
            if (OnIndexUpdate != null)
                OnIndexUpdate(this, ID_Index);
        }
        #endregion
        #region Delete
        public void Delete_Index(int ID_Index)
        {
            IndexRow row = Get_IndexRow(ID_Index);
            if (row == null)
            {
                throw new Exception("No se encontro el Index");
            }
            row.Delete();
            Index.AcceptChanges();
            Fmodificando = true;
            if (OnIndexDelete != null)
                OnIndexDelete(this, ID_Index);
        }
        #endregion
        #endregion
        #region Check
        #region Select1
        private CheckRow Get_CheckRow(int ID_Check)
        {
            var l = (from obj in Check where obj.ID_Check == ID_Check select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CCheck Get_Check(int ID_Check)
        {
            CheckRow row = Get_CheckRow(ID_Check);
            if (row == null)
            {
                throw new Exception("No se encontro el check");
            }
            return new CCheck()
            {
                ID_Check = row.ID_Check,
                ID_Tabla = row.ID_Tabla,
                Modelo = this,
                Nombre = row.Nombre,
                Regla = row.Regla
            };
        }
        #endregion
        #region SelectN
        public List<CCheck> Get_ChecksTabla(int ID_Tabla)
        {
            List<CCheck> lista = new List<CCheck>();
            var l = (from obj in Check where obj.ID_Tabla == ID_Tabla select obj);
            foreach (var row in l)
            {
                lista.Add(new CCheck()
                {
                    ID_Check = row.ID_Check,
                    ID_Tabla = row.ID_Tabla,
                    Modelo = this,
                    Nombre = row.Nombre,
                    Regla = row.Regla
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        public void Insert_Check(string Nombre, string Regla, int ID_Tabla)
        {
            CheckRow row = Check.NewCheckRow();
            row.Nombre = Nombre;
            row.Regla = Regla;
            row.ID_Tabla = ID_Tabla;
            Check.AddCheckRow(row);
            Fmodificando = true;
            if (OnCheckInsert != null)
                OnCheckInsert(this, row.ID_Check);

        }
        #endregion
        #region update
        public void Update_Check(int ID_Check, string Nombre, string Regla, int ID_Tabla)
        {
            CheckRow row = Get_CheckRow(ID_Check);
            if (row == null)
            {
                throw new Exception("No se encontro el check");
            }
            row.Nombre = Nombre;
            row.Regla = Regla;
            row.ID_Tabla = ID_Tabla;
            row.AcceptChanges();
            Fmodificando = true;
            if (OnCheckUpdate != null)
                OnCheckUpdate(this, ID_Check);

        }
        #endregion
        #region Delete
        public void Delete_Check(int ID_Check)
        {
            CheckRow row = Get_CheckRow(ID_Check);
            if (row == null)
            {
                throw new Exception("No se encontro el check");
            }
            row.Delete();
            Check.AcceptChanges();
            Fmodificando = true;
            if (OnCheckDelete != null)
                OnCheckDelete(this, ID_Check);
        }
        #endregion
        #endregion
        #region LineaFK
        #region Select1
        private LineaFKRow Get_LineaFKRow(int ID_LineaFk)
        {
            var l = (from obj in LineaFK where obj.ID_LineaFk == ID_LineaFk select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CLineaFK Get_LineaFK(int ID_LineaFk)
        {
            LineaFKRow row = Get_LineaFKRow(ID_LineaFk);
            if (row == null)
            {
                throw new Exception("No se encontro la lineaFK");
            }
            return new CLineaFK()
            {
                ID_FK = row.ID_FK,
                XI = row.XI,
                YI = row.YI,
                XF = row.XF,
                YF = row.YF,
                Orden = row.Orden,
                ID_LineaFk = row.ID_LineaFk,
                Modelo = this
            };
        }
        #endregion
        #region SelectN
        public List<CLineaFK> Get_LineasFk(int ID_FK)
        {
            List<CLineaFK> lista = new List<CLineaFK>();
            var l = (from obj in LineaFK where obj.ID_FK == ID_FK select obj);
            foreach (var row in l)
            {
                lista.Add(new CLineaFK()
                {
                    ID_FK = row.ID_FK,
                    XI = row.XI,
                    YI = row.YI,
                    XF = row.XF,
                    YF = row.YF,
                    Orden = row.Orden,
                    ID_LineaFk = row.ID_LineaFk,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        public void Insert_LineaFK(int ID_FK, int XI, int YI, int XF, int YF, int Orden)
        {
            LineaFKRow row = LineaFK.NewLineaFKRow();
            row.ID_FK = ID_FK;
            row.XI = XI;
            row.YI = YI;
            row.XF = XF;
            row.YF = YF;
            row.Orden = Orden;
            LineaFK.AddLineaFKRow(row);
            Fmodificando = true;
            if (OnLineaFKInsert != null)
                OnLineaFKInsert(this, row.ID_LineaFk);
        }
        #endregion
        #region update
        public void Update_LineaFK(int ID_FK, int XI, int YI, int XF, int YF, int Orden, int ID_LineaFk)
        {
            LineaFKRow row = Get_LineaFKRow(ID_LineaFk);
            if (row == null)
            {
                throw new Exception("No se encontro la lineaFK");
            }
            row.ID_FK = ID_FK;
            row.XI = XI;
            row.YI = YI;
            row.XF = XF;
            row.YF = YF;
            row.Orden = Orden;
            row.AcceptChanges();
            Fmodificando = true;
            if (OnLineaFKUpdate != null)
                OnLineaFKUpdate(this, ID_LineaFk);
        }
        #endregion
        #region Delete
        public void Delete_LineaFK(int ID_LineaFk)
        {
            LineaFKRow row = Get_LineaFKRow(ID_LineaFk);
            if (row == null)
            {
                throw new Exception("No se encontro la lineaFK");
            }
            row.Delete();
            LineaFK.AcceptChanges();
            Fmodificando = true;
            if (OnLineaFKDelete != null)
                OnLineaFKDelete(this, ID_LineaFk);
        }
        #endregion
        #endregion
        #region CampoUnique
        #region Select1
        private CampoUniqueRow Get_CampoUniqueRow(int ID_Unique, int ID_Campo)
        {
            var l = (from obj in CampoUnique where obj.ID_Campo == ID_Campo && obj.ID_Unique == ID_Unique select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CCampoUnique Get_CampoUnique(int ID_Unique, int ID_Campo)
        {
            CampoUniqueRow row = Get_CampoUniqueRow(ID_Unique, ID_Campo);
            if (row == null)
            {
                throw new Exception("no se encontro el campo unique");
            }
            return new CCampoUnique()
            {
                ID_Campo = row.ID_Campo,
                ID_Unique = row.ID_Unique,
                Modelo = this
            };
        }
        #endregion
        #region SelectN
        public List<CCampoUnique> Get_CamposUnique(int ID_Unique)
        {
            List<CCampoUnique> lista = new List<CCampoUnique>();
            var l = (from obj in CampoUnique where obj.ID_Unique == ID_Unique select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampoUnique()
                {
                    ID_Campo = row.ID_Campo,
                    ID_Unique = row.ID_Unique,
                    Modelo = this
                });
            }
            return lista;
        }
        public List<CCampoUnique> Get_UniquesCampo(int ID_Campo)
        {
            List<CCampoUnique> lista = new List<CCampoUnique>();
            var l = (from obj in CampoUnique where obj.ID_Campo == ID_Campo select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampoUnique()
                {
                    ID_Campo = row.ID_Campo,
                    ID_Unique = row.ID_Unique,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        public void Insert_CampoUnique(int ID_Unique, int ID_Campo)
        {
            CampoUniqueRow row = CampoUnique.NewCampoUniqueRow();
            row.ID_Campo = ID_Campo;
            row.ID_Unique = ID_Unique;
            CampoUnique.AddCampoUniqueRow(row);
            Fmodificando = true;
            if (OnCampoUniqueInsert != null)
                OnCampoUniqueInsert(this, ID_Unique, ID_Campo);
        }
        #endregion
        #region Delete
        public void Delete_CampoUnique(int ID_Unique, int ID_Campo)
        {
            CampoUniqueRow row = Get_CampoUniqueRow(ID_Unique, ID_Campo);
            if (row == null)
            {
                throw new Exception("no se encontro el campo unique");
            }
            row.AcceptChanges();
            Fmodificando = true;
            if (OnCampoUniqueDelete != null)
                OnCampoUniqueDelete(this, ID_Unique, ID_Campo);
        }
        #endregion
        #endregion
        #region CampoIndex
        #region Select1
        private CampoIndexRow get_CampoIndexRow(int ID_Index, int ID_Campo)
        {
            var l = (from obj in CampoIndex where obj.ID_Index == ID_Index && obj.ID_Campo == ID_Campo select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CCampoIndex Get_CampoIndex(int ID_Index, int ID_Campo)
        {
            CampoIndexRow row = get_CampoIndexRow(ID_Index, ID_Campo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo index");
            }
            return new CCampoIndex()
            {
                Descendente = row.Descendente,
                ID_Campo = row.ID_Campo,
                ID_Index = row.ID_Index,
                Modelo = this
            };
        }
        public List<CCampoIndex> Get_IndexsCampo(int ID_Campo)
        {
            List<CCampoIndex> lista = new List<CCampoIndex>();
            var l = (from obj in CampoIndex where obj.ID_Campo == ID_Campo select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampoIndex()
                {
                    Descendente = row.Descendente,
                    ID_Campo = row.ID_Campo,
                    ID_Index = row.ID_Index,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region SelectN
        public List<CCampoIndex> Get_CamposIndex(int ID_Index)
        {
            List<CCampoIndex> lista = new List<CCampoIndex>();
            var l = (from obj in CampoIndex where obj.ID_Index == ID_Index select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampoIndex()
                {
                    Descendente = row.Descendente,
                    ID_Campo = row.ID_Campo,
                    ID_Index = row.ID_Index,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        public void Insert_CampoIndex(int ID_Index, int ID_Campo, bool Descendente)
        {
            CampoIndexRow row = CampoIndex.NewCampoIndexRow();
            row.Descendente = Descendente;
            row.ID_Campo = ID_Campo;
            row.ID_Index = ID_Index;
            CampoIndex.AddCampoIndexRow(row);
            Fmodificando = true;
            if (OnCampoIndexInsert != null)
            {
                OnCampoIndexInsert(this, ID_Index, ID_Campo);
            }
        }
        #endregion
        #region update
        public void Update_CampoIndex(int ID_Index, int ID_Campo, bool Descendente)
        {
            CampoIndexRow row = get_CampoIndexRow(ID_Index, ID_Campo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo index");
            }
            row.Descendente = Descendente;
            row.AcceptChanges();
            Fmodificando = true;
            if (OnCampoIndexUpdate != null)
                OnCampoIndexUpdate(this, ID_Index, ID_Campo);

        }
        #endregion
        #region Delete
        public void Delete_CampoIndex(int ID_Index, int ID_Campo)
        {
            CampoIndexRow row = get_CampoIndexRow(ID_Index, ID_Campo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo index");
            }
            row.Delete();
            CampoIndex.AcceptChanges();
            Fmodificando = true;
            if (OnCampoIndexDelete != null)
                OnCampoIndexDelete(this, ID_Index, ID_Campo);

        }
        #endregion
        #endregion
        #region CampoReferencia
        #region Select1
        private CampoReferenciaRow Get_CampoReferenciaRow(int ID_FK, int ID_CampoPadre, int ID_CampoHijo)
        {
            var l = (from obj in CampoReferencia where obj.ID_FK == ID_FK && obj.ID_CampoPadre == ID_CampoPadre && obj.ID_CampoHijo == ID_CampoHijo select obj);
            if (l.Count() == 0)
            {
                return null;
            }
            return l.First();
        }
        public CCampoReferencia Get_CampoReferencia(int ID_FK, int ID_CampoPadre, int ID_CampoHijo)
        {
            CampoReferenciaRow row = Get_CampoReferenciaRow(ID_FK, ID_CampoPadre, ID_CampoHijo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo referencia");
            }
            return new CCampoReferencia()
            {
                ID_CampoHijo = row.ID_CampoHijo,
                ID_CampoPadre = row.ID_CampoPadre,
                ID_FK = row.ID_FK,
                Modelo = this
            };
        }
        #endregion
        #region SelectN
        public List<CCampoReferencia> Get_CamposReferencia(int ID_FK)
        {
            List<CCampoReferencia> lista = new List<CCampoReferencia>();
            var l = (from obj in CampoReferencia where obj.ID_FK == ID_FK select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampoReferencia()
                {
                    ID_CampoHijo = row.ID_CampoHijo,
                    ID_CampoPadre = row.ID_CampoPadre,
                    ID_FK = row.ID_FK,
                    Modelo = this
                });
            }
            return lista;
        }
        public List<CCampoReferencia> Get_ReferenciasCampo(int ID_Campo)
        {
            List<CCampoReferencia> lista = new List<CCampoReferencia>();
            var l = (from obj in CampoReferencia where obj.ID_CampoHijo == ID_Campo || obj.ID_CampoPadre == ID_Campo select obj);
            foreach (var row in l)
            {
                lista.Add(new CCampoReferencia()
                {
                    ID_CampoHijo = row.ID_CampoHijo,
                    ID_CampoPadre = row.ID_CampoPadre,
                    ID_FK = row.ID_FK,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region update
        public void Insert_CampoReferencia(int ID_FK, int ID_CampoPadre, int ID_CampoHijo)
        {
            CampoReferenciaRow row = CampoReferencia.NewCampoReferenciaRow();
            row.ID_CampoHijo = ID_CampoHijo;
            row.ID_CampoPadre = ID_CampoPadre;
            row.ID_FK = ID_FK;
            CampoReferencia.AddCampoReferenciaRow(row);
            Fmodificando = true;
            if (OnCampoReferenciaInsert != null)
                OnCampoReferenciaInsert(this, ID_FK, ID_CampoPadre, ID_CampoHijo);
        }
        #endregion
        #region Delete
        public void Delete_CampoReferencia(int ID_FK, int ID_CampoPadre, int ID_CampoHijo)
        {
            CampoReferenciaRow row = Get_CampoReferenciaRow(ID_FK, ID_CampoPadre, ID_CampoHijo);
            if (row == null)
            {
                throw new Exception("No se encontro el campo referencia");
            }
            row.Delete();
            CampoReferencia.AcceptChanges();
            Fmodificando = true;
            if (OnCampoReferenciaDelete != null)
                OnCampoReferenciaDelete(this, ID_FK, ID_CampoPadre, ID_CampoHijo);
        }
        #endregion
        #endregion
        #endregion
        #region Manejo de nivel general
        private string FFileName = "";
        private bool Fmodificando;
        public bool Modificado
        {
            get
            {
                return Fmodificando;
            }
        }
        /// <summary>
        /// nombre del archivo donde se almacena el modelo
        /// </summary>
        public string FileName
        {
            get
            {
                return FFileName;
            }
            set
            {
                FFileName = value;
                if (OnFileNameChange != null)
                    OnFileNameChange(this);
            }
        }
        /// <summary>
        /// hace una copia de seguridad
        /// </summary>
        private void Bakup()
        {
            try
            {
                string nombre = FFileName.Substring(0, FFileName.IndexOf('.')) + "_" + System.DateTime.Now.ToString("ddMMyyyy") + ".bak";
                WriteXml(nombre);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// regresa el nombre del archivo del proyecto sin ruta ni extencion
        /// </summary>
        /// <returns></returns>
        public string getNombreCorto()
        {
            if (FileName.Trim() == "")
                return "";
            //separo por diagonales
            string[] txt = FFileName.Split('\\');
            //separo la extencion
            string[] txt2 = txt[txt.Length - 1].Split('.');
            return txt2[0];
        }
        /// <summary>
        /// inicializa el modelo para trabajar con datos limpios
        /// </summary>
        public void Nuevo()
        {
            //asigno el nuevo nombre
            FileName = "Modelo";
            // limpio los datos
            Clear();
            if (OnNuevo != null)
                OnNuevo(this);
            Inicializa();
        }
        /// <summary>
        /// abre un archivo
        /// </summary>
        /// <param name="fileName"></param>
        public void Abrir(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("No existe el archivo");
            }
            FileName = fileName;
            Clear();
            ReadXml(FFileName);
            if (OnAbrir != null)
                OnAbrir(this);
            Fmodificando = false;
        }
        public void Inicializa()
        {
            Insert_Capa("Principal", true);
            Fmodificando = false;
        }
        public void Cerrar()
        {

        }
        public void Guardar()
        {
            try
            {
                if (FFileName == "")
                {
                    throw new Exception("Falta el nombre del archivo");
                }
                WriteXml(FFileName);
                //ahora almaceno el bakup
                Bakup();
                Fmodificando = false;
            }
            catch (System.Exception ex)
            {
                Fmodificando = false;
                return;
            }
        }
        #endregion
        /// <summary>
        /// Guarda el modelo en el archivo
        /// </summary>
        /// 
        private void Actualiza()
        {
            /*
            try
            {
                if (FFileName != "")
                {
                    WriteXml(FFileName);
                    //ahora almaceno el bakup
                    Bakup();
                }
                Fmodificando = false;
            }
            catch (System.Exception ex)
            {
                Fmodificando = false;
                return;
            }
            */
        }
    }
}
