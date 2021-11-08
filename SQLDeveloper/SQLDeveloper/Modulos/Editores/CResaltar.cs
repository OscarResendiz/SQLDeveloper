using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Editores
{
    public delegate void OnActivoChangeEvent(CResaltar obj, Color color, bool status);
    public delegate void OnColorChangeEvent(CResaltar obj, Color color);
    public delegate void OnCloseEvent(CResaltar obj);
    public partial class CResaltar : UserControl
    {
        public event OnActivoChangeEvent OnActivoChange;
        public event OnColorChangeEvent OnColorChange;
        public event OnCloseEvent OnClose;
        public event OnCloseEvent BuscarAnterior;
        public event OnCloseEvent BuscarSiguiente;
        private bool Brinco;
        public CResaltar()
        {
            InitializeComponent();
        }
        #region Propiedades
        public string Texto
        {
            get
            {
                return CHResaltar.Text;
            }
            set
            {
                CHResaltar.Text = value;
            }
        }
        public Color Color
        {
            get
            {
                return BackColor;
            }
            set
            {
                BackColor = value;
            }
        }
        public bool Activo
        {
            get
            {
                return CHResaltar.Checked;
            }
            set
            {
                CHResaltar.Checked = value;
            }
        }
        #endregion

        private void CHResaltar_CheckedChanged(object sender, EventArgs e)
        {
            if (OnActivoChange != null)
                OnActivoChange(this, BackColor, CHResaltar.Checked);
            if (Activo == false)
                TimerBrincar.Enabled = false;
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK)
                return;
            BackColor = colorDialog1.Color;
            toolStrip1.BackColor= colorDialog1.Color;
        }

        private void PanelColor_BackColorChanged(object sender, EventArgs e)
        {
            toolStrip1.BackColor= BackColor;
            if (CHResaltar.Checked)
            {
                if (OnColorChange != null)
                {
                    OnColorChange(this, BackColor);
                }
            }
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            if (OnClose != null)
                OnClose(this);
        }

        private void Banterior_Click(object sender, EventArgs e)
        {
            if (BuscarAnterior != null)
                BuscarAnterior(this);
    }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (BuscarSiguiente != null)
                BuscarSiguiente(this);
        }

        private void BBricar_Click(object sender, EventArgs e)
        {
            if (Activo == false)
                return;
            TimerBrincar.Enabled = !TimerBrincar.Enabled;
            if(TimerBrincar.Enabled==false)
            {
                CHResaltar_CheckedChanged(null, null);
            }
        }

        private void TimerBrincar_Tick(object sender, EventArgs e)
        {
            if (OnActivoChange != null)
            {
                Brinco = !Brinco;
                OnActivoChange(this, BackColor, Brinco);
            }
        }
    }
}
