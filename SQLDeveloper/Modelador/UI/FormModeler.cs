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
    public partial class FormModeler : Form
    {
        public event OnShowEditorGenericoEvent OnVerDiseñador;
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
    }
}
