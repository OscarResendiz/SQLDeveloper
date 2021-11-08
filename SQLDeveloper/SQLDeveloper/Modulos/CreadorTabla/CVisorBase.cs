using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CreadorTabla
{
    public delegate void OnChangeDataEvent(CVisorBase sender);
    public partial class CVisorBase : UserControl
    {
        public event OnChangeDataEvent OnChangeData;
        public CVisorBase()
        {
            InitializeComponent();
        }
        protected void ChangeData()
        {
            if (OnChangeData != null)
                OnChangeData(this);
        }
        public virtual void RefreshData()
        {
            //hay que refrescar la informacion
        }
    }
}
