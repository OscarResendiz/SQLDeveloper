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
    public partial class FormEsperar : Form
    {
        public FormEsperar()
        {
            InitializeComponent();
        }

        private void FormEsperar_Load(object sender, EventArgs e)
        {
        }

        private void FormEsperar_FormClosing(object sender, FormClosingEventArgs e)
        {
            waitControl1.Animar = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            waitControl1.Animar = true;

        }
    }
}
