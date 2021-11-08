using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoUniques: CNodoFolder
    {
        CTabla Tabla;
        CVisorUnicos Visor;
        private System.Windows.Forms.ContextMenuStrip MenuUniques;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        public CNodoUniques(CTabla tabla)
        {
            Tabla = tabla;
            Text = "Valores Unicos";
            CargaUnicos();
        }
        private void CargaUnicos()
        {
            Nodes.Clear();
            //Tabla = DBProvider.DB.DameTabla(Tabla.Nombre);
            foreach (CUnique obj in Tabla.Uniques)
            {
                CNodoUnq un = new CNodoUnq(Tabla, obj);
                Nodes.Add(un);
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
            {
                Visor = new CVisorUnicos(Tabla);
                Visor.OnChangeData += new OnChangeDataEvent(OnVisorChange);
            }
            return Visor;
        }
        public override void RefreshData()
        {
            CargaUnicos();
            if (Visor != null)
                Visor.RefreshData();
        }
        private void OnVisorChange(CVisorBase visor)
        {
            RefreshData();
        }
        protected override ContextMenuStrip CreaMenu()
        {
            MenuUniques = new ContextMenuStrip();
            MenuAgregar = new ToolStripMenuItem();
            MenuRefrescar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuUniques.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar});
            this.MenuUniques.Name = "MenuFks";
            this.MenuUniques.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Valor unico";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refresh";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuUniques;
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            FormUniqueProperty dlg = new FormUniqueProperty(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            RefreshData();
        }
    }
}
