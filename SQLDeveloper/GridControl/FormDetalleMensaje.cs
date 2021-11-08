using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridControl
{
    public partial class FormDetalleMensaje : Form
    {
        public FormDetalleMensaje()
        {
            InitializeComponent();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string Texto
        {
            get
            {
                return TTextro.Text;
            }
            set
            {
                TTextro.Text = value;
            }
        }
    }
}
