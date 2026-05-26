using SPGenerator.Objetos;
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

namespace SPGenerator
{
    public partial class FormSeleccionarCampos : Form
    {
        public FormSeleccionarCampos(List<CParametroSP> l)
        {
            InitializeComponent();
            foreach (CParametroSP obj in l)
            {
                ComboCampos.Items.Add(obj);
            }
        }
        public CParametroSP Campo
        {
            get
            {
                CParametroSP obj;
                obj = (CParametroSP)ComboCampos.Items[ComboCampos.SelectedIndex];
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