using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Relaciones
{
    public partial class FormRelaciones : Form
    {
        MotorDB.IMotorDB Motor;
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        private List<string> Agregados;
        private string Tabla;
        public FormRelaciones(MotorDB.IMotorDB motor,string tabla)
        {
            Motor = motor;
            Tabla = tabla;
            Agregados = new List<string>();
            InitializeComponent();
        }

        private void FormRelaciones_Load(object sender, EventArgs e)
        {
            CNodoRelacion Raiz = new CNodoRelacion(Motor);
            Raiz.Nombre = Tabla;
            Raiz.OnVerObjeto += new MotorDB.OnVerObjetoEvent(VerObjeto);
            ListaObjetos.Nodes.Add(Raiz);
            Raiz.CargaRelaciones();
        }
        private void VerObjeto(MotorDB.IMotorDB motor,string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            if (OnVerObjeto != null)
            {
                OnVerObjeto(motor,nombre, tipo);
            }
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

    }
}
