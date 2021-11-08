using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Modelador.Dibujable
{
   public class CDibujable
    {
        protected List<CDibujable> hijos;
        public CDibujable()
        {
            hijos = new List<CDibujable>();
        }
        //funcion que hay que sobreescribir para que se pinten
        public virtual void Dibuja(MiGraphics graphics)
        {
        }
        protected virtual void DibujaHijos(MiGraphics graphics)
        {
            foreach (CDibujable obj in hijos)
            {
                obj.Dibuja(graphics);
            }

        }
        public virtual void DibujaFinal(MiGraphics graphics)
        {
            if (hijos != null)
            {
                foreach (CDibujable obj in hijos)
                {
                    obj.DibujaFinal(graphics);
                }
            }
        }
        public virtual void GeneraMapa(MiGraphics graphics)
        {
            foreach (CDibujable obj in hijos)
            {
                obj.GeneraMapa(graphics);
            }

        }
        public virtual void Free()
        {
            if (hijos == null)
                return;
            for(int i=hijos.Count-1;i>=0;i-- )
            {
                CDibujable obj = hijos[i];
                obj.Free();
                hijos.Remove(obj);
            }
            hijos = null;
        }
    }
}
