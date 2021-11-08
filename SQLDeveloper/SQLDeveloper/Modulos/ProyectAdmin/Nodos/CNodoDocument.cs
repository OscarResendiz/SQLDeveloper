using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoDocument : CNodoBase,Editores.IComenarioDriver
    {
        //menu del objeto
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        private System.Windows.Forms.ToolStripMenuItem MenuRenombrar;
        public CNodoDocument()
        {
            ImageIndex = 21;
            SelectedImageIndex = 21;
        }
        public int ID_Document
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
        public ManagerConnect.CConexion Conexion
        {
            get;
            set;
        }
        public string Servidor
        {
            get;
            set;
        }
        public string Texto
        {
            get
            {
                if (Modelo != null)
                {
                    return Modelo.DameTextoDocumento(ID_Document);
                }
                return "";
            }
            set
            {
                if (Modelo != null)
                {
                    Modelo.AsignaTextoDocumento(ID_Document, value);
                }

            }
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar: " + Nombre + " del proyecto?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Modelo.EliminaDocumento(ID_Document);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            MenuRenombrar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuComentarios,
            MenuRenombrar,
            this.MenuEliminar
             });
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ImageManager.getImagen("IconoEliminar"); // ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuRefrescar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Quitar del proyecto";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ImageManager.getImagen("IconoEditar"); // ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
            this.MenuComentarios.Name = "MenuVerCodigo";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Editar";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);
            // 
            // MenuRenombrar
            // 
            this.MenuRenombrar.Image = ImageManager.getImagen("rename"); // ((System.Drawing.Image)(resources.GetObject("rename")));
            this.MenuRenombrar.Name = "MenuVerCodigo";
            this.MenuRenombrar.Size = new System.Drawing.Size(201, 22);
            this.MenuRenombrar.Text = "Cambiar Nombre";
            this.MenuRenombrar.Click += new System.EventHandler(this.MenuRenombrar_Click);
            return MenuPrinciapl;
        }
        private void MenuRenombrar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = Nombre;
            dlg.OnNombre += new Forms.ONFormNombreEvent(NuevoNombre);
            dlg.ShowDialog();
        }
        private bool NuevoNombre(Forms.FormNombre sender, string nuevoNombre)
        {
            try
            {
                Modelo.RenameDocument(ID_Document,nuevoNombre);
                Nombre = nuevoNombre;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            Editores.CEditorComentarios editor = new Editores.CEditorComentarios();
            editor.Driver = this;
            //me traigo el acceso al formulario
            FormProyect dlg = (FormProyect)TreeView.Tag;
            dlg.EditorComentario(editor, Nombre);
        }
        public override void DoubleClick(TreeNodeMouseClickEventArgs e)
        {
            MenuComentarios_Click(null, null);
        }
        public override void ModeloAsignado()
        {

            Modelo.OnCodigoDocumentChange += new OnModeloBasicoObjectEvent(CodigoDocumentChange);
        }
        #region implementacion de la interface IComentarioDriver
        private event Editores.IComentarioDriverEvent onDocumentChage;
        public void setDocumentChage(Editores.IComentarioDriverEvent DocumentChage)
        {
            onDocumentChage += DocumentChage;
        }
        public int getId()
        {
            return this.ID_Document;
        }
        public void setId(int id)
        {
            ID_Document = id;
        }
        public string getText()
        {
            return Modelo.DameTextoDocumento(ID_Document);
        }
        public void setText(string texto)
        {
            Modelo.AsignaTextoDocumento(ID_Document, texto);
        }
        public void Save()
        {

        }
        public string getName()
        {
            return this.Nombre;
        }
        public void setName(string nombre)
        {
            this.Nombre = nombre;
        }
        private void CodigoDocumentChange(int id_Document)
        {
            if(this.ID_Document==id_Document)
            {
                if (onDocumentChage != null)
                    onDocumentChage(this.ID_Document);
            }
        }
        #endregion
    }
}
   