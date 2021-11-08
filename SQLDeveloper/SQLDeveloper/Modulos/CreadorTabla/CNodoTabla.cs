using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CreadorTabla
{
    class CNodoTabla : CNodoBase
    {
        private System.Windows.Forms.ContextMenuStrip MenuTabla;
        private System.Windows.Forms.ToolStripMenuItem MenuPrimaryKey;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        CVisorCampos Visor;
        public CTabla Tabla
        {
            get;
            set;
        }
        public string NombreTabla
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
                Tabla.Nombre = value;
            }
        }
        public CNodoTabla( CTabla tabla)
        {
            Tabla = tabla;
            //CreaMenu();
            NombreTabla = Tabla.Nombre;
            ImageIndex = 0;
            SelectedImageIndex = 0;
            CargaDatos();
        }
        private void CargaDatos()
        {
            Nodes.Clear();
            //Tabla = DBProvider.DB.DameTabla(NombreTabla);
            //agrego el nodo de llaves primarias
            if (Tabla.PrimaryKey != null)
            {
                CPrimaryKeyNode pk = new CPrimaryKeyNode(Tabla);
                pk.Pk = Tabla.PrimaryKey;
                Nodes.Add(pk);
                MenuPrimaryKey.Enabled = false;
            }
            else
            {
                MenuPrimaryKey.Enabled = true;
            }
            //muestro los campos de la tabla
            CNodoCampos campos = new CNodoCampos(Tabla);
            Nodes.Add(campos);
            //Agrego el administrador de llaves foraneas
            CNodoForeignkeysContainer fks = new CNodoForeignkeysContainer(Tabla);
            Nodes.Add(fks);
            //agrego los indices
            CNodoIndexContainer index = new CNodoIndexContainer(Tabla);
            Nodes.Add(index);
            //Cargo valores unicos
            CNodoUniques uniques = new CNodoUniques(Tabla);
            Nodes.Add(uniques);
            //agrego los checks
            CNodoChecks checks = new CNodoChecks(Tabla);
            Nodes.Add(checks);
            //agrego los triggers
     //       CNodoTriggers triggers = new CNodoTriggers(Tabla);
       //     Nodes.Add(triggers);
        }
        protected override ContextMenuStrip CreaMenu()
        {
            this.MenuTabla = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPrimaryKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRefrescar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuTabla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPrimaryKey,
            this.MenuRefrescar});
            this.MenuTabla.Name = "MenuTabla";
            this.MenuTabla.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuPrimaryKey
            // 
            this.MenuPrimaryKey.Image = ((System.Drawing.Image)(resources.GetObject("IconoPk")));
            this.MenuPrimaryKey.Name = "MenuPrimaryKey";
            this.MenuPrimaryKey.Size = new System.Drawing.Size(201, 22);
            this.MenuPrimaryKey.Text = "Establecer llave primaria";
            this.MenuPrimaryKey.Click += new System.EventHandler(this.MenuPrimaryKey_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refrescar";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuTabla;
        }
        private void MenuPrimaryKey_Click(object sender, EventArgs e)
        {
            if(Tabla.PrimaryKey==null)
            {
                FormNewIndex dlg = new FormNewIndex(Tabla);
                dlg.ShowPrimaryKey = true;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                CargaDatos();
            }
        }

        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }
        public override void RefreshData()
        {
            CargaDatos();
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
        public void OnVisorChanceData(CVisorBase sender)
        {
            RefreshData();
        }
    }
}
