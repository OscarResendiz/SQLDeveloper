using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public class CNodoSP: CNodoBase
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuPropiedades;
        public int ID_Store
        {
            get;
            set;
        }
        public CNodoSP()
        {
            ImageIndex = 10;
            SelectedImageIndex = 10;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuPropiedades = new ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar
            ,MenuPropiedades});
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Quitar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuPropiedades
            // 
            this.MenuPropiedades.Image = ((System.Drawing.Image)(resources.GetObject("document")));
            this.MenuPropiedades.Name = "MenuPropiedades";
            this.MenuPropiedades.Size = new System.Drawing.Size(201, 22);
            this.MenuPropiedades.Text = "Propiedades";
            this.MenuPropiedades.Click += new System.EventHandler(this.MenuPropiedades_Click);
            return MenuPrinciapl;
        }
        private void MenuPropiedades_Click(object sender, EventArgs e)
        {
            CStoreProcedures sp=            Modelo.DameSp(this.ID_Store);
            CConexion con = Modelo.DameConexion(sp.ID_Conexion);
            MotorDB.IMotorDB motor = con.DameMotor();
            FormPropiedadesSP dlg = new FormPropiedadesSP(motor, Modelo, ID_Store);
            dlg.ShowDialog();
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar el SP del proyecto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //veo si tiene objetos relacionados
            Modelo.EliminaSP(ID_Store);
        }
    }
}
