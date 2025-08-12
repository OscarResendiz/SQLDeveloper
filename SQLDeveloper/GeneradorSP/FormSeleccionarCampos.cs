using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormSeleccionarCampos : Form
    {
        public FormSeleccionarCampos(List<Objetos.CParametro> l)
        {
            InitializeComponent();
            foreach (Objetos.CParametro obj in l)
            {
                ComboCampos.Items.Add(obj);
            }
        }
        public Objetos.CParametro Campo
        {
            get
            {
                Objetos.CParametro obj;
                obj = (Objetos.CParametro)ComboCampos.Items[ComboCampos.SelectedIndex];
                return obj;
            }
        }
        public int CampoAEliminar
        {
            get
            {
                return ComboCampos.SelectedIndex;
            }
        }

        private void ComboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboCampos.SelectedIndex == -1)
                return;
            BAceptar.Enabled = true;
        }
        public string Texto
        {
            set
            {
                label1.Text = value;
            }
        }
    }
}