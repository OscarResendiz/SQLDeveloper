using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormPropCaso : Form
    {
        public FormPropCaso()
        {
            InitializeComponent();
        }
        public string When
        {
            get
            {
                return TWhen.Text;
            }
            set
            {
                TWhen.Text = value;
                TWhen.ReadOnly = true;
            }
        }
        public string Dhen
        {
            get
            {
                return TDhen.Text;
            }
            set
            {
                TDhen.Text = value;
            }
        }
    }
}