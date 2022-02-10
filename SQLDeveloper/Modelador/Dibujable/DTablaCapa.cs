using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Modelador.Dibujable
{
   public class DTablaCapa:DTabla
    {
        public event BuscaTablaDelegate OnBuscaTabla;
        CObjetoDibujable TieneRaton;

        public int ID_Capa
        {
            get;
            set;
        }
        protected override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Tabla = Modelo.Get_TablaCapa(ID_Capa,ID_Tabla);
            Posicion = new Point(Tabla.X, Tabla.Y);
            Modelo.OnCapaTablaUpdate += new Modelo.DelegateModeloDatosEvent2(CapaTablaUpdate);
            Modelo.OnLlaveForaneaInsert += new Modelo.DelegateModeloDatosEvent(LlaveForaneaInsert);
            Modelo.OnLlaveForaneaDelete += new Modelo.DelegateModeloDatosEvent(LlaveForaneaDelete);
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnCapaTablaUpdate -= CapaTablaUpdate;
            Modelo.OnLlaveForaneaInsert -= LlaveForaneaInsert;
            Modelo.OnLlaveForaneaDelete -= LlaveForaneaDelete;
        }
        protected override void TablaUpdate(Modelo.ModeloDatos modelo, int id_tabla)
        {
            if (ID_Tabla == id_tabla)
            {
                Tabla = Modelo.Get_TablaCapa(ID_Capa, ID_Tabla);
                if (Tabla == null)
                    return;
                BarraTitulo.Titulo = Tabla.Nombre;
                Posicion = new Point(Tabla.X, Tabla.Y);
                Dimencion = new Size(Tabla.Ancho, Tabla.Alto);
                BarraTitulo.ColorFondo = new SolidBrush(Color.DarkSlateBlue);
                BarraTitulo.ColorTexto = new SolidBrush(Color.White);
                ColorFondo = new SolidBrush(Tabla.BKColor);
                if(Tabla.BKColor.R!=255 || Tabla.BKColor.G!=255 || Tabla.BKColor.B!=255)
                    BarraTitulo.ColorFondo = new SolidBrush(Tabla.BKColor);// Color.DarkSlateBlue);
                else
                    BarraTitulo.ColorFondo = new SolidBrush(Color.DarkSlateBlue);// );
                Redibuja();
            }
        }
        protected override void OnFinMove()
        {
            //            base.OnFinMove();
            //actalizo la nueva posicion
            Modelo.Update_TablaCapa(ID_Capa, ID_Tabla, Posicion.X, Posicion.Y, Tabla.Visible);
            //CargaLavesForaneas();
        }
        private void DibujaLigas(MiGraphics graphics)
        {
            foreach (DForeKey fk in llavesForaneas)
            {
                fk.Tabla = this;
                fk.Dibuja(graphics);
            }
        }
        public override void DibujaFinal(MiGraphics graphics)
        {
            base.DibujaFinal(graphics);
            DibujaLigas(graphics);
        }
        public DTablaCapa BuscaTablaCapa(int id_capa,int id_tabla)
        {
            if (ID_Tabla == id_tabla&& ID_Capa==id_capa) //me estan buscando
            {
                //si estoy visible regreso
                if (IsVisible())
                    return this;
            }
            return null;
        }
        private void CapaTablaUpdate(Modelo.ModeloDatos modelo, int id_capa,int id_tabla)
        {
            if (ID_Capa == id_capa && ID_Tabla == id_tabla)
            {
                Tabla = Modelo.Get_TablaCapa(ID_Capa, ID_Tabla);
                Redibuja();
            }
        }
        private void LlaveForaneaInsert(Modelo.ModeloDatos modelo, int ID_fk)
        {
            Modelo.CLlaveForanea obj = Modelo.Get_LlaveForanea(ID_fk);
            if (obj.ID_TablaPadre == ID_Tabla)
            {
                DForeKey fk = new DForeKey()
                {
                    ID_FK = obj.ID_FK,
                    Tabla = this,
                    Modelo = this.Modelo
                };
                fk.OnBuscaTabla += OnBuscaTabla;
                llavesForaneas.Add(fk);
              CapaPadre.AgregaObjetoControl(fk);
                Redibuja();
            }
        }
        private void  LlaveForaneaDelete(Modelo.ModeloDatos modelo, int ID_fk)
        {
            //veo si esta entre mis llaves
            foreach(DForeKey obj in llavesForaneas)
            {
                if(obj.ID_FK==ID_fk)
                {
                    llavesForaneas.Remove(obj);
                    CapaPadre.QuitaObjetoControl(obj);
                    Redibuja();
                    return;
                }
            }
        }
        #region Manejo de menus
        public override ContextMenuStrip PreparaMenu(IContainer container, int x, int y)
        {
            ContextMenuStrip menu = null;
            if (BarraTitulo.OnMouseIn(x, y))
            {
                menu = base.PreparaMenu(container, x, y);
            }
            //veo si se esta dentro de uno de mis campos
            foreach (DCampo campo in hijos)
            {
                if (campo.OnMouseIn(x, y))
                {
                    menu = campo.PreparaMenu(container, x, y);
                }
            }
            return menu;
        }

        protected override void InicializaMenu(int x, int y)
        {
            base.InicializaMenu(x, y);
            if (BarraTitulo.OnMouseIn(x, y))
            {
                AddMenuItem("Copiar nombre al portapapeles", "copiar", this.MenuCoiarNombre_Click);
                AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
                AddMenuItem("Resaltar", "Resaltar", MenuMarcar_Click);
                AddMenuSeparator();
                AddMenuItem("Quitar de la capa", "Eliminar", MenuEliminar_Click);
                AddMenuSeparator();
                AddMenuItem("Agregar Campo", "IconoAgregar", MenuAgregarCampo_Click);
                AddMenuItem("Agregar LLave Foranea", "IconoAgregar", MenuAgregarFk_Click);
                AddMenuItem("Agregar Indice", "IconoAgregar", MenuAgregarIndex_Click);

            }
        }
        private void MenuMarcar_Click(object sender, EventArgs e)
        {
            Modelador.Modelo.CTabla obj = GetTabla();
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.Reset();
            dlg.FullOpen = true;
            dlg.Color = obj.BKColor;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            obj.BKColor = dlg.Color;
            obj.Update();
        }

        private void MenuEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.CTabla tabla = GetTabla();
                UI.FormPropiedadesTabla dlg = new UI.FormPropiedadesTabla();
                dlg.Nombre = tabla.Nombre;
                dlg.Comentarios = tabla.Comentarios;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                tabla.Nombre = dlg.Nombre;
                tabla.Comentarios = dlg.Comentarios;
                tabla.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected virtual void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.CTabla tabla = GetTabla();
                if (MessageBox.Show("Eliminar la tabla " + tabla.Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                Modelo.Delete_TablaCapa(ID_Capa, ID_Tabla);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuAgregarCampo_Click(object sender, EventArgs e)
        {
            try
            {
                UI.FormPropiedadesCampo dlg = new UI.FormPropiedadesCampo(Modelo);
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modelo.CTabla tabla = GetTabla();
                tabla.Insert_Campo(dlg.NombreX, dlg.ID_TipoDato, dlg.Longitud, dlg.PK, dlg.AceptaNulos, dlg.CampoCalculado, dlg.Formula, dlg.EsDefault, dlg.DefaultName,dlg.Comentarios);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuAgregarFk_Click(object sender, EventArgs arg)
        {
            try
            {
                UI.FormPropiedadesFK dlg = new UI.FormPropiedadesFK();
                dlg.ID_TablaHija = this.ID_Tabla;
                dlg.Modelo = Modelo;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modelo.CTabla tablaPadre = dlg.TablaPadre;
                List<UI.CCampoProFk> l = dlg.Get_Campos();
                int ID_fk = Modelo.Insert_LlaveForanea(tablaPadre.ID_Tabla, ID_Tabla, dlg.Nombre, dlg.AcctionDelete, dlg.AcctionUpdate, dlg.LineColor);
                foreach (UI.CCampoProFk obj in l)
                {
                    Modelo.Insert_CampoReferencia(ID_fk, obj.ID_CampoPadre, obj.ID_CampoHijo);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuAgregarIndex_Click(Object sender, EventArgs arg)
        {
            UI.FormPropiedadesIndex dlg = new UI.FormPropiedadesIndex();
            dlg.OnCampoIndex += new UI.OnFormPropiedadesCampoIndexEvent(CampoSeleccionado);
            dlg.OnIndex += new UI.OnFormPropiedadesIndexEvent(IndiceSeleccionado);
            foreach (Modelo.CCampo campo in GetTabla().Get_Campos())
            {
                dlg.AddCampoTabla(campo.Nombre);
            }
            dlg.ShowDialog();
        }
        private void CampoSeleccionado(string NomCampo, bool descendente)
        {
            try
            {
                Modelo.CIndexX index = Modelo.Get_Index(Id_Index);
                List<Modelo.CCampo> campos = GetTabla().Get_Campos();
                foreach (Modelo.CCampo campo in campos)
                {
                    if (campo.Nombre == NomCampo)
                    {
                        index.Insert_Campo(campo.ID_Campo, descendente);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void IndiceSeleccionado(string nombre, bool pk, bool genrarFuncion, bool MultiplesObjetos)
        {
            try
            {
                Id_Index = Modelo.Insert_IndexX(nombre, ID_Tabla, genrarFuncion, MultiplesObjetos);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        protected override void CargaLavesForaneas()
        {
            if (llavesForaneas != null)
            {
                foreach (DForeKey obj in llavesForaneas)
                {
                    obj.OnMouseCapture -= MouseCapture;
                    obj.OnMouseFree -= LiberaRaon;
                    obj.OnRedibuja -= Redibuja;
                    CapaPadre.QuitaObjetoControl(obj);
                }
            }
            base.CargaLavesForaneas();
            foreach (DForeKey obj in llavesForaneas)
            {
                obj.Tabla = this;
                obj.OnBuscaTabla += OnBuscaTabla;
                obj.OnMouseCapture += new CObjetoDibujableDelegate(MouseCapture);
                obj.OnMouseFree += new CObjetoDibujableDelegate(LiberaRaon);
                obj.OnRedibuja += new CObjetoDibujableDelegate(Redibuja);
                CapaPadre.AgregaObjetoControl(obj);
            }

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
        private void Redibuja(CObjetoDibujable sender)
        {
            Redibuja();
        }
        protected virtual void MenuCoiarNombre_Click(object sender, EventArgs e)
        {
            Modelo.CTabla tabla = GetTabla();
            Clipboard.SetText(tabla.Nombre);
        }
    }
}
