using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public delegate void OnColorCahngeEvent(CComponetColor sender,Color color);
    public partial class CComponetColor : UserControl
    {
        public event OnColorCahngeEvent OnColorCahnge;
        public CComponetColor()
        {
            InitializeComponent();
        }
        public string Nombre
        {
            get
            {
                return LNombre.Text;
            }
            set
            {
                LNombre.Text = value;
            }
        }
        public Color Color
        {
            get
            {
                return PanelColor.BackColor;
            }
            set
            {
                PanelColor.BackColor = value;
            }
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color = colorDialog1.Color;
                if (OnColorCahnge != null)
                    OnColorCahnge(this, Color);
            }
        }
    }
}
