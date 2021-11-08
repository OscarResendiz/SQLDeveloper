using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class CVisorChecks : CVisorBase
    {
        private string TableName;
        MotorDB.CTabla Tabla;
        public CVisorChecks(CTabla tabla)
        {
            Tabla = tabla;
            TableName = Tabla.Nombre;
            InitializeComponent();
        }
        private void CargaTabla()
        {
            TNombre.Text = "";
            TRegla.Text = "";
            //Tabla = DBProvider.DB.DameTabla(TableName);
            ListaChecks.Nodes.Clear();
            //recorro la lista de checks
            foreach (MotorDB.CCheck obj in Tabla.Checks)
            {
                TreeNode nodo = new TreeNode();
                nodo.SelectedImageIndex = 0;
                nodo.ImageIndex = 0;
                nodo.Text = obj.Nombre;
                nodo.Tag = obj;
                ListaChecks.Nodes.Add(nodo);
            }
        }

        private void CVisorChecks_Load(object sender, EventArgs e)
        {
            LTabla.Text = "Tabla: " + TableName;
            CargaTabla();
        }

        private void ListaChecks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ListaChecks.SelectedNode == null)
                return;
            MotorDB.CCheck obj = (MotorDB.CCheck)ListaChecks.SelectedNode.Tag;
            TNombre.Text = obj.Nombre;
            TRegla.Text = obj.Regla;
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormNewCheck dlg = new FormNewCheck(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CargaTabla();
            ChangeData();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (ListaChecks.SelectedNode == null)
                return;
            MotorDB.CCheck obj = (MotorDB.CCheck)ListaChecks.SelectedNode.Tag;
            if (MessageBox.Show("¿Seguro que desea eliminar la regla: " + obj.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Tabla.RemoveCheck(obj.Nombre);
                //DBProvider.DB.AlterTable_DropChechk(TableName, );
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargaTabla();
            ChangeData();
        }
        public override void RefreshData()
        {
            CargaTabla();
        }
    }
}
