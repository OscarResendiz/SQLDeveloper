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
    public partial class FormChecks : Form
    {
        private string TableName;
        MotorDB.CTabla Tabla;
        MotorDB.IMotorDB motor;
        public FormChecks(string tabla,MotorDB.IMotorDB db)
        {
            motor = db;
            TableName = tabla;
            InitializeComponent();
        }
        private void CargaTabla()
        {
            TNombre.Text = "";
            TRegla.Text = "";
            Tabla = motor.DameTabla(TableName);
            ListaChecks.Nodes.Clear();
            //recorro la lista de checks
            foreach(MotorDB.CCheck obj in Tabla.Checks)
            {
                TreeNode nodo = new TreeNode();
                nodo.SelectedImageIndex = 0;
                nodo.ImageIndex = 0;
                nodo.Text = obj.Nombre;
                nodo.Tag = obj;
                ListaChecks.Nodes.Add(nodo);
            }
        }

        private void FormChecks_Load(object sender, EventArgs e)
        {
            LTabla.Text = "Tabla: "+TableName;
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

        private void Bagregar_Click(object sender, EventArgs e)
        {
            FormNewCheck dlg = new FormNewCheck(TableName,motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CargaTabla();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
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
                motor.AlterTable_DropChechk(TableName, obj.Nombre);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargaTabla();
        }
    }
}
