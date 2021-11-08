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
    public partial class FormPropiedadesRegion : Form
    {
        public FormPropiedadesRegion()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TNombre.Text.Trim() == "")
                BAceptar.Enabled = false;
            else
                BAceptar.Enabled = true;
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text.Trim();
            }
            set
            {
                TNombre.Text = value.Trim();
            }
        }
        public Color Bk_Color
        {
            get
            {
                return BBackColor.BackColor;
            }
            set
            {
                BBackColor.BackColor = value;
            }
        }
        public Color Fore_Color
        {
            get
            {
                return BForeColor.BackColor;
            }
            set
            {
                BForeColor.BackColor = value;
            }
        }
        public bool RegionVisible
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

        private void BBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Bk_Color;
            if (colorDialog1.ShowDialog() != DialogResult.OK)
                return;
            Bk_Color = colorDialog1.Color;
        }

        private void BForeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Fore_Color;
            if (colorDialog1.ShowDialog() != DialogResult.OK)
                return;
            Fore_Color = colorDialog1.Color;

        }
    }
}
