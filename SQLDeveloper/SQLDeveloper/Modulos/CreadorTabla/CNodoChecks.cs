using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoChecks: CNodoFolder
    {
        CTabla Tabla;
        CVisorChecks Visor;
        private System.Windows.Forms.ContextMenuStrip MenuChecks;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        public CNodoChecks(CTabla tabla)
        {
            Tabla = tabla;
            Text = "Reglas (Checks)";
            CargaChecks();
        }
        private void CargaChecks()
        {
            Nodes.Clear();
            //Tabla = DBProvider.DB.DameTabla(Tabla.Nombre);
            foreach (CCheck obj in Tabla.Checks)
            {
                CNodoCheck ck = new CNodoCheck(Tabla, obj);
                Nodes.Add(ck);
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
            {
                Visor = new CVisorChecks(Tabla);
                Visor.OnChangeData += new OnChangeDataEvent(OnVisorChange);
            }
            return Visor;
        }
        private void OnVisorChange(CVisorBase visor)
        {
            RefreshData();
        }
        public override void RefreshData()
        {
            CargaChecks();
            if (Visor != null)
                Visor.RefreshData();
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuChecks = new ContextMenuStrip();
            MenuAgregar = new ToolStripMenuItem();
            MenuRefrescar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuChecks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar});
            this.MenuChecks.Name = "MenuFks";
            this.MenuChecks.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Regla";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refresh";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuChecks;
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            FormNewCheck dlg = new FormNewCheck(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            RefreshData();
        }
    }
}
