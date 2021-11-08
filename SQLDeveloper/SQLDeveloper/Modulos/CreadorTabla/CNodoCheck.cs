using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoCheck: CNodoBase
    {
        CTabla Tabla;
        CCheck Check;
        CVisorCheck Visor;
        private System.Windows.Forms.ContextMenuStrip MenuCheck;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        public CNodoCheck(CTabla tabla, CCheck check)
        {
            Tabla = tabla;
            Check = check;
            Text = check.Nombre;
            ImageIndex = 7;
            SelectedImageIndex = 7;
        }
        public override CVisorBase GetVisor()
        {
            if(Visor==null)
            {
                Visor = new CVisorCheck(Check);
            }
            return Visor;
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuCheck = new ContextMenuStrip();
            MenuEliminar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuCheck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.MenuCheck.Name = "MenuFk";
            this.MenuCheck.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar Regla";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            return MenuCheck;

        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar la regla: " + Check.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Tabla.RemoveCheck(Check.Nombre);
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
