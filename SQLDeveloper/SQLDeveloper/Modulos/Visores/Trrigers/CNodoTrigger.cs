using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Trrigers
{
    class CNodoTrigger:TreeNode
    {
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuVer;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.ComponentModel.IContainer components = null;
        private void CreaMenu()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrigger));
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVer,
            this.MenuEliminar});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(153, 70);
            // 
            // MenuVer
            // 
            this.MenuVer.Image = ((System.Drawing.Image)(resources.GetObject("MenuVer.Image")));
            this.MenuVer.Name = "MenuVer";
            this.MenuVer.Size = new System.Drawing.Size(152, 22);
            this.MenuVer.Text = "Ver Codigo";
            this.MenuVer.Click += new System.EventHandler(this.MenuVer_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(152, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            this.ContextMenuStrip = Menu;

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
        public CNodoTrigger()
        {
            ImageIndex = 4;
            SelectedImageIndex = 4;
            CreaMenu();

        }
        private void MenuVer_Click(object sender, EventArgs e)
        {

        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {

        }

    }
}
