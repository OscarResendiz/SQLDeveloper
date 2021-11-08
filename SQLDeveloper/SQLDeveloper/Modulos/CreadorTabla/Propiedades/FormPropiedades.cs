using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class FormPropiedades : Form
    {
        public CPropiedadesBase Objeto
        {
            get
            {
                return (CPropiedadesBase)propertyGrid1.SelectedObject;
            }
            set
            {
                propertyGrid1.SelectedObject = value;
            }
        }
        public FormPropiedades()
        {
            InitializeComponent();
            
        }

    }
}
