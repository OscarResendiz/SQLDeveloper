using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Dibujable
{
    /// <summary>
    /// clase que representa un rectangulo dibujable
    /// </summary>
    public class DRectangulo : CObjetoDibujable
    {
        private MiGraphics migraficts;
        protected Rectangle FRectangle;
        protected Pen FPen;
        /// <summary>
        /// Indica la pocicion de la esquina superior izquierda
        /// </summary>
        public Point Posicion
        {
            get
            {
                return FRectangle.Location;
            }
            set
            {
                FRectangle.Location = value;
            }
        }
        /// <summary>
        /// contiene el tamaño del objeto
        /// </summary>
        public Size Dimencion
        {
            get
            {
                return FRectangle.Size;
            }
            set
            {
                FRectangle.Size = value;
            }
        }
        /// <summary>
        /// color de relleno del fondo del area de trabajo
        /// </summary>
        public Brush ColorFondo
        {
            get;
            set;
        }
        /// <summary>
        /// Color de frente
        /// </summary>
        public Color ColorFrente
        {
            get
            {
                return FPen.Color;
            }
            set
            {
                FPen.Color = value;
            }
        }
        /// <summary>
        /// indica si se va a mostrar el contorno
        /// </summary>
        public bool Contorno
        {
            get;
            set;
        }
        /// <summary>
        /// establece el ancho de las lineas del contorno
        /// </summary>
        public int AnchoLinea
        {
            get
            {
                return (int)FPen.Width;
            }
            set
            {
                FPen.Width = value;
            }
        }
        public DRectangulo()
        {
            FRectangle = new Rectangle(0, 0, 50, 10);
            ColorFondo = Brushes.White;
            FPen = new Pen(Color.Black);
            Contorno = true;
            AnchoLinea = 1; //un poxel

        }
        public override void Dibuja(MiGraphics graphics)
        {
            base.Dibuja(graphics);
            graphics.FillRectangle(ColorFondo, FRectangle);
            if (Contorno)
            {
                graphics.DrawRectangle(FPen, FRectangle);
            }
        }
        public override bool OnMouseIn(int x,int y)
        {
            if (x >= Posicion.X && x <= Posicion.X + Dimencion.Width && y >= Posicion.Y && y <= Posicion.Y + Dimencion.Height)
                return true;
            return false;
        }
        /// <summary>
        /// regresa un lienzo para dibujar 
        /// </summary>
        /// <returns></returns>
        public MiGraphics GetGrafics()
        {
            if(migraficts==null|| migraficts.Width!= Dimencion.Width || migraficts.Height!= Dimencion.Height)
            {
                migraficts = new MiGraphics(Dimencion.Width, Dimencion.Height);
            }
            return migraficts;
        }

    }

}
