using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class CVisorCheck : CVisorBase
    {
        CCheck Check;
        public CVisorCheck(CCheck c)
        {
            Check = c;
            InitializeComponent();
        }

        private void CVisorCheck_Load(object sender, EventArgs e)
        {
            TNombre.Text = Check.Nombre;
            TRegla.Text = Check.Regla;
        }
    }
}
