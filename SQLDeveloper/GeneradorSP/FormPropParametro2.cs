using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormPropParametro2 : Form
    {
        private DialogResult result;
        public FormPropParametro2()
        {
            InitializeComponent();
            result = DialogResult;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            if (CHNoRepetibles.Checked == true)
            {
                if (TEcepcionNoRepetibles.Text.Trim() == "")
                    ok = false;
            }
            if (CHVacios.Checked == false)
            {
                if (TExcepcionVacios.Text.Trim() == "")
                    ok = false;
            }
            BAceptar.Enabled = ok;
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
        public bool NoRepetibles
        {
            get
            {
                return CHNoRepetibles.Checked;
            }
            set
            {
                CHNoRepetibles.Checked = value;
                TEcepcionNoRepetibles.Enabled = CHNoRepetibles.Checked;
            }
        }
        public string ExcepcionNoRepetibles
        {
            get
            {
                return TEcepcionNoRepetibles.Text;
            }
            set
            {
                TEcepcionNoRepetibles.Text = value;
            }
        }
        public bool Vacios
        {
            get
            {
                return CHVacios.Checked;
            }
            set
            {
                CHVacios.Checked = value;
                TExcepcionVacios.Enabled = !CHVacios.Checked;
            }
        }
        public string ExcepcionVacios
        {
            get
            {
                return TExcepcionVacios.Text;
            }
            set
            {
                TExcepcionVacios.Text = value;
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

        private void CHNoRepetibles_CheckedChanged(object sender, EventArgs e)
        {
            TEcepcionNoRepetibles.Enabled = CHNoRepetibles.Checked;
        }

        private void CHVacios_CheckedChanged(object sender, EventArgs e)
        {
            TExcepcionVacios.Enabled = !CHVacios.Checked;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;

        }

        private void FormPropParametro2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = result;
        }
    }
}