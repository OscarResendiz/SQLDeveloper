using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Comparador
{
    public class CLinea
    {
        private string Ftexto;
        public CLinea()
        {
            Procesado = false;
        }
        public int NLinea
        {
            get;
            set;
        }
        public string texto
        {
            get
            {
                return  Ftexto;
            }
            set
            {
                Ftexto = value;
            }
        }
        public bool Procesado
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "NLinea=" + NLinea.ToString() + "; Texto=" + texto + "; procesado=" + Procesado.ToString();
        }
    }
}
