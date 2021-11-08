using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Tabla
{
    public partial class FormDatosAvanzados : Form
    {
        string TableName;
        private MotorDB.IMotorDB motor;
        public FormDatosAvanzados(string tabla,MotorDB.IMotorDB db)
        {

            motor=db;
            TableName = tabla;
            InitializeComponent();
        }

        private void FormConstraints_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            //creo el nodo principal que es el de la tabla
            CNodoTabla nodo = new CNodoTabla(TableName,motor);
            treeView1.Nodes.Add(nodo);
            TTabla.Text = TableName;
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuPrimaryKey_Click(object sender, EventArgs e)
        {

        }

        private void MenuRefrescar_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.Expandido();
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.Colapsado();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            CNodoBase nodo = (CNodoBase)e.Node;
            //elimino el visor que actualmente se esta mostrando
            splitContainer1.Panel2.Controls.Clear();
            //me traigo el visor
            CVisorBase visor = nodo.GetVisor();
            //lo asigno
            splitContainer1.Panel2.Controls.Add(visor);
            //lo configuro para que abarque todo el espacio
            visor.Dock = DockStyle.Fill;
        }

        private void MenuEliminarPk_Click(object sender, EventArgs e)
        {

        }
    }
}
