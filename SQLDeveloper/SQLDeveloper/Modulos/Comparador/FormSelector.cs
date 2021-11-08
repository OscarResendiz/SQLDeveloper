using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Comparador
{
    public delegate void ONFormSelectorEvent(string opcion1, string opcion2, String Codigo1, String Codigo2);
    public partial class FormSelector : Form
    {
        public event ONFormSelectorEvent OnSeleccion;
        public FormSelector()
        {
            InitializeComponent();
        }
        public FormSelector(string titulo, string texto1, string texto2, List<EditorManager.EditorGenerico> lista1, List<EditorManager.EditorGenerico> lista2)
        {
            InitializeComponent();
            Titulo = titulo;
            TextoArriba = texto1;
            TextoAbajo = texto2;
            ListaArriba = lista1;
            ListaAbajo = lista2;
        }
        public string Titulo
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        public string TextoArriba
        {
            get
            {
                return LPrimero.Text;
            }
            set
            {
                LPrimero.Text = value;
            }
        }
        public string TextoAbajo
        {
            get
            {
                return LSegundo.Text;
            }
            set
            {
                LSegundo.Text = value;
            }
        }
        private List<EditorManager.EditorGenerico> FListaArriba;
        public List<EditorManager.EditorGenerico> ListaArriba
        {
            get
            {
                List<EditorManager.EditorGenerico> l = new List<EditorManager.EditorGenerico>();
                foreach (EditorManager.EditorGenerico s in FListaArriba)
                {
                    l.Add(s);
                }
                return l;
            }
            set
            {
                FListaArriba = new List<EditorManager.EditorGenerico>();
                Combo1.Items.Clear();
                foreach (EditorManager.EditorGenerico s in value)
                {
                    FListaArriba.Add(s);
                    Combo1.Items.Add(s.ToString());
                }
            }
        }
        private List<EditorManager.EditorGenerico> FListaAbajo;
        public List<EditorManager.EditorGenerico> ListaAbajo
        {
            get
            {
                List<EditorManager.EditorGenerico> l = new List<EditorManager.EditorGenerico>();
                foreach (EditorManager.EditorGenerico s in FListaAbajo)
                {
                    l.Add(s);
                }
                return l;
            }
            set
            {
                FListaAbajo = new List<EditorManager.EditorGenerico>();
                Combo2.Items.Clear();
                foreach (EditorManager.EditorGenerico s in value)
                {
                    FListaAbajo.Add(s);
                    Combo2.Items.Add(s.ToString());
                }
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(Combo1.SelectedIndex==-1 || Combo2.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar los textos a comparar","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TextEditor.CTextEdit ed1 = (TextEditor.CTextEdit)ListaArriba[Combo1.SelectedIndex];
            TextEditor.CTextEdit ed2 = (TextEditor.CTextEdit)ListaAbajo[Combo2.SelectedIndex];
            if (OnSeleccion != null)
                OnSeleccion(Combo1.SelectedItem.ToString(), Combo2.SelectedItem.ToString(), ed1.CodigoFuente, ed2.CodigoFuente);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
