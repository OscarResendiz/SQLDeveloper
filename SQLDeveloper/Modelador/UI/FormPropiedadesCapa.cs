using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.UI
{
    public partial class FormPropiedadesCapa : Form
    {
        public FormPropiedadesCapa()
        {
            InitializeComponent();
        }
        public string NombreCapa
        {
            get
            {
                return TCapa.Text.Trim();
            }
            set
            {
                TCapa.Text = value.Trim();
            }
        }
        public bool CapaVisible
        {
            get
            {
                return ChVisible.Checked;
            }
            set
            {
                ChVisible.Checked = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TCapa.Text.Trim() == "")
                BAceptar.Enabled = false;
            else
                BAceptar.Enabled = true;
        }
    }
}
