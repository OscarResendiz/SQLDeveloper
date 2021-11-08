using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Modelador.Dibujable
{
    public delegate void DBarraTituloDelegate(DBarraTitulo sender, int x, int y);
    /// <summary>
    /// clase que define una barra de titulo
    /// </summary>
    public class DBarraTitulo: DTexto
    {
        public event DBarraTituloDelegate OnNuevaPosicion;
        private Point Diferencia;
        private bool MousePresionado;
        public DBarraTitulo()
        {
            MousePresionado = false;
        }
        public string Titulo
        {
            get
            {
                return Texto;
            }
            set
            {
                Texto = value;
            }
        }
        public override void Dibuja(MiGraphics graphics)
        {
            //dibujo la pantalla
            base.Dibuja(graphics);
        }
        public override bool OnMouseDown(object sender, MouseEventArgs e, int x, int y)
        {
            MousePresionado = true;
            //marco la diferencia entre la posicion del raton con respecto a la posicion de la esquina superior izquerda
            Diferencia = new Point(x - Posicion.X, y - Posicion.Y);
            return true;
        }
        public override bool OnMouseUp(object sender, MouseEventArgs e, int x, int y)
        {
            MousePresionado = false;
            return true;
        }
        public override bool OnMouseMove(object sender, MouseEventArgs e, int x, int y)
        {
            if (MousePresionado == false)
                return false;
            //calculo la nueva posicion
            if(OnNuevaPosicion!=null)
            {
                if (x - Diferencia.X > 0 && y - Diferencia.Y > 0)
                {
                    OnNuevaPosicion(this, x - Diferencia.X, y - Diferencia.Y);
                }
                else if(x - Diferencia.X <= 0)
                {
                    OnNuevaPosicion(this,0, y - Diferencia.Y);

                }
                else if (y - Diferencia.Y <= 0)
                {
                    OnNuevaPosicion(this, x - Diferencia.X, 0);
                }
                return true;
            }
            return false;
        }
        public override bool OnMouseClick(object sender, MouseEventArgs e, int x, int y)
        {
            if(e.Button== MouseButtons.Right)
            {
           //     MessageBox.Show(Titulo);
            }
            return false;
        }
    }
}
