using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CVista: CCampoGroup
    {
        public CVista()
        {
            Tipo = EnumTipoObjeto.VIEW;
        }
        public string CodigoFuente
        {
            get;
            set;
        }
        public CCampoBase GetCampo(string nombre)
        {
            foreach (CCampoBase obj in FCampos)
            {
                if (obj.Nombre == nombre)
                    return obj;
            }
            return null;
        }
    }
}
