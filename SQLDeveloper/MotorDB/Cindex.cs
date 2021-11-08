using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class Cindex: CObjeto
    {
        public Cindex()
        {
            Tipo = EnumTipoObjeto.INDEX;
            Campos = new List<CCampoIndex>();
        }
        public List<CCampoIndex> Campos
        {
            get;
            set;
        }
    }
}
