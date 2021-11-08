using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoUnq: CNodoBase
    {
        CTabla Tabla;
        CUnique Unique;
        CVisorUnico Visor;
        private System.Windows.Forms.ContextMenuStrip MenuUnique;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        public CNodoUnq(CTabla tabla, CUnique unique)
        {
            Tabla = tabla;
            Unique = unique;
            ImageIndex = 6;
            SelectedImageIndex = 6;
            Text = unique.Nombre;
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuUnique = new ContextMenuStrip();
            MenuEliminar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuUnique.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.MenuUnique.Name = "MenuFk";
            this.MenuUnique.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar Valor unico";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            return MenuUnique;

        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro que desea eliminar la clave unica: " + Unique.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                Tabla.RemoveUnique(Unique.Nombre);
               // DBProvider.DB.AlterTable_DropUnique(Tabla.Nombre, Unique.Nombre);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RefreshParent();
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
                Visor = new CVisorUnico(Unique);
            return Visor;
        }
    }
}
