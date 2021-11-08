using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public partial class FormComentario : Form
    {
        public FormComentario()
        {
            InitializeComponent();
        }
        public string Texto
        {
            get
            {
                return richTextBox1.Rtf;
            }
            set
            {
                if (value == "")
                    richTextBox1.Text = "";
                else
                    richTextBox1.Rtf = value;
            }
        }

        private void BFuente_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            richTextBox1.SelectionFont=fontDialog1.Font;
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void BBakColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionBackColor;
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            richTextBox1.SelectionBackColor = colorDialog1.Color;
        }

        private void BIzquierda_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void Bcentrado_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void BDerecha_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
