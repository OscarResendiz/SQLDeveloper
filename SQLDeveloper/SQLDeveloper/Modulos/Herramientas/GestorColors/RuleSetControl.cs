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
    public partial class RuleSetControl : CControlBase
    {
        CRuleSet RuleSet;
        public RuleSetControl()
        {
            InitializeComponent();
        }
        public string Delimitadores
        {
            get
            {
                return TDelimitadores.Text;
            }
            set
            {
                TDelimitadores.Text = value;
            }
        }
        public bool Ignorecase
        {
            get
            {
                return CHignorecase.Checked;
            }
            set
            {
                CHignorecase.Checked = value;
            }
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            RuleSet = (CRuleSet)Objeto;
            Delimitadores = RuleSet.Delimiters;
            Ignorecase = RuleSet.ignorecase;
        }

        private void TDelimitadores_TextChanged(object sender, EventArgs e)
        {
            RuleSet.Delimiters = Delimitadores;

        }

        private void CHignorecase_CheckedChanged(object sender, EventArgs e)
        {
            RuleSet.ignorecase = Ignorecase;

        }
    }
}
