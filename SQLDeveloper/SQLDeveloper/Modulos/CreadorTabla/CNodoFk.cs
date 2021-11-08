using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    class CNodoFk:CNodoBase
    {
        CTabla Tabla;
        CForeignKey FK;
        CVisorFk Visor;
        private System.Windows.Forms.ContextMenuStrip MenuFk;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        public CNodoFk(CTabla tabla, CForeignKey fk)
        {
            Tabla = tabla;
            FK = fk;
            ImageIndex = 4;
            SelectedImageIndex = 4;
            Text = fk.Nombre;
        }
        public override CVisorBase GetVisor()
        {
            if(Visor==null)
            {
                Visor = new CVisorFk(Tabla,FK);
            }
            return Visor;
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuFk = new ContextMenuStrip();
            MenuEliminar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuFk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.MenuFk.Name = "MenuFk";
            this.MenuFk.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar Relación";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            return MenuFk;
        }
        private void MenuEliminar_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar la relacion: " + FK.Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                Tabla.RemoveForeignKey(this.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RefreshParent();
        }
    }
}
