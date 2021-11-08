using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    class CNodoConexion : CNodoFolder
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private ManagerConnect.CConexion FConexion;
        public CNodoConexion()
        {
            Text = "Conexion";

        }
        public ManagerConnect.CConexion Conexion
        {
            get
            {
                return FConexion;
            }
            set
            {
                FConexion = value;
                if (FConexion != null)
                    Nombre = FConexion.Nombre;
            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            return MenuPrinciapl;
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar la conexion del proyecto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //veo si tiene objetos relacionados
            if(Modelo.DameSpsConexion(ID_Conexion).Count()>0)
            {
                MessageBox.Show("Tiene funciones asignadas en las clases, vafor de quitarlas primero", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Modelo.EliminaeConexion(ID_Conexion);
        }
        public string Servidor
        {
            get;
            set;
        }
        private void FinMultiSeleccion()
        {
            Nodes.Clear();
            ModeloAsignado();

        }
        public int ID_Conexion
        {
            get;
            set;
        }
    }
}
