using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoLineaArchivo: CNodoBase
    {
        public int ID_Archivo
        {
            get;
            set;
        }
        public int ID_Linea
        {
            get;
            set;
        }
        public string Texto
        {
            get;
            set;
        }
        public CNodoLineaArchivo(int id_archivo, int id_Linea)
        {
            ID_Archivo = id_archivo;
            ID_Linea = id_Linea;

        }
        public override void ModeloAsignado()
        {
            ObjetosModelo.CLineaArchivo obj = Modelo.GetLineaArchivo(ID_Linea);
            Nombre = obj.Texto;
            Modelo.LineaArchivoUpdatetEvent += new ObjetosModelo.OnAppModelEventDelegate(LineaArchivoUpdate);
        }
        public override void Free()
        {
            base.Free();
            Modelo.LineaArchivoUpdatetEvent -= LineaArchivoUpdate;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
            this.AddMenuItem("Eliminar de todos los Archivos", "IconoEliminar", MenuEliminarArchivos);
            this.AddMenuItem("Editar", "IconoEditar", MenuIconoEditar);
            this.AddMenuItem("Editar todas las coincidencias", "IconoEditar", MenuIconoEditarCoincidencias);
            //        this.AddMenuItem("Agregar Objeto", "IconoAgregar", MenuAgregarObjeto);
        }
        private void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("¿Eliminar Lalinea?", "Eliminar", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            ObjetosModelo.CLineaArchivo c = Modelo.GetLineaArchivo(this.ID_Linea);
            try
            {
                c.delete();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void MenuEliminarArchivos(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.MessageBox.Show("¿Eliminar todas las coicidencias?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
                    return;
                List<ObjetosModelo.CLineaArchivo> l = Modelo.GetCoincidenciasLineaArchivos(this.Text);
                int max = l.Count();
                for (int i = l.Count() - 1; i >= 0; i--)
                {
                    l[i].delete();
                }
                System.Windows.MessageBox.Show("Se eliminaron " + max.ToString() + " Cadenas", "Eliminar", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void MenuIconoEditar(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Texto = "Cadena";
            dlg.Nombre = this.Text;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            ObjetosModelo.CLineaArchivo obj = Modelo.GetLineaArchivo(this.ID_Linea);
            obj.Texto = dlg.Nombre;
            obj.update();
        }
        private void MenuIconoEditarCoincidencias(object sender, EventArgs e)
        {
            try
            {
                Forms.FormNombre dlg = new Forms.FormNombre();
                dlg.Texto = "Cadena";
                dlg.Nombre = this.Text;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                List<ObjetosModelo.CLineaArchivo> l = Modelo.GetCoincidenciasLineaArchivos(this.Text);
                foreach (ObjetosModelo.CLineaArchivo obj in l)
                {
                    obj.Texto = dlg.Nombre;
                    obj.update();
                }
                System.Windows.MessageBox.Show("Se actualizaron " + l.Count().ToString() + " Cadenas", "Editar", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void LineaArchivoUpdate(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CLineaArchivo obj2 = (ObjetosModelo.CLineaArchivo)obj;
            if(obj2.ID_Linea==this.ID_Linea)
            {
                Nombre = obj2.Texto;
            }
        }
    }
}
   