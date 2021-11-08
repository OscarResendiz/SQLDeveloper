using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AnalizadorLexico;
//using AnalizadorLexico;
namespace Inteliences
{
    public partial class CSQLTextAnaliser : CBaseTextAnaliser
    {
        private List<Compiler.Lexer.Lexema> TablasINternas;
        private Dictionary<Compiler.Lexer.Lexema, List<Compiler.Lexer.Lexema>> CamposTablas;
        private CAliasManager AliasManager;
        private List<string> Sincronizadores;
        /// <summary>
        /// crea la lista de sincronizadores.
        /// un sincronizador es una palabra clave que va a indicar que accion tomar 
        /// </summary>
        private void InicializaSincronizadores()
        {
            if (Sincronizadores != null)
                return;
            Sincronizadores = new List<string>();
            Sincronizadores.Add("SELECT");
            Sincronizadores.Add("FROM");
            Sincronizadores.Add("WHERE");
            Sincronizadores.Add("ON");
            Sincronizadores.Add("JOIN");
            Sincronizadores.Add("INSERT");
            Sincronizadores.Add("UPDATE");
            Sincronizadores.Add("SET");
            Sincronizadores.Add("DELETE");
            Sincronizadores.Add("AND");
            Sincronizadores.Add("OR");
        }
        public CSQLTextAnaliser()
        {
            AliasManager = new CAliasManager();
            InicializaSincronizadores();
            InitializeComponent();
        }

