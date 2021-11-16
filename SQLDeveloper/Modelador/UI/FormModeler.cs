using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorManager;
namespace Modelador.UI
{
    public delegate void FormModelerVerCodigoEvent(string nombre, string codigo);
    public partial class FormModeler : Form
    {
        public event OnShowEditorGenericoEvent OnVerDiseñador;
        public event FormModelerVerCodigoEvent OnVerCodigo;
        public FormModeler()
        {
            InitializeComponent();
            modeloDatos1.Inicializa();
            cArbol1.Modelo = this.modeloDatos1;
        }

        private void FormModeler_Load(object sender, EventArgs e)
        {
        }

        private void cArbol1_OnVerModelo(EditorGenerico editor, string text)
        {
            if (OnVerDiseñador != null)
                OnVerDiseñador(editor, text);
        }
        public void VerDiseñador()
        {
            cArbol1.VerDiseñador();
        }

        private void cArbol1_OnVerCodigo(EditorGenerico editor, string text)
        {
        }
        public void MuestraCodigo(string nombre, string codigo)
        {
            if (OnVerCodigo != null)
                OnVerCodigo(nombre, codigo);
        }
    }
}
