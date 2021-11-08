using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridControl
{
    public  class CTablaColumnas
    {
        public CTablaColumnas()
        {
            FColumnas = new List<string>();

        }
        private List<string> FColumnas;
        public string Tabla
        {
            get;
            set;
        }
        public List<string> Columnas
        {
            get
            {
                return FColumnas;
            }
            set
            {
                FColumnas = value;
            }
        }
        public bool ExisteColumna(string nombre)
        {
            foreach(string s in FColumnas)
            {
                if (s == nombre)
                    return true;
            }
            return false;
        }
    }
}
