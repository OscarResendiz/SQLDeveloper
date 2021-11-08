using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
   public class CFuncion: CStoreProcedure
    {
        public CFuncion()
        {
            Tipo = EnumTipoObjeto.FUNCION;
        }
        public CTipoDato Retorno
        {
            get;
            set;
        }
    }
}
