using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Lexer
{
    //indica el tipo del lexema 
    public enum LEXTIPE
    {
        IDENTIFICADOR,      // LETRA+(LETRA O DIGITO O _)
        VARIABLE,
        #region Variables
        SQLVARIABLE,        // @nombre
        SQLVARIABLESISTEMA,        // @@nombre
        #endregion
        SIMBOLO,
        #region Simbolos
        SUMA,               // +
        RESTA,              // -
        MULTIPLICACION,     // *
        DIVICION,           // /
        MODULO,             // %
        INCREMENTO,         // ++
        DECREMENTO,         // --
        LLAVEABRE,          // {
        LLAVECIERRA,        // }
        CORCHETEABRE,       // [
        CORCHETECIERRA,    // }
        PARENTESISABRE,     // (
        PARENTESISCIERRA,   // )
        ASIGNACION,         // =
        COMA,               // ,
        PUNTO,              // .
        AMPERSON,           // &
        BARRA,              // |
        EXPONENCIAL,        // ^
        TILDE,              // ~
        PUNTOYCOMA,         // ;
        NEGACION,           // !
        MENORQUE,           // <
        MAYORQUE,           // >
        MENOROIGUALQUE,     // <=
        MAYOROIGUALQUE,     // >=
        DIFERENTESQL,       // <>
        DIFERENTEC,         // !=
        ARROBA,             // @
        COMILLASIMPLE,      // '
        COMILLADOBLE,       // "
        DOSPUNTOS,          // :
        SUMAASIGNA,         // +=
        RESTAASIGNA,        // -=
        MULTIPLICAASIGNA,   // *=
        DIVIDEASIGNA,       // /=
        #endregion
        CONSTANTE,
        #region constantes
        NUMERO,             // 123
        NUMEROFLOTANTE,     // 3.141516
        CADENASIMPLE,       // 'cadena'
        CADENADOBLE,        // "cadena"
        #endregion
        COMENTARIO,
        #region comentarios
        COMENTARIOLINEAC,    // //COMENTARIO
        COMENTARIOLINEASQL,  // --COMENTARIO
        COMENTARIOMULTIL,   // /*COMENTARIO*/
        #endregion
        PALABRARESERVADA,  // que se encuentre en un listado de palabras reservadas
        SEPARADOR,          // \t espaco en blanco
        INDEFINIDO,         // no reconocido
        FINLINEA,            // \n
        GATO,               // #
        TABLATEMPORAL,       // #nombre
        ALIASTABLA          // cuando se renombra una tabla con un alias
    };
}
