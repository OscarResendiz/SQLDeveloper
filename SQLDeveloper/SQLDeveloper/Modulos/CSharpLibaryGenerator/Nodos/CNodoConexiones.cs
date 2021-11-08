using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    class CNodoConexiones : CNodoBase
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        public CNodoConexiones()
        {
            Text = "Servidores";
            ImageIndex = 1;
            SelectedImageIndex = 1;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            });
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuPrimaryKey
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Conexiòn";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            return MenuPrinciapl;
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            ManagerConnect.FormSelectConecion dlg = new ManagerConnect.FormSelectConecion();
            dlg.OnConexion += new ManagerConnect.OnFormConexionInicialEvent(ConecionSeleccionada);
            dlg.ShowDialog();
        }
        private void ConecionSeleccionada(string grupo, ManagerConnect.CConexion conexion)
        {
            //veo si ya existe el grupo
            CNodoGrupo Grupo = null;
            foreach (CNodoGrupo obj in Nodes)
            {
                if (obj.Nombre == grupo)
                {
                    Grupo = obj;
                    break;
                }
            }
            if (Grupo == null)
            {
                Grupo = new CNodoGrupo();
                Grupo.Nombre = grupo;
                Grupo.Modelo = Modelo;
                Nodes.Add(Grupo);
                //lo agrego al modelo
                Modelo.AgregaServidor(Grupo.Nombre);
                Cservidor ser = Modelo.DameServidor(Grupo.Nombre);
                Grupo.ID_Servidor = ser.ID_Servidor;
            }
            Grupo.AgregaConexion(conexion);
        }
        public override void ModeloAsignado()
        {
            Modelo.OnServidorChange += new OnModeloNetEvent(ServidorChange);
        }
        private void ServidorChange(ModeloNet sender)
        {
            CargaModelo();
        }
        public override void CargaModelo()
        {
            //me traigo los servidores del modelo
            List<Cservidor> l = Modelo.DameServidores();
            //quito los que ya no estan en el modelo
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                bool encontrado = false;
                CNodoGrupo Grupo = (CNodoGrupo)Nodes[i];
                foreach (Cservidor obj in l)
                {
                    if (Grupo.ID_Servidor == obj.ID_Servidor)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Nodes.Remove(Grupo);
                }
            }
            //ahora agrego los que no estan
            foreach (Cservidor obj in l)
            {
                bool encontrado = false;
                foreach (CNodoGrupo servidor in Nodes)
                {
                    if(obj.ID_Servidor==servidor.ID_Servidor)
                    {
                        //como ya existe, que se lo salte
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    //como no esta, lo agrega
                    CNodoGrupo Grupo = new CNodoGrupo();
                    Grupo.Nombre = obj.Nombre;
                    Grupo.ID_Servidor = obj.ID_Servidor;
                    Grupo.Modelo = Modelo;
                    Nodes.Add(Grupo);
                }
            }
        }
    }
}
