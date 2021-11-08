using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Comparador
{
    public class CRangoDiferencia
    {
        public CRangoDiferencia()
        {
            Inicio1 = -1;
            Inicio2 = -1;
            Longitud1 = 0;
            Longitud2= 0;
        }
        public int Inicio1
        {
            get;
            set;
        }
        public int Longitud1
        {
            get;
            set;
        }
        public int Inicio2
        {
            get;
            set;
        }
        public int Longitud2
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "Inicio1=" + Inicio1.ToString() + "; Longitud1=" + Longitud1.ToString() + "; Inicio2=" + Inicio2.ToString() + "; Longitud2=" + Longitud2.ToString();
        }
    }
}
