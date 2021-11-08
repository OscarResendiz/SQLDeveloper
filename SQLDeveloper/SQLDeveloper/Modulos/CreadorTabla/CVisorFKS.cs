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
    public partial class CVisorFKS : CVisorBase
    {
        CTabla Tabla;
        public CVisorFKS(CTabla tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }
        private void MuestraLLavesFK()
        {
            ListaFks.Nodes.Clear();
            LimpiaCOntroles();
            //me traigo el listado de llaves foraneas
            List<MotorDB.CForeignKey> l = Tabla.ForeignKeys; //DBProvider.DB.DameLLavesForaneas(Tabla);
            foreach (MotorDB.CForeignKey fk in l)
            {
                TreeNode nodo = new TreeNode(fk.Nombre, 0, 0);
                nodo.Tag = fk;
                ListaFks.Nodes.Add(nodo);
            }
        }

        private void CVisorFKS_Load(object sender, EventArgs e)
        {
            MuestraLLavesFK();
        }

        private void ListaFks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataSet1.Tables["Columnas"].Rows.Clear();
            TreeNode nodo = ListaFks.SelectedNode;
            if (nodo == null)
            {
                LimpiaCOntroles();
                return;
            }
            MotorDB.CForeignKey fk = (MotorDB.CForeignKey)nodo.Tag;
            TNombre.Text = fk.Nombre;
            TBorrar.Text = fk.AccionBorrar.ToString();
            TActualizar.Text = fk.AccionActualizar.ToString();
            dataGridView1.Columns[0].HeaderText = fk.TablaPadre;
            dataGridView1.Columns[1].HeaderText = fk.TablaHija;
            TTablaPadre.Text = fk.TablaPadre;
            //me traigo la tabla que muestra los datos en la pantalla
            DataTable dt = dataSet1.Tables["Columnas"];
            //recoor los campos de la llave foranea
            foreach (MotorDB.CCampoFereneces obj in fk.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["ColumnaPadre"] = obj.CampoPadre;
                dr["ColumnaHija"] = obj.CampoHijo;
                dt.Rows.Add(dr);
            }
        }

        private void Bagregar_Click(object sender, EventArgs e)
        {
            FormAddForeignKey dlg = new FormAddForeignKey(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //recargo los datos
            MuestraLLavesFK();
            ChangeData();

        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (ListaFks.SelectedNode == null)
            {
                MessageBox.Show("Seleccione una llave foranea de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MotorDB.CForeignKey fk = (MotorDB.CForeignKey)ListaFks.SelectedNode.Tag;
            if (MessageBox.Show("Desea eliminar la relacion: " + fk.Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                Tabla.RemoveForeignKey(fk.Nombre);
                //DBProvider.DB.EliminaForeignKey(fk);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            MuestraLLavesFK();
            ChangeData();
        }
        private void LimpiaCOntroles()
        {
            //limpio los controles
            TNombre.Text = "";
            TBorrar.Text = "";
            TActualizar.Text = "";
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[1].HeaderText = "";
            TTablaPadre.Text = "";

        }
        public override void RefreshData()
        {
            MuestraLLavesFK();
        }
    }
}
