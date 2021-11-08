using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerConnect;
using MotorDB;

namespace Modelador.Dibujable
{
    public class DRegion : DDimencionable
    {
        public event BuscaTablaDelegate OnBuscaTabla;
        public event OnPosisionRealDelegate OnGetPosicionReal;

        Modelo.CRegion Region;
        public int ID_Region
        {
            get;
            set;
        }
        public DCapa CapaPadre
        {
            get;
            set;
        }
        public DRegion RegionPadre
        {
            get;
            set;
        }
        protected override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Region = Modelo.Get_Region(ID_Region);
            CargaCaracteristicas();
            Modelo.OnRegionUpdate += new Modelo.DelegateModeloDatosEvent(RegionUpdate);
            Modelo.OnMoveRegionCapa += new DelegateModeloDatosEvent3(MoveRegionCapa);
            Modelo.OnMoveRegionRegion += new DelegateModeloDatosEvent3(MoveRegionRegion);
            Modelo.OnRegionInsert += new DelegateModeloDatosEvent(RegionInsert);
            Modelo.OnTablaInsert += new Modelo.DelegateModeloDatosEvent(TablaInsert);
            Modelo.OnTablaDelete += new Modelo.DelegateModeloDatosEvent(TablaDelete);
            Modelo.OnRegionDelete += new Modelo.DelegateModeloDatosEvent(RegionDelete);
            //tablas
            Modelo.OnRegionTablaDelete += new DelegateModeloDatosEvent2(RegionTablaDelete);
            Modelo.OnRegionTablaInsert += new DelegateModeloDatosEvent2(RegionTablaInsert);
            CargaRegiones();
            Cargatablas();
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnRegionUpdate -= RegionUpdate;
            Modelo.OnMoveRegionCapa -= MoveRegionCapa;
            Modelo.OnMoveRegionRegion -= MoveRegionRegion;
            Modelo.OnRegionInsert -= RegionInsert;
            Modelo.OnTablaInsert -= TablaInsert;
            Modelo.OnTablaDelete -= TablaDelete;
            Modelo.OnRegionDelete -= RegionDelete;
            Modelo.OnRegionTablaDelete -= RegionTablaDelete;
            Modelo.OnRegionTablaInsert -= RegionTablaInsert;
        }
        private void CargaCaracteristicas()
        {
            BarraTitulo.Titulo = Region.Nombre;
            BarraTitulo.ColorFondo = Brushes.DarkSlateBlue;
            BarraTitulo.ColorTexto = new SolidBrush(Region.ForeColor);

            Posicion = new System.Drawing.Point(Region.X, Region.Y);
            Dimencion = new System.Drawing.Size(Region.Ancho, Region.Alto);
            HareaTrabajo.ColorFondo = new SolidBrush(Region.BkColor);
        }
        private void RegionUpdate(Modelo.ModeloDatos modelo, int id_region)
        {
            if (ID_Region == id_region)
            {
                Region = Modelo.Get_Region(ID_Region);
                CargaCaracteristicas();
                Redibuja();
            }
        }
        protected override void OnFinMove()
        {
            base.OnFinMove();
            //actalizo la nueva posicion
            Region.X = Posicion.X;
            Region.Y = Posicion.Y;
            Region.Update();
        }
        public override bool IsVisible()
        {
            bool ok = Region.Visible && CapaPadre.Visible;
            if (RegionPadre != null)
                ok = ok && RegionPadre.IsVisible();
            return ok;
        }
        protected override void Redimencionado()
        {
            base.Redimencionado();
            Region.X = Posicion.X;
            Region.Y = Posicion.Y;
            Region.Ancho = Dimencion.Width;
            Region.Alto = Dimencion.Height;
            Region.Update();
        }
        private void CargaRegiones()
        {
            List<Modelo.CRegion> regiones = Region.Get_Regiones();
            foreach (Modelo.CRegion region in regiones)
            {
                DRegion dregion = new DRegion();
                dregion.ID_Region = region.ID_Region;
                dregion.CapaPadre = this.CapaPadre;
                dregion.RegionPadre = this;
                dregion.OnBuscaTabla += OnBuscaTabla;
                dregion.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
                dregion.Modelo = Modelo;
                dregion.OnMouseCapture += new CObjetoDibujableDelegate(MouseCapture);
                dregion.OnMouseFree += new CObjetoDibujableDelegate(LiberaRaon);
                dregion.OnRedibuja += new CObjetoDibujableDelegate(Redibuja);
                dregion.OnEstoyAlFrente += new CObjetoDibujableDelegate2(EstaAlFrente);
                dregion.OnChangeCursor += new CObjetoDibujableDelegateCurdor(CambiaCursor);

                hijos.Add(dregion);
                AgregaObjetoControl(dregion);
            }
        }
        private void CambiaCursor(CObjetoDibujable obj, Cursor cursor)
        {
            CmbiaCursor(cursor);
        }

