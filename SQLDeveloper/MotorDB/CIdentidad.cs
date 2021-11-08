using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
   public class CIdentidad: CConstraint
    {
        public CCampoBase Campo
        {
            get;
            set;
        }
        public int ValorInicial
        {
            get;
            set;
        }
        public int Incremento
        {
            get;
            set;
        }
        public CIdentidad()
        {
            ValorInicial = 1;
            Incremento = 1;
            Tipo = EnumTipoObjeto.IDENTITY;
        }        
    }
}
