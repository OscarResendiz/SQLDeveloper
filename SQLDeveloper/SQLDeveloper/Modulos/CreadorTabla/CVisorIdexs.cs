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
    public partial class CVisorIdexs : CVisorBase
    {
        private string TableName;
        MotorDB.CTabla Tabla;
        public CVisorIdexs(CTabla tabla)
        {
            Tabla = tabla;
            TableName = tabla.Nombre;
            InitializeComponent();
        }

        private void VisorIdexs_Load(object sender, EventArgs e)
        {
            //asigno el nombre de la tabla
            LTabla.Text = "Tabla: " + TableName;
            CargaIndices();

        }
        private void CargaIndices()
        {
            ListaIndexes.Nodes.Clear();
            //me traigo la tabla
            //Tabla = DBProvider.DB.DameTabla(TableName);
            //borro la tabla que muestra los campos
            DataTable table = dataSet1.Tables["Campos"];
            table.Rows.Clear();
            //me traigo los indices de la tabla
            foreach (MotorDB.Cindex obj in Tabla.Indexs)
            {
                if (!Tabla.EsPrimaryKey(obj))
                {
                    TreeNode nodo = new TreeNode(obj.Nombre);
                                        nodo.ImageIndex = 1;
                                      nodo.SelectedImageIndex = 1;
                    ListaIndexes.Nodes.Add(nodo);
                }
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

        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormNewIndex dlg = new FormNewIndex(Tabla);
            dlg.ShowPrimaryKey = false;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CargaIndices();
            ChangeData();
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
                    Tabla.RemoveIndex(nombre);
                    //DBProvider.DB.EliminaIndex(Tabla.Nombre, nombre);
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar la llave primaria", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    Tabla.RemovePK();
                    //DBProvider.DB.EliminaPk(Tabla.Nombre);

                }
                CargaIndices();
                ChangeData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void RefreshData()
        {
            CargaIndices();
        }
    }
}
