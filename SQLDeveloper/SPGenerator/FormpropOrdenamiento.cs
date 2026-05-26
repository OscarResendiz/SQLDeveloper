using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPGenerator
{
    public partial class FormpropOrdenamiento : Form
    {
        public FormpropOrdenamiento()
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
        public bool Desendente
        {
            get
            {
                return RBDecendente.Checked;
            }
            set
            {
                RBDecendente.Checked = value;
                RBAcendente.Checked = !value;
            }
        }

    }
}