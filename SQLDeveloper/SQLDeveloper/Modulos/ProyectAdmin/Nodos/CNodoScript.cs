using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoScript : CNodoBase
    {
        //menu del objeto
        private System.Windows.Forms.ToolStripMenuItem MenuVerCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        private System.Windows.Forms.ToolStripMenuItem MenuCoiarCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuRenombrar;
        public CNodoScript()
        {
            ImageIndex = 20;
            SelectedImageIndex = 20;

        }
        public int ID_Script
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
        public ManagerConnect.CConexion Conexion
        {
            get;
            set;
        }
        public string Servidor
        {
            get;
            set;
        }
        public string Comentarios
        {
            get
            {
                if (Modelo != null)
                {
                    return Modelo.DameComentariosScript(ID_Script);
                }
                return "";
            }
            set
            {
                if (Modelo != null)
                {
                    Modelo.AsignaComentariosScript(ID_Script,value);
                }

            }
        }
        private void MenuVerCodigo_Click(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            FormProyect dlg = (FormProyect)TreeView.Tag;
            //me traigo el codigo de la base de datos
            string codigo = Modelo.DameCodigoScript(ID_Script);
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            CodeScriptManager fm = new CodeScriptManager();
            CModelScript obj = Modelo.DameScript(ID_Script);
            fm.ID_Script = ID_Script;
            fm.Nombre = obj.Nombre;
            fm.Modelo = Modelo;
            //mando a mostrar el codigo
            dlg.VerCodigo(Nombre, codigo, motor, Servidor, Conexion.Nombre, fm);
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar: " + Nombre + " del proyecto?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Modelo.EliminaScript(ID_Script);
                //Parent.Nodes.Remove(this);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
            dlg.Texto = Comentarios;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Comentarios = dlg.Texto;
        }
        private void MenuCoiarCodigo_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(CopiaCodigo);
            dlg.ShowDialog();
        }
        private bool CopiaCodigo(Forms.FormNombre sender, string nombre)
        {
            try
            {
                string codigo = Modelo.DameCodigoScript(ID_Script);
                Modelo.AgregaScript(ID_Conexion,ID_Carpeta,nombre, codigo);
                //lo muestro para que se pueda editar
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
                FormProyect dlg = (FormProyect)TreeView.Tag;
                CodeScriptManager fm = new CodeScriptManager();
                fm.ID_Script = ID_Script;
                fm.Nombre = nombre;
                fm.Modelo = Modelo;

                dlg.VerCodigo(nombre, codigo, motor, Servidor, Conexion.Nombre, fm);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuVerCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            MenuCoiarCodigo = new System.Windows.Forms.ToolStripMenuItem();
            MenuRenombrar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVerCodigo,
            MenuComentarios,
            MenuRenombrar,
            MenuCoiarCodigo,
            this.MenuEliminar
             });
            // 
            // MenuVerCodigo
            // 
            this.MenuVerCodigo.Image = ImageManager.getImagen("IconoEditar"); //  ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
            this.MenuVerCodigo.Name = "MenuVerCodigo";
            this.MenuVerCodigo.Size = new System.Drawing.Size(201, 22);
            this.MenuVerCodigo.Text = "Editar";
            this.MenuVerCodigo.Click += new System.EventHandler(this.MenuVerCodigo_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ImageManager.getImagen("IconoEliminar"); // ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuRefrescar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Quitar del proyecto";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ImageManager.getImagen("comentario"); //  ((System.Drawing.Image)(resources.GetObject("comentario")));
            this.MenuComentarios.Name = "MenuVerCodigo";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Cometarios";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);
            // 
            // MenuCoiarCodigo
            // 
            this.MenuCoiarCodigo.Image = ImageManager.getImagen("IconoAgregar"); //  ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuCoiarCodigo.Name = "MenuCoiarCodigo";
            this.MenuCoiarCodigo.Size = new System.Drawing.Size(201, 22);
            this.MenuCoiarCodigo.Text = "Hacer una copia para editar";
            this.MenuCoiarCodigo.Click += new System.EventHandler(this.MenuCoiarCodigo_Click);
            // 
            // MenuRenombrar
            // 
            this.MenuRenombrar.Image = ImageManager.getImagen("rename"); // ((System.Drawing.Image)(resources.GetObject("rename")));
            this.MenuRenombrar.Name = "MenuVerCodigo";
            this.MenuRenombrar.Size = new System.Drawing.Size(201, 22);
            this.MenuRenombrar.Text = "Cambiar Nombre";
            this.MenuRenombrar.Click += new System.EventHandler(this.MenuRenombrar_Click);

            return MenuPrinciapl;
        }
        private void MenuRenombrar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = Nombre;
            dlg.OnNombre += new Forms.ONFormNombreEvent(NuevoNombre);
            dlg.ShowDialog();
        }
        private bool NuevoNombre(Forms.FormNombre sender, string nuevoNombre)
        {
            try
            {
                Modelo.RenameScript(ID_Script,nuevoNombre);
                Nombre = nuevoNombre;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public override void DoubleClick(System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            MenuVerCodigo_Click(null, null);
        }
    }
}
   