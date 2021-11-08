using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Dependencias
{
    public partial class FormDependencias : Form
    {
        MotorDB.IMotorDB Motor;
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        String Tabla;
        CNodoDependencia Raiz;
        CDependenciaManager DependenciaManager;
        bool BuscarHaciaBajo;
        public FormDependencias(MotorDB.IMotorDB motor, string tabla)
        {
            Motor = motor;
            Tabla = tabla;
            InitializeComponent();

        }
        private bool EnableControls
        {
            set
            {
                RBDependen.Enabled = value;
                RBDepende.Enabled = value;
                ListaObjetos.Enabled = value;
            }
        }
        private void FormDependencias_Load(object sender, EventArgs e)
        {
            RBDependen.Text += " "+Tabla;
            RBDepende.Text+= " " + Tabla;
            RBDependen_CheckedChanged(null, null);
        }
        private void RBDependen_CheckedChanged(object sender, EventArgs e)
        {
            ListaObjetos.Nodes.Clear();
            waitControl1.Animar = true;
            BuscarHaciaBajo = RBDepende.Checked;
            DependenciaManager = new CDependenciaManager();
            EnableControls = false;
            Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BuscarHaciaBajo == true)
            {
                Raiz = DependenciaManager.CargaDependientes(Tabla, MotorDB.EnumTipoObjeto.TABLE);
            }
            else
            {
                Raiz = DependenciaManager.CargaDependencias(Tabla, MotorDB.EnumTipoObjeto.TABLE);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitControl1.Animar = false;
            ListaObjetos.Nodes.Add(Raiz);
            EnableControls = true;
            Cursor = Cursors.Arrow;
        }

        private void MenuVer_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            CNodoDependencia nd = (CNodoDependencia)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
                OnVerObjeto(Motor,nd.Nombre, nd.Tipo);
        }

        private void ListaObjetos_MouseUp(object sender, MouseEventArgs e)
        {
            CNodoDependencia nd = (CNodoDependencia)ListaObjetos.GetNodeAt(e.X, e.Y);
            if(nd!=null)
            {
                ListaObjetos.SelectedNode = nd;
            }
        }
    }
}
