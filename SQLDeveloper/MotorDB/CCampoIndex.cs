using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public enum EnumOrdenIndex
    {
        ASC,
        DESC
    }
   public class CCampoIndex:CCampoBase
    {
        public CCampoIndex()
        {
            Ordenamiento = EnumOrdenIndex.ASC;
            Tipo = EnumTipoObjeto.CAMPO;
        }
        public EnumOrdenIndex Ordenamiento
        {
            get;
            set;
        }
    }
}
