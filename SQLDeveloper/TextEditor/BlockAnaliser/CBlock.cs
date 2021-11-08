using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TextEditor
{
    //clase encargada de mantener los datos que corresponden a unbloque de codigo contraible
    public class CBlock
    {
        public string Text
        {
            get;
            set;
        }
        public Point Inicio
        {
            get;
            set;
        }
        public Point Final
        {
            get;
            set;
        }
        public bool AplicaTabulador
        {
            get;
            set;
        }
    }
}
