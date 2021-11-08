using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Lexer
{
    public class Lexema
    {
        public Lexema()
        {
            PosicionInicial = new LexPosicion();
            PosicionFinal = new LexPosicion();
            Texto = "";
            Tipo = LEXTIPE.INDEFINIDO;
            PalabraReservada = PALABRASRESERVADAS.NO_DEFINIDO; //indica que no es palabra reservada
        }
        /// <summary>
        /// asigna o regresa el indice del lexema
        /// </summary>
        public int Index
        {
            get;
            set;

        }
        /// <summary>
        /// texto que se encontró
        /// </summary>
        public string Texto
        {
            get;
            set;
        }
        /// <summary>
        /// regresa o asigna la posicion inicial del lexema dentro del documento
        /// </summary>
        public LexPosicion PosicionInicial;
        /// <summary>
        /// regresa o asigna la posicion final del lexema dentro del documento
        /// </summary>
        public LexPosicion PosicionFinal;
        /// <summary>
        /// Regresa o asigna el tipo de lexema que es
        /// </summary>
        public LEXTIPE Tipo
        {
            get;
            set;
        }
        /// <summary>
        /// asigna o regresa la nilea donde termina el exema
        /// </summary>
        public int NumeroLineaFinal
        {
            get;
            set;
        }
        /// <summary>
        /// regresa el tipo superior al que corresponde el tipo
        /// </summary>
        public LEXTIPE SuperTipo
        {
            get
            {
                switch (Tipo)
                {
                    case LEXTIPE.IDENTIFICADOR:      // LETRA+(LETRA O DIGITO O _)
                        return LEXTIPE.IDENTIFICADOR;
                    #region Variables
                    case LEXTIPE.SQLVARIABLE:        // @nombre
                        return LEXTIPE.VARIABLE;
                    case LEXTIPE.SQLVARIABLESISTEMA:        // @nombre
                        return LEXTIPE.VARIABLE;
                    #endregion
                    #region Simbolos
                    case LEXTIPE.SUMA:               // +
                    case LEXTIPE.RESTA:              // -
                    case LEXTIPE.MULTIPLICACION:     // *
                    case LEXTIPE.DIVICION:           // /
                    case LEXTIPE.MODULO:             // %
                    case LEXTIPE.INCREMENTO:         // ++
                    case LEXTIPE.DECREMENTO:         // --
                    case LEXTIPE.LLAVEABRE:          // {
                    case LEXTIPE.LLAVECIERRA:        // }
                    case LEXTIPE.CORCHETEABRE:       // [
                    case LEXTIPE.CORCHETECIERRA:    // }
                    case LEXTIPE.PARENTESISABRE:     // (
                    case LEXTIPE.PARENTESISCIERRA:   // )
                    case LEXTIPE.ASIGNACION:         // =
                    case LEXTIPE.COMA:               // ,
                    case LEXTIPE.PUNTO:              // .
                    case LEXTIPE.AMPERSON:           // &
                    case LEXTIPE.BARRA:              // |
                    case LEXTIPE.EXPONENCIAL:        // ^
                    case LEXTIPE.TILDE:              // ~
                    case LEXTIPE.PUNTOYCOMA:         // ;
                    case LEXTIPE.NEGACION:           // !
                    case LEXTIPE.MENORQUE:           // <
                    case LEXTIPE.MAYORQUE:           // >
                    case LEXTIPE.MENOROIGUALQUE:     // <=
                    case LEXTIPE.MAYOROIGUALQUE:     // >=
                    case LEXTIPE.DIFERENTESQL:       // <>
                    case LEXTIPE.DIFERENTEC:         // !=
                    case LEXTIPE.ARROBA:             // @
                    case LEXTIPE.COMILLASIMPLE:      // '
                    case LEXTIPE.COMILLADOBLE:       // "
                    case LEXTIPE.DOSPUNTOS:          // :
                    case LEXTIPE.SUMAASIGNA:         // +=
                    case LEXTIPE.RESTAASIGNA:        // -=
                    case LEXTIPE.MULTIPLICAASIGNA:   // *=
                    case LEXTIPE.DIVIDEASIGNA:       // /=
                        return LEXTIPE.SIMBOLO;
                    #endregion
                    #region constantes
                    case LEXTIPE.NUMERO:             // 123
                    case LEXTIPE.NUMEROFLOTANTE:     // 3.141516
                    case LEXTIPE.CADENASIMPLE:       // 'cadena'
                    case LEXTIPE.CADENADOBLE:        // "cadena"
                        return LEXTIPE.CONSTANTE;
                    #endregion
                    #region comentarios
                    case LEXTIPE.COMENTARIOLINEAC:    // //COMENTARIO
                    case LEXTIPE.COMENTARIOLINEASQL:  // --COMENTARIO
                    case LEXTIPE.COMENTARIOMULTIL:   // /*COMENTARIO*/
                        return LEXTIPE.COMENTARIO;
                    #endregion
                    case LEXTIPE.PALABRARESERVADA:  // que se encuentre en un listado de palabras reservadas
                        return LEXTIPE.PALABRARESERVADA;
                    case LEXTIPE.SEPARADOR:          // \t espaco en blanco
                        return LEXTIPE.SEPARADOR;
                    case LEXTIPE.INDEFINIDO:         // no reconocido
                        return LEXTIPE.INDEFINIDO;
                    case LEXTIPE.FINLINEA:            // \n
                        return LEXTIPE.FINLINEA;
                    case LEXTIPE.ALIASTABLA:
                        return LEXTIPE.IDENTIFICADOR;


                }
                return LEXTIPE.INDEFINIDO;
            }
        }
        public override string ToString()
        {
            return "Texto=\'" + Texto + "\'; Inicio: " + PosicionInicial.ToString() + " | Fin: " + PosicionFinal.ToString() + "; STipo=" + SuperTipo + "; Tipo=" + Tipo + ";";
        }
        public PALABRASRESERVADAS PalabraReservada
        {
            get;
            set;
        }
    }
}