        public CSQLTextAnaliser(IContainer container)
        {
            AliasManager = new CAliasManager();
            container.Add(this);
            InicializaSincronizadores();
            InitializeComponent();
        }
        private void BuscaVariables()
        {
            //busca variables y tablas temporales
            foreach (Compiler.Lexer.Lexema lex in lecxer1)
            {
                switch (lex.Tipo)
                {
                    case Compiler.Lexer.LEXTIPE.SQLVARIABLE:
                        AddSimbol(new CSimbolo()
                        {
                            DeclarationLinea = lex.PosicionInicial.Linea,
                            Tipo = TIPO_SIMBOLO.VARIABLE,
                            Name = lex.Texto
                        }
                        );
                        break;
                    case Compiler.Lexer.LEXTIPE.TABLATEMPORAL:
                        AgregaTabla(lex);                        
                        break;
                }
            }
        }
        //esta funcion se llama cada vez que hay que analisar la cadena
        protected override void AnalizaTexto(string texto)
        {
            CamposTablas = new Dictionary<Compiler.Lexer.Lexema, List<Compiler.Lexer.Lexema>>();
            lecxer1.Cadena = texto;
            BuscaVariables();
            BuscaTablas();

        }
        /// <summary>
        /// regresa true si s es un sincronizador
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool EsSincronizador(string s)
        {
            foreach (string s2 in Sincronizadores)
            {
                if (s2 == s.ToUpper().Trim())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// regresa la palabra clave de sincronizacion inmediatamente anterior a offset
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>            
        public override string GetSincronizadorAnterior(int offset)
        {
            lecxer1.Cadena = TCodigo.Text;
            //me traigo la posicion del item
            int pos = lecxer1.GetIndexPos(offset);
            int posOriginal = pos;
            if (pos == -1)
                return ""; //no hay nada
            do
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema lex = lecxer1[pos];
                if (lex.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA)
                {
                    //solo too en cuenta palabras reservadas
                    if (EsSincronizador(lex.Texto))
                    {
                        //regreso la palabra reservada
                        if (CompruebaSintaxis(lex, posOriginal))
                            return lex.PalabraReservada.ToString();
                        else
                            return "";
                    }
                }
                pos--;
            }
            while (pos >= 0);
            //no encontre nada
            return "";
        }
        /// <summary>
        /// comprueba si la sintaxis del sincronizador es correcta hasta el punto de la posicion actual
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxis(Compiler.Lexer.Lexema lex, int posActual)
        {
            switch (lex.PalabraReservada)
            {
                case Compiler.Lexer.PALABRASRESERVADAS.FROM:
                    return CompruebaSintaxisFrom(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.JOIN:
                    return CompruebaSintaxisJoin(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.DELETE:
                    return CompruebaSintaxisDelete(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.UPDATE:
                    return CompruebaSintaxisUpdate(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.SET:
                    return CompruebaSintaxisSet(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.WHERE:
                    return CompruebaSintaxisWhere(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.AND:
                    return CompruebaSintaxisAnd(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.OR:
                    return CompruebaSintaxisOr(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.ON:
                    return CompruebaSintaxisOn(lex, posActual);
                case Compiler.Lexer.PALABRASRESERVADAS.SELECT:
                    return CompruebaSintaxisSelect(lex, posActual);
            }
            return false;
        }
        #region From
        /// <summary>
        /// verifica si la sintaxis de la palabra reservada from
        /// las sintaxis validas son
        /// a) from 
        /// b) from DefinicionTabla,
        /// c) from DefinicionTabla DefinicionNOLOCK,
        /// d) from DefinicionTabla DefiniconAlias,
        /// e) from DefinicionTabla DefiniconAlias DefinicionNOLOCK,
        /// donde DefinicionTabla puede ser
        /// 1. ID                   => tabla
        /// 2. ID.ID                => user.tabla
        /// 3. ID.ID.ID             => DataBase.User.Tabla
        /// 4. [ID]                 => [Tabla]
        /// 5. ID.[ID]              => User.[Tabla]
        /// 6. ID.ID.[ID]           => DataBase.User.[Tabla]
        /// 7. SQLVariable          => tabla variable @ombre
        /// 8. TABLATEMPORAL        => tabla temporal #tabla
        /// DefinicionNOLOCK puede ser
        /// 1. NOLOCK
        /// 2. (NOLOCK)
        /// 3. WITH NOLOCK
        /// 4. WITH(NOLOCK)
        /// DefiniconAlias puede ser
        /// 1. ID
        /// </summary>
        /// <returns></returns>
        private bool CompruebaSintaxisFrom(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es from u una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.COMA)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.FROM)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region Join
        /// <summary>
        /// comprueba la sintaxis de la palabra reservada join
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisJoin(Compiler.Lexer.Lexema lex, int posActual)
        {
            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.JOIN)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region Delete
        /// <summary>
        /// comprueba la sintaxis de delete
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisDelete(Compiler.Lexer.Lexema lex, int posActual)
        {
            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.DELETE)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region Update
        /// <summary>
        /// comprueba la sintaxis de update
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisUpdate(Compiler.Lexer.Lexema lex, int posActual)
        {
            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.UPDATE)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region SET
        /// <summary>
        /// comprueba la sintaxis de SET
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisSet(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es set o una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (CompruebaOperadorCondicional(obj.Tipo))
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.COMA)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.SET)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region Where
        /// <summary>
        /// comprueba sintaxis where
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisWhere(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es set o una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (CompruebaOperadorCondicional(obj.Tipo))
                    return true;
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.WHERE)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region AND
        /// <summary>
        /// comprueba la sintaxis de AND
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisAnd(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es set o una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (CompruebaOperadorCondicional(obj.Tipo))
                    return true;
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.AND)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region OR
        /// <summary>
        /// comprueba la sintaxis de OR
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisOr(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es set o una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (CompruebaOperadorCondicional(obj.Tipo))
                    return true;
                if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.OR)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region ON
        /// <summary>
        /// comprueba la sintaxis de ON
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisOn(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es set o una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (CompruebaOperadorCondicional(obj.Tipo))
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.ON)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        #endregion
        #region Select
        /// <summary>
        /// comprueba la sintaxis de select
        /// </summary>
        /// <param name="lex"></param>
        /// <param name="posActual"></param>
        /// <returns></returns>
        private bool CompruebaSintaxisSelect(Compiler.Lexer.Lexema lex, int posActual)
        {
            //en realidad solo nececito saber si el item anterior es set o una coma (ignorando separadores)
            //declaro una pila donde voy a utilizar el metodo de reduccion
            //            List<Compiler.Lexer.Lexema> pila = new List<Compiler.Lexer.Lexema>();

            int pos = lecxer1.GetIndexPos(lex.PosicionInicial.PosicionGeneral);
            while (pos <= posActual)
            {
                //me traigo el lexema
                Compiler.Lexer.Lexema obj = lecxer1[posActual];
                if (CompruebaOperadorCondicional(obj.Tipo))
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.COMA)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && obj.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.SELECT)
                    return true;
                else if (obj.Tipo == Compiler.Lexer.LEXTIPE.SEPARADOR || obj.Tipo == Compiler.Lexer.LEXTIPE.COMENTARIO || obj.Tipo == Compiler.Lexer.LEXTIPE.FINLINEA)
                    posActual--;
                else
                    return false;

            }
            return false;
        }
        /// <summary>
        /// regresa true si el operador es de tipo asignacion o condicional
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private bool CompruebaOperadorCondicional(Compiler.Lexer.LEXTIPE Tipo)
        {
            switch (Tipo)
            {
                case Compiler.Lexer.LEXTIPE.ASIGNACION:
                    return true;
                case Compiler.Lexer.LEXTIPE.DIFERENTESQL:
                    return true;
                case Compiler.Lexer.LEXTIPE.DIFERENTEC:
                    return true;
                case Compiler.Lexer.LEXTIPE.MAYOROIGUALQUE:
                    return true;
                case Compiler.Lexer.LEXTIPE.MAYORQUE:
                    return true;
                case Compiler.Lexer.LEXTIPE.MENOROIGUALQUE:
                    return true;
                case Compiler.Lexer.LEXTIPE.MENORQUE:
                    return true;
            }
            return false;
        }
        #endregion
        #region Busqueda de tablas temporales y variables tabla
        /// <summary>
        /// agrega el simbolo a la tabla de simbolos y una referencia a las tablas
        /// </summary>
        /// <param name="lex"></param>
        private void AgregaTabla(Compiler.Lexer.Lexema lex)
        {
            TablasINternas.Add(lex);
            AddSimbol(new CSimbolo()
            {
                DeclarationLinea = lex.PosicionInicial.Linea,
                Name = lex.Texto,
                Tipo = TIPO_SIMBOLO.TABLA
            }
                );
        }
        /// <summary>
        /// Busca las tablas que hay en el documehto. Basicamente se toman las tablas temporales y las tablas variables
        /// </summary>
        protected override void BuscaTablas()
        {
            TablasINternas = new List<Compiler.Lexer.Lexema>();
            Compiler.Lexer.Lexema lex = null;
            //las tablas temporales son faciles de reconocer
            lecxer1.ReiniciaCursor();
            do
            {
                lex = lecxer1.BuscaSiguienteLexema(Compiler.Lexer.LEXTIPE.TABLATEMPORAL);
                if (lex == null)
                    break;
                AgregaTabla(lex);
            } while (lecxer1.CursorFinal == false); //mientras no llegue al final
            //ahora busco las tablas variable. su sintaxis es DECLARE @NOMBRE TABLE
            lecxer1.ReiniciaCursor();
            lex = null;
            //me traigo la palabra reservada declare
            while (lecxer1.BuscaSiguientePalabraReservada(Compiler.Lexer.PALABRASRESERVADAS.DECLARE) != null)
            {
                //me traigo el nombre de la variable
                lex = lecxer1.DameSiguienteLexemaUtil();
                //me traigo el tipo
                Compiler.Lexer.Lexema lex2 = lecxer1.DameSiguienteLexemaUtil();
                //veo si hay datos
                if (lex == null || lex2 == null)
                    continue;

                if (lex.Tipo != Compiler.Lexer.LEXTIPE.SQLVARIABLE)
                    continue;
                if (lex2.Tipo != Compiler.Lexer.LEXTIPE.PALABRARESERVADA || lex2.PalabraReservada != Compiler.Lexer.PALABRASRESERVADAS.TABLE)
                    continue;
                //paso las pruebas, por lo que lo agrego
                AgregaTabla(lex);

            }
            //ahora agrego los alias
            BuscaAliasTabla();
        }
        #endregion
        #region Alias
        /// <summary>
        ///  busca los alias que se les asignan a las tablas
        /// </summary>
        private void BuscaAliasTabla()
        {
            // las sintaxis a buscar son
            // 1. from  DefiniconTabla DefinicionAlias 
            // 3. from DefiniconListaTablas, DefiniconTabla | DefinicionAlias
            // 5. join DefiniconTabla | DefinicionAlias
            // donde
            // DefinicionAlias 
            //      1.  ID
            //      2. [ID]
            //      3.  AS ID
            //      4.  AS [ID]
            // DefiniconListaTablas
            //      1. DefiniconTablaCompleta,  =>se repite varias veces
            // DefiniconTablaCompleta
            //      1. DefiniconTabla 
            //      2. DefiniconTabla DefinicionAlias
            //      3. DefiniconTabla DefinicionNOLOCK
            //      4. DefiniconTabla DefinicionAlias DefinicionNOLOCK
            //  DefiniconTabla
            //      1. ID           => TableName
            //      2. ID.ID        => UserName.TableName
            //      3. ID.ID.ID     => DataBase.UserName.TableName
            // DefinicionNOLOCK puede ser
            //      1. NOLOCK
            //      2. (NOLOCK)
            //      3. WITH NOLOCK
            //      4. WITH(NOLOCK)
            BuscaAliasFrom();
            BuscaAliasJoin();
        }
        /// <summary>
        /// busca las definiciones de from
        /// </summary>
        private void BuscaAliasFrom()
        {
            lecxer1.ReiniciaCursor();
            //busco todos los from
            while (lecxer1.BuscaSiguientePalabraReservada(Compiler.Lexer.PALABRASRESERVADAS.FROM) != null)
            {
                bool continuar=false;
                do
                {
                    BuscaDefinicionTabla();
                    Compiler.Lexer.Lexema tmp = lecxer1.DameSiguienteLexemaUtil();
                    if (tmp == null)
                        break;
                    if (tmp.Tipo == Compiler.Lexer.LEXTIPE.COMA)
                        continuar = true;
                    else
                        lecxer1.DesechaLexema();
                } while (continuar);
            }
        }
        /// <summary>
        /// busca las definiciones de join
        /// </summary>
        private void BuscaAliasJoin()
        {
            lecxer1.ReiniciaCursor();
            //busco todos los from
            while (lecxer1.BuscaSiguientePalabraReservada(Compiler.Lexer.PALABRASRESERVADAS.JOIN) != null)
            {
                BuscaDefinicionTabla();
            }
        }
        /// <summary>
        /// busca las definiciones de tablas
        ///  DefiniconTabla
        ///      1. ID           => TableName
        ///      2. ID.ID        => UserName.TableName
        ///      3. ID.ID.ID     => DataBase.UserName.TableName
        /// 
        /// </summary>

        private void BuscaDefinicionTabla()
        {
            Compiler.Lexer.Lexema tabla = null;
            Compiler.Lexer.Lexema tmp = null;
            //busco el nombre de latbla suponiendo que viene en alguna de las tres formas
            //asumo que es la forma ID
            tabla = lecxer1.DameSiguienteLexemaUtil();
            if (tabla == null)
                return;
            tmp = lecxer1.DameSiguienteLexemaUtil();
            if (tmp == null)
                return;
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PUNTO)
            {
                //asumo que es la forma ID.ID
                tabla = lecxer1.DameSiguienteLexemaUtil();
                if (tabla == null)
                    return;
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
                if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PUNTO)
                {
                    //asumo que es la forma ID.ID.ID
                    tabla = lecxer1.DameSiguienteLexemaUtil();
                    if (tabla == null)
                        return;
                }
                else
                {
                    lecxer1.DesechaLexema();
                }
            }
            else
            {
                lecxer1.DesechaLexema();
            }
            //tmp = lecxer1.DameSiguienteLexemaUtil();
            //checo si es alias
            BuscaDefinicionAlias(tabla);
            BuscaDefinicionNOLOCK();
        }
        /// <summary>
        /// busca la definicion de alias
        /// DefinicionAlias 
        ///      1.  ID
        ///      2. [ID]
        ///      3.  AS ID
        ///      4.  AS [ID]
        /// 
        /// </summary>
        /// <param name="tabla"></param>
        private void BuscaDefinicionAlias(Compiler.Lexer.Lexema tabla)
        {
            Compiler.Lexer.Lexema tmp = null;
            tmp = lecxer1.DameSiguienteLexemaUtil();
            if (tmp == null)
                return;
            #region es de la form ID
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.IDENTIFICADOR)
            {
                //encontre el alias
                AgregaAlias(tabla, tmp);
                return;
            }
            #endregion
            #region contiene AS
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && tmp.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.AS)
            {
                //me traigo el sigiente lexema
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
            }
            #endregion
            #region es de la forma [ID]
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.CORCHETEABRE)
            {
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
                if (tmp.Tipo == Compiler.Lexer.LEXTIPE.IDENTIFICADOR)
                {
                    //encontre el alias
                    AgregaAlias(tabla, tmp);
                }
                //descargo el corchete que cierra
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
                return;
            }
            #endregion
            //si llegue aqi no identifique nada y tengo que regresar el lexema
            lecxer1.DesechaLexema();
        }
        /// <summary>
        /// agrega el alias a lla lista de tablas
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="alias"></param>
        private void AgregaAlias(Compiler.Lexer.Lexema tabla, Compiler.Lexer.Lexema alias)
        {
            alias.Tipo = Compiler.Lexer.LEXTIPE.ALIASTABLA;
            AliasManager.Add(tabla, alias);
            AgregaTabla(alias);
        }
        #endregion
        #region NOLOCK
        /// <summary>
        /// saca de la cadena la definicion de NOLOCK
        /// DefinicionNOLOCK puede ser
        ///      1. NOLOCK
        ///      2. (NOLOCK)
        ///      3. WITH NOLOCK
        ///      4. WITH(NOLOCK)
        /// 
        /// </summary>
        private void BuscaDefinicionNOLOCK()
        {
            bool parentesis = false;
            Compiler.Lexer.Lexema tmp = null;
            tmp = lecxer1.DameSiguienteLexemaUtil();
            if (tmp == null)
                return;
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && tmp.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.WITH)
            {
                //extraigo el poximo lexema
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;

            }
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PARENTESISABRE)
            {
                parentesis = true;
                //posiblemente sea (NOLOCK)
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
            }
            if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && tmp.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.NOLOCK)
            {
                //desecho el parentesis
                lecxer1.DameSiguienteLexemaUtil();
            }
            else
            {
                //no era, por lo que rereso los dos itmns
                lecxer1.DesechaLexema();
                if (parentesis)
                    lecxer1.DesechaLexema();
                return;
            }
            if (parentesis)
                tmp = lecxer1.DameSiguienteLexemaUtil();
        }
        #endregion
        protected override void BuscaCamposTablas()
        {
            //List<string> campos = new List<string>();
            //recorro todas la tablas para ir extrayendo sus campos
            if (TablasINternas == null)
                return;
            foreach(Compiler.Lexer.Lexema obj in TablasINternas)
            {
                BuscaCamposTablas(obj);                
            }
        }
        /// <summary>
        /// busca los capos de la tabla
        /// </summary>
        /// <param name="tabla"></param>
        protected void BuscaCamposTablas(Compiler.Lexer.Lexema tabla)
        {
            //dependiendo del tipo de tabl hago la busqueda
            switch(tabla.Tipo)
            {
                case Compiler.Lexer.LEXTIPE.ALIASTABLA:
                    BuscaCamposAlias(tabla);
                    break;
                case Compiler.Lexer.LEXTIPE.TABLATEMPORAL:
                    BuscaCamposTablaTemporal(tabla);
                    break;
                case Compiler.Lexer.LEXTIPE.SQLVARIABLE:
                    BuscaCamposTablaVariable(tabla);
                    break;
            }
        }
        /// <summary>
        /// extrae los campos del codigo
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        private List<Compiler.Lexer.Lexema> ExtraeCamposCodigo(Compiler.Lexer.Lexema tabla)
        {
            List<Compiler.Lexer.Lexema> campos = new List<Compiler.Lexer.Lexema>();
            Compiler.Lexer.Lexema tmp=null;
            //descarto el parentesis
            lecxer1.DameSiguienteLexemaUtil();
            //recorro los demas items hasta encontrar el final de la tabla (que es el parentesis que cierra)
            bool continuar = true;
            do
            {
                //me traigo el nombre del campo
                tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return campos;
                if (tmp.Tipo != Compiler.Lexer.LEXTIPE.IDENTIFICADOR)
                {
                    //algo paso y se descontrolo el seguimiento
                    break; //rompo el siclo
                }
                campos.Add(tmp);
                int nparentesis = 0; //indica el numero de parentesis encontrados abierto. esto es para valancearlos
                //desecho todos los lexcemas hasta encontrar el parentesis o el )
                do
                {
                    tmp = lecxer1.DameSiguienteLexemaUtil();
                    if (tmp == null)
                        return campos;
                    if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PARENTESISCIERRA)
                    {
                        if (nparentesis == 0)
                        {
                            //no hay parenteis que cuadrar, por lo que llegue al final de la tabla
                            //rompo los siclos
                            continuar = false;
                            break;
                        }
                        else
                        {
                            nparentesis--; //cierro el parentesis
                        }
                    }
                    if (tmp.Tipo == Compiler.Lexer.LEXTIPE.COMA)
                    {
                        //veo si los parestesis estan alineados porque puede que la coma este dentro de ellos
                        if (nparentesis == 0)
                        {
                            //rompo el siclo de que encontre un campo
                            break;
                        }
                    }
                    if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PARENTESISABRE)
                    {
                        nparentesis++;
                    }
                } while (true);

                if (continuar == false)
                    break;

            } while (continuar);
            return campos;

        }
        /// <summary>
        /// Busca la definicion de la tabla en el codigo y extrae sus campos
        /// </summary>
        /// <param name="tabla"></param>
        private void BuscaCamposTablaVariable(Compiler.Lexer.Lexema tabla)
        {
            lecxer1.ReiniciaCursor();
            List<Compiler.Lexer.Lexema> campos = new List<Compiler.Lexer.Lexema>();
            //recorro todas las declaraciones e variables
            while (lecxer1.BuscaSiguientePalabraReservada(Compiler.Lexer.PALABRASRESERVADAS.DECLARE) != null)
            {
                //lo que sigue es el nombre de la tabla
                Compiler.Lexer.Lexema tmp = lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
                if (tmp.Texto == tabla.Texto)
                {
                    //ya encontre la  definicion de la tabla
                    //el siguiente lexema que sigue es la palabra reservada TABLE
                    tmp = lecxer1.DameSiguienteLexemaUtil();
                    if (tmp == null)
                        return;
                    if (tmp.Tipo == Compiler.Lexer.LEXTIPE.PALABRARESERVADA && tmp.PalabraReservada == Compiler.Lexer.PALABRASRESERVADAS.TABLE)
                    {
                        //ya tengo la confirmacion al 100% que es la declaracion de una tabla
                        //lo que se espera es el parentesis y la definicionde los campos
                        campos = ExtraeCamposCodigo(tabla);
                        //agrego los campos a la lista de campos
                        foreach (Compiler.Lexer.Lexema campo in campos)
                        {
                            AgregaCampo(tabla, campo);
                        }
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// busco la definicion de la tabla temporal.
        /// </summary>
        /// <param name="tabla"></param>
        private void BuscaCamposTablaTemporal(Compiler.Lexer.Lexema tabla)
        {
                        lecxer1.ReiniciaCursor();
            List<Compiler.Lexer.Lexema> campos = new List<Compiler.Lexer.Lexema>();
            //recorro todas las declaraciones e variables
            while (lecxer1.BuscaSiguientePalabraReservada(Compiler.Lexer.PALABRASRESERVADAS.CREATE) != null)
            {
                Compiler.Lexer.Lexema tmp=lecxer1.DameSiguienteLexemaUtil();
                if (tmp == null)
                    return;
                if(tmp.Tipo== Compiler.Lexer.LEXTIPE.PALABRARESERVADA && tmp.PalabraReservada== Compiler.Lexer.PALABRASRESERVADAS.TABLE)
                {
                    //me traigo el nombre de la tabla
                    tmp = lecxer1.DameSiguienteLexemaUtil();
                    if (tmp == null)
                        return;
                    if(tmp.Texto==tabla.Texto)
                    {
                        //es la tabla. Extraigo los campos
                        campos = ExtraeCamposCodigo(tabla);
                        //agrego los campos a la lista de campos
                        foreach (Compiler.Lexer.Lexema campo in campos)
                        {
                            AgregaCampo(tabla, campo);
                        }
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// busca los ccampos de los alias
        /// pueden haber varias tablas asociadas a un alias y puede haber alias a tablas temporales y tablas variables
        /// </summary>
        /// <param name="tabla"></param>
        private void BuscaCamposAlias(Compiler.Lexer.Lexema tabla)
        {
            //me traigo toda la lista de tablas que pertenecen al alias
            List<Compiler.Lexer.Lexema> l = AliasManager.DameTablaOrigen(tabla.Texto);
            //recorro la lista
            foreach (Compiler.Lexer.Lexema obj in l)
            {
                bool encontrado = false;
                //veo si la tabla esta dentro de la lista de tablas encontradas
                int x = 0;
                //foreach (KeyValuePair<Compiler.Lexer.Lexema, List<Compiler.Lexer.Lexema>> tbl in CamposTablas)
                while (x < CamposTablas.Count())
                {
                    KeyValuePair<Compiler.Lexer.Lexema, List<Compiler.Lexer.Lexema>> tbl =CamposTablas.ElementAt(x);
                    x++;
                    if (tbl.Key.Texto == obj.Texto)
                    {
                        encontrado = true;
                        //si lo encontre, por lo que agrego sus datos a la lista de objetos
                        //ahora recooro los campos
                        List<Compiler.Lexer.Lexema> campos = tbl.Value;
                        foreach (Compiler.Lexer.Lexema cmp in campos)
                        {
                            AgregaCampo(tabla, cmp);
                        }
                    }

                }
                if(encontrado==false)
                {
                    //no se encuentra en la lista de objetos definidos en el codigo
                    //posiblemente sea de la base de datos, por lo que tengo que buscarla
                    if (DbBuffer == null)
                        return; //no hay nada que pueda hacer
                    //si tiene separadores de puntos, obtengo el ultimo que se supone es el nomnre de la tabla
                    string nt = obj.Texto;
                    if (obj.Texto.Contains("."))
                    {
                        string[] lnt = nt.Split('.');
                        nt = lnt[lnt.Length-1];
                    }
                    List<string> lc = DbBuffer.GetFields(nt);
                    foreach (string s in lc)
                    {
                        //aqui agrego el simbolo directamente
                        AddSimbol(
                            new CSimbolo()
                            {
                                DeclarationLinea = tabla.PosicionInicial.Linea,
                                Tipo = TIPO_SIMBOLO.CAMPO,
                                Name = tabla.Texto + "." + s
                            }
                            );
                    }
                }
            }
        }
        /// <summary>
        /// agrega la definicion de campo a la tabla de variables y al registro de tablas
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="campo"></param>
        private void AgregaCampo(Compiler.Lexer.Lexema tabla, Compiler.Lexer.Lexema campo)
        {
            //agrego el symbolo
            AddSimbol(
                new CSimbolo()
                {
                    DeclarationLinea = tabla.PosicionInicial.Linea,
                    Tipo = TIPO_SIMBOLO.CAMPO,
                    Name = tabla.Texto + "." + campo.Texto
                }
                );
            AddSimbol(
                new CSimbolo()
                {
                    DeclarationLinea = tabla.PosicionInicial.Linea,
                    Tipo = TIPO_SIMBOLO.CAMPO,
                    Name = campo.Texto
                }
                );
            //agrego la definicion del campo en la tabla
            //me traigo el registro de la tbla
            int x = 0;
            //            foreach (KeyValuePair<Compiler.Lexer.Lexema, List<Compiler.Lexer.Lexema>> tbl in CamposTablas)
            while (x < CamposTablas.Count())
            {
                KeyValuePair<Compiler.Lexer.Lexema, List<Compiler.Lexer.Lexema>> tbl =CamposTablas.ElementAt(x);
                x++;
                if(tbl.Key.Texto==tabla.Texto)
                {
                    //ahora recooro los campos
                    List<Compiler.Lexer.Lexema> campos = tbl.Value;
                    foreach(Compiler.Lexer.Lexema cmp in campos)
                    {
                        if(cmp.Texto==campo.Texto)
                        {
                            //ya esta, por lo que ya no hago nada
                            return;
                        }
                    }
                    //no esta el campo en la tabla
                    // lo agrego
                    campos.Add(campo);
                    return;
                }
            }
            //no esta la tabla
            List<Compiler.Lexer.Lexema> l=new List<Compiler.Lexer.Lexema>();
            l.Add(campo);
            CamposTablas.Add(tabla, l);
        }
    }
}