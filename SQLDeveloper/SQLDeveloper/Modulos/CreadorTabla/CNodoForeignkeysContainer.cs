using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoForeignkeysContainer: CNodoFolder
    {
        CTabla Tabla;
        CVisorFKS Visor;
        private System.Windows.Forms.ContextMenuStrip MenuFks;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        public CNodoForeignkeysContainer(CTabla tabla)
        {
           // base.CNodoFolder();
            Tabla = tabla;
            Text = "FOREIGN KEYS";
            CargaFks();
        }
        public void CargaFks()
        {
          //  Tabla = DBProvider.DB.DameTabla(Tabla.Nombre);
            Nodes.Clear();
            foreach(CForeignKey obj in Tabla.ForeignKeys)
            {
                CNodoFk fk = new CNodoFk(Tabla, obj);
                Nodes.Add(fk);
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
            {
                Visor = new CVisorFKS(Tabla);
                Visor.OnChangeData += new OnChangeDataEvent(VisorChanceData);
            }
            return Visor;
        }
        public override void RefreshData()
        {
            CargaFks();
            if (Visor != null)
                Visor.RefreshData();
        }
        private void VisorChanceData(CVisorBase v)
        {
            CargaFks();
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuFks=new ContextMenuStrip();
            MenuAgregar=new ToolStripMenuItem();
            MenuRefrescar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuFks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar});
            this.MenuFks.Name = "MenuFks";
            this.MenuFks.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar LLave Foranea";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refresh";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);

            return MenuFks;
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            FormAddForeignKey dlg = new FormAddForeignKey(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            RefreshData();
        }
    }
}

