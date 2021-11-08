using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Dibujable
{
    /// <summary>
    /// Clase que representa a un objeto que se puede mover con el raton
    /// </summary>
    public class DMovible:DRectangulo
    {
        protected DBarraTitulo FBarraTitulo;
        protected DRectangulo HareaTrabajo;
        public DMovible()
        {
            FBarraTitulo = new DBarraTitulo();
            FBarraTitulo.OnNuevaPosicion += new DBarraTituloDelegate(NuevaPosicion);
            HareaTrabajo = new DRectangulo();

        }
        public override void Free()
        {
            base.Free();
            FBarraTitulo.OnNuevaPosicion -= NuevaPosicion;
        }
        /// <summary>
        /// Indica la pocicion de la esquina superior izquierda
        /// </summary>
        public new Point Posicion
        {
            get
            {
                return FRectangle.Location;
            }
            set
            {
                FRectangle.Location = value;
                //asigno la barra de titulo
                FBarraTitulo.Posicion = value;
                HareaTrabajo.Posicion = new Point(Posicion.X, Posicion.Y + FBarraTitulo.Dimencion.Height);
                HareaTrabajo.Dimencion = new Size(Dimencion.Width, Dimencion.Height - BarraTitulo.Dimencion.Height);
            }
        }
        /// <summary>
        /// contiene el tamaño del objeto
        /// </summary>
        public new Size Dimencion
        {
            get
            {
                return FRectangle.Size;
            }
            set
            {
                FRectangle.Size = value;
                FBarraTitulo.Dimencion = new Size(Dimencion.Width, 25); 
                HareaTrabajo.Dimencion = new Size(Dimencion.Width, Dimencion.Height - BarraTitulo.Dimencion.Height);
                HareaTrabajo.Posicion=new Point(Posicion.X, Posicion.Y + FBarraTitulo.Dimencion.Height);
            }
        }
        /// <summary>
        /// contiene la barra de titulo
        /// </summary>
        public DBarraTitulo BarraTitulo
        {
            get
            {
                return FBarraTitulo;
            }
        }
        /// <summary>
        /// se incializan
        /// </summary>
        /// <param name="graphics"></param>
        public override void Dibuja(MiGraphics graphics)
        {
            //dibujo mi cuadro
            base.Dibuja(graphics);
            //Dibujo mi titulo
            FBarraTitulo.Dibuja(graphics);
            //ahora dibujo el area de trabajo
            HareaTrabajo.Dibuja(graphics);
        }
        public override bool OnMouseDown(object sender, MouseEventArgs e,int x, int y)
        {
            if(BarraTitulo.OnMouseIn(x,y))
            {
                CapturaMouse();
                return BarraTitulo.OnMouseDown(sender, e,x,y);
            }
            if (HareaTrabajo.OnMouseIn(x, y))
                return true;
            return false;
//                return HareaTrabajo.OnMouseDown(sender, e,x,y);
        }
        public override bool OnMouseUp(object sender, MouseEventArgs e, int x, int y)
        {
            if (BarraTitulo.OnMouseIn(x,y))
            {
                LiberaRaton();
                OnFinMove();
                return BarraTitulo.OnMouseUp(sender, e,x,y);
            }
            return HareaTrabajo.OnMouseUp(sender, e,x,y);
        }
        public override bool OnMouseMove(object sender, MouseEventArgs e, int x, int y)
        {
            if (BarraTitulo.OnMouseIn(x, y)|| MouseCapturado)
            {
                return BarraTitulo.OnMouseMove(sender, e,x,y);
            }
            return HareaTrabajo.OnMouseMove(sender, e,x,y);
        }
        private void NuevaPosicion(DBarraTitulo sender,int x, int y)
        {
            //recalculo mi nueva posicion
            Posicion = new Point(x, y);
            Redibuja();
        }
        /// <summary>
        /// se llama cuando se mueve la pantalla
        /// </summary>
        protected virtual void OnFinMove()
        {

        }
        public override bool OnMouseClick(object sender, MouseEventArgs e, int x, int y)
        {
            if (BarraTitulo.OnMouseIn(x, y) || MouseCapturado)
            {
                return BarraTitulo.OnMouseClick(sender, e, x, y);
            }
            return false;
        }

    }
}
