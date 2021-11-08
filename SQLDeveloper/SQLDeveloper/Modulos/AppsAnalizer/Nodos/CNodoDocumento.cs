using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoDocumento: CNodoBase
    {
        public int ID_Document
        {
            get
            {
                return ID_Objeto;
            }
            set
            {
                ID_Objeto = value;
            }
        }
        public CNodoDocumento(int id_documento)
        {
            ImageIndex = 21;
            SelectedImageIndex = 21;

            ID_Document = id_documento;
        }
        public override void ModeloAsignado()
        {
            ObjetosModelo.CDocumento doc = Modelo.GetDocumento(ID_Document);
            this.Nombre = doc.Nombre;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Editar", "IconoEditar", MenuVerDocumento);
            this.AddMenuItem("Eliminar", "IconoEliminar", MenuEliminar);
        }
        protected virtual void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("¿Deseas eliminar el Documento: " + Nombre + " del proyecto?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CDocumento doc = Modelo.GetDocumento(this.ID_Document);
            doc.delete();
        }
        protected virtual void MenuVerDocumento(object sender, EventArgs e)
        {
            Editores.CEditorComentarios editor = new Editores.CEditorComentarios();
            editor.Driver = new CDcoumentDriver(this.ID_Document,this.Modelo);
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            //me traigo el acceso al formulario
            dlg.EditorComentario(editor, Nombre);
        }
    }
}
   