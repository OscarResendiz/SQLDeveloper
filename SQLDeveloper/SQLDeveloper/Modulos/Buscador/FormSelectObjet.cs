using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Buscador
{
    public partial class FormSelectObjet : Form
    {
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        public event MotorDB.OnVerObjetoEvent OnVerMultiObjeto;
        public event MotorDB.OnEventoVacio OnFInMultiObjeto;
        MotorDB.EnumTipoObjeto tipo;
        List<MotorDB.CObjeto> Objetos;
        List<MotorDB.CObetoBuqueda> ListaVer;
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
            ComboTipo.Items.Clear();
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Todos", MotorDB.EnumTipoObjeto.NONE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Tablas", MotorDB.EnumTipoObjeto.TABLE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Vistas", MotorDB.EnumTipoObjeto.VIEW));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Procediientos almacenados", MotorDB.EnumTipoObjeto.PROCEDURE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Funciones", MotorDB.EnumTipoObjeto.FUNCION));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Trigers", MotorDB.EnumTipoObjeto.TRIGER));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Buscar campos en objetos", MotorDB.EnumTipoObjeto.CAMPO));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Buscar en el codigo", MotorDB.EnumTipoObjeto.CODE));
            ComboTipo.SelectedIndex = 0;
            TimerTextChange.Enabled = false;
            EnableControls = true;
            TNombre.Focus();
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
            if (ComboTipo.SelectedIndex == -1)
                return;
            if (!BKBuscar.IsBusy)
            {
                MotorDB.CTipoBusqueda obj = (MotorDB.CTipoBusqueda)ComboTipo.SelectedItem;
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
                ComboTipo.Enabled = value;
                ListaObjetos.Enabled = value;
            }
        }

        private void BKBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (MotorDB.CObjeto obj in Objetos)
            {
                CNodoBusqueda nodo = new CNodoBusqueda();
                nodo.Nombre = obj.Nombre;
                nodo.Tipo = obj.Tipo;
                ListaObjetos.Nodes.Add(nodo);
            }
            waitControl1.Animar = false;
            EnableControls = true;
            LMensaje.Text = "Objetos encontrados: " + Objetos.Count();
            TNombre.Focus();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimerTextChange.Enabled = true;
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            CNodoBusqueda nodo = (CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                OnVerObjeto(Motor, nodo.Nombre, nodo.Tipo);
            }
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
            ListaVer = new List<MotorDB.CObetoBuqueda>();
            Errores = "";
            foreach (CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                if (OnVerObjeto != null)
                {
                    MotorDB.CObetoBuqueda obj = new MotorDB.CObetoBuqueda();
                    obj.Nombre=nodo.Nombre;
                    obj.Tipo=nodo.Tipo;

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
            foreach (MotorDB.CObetoBuqueda obj in ListaVer)
            {
                BKVerTodos.ReportProgress(pos, obj);
                pos++;
            }
        }

        private void BKVerTodos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MotorDB.CObetoBuqueda obj = (MotorDB.CObetoBuqueda)e.UserState;
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
                catch(System.Exception ex2)
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
            if(Errores!="")
                MessageBox.Show(Errores, "Processo terminado con errores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Proceso terminado Correctaente", "Fin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
