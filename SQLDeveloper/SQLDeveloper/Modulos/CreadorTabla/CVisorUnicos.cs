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
    public partial class CVisorUnicos : CVisorBase
    {
        MotorDB.CTabla Tabla;
        public CVisorUnicos(CTabla tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }

        private void CVisorUnicos_Load(object sender, EventArgs e)
        {
            LTabla.Text = "Tabla: " + Tabla.Nombre;
            MuestraUnicos();
        }
        private void MuestraUnicos()
        {
            ListaUniques.Nodes.Clear();
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            //recorro la lista de valores unicos
//            Tabla = DBProvider.DB.DameTabla(Tabla.Nombre);
            foreach (MotorDB.CUnique obj in Tabla.Uniques)
            {
                TreeNode nodo = new TreeNode(obj.Nombre);
                nodo.Tag = obj;
                nodo.ImageIndex = 0;
                nodo.SelectedImageIndex = 0;
                ListaUniques.Nodes.Add(nodo);
            }
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormUniqueProperty dlg = new FormUniqueProperty(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraUnicos();
            ChangeData();

        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (ListaUniques.SelectedNode == null)
            {
                MessageBox.Show("Seleccione un elemento para eliminarlo", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                MotorDB.CUnique obj = (MotorDB.CUnique)ListaUniques.SelectedNode.Tag;
                if (MessageBox.Show("¿Seguro que desea eliminar la clave unica: " + obj.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                Tabla.RemoveUnique(obj.Nombre);
                //DBProvider.DB.AlterTable_DropUnique(Tabla.Nombre, obj.Nombre);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MuestraUnicos();
            ChangeData();
        }

        private void ListaUniques_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            if (ListaUniques.SelectedNode == null)
            {
                return;
            }
            //me traigo el objeto seleccionado
            MotorDB.CUnique obj = (MotorDB.CUnique)ListaUniques.SelectedNode.Tag;
            //recorro los campos que lo componene
            foreach (MotorDB.CCampoBase cb in obj.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["Campo"] = cb.Nombre;
                dr["Tipo"] = cb.GetTipoString();
                dt.Rows.Add(dr);
            }
        }
        public override void RefreshData()
        {
            MuestraUnicos();
        }
    }
}
