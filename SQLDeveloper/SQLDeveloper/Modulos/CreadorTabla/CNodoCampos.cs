using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoCampos: CNodoFolder
    {
        CTabla Tabla;
        private System.Windows.Forms.ContextMenuStrip MenuCampos;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        CVisorCampos Visor;

        public CNodoCampos(CTabla tabla)
        {
            Tabla = tabla;
            Text = "Campos";
            MuestraCampos();
           // CreaMenu();
        }
        private void MuestraCampos()
        {
            Nodes.Clear();
            //Tabla = DBProvider.DB.DameTabla(Tabla.Nombre);
            foreach(CCampo obj in Tabla.Campos)
            {
                CNodoCampo nodo = new CNodoCampo(Tabla, obj);
                Nodes.Add(nodo);
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
            {
                Visor = new CVisorCampos(Tabla);
                Visor.OnChangeData += new OnChangeDataEvent(OnVisorChanceData);
            }
            return Visor;
        }
        public override void RefreshData()
        {
            MuestraCampos();
            if (Visor != null)
                Visor.RefreshData();

        }
        public void OnVisorChanceData(CVisorBase sender)
        {
            RefreshData();
        }
        protected override ContextMenuStrip CreaMenu()
        {
            //creo el menu
            MenuCampos = new ContextMenuStrip();
            MenuAgregar = new ToolStripMenuItem();
            MenuRefrescar = new ToolStripMenuItem();
            //configuro los menus
            // 
            // MenuTabla
            // 
            //asigno los sub menus
            this.MenuCampos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar});
            this.MenuCampos.Name = "MenuCampos";
            this.MenuCampos.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Campo";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refrescar";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuCampos;

        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarCampo dlg = new FormAgregarCampo(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            RefreshData();
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
