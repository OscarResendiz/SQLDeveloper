using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Herramientas.GestorBloques
{
    public partial class FormDetalleBloque : Form
    {
        public FormDetalleBloque()
        {
            InitializeComponent();
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
                if (value != "")
                    TNombre.ReadOnly = true;
            }
        }
        public string InicioMatch
        {
            get
            {
                return TTextoInicial.Text;
            }
            set
            {
                TTextoInicial.Text = value;
            }
        }
        public string FinMatch
        {
            get
            {
                return TTextoFinal.Text;
            }
            set
            {
                TTextoFinal.Text = value;
            }
        }
        public string TextoRemplazo
        {
            get
            {
                return TCadenaRemplazo.Text;
            }
            set
            {
                TCadenaRemplazo.Text = value;
            }
        }
        public bool UseTextLine
        {
            get
            {
                return ChRemplazo.Checked;
            }
            set
            {
                ChRemplazo.Checked = value;
            }
        }
        public int MinimumLength
        {
            get
            {
                return int.Parse(TLongitudMinima.Text);
            }
            set
            {
                TLongitudMinima.Text = value.ToString();
            }
        }
        public bool ApliaTabulador
        {
            get
            {
                return CHTabulador.Checked;
            }
            set
            {
                CHTabulador.Checked = value;
            }
        }
        private bool ValidaDatos()
        {
            if (Nombre == "")
            {
                //MessageBox.Show("Falta el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (InicioMatch == "")
            {
                //MessageBox.Show("Falta la cadena de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (FinMatch == "")
            {
                //MessageBox.Show("Falta la cadena de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!UseTextLine)
            {
                if (TextoRemplazo == "")
                {
                    //MessageBox.Show("Falta la cadena de remplazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            if (TLongitudMinima.Text.Trim() == "")
            {
                //MessageBox.Show("Falta la cadena de remplazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            BAceptar.Enabled = ValidaDatos();
        }

        private void ChRemplazo_CheckedChanged(object sender, EventArgs e)
        {
            TCadenaRemplazo.Enabled = !ChRemplazo.Checked;
            TNombre_TextChanged(null,null);
        }
    }
}
