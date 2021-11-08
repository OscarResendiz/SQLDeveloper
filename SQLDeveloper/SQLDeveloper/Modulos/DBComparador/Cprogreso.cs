using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.DBComparador
{
    public class Cprogreso
    {
        public int Maximo;
        public int Valor;
        public string Mensaje;
        public Cprogreso(int max, int val, string msg)
        {
            Maximo = max;
            Valor = val;
            Mensaje = msg;
        }
    }
}
