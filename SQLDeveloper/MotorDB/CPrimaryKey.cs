using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CPrimaryKey: CCampoGroup
    {
        public CPrimaryKey()
        {
            Tipo = EnumTipoObjeto.PRIMARYKEY;
        }
    }
}
