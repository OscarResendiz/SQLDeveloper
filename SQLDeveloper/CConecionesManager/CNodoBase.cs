using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerConnect
{
   public class CNodoBase : TreeNode
    {
        //para tener un punto en comun
        /// <summary>
        /// se llama cuando el nodo cambia el chexk
        /// </summary>
        public virtual void AfterCheck()
        {
            //propago el chek a todos los hijos
            foreach (CNodoBase nodo in Nodes)
            {
                nodo.Checked = Checked;
                nodo.AfterCheck();
            }
        }
    }
}
