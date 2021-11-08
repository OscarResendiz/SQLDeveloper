using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CError
    {
        public string Mensaje;
        public int Linea;
        public override string ToString()
        {
            return Linea.ToString() + ">" + Mensaje;
        }
        public CError()
        {

        }
        public CError(int l, string msg)
        {
            Linea = l;
            Mensaje = msg;
        }
    }
    public class ExceptionDB: Exception
    {
        public List<CError> Errores;
        public ExceptionDB()
        {
            Errores = new List<CError>();
        }
        public void Add(CError err)
        {
            Errores.Add(err);
        }
    }
}
