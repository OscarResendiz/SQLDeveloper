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
    public delegate DTablaCapa BuscaTablaDelegate(int ID_Capa,int id_tabla);
    public delegate Point OnPosisionRealDelegate(DRectangulo sender);
    public class DTabla : DMovible
    {
        protected int Id_Index;
        public event OnPosisionRealDelegate OnGetPosicionReal;
        protected Modelador.Modelo.CTabla Tabla;
        protected List<DForeKey> llavesForaneas;
        public int ID_Tabla
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
            Tabla = GetTabla();
            BarraTitulo.Titulo = Tabla.Nombre;
            Posicion = new Point(Tabla.X, Tabla.Y);
            Dimencion = new Size(Tabla.Ancho, Tabla.Alto);
            BarraTitulo.ColorFondo = new SolidBrush(Tabla.BKColor);// Color.DarkSlateBlue);

            if (Tabla.BKColor.R != 255 || Tabla.BKColor.G != 255 || Tabla.BKColor.B != 255)
                BarraTitulo.ColorFondo = new SolidBrush(Tabla.BKColor);// Color.DarkSlateBlue);
            else
                BarraTitulo.ColorFondo = new SolidBrush(Color.DarkSlateBlue);// );

//            BarraTitulo.ColorTexto = new SolidBrush(Color.White);
            ColorFondo = new SolidBrush(Tabla.BKColor);
            Modelo.OnCampoInsert += new Modelo.DelegateModeloDatosEvent(CampoInsert);
            Modelo.OnCampoDelete += new Modelo.DelegateModeloDatosEvent(CampoDelete);
            Modelo.OnTablaUpdate += new Modelo.DelegateModeloDatosEvent(TablaUpdate);
            Modelo.OnLlaveForaneaUpdate += new Modelo.DelegateModeloDatosEvent(LlaveForaneaUpdate);

            CargaCampos();
            CargaLavesForaneas();
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnCampoInsert -= CampoInsert;
            Modelo.OnCampoDelete -= CampoDelete;
            Modelo.OnTablaUpdate -= TablaUpdate;
            Modelo.OnLlaveForaneaUpdate -= LlaveForaneaUpdate;
        }
        /// <summary>
        /// obtiene la lista de campos
        /// </summary>
        private void CargaCampos()
        {
            List<Modelo.CCampo> campos = Modelo.Get_CamposTabla(ID_Tabla);
            foreach (Modelo.CCampo campo in campos)
            {
                DCampo obj = new DCampo();
                obj.OnRedibuja += new CObjetoDibujableDelegate(Redibuja);
                obj.ID_Campo = campo.ID_Campo;
                obj.Modelo = Modelo;
                hijos.Add(obj);
            }
        }
        private void LlaveForaneaUpdate(Modelo.ModeloDatos modelo, int Id_Fk)
        {
            CargaLavesForaneas();
            Redibuja();
        }

        private void Redibuja(CObjetoDibujable sender)
        {
            Redibuja();
        }

        public override void Dibuja(MiGraphics graphics)
        {
            if (IsVisible() == false)
                return;
            //veo cual es el texto mas largo
            string max = Tabla.Nombre;
            if (hijos == null)
                return;
            foreach (DCampo campo in hijos)
            {
                if (campo.Texto.Length > max.Length)
                {
                    max = campo.Texto;
                }
            }
            //calculo el tamaño
            SizeF stringSize = new SizeF();
            stringSize = graphics.MeasureString(max, BarraTitulo.Font);
            int ancho = (int)stringSize.Width + 20;
            int alto = ((int)stringSize.Height) * (hijos.Count() + 2);
            if (Dimencion.Width != ancho || Dimencion.Height != alto)
            {
                Dimencion = new Size(ancho, alto);
                Tabla.Ancho = ancho;
                Tabla.Alto = alto;
                Tabla.Update();
            }
            //ahora calculo la posicion de cada campo
            int pos = Posicion.Y + BarraTitulo.Dimencion.Height;
            foreach (DCampo campo in hijos)
            {
                //calculo la posicion
                if (campo.Posicion.X != Posicion.X || campo.Posicion.Y != pos)
                {
                    campo.Posicion = new Point(Posicion.X, pos);
                }
                //calculo el tamaño
                if (campo.Dimencion.Width != ancho || campo.Dimencion.Height != stringSize.Height)
                {
                    campo.Dimencion = new Size(ancho, (int)stringSize.Height);
                }
                pos += (int)stringSize.Height;
            }
            //ahora si mando a dibujar
            base.Dibuja(graphics);
            //ahora dibujo mis campos
            foreach (DCampo campo in hijos)
            {
                campo.Dibuja(graphics);
            }
            //DibujaFinal(graphics);
        }
        private void CampoInsert(Modelo.ModeloDatos modelo, int id_campo)
        {
            Modelador.Modelo.CCampo campo = Modelo.Get_Campo(id_campo);
            if (campo.ID_Tabla == ID_Tabla)
            {
                DCampo obj = new DCampo();
                obj.ID_Campo = campo.ID_Campo;
                obj.Modelo = Modelo;
                hijos.Add(obj);
                Redibuja();
            }
        }
        protected override void OnFinMove()
        {
            base.OnFinMove();
            //actalizo la nueva posicion
            Tabla.X = Posicion.X;
            Tabla.Y = Posicion.Y;
            Tabla.Update();
        }
        private void CampoDelete(Modelo.ModeloDatos modelo, int id_campo)
        {
            foreach (DCampo campo in hijos)
            {
                if (campo.ID_Campo == id_campo)
                {
                    hijos.Remove(campo);
                    Redibuja();
                    return;
                }
            }
        }
        protected virtual void TablaUpdate(Modelo.ModeloDatos modelo, int id_tabla)
        {
            if (ID_Tabla == id_tabla)
            {
                Tabla = GetTabla();
                BarraTitulo.Titulo = Tabla.Nombre;
                Posicion = new Point(Tabla.X, Tabla.Y);
                Dimencion = new Size(Tabla.Ancho, Tabla.Alto);
                BarraTitulo.ColorFondo = new SolidBrush(Color.DarkSlateBlue);
                BarraTitulo.ColorTexto = new SolidBrush(Color.White);
                ColorFondo = new SolidBrush(Tabla.BKColor);
                BarraTitulo.ColorFondo = new SolidBrush(Tabla.BKColor);// Color.DarkSlateBlue);

                Redibuja();
            }
        }
        public override bool IsVisible()
        {
            bool ok = Tabla.Visible && CapaPadre.Visible;
            if (RegionPadre != null)
                ok = ok && RegionPadre.IsVisible();
            return ok;
        }
        protected virtual void CargaLavesForaneas()
        {
            llavesForaneas = new List<DForeKey>();
            List<Modelo.CLlaveForanea> l= Tabla.Get_FKHijas();
            foreach (Modelo.CLlaveForanea obj in l)
            {
                DForeKey fk = new DForeKey()
                {
                    ID_FK = obj.ID_FK,
                    Modelo = this.Modelo
                };
                llavesForaneas.Add(fk);
                AgregaObjetoControl(fk);
            }
            l = Tabla.Get_FKHijas();
            foreach (Modelo.CLlaveForanea obj in l)
            {
                DForeKey fk = new DForeKey()
                {
                    ID_FK = obj.ID_FK,
                    Modelo = this.Modelo
                };
                llavesForaneas.Add(fk);
           //     AgregaObjetoControl(fk);
            }
        }
        public DTabla BuscaTabla(int id_tabla)
        {
            if (ID_Tabla == id_tabla) //me estan buscando
            {
                //si estoy visible regreso
                if(IsVisible())
                    return this;
            }
            return null;
        }
        public Point DamePosicionReal()
        {
            if (OnGetPosicionReal != null)
                return OnGetPosicionReal(this);
            return Posicion;
        }
        public override void GeneraMapa(MiGraphics graphics)
        {
        }
        protected Modelo.CTabla GetTabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
    }
}
