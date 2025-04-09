using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;

namespace ManagerConnect
{
    class CNodoGrupo : CNodoBase
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminConexiones));
        private System.ComponentModel.IContainer Components = new System.ComponentModel.Container();
        #region Menu Contextual
        private System.Windows.Forms.ContextMenuStrip MenuGrupo;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevaConexion;
        private System.Windows.Forms.ToolStripMenuItem MenuSqlServer;
        private System.Windows.Forms.ToolStripMenuItem MenuMultiSqlServer;
        private System.Windows.Forms.ToolStripMenuItem MenuMultiMySql;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminarGrupo;
        private System.Windows.Forms.ToolStripMenuItem MenuMySql;
        private System.Windows.Forms.ToolStripMenuItem MenuOracle;
        #endregion
        private void CreaMenu()
        {
            this.MenuGrupo = new System.Windows.Forms.ContextMenuStrip(this.Components);
            this.MenuNuevaConexion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSqlServer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMultiSqlServer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminarGrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMySql = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMultiMySql = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOracle = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuGrupo
            // 
            this.MenuGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevaConexion,
            this.MenuEliminarGrupo});
            this.MenuGrupo.Name = "MenuRaiz";
            this.MenuGrupo.Size = new System.Drawing.Size(162, 70);
            // 
            // MenuNuevaConexion
            // 
            this.MenuNuevaConexion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSqlServer,
            this.MenuMultiSqlServer,
            this.MenuMySql,
            this.MenuMultiMySql,
            this.MenuOracle});
            this.MenuNuevaConexion.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevaConexion.Image")));
            this.MenuNuevaConexion.Name = "MenuNuevaConexion";
            this.MenuNuevaConexion.Size = new System.Drawing.Size(161, 22);
            this.MenuNuevaConexion.Text = "Nueva Conexion";
            // 
            // MenuSqlServer
            // 
            this.MenuSqlServer.Image = ((System.Drawing.Image)(resources.GetObject("MenuSqlServer.Image")));
            this.MenuSqlServer.Name = "MenuSqlServer";
            this.MenuSqlServer.Size = new System.Drawing.Size(152, 22);
            this.MenuSqlServer.Text = "SQL Server";
            this.MenuSqlServer.Click += new System.EventHandler(this.MenuSqlServer_Click);
            // 
            // MenuMultiSqlServer
            // 
            this.MenuMultiSqlServer.Image = ((System.Drawing.Image)(resources.GetObject("MenuSqlServer.Image")));
            this.MenuMultiSqlServer.Name = "MenuMultiSqlServer";
            this.MenuMultiSqlServer.Size = new System.Drawing.Size(152, 22);
            this.MenuMultiSqlServer.Text = "SQL Server multiple";
            this.MenuMultiSqlServer.Click += new System.EventHandler(this.MenuMultiSqlServer_Click);
            //
            // MenuEliminarGrupo
            // 
            this.MenuEliminarGrupo.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminarGrupo.Image")));
            this.MenuEliminarGrupo.Name = "MenuEliminarGrupo";
            this.MenuEliminarGrupo.Size = new System.Drawing.Size(161, 22);
            this.MenuEliminarGrupo.Text = "Eliminar Grupo";
            this.MenuEliminarGrupo.Click += new System.EventHandler(this.MenuEliminarGrupo_Click);
            // 
            // MenuMySql
            // 
            this.MenuMySql.Enabled = true;
            this.MenuMySql.Image = ((System.Drawing.Image)(resources.GetObject("MenuMySql.Image")));
            this.MenuMySql.Name = "MenuMySql";
            this.MenuMySql.Size = new System.Drawing.Size(152, 22);
            this.MenuMySql.Text = "MySql";
            this.MenuMySql.Click += new System.EventHandler(this.MenuMySql_Click);
            // 
            // MenuMultiMySql
            // 
            this.MenuMultiMySql.Image = ((System.Drawing.Image)(resources.GetObject("MenuSqlServer.Image")));
            this.MenuMultiMySql.Name = "MenuMultiMySql";
            this.MenuMultiMySql.Size = new System.Drawing.Size(152, 22);
            this.MenuMultiMySql.Text = "MySQL multiple";
            this.MenuMultiMySql.Click += new System.EventHandler(this.MenuMultiMySql_Click);
            // 
            // MenuPosgres
            // 
            this.MenuOracle.Enabled = true;
            this.MenuOracle.Image = ((System.Drawing.Image)(resources.GetObject("MenuOracle.Image")));
            this.MenuOracle.Name = "MenuPostgres";
            this.MenuOracle.Size = new System.Drawing.Size(152, 22);
            this.MenuOracle.Text = "Postgres";
            this.MenuOracle.Click += new System.EventHandler(this.MenuPosgres_Click);
            this.ContextMenuStrip = MenuGrupo;

        }
        public CNodoGrupo()
        {
            ImageIndex = 1;
            SelectedImageIndex = 1;
            Text = "Nuevo Grupo";
            CreaMenu();
        }
        public void CargaConexiones()
        {
            List<CConexion> l = ControladorConexiones.GetConexiones(Text);
            foreach (CConexion obj in l)
            {
                CNodoConexion nodo = new CNodoConexion();
                nodo.Text = obj.Nombre;
                nodo.Tag = obj;
                Nodes.Add(nodo);
            }
        }
        private void AgregaConexion(EnumMotoresDB tipo)
        {
            //me traigo el motor de base de datos seleccionado
            IMotorDB motor = CProviderDataBase.DameMotor(tipo);
            //mando a mostrar la pantalla de configuracion del motor
            if (motor.ShowDlgConfig() != DialogResult.OK)
            {
                //se cancelo, por lo que no hago nada
                return;
            }
            //me traigo los datos de la conexion
            CConexion obj = new CConexion();
            obj.Nombre = motor.GetConnectionName();
            obj.MotorDB = motor.GetMotor().ToString();// EnumMotoresDB.SQLSERVER.ToString();
            obj.ConecctionString = motor.GetConecctionString();
            //mando a agregar la conexion
            try
            {
                ControladorConexiones.AddConexion(Text, obj.MotorDB, obj.Nombre, obj.ConecctionString);
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
            Nodes.Add(nodo);

        }
        private void MenuSqlServer_Click(object sender, EventArgs e)
        {
            AgregaConexion(EnumMotoresDB.SQLSERVER);
        }
        private void MenuMySql_Click(object sender, EventArgs e)
        {
            AgregaConexion(EnumMotoresDB.MYSQL);
        }

        private void MenuPosgres_Click(object sender, EventArgs e)
        {
            AgregaConexion(EnumMotoresDB.POSTGRES);
        }

        private void MenuEliminarGrupo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el grupo " + Text + " y todas sus conexiones?", "Eliminar Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ControladorConexiones.DeleteGrupo(Text);
                    this.Remove();
                }
                catch (System.Exception ex)
                {
                    //muestro el mensaje de error
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        public List<CConexion> DameConexionesSeleccionadas()
        {
            List<CConexion> l = new List<CConexion>();
            foreach (CNodoConexion con in Nodes)
            {
                if (con.Checked)
                {
                    l.Add(con.DameConexion());
                }
            }
            return l;
        }
        public bool MarcaMotor(MotorDB.IMotorDB motor)
        {
            foreach (CNodoConexion con in Nodes)
            {
                if (con.DameConexion().ConecctionString == motor.GetConecctionString())
                {
                    con.Checked = true;
                    Checked = true;
                    return true;
                }
            }
            return false;
        }
        private void MenuMultiSqlServer_Click(object sender, EventArgs e)
        {
            AgregaConexionMultiple(EnumMotoresDB.SQLSERVER);
        }
        private void MenuMultiMySql_Click(object sender, EventArgs e)
        {
            AgregaConexionMultiple(EnumMotoresDB.MYSQL);
        }

        private void AgregaConexionMultiple(EnumMotoresDB tipo)
        {
            //me traigo el motor de base de datos seleccionado
            IMotorDB motor = CProviderDataBase.DameMotor(tipo);
            //mando a mostrar la pantalla de configuracion del motor
            if (motor.ShowDlgMultiConfig() != DialogResult.OK)
            {
                //se cancelo, por lo que no hago nada
                return;
            }
            //me traigo las conexiones que se seleccionaron
            int total = motor.GetConnectionsCount();
            for (int i = 0; i < total; i++)
            {
                AgregaConexion(motor.GetConnectionName(i), motor.GetConeccionString(i), motor.GetMotor());
            }
        }
        private void AgregaConexion(string nombre, string connectionstring, EnumMotoresDB motor)
        {
            CConexion obj = new CConexion();
            obj.Nombre = nombre;
            obj.MotorDB = motor.ToString();
            obj.ConecctionString = connectionstring;
            //mando a agregar la conexion
            try
            {
                ControladorConexiones.AddConexion(Text, obj.MotorDB, obj.Nombre, obj.ConecctionString);
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
            Nodes.Add(nodo);

        }
    }
}
