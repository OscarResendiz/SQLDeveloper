using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Visores.Variables
{
    public partial class PropiedadesVariable : UserControl
    {
        public PropiedadesVariable()
        {
            InitializeComponent();
        }
        public CDefinicionVariable Variable
        {
            set
            {
                if (value != null)
                {
                    TNombre.Text = value.Variable;
                    TTipo.Text = value.Tipo;
                    if (value.UsaLongitud)
                        Tlongitd.Text = value.Longitud.ToString();
                }
            }
        }
    }
}
