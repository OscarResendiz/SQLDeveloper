using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor.Document;
using System.Data;
using System.Windows.Forms;

namespace TextEditor
{
    /*
    //clase encarghada de analizar el texto y buscar todos los bloques colapsables
    los tipos de bloques que va a anlizar son:
    Comentarios definicods por /* y */
    /*
    blque begin  definidos por begin y end
    bloque case definido por case y end
    llabes  definido por { y }
    parentesis definidos por ( y )
    corchetes definidos por [ y ]
    definie definido por #define y #enddefine
    define2 definido por --define y --enddefine
    cadenas definicdas por ' y '
*/
    public delegate void AnalisisTerminadoEvent(List<CBlock> lista);
    public partial class CBlockAnaliser : Component
    {
        #region Variables internas
        string Buffer;
        int BufferPos;
        private List<string> Secuencias;
        private List<CBlock> Lista;
        private List<CTocken> Pila;
        private List<CBloqueMach> ListaMatch;
        private int TotalLineas;
        private int LineaActual;
        CNodo Arbol;

        DataSet dataSet1;
        DataTable Bloques;
        public event AnalisisTerminadoEvent OnAnalisisTerminado;
        private List<string>Lineas;
        string Cadena;
        #endregion
        #region codigo generado por VS
        public CBlockAnaliser()
        {
            InicializaDatos();
            InitializeComponent();

        }

