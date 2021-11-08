using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CTipoBusqueda
    {
        public CTipoBusqueda()
        {

        }
        public string Cadena
        {
            get;
            set;
        }
        public MotorDB.EnumTipoObjeto Tipo
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Cadena;
        }
        public CTipoBusqueda(string cadena, MotorDB.EnumTipoObjeto tipo)
        {
            Cadena = cadena;
            Tipo = tipo;
        }
    }
}
