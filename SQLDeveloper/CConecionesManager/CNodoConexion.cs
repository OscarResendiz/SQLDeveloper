using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;

namespace ManagerConnect
{
    class CNodoConexion : CNodoBase
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminConexiones));
        private System.ComponentModel.IContainer Components = new System.ComponentModel.Container();
        #region Menu Contextual
        private System.Windows.Forms.ContextMenuStrip MenuConexion;
        private System.Windows.Forms.ToolStripMenuItem MenuEditarConexion;
        private System.Windows.Forms.ToolStripMenuItem MenuClonarConexion;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminarConexion;
        #endregion
        private void CreaMenu()
        {
            this.MenuConexion = new System.Windows.Forms.ContextMenuStrip(this.Components);
            this.MenuEditarConexion = new System.Windows.Forms.ToolStripMenuItem();
            MenuClonarConexion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminarConexion = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuConexion
            // 
            this.MenuConexion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditarConexion,
            MenuClonarConexion,
            this.MenuEliminarConexion});
            this.MenuConexion.Name = "MenuConexion";
            this.MenuConexion.Size = new System.Drawing.Size(153, 70);
            // 
            // MenuEditarConexion
            // 
            this.MenuEditarConexion.Image = ((System.Drawing.Image)(resources.GetObject("MenuEditarConexion.Image")));
            this.MenuEditarConexion.Name = "MenuEditarConexion";
            this.MenuEditarConexion.Size = new System.Drawing.Size(152, 22);
            this.MenuEditarConexion.Text = "Editar";
            this.MenuEditarConexion.Click += new System.EventHandler(this.MenuEditarConexion_Click);
            // 
            // MenuClonarConexion
            // 
            this.MenuClonarConexion.Image = ((System.Drawing.Image)(resources.GetObject("MenuCopiarConexion.Image")));
            this.MenuClonarConexion.Name = "MenuEditarConexiòn";
            this.MenuClonarConexion.Size = new System.Drawing.Size(152, 22);
            this.MenuClonarConexion.Text = "Clonar Conexiòn";
            this.MenuClonarConexion.Click += new System.EventHandler(this.MenuClonarConexion_Click);
            // 
            // MenuEliminarConexion
            // 
            this.MenuEliminarConexion.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminarConexion.Image")));
            this.MenuEliminarConexion.Name = "MenuEliminarConexion";
            this.MenuEliminarConexion.Size = new System.Drawing.Size(152, 22);
            this.MenuEliminarConexion.Text = "Eliminar";
            this.MenuEliminarConexion.Click += new System.EventHandler(this.MenuEliminarConexion_Click);
            this.ContextMenuStrip = MenuConexion;
        }
        public CNodoConexion()
        {
            ImageIndex = 2;
            SelectedImageIndex = 2;
            Text = "Sin Nombre";
            CreaMenu();
        }
        private void MenuEliminarConexion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar la conexion?", "Eliminar Conexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //me traigo el grupo al que pertenesco
            string grupo = Parent.Text;
            try
            {
                ControladorConexiones.DeleteConexion(grupo, Text);
            }
            catch (System.Exception ex)
            {
                //muestro el mensaje de error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Remove();

        }
        private void MenuEditarConexion_Click(object sender, EventArgs e)
        {
            //me traigo el grupo al que pertenesco
            string grupo = Parent.Text;
            //me traigo la conexion
            CConexion obj = ControladorConexiones.GetConexion(grupo, Text);
            IMotorDB motor = CProviderDataBase.DameMotor(ControladorConexiones.DameTipoMotor(obj.MotorDB));
            motor.SetConnectionName(obj.Nombre);
            motor.SetConnectionString(obj.ConecctionString);
            //mando a mostrar la pantalla de configuracion del motor
            if (motor.ShowDlgConfig() != DialogResult.OK)
            {
                //se cancelo, por lo que no hago nada
                return;
            }
            CConexion con = new CConexion();
            con.Nombre = motor.GetConnectionName();
            con.ConecctionString = motor.GetConecctionString();
            try
            {
                ControladorConexiones.ActualizaConexion(grupo, Text, con.ConecctionString, con.Nombre);
            }
            catch (System.Exception ex)
            {
                //muestro el mensaje de error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Text != con.Nombre && con.Nombre != "" && con.Nombre != null)
                Text = con.Nombre;
        }
        private void MenuClonarConexion_Click(object sender, EventArgs e)
        {
            //me traigo el grupo al que pertenesco
            string grupo = Parent.Text;
            //me traigo la conexion
            CConexion obj = ControladorConexiones.GetConexion(grupo, Text);
            IMotorDB motor = CProviderDataBase.DameMotor(ControladorConexiones.DameTipoMotor(obj.MotorDB));
            motor.SetConnectionName("");
            motor.SetConnectionString(obj.ConecctionString);
            //mando a mostrar la pantalla de configuracion del motor
            if (motor.ShowDlgConfig() != DialogResult.OK)
            {
                //se cancelo, por lo que no hago nada
                return;
            }
            //CConexion con = new CConexion();
            obj.Nombre = motor.GetConnectionName();
            obj.MotorDB = motor.GetMotor().ToString();// EnumMotoresDB.SQLSERVER.ToString();
            obj.ConecctionString = motor.GetConecctionString();
            try
            {
                ControladorConexiones.AddConexion(grupo, obj.MotorDB, obj.Nombre, obj.ConecctionString);
            }
            catch (System.Exception ex)
            {
                //muestro el mensaje de error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //agrego el nodo
            CNodoConexion nodo = new CNodoConexion();
            nodo.Text = obj.Nombre;
            nodo.Tag = obj;
            this.Parent.Nodes.Add(nodo);
        }
        public CConexion DameConexion()
        {
            string grupo = Parent.Text;
            return ControladorConexiones.GetConexion(grupo, Text);
        }
    }
}
