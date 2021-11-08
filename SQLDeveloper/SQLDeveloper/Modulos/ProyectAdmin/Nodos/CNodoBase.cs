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
    public class CNodoBase: TreeNode
    {
        #region menus
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuCoiarNombre;
        private System.Windows.Forms.ToolStripMenuItem MenuBuscar;
        #endregion
        protected System.ComponentModel.IContainer components = null;
//        protected System.ComponentModel.ComponentResourceManager resources;
        private ModeloBasico FMOdelo;
        public CNodoBase()
        {
            this.components = new System.ComponentModel.Container();
  //          resources = GetResource();
        }
        public virtual void Expandido()
        {
            //se sobre escibe para manejar el vento de expandido
        }
        public virtual void Colapsado()
        {
            //se sobre escibe para manejar el vento de colapsado

        }
        public virtual void RefreshData()
        {
            //se debe de sustituir para manejarlo por separado
        }
        public virtual void ModeloAsignado()
        {
            //se debe de sustituir para manejarlo por separado
        }
        public virtual void Seleccionado()
        {
            //se llama cuando el usuario lo selecciona
        }
//        protected System.ComponentModel.ComponentResourceManager GetResource()
  //      {
    //        return new System.ComponentModel.ComponentResourceManager(typeof(Recursos));
      //  }
        protected virtual ContextMenuStrip CreaMenu()
        {
            if (MenuPrinciapl != null)
                return MenuPrinciapl;
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            MenuCoiarNombre = new System.Windows.Forms.ToolStripMenuItem();
            MenuBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuBuscar,
            MenuCoiarNombre
             });
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);

            // 
            // MenuCoiarNombre
            // 
            this.MenuCoiarNombre.Image = ImageManager.getImagen("copiar");  //((System.Drawing.Image)(resources.GetObject("copiar")));
            this.MenuCoiarNombre.Name = "MenuCoiarNombre";
            this.MenuCoiarNombre.Size = new System.Drawing.Size(201, 22);
            this.MenuCoiarNombre.Text = "Copiar nombre al portapapeles";
            this.MenuCoiarNombre.Click += new System.EventHandler(this.MenuCoiarNombre_Click);
            //
            //MenuBuscar
            //
            this.MenuBuscar.Image = ImageManager.getImagen("buscar");  // ((System.Drawing.Image)(resources.GetObject("buscar")));
            this.MenuBuscar.Name = "MenuBuscar";
            this.MenuBuscar.Size = new System.Drawing.Size(201, 22);
            this.MenuBuscar.Text = "Buscar";
            this.MenuBuscar.Click += new System.EventHandler(this.MenuBuscar_Click);

            return MenuPrinciapl;
        }
        private void MenuBuscar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Buscar";
            dlg.OnNombre += new Forms.ONFormNombreEvent(BuscarNombreCarpeta);
            dlg.ShowDialog();
        }
        private bool BuscarNombreCarpeta(Forms.FormNombre sender, string nombre)
        {
            BuscaNodo(nombre);
            return true;
        }
        private void MenuCoiarNombre_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Nombre);
        }
        protected void RefreshParent()
        {
            CNodoBase padre = (CNodoBase)this.Parent;
            padre.RefreshData();
        }
        public string Nombre
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        public ModeloBasico Modelo
        {
            get
            {
                return FMOdelo;
            }
            set
            {
                FMOdelo = value;
                if (FMOdelo != null)
                {
                    ModeloAsignado();
                }
            }
        }
        public virtual void Monitorea()
        {
            //esta funcion debe de sobrecargarse cuando se nececite hacer una revision de los objetos 
            //que se estan monitoreando
        }
        public virtual void PreparaMenu()
        {
            if (ContextMenuStrip==null)
                this.ContextMenuStrip = CreaMenu();

        }
        public virtual void NodeDrop(CNodoBase nodo)
        {

        }
        public virtual void DoubleClick(TreeNodeMouseClickEventArgs e)
        {
            //hay que sobre escribirlo
            
        }
        protected void BuscaNodo(string nombre)
        {
            //veo si soy yo
            if (Nombre.ToUpper().Trim() == nombre.ToUpper().Trim())
            {
                this.TreeView.SelectedNode = this;
                ForeColor = Color.Red;
               // return;
            }
            else
            {
                ForeColor = Color.Black;
            }
            foreach (CNodoBase n in Nodes)
            {
                n.BuscaNodo(nombre);
            }
        }
    }
}
