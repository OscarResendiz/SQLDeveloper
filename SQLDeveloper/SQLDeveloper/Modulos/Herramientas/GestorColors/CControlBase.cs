using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SintaxColor;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public partial class CControlBase : UserControl
    {
        public CControlBase()
        {
            InitializeComponent();
        }
        public CObjetoBase Objeto
        {
            get;
            set;
        }
        public virtual void Recarga()
        {
            //hay que sobre cargarlo y se llama cuando halla que mostrar los datos
        }
    }
}
