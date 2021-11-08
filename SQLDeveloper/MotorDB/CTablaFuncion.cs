using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CTablaFuncion: CCampoGroup
    {
        public List<CParametro> Parametros
        {
            get;
            set;
        }
            
        public CTablaFuncion()
        {
            Tipo = EnumTipoObjeto.TABLA_FUNCION;
        }
        public string CodigoFuente
        {
            get;
            set;
        }
    }
}
