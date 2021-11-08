using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CCheck: CConstraint
    {
        public CCheck()
        {
            Tipo = EnumTipoObjeto.CHECK;
        }
        public string Regla
        {
            get;
            set;
        }
    }
}
