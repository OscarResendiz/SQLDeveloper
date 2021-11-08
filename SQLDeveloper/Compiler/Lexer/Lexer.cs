using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Compiler.Lexer
{
    /// <summary>
    /// componente que realiza todo el analisi lexico de una cadena cualquiera
    /// </summary>
    public partial class Lecxer : Component, IEnumerable
    {
        private int IndexActual; //cursor que siempre va a estar apuntando al lexema siguiente
        private static Dictionary<PALABRASRESERVADAS, string> PalabrasReservadas;
        #region Codigo generado por VS
        public Lecxer()
        {
            InicializaPalabrasReservadas();
            lexemas = new List<Lexema>();
            InitializeComponent();
        }

        public Lecxer(IContainer container)
        {
            InicializaPalabrasReservadas();
            lexemas = new List<Lexema>();
            container.Add(this);

            InitializeComponent();
        }
        #endregion
        #region Variables internas
        List<Lexema> lexemas;
        private int posicion = 0;
        private int nLinea = 0;
        private string FCadena = "";
        private int FLongitudCadena;
        #endregion
        #region Propiedades
        /// <summary>
        /// regresa true si el apuntador de lexemas esta al inicio
        /// </summary>
        public bool CursorInicio
        {
            get
            {
                return IndexActual == 0;
            }
        }
        /// <summary>
        /// regresa true si el apuntador de lexemas esta apuntando al ultimo lexema
        /// </summary>
        public bool CursorFinal
        {
            get
            {
                if (lexemas == null)
                    return false;
                return IndexActual==lexemas.Count()-1;
            }
        }
        /// <summary>
        /// Asigna o regresa la cadena que hay que separar en lexemas
        /// </summary>
        public string Cadena
        {
            get
            {
                return FCadena;
            }
            set
            {
                if (value == null)
                    return;
                FCadena = value;
                FLongitudCadena = FCadena.Length;
                Analiza();
                BuscaPalabrasReservadas();
                AsignaIndices();
            }
        }
        /// <summary>
        /// regresa la longitud de la cadena a analizar
        /// </summary>
        public int LongitudCadena
        {
            get
            {
                return FLongitudCadena;
            }
        }
        #endregion
        #region Impelentacion de IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)new LexEnumerable(lexemas);
        }
        #endregion
        #region Funciones internas
        /// <summary>
        /// regresa true si el caracter es una letra o un _
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool EsLetra(char c)
        {
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            if (c == '_')
                return true;
            if (c == 'ñ' || c == 'Ñ')
                return true;
            return false;
        }
        /// <summary>
        /// regresa true si el caracter es un digito
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool EsDigito(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }
        /// <summary>
        /// regresa true si es un simbolo simple
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool EsSimboloSimple(char c)
        {
            //verifica si es uno se los simbolos simples que se reconocen
            switch (c)
            {
                case ',':
                    return true;
                case '[':
                    return true;
                case ']':
                    return true;
                case '{':
                    return true;
                case '}':
                    return true;
                case '(':
                    return true;
                case ')':
                    return true;
                case '.':
                    return true;
                case '+':
                    return true;
                case '*':
                    return true;
                case '=':
                    return true;
                case '&':
                    return true;
                case '%':
                    return true;
                case '|':
                    return true;
                case '^':
                    return true;
                case '~':
                    return true;
                case ';':
                    return true;
                //nuevos simbolos
                case '/':
                    return true;
                case '!':
                    return true;
                case '<':
                    return true;
                case '>':
                    return true;
                case '@':
                    return true;
                case '\'':
                    return true;
                case ':':
                    return true;
                case '-':
                    return true;
                case '"':
                    return true;
                case '#':
                    return true;
            }
            return false;
        }
        /// <summary>
        /// regresa el symbolo que representa c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private LEXTIPE TipoSimbolo(char c)
        {
            //regresa el tipo de simbolo
            switch (c)
            {
                case ',':
                    return LEXTIPE.COMA;
                case '[':
                    return LEXTIPE.CORCHETEABRE;
                case ']':
                    return LEXTIPE.CORCHETECIERRA;
                case '{':
                    return LEXTIPE.LLAVEABRE;
                case '}':
                    return LEXTIPE.LLAVECIERRA;
                case '(':
                    return LEXTIPE.PARENTESISABRE;
                case ')':
                    return LEXTIPE.PARENTESISCIERRA;
                case '.':
                    return LEXTIPE.PUNTO;
                case '+':
                    return LEXTIPE.SUMA;
                case '*':
                    return LEXTIPE.MULTIPLICACION;
                case '=':
                    return LEXTIPE.ASIGNACION;
                case '&':
                    return LEXTIPE.AMPERSON;
                case '%':
                    return LEXTIPE.MODULO;
                case '|':
                    return LEXTIPE.BARRA;
                case '^':
                    return LEXTIPE.EXPONENCIAL;
                case '~':
                    return LEXTIPE.TILDE;
                case ';':
                    return LEXTIPE.PUNTOYCOMA;
                //nuevos simbolos
                case '/':
                    return LEXTIPE.DIVICION;
                case '!':
                    return LEXTIPE.NEGACION;
                case '<':
                    return LEXTIPE.MENORQUE;
                case '>':
                    return LEXTIPE.MAYORQUE;
                case '@':
                    return LEXTIPE.ARROBA;
                case '\'':
                    return LEXTIPE.COMILLASIMPLE;
                case ':':
                    return LEXTIPE.DOSPUNTOS;
                case '-':
                    return LEXTIPE.RESTA;
                case '"':
                    return LEXTIPE.COMILLADOBLE;
                case '#':
                    return  LEXTIPE.GATO;
            }
            return LEXTIPE.INDEFINIDO;
        }
        /// <summary>
        /// inicializa la lista de palabras reservadas
        /// </summary>
        private void InicializaPalabrasReservadas()
        {
            if (PalabrasReservadas == null)
            {
                PalabrasReservadas = new Dictionary<PALABRASRESERVADAS, string>();
                foreach (string s in Enum.GetNames(typeof(PALABRASRESERVADAS)).ToList())
                {
                    PALABRASRESERVADAS p = (PALABRASRESERVADAS)Enum.Parse(typeof(PALABRASRESERVADAS), s);
                    PalabrasReservadas.Add(p, s);
                }
            }

        }
        /// <summary>
        /// regresa true si la palabra coincide con una palabra reservada
        /// </summary>
        /// <param name="palabra"></param>
        /// <returns></returns>
        private bool EsPalabraReservada(string palabra)
        {
            foreach (KeyValuePair<PALABRASRESERVADAS, string> obj in PalabrasReservadas)
            {
                if (palabra.ToUpper().Trim() == obj.Value.ToUpper().Trim())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// regresa el valor del ENUM si es una palabra reservada y PALABRASRESERVADAS.NO_DEFINIDO en caso contrario
        /// </summary>
        /// <param name="palabra"></param>
        /// <returns></returns>
        private PALABRASRESERVADAS DamePalabraReservada(string palabra)
        {
            foreach (KeyValuePair<PALABRASRESERVADAS, string> obj in PalabrasReservadas)
            {
                if (palabra.ToUpper().Trim() == obj.Value.ToUpper().Trim())
                {
                    return obj.Key;
                }
            }
            return PALABRASRESERVADAS.NO_DEFINIDO;
        }
        /// <summary>
        /// indica si el caractes es o no un separador
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool EsSeparador(char x)
        {
            if (x == '\t')
                return true;
            if (x == ' ')
                return true;
            return false;
        }
        /// <summary>
        /// Coienza con el analisi de la cadena
        /// </summary>
        private void Analiza()
        {
            IndexActual = 0; //siempre se reinicia
            lexemas.Clear();
            posicion = 0;
            nLinea = 0;
            Lexema lex = null;
            int posLine = 0;
            int tmpposicion = 0;
            int tmpnLinea = 0;
            int tmpposLine = 0;
            //recorro toda la cadena hasta el final
            //las expresiones regulares que se van a identificar son
            //1. letra+_+numero paraidentificadores
            //2. numeros digito+.+digito
            //simbolos 
            try
            {
                while (posicion < LongitudCadena)
                {
                    #region identificador
                    if (EsLetra(FCadena[posicion]))
                    {
                        //encontre el inicio de un identificador
                        lex = new Lexema();
                        //asigno la posicion inicial
                        lex.PosicionInicial.PosicionLinea = posLine;
                        lex.PosicionInicial.Linea = nLinea;
                        lex.PosicionInicial.PosicionGeneral = posicion;
                        //mientras sea letra o numero es valido
                        while ((posicion < LongitudCadena) && (EsLetra(FCadena[posicion]) || EsDigito(FCadena[posicion])))
                        {
                            lex.Texto += FCadena[posicion].ToString();
                            posicion++;
                            posLine++;
                        }
                        lex.Tipo = LEXTIPE.IDENTIFICADOR;
                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                        lex.PosicionFinal.Linea = nLinea;
                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                        //lo agrego a la lista
                        lexemas.Add(lex);
                    }
                    #endregion
                    #region Numeros
                    else if (EsDigito(FCadena[posicion]))
                    {
                        lex = new Lexema();
                        lex.PosicionInicial.PosicionLinea = posLine;
                        lex.PosicionInicial.Linea = nLinea;
                        lex.PosicionInicial.PosicionGeneral = posicion;
                        bool pd = false;
                        //es valido mientras siga siendo digito o '.' siempre y cuando solo exista un '.'
                        while ((posicion < LongitudCadena) && (EsDigito(FCadena[posicion]) || (FCadena[posicion] == '.' && pd == false)))
                        {
                            lex.Texto += FCadena[posicion].ToString();
                            if (FCadena[posicion] == '.')
                                pd = true;
                            posicion++;
                            posLine++;
                        }
                        lex.Tipo = LEXTIPE.NUMERO;
                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                        lex.PosicionFinal.Linea = nLinea;
                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                        //lo agrego a la lista
                        lexemas.Add(lex);
                    }
                    #endregion
                    #region simbolos
                    else if (EsSimboloSimple(FCadena[posicion]))
                    {
                        lex = new Lexema();
                        lex.PosicionInicial.PosicionLinea = posLine;
                        lex.PosicionInicial.Linea = nLinea;
                        lex.PosicionInicial.PosicionGeneral = posicion;
                        lex.Texto += FCadena[posicion].ToString();
                        lex.Tipo = TipoSimbolo(FCadena[posicion]);
                        lex.PosicionFinal.PosicionLinea = posLine;
                        lex.PosicionFinal.Linea = nLinea;
                        lex.PosicionFinal.PosicionGeneral = posicion;
                        //verifico si hay que revisar algo mas a fondo, por los casos donde el simbolo corresponde a dos caracteres
                        if ((posicion + 1) < LongitudCadena)
                        {
                            switch (lex.Tipo)
                            {
                                #region INCREMENTO ++ o SUMAASIGNA +=
                                case LEXTIPE.SUMA: // puede ser ++ o += 
                                    #region INCREMENTO ++
                                    if (FCadena[posicion + 1] == '+')
                                    {
                                        lex.Tipo = LEXTIPE.INCREMENTO;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    #endregion
                                    #region SUMAASIGNA +=
                                    else if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.SUMAASIGNA;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    #endregion
                                    break;
                                #endregion
                                #region COMENTARIOLINEASQL -- o RESTAASIGNA -=
                                case LEXTIPE.RESTA: // puede ser -- o -= o 
                                    #region COMENTARIOLINEASQL --
                                    if (FCadena[posicion + 1] == '-')
                                    {
                                        // podria ser un decremento pero se asume que es un comentario sql por ser el lenguaje al que esta orientado en analizador
                                        lex.Tipo = LEXTIPE.COMENTARIOLINEASQL;
                                        posicion++;
                                        posLine++;
                                        while ((posicion < LongitudCadena) && (FCadena[posicion] != '\n' && FCadena[posicion] != '\0'))
                                        {
                                            //mientras no sea fin de cadena o fin de linea agrego los caracteres a la cadena
                                            lex.Texto += FCadena[posicion].ToString();
                                            posicion++;
                                            posLine++;
                                        }
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                        lexemas.Add(lex);
                                        continue; //me paso a analizar el siguiente caracter
                                    }
                                    #endregion
                                    #region RESTAASIGNA -=
                                    else if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.RESTAASIGNA;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                        continue; //me paso a analizar el siguiente caracter
                                    }
                                    #endregion
                                    break;
                                #endregion
                                #region MAYOROIGUALQUE >=
                                case LEXTIPE.MAYORQUE:
                                    if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.MAYOROIGUALQUE;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    break;
                                #endregion
                                #region MENOROIGUALQUE <= o DIFERENTESQL <>
                                case LEXTIPE.MENORQUE:
                                    if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.MENOROIGUALQUE;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    else if (FCadena[posicion + 1] == '>')
                                    {
                                        lex.Tipo = LEXTIPE.DIFERENTESQL;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    break;
                                #endregion
                                #region DIFERENTEC !=
                                case LEXTIPE.NEGACION:
                                    if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.DIFERENTEC;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    break;
                                #endregion
                                #region MULTIPLICAASIGNA *=
                                case LEXTIPE.MULTIPLICACION:
                                    #region MULTIPLICAASIGNA
                                    if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.MULTIPLICAASIGNA;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    #endregion/*
                                    break;
                                #endregion
                                #region DIVIDEASIGNA /= o COMENTARIOLINEAC // comentario o COMENTARIOMULTIL /* comentario */
                                case LEXTIPE.DIVICION:
                                    #region DIVIDEASIGNA /=
                                    if (FCadena[posicion + 1] == '=')
                                    {
                                        lex.Tipo = LEXTIPE.DIVIDEASIGNA;
                                        posicion++;
                                        posLine++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion;
                                    }
                                    #endregion
                                    #region COMENTARIOLINEAC //comentario

                                    else if (FCadena[posicion + 1] == '/')
                                    {
                                        lex.Tipo = LEXTIPE.COMENTARIOLINEAC;
                                        posicion++;
                                        posLine++;
                                        while (FCadena[posicion] != '\n' && FCadena[posicion] != '\0')
                                        {
                                            //mientras no sea fin de cadena o fin de linea agrego los caracteres a la cadena
                                            lex.Texto += FCadena[posicion].ToString();
                                            posicion++;
                                            posLine++;
                                        }
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                        continue; //me paso a analizar el siguiente caracter

                                    }
                                    #endregion
                                    #region COMENTARIOMULTIL /* comentario */
                                    else if (FCadena[posicion + 1] == '*')
                                    {
                                        tmpposLine = posLine;
                                        tmpposicion = posicion;
                                        tmpnLinea = nLinea;

                                        posicion++;
                                        posLine++;
                                        //recorro la cadena hasta encontrar el fin de la cadena
                                        while ((posicion + 1 < LongitudCadena) && (FCadena[posicion] != '*' || FCadena[posicion + 1] != '/'))
                                        {
                                            lex.Texto += FCadena[posicion].ToString();
                                            posicion++;
                                            posLine++;
                                            //tomo en cuenta el numero de linea
                                            if (posicion >= LongitudCadena)
                                                break;
                                            if (FCadena[posicion] == '\n')
                                            {
                                                nLinea++;
                                                posLine = 0;
                                            }
                                        }
                                        //en este punto tengo el final del comentario */
                                        if ((posicion + 1 < LongitudCadena) && (FCadena[posicion] == '*' && FCadena[posicion + 1] == '/'))
                                        {
                                            lex.Texto += FCadena[posicion].ToString(); //agrego el *
                                            posicion++;
                                            posLine++;
                                            lex.Texto += FCadena[posicion].ToString(); // agrego el /
                                            lex.Tipo = LEXTIPE.COMENTARIOMULTIL;

                                        }
                                        else
                                        {
                                            //se llego al final de la cadena y no se encontro el cierre del comentario
                                            //por lo que hay que echar para atras todo
                                            posLine = tmpposLine;
                                            posicion = tmpposicion;
                                            nLinea = tmpnLinea;
                                            lex.Texto = "/";
                                        }
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                    }
                                    #endregion
                                    break;
                                #endregion
                                #region CADENASIMPLE 'cadena'
                                case LEXTIPE.COMILLASIMPLE:
                                    tmpposLine = posLine;
                                    tmpposicion = posicion;
                                    tmpnLinea = nLinea;
                                    posicion++;
                                    posLine++;
                                    //recorro la cadena hasta encontrar el fin de la cadena
                                    while ((posicion < LongitudCadena) && FCadena[posicion] != '\'')
                                    {
                                        lex.Texto += FCadena[posicion].ToString();
                                        posicion++;
                                        posLine++;
                                        //tomo en cuenta el numero de linea
                                        if (posicion >= LongitudCadena - 1)
                                            break;
                                        if (FCadena[posicion] == '\n')
                                        {
                                            nLinea++;
                                            posLine = 0;
                                        }
                                    }
                                    //en este punto se tiene la comiila
                                    if ((posicion < LongitudCadena) && (FCadena[posicion] == '\''))
                                    {
                                        lex.Tipo = LEXTIPE.CADENASIMPLE;
                                        //la agrego y me salto al siguiente caracter
                                        lex.Texto += FCadena[posicion].ToString();
                                        //                                posicion++;
                                        //                              posLine++;
                                    }
                                    else
                                    {
                                        //se llego al final del texto y no se encontro el cierre de la cadena
                                        //por lo que hay que echar para atras todo
                                        posLine = tmpposLine;
                                        posicion = tmpposicion;
                                        nLinea = tmpnLinea;
                                        lex.Texto = "\'";
                                    }
                                    lex.PosicionFinal.PosicionLinea = posLine - 1;
                                    lex.PosicionFinal.Linea = nLinea;
                                    lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                    break;
                                #endregion
                                #region CADENADOBLE "cadena"
                                case LEXTIPE.COMILLADOBLE:
                                    tmpposLine = posLine;
                                    tmpposicion = posicion;
                                    tmpnLinea = nLinea;
                                    posicion++;
                                    posLine++;
                                    //recorro la cadena hasta encontrar el fin de la cadena
                                    while ((posicion < LongitudCadena) && FCadena[posicion] != '\"')
                                    {
                                        lex.Texto += FCadena[posicion].ToString();
                                        posicion++;
                                        posLine++;
                                        //tomo en cuenta el numero de linea
                                        if (posicion >= LongitudCadena)
                                            break;
                                        if (FCadena[posicion] == '\n')
                                        {
                                            nLinea++;
                                            posLine = 0;
                                        }
                                    }
                                    //en este punto se tiene la comiila
                                    if ((posicion < LongitudCadena) && (FCadena[posicion] == '\"'))
                                    {
                                        lex.Tipo = LEXTIPE.CADENADOBLE;
                                        //la agrego y me salto al siguiente caracter
                                        lex.Texto += FCadena[posicion].ToString();
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                    }
                                    else
                                    {
                                        //se llego al final del texto y no se encontro el cierre de la cadena
                                        //por lo que hay que echar para atras todo
                                        posLine = tmpposLine;
                                        posicion = tmpposicion;
                                        nLinea = tmpnLinea;
                                        lex.Texto = "\"";
                                    }
                                    break;
                                #endregion
                                #region SQLVARIABLE @nombre o SQLVARIABLESISTEMA @@nombre
                                case LEXTIPE.ARROBA:
                                    //el siguiente caracter debe de ser un caracter
                                    if (EsLetra(FCadena[posicion + 1]))
                                    {
                                        posicion++;
                                        while ((posicion < LongitudCadena) && (EsLetra(FCadena[posicion]) || EsDigito(FCadena[posicion])))
                                        {
                                            lex.Texto += FCadena[posicion].ToString();
                                            posicion++;
                                            posLine++;
                                        }
                                        lex.Tipo = LEXTIPE.SQLVARIABLE;
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                        //lo agrego a la lista
                                        lexemas.Add(lex);
                                        continue;
                                    }
                                    else if (FCadena[posicion + 1] == '@')
                                    {
                                        posicion++;
                                        lex.Texto += FCadena[posicion].ToString();
                                        posicion++;
                                        while ((posicion < LongitudCadena) && (EsLetra(FCadena[posicion]) || EsDigito(FCadena[posicion])))
                                        {
                                            lex.Texto += FCadena[posicion].ToString();
                                            posicion++;
                                            posLine++;
                                        }
                                        lex.Tipo = LEXTIPE.SQLVARIABLESISTEMA;
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                        //lo agrego a la lista
                                        lexemas.Add(lex);
                                        continue;

                                    }
                                    break;
                                case LEXTIPE.GATO:
                                    if (EsLetra(FCadena[posicion + 1]))
                                    {
                                        posicion++;
                                        while ((posicion < LongitudCadena) && (EsLetra(FCadena[posicion]) || EsDigito(FCadena[posicion])))
                                        {
                                            lex.Texto += FCadena[posicion].ToString();
                                            posicion++;
                                            posLine++;
                                        }
                                        lex.Tipo = LEXTIPE.TABLATEMPORAL;
                                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                                        lex.PosicionFinal.Linea = nLinea;
                                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                                        //lo agrego a la lista
                                        lexemas.Add(lex);
                                        continue;
                                    }
                                    break;
                                #endregion
                            }
                        }
                        //lo agrego a la lista
                        lexemas.Add(lex);
                        posicion++;
                        posLine++;
                    }
                    #endregion
                    #region separadores
                    else if (FCadena[posicion] == '\r' && FCadena[posicion + 1] == '\n')
                    {
                        //es una nueva linea
                        lex = new Lexema();
                        //posicion inicial
                        lex.PosicionInicial.PosicionLinea = posLine;
                        lex.PosicionInicial.Linea = nLinea;
                        lex.PosicionInicial.PosicionGeneral = posicion;
                        posicion++;
                        posLine++;
                        lex.Texto += "\r\n";
                        lex.Tipo = LEXTIPE.FINLINEA;
                        //posicion final
                        lex.PosicionFinal.PosicionLinea = posLine;
                        lex.PosicionFinal.Linea = nLinea;
                        lex.PosicionFinal.PosicionGeneral = posicion;
                        //lo agrego a la lista
                        lexemas.Add(lex);
                        posicion++;
                        posLine = 0;
                        nLinea++;
                    }
                    else if (EsSeparador(FCadena[posicion]))
                    {
                        lex = new Lexema();
                        lex.PosicionInicial.PosicionLinea = posLine;
                        lex.PosicionInicial.Linea = nLinea;
                        lex.PosicionInicial.PosicionGeneral = posicion;
                        //sigo separando los demas separadores
                        while ((posicion < LongitudCadena) && EsSeparador(FCadena[posicion]))
                        {
                            lex.Texto += FCadena[posicion].ToString();
                            posicion++;
                            posLine++;
                        }
                        lex.Tipo = LEXTIPE.SEPARADOR;
                        lex.PosicionFinal.PosicionLinea = posLine - 1;
                        lex.PosicionFinal.Linea = nLinea;
                        lex.PosicionFinal.PosicionGeneral = posicion - 1;
                        //lo agrego a la lista
                        lexemas.Add(lex);
                    }
                    else
                    {
                        //no se que sea
                        lex = new Lexema();
                        lex.PosicionInicial.PosicionLinea = posLine;
                        lex.PosicionInicial.Linea = nLinea;
                        lex.PosicionInicial.PosicionGeneral = posicion;
                        lex.Texto += FCadena[posicion].ToString();
                        posicion++;
                        posLine++;
                        lex.Tipo = LEXTIPE.INDEFINIDO;
                        lex.PosicionFinal.PosicionLinea = posLine;
                        lex.PosicionFinal.Linea = nLinea;
                        lex.PosicionFinal.PosicionGeneral = posicion;
                        //lo agrego a la lista
                        lexemas.Add(lex);
                    }

                    #endregion
                }
                //agrego un ultimo lexema
                lex = new Lexema();
                //posicion inicial
                lex.PosicionInicial.PosicionLinea = posLine;
                lex.PosicionInicial.Linea = nLinea;
                lex.PosicionInicial.PosicionGeneral = posicion;
                posicion++;
                posLine++;
                lex.Texto += "\r\n";
                lex.Tipo = LEXTIPE.FINLINEA;
                //posicion final
                lex.PosicionFinal.PosicionLinea = posLine;
                lex.PosicionFinal.Linea = nLinea;
                lex.PosicionFinal.PosicionGeneral = posicion;
                //lo agrego a la lista
                lexemas.Add(lex);
            }
            catch(System.Exception)
            {
                return;
            }

        }
        /// <summary>
        /// Busca los identificadores que son palabras reservadas y les asigna su valor corespondiente
        /// </summary>
        private void BuscaPalabrasReservadas()
        {
            try
            {
                foreach (Lexema lex in lexemas)
                {
                    if (lex.Tipo == LEXTIPE.IDENTIFICADOR)
                    {
                        if (EsPalabraReservada(lex.Texto) == true)
                        {
                            lex.Tipo = LEXTIPE.PALABRARESERVADA;
                            lex.PalabraReservada = DamePalabraReservada(lex.Texto);
                        }
                    }
                }
            }
            catch(System.Exception ex)
            {
                return;
            }
        }
        private void AsignaIndices()
        {
            for(int i=0; i<lexemas.Count();i++)
            {
                if (lexemas[i] != null)
                {
                    lexemas[i].Index = i;
                }
            }

        }
        #endregion
        #region Funciones publicas
        /// <summary>
        /// regresa el lexema indicado en index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Lexema this[int index]
        {
            get
            {
                return lexemas[index];
            }
        }
        /// <summary>
        /// regresa el numero de lexemas que contiene la cadena
        /// </summary>
        public int Length
        {
            get
            {
                return lexemas.Count();
            }
        }
        /// <summary>
        /// regresa el indice del lexema que se encuentra en la posicion pos. regrea -1 si no lo encuentra 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetIndexPos(int pos)
        {
            try
            {
                int i = 0;
                foreach (Lexema obj in lexemas)
                {
                    if (obj.PosicionInicial.Linea == 42)
                        i = i;
                    if (obj.PosicionInicial.PosicionGeneral <= pos && obj.PosicionFinal.PosicionGeneral >= pos)
                    {
                        return i;
                    }
                    i++;
                }
            }
            catch(System.Exception ex)
            {
                return -1;
            }
            //si llega hasta aqui no se encontro
            return -1;
        }
        #region Manejo de items
        /// <summary>
        /// reinicial el apuntador de lexemas y regresa el primer lexema que no sea separador o comentario o null si no encuentra alguno
        /// </summary>
        /// <returns></returns>
        public Lexema DamePrimerLexemaUtil()
        {
            ReiniciaCursor();
            return DameSiguienteLexemaUtil();
        }
        /// <summary>
        /// reinicia el apuntador de lexemas
        /// </summary>
        public void ReiniciaCursor()
        {
            IndexActual = 0;
        }
        /// <summary>
        /// mueve el apuntador de lexemas a la ultima posicion
        /// </summary>
        public void MueveCursosAlFinal()
        {
            IndexActual = lexemas.Count() - 1;
        }
        /// <summary>
        /// Regresa el primer lexema que no sea separador o comentario o null si no encuentra alguno
        /// </summary>
        /// <returns></returns>
        public Lexema DameSiguienteLexemaUtil()
        {
            while (IndexActual < lexemas.Count())
            {
                Lexema lex = lexemas[IndexActual];
                IndexActual++;
                if (lex.Tipo != LEXTIPE.SEPARADOR && lex.Tipo != LEXTIPE.FINLINEA && lex.Tipo != LEXTIPE.COMENTARIO)
                    return lex;
            }
            return null;

        }
        /// <summary>
        /// Regresa el lexema anterior a la posicion actual del apuntador ignorando espacios en blanco y comentarios
        /// </summary>
        /// <returns></returns>
        public Lexema DameLexemaUtilAnterior()
        {
            if (IndexActual == 0)
                return null;
            do
            {
                IndexActual--;
                Lexema lex = lexemas[IndexActual];
                if (lex.Tipo != LEXTIPE.SEPARADOR && lex.Tipo != LEXTIPE.FINLINEA && lex.Tipo != LEXTIPE.COMENTARIO)
                    return lex;

            } while (IndexActual > 0);
            return null;
        }
        /// <summary>
        /// regresa el primer lexema que corresponda con el tipo. Si no encuentra regresa null y no afecta el apuntador de lexemas
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public Lexema BuscaSiguienteLexema(LEXTIPE tipo)
        {
            //guardo la posicion actual
            int IndexActualOrg = IndexActual; 
            while (IndexActual < lexemas.Count())
            {
                Lexema lex = lexemas[IndexActual];
                IndexActual++;
                if (lex.Tipo == tipo)
                    return lex;
            }
            //restauro la posicion actual 
            IndexActual = IndexActualOrg;
            return null;
        }
        /// <summary>
        /// regresa el lexema anterior que corresponda al tipo. Si no encuentra regresa null y no afecta el apuntador de lexemas
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public Lexema BuscaLexemaAnterior(LEXTIPE tipo)
        {
            //guardo la posicion actual
            int IndexActualOrg = IndexActual;
            while (IndexActual >0)
            {
                IndexActual--;
                Lexema lex = lexemas[IndexActual];
                if (lex.Tipo == tipo)
                    return lex;
            }
            //restauro la posicion actual 
            IndexActual = IndexActualOrg;
            return null;            
        }
        /// <summary>
        /// regresa la palabra reservada buscada. si no la encuentra regresa null y no afecta el puntador de lexemas
        /// </summary>
        /// <param name="palabra"></param>
        /// <returns></returns>
        public Lexema BuscaSiguientePalabraReservada(PALABRASRESERVADAS palabra)
        {
            int IndexActualOrg = IndexActual;
            while (IndexActual < lexemas.Count())
            {
                Lexema lex = lexemas[IndexActual];
                IndexActual++;
                if (lex.Tipo == LEXTIPE.PALABRARESERVADA && lex.PalabraReservada == palabra)
                    return lex;
            }
            //restauro la posicion actual 
            IndexActual = IndexActualOrg;
            return null;

        }
        /// <summary>
        /// regresa la palabra reservada buscada. si no la encuentra regresa null y no mueve el apuntador de lexemas
        /// </summary>
        /// <param name="palabra"></param>
        /// <returns></returns>
        public Lexema BuscaPalabraReservadaAnterior(PALABRASRESERVADAS palabra)
        {
            //guardo la posicion actual
            int IndexActualOrg = IndexActual;
            while (IndexActual > 0)
            {
                IndexActual--;
                Lexema lex = lexemas[IndexActual];
                if (lex.Tipo ==  LEXTIPE.PALABRARESERVADA && lex.PalabraReservada== palabra)
                    return lex;
            }
            //restauro la posicion actual 
            IndexActual = IndexActualOrg;
            return null;
        }
        /// <summary>
        /// Regresa una posicion el apuntador de lexemas
        /// </summary>
        public void DesechaLexema()
        {
            IndexActual--;
        }
        /// <summary>
        /// mueve el apuntador de lexemas a la posicion indicada
        /// </summary>
        /// <param name="pos"></param>
        public void MueveCursorA(int pos)
        {
            if (pos >= lexemas.Count() || pos<0)
                throw new Exception("Posicion fuera del intervalo");
            IndexActual = pos;
        }
        #endregion
        #endregion
    }
}
   