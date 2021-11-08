using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerConnect
{
    //esta clase se va a encargar de administrar todas las conexiones del sistema
    //va 
    public partial class FormAdminConexiones : Form
    {
        CNodoRaiz NodoRaiz;
        public FormAdminConexiones()
        {
            InitializeComponent();
        }

        private void FormAdminConexiones_Load(object sender, EventArgs e)
        {
            //agrego la raiz
            NodoRaiz = new CNodoRaiz();
            treeView1.Nodes.Add(NodoRaiz);
            NodoRaiz.CargaGrupos();
        }


        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //en teoria se llama cuando termina la edicion del nodo
            if(e.Node.GetType()==typeof(CNodoGrupo))
            {
                //se agrego un nuevo nodo
                try
                {
                    string nombre = e.Node.Text;
                    if (e.Label != null)
                        nombre = e.Label;
                    ControladorConexiones.AddGrupo(nombre);
                }
                catch(System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Node.Remove();
                }
            }
        }

    

        private void MenuEliminarConexion_Click(object sender, EventArgs e)
        {

        }

        private void MenuEditarConexion_Click(object sender, EventArgs e)
        {

        }
    }
}
