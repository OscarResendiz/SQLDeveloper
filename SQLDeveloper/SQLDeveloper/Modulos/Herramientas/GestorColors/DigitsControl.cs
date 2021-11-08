using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public partial class DigitsControl : CControlBase
    {
        CDigits Digits;
        public DigitsControl()
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
            }
        }
        public bool Negritas
        {
            get
            {
                return CHNegritas.Checked;
            }
            set
            {
                CHNegritas.Checked = value;
            }
        }
        public bool Cursiva
        {
            get
            {
                return CHCursiva.Checked;
            }
            set
            {
                CHCursiva.Checked = value;
            }
        }
        public Color Color
        {
            get
            {
                return ColorCmponet.Color;
            }
            set
            {
                ColorCmponet.Color = value;
            }
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            Digits = (CDigits)Objeto;
            Nombre = Digits.name;
            Negritas = Digits.bold;
            Cursiva = Digits.italic;
            Color = Digits.color.Color;
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            Digits.name = Nombre;
        }

        private void CHNegritas_CheckedChanged(object sender, EventArgs e)
        {
            Digits.bold = Negritas;
        }

        private void CHCursiva_CheckedChanged(object sender, EventArgs e)
        {
            Digits.italic = Cursiva;
        }

        private void ColorCmponet_OnColorCahnge(CComponetColor sender, Color color)
        {
            Digits.color.Color = color;
        }
    }
}
