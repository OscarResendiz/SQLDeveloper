using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.BuscadorDependencias
{
   public class CObjetoBusquedaDependencia: Buscador.CObjetoBusquedaAvanzado
    {
        public CObjetoBusquedaDependencia()
        {
            NombreLargo = "";

        }
        public string NombreLargo
        {
            get;
            set;
        }
        public Buscador.CObjetoBusquedaAvanzado objetoPadre
        {
            get;
            set;
        }
    }
}
