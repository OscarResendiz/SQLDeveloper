using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class FormUniques : Form
    {
        CTabla Tabla;
        public FormUniques(CTabla tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }

        private void FormUniques_Load(object sender, EventArgs e)
        {
            LTabla.Text = "Tabla: "+Tabla.Nombre;
            MuestraUnicos();
        }
        private void MuestraUnicos()
        {
            ListaUniques.Nodes.Clear();
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            //recorro la lista de valores unicos
            foreach(MotorDB.CUnique obj in Tabla.Uniques)
            {
                TreeNode nodo = new TreeNode(obj.Nombre);
                nodo.Tag = obj;
                nodo.ImageIndex = 0;
                nodo.SelectedImageIndex = 0;
                ListaUniques.Nodes.Add(nodo);
            }
        }

        private void Bagregar_Click(object sender, EventArgs e)
        {
            FormUniqueProperty dlg = new FormUniqueProperty(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraUnicos();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if(ListaUniques.SelectedNode==null)
            {
                MessageBox.Show("Seleccione un elemento para eliminarlo", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                MotorDB.CUnique obj = (MotorDB.CUnique)ListaUniques.SelectedNode.Tag;
                if (MessageBox.Show("¿Seguro que desea eliminar la clave unica: "+obj.Nombre+"?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                Tabla.RemoveUnique(obj.Nombre);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MuestraUnicos();
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
            foreach(MotorDB.CCampoBase cb in obj.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["Campo"] = cb.Nombre;
                dr["Tipo"] = cb.GetTipoString();
                dt.Rows.Add(dr);
            }
        }
    }
}
