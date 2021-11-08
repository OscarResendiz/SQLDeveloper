using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.UI
{
    public partial class FormPropiedadesTabla : Form
    {
        public FormPropiedadesTabla()
        {
            InitializeComponent();
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text.Trim();
            }
            set
            {
                TNombre.Text = value.Trim();
            }
        }
        public string Comentarios
        {
            get
            {
                return TComentarios.Text.Trim();
            }
            set
            {
                if(value!=null)
                    TComentarios.Text = value.Trim();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Nombre == "")
                BAceptar.Enabled = false;
            else
                BAceptar.Enabled = true;
        }
    }
}
