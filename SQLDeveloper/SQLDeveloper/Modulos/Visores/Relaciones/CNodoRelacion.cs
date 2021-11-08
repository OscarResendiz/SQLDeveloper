using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.Visores.Relaciones
{
    public class CNodoRelacion:TreeNode
    {
        MotorDB.IMotorDB Motor;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuVer;
        private System.Windows.Forms.ToolStripMenuItem MenuHijosPadres;
        private System.ComponentModel.IContainer components = null;
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        TreeNode Padres;
        TreeNode Hijos;
        private void CreaMenu()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelaciones));
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHijosPadres = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVer,
            this.MenuHijosPadres});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(193, 70);
            // 
            // MenuVer
            // 
            this.MenuVer.Image = ((System.Drawing.Image)(resources.GetObject("MenuVer.Image")));
            this.MenuVer.Name = "MenuVer";
            this.MenuVer.Size = new System.Drawing.Size(192, 22);
            this.MenuVer.Text = "Ver";
            this.MenuVer.Click += new System.EventHandler(this.MenuVer_Click);
            // 
            // MenuHijosPadres
            // 
            this.MenuHijosPadres.Image = ((System.Drawing.Image)(resources.GetObject("MenuHijosPadres.Image")));
            this.MenuHijosPadres.Name = "MenuHijosPadres";
            this.MenuHijosPadres.Size = new System.Drawing.Size(192, 22);
            this.MenuHijosPadres.Text = "Mostrar Relaciones";
            this.MenuHijosPadres.Click += new System.EventHandler(this.MenuHijosPadres_Click);
            this.ContextMenuStrip = Menu;
        }
        public CNodoRelacion(MotorDB.IMotorDB motor)
        {
            Motor = motor;
            FTipo = MotorDB.EnumTipoObjeto.TABLE;
            CreaMenu();
        }
        public string Nombre
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        private MotorDB.EnumTipoObjeto FTipo;
        public MotorDB.EnumTipoObjeto Tipo
        {
            get
            {
                return FTipo;
            }
            set
            {
                FTipo = value;
                switch (FTipo)
                {
                    case MotorDB.EnumTipoObjeto.FUNCION:
                        ImageIndex = 2;
                        SelectedImageIndex = 2;
                        break;
                    case MotorDB.EnumTipoObjeto.PROCEDURE:
                        ImageIndex = 3;
                        SelectedImageIndex = 3;
                        break;
                    case MotorDB.EnumTipoObjeto.TABLE:
                        ImageIndex = 0;
                        SelectedImageIndex = 0;
                        break;
                    case MotorDB.EnumTipoObjeto.TRIGER:
                        ImageIndex = 4;
                        SelectedImageIndex = 4;
                        break;
                    case MotorDB.EnumTipoObjeto.VIEW:
                        ImageIndex = 1;
                        SelectedImageIndex = 1;
                        break;
                    case MotorDB.EnumTipoObjeto.DATABSE:
                        ImageIndex = 5;
                        SelectedImageIndex = 5;
                        break;
                }

            }
        }
        private void MenuVer_Click(object sender, EventArgs e)
        {
            if(OnVerObjeto!=null)
            {
                OnVerObjeto(Motor,Nombre, Tipo);
            }                
        }
        private void MenuHijosPadres_Click(object sender, EventArgs e)
        {
            CargaRelaciones();

        }
        public void CargaRelaciones()
        {
            //Limpio los nodos
            Nodes.Clear();
            //agrego los nodos de padres e hijos
            //6
            Padres = new TreeNode("Padres", 6, 6);
            Hijos = new TreeNode("Hijos", 6, 6);
            Nodes.Add(Padres);
            Nodes.Add(Hijos);
            //me traigo los padres de la tabla
            List<MotorDB.CForeignKey> listaPadres = Motor.DameLLavesForaneas(Nombre);
            //me traigo a los hijos
            List<MotorDB.CForeignKey> listaHijos = Motor.DameLLavesForaneasHijas(Nombre);
            //agrego los padres al arbol
            foreach (MotorDB.CForeignKey fkp in listaPadres)
            {
                CNodoRelacion padre = new CNodoRelacion(Motor);
                padre.Nombre = fkp.TablaPadre;
                padre.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
                Padres.Nodes.Add(padre);
            }
            //ahora agrego los hijos
            foreach (MotorDB.CForeignKey fkh in listaHijos)
            {
                CNodoRelacion hijo = new CNodoRelacion(Motor);
                hijo.Nombre = fkh.TablaHija;
                hijo.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
                Hijos.Nodes.Add(hijo);
            }
            this.Expand();
            Padres.Expand();
            Hijos.Expand();
        }
        private void VerObjeto(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            if (OnVerObjeto != null)
            {
                OnVerObjeto(Motor, nombre, tipo);
            }
        }

    }
}
