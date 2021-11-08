using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoIndex: CNodoBase
    {
        CTabla Tabla;
        Cindex Index;
        CVisorIndex Visor;
        private System.Windows.Forms.ContextMenuStrip MenuIndex;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        public CNodoIndex(CTabla tabla, Cindex index)
        {
            Tabla = tabla;
            Index = index;
            Text = Index.Nombre;
            ImageIndex = 5;
            SelectedImageIndex = 5;
            if(Tabla.EsPrimaryKey(index))
            {
                ImageIndex = 1;
                SelectedImageIndex = 1;
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
                Visor = new CVisorIndex(Index);
            return Visor;
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuIndex = new ContextMenuStrip();
            MenuEliminar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuIndex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.MenuIndex.Name = "MenuFk";
            this.MenuIndex.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar Index";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            return MenuIndex;

        }
        private void MenuEliminar_Click(object sender,EventArgs e)
        {
            try
            {
                string nombre = Index.Nombre;
                //veo si es la llave primaria de la tabla
                if (Tabla.PrimaryKey == null || Tabla.PrimaryKey.Nombre != nombre)
                {
                    if (MessageBox.Show("Desea eliminar el indice: " + nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    Tabla.RemoveIndex(nombre);
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar la llave primaria", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    Tabla.RemovePK();
                }
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