        private bool EstaAlFrente(CObjetoDibujable obj)
        {
            if (hijos.Count > 0)
            {
                if (hijos[hijos.Count - 1] == obj)
                    return true;
            }
            return false;

        }

        private void Redibuja(CObjetoDibujable sender)
        {
            Redibuja();
        }
        public override void Dibuja(MiGraphics graphics)
        {
            if (IsVisible())
            {
                base.Dibuja(graphics);
                //dibujo las tablas primero
                DibujaTablas(graphics);
            }
        }
        public void DibujaTablas(MiGraphics graphics)
        {
            if (IsVisible())
            {
                MiGraphics graphics2 = new MiGraphics(Dimencion.Width, Dimencion.Height - BarraTitulo.Dimencion.Height);
                graphics2.Flush();
                foreach (CObjetoDibujable obj in hijos)
                {
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa tabla = (DTablaCapa)obj;
                        tabla.Dibuja(graphics2);
                        //dibujo sus laves foraneas
                        tabla.DibujaFinal(graphics);
                    }
                    if (obj.GetType() == typeof(DRegion))

                    {
                        DRegion region = (DRegion)obj;
                        region.Dibuja(graphics2);
                    }
                }
                graphics.DrawImage(graphics2.GetBitMap(), HareaTrabajo.Posicion.X, HareaTrabajo.Posicion.Y);
            }
        }

        protected override void DibujaHijos(MiGraphics graphics)
        {
            if (IsVisible())
            {
                MiGraphics graphics2 = HareaTrabajo.GetGrafics();
                SolidBrush s = (SolidBrush)HareaTrabajo.ColorFondo;
                graphics2.Clear(s.Color);
                base.DibujaHijos(graphics2);
                graphics.DrawImage(graphics2.GetBitMap(), HareaTrabajo.Posicion.X, HareaTrabajo.Posicion.Y);
            }
        }
        private void MoveRegionCapa(ModeloDatos modelo, int ID_Region, int ID_CapaOrigen, int ID_CapaDestino)
        {
            //como se movio de una regio a una capa, hay que quitarlo de los hijos
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DRegion))
                {
                    DRegion region = (DRegion)obj;
                    if (region.ID_Region == ID_Region)
                    {
                        hijos.Remove(obj);
                        Redibuja();
                        return;
                    }
                }
            }
        }
        private void MoveRegionRegion(ModeloDatos modelo, int id_region, int id_regionOrigen, int id_regionDestino)
        {
            if (id_regionOrigen == ID_Region)
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
            if (id_regionDestino == ID_Region)
            {
                //hay que agregarlo
                RegionInsert(Modelo, id_region);
            }
        }
        private void RegionInsert(ModeloDatos modelo, int id_Region)
        {
            CRegion region = Modelo.Get_Region(id_Region);
            if (region.ID_RegionPadre == this.ID_Region)
            {
                DRegion dregion = new DRegion();
                dregion.ID_Region = region.ID_Region;
                dregion.CapaPadre = this.CapaPadre;
                dregion.RegionPadre = this;
                dregion.OnBuscaTabla += OnBuscaTabla;
                dregion.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
                dregion.Modelo = Modelo;
                dregion.OnMouseCapture += new CObjetoDibujableDelegate(MouseCapture);
                dregion.OnMouseFree += new CObjetoDibujableDelegate(LiberaRaon);
                dregion.OnRedibuja += new CObjetoDibujableDelegate(Redibuja);
                dregion.OnEstoyAlFrente += new CObjetoDibujableDelegate2(EstaAlFrente);
                dregion.OnChangeCursor += new CObjetoDibujableDelegateCurdor(CambiaCursor);
                hijos.Add(dregion);
                AgregaObjetoControl(dregion);
                Redibuja();
            }
        }
        private Point GetPosicionReal(DRectangulo obj)
        {
            Point pos = Posicion;
            //me traigo mi posicion real
            if (OnGetPosicionReal != null)
                pos = OnGetPosicionReal(this);
            return new Point(pos.X + obj.Posicion.X, pos.Y + obj.Posicion.Y+BarraTitulo.Dimencion.Height);
        }

        #region Manejo del raton
        CObjetoDibujable TieneRaton;

        public override bool OnMouseDown(object sender, MouseEventArgs e, int x, int y)
        {
            if (base.OnMouseDown(sender, e, x, y))
            {
                if (HareaTrabajo.OnMouseIn(x, y) == false)
                    return true;
            }
            int mx = x - Posicion.X;
            int my = y - Posicion.Y - BarraTitulo.Dimencion.Height;
            //hago el recorrido desde el masal frente hacia el que esta mas atraz
            for (int i = hijos.Count; i > 0; i--)
            {
                CObjetoDibujable obj = (CObjetoDibujable)hijos[i - 1];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseDown(sender, e, mx, my) == true)
                        {
                            //lo paso al frente
                            hijos.Remove(obj);
                            hijos.Add(obj);
                            Redibuja();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public override bool OnMouseMove(object sender, MouseEventArgs e, int x, int y)
        {
            if (base.OnMouseMove(sender, e, x, y))
            {
                if (HareaTrabajo.OnMouseIn(x, y) == false)
                    return true;
            }
            int mx = x - Posicion.X;
            int my = y - Posicion.Y - BarraTitulo.Dimencion.Height;
            if (TieneRaton != null)
            {
                if (TieneRaton.IsVisible())
                {
                    if (TieneRaton.OnMouseMove(sender, e, mx, my) == true)
                    {
                        Redibuja();
                        return true;
                    }
                }
            }
            for (int i = hijos.Count - 1; i >= 0; i--)
            {
                CObjetoDibujable obj = (CObjetoDibujable)hijos[i];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseMove(sender, e, mx, my) == true)
                        {
                            return true;
                        }
                    }
                }
            }
            //CmbiaCursor(Cursors.Default);
            return true;
        }
        public CRegion GetRegion()
        {
            return Modelo.Get_Region(ID_Region);
        }

        public override bool OnMouseUp(object sender, MouseEventArgs e, int x, int y)
        {
            if (base.OnMouseUp(sender, e, x, y))
            {
                if (HareaTrabajo.OnMouseIn(x, y) == false)
                    return true;
            }
            int mx = x - Posicion.X;
            int my = y - Posicion.Y - BarraTitulo.Dimencion.Height;
            for (int i = hijos.Count; i > 0; i--)
            {
                CObjetoDibujable obj = (CObjetoDibujable)hijos[i - 1];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseUp(sender, e, mx, my) == true)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void MouseCapture(CObjetoDibujable objeto)
        {
            TieneRaton = objeto;
            CapturaMouse();
        }
        private void LiberaRaon(CObjetoDibujable objeto)
        {
            TieneRaton = null;
            LiberaRaton();
        }

        #endregion
        #region manejo de tablas
        private void Cargatablas()
        {
            Modelo.CRegion region = Modelo.Get_Region(ID_Region);
            List<Modelador.Modelo.CTabla> tablas = Region.Get_Tablas();
            foreach (Modelador.Modelo.CTabla tabla in tablas)
            {
                //veo si no esta dentro de una region
                DTablaCapa obj = new DTablaCapa();
                obj.ID_Tabla = tabla.ID_Tabla;
                obj.ID_Capa = region.ID_Capa;
                obj.OnBuscaTabla += OnBuscaTabla;
                obj.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
                obj.CapaPadre = this.CapaPadre;
                obj.Modelo = Modelo;
                obj.RegionPadre = this;
                obj.OnMouseCapture += new CObjetoDibujableDelegate(MouseCapture);
                obj.OnMouseFree += new CObjetoDibujableDelegate(LiberaRaon);
                obj.OnRedibuja += new CObjetoDibujableDelegate(Redibuja);
                obj.OnEstoyAlFrente += new CObjetoDibujableDelegate2(EstaAlFrente);
                obj.OnChangeCursor += new CObjetoDibujableDelegateCurdor(CambiaCursor);

                hijos.Add(obj);
                AgregaObjetoControl(obj);
            }
        }
        private void TablaInsert(Modelo.ModeloDatos modelo, int id_tabla)
        {
            Modelo.CRegion region = Modelo.Get_Region(ID_Region);
            Modelador.Modelo.CTabla tabla = Modelo.Get_TablaCapa(region.ID_Capa, id_tabla);
            if (tabla == null)
                return;
            Modelo.CRegion reg =Modelo.Get_RegionTablaCapa(region.ID_Capa, tabla.ID_Tabla);
            if (reg == null)
                return;
            if (reg.ID_Region == ID_Region)
            {
                DTablaCapa obj = new DTablaCapa();
                obj.ID_Tabla = tabla.ID_Tabla;
                obj.ID_Capa = region.ID_Capa;
                obj.OnBuscaTabla += OnBuscaTabla;
                obj.OnGetPosicionReal += new OnPosisionRealDelegate(GetPosicionReal);
                obj.CapaPadre = this.CapaPadre;
                obj.Modelo = Modelo;
                obj.RegionPadre = this;
                obj.OnMouseCapture += new CObjetoDibujableDelegate(MouseCapture);
                obj.OnMouseFree += new CObjetoDibujableDelegate(LiberaRaon);
                obj.OnRedibuja += new CObjetoDibujableDelegate(Redibuja);
                obj.OnEstoyAlFrente += new CObjetoDibujableDelegate2(EstaAlFrente);
                obj.OnChangeCursor += new CObjetoDibujableDelegateCurdor(CambiaCursor);
                hijos.Add(obj);
                AgregaObjetoControl(obj);
                Redibuja();
            }
        }
        private void TablaDelete(Modelo.ModeloDatos modelo, int id_tabla)
        {
            Modelo.CRegion region=            Modelo.Get_Region(ID_Region);
            //busco si tengo la tabla
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DTablaCapa))
                {
                    DTablaCapa nodotabla = (DTablaCapa)obj;
                    if (nodotabla.ID_Tabla == id_tabla && nodotabla.ID_Capa== region.ID_Capa)
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

        private void RegionTablaDelete(ModeloDatos modelo, int id_region, int ID_Tabla)
        {
            if (ID_Region != id_region)
                return;
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.GetType() == typeof(DTablaCapa))
                {
                    DTablaCapa nodotabla = (DTablaCapa)obj;
                    if (nodotabla.ID_Tabla == ID_Tabla)
                    {
                        hijos.Remove(obj);
                        QuitaObjetoControl(obj);
                        Redibuja();
                        return;
                    }
                }
            }
        }
        private void RegionTablaInsert(ModeloDatos modelo, int id_region, int ID_Tabla)
        {
            if (ID_Region != id_region)
                return;
            TablaInsert(modelo, ID_Tabla);
        }
        public DTablaCapa BuscaTablaCapa(int id_capa,int id_tabla)
        {
            foreach (CObjetoDibujable obj in hijos)
            {
                //veo si es la tabla que estoy buscando
                if (obj.GetType() == typeof(DTablaCapa))
                {
                    DTablaCapa nodotabla = (DTablaCapa)obj;
                    nodotabla = nodotabla.BuscaTablaCapa(id_capa,id_tabla);
                    if (nodotabla!=null)
                    {
                        return nodotabla;
                    }
                }
                else if(obj.GetType() == typeof(DRegion))
                {
                    DRegion region = (DRegion)obj;
                    DTablaCapa tabla = region.BuscaTablaCapa(id_capa, id_tabla);
                    if (tabla != null)
                        return tabla;
                }
            }
            //como no lo encontre regreso null
            return null;
        }
        #endregion
        #region menus
        public override ContextMenuStrip PreparaMenu(IContainer container, int x, int y)
        {
            int mx = x - Posicion.X;
            int my = y - Posicion.Y - BarraTitulo.Dimencion.Height;
            //reviso si las corrdenadas del raton estan dentro de una tabla o una region hija
            foreach (CObjetoDibujable obj in hijos)
            {
                if (obj.OnMouseIn(mx, my))
                {
                    return obj.PreparaMenu(container, mx, my); ;
                }
            }
            if(BarraTitulo.OnMouseIn(x,y))
                return base.PreparaMenu(container, x, y);
            return null;
        }
        protected override void InicializaMenu(int x, int y)
        {
            base.InicializaMenu(x, y);
            if (BarraTitulo.OnMouseIn(x, y))
            {
                AddMenuItem("Agregar Region", "IconoAgregar", MenuAgregarRegion_Click);
                AddMenuItem("Nueva Tabla", "Table_Field_Insert", MenuNuevaTabla_Click);
                AddMenuItem("Importar Tabla", "Tabla", MenuImportarTabla_Click);
                AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
                AddMenuItem("Ocultar/Mostrar", "ojo2", MenuVisible_Click);
                AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
            }
        }
        private void MenuAgregarRegion_Click(object sender, EventArgs e)
        {
            UI.FormPropiedadesRegion dlg = new UI.FormPropiedadesRegion();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CRegion region = GetRegion();
            region.Insert_Region(dlg.Nombre, dlg.Bk_Color, dlg.RegionVisible, "", region.ID_Capa, dlg.Fore_Color);
        }
        private void MenuNuevaTabla_Click(object sender, EventArgs e)
        {
            UI.FormPropiedadesTabla dlg = new UI.FormPropiedadesTabla();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CRegion region = GetRegion();
            region.Insert_Tabla(dlg.Nombre, 0, 0, 10, 10, Color.White, "", 0, "", region.ID_Capa, Color.Black,dlg.Comentarios);

        }
        private void MenuImportarTabla_Click(object sender, EventArgs e)
        {
            FormSelectConecion dlg = new FormSelectConecion();
            dlg.OnConexion += new OnFormConexionInicialEvent(OnConexionEvent);
            dlg.ShowDialog();
        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            CRegion region = GetRegion();
            UI.FormPropiedadesRegion dlg = new UI.FormPropiedadesRegion();
            dlg.Nombre = region.Nombre;
            dlg.Bk_Color = region.BkColor;
            dlg.RegionVisible = region.Visible;
            dlg.Fore_Color = region.ForeColor;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            region.Nombre = dlg.Nombre;
            region.BkColor = dlg.Bk_Color;
            region.Visible = dlg.RegionVisible;
            region.ForeColor = dlg.Fore_Color;
            region.Update();

        }
        private void MenuVisible_Click(object sender, EventArgs arg)
        {
            CRegion region = GetRegion();
            region.Visible = !region.Visible;
            region.Update();
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            CRegion region = GetRegion();
            if (MessageBox.Show("¿Eliminar la Region" + region.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                region.Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnConexionEvent(string nombre, CConexion con)
        {
            IMotorDB motor = ControladorConexiones.DameMotor(con);
            UI.FormSelectObjet dlg = new UI.FormSelectObjet();
            dlg.Motor = motor;
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(TablaSeleccionada);
            dlg.ShowDialog();
        }
        private void TablaSeleccionada(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            if (tipo == EnumTipoObjeto.TABLE)
            {
                //inserto la tabla
                MotorDB.CTabla tabla = motor.DameTabla(nombre);
                if (tabla == null)
                    return;
                Modelo.CTabla tbl = Modelo.Get_Tabla(nombre);
                if (tbl == null)
                {
                    CRegion region = GetRegion();
                    tbl = region.Insert_Tabla(tabla.Nombre, 0, 0, 10, 10, Color.White, "", 0, "", region.ID_Capa, Color.Black,tbl.Comentarios);
                }
                if (tabla.PrimaryKey != null)
                {
                    tbl.PK_Nombre = tabla.PrimaryKey.Nombre;
                    tbl.Update();
                }
                AgregaCampos(tabla, tbl);
                AgregaIndices(tabla, tbl);
                AgregaForaneas(motor, tabla, tbl);
                AgregaForaneasHijas(motor, tabla, tbl);
            }
        }
        private void AgregaCampos(MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo sus campos
            int orden = 0;
            if (tabla == null)
                return;
            foreach (MotorDB.CCampo campo in tabla.Campos)
            {
                Modelo.CTipoDato td = Modelo.Get_TipoDato(campo.TipoDato.Nombre);
                if (td == null)
                {
                    int id_tipoDato = Modelo.Insert_TipoDato(campo.TipoDato.Nombre, campo.TipoDato.UsaLongitud);
                    td = Modelo.Get_TipoDato(id_tipoDato);
                }
                bool pk = false;
                if (tabla.PrimaryKey != null)
                {
                    pk = tabla.PrimaryKey.ContieneCampo(campo);
                }
                if (tbl.Get_Campo(campo.Nombre) == null)
                {
                    int id_campo = Modelo.Insert_Campo(campo.Nombre, tbl.ID_Tabla, td.ID_TipoDato, campo.Longitud, pk, campo.AceptaNulo, campo.CampoCalculado, campo.Formula, campo.EsDefault, campo.DefaultName, orden,"");
                    if (tabla.EsIdentidad(campo))
                    {
                        tbl.ID_Identidad = id_campo;
                        tbl.Update();
                    }
                }
                orden++;
            }
        }
        private void AgregaIndices(MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo los indices
            foreach (Cindex index in tabla.Indexs)
            {
                if (Modelo.Get_Index(index.Nombre) == null)
                {
                    int id_index = Modelo.Insert_Index(index.Nombre, tbl.ID_Tabla);
                    //ahora me traigo los campos
                    foreach (MotorDB.CCampoIndex ci in index.Campos)
                    {
                        foreach (Modelo.CCampo obj2 in tbl.Get_Campos())
                        {
                            if (obj2.NombreX == ci.Nombre)
                            {
                                Modelo.Insert_CampoIndex(id_index, obj2.ID_Campo, ci.Ordenamiento == EnumOrdenIndex.DESC);
                            }
                        }
                    }
                }
            }
        }
        private void AgregaForaneas(MotorDB.IMotorDB motor, MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo las llaves foraneas
            foreach (CForeignKey fk in motor.DameLLavesForaneas(tabla.Nombre))
            {
                if (Modelo.Get_LlaveForanea(fk.Nombre) == null)
                {
                    try
                    {
                        Modelo.CTabla padre = Modelo.Get_Tabla(fk.TablaPadre);
                        if (padre != null)
                        {
                            bool ok = true;
                            //verifico si existen los campos
                            foreach (CCampoFereneces campo in fk.Campos)
                            {
                                Modelo.CCampo campoPadre = padre.Get_Campo(campo.CampoPadre.Nombre);
                                Modelo.CCampo campoHijo = tbl.Get_Campo(campo.CampoHijo.Nombre);
                                if (campoPadre == null || campoHijo == null)
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok == true)
                            {
                                int id_Fk = Modelo.Insert_LlaveForanea(padre.ID_Tabla, tbl.ID_Tabla, fk.Nombre, fk.AccionBorrar, fk.AccionActualizar, Color.Black);
                                CLlaveForanea Fk3 = Modelo.Get_LlaveForanea(id_Fk);
                                //agrego los campos
                                foreach (CCampoFereneces campo in fk.Campos)
                                {
                                    Fk3.Insert_CampoReferencia(padre.Get_Campo(campo.CampoPadre.Nombre).ID_Campo, tbl.Get_Campo(campo.CampoHijo.Nombre).ID_Campo);
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
        private void AgregaForaneasHijas(MotorDB.IMotorDB motor, MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo las llaves foraneas
            foreach (CForeignKey fk in motor.DameLLavesForaneasHijas(tabla.Nombre))
            {
                if (Modelo.Get_LlaveForanea(fk.Nombre) == null)
                {
                    try
                    {
                        Modelo.CTabla hija = Modelo.Get_Tabla(fk.TablaHija);
                        if (hija != null)
                        {
                            bool ok = true;
                            //verifico si existen los campos
                            foreach (CCampoFereneces campo in fk.Campos)
                            {
                                Modelo.CCampo campoHijo = hija.Get_Campo(campo.CampoPadre.Nombre);
                                Modelo.CCampo campoPadre = tbl.Get_Campo(campo.CampoHijo.Nombre);
                                if (campoPadre == null || campoHijo == null)
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok == true)
                            {
                                int id_Fk = Modelo.Insert_LlaveForanea(tbl.ID_Tabla, hija.ID_Tabla, fk.Nombre, fk.AccionBorrar, fk.AccionActualizar, Color.Black);
                                CLlaveForanea Fk3 = Modelo.Get_LlaveForanea(id_Fk);
                                //agrego los campos
                                foreach (CCampoFereneces campo in fk.Campos)
                                {
                                    Fk3.Insert_CampoReferencia(tbl.Get_Campo(campo.CampoHijo.Nombre).ID_Campo, hija.Get_Campo(campo.CampoPadre.Nombre).ID_Campo);
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        continue;
                    }
                }
            }
        }

        #endregion
    }
}
