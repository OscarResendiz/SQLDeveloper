using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CModelCodigoObjeto
    {
        public int ID_Objeto
        {
            get;
            set;
        }
        public int ID_Codigo
        {
            get;
            set;
        }
        public DateTime Fecha
        {
            get;
            set;
        }
        public string Codigo
        {
            get;
            set;
        }
        public bool Visto
        {
            get;
            set;
        }
        public string Cometarios
        {
            get;
            set;

        }
        public override string ToString()
        {
            return Fecha.ToString();
        }
    }
}