        public CBlockAnaliser(IContainer container)
        {
            InicializaDatos();
            container.Add(this);

            InitializeComponent();
        }
        #endregion
        #region Propiedades
        private string NombreArchivo
        {
            get
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\Colores") == false)
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Colores");
                return Application.StartupPath + "\\Colores\\bloques.xml";
            }
        }
        public IDocument Document
        {
            get;
            set;
        }
        #endregion
        #region Funciones publicas
        public void  Analiza()
        {
            if (BKAnaliser.IsBusy)
                return;
            Lineas=new List<string>();
            Cadena = Document.TextContent;
            for (int linea = 0; linea < Document.TotalNumberOfLines; linea++)
            {
                string buffer = Document.GetText(Document.GetLineSegment(linea)).ToLower();// +"\n";
                Lineas.Add(buffer);
            }

            BKAnaliser.RunWorkerAsync();
        }
        public string AnalizaTabuladores()
        {
            //primero quito los espacios
            Document.TextContent = QuitaEspacios(Document.TextContent);
            //iniciaizo el analisis
            //Analiza();
            Lineas = new List<string>();
            Cadena = Document.TextContent;
            for (int linea = 0; linea < Document.TotalNumberOfLines; linea++)
            {
                string buffer = Document.GetText(Document.GetLineSegment(linea)).ToLower();// +"\n";
                Lineas.Add(buffer);
            }
            Algoritmo1();
            IncializaAnalisis();
            //lleno la pila de tockens
            LLenaPila();
            //separo los datos de la pila para ir llenando la lista
            int inicios, finales;
            inicios = 0;
            //hace esto mientras existan elemntos en la pila
            do
            {
                if (Pila.Count == 1)
                {
                    //ya no hay pares en la pila
                    //elimino el dato
                    Pila.RemoveAt(0);
                }
                else
                {
                    //recorro toda la pila para buscar el match
                    bool encontrado = false;
                    for (finales = inicios + 1; finales < Pila.Count; finales++)
                    {
                        CTocken obj1 = Pila[inicios];
                        CTocken obj2 = Pila[finales];
                        if (HaceMatch(obj1, obj2))
                        {
                            //si hacen match, por lo que creo el bloque
                            AgregaBloque(obj1, obj2);
                            //ahora los elimino de la pila
                            if (Pila.Count > finales)
                                Pila.RemoveAt(finales);
                            if (Pila.Count > inicios)
                                Pila.RemoveAt(inicios);
                            //reinicio el proceso
                            inicios = 0;
                            encontrado = true;
                            break;
                        }
                        else
                        {
                            if (obj2!=null && obj2.Opener)
                            {
                                //es un opener, por lo que lo pongo como inicio para que busque su match
                                inicios = finales;
                            }
                        }
                    }
                    if (encontrado == false)
                    {
                        //no encontre ningun bloque con el inico, por lo que lo elimino y reinicio
                        //en este momento hay que tener en cuenta que estoy analizando el inico mas 
                        //profundo de la lista
                        if (Pila.Count > 0)
                        {
                            Pila.RemoveAt(inicios);
                            inicios = 0;
                        }
                    }
                }
            }
            while (Pila.Count > 0);
            //ya termine, de analizar, ahora voy aplicando los tabuladores como corresponden
            return AplicaTabuladores();
        }
        #endregion
        #region Funciones internas
        private void InicializaDatos()
        {
            //inicializa las secuencias a tomar en cuenta
            Arbol = new CNodo();
            Arbol.Raiz = true;
            //inicializo la lista de match
            ListaMatch = new List<CBloqueMach>();
            DataSet ds = new DataSet();
            try
            {
                if (System.IO.File.Exists(NombreArchivo) == false)
                {
                    //si no existe el archivo de configuracion, lo crea
                    CargaValoresDefault();
                }
                ds.ReadXml(NombreArchivo);
                DataTable dt = ds.Tables["Bloques"];
                foreach (DataRow dr in dt.Rows)
                {
                    string Nombre = dr["Nombre"].ToString();
                    string InicioMatch = dr["InicioMatch"].ToString();
                    string FinMatch = dr["FinMatch"].ToString();
                    string TextoRemplazo = dr["TextoRemplazo"].ToString();
                    bool UseTextLine = bool.Parse(dr["UseTextLine"].ToString());
                    int MinimumLength = int.Parse(dr["MinimumLength"].ToString());
                    bool ApliaTabulador = bool.Parse(dr["ApliaTabulador"].ToString());
                    AddBloque(InicioMatch, FinMatch, TextoRemplazo, UseTextLine, MinimumLength, ApliaTabulador);
                }
            }
            catch (System.Exception)
            {
                return;
            }

        }
        private void CargaValoresDefault()
        {
            IncializaTabla();
            //inicializa valores si el archivo no existe
            AddBloqueFile("comentarios", "/*", "*/", "/*..*/");
            AddBloqueFile("begin", "begin ", "end ", "Begin...End", false, 0, true);
            AddBloqueFile("case", "case ", "break ", "Case..Break", false, 0, true);
            AddBloqueFile("case2", "case ", "end ", "Case..End", false, 0, true);
            AddBloqueFile("llaves", "{", "}", "{..}", false, 0, true);
            AddBloqueFile("Parentesis", "(", ")", "(..)", false, 50, true);
            AddBloqueFile("corchetes", "[", "]", "[..]");
            AddBloqueFile("Region1", "#region ", "#endregion ", "", true);
            AddBloqueFile("Region2", "--#region ", "--#endregion ", "", true);
            AddBloqueFile("Transaccion1", "BEGIN TRANSACTION ", "COMMIT TRANSACTION ", "", true, 0, false);
            AddBloqueFile("NOCOUNT", "SET NOCOUNT ON", "SET NOCOUNT OFF", "NOCOUNT", false, 0, false);
            AddBloqueFile("create", "create procedure", "go", "NOCOUNT", true, 0, false);
            AddBloqueFile("Transacciones", "BEGIN TRAN", "COMMIT TRAN", "Transaccion", false, 0, false);
            dataSet1.WriteXml(NombreArchivo);
        }
        private void IncializaAnalisis()
        {
            if (Lista == null)
                Lista = new List<CBlock>();
            else
                Lista.Clear();
            if (Pila == null)
                Pila = new List<CTocken>();
            else
                Pila.Clear();
            LineaActual = -1; //no tengo ninguna liena
            TotalLineas = Document.TotalNumberOfLines;
            Buffer = "";
            BufferPos = 0;
        }
        private string QuitaComentariosSimples(string cadena)
        {
            int n = cadena.IndexOf("--");
            if (n > -1)
            {
                //si hay un comentario, pero veo si no es --#
                try
                {
                    if (cadena.Substring(n + 2, 1) == "#")
                    {
                        //si es por lo que regreso la cadena sin cambios
                        return cadena;
                    }
                }
                catch (System.Exception ex)
                {
                    return cadena;
                }
                //es solo un comentario simple, por lo que lo elimino de la cadena
                return cadena.Substring(0, n);
            }
            //no tiene comentarios.
            return cadena;
        }
        private void LLenaPila()
        {
            if (Lineas == null)
                return;
            //recorro todas las lineas del documento buscando los itemns
            for (int linea = 0; linea < Lineas.Count; linea++)
            {
                string buffer = QuitaComentariosSimples(Lineas[linea]) + "\n"; //QuitaComentariosSimples(Document.GetText(Document.GetLineSegment(linea)).ToLower()) + "\n";
                //recorro caracter por caracter buscando los tockens
                for (int i = 0; i < buffer.Length; i++)
                {
                    bool agregar = true;
                    CTocken obj = null;
                    obj = Arbol.Encuentra(buffer, i);
                    if (obj != null)
                    {
                        //antes e agregar la linea, verifico si es begin, case o end para evitar falsos positivos
                        if (obj.ValidarLetraINicial)
                        {
                            //veo si el caracter anterior es una letra
                            if (obj.X - 1 > 0)
                            {
                                //no esta al principio de la linea
                                if (char.IsLetter(buffer[obj.X - 1]))
                                {
                                    agregar = false;
                                }
                            }

                        }
                        if (agregar)
                        {
                            //le agrego la linea en la que lo encontre
                            obj.Y = linea;
                            Pila.Add(obj);
                        }
                        //me salto el resto de la cadena que compone el tocken
                        i += obj.Cadena.Trim().Length - 1;
                    }
                }
            }
        }
        private bool HaceMatch(CTocken obj1, CTocken obj2)
        {
            foreach (CBloqueMach obj in ListaMatch)
            {
                if (obj.HaceMatch(obj1, obj2))
                    return true;
            }
            return false;
        }
        private string AsignaCadena(CTocken obj1, CTocken obj2)
        {
            string buffer = Lineas[obj1.Y];// Document.GetText(Document.GetLineSegment(obj1.Y));
            //busco su bloque
            foreach (CBloqueMach obj in ListaMatch)
            {
                if (obj.HaceMatch(obj1, obj2))
                    return obj.GetCadena(obj1, obj2, buffer);
            }
            return "...";
        }
        private void AgregaBloque(CTocken inicio, CTocken final)
        {
            if (Lista == null)
                Lista = new List<CBlock>();
            CBlock obj = new CBlock();
            obj.Text = AsignaCadena(inicio, final);
            obj.Final = final.Posicion;
            obj.Inicio = inicio.Posicion;
            obj.AplicaTabulador = inicio.AplicaTabulador;
            if (obj.Text != "")
                Lista.Add(obj);
        }
        private string QuitaEspacios(string cadena)
        {
            string s2 = "";
            //quita los espacios en blanco que se encuentran al inicio de cada cadena
            //se paro la cadena en lineas
            string[] lista = cadena.Split('\n');
            //recorro cada linea y voy quitando los espacios en blanco que tiene al prinicipio
            foreach (string l in lista)
            {
                int pos = 0;
                //si es tabulador o espacio lo ignora
                int n = l.Length;
                while (pos < n && (l[pos] == ' ' || l[pos] == '\t'))
                {
                    pos++;
                }
                s2 += l.Substring(pos) + "\n";
            }
            return s2;
        }
        private string AplicaTabuladores()
        {
            //recorro todas las lineas para ir aplicando los tabuladores
            string cadena = "";
            int NTabuladores = 0;
            int linea = 0;
            List<string> cadenas = new List<string>();
            //inicializo el numero de lineas
            for (int i = 0; i < Document.TotalNumberOfLines; i++)
            {
                cadenas.Add(Document.GetText(Document.GetLineSegment(i)));
            }
            //se supone que los bloques estan en el orden en que aparecen en el documento
            foreach (CBlock obj in Lista)
            {
                //veo el tipo de bloque
                if (obj.AplicaTabulador)
                {
                    //recorro las lineas que corresponden al bloque
                    for (linea = obj.Inicio.Y + 1; linea < obj.Final.Y; linea++)
                    {
                        cadenas[linea] = "\t" + cadenas[linea];
                    }
                }
            }
            //ya termine de aplicar los tabuladores
            foreach (string s in cadenas)
            {
                cadena = cadena + s + "\n";
            }
            return cadena;
        }
        private void AddBloque(string inicio, string fin, string textoRemplazo, bool useTextLine = false, int minimumLength = 0, bool apliaTabulador = false)
        {
            //agrego el inicio al arbol
            Arbol.Add(inicio.ToLower(), true);
            //agrego el final al arbol
            Arbol.Add(fin.ToLower(), false);
            //lo agrego a la lista de matchs
            ListaMatch.Add(new CBloqueMach(inicio, fin, textoRemplazo, useTextLine, minimumLength, apliaTabulador));
        }
        private void IncializaTabla()
        {
            dataSet1 = new DataSet();
            Bloques = new DataTable();
            dataSet1.Tables.Add(Bloques);
            Bloques.TableName = "Bloques";
            // 
            // Bloques
            // 
            this.Bloques.Columns.Add("Nombre");
            this.Bloques.Columns.Add("InicioMatch");
            this.Bloques.Columns.Add("FinMatch");
            this.Bloques.Columns.Add("TextoRemplazo");
            this.Bloques.Columns.Add("UseTextLine", typeof(bool));
            this.Bloques.Columns.Add("MinimumLength", typeof(int));
            this.Bloques.Columns.Add("ApliaTabulador", typeof(bool));
        }
        private void AddBloqueFile(string nombre, string inicio, string fin, string textoRemplazo, bool useTextLine = false, int minimumLength = 0, bool apliaTabulador = false)
        {
            DataRow dr = Bloques.NewRow();
            dr["Nombre"] = nombre;
            dr["InicioMatch"] = inicio;
            dr["FinMatch"] = fin;
            dr["TextoRemplazo"] = textoRemplazo;
            dr["UseTextLine"] = useTextLine;
            dr["MinimumLength"] = minimumLength;
            dr["ApliaTabulador"] = apliaTabulador;
            Bloques.Rows.Add(dr);
        }
        private void Algoritmo1()
        {
            //iniciaizo el analisis
            IncializaAnalisis();
            //lleno la pila de tockens
            LLenaPila();
            //separo los datos de la pila para ir llenando la lista
            int inicios, finales;
            inicios = 0;
            //hace esto mientras existan elemntos en la pila
            do
            {
                if (Pila.Count == 1)
                {
                    //ya no hay pares en la pila
                    //elimino el dato
                    Pila.RemoveAt(0);
                }
                else
                {
                    //recorro toda la pila para buscar el match
                    bool encontrado = false;
                    for (finales = inicios + 1; finales < Pila.Count; finales++)
                    {
                        CTocken obj1 = Pila[inicios];
                        CTocken obj2 = Pila[finales];
                        if (HaceMatch(obj1, obj2))
                        {
                            //si hacen match, por lo que creo el bloque
                            AgregaBloque(obj1, obj2);
                            //ahora los elimino de la pila
                            Pila.RemoveAt(finales);
                            Pila.RemoveAt(inicios);
                            //reinicio el proceso
                            inicios = 0;
                            encontrado = true;
                            break;
                        }
                        else
                        {
                            if (obj2!=null && obj2.Opener)
                            {
                                //es un opener, por lo que lo pongo como inicio para que busque su match
                                inicios = finales;
                            }
                        }
                    }
                    if (encontrado == false)
                    {
                        //no encontre ningun bloque con el inico, por lo que lo elimino y reinicio
                        //en este momento hay que tener en cuenta que estoy analizando el inico mas 
                        //profundo de la lista
                        if (Pila.Count > 0)
                            Pila.RemoveAt(inicios);
                        inicios = 0;
                    }
                }
            }
            while (Pila.Count > 0);
            /*
            //priceso las cadenas
            Compiler.Lexer.Lecxer lexser = new Compiler.Lexer.Lecxer();
            Compiler.Lexer.Lexema lex=null;
            lexser.Cadena = Cadena;
            do
            {
                lex = lexser.DameSiguienteLexemaUtil();
                if(lex!=null)
                {
                    if(lex.Tipo== Compiler.Lexer.LEXTIPE.CADENADOBLE || lex.Tipo== Compiler.Lexer.LEXTIPE.CADENASIMPLE)
                    {
                        CTocken obj1 = new CTocken();
                        CTocken obj2 = new CTocken();
                        obj1.AplicaTabulador = false;
                        obj2.AplicaTabulador = false;
                        if (lex.Tipo == Compiler.Lexer.LEXTIPE.CADENADOBLE)
                        {
                            obj1.Cadena = "\"";
                            obj2.Cadena = "\"";
                        }
                        else
                        {
                            obj1.Cadena = "\'";
                            obj2.Cadena = "\'";
                        }
                        obj1.Opener = true;
                        obj2.Opener = false;
                        obj1.Posicion = new System.Drawing.Point(lex.PosicionInicial.Linea, lex.PosicionInicial.PosicionLinea); ;
                        obj2.Posicion = new System.Drawing.Point(lex.PosicionFinal.Linea, lex.PosicionFinal.PosicionLinea); ;
                        obj1.X = lex.PosicionInicial.PosicionLinea;
                        obj2.X = lex.PosicionFinal.PosicionLinea;
                        obj1.Y = lex.PosicionInicial.Linea;
                        obj2.Y = lex.PosicionFinal.Linea;
                        AgregaBloque(obj1, obj2);
                    }
                }
            } while (lex != null);
             * */
            //ya termine, por lo que regreso el resultado del analisis
        }
        private void Algoritmo2()
        {
            IncializaAnalisis();
        }
        #endregion

        private void BKAnaliser_DoWork(object sender, DoWorkEventArgs e)
        {
            Algoritmo1();
        }

        private void BKAnaliser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnAnalisisTerminado != null)
                OnAnalisisTerminado(Lista);
        }
    }
}
