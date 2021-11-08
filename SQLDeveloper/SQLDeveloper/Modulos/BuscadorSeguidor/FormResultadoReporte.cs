using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.BuscadorSeguidor
{
    public partial class FormResultadoReporte : Form
    {
        private DataTable Tabla;
        public FormResultadoReporte(DataTable  tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }

        private void FormResultadoReporte_Load(object sender, EventArgs e)
        {
            griVisor1.Tabla = Tabla;
            griVisor1.AllowUserToOrderColumns = false;
        }
    }
}
