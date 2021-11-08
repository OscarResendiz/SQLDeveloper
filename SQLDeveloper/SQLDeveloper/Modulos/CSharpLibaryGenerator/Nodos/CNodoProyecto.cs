using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public delegate void CNodoProyectoNetEvent(CNodoProyecto sender);
    public class CNodoProyecto : CNodoFolder
    {
        public event CNodoProyectoNetEvent OnCerrarproyecto;
        private CNodoConexiones Conexiones;
        private CNodoClases Clases;
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuPropiedades;
        public CNodoProyecto()
        {
            Text = "Proyecto nuevo";
            ImageIndex = 0;
            SelectedImageIndex = 0;
            Conexiones = new CNodoConexiones();
            Clases = new CNodoClases();
            Conexiones.Modelo = Modelo;
            Clases.Modelo = Modelo;
            Nodes.Add(Conexiones);
            Nodes.Add(Clases);
        }
        public override void ModeloAsignado()
        {
            Conexiones.Modelo = Modelo;
            Clases.Modelo = Modelo;
            Modelo.OnProjectNameChange += new OnModeloNetEvent(ProjectNameChange);
        }
        private void ProjectNameChange(ModeloNet ender)
        {
            Nombre = Modelo.ProjectName;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPropiedades = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPropiedades});
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
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
            FormPropiedades dlg = new FormPropiedades(Modelo);
            dlg.ShowDialog();
        }
    }
}
