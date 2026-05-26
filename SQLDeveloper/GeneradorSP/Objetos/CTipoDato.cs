using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorSP.Objetos
{
    class CTipoDato
    {
        public string Nombre;
        public bool Variable; //indica que se activa o no el campo longitud
        public CTipoDato(string nombre, bool variable)
        {
            Nombre = nombre;
            Variable = variable;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
