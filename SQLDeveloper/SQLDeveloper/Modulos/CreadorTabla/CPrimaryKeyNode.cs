using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.CreadorTabla
{
   
    public class CPrimaryKeyNode: CNodoBase
    {
        System.Windows.Forms.ContextMenuStrip MenuPK;
        System.Windows.Forms.ToolStripMenuItem MenuEliminarPk;
        CTabla Tabla;
        protected override ContextMenuStrip CreaMenu()
        {
            
            this.MenuPK = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuEliminarPk = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuPK
            // 
            this.MenuPK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminarPk});
            this.MenuPK.Name = "MenuPK";
            this.MenuPK.Size = new System.Drawing.Size(192, 48);
            // 
            // MenuEliminarPk
            // 
            this.MenuEliminarPk.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminarPk.Name = "MenuEliminarPk";
            this.MenuEliminarPk.Size = new System.Drawing.Size(191, 22);
            this.MenuEliminarPk.Text = "Eliminar llave primaria";
            this.MenuEliminarPk.Click += new System.EventHandler(this.MenuEliminarPk_Click);
            return MenuPK;
        }
        private CPrimaryKey pk;
        public CPrimaryKeyNode(CTabla tabla)
        {
            Tabla = tabla;
            Text = "Primary Key";
            SelectedImageIndex = 1;
            ImageIndex = 1;
            //CreaMenu();
        }
        public CPrimaryKey Pk
        {
            get
            {
                return pk;
            }
            set
            {
                pk = value;
                Text = pk.Nombre + " (Primary key)";
            }
        }
        public override CVisorBase GetVisor()
        {
            CVisorPK visor = new CVisorPK(pk);
            return visor;
        }
        private void MenuEliminarPk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar la llave primaria", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Tabla.RemovePK();
                //DBProvider.DB.EliminaPk(Tabla.Nombre);
                CNodoBase padre = (CNodoBase)Parent;
                padre.RefreshData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
