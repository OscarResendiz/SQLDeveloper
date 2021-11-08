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
    public partial class FormBuscadorObjetos : Form
    {
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        MotorDB.EnumTipoObjeto tipo;
        List<MotorDB.CObjeto> Objetos;
        string cadena;
        public FormBuscadorObjetos()
        {
           // Motor = motor;
            InitializeComponent();
        }

        private void FormBuscadorObjetos_Load(object sender, EventArgs e)
        {
            ComboTipo.Items.Clear();
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Todos", MotorDB.EnumTipoObjeto.NONE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Tablas", MotorDB.EnumTipoObjeto.TABLE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Type Table", MotorDB.EnumTipoObjeto.TYPE_TABLE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Vistas", MotorDB.EnumTipoObjeto.VIEW));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Procediientos almacenados", MotorDB.EnumTipoObjeto.PROCEDURE));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Funciones", MotorDB.EnumTipoObjeto.FUNCION));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Trigers", MotorDB.EnumTipoObjeto.TRIGER));
            ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Buscar campos en objetos",MotorDB.EnumTipoObjeto.CAMPO));
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
            if(e.KeyCode== Keys.Enter)
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
                    TNombre.Text=Clipboard.GetText();
                }
            }
        }

        private void TimerTextChange_Tick(object sender, EventArgs e)
        {
            TimerTextChange.Enabled = false;
            Buscar();
        }
        private void Buscar()
        {
            if (ComboTipo.SelectedIndex== -1)
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
        private void BKBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            Objetos = MotorDB.DBProvider.DB.Buscar(cadena, tipo);
        }

        private void BKBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach(MotorDB.CObjeto obj in Objetos)
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
            if(OnVerObjeto!=null)
            {

                OnVerObjeto(MotorDB.DBProvider.DB, nodo.Nombre, nodo.Tipo);
            }
        }

        private void ListaObjetos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Linfo.Text = (string)e.Node.Tag;
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                if (OnVerObjeto != null)
                {
                    OnVerObjeto(MotorDB.DBProvider.DB, nodo.Nombre, nodo.Tipo);
                }
            }

        }

        private void ListaObjetos_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
        }

        private void ListaObjetos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string cadena="";
            CNodoBusqueda nodo = (CNodoBusqueda)e.Item;
            switch(nodo.Tipo)
            {
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    cadena = MotorDB.DBProvider.DB.GetExcecute_StoreProcedure(nodo.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.FUNCION:
                    cadena = MotorDB.DBProvider.DB.GetExcecute_Function(nodo.Nombre);
                    break;
                default:
                    cadena=nodo.Nombre;
                    break;

            }
            DoDragDrop(cadena, DragDropEffects.Move);
        }

        private void copiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            CNodoBusqueda nodo = (CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                Clipboard.SetText(nodo.Nombre);
            }

        }
    }
}
