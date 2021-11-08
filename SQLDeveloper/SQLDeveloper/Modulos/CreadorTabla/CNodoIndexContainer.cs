using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;

namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoIndexContainer: CNodoFolder
    {
        CTabla Tabla;
        CVisorIdexs Visor;
        private System.Windows.Forms.ContextMenuStrip MenuIndexs;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        public CNodoIndexContainer(CTabla tabla)
        {
            Tabla = tabla;
            Text = "INDEXS";
            CargaIndices();
        }
        private void CargaIndices()
        {
            Nodes.Clear();
            //Tabla = DBProvider.DB.DameTabla(Tabla.Nombre);
            foreach (Cindex obj in Tabla.Indexs)
            {
                if (!Tabla.EsPrimaryKey(obj))
                {
                    CNodoIndex nodo = new CNodoIndex(Tabla, obj);
                    Nodes.Add(nodo);
                }
            }
        }
        public override CVisorBase GetVisor()
        {
            if (Visor == null)
            {
                Visor = new CVisorIdexs(Tabla);
                Visor.OnChangeData += new OnChangeDataEvent(VisorChangeData);
            }
            return Visor;
        }
        public override void RefreshData()
        {
            CargaIndices();
            if(Visor!=null)
            {
                Visor.RefreshData();
            }
        }
        private void VisorChangeData(CVisorBase visor)
        {
            RefreshData();
        }
        protected override ContextMenuStrip CreaMenu()
        {
         MenuIndexs=new ContextMenuStrip();
         MenuAgregar=new ToolStripMenuItem();
        MenuRefrescar=new ToolStripMenuItem();
            //confiburo los menus
            this.MenuIndexs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar});
            this.MenuIndexs.Name = "MenuIndexs";
            this.MenuIndexs.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Index";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refresh";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuIndexs;
        }
        private void MenuRefrescar_Click(object sebder, EventArgs e)
        {
            RefreshData();
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            FormNewIndex dlg = new FormNewIndex(Tabla);
            dlg.ShowPrimaryKey = false;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            RefreshData();
        }
    }
}
