using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Modelador
{
    public class ImageManager
    {
        private static Dictionary<String, System.Drawing.Image> Imagenes;
        private static Dictionary<String, System.Drawing.Icon> Iconos;
        private static System.ComponentModel.ComponentResourceManager resources;
        public static System.Drawing.Image getImagen(string nombre)
        {
            if (Imagenes == null)
                Imagenes = new Dictionary<string, Image>();
            if (Imagenes.ContainsKey(nombre))
            {
                return Imagenes[nombre];
            }
            if (resources == null)
            {
                resources = GetResource();
            }

            System.Drawing.Image img = ((System.Drawing.Image)(resources.GetObject(nombre)));
            Imagenes.Add(nombre, img);
            return img;
        }
        public static System.Drawing.Icon getIcon(string nombre)
        {
            if (Iconos == null)
                Iconos = new Dictionary<string, Icon>();
            if (Iconos.ContainsKey(nombre))
            {
                return Iconos[nombre];
            }
            if (resources == null)
            {
                resources = GetResource();
            }

            System.Drawing.Icon img = ((System.Drawing.Icon)(resources.GetObject(nombre)));
            Iconos.Add(nombre, img);
            return img;
        }
        private static System.ComponentModel.ComponentResourceManager GetResource()
        {
            return new System.ComponentModel.ComponentResourceManager(typeof(Recursos));
        }


    }
}
