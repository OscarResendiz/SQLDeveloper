using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteliences
{
    public enum TIPO_SIMBOLO
    {
        VARIABLE,
        TABLA,
        CAMPO
    }
    //clase que implementa un item de la tabla de simbolos
    public class CSimbolo
    {
        public string Name
        {
            get;
            set;
        }
        public int DeclarationLinea
        {
            get;
            set;
        }
        public TIPO_SIMBOLO Tipo
        {
            get;
            set;
        }
    }
}
