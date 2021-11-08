using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    /// <summary>
    /// se encarga de manejar una sola copia de las imagenes de los menus para no gastar tanta memoria
    /// </summary>
    public class ImageManager
    {
        private static Dictionary<String ,System.Drawing.Image> Imagenes;
        private static System.ComponentModel.ComponentResourceManager resources;
        public static System.Drawing.Image getImagen(string nombre)
        {
            if (Imagenes == null)
                Imagenes = new Dictionary<string, Image>();
            if(Imagenes.ContainsKey(nombre))
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
        private static System.ComponentModel.ComponentResourceManager GetResource()
        {
            return new System.ComponentModel.ComponentResourceManager(typeof(Recursos));
        }


    }
}
