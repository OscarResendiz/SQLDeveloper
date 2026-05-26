using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaraverTools.Formularios
{
    public partial class FormLaravel : Form
    {
        public FormLaravel()
        {
            InitializeComponent();
            cArbol1.Modelo = modeloDatos1;
        }

        private void cArbol1_OnVerCodigo(EditorManager.EditorGenerico editor, string text)
        {

        }
    }
}
