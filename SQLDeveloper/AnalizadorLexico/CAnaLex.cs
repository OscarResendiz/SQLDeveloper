using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AnalizadorLexico
{
    public enum TIPO_LEX
    {
        IDENTIFICADOR = 0,// letra(letra|digito)*
        SIMBOLO = 1,//operadores 
        VARIABLE = 2,//@[letra]+[letra|digito]*
        NUMERO = 3,//[digito]+[.|X]*[digito]
        CADENA = 4,// ['][cualquier caracter][']
        COMENTARIO = 5,// [//][cualquier caracter][Nueva linea]|[/*][cualquier cosa][*/]
        PALABRA_RESERVADA = 6, //todas las palabras reservadas de sql
        OTRO = 7,// cuando no se reconoce el simbolo
        SEPARADOR=8
    };
    public partial class CAnaLex : Component
    {
        public event OnErrorEvent OnError;
        private string FTexto;
        int pos;
        int Max;
        CNodo PalasRservadas;
        //private CTablaTransicion Tabla;
        private void OnerrorHandle(string msg)
        {
            if (OnError != null)
                OnError(msg);
        }
        public CAnaLex()
        {
            InitializeComponent();
        }

        public CAnaLex(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public string Texto
        {
            get
            {
                return FTexto;
            }
            set
            {
                FTexto = value;
                pos = 0;
                Max = 0;
                if (FTexto!=null)
                Max = FTexto.Length;
            }
        }
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
                case '-':
                    return true;
            }
            return false;
        }
        private bool EsLetra(char c)
        {
            if (c >= 'a' && c <= 'z') 
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            if (c == '_')
                return true;
            return false;
        }
        private bool EsDigito(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }
        public CLexema DameItem()
        {
            CLexema lex;
            lex = DameIteminterno();
            if (lex == null)
                return lex;
            //reviso si es un identificador
            if (lex.Tipo == TIPO_LEX.IDENTIFICADOR)
            {
                //reviso si es una palabra reservada
                if (PalasRservadas.EstaCOntenido(lex.cadena) == true)
                {
                    //le cambia el tipo
                    lex.Tipo = TIPO_LEX.PALABRA_RESERVADA;
                }
            }
            return lex;
        }
        private CLexema DameIteminterno()
        {
            if (PalasRservadas == null)
                CargaPalabrasReservadas();
            CLexema lex;
            int estado = 0;
            int posI;
            string s="";
            Char c;
            //primero veo separadores
            int separadores = 0;
            posI = pos;
            while (pos < Max && (FTexto[pos] == ' ' || FTexto[pos] == '\t'))// || FTexto[pos] == '\r' || FTexto[pos] == '\n'))
            {
                separadores++;
                pos++;
            }
            if(separadores>0)
            {
                //hay separadores, por lo que los regreso como un item mas
                lex = new CLexema();
                lex.cadena = FTexto.Substring(posI, pos - posI);
                lex.Pos = posI;
                lex.Tipo = TIPO_LEX.SEPARADOR;
               // pos++;
                return lex;
            }
            if (pos > Max)
                return null;
            //guardo la posocion del texto que voy a analizar
            posI = pos;
            //analizo hasta el final del texto
            while (pos < Max&&FTexto[pos] != '\0')
            {
                //obtengo el caracter
                c=FTexto[pos];
                switch (estado)
                {
                    case 0:
                        //if (c == '!')
                          //  estado = 14;
                        //else if (c == '<')
                          //  estado = 13;
                        //else if (c == '>')
                          //  estado = 12;
                        //else if (c == '/')
                          //  estado = 8;
                        //else if (c == '@')
                          //  estado = 5;
                        //else if (c == '\'')
                          //  estado = 7;
                        //else if (c == '-')
                          //  estado = 15;
                        //else 
                        if (EsSimboloSimple(c) == true)
                        {
                            //se detecto un simbolo
                            lex = new CLexema();
                            lex.cadena = c.ToString();
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.SIMBOLO;
                            pos++;
                            return lex;
                        }
                        else if (EsLetra(c) == true)
                            estado = 1;
                        else if (EsDigito(c) == true)
                            estado = 2;
                        s=s+c;
                        pos++;
                        break;
                    case 1:
                        if (EsLetra(c) == false&&EsDigito(c)==false)
                        {
                            //se detecto un identificador
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.IDENTIFICADOR;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c; //se trae el siguiente caracter y se mantiene en el mismo estado
                        pos++;
                        break;
                    case 2:
                        if (c == '.' || c == 'X' || c == 'x')
                            estado = 3;
                        else if (EsDigito(c) == false)
                        {
                            //se detecto un numero
                            lex = new CLexema();
                            lex.cadena = s;
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.NUMERO;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 3:
                        if (EsDigito(c) == true)
                            estado = 4;
                        else
                        {
                            //error, no se reconoce el item
                            lex = new CLexema();
                            lex.cadena = s;
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.OTRO;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 4:
                        if (EsDigito(c) == false)
                        {
                            //se detecto un numero
                            lex = new CLexema();
                            lex.cadena = s;
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.NUMERO;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 5:
                        if (EsLetra(c) == true)
                            estado = 6;
                        else
                        {
                            //no se reconoce el item
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.OTRO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 6:
                        if (EsLetra(c) == false && EsDigito(c) == false)
                        {
                            //se detecto una variable
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.VARIABLE;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 7:
                        if (c == '\'')
                        {
                            // se detecto una cadena
                            s = s + c;
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.CADENA;
                            lex.Pos = posI;
                            lex.cadena = s;
                            pos++;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 8:
                        if (c == '/')
                            estado = 9;
                        else if (c == '*')
                            estado = 10;
                        else
                        {
                            // se detecto un simbolo
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.SIMBOLO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 9:
                        if (c == '\n' || c == '\0')
                        {
                            // se detecto un comentario
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.COMENTARIO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 10:
                        if (c == '*')
                            estado = 11;
                        s = s + c;
                        pos++;
                        break;
                    case 11:
                        if (c == '/')
                        {
                            //se detecto un comentario
                            s = s + c;
                            pos++;
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.COMENTARIO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        estado = 10;
                        s = s + c;
                        pos++;
                        break;
                    case 12:
                        if (c =='=')
                        {
                            //toma en cuenta el caracter y lo consume
                            s = s + c;
                            pos++;
                        }
                        // se detecto un simbolo
                        lex = new CLexema();
                        lex.Tipo = TIPO_LEX.SIMBOLO;
                        lex.Pos = posI;
                        lex.cadena = s;
                        return lex;
                    case 13:
                        if (c =='='||c=='>')
                        {
                            //toma en cuenta el caracter y lo consume
                            s = s + c;
                            pos++;
                        }
                        // se detecto un simbolo
                        lex = new CLexema();
                        lex.Tipo = TIPO_LEX.SIMBOLO;
                        lex.Pos = posI;
                        lex.cadena = s;
                        return lex;
                    case 14:
                        if (c == '<' || c == '>' || c == '=')
                        {
                            // se detecto un simbolo
                            //toma en cuenta el caracter y lo consume
                            s = s + c;
                            pos++;
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.SIMBOLO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        //no se reconoce el item
                        lex = new CLexema();
                        lex.Tipo = TIPO_LEX.OTRO;
                        lex.Pos = posI;
                        lex.cadena = s;
                        return lex;
                    case 15:
                        if (c == '-')
                            estado = 16;
                        else
                        {
                            //se detecto un simbolo
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.SIMBOLO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                    case 16:
                        if (c == '\n' || c == '\0')
                        {
                            //se detecto un comentario
                            pos++;
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.COMENTARIO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                        }
                        s = s + c;
                        pos++;
                        break;
                }
            }
            if (s != "")
            {
                switch (estado)
                {
                    case 1:
                            //se detecto un identificador
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.IDENTIFICADOR;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 2:
                            //se detecto un numero
                            lex = new CLexema();
                            lex.cadena = s;
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.NUMERO;
                            return lex;
                    case 3:
                            //error, no se reconoce el item
                            lex = new CLexema();
                            lex.cadena = s;
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.OTRO;
                            return lex;
                    case 4:
                            //se detecto un numero
                            lex = new CLexema();
                            lex.cadena = s;
                            lex.Pos = posI;
                            lex.Tipo = TIPO_LEX.NUMERO;
                            return lex;
                    case 5:
                            //no se reconoce el item
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.OTRO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 6:
                            //se detecto una variable
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.VARIABLE;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 7:
                            // se detecto una cadena
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.CADENA;
                            lex.Pos = posI;
                            lex.cadena = s;
                            pos++;
                            return lex;
                    case 8:
                            // se detecto un simbolo
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.SIMBOLO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 9:
                            // se detecto un comentario
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.COMENTARIO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 11:
                            //se detecto un comentario
                            pos++;
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.COMENTARIO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 12:
                        // se detecto un simbolo
                        lex = new CLexema();
                        lex.Tipo = TIPO_LEX.SIMBOLO;
                        lex.Pos = posI;
                        lex.cadena = s;
                        return lex;
                    case 13:
                        // se detecto un simbolo
                        lex = new CLexema();
                        lex.Tipo = TIPO_LEX.SIMBOLO;
                        lex.Pos = posI;
                        lex.cadena = s;
                        return lex;
                    case 14:
                        //no se reconoce el item
                        lex = new CLexema();
                        lex.Tipo = TIPO_LEX.OTRO;
                        lex.Pos = posI;
                        lex.cadena = s;
                        return lex;
                    case 15:
                            //se detecto un simbolo
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.SIMBOLO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                    case 16:
                            //se detecto un comentario
                            pos++;
                            lex = new CLexema();
                            lex.Tipo = TIPO_LEX.COMENTARIO;
                            lex.Pos = posI;
                            lex.cadena = s;
                            return lex;
                }
                //if (estado == 16)
                //{
                //    //es un comentario y ahi se quedo
                //    //se detecto un comentario
                //    pos++;
                //    lex = new CLexema();
                //    lex.Tipo = TIPO_LEX.COMENTARIO;
                //    lex.Pos = posI;
                //    lex.cadena = s;
                //    return lex;
                //}
                //if (estado == 4)
                //{
                //    //se detecto un numero
                //    lex = new CLexema();
                //    lex.cadena = s;
                //    lex.Pos = posI;
                //    lex.Tipo = TIPO_LEX.NUMERO;
                //    return lex;
                //}
                //lex = new CLexema();
                //lex.Pos = posI;
                //lex.Tipo = TIPO_LEX.IDENTIFICADOR;
                //lex.cadena = s;
                //return lex;
            }
            return null;
        }
        private void CargaPalabrasReservadas()
        {
            PalasRservadas = new CNodo("ADD");
            PalasRservadas.OnError += new OnErrorEvent(OnerrorHandle);
            PalasRservadas.Add("EXCEPT");
            PalasRservadas.Add("PERCENT");
            PalasRservadas.Add("ALL");
            PalasRservadas.Add("EXEC");
            PalasRservadas.Add("PLAN");
            PalasRservadas.Add("ALTER");
            PalasRservadas.Add("EXECUTE");
            PalasRservadas.Add("PRECISION");
            PalasRservadas.Add("AND");
            PalasRservadas.Add("EXISTS");
            PalasRservadas.Add("PRIMARY");
            PalasRservadas.Add("ANY");
            PalasRservadas.Add("EXIT");
            PalasRservadas.Add("PRINT");
            PalasRservadas.Add("AS");
            PalasRservadas.Add("FETCH");
            PalasRservadas.Add("PROC");
            PalasRservadas.Add("ASC");
            PalasRservadas.Add("FILE");
            PalasRservadas.Add("PROCEDURE");
            PalasRservadas.Add("AUTHORIZATION");
            PalasRservadas.Add("FILLFACTOR");
            PalasRservadas.Add("PUBLIC");
            PalasRservadas.Add("BACKUP");
            PalasRservadas.Add("FOR");
            PalasRservadas.Add("RAISERROR");
            PalasRservadas.Add("BEGIN");
            PalasRservadas.Add("FOREIGN");
            PalasRservadas.Add("READ");
            PalasRservadas.Add("BETWEEN");
            PalasRservadas.Add("FREETEXT");
            PalasRservadas.Add("READTEXT");
            PalasRservadas.Add("BREAK");
            PalasRservadas.Add("FUNCTION");
            PalasRservadas.Add("REVOKE");
            PalasRservadas.Add("SCHEMA");
            PalasRservadas.Add("COLLATE");
            PalasRservadas.Add("IDENTITY_INSERT");
            PalasRservadas.Add("IDENTITYCOL");
            PalasRservadas.Add("CHECKPOINT");
            PalasRservadas.Add("CLUSTERED");
            PalasRservadas.Add("RECONFIGURE");
            PalasRservadas.Add("FREETEXTTABLE");
            PalasRservadas.Add("SAVE");
            PalasRservadas.Add("GRANT");
            PalasRservadas.Add("BROWSE");
            PalasRservadas.Add("FROM");
            PalasRservadas.Add("REFERENCES");
            PalasRservadas.Add("BULK");
            PalasRservadas.Add("FULL");
            PalasRservadas.Add("REPLICATION");
            PalasRservadas.Add("RESTORE");
            PalasRservadas.Add("BY");
            PalasRservadas.Add("CASCADE");
            PalasRservadas.Add("GOTO");
            PalasRservadas.Add("RESTRICT");
            PalasRservadas.Add("CASE");
            PalasRservadas.Add("RETURN");
            PalasRservadas.Add("CHECK");
            PalasRservadas.Add("GROUP");
            PalasRservadas.Add("HAVING");
            PalasRservadas.Add("RIGHT");
            PalasRservadas.Add("CLOSE");
            PalasRservadas.Add("HOLDLOCK");
            PalasRservadas.Add("ROLLBACK");
            PalasRservadas.Add("IDENTITY");
            PalasRservadas.Add("ROWCOUNT");
            PalasRservadas.Add("COALESCE");
            PalasRservadas.Add("ROWGUIDCOL");
            PalasRservadas.Add("RULE");
            PalasRservadas.Add("COLUMN");
            PalasRservadas.Add("IF");
            PalasRservadas.Add("COMMIT");
            PalasRservadas.Add("IN");
            PalasRservadas.Add("COMPUTE");
            PalasRservadas.Add("INDEX");
            PalasRservadas.Add("SELECT");
            PalasRservadas.Add("CONSTRAINT");
            PalasRservadas.Add("INNER");
            PalasRservadas.Add("SESSION_USER");
            PalasRservadas.Add("CONTAINS");
            PalasRservadas.Add("INSERT");
            PalasRservadas.Add("SET");
            PalasRservadas.Add("CONTAINSTABLE");
            PalasRservadas.Add("INTERSECT");
            PalasRservadas.Add("SETUSER");
            PalasRservadas.Add("CONTINUE");
            PalasRservadas.Add("INTO");
            PalasRservadas.Add("SHUTDOWN");
            PalasRservadas.Add("CONVERT");
            PalasRservadas.Add("IS");
            PalasRservadas.Add("SOME");
            PalasRservadas.Add("CREATE");
            PalasRservadas.Add("JOIN");
            PalasRservadas.Add("STATISTICS");
            PalasRservadas.Add("CROSS");
            PalasRservadas.Add("CLAVE");
            PalasRservadas.Add("SYSTEM_USER");
            PalasRservadas.Add("CURRENT");
            PalasRservadas.Add("KILL");
            PalasRservadas.Add("TABLE");
            PalasRservadas.Add("TEXTSIZE");
            PalasRservadas.Add("LEFT");
            PalasRservadas.Add("CURRENT_DATE");
            PalasRservadas.Add("CURRENT_TIME");
            PalasRservadas.Add("LIKE");
            PalasRservadas.Add("THEN");
            PalasRservadas.Add("CURRENT_TIMESTAMP");
            PalasRservadas.Add("LINENO");
            PalasRservadas.Add("TO");
            PalasRservadas.Add("CURRENT_USER");
            PalasRservadas.Add("LOAD");
            PalasRservadas.Add("TOP");
            PalasRservadas.Add("CURSOR");
            PalasRservadas.Add("NATIONAL");
            PalasRservadas.Add("TRAN");
            PalasRservadas.Add("DATABASE");
            PalasRservadas.Add("NOCHECK");
            PalasRservadas.Add("TRANSACTION");
            PalasRservadas.Add("DBCC");
            PalasRservadas.Add("NONCLUSTERED");
            PalasRservadas.Add("TRIGGER");
            PalasRservadas.Add("TRUNCATE");
            PalasRservadas.Add("NOT");
            PalasRservadas.Add("DEALLOCATE");
            PalasRservadas.Add("UPDATE");
            PalasRservadas.Add("UNIQUE");
            PalasRservadas.Add("UPDATETEXT");
            PalasRservadas.Add("OFFSETS");
            PalasRservadas.Add("DECLARE");
            PalasRservadas.Add("NULL");
            PalasRservadas.Add("TSEQUAL");
            PalasRservadas.Add("DEFAULT");
            PalasRservadas.Add("NULLIF");
            PalasRservadas.Add("UNION");
            PalasRservadas.Add("OF");
            PalasRservadas.Add("OFF");
            PalasRservadas.Add("DELETE");
            PalasRservadas.Add("DESC");
            PalasRservadas.Add("DENY");
            PalasRservadas.Add("DISK");
            PalasRservadas.Add("ON");
            PalasRservadas.Add("USE");
            PalasRservadas.Add("DISTINCT");
            PalasRservadas.Add("OPEN");
            PalasRservadas.Add("USER");
            PalasRservadas.Add("DISTRIBUTED");
            PalasRservadas.Add("OPENDATASOURCE");
            PalasRservadas.Add("VALUES");
            PalasRservadas.Add("DOUBLE");
            PalasRservadas.Add("OPENQUERY");
            PalasRservadas.Add("VARYING");
            PalasRservadas.Add("DROP");
            PalasRservadas.Add("OPENROWSET");
            PalasRservadas.Add("VIEW");
            PalasRservadas.Add("DUMMY");
            PalasRservadas.Add("OPENXML");
            PalasRservadas.Add("WAITFOR");
            PalasRservadas.Add("DUMP");
            PalasRservadas.Add("OPTION");
            PalasRservadas.Add("WHEN");
            PalasRservadas.Add("ELSE");
            PalasRservadas.Add("OR");
            PalasRservadas.Add("WHERE");
            PalasRservadas.Add("ORDER");
            PalasRservadas.Add("WHILE");
            PalasRservadas.Add("ERRLVL");
            PalasRservadas.Add("OUTER");
            PalasRservadas.Add("WITH");
            PalasRservadas.Add("ESCAPE");
            PalasRservadas.Add("OVER");
            PalasRservadas.Add("WRITETEXT");
            PalasRservadas.Add("ABSOLUTE");
            PalasRservadas.Add("FOUND");
            PalasRservadas.Add("PRESERVE");
            PalasRservadas.Add("ACTION");
            PalasRservadas.Add("FREE");
            PalasRservadas.Add("PRIOR");
            PalasRservadas.Add("ADMIN");
            PalasRservadas.Add("GENERAL");
            PalasRservadas.Add("PRIVILEGES");
            PalasRservadas.Add("AFTER");
            PalasRservadas.Add("GET");
            PalasRservadas.Add("READS");
            PalasRservadas.Add("AGGREGATE");
            PalasRservadas.Add("GLOBAL");
            PalasRservadas.Add("REAL");
            PalasRservadas.Add("ALIAS");
            PalasRservadas.Add("GO");
            PalasRservadas.Add("RECURSIVE");
            PalasRservadas.Add("ALLOCATE");
            PalasRservadas.Add("GROUPING");
            PalasRservadas.Add("REF");
            PalasRservadas.Add("ARE");
            PalasRservadas.Add("HOST");
            PalasRservadas.Add("REFERENCING");
            PalasRservadas.Add("ARRAY");
            PalasRservadas.Add("HOUR");
            PalasRservadas.Add("RELATIVE");
            PalasRservadas.Add("ASSERTION");
            PalasRservadas.Add("IGNORE");
            PalasRservadas.Add("RESULT");
            PalasRservadas.Add("AT");
            PalasRservadas.Add("IMMEDIATE");
            PalasRservadas.Add("RETURNS");
            PalasRservadas.Add("BEFORE");
            PalasRservadas.Add("INDICATOR");
            PalasRservadas.Add("ROLE");
            PalasRservadas.Add("BINARY");
            PalasRservadas.Add("INITIALIZE");
            PalasRservadas.Add("ROLLUP");
            PalasRservadas.Add("BIT");
            PalasRservadas.Add("INITIALLY");
            PalasRservadas.Add("ROUTINE");
            PalasRservadas.Add("BLOB");
            PalasRservadas.Add("INOUT");
            PalasRservadas.Add("ROW");
            PalasRservadas.Add("BOOLEAN");
            PalasRservadas.Add("INPUT");
            PalasRservadas.Add("ROWS");
            PalasRservadas.Add("BOTH");
            PalasRservadas.Add("INT");
            PalasRservadas.Add("SAVEPOINT");
            PalasRservadas.Add("BREADTH");
            PalasRservadas.Add("INTEGER");
            PalasRservadas.Add("SCROLL");
            PalasRservadas.Add("CALL");
            PalasRservadas.Add("INTERVAL");
            PalasRservadas.Add("SCOPE");
            PalasRservadas.Add("CASCADED");
            PalasRservadas.Add("ISOLATION");
            PalasRservadas.Add("SEARCH");
            PalasRservadas.Add("CAST");
            PalasRservadas.Add("ITERATE");
            PalasRservadas.Add("SECOND");
            PalasRservadas.Add("CATALOG");
            PalasRservadas.Add("LANGUAGE");
            PalasRservadas.Add("SECTION");
            PalasRservadas.Add("CHAR");
            PalasRservadas.Add("LARGE");
            PalasRservadas.Add("SEQUENCE");
            PalasRservadas.Add("CHARACTER");
            PalasRservadas.Add("LAST");
            PalasRservadas.Add("SESSION");
            PalasRservadas.Add("CLASS");
            PalasRservadas.Add("LATERAL");
            PalasRservadas.Add("SETS");
            PalasRservadas.Add("CLOB");
            PalasRservadas.Add("LEADING");
            PalasRservadas.Add("SIZE");
            PalasRservadas.Add("COLLATION");
            PalasRservadas.Add("LESS");
            PalasRservadas.Add("SMALLINT");
            PalasRservadas.Add("COMPLETION");
            PalasRservadas.Add("LEVEL");
            PalasRservadas.Add("SPACE");
            PalasRservadas.Add("CONNECT");
            PalasRservadas.Add("LIMIT");
            PalasRservadas.Add("SPECIFIC");
            PalasRservadas.Add("CONNECTION");
            PalasRservadas.Add("SPECIFICTYPE");
            PalasRservadas.Add("LOCAL");
            PalasRservadas.Add("CONSTRAINTS");
            PalasRservadas.Add("LOCALTIME");
            PalasRservadas.Add("SQL");
            PalasRservadas.Add("CONSTRUCTOR");
            PalasRservadas.Add("LOCALTIMESTAMP");
            PalasRservadas.Add("SQLEXCEPTION");
            PalasRservadas.Add("CORRESPONDING");
            PalasRservadas.Add("LOCATOR");
            PalasRservadas.Add("SQLSTATE");
            PalasRservadas.Add("CUBE");
            PalasRservadas.Add("MAP");
            PalasRservadas.Add("SQLWARNING");
            PalasRservadas.Add("CURRENT_PATH");
            PalasRservadas.Add("MATCH");
            PalasRservadas.Add("START");
            PalasRservadas.Add("CURRENT_ROLE");
            PalasRservadas.Add("MINUTE");
            PalasRservadas.Add("STATE");
            PalasRservadas.Add("CYCLE");
            PalasRservadas.Add("MODIFIES");
            PalasRservadas.Add("STATEMENT");
            PalasRservadas.Add("DATA");
            PalasRservadas.Add("MODIFY");
            PalasRservadas.Add("STATIC");
            PalasRservadas.Add("DATE");
            PalasRservadas.Add("MODULE");
            PalasRservadas.Add("STRUCTURE");
            PalasRservadas.Add("DAY");
            PalasRservadas.Add("MONTH");
            PalasRservadas.Add("TEMPORARY");
            PalasRservadas.Add("DEC");
            PalasRservadas.Add("NAMES");
            PalasRservadas.Add("TERMINATE");
            PalasRservadas.Add("DECIMAL");
            PalasRservadas.Add("NATURAL");
            PalasRservadas.Add("THAN");
            PalasRservadas.Add("DEFERRABLE");
            PalasRservadas.Add("NCHAR");
            PalasRservadas.Add("TIME");
            PalasRservadas.Add("DEFERRED");
            PalasRservadas.Add("NCLOB");
            PalasRservadas.Add("TIMESTAMP");
            PalasRservadas.Add("DEPTH");
            PalasRservadas.Add("NEW");
            PalasRservadas.Add("TIMEZONE_HOUR");
            PalasRservadas.Add("DEREF");
            PalasRservadas.Add("NEXT");
            PalasRservadas.Add("TIMEZONE_MINUTE");
            PalasRservadas.Add("DESCRIBE");
            PalasRservadas.Add("NO");
            PalasRservadas.Add("TRAILING");
            PalasRservadas.Add("DESCRIPTOR");
            PalasRservadas.Add("NONE");
            PalasRservadas.Add("TRANSLATION");
            PalasRservadas.Add("DESTROY");
            PalasRservadas.Add("NUMERIC");
            PalasRservadas.Add("TREAT");
            PalasRservadas.Add("DESTRUCTOR");
            PalasRservadas.Add("OBJECT");
            PalasRservadas.Add("TRUE");
            PalasRservadas.Add("DETERMINISTIC");
            PalasRservadas.Add("OLD");
            PalasRservadas.Add("UNDER");
            PalasRservadas.Add("DICTIONARY");
            PalasRservadas.Add("ONLY");
            PalasRservadas.Add("UNKNOWN");
            PalasRservadas.Add("DIAGNOSTICS");
            PalasRservadas.Add("OPERATION");
            PalasRservadas.Add("UNNEST");
            PalasRservadas.Add("DISCONNECT");
            PalasRservadas.Add("ORDINALITY");
            PalasRservadas.Add("USAGE");
            PalasRservadas.Add("DOMAIN");
            PalasRservadas.Add("OUT");
            PalasRservadas.Add("USING");
            PalasRservadas.Add("DYNAMIC");
            PalasRservadas.Add("OUTPUT");
            PalasRservadas.Add("VALUE");
            PalasRservadas.Add("EACH");
            PalasRservadas.Add("PAD");
            PalasRservadas.Add("VARCHAR");
            PalasRservadas.Add("END");
            PalasRservadas.Add("PARAMETER");
            PalasRservadas.Add("VARIABLE");
            PalasRservadas.Add("EQUALS");
            PalasRservadas.Add("PARAMETERS");
            PalasRservadas.Add("WHENEVER");
            PalasRservadas.Add("EVERY");
            PalasRservadas.Add("PARTIAL");
            PalasRservadas.Add("WITHOUT");
            PalasRservadas.Add("EXCEPTION");
            PalasRservadas.Add("PATH");
            PalasRservadas.Add("WORK");
            PalasRservadas.Add("EXTERNAL");
            PalasRservadas.Add("POSTFIX");
            PalasRservadas.Add("WRITE");
            PalasRservadas.Add("FALSE");
            PalasRservadas.Add("PREFIX");
            PalasRservadas.Add("YEAR");
            PalasRservadas.Add("FIRST");
            PalasRservadas.Add("PREORDER");
            PalasRservadas.Add("ZONE");
            PalasRservadas.Add("FLOAT");
            PalasRservadas.Add("PREPARE");
            PalasRservadas.Add("ADD");
            PalasRservadas.Add("DATETIME");
            PalasRservadas.Add("#REGION");
        }
        public void AgregaPalabraReservada(string palabra)
        {
            if (PalasRservadas == null)
                CargaPalabrasReservadas();
            PalasRservadas.Add(palabra);
        }
    }
}
