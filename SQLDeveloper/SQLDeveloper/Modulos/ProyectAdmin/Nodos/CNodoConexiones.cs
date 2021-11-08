using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoConexiones: CNodoBase
    {
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescarConexiones;
        public CNodoConexiones()
        {
            Text = "Servidores";
            ImageIndex = 1;
            SelectedImageIndex = 1;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRefrescar = new System.Windows.Forms.ToolStripMenuItem();
            MenuRefrescarConexiones = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar,
            MenuRefrescarConexiones});
            // 
            // MenuPrimaryKey
            // 
            this.MenuAgregar.Image = ImageManager.getImagen("IconoAgregar");  // ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Conexiòn";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // Actualizar Conexiones
            // 
            this.MenuRefrescarConexiones.Image = ImageManager.getImagen("refresh11"); // ((System.Drawing.Image)(resources.GetObject("refresh11")));
            this.MenuRefrescarConexiones.Name = "MenuRefrescarConexion";
            this.MenuRefrescarConexiones.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescarConexiones.Text = "Refrescar Conexiones";
            this.MenuRefrescarConexiones.Click += new System.EventHandler(this.MenuRefrescarConexiones_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ImageManager.getImagen("refresh11"); // ((System.Drawing.Image)(resources.GetObject("refresh11")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refrescar";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuPrinciapl;
        }
        private void MenuRefrescarConexiones_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.RefrescaConexiones();
                System.Windows.Forms.MessageBox.Show("Conexiones actualizadas", "Actualizacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            }
        }

        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            ManagerConnect.FormSelectConecion dlg = new ManagerConnect.FormSelectConecion();
            dlg.OnConexion += new ManagerConnect.OnFormConexionInicialEvent(ConecionSeleccionada);
            dlg.ShowDialog();
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
        }
        private void ConecionSeleccionada(string grupo, ManagerConnect.CConexion conexion)
        {
            //veo si ya existe el grupo
            CNodoGrupo Grupo = null;
            foreach(CNodoGrupo obj in Nodes)
            {
                if(obj.Nombre==grupo)
                {
                    Grupo = obj;
                    break;
                }
            }
            if(Grupo==null)
            {
                Grupo = new CNodoGrupo();
                Grupo.Nombre = grupo;
                Grupo.Modelo = Modelo;
                Nodes.Add(Grupo);
                //lo agrego al modelo
                Modelo.AgregaServidor(Grupo.Nombre);
            }
            Grupo.AgregaConexion(conexion);
        }
        public override void ModeloAsignado()
        {
            //me traigo los servidores del modelo
            Modelo.RefrescaConexiones();
            List<CModelServidor> l = Modelo.DameServidores();
            foreach (CModelServidor obj in l)
            {
                CNodoGrupo Grupo = new CNodoGrupo();
                Grupo.Nombre = obj.Nombre;
                Grupo.Modelo = Modelo;
                Nodes.Add(Grupo);
            }
        }
    }
}
