using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Editores
{
    public partial class FormBuscador : Form
    {
        public FormBuscador()
        {
            InitializeComponent();
        }
        public ICSharpCode.TextEditor.TextEditorControl Editor
        {
            get
            {
                return cBuscador1.Editor;
            }
            set
            {
                cBuscador1.Editor = value;
            }
        }
    }
}
