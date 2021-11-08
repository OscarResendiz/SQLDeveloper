using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoObjetoCarpeta : CNodoObjeto
    {
        public int ID_Carpeta
        {
            get;
            set;
        }
        public CNodoObjetoCarpeta(int id_objeto, int id_Carpeta): base(id_objeto)
        {
            
            ID_Objeto = id_objeto;
            ID_Carpeta = id_Carpeta;
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(ID_Objeto);
            Nombre = obj.Nombre;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
        }
        protected override void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("¿Deseas eliminar el objeto: " + Nombre + " de la carpeta?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CObjetoCarpeta obj = Modelo.GetObjetoCarpeta(this.ID_Carpeta, this.ID_Objeto);
            obj.delete();
        }
    }
}
   