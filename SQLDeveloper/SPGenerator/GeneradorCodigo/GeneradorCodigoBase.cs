using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator
{
    public class GeneradorCodigoBase
    {
        protected string Codigo;
        protected void Add(string s)
        {
            Codigo = Codigo + s;
        }
        protected void AddLine(string s)
        {
            Add(s + "\n");
        }
        protected void QuitaUltimoCaracter()
        {
            Codigo= Codigo.Substring(0,Codigo.Length-1);
        }
    }
}
