using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Dibujable
{
    public class DDimencionable: DMovible
    {
        private bool Dimencionando;
        private DockStyle direccion;
        public DDimencionable()
        {
            Dimencionando = false;
        }
        public override bool OnMouseMove(object sender, MouseEventArgs e, int x, int y)
        {
            int tmp = 0;
            if (Dimencionando)
            {
                //tengo el control y estoy dimencionando la pantalla
                switch(direccion)
                {
                    case DockStyle.Top: //Arriba
                        //calculo el nuevo tamaño
                        if (y < 0)
                            y = 0;
                        tmp = (Posicion.Y + Dimencion.Height)-y;
                        //actualizo las dimenciones y posiciones
                        Posicion = new System.Drawing.Point(Posicion.X, y);
                        Dimencion = new System.Drawing.Size(Dimencion.Width, tmp);
                        CmbiaCursor(Cursors.SizeNS);
                        //aviso del cambio
                        Redimencionado();
                        Redibuja();
                        break;
                    case DockStyle.Bottom:// abajo
                        tmp = y-Posicion.Y;
                        //actualizo el tamaño
                        Dimencion = new System.Drawing.Size(Dimencion.Width, tmp);
                        CmbiaCursor(Cursors.SizeNS);
                        //aviso del cambio
                        Redimencionado();
                        Redibuja();
                        break;
                    case DockStyle.Left: //izquierda
                        //calculo el nuevo tamaño
                        if (x < 0)
                            x = 0;
                        tmp = (Posicion.X + Dimencion.Width) - x;
                        //actuaizo las dimenciones y la nueva posicion
                        Posicion = new System.Drawing.Point(x, Posicion.Y);
                        //actualizo el nuevo tamaño
                        Dimencion = new System.Drawing.Size(tmp, Dimencion.Height);
                        CmbiaCursor(Cursors.SizeWE);
                        //aviso del cambio
                        Redimencionado();
                        Redibuja();
                        break;
                    case DockStyle.Right://derecha
                        //calculo el uevo tamaño
                        tmp =x- Posicion.X;
                        Dimencion = new System.Drawing.Size(tmp, Dimencion.Height);
                        CmbiaCursor(Cursors.SizeWE);
                        //aviso del cambio
                        Redimencionado();
                        Redibuja();
                        break;
                    case DockStyle.Fill:
                        //actualizo el tamaño
                        Dimencion = new System.Drawing.Size(x - Posicion.X, y - Posicion.Y);
                        CmbiaCursor(Cursors.SizeNWSE);
                        //aviso del cambio
                        Redimencionado();
                        Redibuja();
                        break;
                }
                return true;
            }
            //verifico si el raton esta en una de las esquinas
            if((x >= Posicion.X + Dimencion.Width-1 && x <= Posicion.X + Dimencion.Width - 1) && (y>=Posicion.Y + Dimencion.Height-1 && y <= Posicion.Y + Dimencion.Height + 1))
            {
                if (EstoyAlFrente())
                {
                    //hay que cambiar el puntero del raton
                    CmbiaCursor(Cursors.SizeNWSE);
                    return true;
                }

            }

           else if ((x >= Posicion.X-1 && x <= Posicion.X+1) || (x >= Posicion.X + Dimencion.Width-1 && x <= Posicion.X + Dimencion.Width+1))
            {
                if (EstoyAlFrente())
                {
                    //hay que cambiar el puntero del raton
                    CmbiaCursor(Cursors.SizeWE);
                    return true;
                }

            }
           else if((y >= Posicion.Y-1 && y <= Posicion.Y+1) || (y >= Posicion.Y + Dimencion.Height-1 && y <= Posicion.Y + Dimencion.Height+1))
            {
                if (EstoyAlFrente())
                {
                    //hay que cambiar el puntero del raton
                    CmbiaCursor(Cursors.SizeNS);
                    return true;
                }
            }
            CmbiaCursor(Cursors.Default);
            return base.OnMouseMove(sender, e, x, y);
        }
        public override bool OnMouseDown(object sender, MouseEventArgs e, int x, int y)
        {
            //verifico si estoy en una de mis orillas
            if ((x >= Posicion.X-1 && x <= Posicion.X+1) || (x >= Posicion.X + Dimencion.Width-1 && x <= Posicion.X + Dimencion.Width + 1) || (y >= Posicion.Y-1&& y <= Posicion.Y + 1) || (y >= Posicion.Y + Dimencion.Height-1&& y <= Posicion.Y + Dimencion.Height + 1))
            {
                Dimencionando = true;
                CapturaMouse();
                //asigno la direccion
                if((x >= Posicion.X + Dimencion.Width-1 && x <= Posicion.X + Dimencion.Width + 1) && (y >= Posicion.Y + Dimencion.Height-1 && y <= Posicion.Y + Dimencion.Height + 1))
                {
                    direccion = DockStyle.Fill;
                }
                else if (x >= Posicion.X-1 && x <= Posicion.X+1)
                {
                    direccion = DockStyle.Left;
                }
                else if (x >= Posicion.X + Dimencion.Width-1 && x <= Posicion.X + Dimencion.Width + 1)
                {
                    direccion = DockStyle.Right;
                }
                else if (y >= Posicion.Y-1 && y <= Posicion.Y + 1)
                {
                    direccion = DockStyle.Top;
                }
                else if( y >= Posicion.Y + Dimencion.Height-1 && y <= Posicion.Y + Dimencion.Height + 1)
                {
                    direccion = DockStyle.Bottom;
                }
                    return true;
            }
            return base.OnMouseDown(sender, e, x, y);
        }
        public override bool OnMouseUp(object sender, MouseEventArgs e, int x, int y)
        {
            if(Dimencionando)
            {
                CmbiaCursor(Cursors.Default);
                LiberaRaton();
                Dimencionando = false; //termina el proceso
                return true;
            }
            return base.OnMouseUp(sender, e, x, y);
        }
        /// <summary>
        /// se  llama cuando se modifica la dimencion
        /// </summary>
        protected virtual void Redimencionado()
        {

        }
    }
}
