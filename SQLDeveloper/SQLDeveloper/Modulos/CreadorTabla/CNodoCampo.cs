using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoCampo: CNodoBase
    {
        CTabla Tabla;
        CCampo Campo;
        CVisorCampo Visor;
        private System.Windows.Forms.ContextMenuStrip MenuCampo;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuEditar;
        public CNodoCampo(CTabla tabla, CCampo campo)
        {
            Tabla = tabla;
            Campo = campo;
            Text = Campo.Nombre+" "+Campo.GetTipoString();
            ImageIndex = 8;
            SelectedImageIndex = 8;
            if (Tabla.EsIdentidad(Campo)==false&&Tabla.EsPrimaryKey(Campo)==false && Tabla.EsForeignKey(Campo)==false)
            {
                //no es ninguna de las tres
                ImageIndex = 8;
                SelectedImageIndex = 8;
            }
            if (Tabla.EsIdentidad(Campo) == false && Tabla.EsPrimaryKey(Campo) == false && Tabla.EsForeignKey(Campo) == true)
            {
                //es FK
                ImageIndex = 14;
                SelectedImageIndex = 14;
            }
            if (Tabla.EsIdentidad(Campo) == false && Tabla.EsPrimaryKey(Campo) == true && Tabla.EsForeignKey(Campo) == false)
            {
                //es PK
                ImageIndex = 9;
                SelectedImageIndex = 9;
            }
            if (Tabla.EsIdentidad(Campo) == false && Tabla.EsPrimaryKey(Campo) == true && Tabla.EsForeignKey(Campo) == true)
            {
                //es PK y FK
                ImageIndex = 15;
                SelectedImageIndex = 15;
            }
            if (Tabla.EsIdentidad(Campo) == true && Tabla.EsPrimaryKey(Campo) == false && Tabla.EsForeignKey(Campo) == false)
            {
                //solo Identidad
                ImageIndex = 16;
                SelectedImageIndex = 16;
            }
            if (Tabla.EsIdentidad(Campo) == true && Tabla.EsPrimaryKey(Campo) == false && Tabla.EsForeignKey(Campo) == true)
            {
                //Identidad y FK
                ImageIndex = 17;
                SelectedImageIndex = 17;
            }
            if (Tabla.EsIdentidad(Campo) == true && Tabla.EsPrimaryKey(Campo) == true && Tabla.EsForeignKey(Campo) == false)
            {
                //Identidad y PK
                ImageIndex = 18;
                SelectedImageIndex = 18;
            }
            if (Tabla.EsIdentidad(Campo) == true && Tabla.EsPrimaryKey(Campo) == true && Tabla.EsForeignKey(Campo) == true)
            {
                //Identidad PK y FK
                ImageIndex = 19;
                SelectedImageIndex = 19;
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
            {
                Visor = new CVisorCampo(Tabla, Campo);
            }
            return Visor;
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuCampo = new ContextMenuStrip();
            MenuEliminar = new ToolStripMenuItem();
            MenuEditar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuCampo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar,
            this.MenuEditar});
            this.MenuCampo.Name = "MenuCampos";
            this.MenuCampo.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar Campo";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuEditar
            // 
            this.MenuEditar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
            this.MenuEditar.Name = "MenuEditar";
            this.MenuEditar.Size = new System.Drawing.Size(201, 22);
            this.MenuEditar.Text = "Editar";
            this.MenuEditar.Click += new System.EventHandler(this.MenuEditar_Click);
            return  MenuCampo;

        }
        private void MenuEliminar_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el campo: " + Campo.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                DBProvider.DB.AlterTable_DropColumn(Tabla.Nombre, Campo.Nombre);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CNodoBase nodo = (CNodoBase)this.Parent;
            nodo.RefreshData();
        }
        private void MenuEditar_Click(Object sender, EventArgs e)
        {
            FormEditarColumna dlg = new FormEditarColumna(Tabla);
            dlg.Campo = Campo.Nombre;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CNodoBase nodo = (CNodoBase)this.Parent;
            nodo.RefreshData();
        }
    }
}
