using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public partial class FormPalabra : Form
    {
        public FormPalabra()
        {
            InitializeComponent();
        }
        public string Palabra
        {
            get
            {
                return TPalabra.Text;
            }
            set
            {
                TPalabra.Text = value;
            }
        }

        private void TPalabra_TextChanged(object sender, EventArgs e)
        {
            if (Palabra == "")
                BAceptar.Enabled = false;
            else
                BAceptar.Enabled = true;
        }
        public string Texto
        {
            get
            {
                return LTexto.Text;
            }
            set
            {
                LTexto.Text = value;
            }
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
    }
}
