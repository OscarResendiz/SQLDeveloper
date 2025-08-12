using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormPropCampo : Form
    {
        public List<Objetos.CCaso> Casos;
        public FormPropCampo()
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
        public string Tipo
        {
            get
            {
                return TTipo.Text;
            }
            set
            {
                TTipo.Text = value;
            }
        }
        public string Comentario
        {
            get
            {
                return TComentario.Text;
            }
            set
            {
                TComentario.Text = value;
            }
        }
        public bool EnableAlias
        {
            get
            {
                return CHAlias.Checked;
            }
            set
            {
                CHAlias.Checked = value;
            }
        }
        public string Alias
        {
            get
            {
                return TAlias.Text;
            }
            set
            {
                TAlias.Text = value;
            }
        }
        public bool Sum
        {
            get
            {
                return CHSum.Checked;
            }
            set
            {
                CHSum.Checked = value;
            }
        }
        public bool EnableCase
        {
            get
            {
                return CHCase.Checked;
            }
            set
            {
                CHCase.Checked = value;
            }
        }

        private void BCase_Click(object sender, EventArgs e)
        {
            FormCasos dlg = new FormCasos();
            dlg.Casos = Casos;
            dlg.ShowDialog();
            Casos = dlg.Casos;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (CHAlias.Checked == true)
            {
                if (TAlias.Text.Trim() == "")
                    ok = false;
            }
            if (CHCase.Checked == true)
            {
                if (Casos == null)
                    ok = false;
                else if (Casos.Count == 0)
                    ok = false;
            }
            BAceptar.Enabled = ok;
            TAlias.ReadOnly = !CHAlias.Checked;
            BCase.Enabled = CHCase.Checked;
        }
    }
}