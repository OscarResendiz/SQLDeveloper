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

namespace Modelador.UI
{
//    public delegate void OnVerObjetoEvent(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo);
    public delegate void OnEventoVacio();

    public partial class FormSelectObjet : Form
    {
        public event OnVerObjetoEvent OnVerObjeto;
        public event OnVerObjetoEvent OnVerMultiObjeto;
        public event OnEventoVacio OnFInMultiObjeto;
        MotorDB.EnumTipoObjeto tipo;
        List<MotorDB.CObjeto> Objetos;
        List<CObetoBuqueda> ListaVer;
        string Errores;
        string cadena;
        public FormSelectObjet()
        {
            InitializeComponent();
        }
        public MotorDB.IMotorDB Motor
        {
            get;
            set;
        }
        private void FormBuscadorObjetos_Load(object sender, EventArgs e)
        {
            EnableControls = true;
            TNombre.Focus();
            TimerTextChange.Enabled = true;
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            //se modifico el texto, por lo que hay que esperar medio segundo para comenzar con la busqueda automaticamente
            TimerTextChange.Enabled = false;
            TimerTextChange.Enabled = true;
        }

        private void TNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //hay que comenzar con la busqueda inmediatamente
                TimerTextChange.Enabled = false;
                Buscar();
            }
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    Clipboard.SetText(TNombre.Text);
                }
                if (e.KeyCode == Keys.V)
                {
                    TNombre.Text = Clipboard.GetText();
                }
            }
        }

        private void TimerTextChange_Tick(object sender, EventArgs e)
        {
            TimerTextChange.Enabled = false;
            //if (TNombre.Text.Trim() != "")
            //{
            Buscar();
            //}
        }
        private void Buscar()
        {
            if (!BKBuscar.IsBusy)
            {
                CTipoBusqueda obj = new CTipoBusqueda("Tablas", MotorDB.EnumTipoObjeto.TABLE);
                tipo = obj.Tipo;
                cadena = TNombre.Text.Trim();
                ListaObjetos.Nodes.Clear();
                if (Objetos == null)
                    Objetos = new List<MotorDB.CObjeto>();
                Objetos.Clear();
                waitControl1.Animar = true;
                EnableControls = false;
                BKBuscar.RunWorkerAsync();
            }
        }
        private bool EnableControls
        {
            set
            {
                TNombre.Enabled = value;
                ListaObjetos.Enabled = value;
            }
        }

        private void BKBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (MotorDB.CObjeto obj in Objetos)
            {
                Arbol.CNodoBusqueda nodo = new Arbol.CNodoBusqueda();
                nodo.Nombre = obj.Nombre;
                nodo.Tipo = obj.Tipo;
                ListaObjetos.Nodes.Add(nodo);
            }
            waitControl1.Animar = false;
            EnableControls = true;
            LMensaje.Text = "Objetos encontrados: " + Objetos.Count();
            TNombre.Focus();
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            this.Cursor = Cursors.WaitCursor;
            Arbol.CNodoBusqueda nodo = (Arbol.CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                OnVerObjeto(Motor, nodo.Nombre, nodo.Tipo);
            }
            this.Cursor = Cursors.Default;
        }

        private void ListaObjetos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Linfo.Text = (string)e.Node.Tag;
        }

        private void BKBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            Objetos = Motor.Buscar(cadena, tipo);
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaVer = new List<CObetoBuqueda>();
            Errores = "";
            Cursor = Cursors.WaitCursor;
            foreach (Arbol.CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                if (OnVerObjeto != null)
                {
                    CObetoBuqueda obj = new CObetoBuqueda();
                    obj.Nombre = nodo.Nombre;
                    obj.Tipo = nodo.Tipo;

                    ListaVer.Add(obj);
                    //                   
                }
            }
            ProgresoVer.Maximum = ListaVer.Count;
            ProgresoVer.Value = 0;
            BKVerTodos.RunWorkerAsync();
        }

        private void BKVerTodos_DoWork(object sender, DoWorkEventArgs e)
        {
            int pos = 0;
            foreach (CObetoBuqueda obj in ListaVer)
            {
                BKVerTodos.ReportProgress(pos, obj);
                pos++;
            }
        }

        private void BKVerTodos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CObetoBuqueda obj = (CObetoBuqueda)e.UserState;
            try
            {
                //                OnVerMultiObjeto(obj.Nombre, obj.Tipo);
                OnVerObjeto(Motor, obj.Nombre, obj.Tipo);
                ProgresoVer.Value = (int)e.ProgressPercentage;
            }
            catch (System.Exception ex)
            {
                try
                {
                    Errores += ex.Message + "\n\r";
                }
                catch (System.Exception ex2)
                {
                    return;
                }
                //                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BKVerTodos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnFInMultiObjeto != null)
                OnFInMultiObjeto();
            ProgresoVer.Value = 0;
            Cursor = Cursors.Default;
            if (Errores != "")
                MessageBox.Show(Errores, "Processo terminado con errores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Proceso terminado Correctaente", "Fin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
