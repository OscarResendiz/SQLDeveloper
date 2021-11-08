using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Lexer
{
    /// <summary>
    /// indica la posicion donde se encuentra una lexema
    /// </summary>
    public class LexPosicion
    {
        public LexPosicion()
        {
            Linea = 0;
            PosicionLinea = 0;
            PosicionGeneral = 0;
        }
        /// <summary>
        /// regresa o asigna el numero de linea
        /// </summary>
        public int Linea
        {
            get;
            set;
        }
        /// <summary>
        ///  regresa o asigna la posicion dentro de la linea
        /// </summary>
        public int PosicionLinea
        {
            get;
            set;
        }
        /// <summary>
        /// regresa o asigna la posicion general relativo a todo el documento
        /// </summary>
        public int PosicionGeneral
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "Y=" + Linea + "; X=" + PosicionLinea + "; G=" + PosicionGeneral;
        }
    }
}
