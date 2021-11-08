using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.BuscadorDependencias
{
    public partial class FormExcluidos : Form
    {
        CBuscadorDependencias Buscador;
        public FormExcluidos(CBuscadorDependencias buscador)
        {
            Buscador = buscador;
            InitializeComponent();
        }

        private void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Lista.SelectedIndex == -1)
                return;
            string s = Lista.Items[Lista.SelectedIndex].ToString();
            Buscador.EliminaExcluido(s);
            Lista.Items.RemoveAt(Lista.SelectedIndex);
        }

        private void FormExcluidos_Load(object sender, EventArgs e)
        {
           foreach(string s in Buscador.DameExcluidos())
           {
               Lista.Items.Add(s);
           }
        }
    }
}
