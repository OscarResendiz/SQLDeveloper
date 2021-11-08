using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Forms
{
    public delegate bool ONFormNombreEvent(FormNombre sender, string nombre);
    public partial class FormNombre : Form
    {
        public event ONFormNombreEvent OnNombre;
        public FormNombre()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TNombre.Text.Trim() == "")
                BAceptar.Enabled = false;
            else
                BAceptar.Enabled = true;
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
        public String Texto
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (OnNombre != null)
               if( OnNombre(this, Nombre)==false)
               {
                   DialogResult = System.Windows.Forms.DialogResult.None;
                   return;
               }
        }
    }
}
   