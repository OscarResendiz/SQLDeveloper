using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Trrigers
{
    public partial class FormTrigger : Form
    {
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        string Tabla;
        NodoTabla Raiz;
        public FormTrigger(string tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }

        private void FormTrriger_Load(object sender, EventArgs e)
        {
            //creo el nodo raiz
            Raiz = new NodoTabla();
            Raiz.Nombre = Tabla;
            Raiz.CargaTriggers();
            ListaObjetos.Nodes.Add(Raiz);
        }

        private void ListaObjetos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            TreeNode nd = (TreeNode)ListaObjetos.GetNodeAt(e.X, e.Y);
            if (nd != null)
            {
                ListaObjetos.SelectedNode = nd;
            }
        }

        private void MenuVer_Click(object sender, EventArgs e)
        {

        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
