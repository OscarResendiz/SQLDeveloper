using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CNodoCodigoEditable: CNodoBase
    {
        private System.Windows.Forms.ToolStripMenuItem MenuVerCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        private System.Windows.Forms.ToolStripMenuItem MenuRenombrar;
        public ManagerConnect.CConexion Conexion
        {
            get;
            set;
        }
        public int ID_Objeto
        {
            get;
            set;
        }
        public string Servidor
        {
            get;
            set;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            System.Windows.Forms.ContextMenuStrip MenuPrinciapl = base.CreaMenu();
            this.MenuVerCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            MenuRenombrar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVerCodigo,
            MenuComentarios,
            MenuRenombrar ,
            this.MenuEliminar
             });
            // 
            // MenuVerCodigo
            // 
            this.MenuVerCodigo.Image = ImageManager.getImagen("IconoEditar"); // ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
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
            this.MenuComentarios.Image = ImageManager.getImagen("comentario"); // ((System.Drawing.Image)(resources.GetObject("comentario")));
            this.MenuComentarios.Name = "MenuVerCodigo";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Cometarios";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);
            // 
            // MenuRenombrar
            // 
            this.MenuRenombrar.Image = ImageManager.getImagen("rename"); //((System.Drawing.Image)(resources.GetObject("rename")));
            this.MenuRenombrar.Name = "MenuVerCodigo";
            this.MenuRenombrar.Size = new System.Drawing.Size(201, 22);
            this.MenuRenombrar.Text = "Cambiar Nombre";
            this.MenuRenombrar.Click += new System.EventHandler(this.MenuRenombrar_Click);


            return MenuPrinciapl;
        }
        private void MenuVerCodigo_Click(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            FormProyect dlg = (FormProyect)TreeView.Tag;
            CModelCodigoEditable obj = Modelo.DameCodigoEditable(ID_Objeto, Nombre);
            //me traigo el motor
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            //mando a mostrar el codigo
            CodeFileManager fm = new CodeFileManager();
            fm.ID_Objeto = ID_Objeto;
            fm.Nombre = Nombre;
            fm.Modelo = Modelo;
            dlg.VerCodigo(Nombre, obj.Codigo, motor, Servidor, Conexion.Nombre,fm);
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            SQLDeveloper.Forms.FormComentario dlg = new SQLDeveloper.Forms.FormComentario();
            CModelCodigoEditable obj = Modelo.DameCodigoEditable(ID_Objeto, Nombre);
            dlg.Texto = obj.Comentarios;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Modelo.AsignaComentariosCodidoEditable(ID_Objeto, Nombre, dlg.Texto);
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar: " + Nombre + " del proyecto?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Modelo.EliminaCodigoEditable(ID_Objeto,Nombre);
                Parent.Nodes.Remove(this);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
//            CModelObjeto objeto = Modelo.DameObjeto(Servidor, Conexion.Nombre, Nombre);
            try
            {
                Modelo.RenombrarCodigoEditable(ID_Objeto, Nombre, nuevoNombre);
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
   