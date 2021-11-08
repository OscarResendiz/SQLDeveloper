using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;

namespace Modelador.UI
{
    public class CCampoProFk
    {
        public int ID_CampoPadre
        {
            get;
            set;
        }
        public int ID_CampoHijo
        {
            get;
            set;
        }
        public EnumAccionReferencial Tipo
        {
            get;
            set;
        }
    }
}
