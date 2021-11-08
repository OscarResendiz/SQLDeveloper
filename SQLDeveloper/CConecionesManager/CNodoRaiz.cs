using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerConnect
{
   public class CNodoRaiz : CNodoBase
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminConexiones));
        private System.ComponentModel.IContainer Components = new System.ComponentModel.Container();

        private System.Windows.Forms.ContextMenuStrip MenuRaiz;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoGrupo;

        private void CreaMenu()
        {
            // 
            // MenuNuevoGrupo
            // 
            this.MenuNuevoGrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoGrupo.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevoGrupo.Image")));
            this.MenuNuevoGrupo.Name = "MenuNuevoGrupo";
            this.MenuNuevoGrupo.Size = new System.Drawing.Size(145, 22);
            this.MenuNuevoGrupo.Text = "Nuevo Grupo";
            this.MenuNuevoGrupo.Click += new System.EventHandler(this.MenuNuevoGrupo_Click);
            // 
            // MenuRaiz
            //           
            this.MenuRaiz = new System.Windows.Forms.ContextMenuStrip(Components);
            //this.MenuRaiz.SuspendLayout();
            this.MenuRaiz.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevoGrupo});
            this.MenuRaiz.Name = "MenuRaiz";
            this.MenuRaiz.Size = new System.Drawing.Size(146, 26);
            this.ContextMenuStrip = MenuRaiz;
        }
        //representa el raiz de todo el arbol de conexiones
        public CNodoRaiz()
        {
            ImageIndex = 0;
            SelectedImageIndex = 0;
            Text = "Raiz";
            CreaMenu();
        }
        public void CargaGrupos()
        {
            List<string> l = ControladorConexiones.GetGrupos();
            foreach (string s in l)
            {
                CNodoGrupo nuevo = new CNodoGrupo();
                nuevo.Text = s;
                Nodes.Add(nuevo);
                nuevo.CargaConexiones();
            }
        }
        private void MenuNuevoGrupo_Click(object sender, EventArgs e)
        {
            //da de alta un nuevo grupo
            CNodoGrupo nuevo = new CNodoGrupo();
            Nodes.Add(nuevo);
            nuevo.BeginEdit();
        }
        public List<CConexion> DameConexionesSeleccionadas()
        {
            List<CConexion> l = new List<CConexion>();
            foreach (CNodoGrupo nodo in Nodes)
            {
                foreach (CConexion obj in nodo.DameConexionesSeleccionadas())
                {
                    obj.GrupoName = nodo.Text;
                    l.Add(obj);
                }
            }
            return l;
        }
        public void MarcaMotor(MotorDB.IMotorDB motor)
        {
            foreach (CNodoGrupo nodo in Nodes)
            {
                if (nodo.MarcaMotor(motor) == true)
                    this.Checked = true;
            }
        }
        public bool EstaSeleccionado(string servidor, string conexion)
        {
            foreach (CNodoGrupo nodo in Nodes)
            {
                if (nodo.Text == servidor)
                {
                    foreach (CConexion obj in nodo.DameConexionesSeleccionadas())
                    {
                        if (obj.Nombre == conexion)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
