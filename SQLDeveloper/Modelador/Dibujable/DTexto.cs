using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Modelador.Dibujable
{
   public  class DTexto: DRectangulo
    {
        private Rectangle textRectangle;
        public DTexto()
        {
            Font = SystemFonts.DialogFont;
            ColorTexto = Brushes.Black;
        }
        /// <summary>
        /// Texto a mostrar
        /// </summary>
        public string Texto
        {
            get;
            set;
        }
        /// <summary>
        /// fuente con la que se mostrara el texto
        /// </summary>
        public Font Font
        {
            get;
            set;
        }
        /// <summary>
        /// Contiene el color con el que se va a mostrar el texto
        /// </summary>
        public Brush ColorTexto
        {
            get;
            set;
        }
        public override void Dibuja(MiGraphics graphics)
        {
            //dibujo la pantalla
            base.Dibuja(graphics);
            if (textRectangle == null)
            {
                textRectangle = new Rectangle();
            }
            SizeF stringSize = new SizeF();
            stringSize = graphics.MeasureString(Texto, Font);
            if (Contorno)
            {
                textRectangle.X = Posicion.X + AnchoLinea;
                textRectangle.Y = (Posicion.Y + AnchoLinea) + ((int)(Dimencion.Height - stringSize.Height) / 2);
                textRectangle.Width = Dimencion.Width - (AnchoLinea * 2);
            }
            else
            {
                textRectangle.X = Posicion.X;
                textRectangle.Y = (Posicion.Y) + ((int)(Dimencion.Height - stringSize.Height) / 2);
                textRectangle.Width = Dimencion.Width;
            }
            textRectangle.Height = (int)stringSize.Height;
            graphics.DrawString(Texto, Font, ColorTexto, textRectangle);
        }

    }
}
