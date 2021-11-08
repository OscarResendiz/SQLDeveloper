using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Modelador.Modelo;

namespace Modelador.Dibujable
{

    public partial class ControlDibujable : PictureBox
    {
        CObjetoDibujable TieneRaton;
        private int Desplazamiento = 30;
        private int FHScroolValue;
        private int FVScroolValue;
        private List<CObjetoDibujable> Controles;
        private Brush BakBrush;
        Modelo.ModeloDatos FModelo;
        private MiGraphics FGraphics;
        CCuadricula Cuadricula;
        private int FAnchoCuadricula;
        private bool FMostrarCuadricula;
        private Color FColorCuadricula;
        [
        Category("Cuadricula")
        ]
        public bool MostrarCuadricula
        {
            get
            {
                return FMostrarCuadricula;
            }
            set
            {
                FMostrarCuadricula = value;
                Invalidate();
            }
        }
        [
        Category("Cuadricula")
        ]
        public int AnchoCuadricula
        {
            get
            {
                return FAnchoCuadricula;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("No se acepta el cero");
                }
                FAnchoCuadricula = value;
                Invalidate();
            }
        }
        [
        Category("Cuadricula")
        ]
        public Color ColorCuadricula
        {
            get
            {
                return FColorCuadricula;
            }
            set
            {
                FColorCuadricula = value;
                Invalidate();
            }
        }
        public ControlDibujable()
        {
            Controles = new List<CObjetoDibujable>();
            ColorCuadricula = Color.White;
            BakBrush = new SolidBrush(BackColor);
            AnchoCuadricula = 50;
            FHScroolValue = 0;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.ResizeRedraw |
              ControlStyles.ContainerControl |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.SupportsTransparentBackColor, true);
            FGraphics = new MiGraphics(Width, Height);
            InitializeComponent();
        }
        public Modelo.ModeloDatos Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if (FModelo != null)
                {
                    FModelo.OnCapaDelete += new Modelo.DelegateModeloDatosEvent(CapaDelete);
                    FModelo.OnCapaInsert += new Modelo.DelegateModeloDatosEvent(CapaInsert);
                    FModelo.OnAbrir += new Modelo.DelegateModeloEvent(ModeloAbrir);
                    Cargacapas();
                }
            }
        }
        private void AgregaCapa(DCapa capa)
        {
            Controles.Insert(0, capa);
            //agrego los manejadores de eventos
            capa.OnAddObjetc += new CObjetoDibujableDelegate(AddObjetc);
            capa.OnRedibuja += new CObjetoDibujableDelegate(Repinta);
            capa.OnRemovebjetc += new CObjetoDibujableDelegate(RemoveObjetc);
            capa.OnBuscaTabla += new BuscaTablaDelegate(BuscaTabla);
        }
        private void CapaInsert(Modelo.ModeloDatos modelo, int id_Capa)
        {
            AgregaCapa(new DCapa()
            {
                ID_Capa = id_Capa,
                Modelo = modelo
            });
        }
        private void CapaDelete(Modelo.ModeloDatos modelo, int ID_Capa)
        {
            //elimino la capa de la lista
            foreach (DCapa capa in Controles)
            {
                if (capa.ID_Capa == ID_Capa)
                {
                    capa.Free();
                    Controles.Remove(capa);
                    return;
                }
            }

        }
        private void Cargacapas()
        {
            foreach (DCapa capax in Controles)
            {
                capax.Free();
            }
            //cargo las capas
            Controles.Clear();
            Modelo.CCapa capa = FModelo.Get_CapaInferior();
            if (capa == null)
                return;
            DCapa capa1 = new DCapa()
            {
                ID_Capa = capa.ID_Capa
            };
            AgregaCapa(capa1);
            capa1.Modelo = FModelo;
            do
            {
                capa = capa.Get_CapaSuperior();
                if (capa != null)
                {
                    DCapa capa2 = new DCapa()
                    {
                        ID_Capa = capa.ID_Capa
                    };
                    AgregaCapa(capa2);
                    capa2.Modelo = FModelo;
                }
            }
            while (capa != null);
        }
        public virtual void InicializaComponentes()
        {
        }
        private void LiberaRaon(CObjetoDibujable objeto)
        {
            TieneRaton = null;
        }
        private void MouseCapture(CObjetoDibujable objeto)
        {
            TieneRaton = objeto;
        }
        private void Repinta(CObjetoDibujable sender)
        {
            Invalidate();
        }
        /// <summary>
        /// establece el desplazamiento horizontal
        /// </summary>
        public int HScroolValue
        {
            get
            {
                return FHScroolValue;
            }
            set
            {
                FHScroolValue = value;
                if (FGraphics != null)
                {
                    FGraphics.HScroolValue = FHScroolValue;
                    FGraphics.Desplazamiento = Desplazamiento;
                }
                Invalidate();
            }
        }
        /// <summary>
        /// establece el desplazamiento Vertical
        /// </summary>
        public int VScroolValue
        {
            get
            {
                return FVScroolValue;
            }
            set
            {
                FVScroolValue = value;
                if (FGraphics != null)
                {
                    FGraphics.VScroolValue = FVScroolValue;
                    FGraphics.Desplazamiento = Desplazamiento;
                }
                Invalidate();
            }
        }
        /// <summary>
        /// agrega el objeto al control de los eventos del raton
        /// </summary>
        /// <param name="obj"></param>
        private void CambiaCursor(CObjetoDibujable obj, Cursor cursor)
        {
            this.Cursor = cursor;
        }
        private void ModeloAbrir(Modelo.ModeloDatos modelo)
        {
            Cargacapas();
        }
        private void RemoveObjetc(CObjetoDibujable obj)
        {
            if (obj != null)
            {
                obj.OnRedibuja -= Repinta;
                obj.OnMouseCapture -= MouseCapture;
                obj.OnMouseFree -= LiberaRaon;
                Controles.Remove(obj);
            }
        }
        #region Manejo de ventanas
        private bool EstaAlFrente(CObjetoDibujable obj)
        {
            if (Controles.Count > 0)
            {
                if (Controles[Controles.Count - 1] == obj)
                    return true;
            }
            return false;

        }
        private void AddObjetc(CObjetoDibujable obj)
        {
            obj.OnRedibuja += new CObjetoDibujableDelegate(Repinta);
            obj.OnMouseCapture += new CObjetoDibujableDelegate(MouseCapture);
            obj.OnMouseFree += new CObjetoDibujableDelegate(LiberaRaon);
            obj.OnChangeCursor += new CObjetoDibujableDelegateCurdor(CambiaCursor);
            obj.OnEstoyAlFrente += new CObjetoDibujableDelegate2(EstaAlFrente);
            Controles.Add(obj);
            Invalidate();
        }
        #endregion
        #region Manejo del raton
        private void ControlDibujable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int mx = e.Location.X + (FHScroolValue * Desplazamiento);
            int my = e.Location.Y + (FVScroolValue * Desplazamiento);
            for (int i = Controles.Count - 1; i > 0; i--)
            {
                CObjetoDibujable obj = Controles[i];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseDoubleClick(sender, e, mx, my) == true)
                        {
                            return;
                        }
                    }
                }
            }
        }
        private void ControlDibujable_MouseUp(object sender, MouseEventArgs e)
        {
            int mx = e.Location.X + (FHScroolValue * Desplazamiento);
            int my = e.Location.Y + (FVScroolValue * Desplazamiento);
            for (int i = Controles.Count - 1; i > 0; i--)
            {
                CObjetoDibujable obj = Controles[i];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseUp(sender, e, mx, my) == true)
                        {
                            return;
                        }
                    }
                }
            }

        }
        private void ControlDibujable_MouseMove(object sender, MouseEventArgs e)
        {
            int mx = e.Location.X + (FHScroolValue * Desplazamiento);
            int my = e.Location.Y + (FVScroolValue * Desplazamiento);
            if (TieneRaton != null)
            {
                if (TieneRaton.IsVisible())
                {
                    if (TieneRaton.OnMouseMove(sender, e, mx, my) == true)
                    {
                        return;
                    }
                }
            }
            for (int i = Controles.Count - 1; i > 0; i--)
            {
                CObjetoDibujable obj = Controles[i];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseMove(sender, e, mx, my) == true)
                        {
                            return;
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void ControlDibujable_MouseDown(object sender, MouseEventArgs e)
        {
            int mx = e.Location.X + (FHScroolValue * Desplazamiento);
            int my = e.Location.Y + (FVScroolValue * Desplazamiento);
            bool menuok = false;
            //hago el recorrido desde el masal frente hacia el que esta mas atraz
            for (int i = Controles.Count - 1; i > 0; i--)
            {
                CObjetoDibujable obj = Controles[i];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            ContextMenuStrip = obj.PreparaMenu(this.components, mx, my);
                            if (ContextMenuStrip != null)
                            {
                                menuok = true;
                                break;
                            }
                        }
                        if (obj.OnMouseDown(sender, e, mx, my) == true)
                        {
                            //lo paso al frente
                            Controles.Remove(obj);
                            Controles.Add(obj);
                            Invalidate();
                            return;
                        }
                    }
                }
            }
            if (menuok == false)
                ContextMenuStrip = null;
        }
        private void ControlDibujable_MouseClick(object sender, MouseEventArgs e)
        {
            int mx = e.Location.X + (FHScroolValue * Desplazamiento);
            int my = e.Location.Y + (FVScroolValue * Desplazamiento);

            for (int i = Controles.Count - 1; i > 0; i--)
            {
                CObjetoDibujable obj = Controles[i];
                if (obj.IsVisible())
                {
                    if (obj.OnMouseIn(mx, my))
                    {
                        if (obj.OnMouseClick(sender, e, mx, my) == true)
                        {
                            return;
                        }
                    }
                }
            }
        }
        #endregion
        private DTablaCapa BuscaTabla(int id_capa, int id_tabla)
        {
            foreach (CObjetoDibujable obj in Controles)
            {
                if (obj.GetType() == typeof(DCapa))
                {
                    DCapa capa = (DCapa)obj;
                    DTablaCapa tabla = capa.BuscaTabla(id_tabla);
                    if (tabla != null)
                        return tabla;
                }
            }
            return null;
        }
        private void Dibuja()
        {
            if (FGraphics.Width != Width || FGraphics.Height != Height || Cuadricula.Visible != MostrarCuadricula || Cuadricula.AnchoCuadricula != AnchoCuadricula || Cuadricula.Color != ColorCuadricula)
            {
                BakBrush = new SolidBrush(BackColor);
                FGraphics.Redimenciona(Width, Height);
                Cuadricula = new CCuadricula();
                Cuadricula.Ancho = Width;
                Cuadricula.Alto = Height;
                Cuadricula.Visible = MostrarCuadricula;
                Cuadricula.AnchoCuadricula = AnchoCuadricula;
                Cuadricula.Color = ColorCuadricula;
            }
            FGraphics.Clear(BackColor);
            Cuadricula.Dibuja(FGraphics);
            foreach (CObjetoDibujable obj in Controles)
            {
                if (obj.GetType() == typeof(DRegion) || obj.GetType() == typeof(DTablaCapa))
                {
                    obj.Dibuja(FGraphics);
                    if (obj.GetType() == typeof(DTablaCapa))
                    {
                        DTablaCapa tabla = (DTablaCapa)obj;
                        if (Modelo.Get_RegionTablaCapa(tabla.ID_Capa, tabla.ID_Tabla) == null)
                        {
                            if (tabla.IsVisible())
                            {
                                tabla.DibujaFinal(FGraphics);
                            }
                        }
                    }
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Dibuja();
            e.Graphics.DrawImage(FGraphics.GetBitMap(), 0, 0);
        }
    }
}
