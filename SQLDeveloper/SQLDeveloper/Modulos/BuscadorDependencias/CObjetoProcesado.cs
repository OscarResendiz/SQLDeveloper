using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.BuscadorDependencias
{
    class CObjetoProcesado
    {
        public string Origen
        {
            get;
            set;
        }
        public CObjetoBusquedaDependencia Objeto
        {
            get;
            set;
        }
    }
}
