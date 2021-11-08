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
    public partial class FormIndexs : Form
    {
        private string TableName;
        MotorDB.CTabla Tabla;
        MotorDB.IMotorDB motor;
        public FormIndexs(string tabla,MotorDB.IMotorDB db)
        {
            motor = db;
            Modificado = false;
            TableName = tabla;
            InitializeComponent();
        }
        public bool Modificado
        {
            get;
            set;
        }
        private void FormIndexs_Load(object sender, EventArgs e)
        {
            //asigno el nombre de la tabla
            LTabla.Text = "Tabla: " + TableName;
            CargaIndices();
        }
        private void CargaIndices()
        {
            ListaIndexes.Nodes.Clear();
            //me traigo la tabla
            Tabla = motor.DameTabla(TableName);
            //borro la tabla que muestra los campos
            DataTable table = dataSet1.Tables["Campos"];
            table.Rows.Clear();
            //me traigo los indices de la tabla
            foreach (MotorDB.Cindex obj in Tabla.Indexs)
            {
                TreeNode nodo = new TreeNode(obj.Nombre);
                if (Tabla.EsPrimaryKey(obj))
                {
                    nodo.ImageIndex = 0;
                    nodo.SelectedImageIndex = 0;
                }
                else
                {
                    nodo.ImageIndex = 1;
                    nodo.SelectedImageIndex = 1;
                }
                ListaIndexes.Nodes.Add(nodo);
            }

        }

        private void ListaIndexes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //limpio el datagrid
            DataTable table = dataSet1.Tables["Campos"];
            table.Rows.Clear();
            //veo si se selecciono un nodo valido
            if (e.Node == null)
                return;
            //me traigo el nombre indice
            MotorDB.Cindex index = Tabla.GetIndex(e.Node.Text);
            if (index == null)
                return; //no es un indice de la tabla por lo que no hago nada
            //muestro los datos en el grid
            foreach (MotorDB.CCampoIndex obj in index.Campos)
            {
                //creo un nuevo registro
                DataRow dr = table.NewRow();
                //lleno los datos de registro
                dr["Campo"] = obj.Nombre;
                dr["Tipo"] = obj.GetTipoString();
                dr["Ordenamiento"] = obj.Ordenamiento;
                table.Rows.Add(dr);
            }
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Bagregar_Click(object sender, EventArgs e)
        {
            FormNewIndex dlg = new FormNewIndex(TableName, motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Modificado = true;
            CargaIndices();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaIndexes.SelectedNode == null)
                {
                    MessageBox.Show("Seleccione un indice de la lista", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string nombre = ListaIndexes.SelectedNode.Text;
                //veo si es la llave primaria de la tabla
                if (Tabla.PrimaryKey == null || Tabla.PrimaryKey.Nombre != nombre)
                {
                    if (MessageBox.Show("Desea eliminar el indice: " + nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    motor.EliminaIndex(Tabla.Nombre, nombre);
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar la llave primaria", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    motor.EliminaPk(Tabla.Nombre);

                }
                Modificado = true;
                CargaIndices();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
