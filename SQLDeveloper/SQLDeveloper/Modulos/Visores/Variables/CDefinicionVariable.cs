using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Lexer;
namespace SQLDeveloper.Modulos.Visores.Variables
{
    public class CDefinicionVariable
    {
        public string Variable
        {
            get;
            set;
        }
        public string Tipo
        {
            get;
            set;
        }
        public string Longitud
        {
            get;
            set;
        }
        public bool UsaLongitud
        {
            get;
            set;
        }
    }
}
