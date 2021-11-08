using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.Visores.Trrigers
{
    class CNodoEvento : TreeNode
    {
        private string Tabla;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.ComponentModel.IContainer components = null;
        private MotorDB.EnumEventTriger FDisparador;
        private void CreaMenu()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrigger));
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(154, 48);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("MenuAgregar.Image")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(153, 22);
            this.MenuAgregar.Text = "Agregar Trriger";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            this.ContextMenuStrip = Menu;
        }
        public MotorDB.EnumEventTriger Disparador
        {
            get
            {
                return FDisparador;
            }
            set
            {
                FDisparador = value;
                Text = FDisparador.ToString();
                switch (FDisparador)
                {
                    case MotorDB.EnumEventTriger.DELETE:
                        ImageIndex = 8;
                        SelectedImageIndex = 8;
                        break;
                    case MotorDB.EnumEventTriger.INSERT:
                        ImageIndex = 6;
                        SelectedImageIndex = 6;
                        break;
                    case MotorDB.EnumEventTriger.UPDATE:
                        ImageIndex = 7;
                        SelectedImageIndex = 7;
                        break;
                }
            }
        }
        public CNodoEvento(string tabla, MotorDB.EnumEventTriger ev, MotorDB.EnumMomentTriger t = MotorDB.EnumMomentTriger.AFTER)
        {
            Tabla = tabla;
            Disparador = ev;
            CreaMenu();
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {

        }
        public void AddTrriger(MotorDB.CTrigger obj)
        {
            //Nodes.Clear();
            //recorro todos los objetos y agrego los que me corresponden
            if (obj.Disparador == Disparador)
            {
                CNodoTrigger nodo = new CNodoTrigger();
                nodo.Nombre = obj.Nombre;
                nodo.Tag = obj;
                Nodes.Add(nodo);
            }
        }
    }
}
