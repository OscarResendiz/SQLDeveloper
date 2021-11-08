using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    public partial class CAnalizadorArchivo : Component, IAnalizer
    {
        ObjetosModelo.AppModel Modelo;
        bool Salir = false;
        public event AnalizerEventString AnalizerEventStringmsg;
        public event AnalizerEvent iniciaAnalisisevent;
        public event AnalizerEvent terminaAnalisisevent;
        List<ObjetosModelo.CArchivo> Archivos;
        private CLineaArchivoCadena CadenaActual;
        private String ObjetoActual;
        private int Id_ArchivoActual=-1;
        List<CLineaArchivoCadena> Cadenas; //va a contener las cadenas encontradas en el archivo
        bool procesando = false;
        List<CMotorConexion> MotoresConexiones;
        List<String> PalabrasNoEncontradas; //lista de palabras que no se encontraron en ninguna base de datos
        List<Buscador.CObjetoBusquedaAvanzado> ObjetosEncontrados;
        bool objetoEncontrado;
        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="archivos"></param>
        public CAnalizadorArchivo(ObjetosModelo.AppModel modelo, List<ObjetosModelo.CArchivo> archivos)
        {
            InitializeComponent();
            Modelo = modelo;
            Archivos = archivos;
        }
        /// <summary>
        /// conrtuctor
        /// </summary>
        /// <param name="container"></param>
        public CAnalizadorArchivo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// se llama cuando termina de hacer el analisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (terminaAnalisisevent != null)
                terminaAnalisisevent();

        }
        #region implementacion de la interface IAnalizer
        /// <summary>
        /// comienza a hacer todo el analisis en segundo plano
        /// </summary>
        public void IniciaAnalisis()
        {
            Salir = false;
            PalabrasNoEncontradas = new List<String>();
            ObjetosEncontrados = new List<Buscador.CObjetoBusquedaAvanzado>();
            if (iniciaAnalisisevent != null)
                iniciaAnalisisevent();
            if (AnalizerEventStringmsg != null)
                AnalizerEventStringmsg("Inicializa Busqueda de objetos en archivos");
            CargaConexiones();
            Salir = false;
            backgroundWorker1.RunWorkerAsync();
        }
        /// <summary>
        /// asigna el manejador de evento de inicio de analizis
        /// </summary>
        /// <param name="e"></param>
        public void AddInitAnalisisEvent(AnalizerEvent e)
        {
            iniciaAnalisisevent += e;
        }
        /// <summary>
        /// asigna el manejador de evento de fin del analisis
        /// </summary>
        /// <param name="e"></param>
        public void AddEndAnalisisEvent(AnalizerEvent e)
        {
            terminaAnalisisevent += e;
        }
        /// <summary>
        /// envia el mensaje al contenedor padre
        /// </summary>
        /// <param name="e"></param>
        public void AddMessageEvent(AnalizerEventString e)
        {
            AnalizerEventStringmsg += e;
        }
        /// <summary>
        /// cancela el proceso de analisis
        /// </summary>
        public void cancelarAnalisis()
        {
            Salir = true; //mando a terminar el proceso
        }
        #endregion
        /// <summary>
        /// manda un mensaje de texto
        /// </summary>
        /// <param name="msg"></param>
        private void Mensaje(string msg)
        {
            try
            {
                backgroundWorker1.ReportProgress(0, msg);
            }
            catch(System.Exception)
            {
                return;
            }
        }
        /// <summary>
        /// proceso en segundo plano que hace el analisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            procesando = true;
            int n, max;
            n = 0;
            max = Archivos.Count();
            foreach (ObjetosModelo.CArchivo archivo in Archivos)
            {
                if (Salir)
                    return;
                n++;
                int porcentaje = n * 100 / max;
                Mensaje("Analizando: " + archivo.NombreCorto );
                AnalizaArchivo(archivo);
            }
            //ahora mando a analizar las cadenas encontradas en todos los archivos
            ProcesaCadenas();
            //me quedo en un bucle de espera hasta que se termine de procesar todas las cadenas
            while (procesando)
            {
                if (Salir)
                    return;
                System.Threading.Thread.Sleep(100); //me espero 100 milisegundos
            }
        }
        /*
        /// <summary>
        /// dependeiendo del tipo de archivo, regresa el analizador correspondiente
        /// </summary>
        /// <param name="extencion"></param>
        /// <returns></returns>
        private IFileAnalizer DameAnalizador(string extencion)
        {
            //por ahorita solo regreso el unico que tengo, pero hay que ir agregando mas
            return new CFileTextAnalizer();
        }
         * */
        /// <summary>
        /// configura las conexiones del buscardor
        /// </summary>
        private void CargaConexiones()
        {
            List<ObjetosModelo.CServidor> l = Modelo.GetServidores();
            foreach (ObjetosModelo.CServidor obj in l)
            {
                List<ObjetosModelo.CConexion> conexiones = obj.getConexiones();
                foreach (ObjetosModelo.CConexion conexion in conexiones)
                {
                    ManagerConnect.CConexion conecion2 = ManagerConnect.ControladorConexiones.GetConexion(obj.Nombre, conexion.Nombre);
                    MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(conecion2);
                    motor.SuscribeErrorMessageEvent(mesageErrorDb);
                    cBuscadorAvanzado1.AgregaMotor(motor);
                    if (MotoresConexiones == null)
                        MotoresConexiones = new List<CMotorConexion>();
                    MotoresConexiones.Add(new CMotorConexion()
                        {
                            Conexion = conexion,
                            Motor = motor
                        });
                }
            }
        }

        /// <summary>
        /// regrea el Id de la conexion que le corresponde al motor
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>

        private int BuscaConexion(MotorDB.IMotorDB motor)
        {
            foreach (CMotorConexion obj in MotoresConexiones)
            {
                if (obj.Motor == motor)
                {
                    return obj.Conexion.ID_Conexion;
                }
            }
            return -1;
        }
        /// <summary>
        /// se termino de hacer la busqueda e un objeto
        /// </summary>
        /// <param name="sender"></param>
        private void cBuscadorAvanzado1_OnFinBusqueda(Buscador.CBuscadorAvanzado sender)
        {
            if(objetoEncontrado==false)
            {
                var x = from s in PalabrasNoEncontradas where s.ToUpper().Trim() == ObjetoActual.ToUpper().Trim() select s;
                if (x.Count() == 0)
                {
                    PalabrasNoEncontradas.Add(ObjetoActual);
                }
            }
            if (ProcesaLexema() == false)
            {
                //ya no hay mas lexemas por procesar, por lo que mando a procesar la siguiente cadena
                ProcesaCadenas();
            }
        }
        /// <summary>
        /// procesa las llamadas de los eventos y los redireciona al componente contenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (e.ProgressPercentage)
                {
                    case 0: //mensajes
                        if (AnalizerEventStringmsg != null)
                            AnalizerEventStringmsg(e.UserState.ToString());
                        break;
                    case 1: //se agrego un nuevo objeto
                        Modelo.InformaInsertObjeto((int)e.UserState);
                        break;
                    case 2: //se agrega un objeto a un archivo
                        ObjetosModelo.CArchivoObjeto ArchivoObjeto = (ObjetosModelo.CArchivoObjeto)e.UserState;
                        Modelo.InformaInsertArchivoObjeto(ArchivoObjeto.ID_Archivo, ArchivoObjeto.ID_Objeto);
                        break;
                    case 3: //se agrega una linea al archivo
                        ObjetosModelo.CLineaArchivo LineaArchivo = (ObjetosModelo.CLineaArchivo)e.UserState;
                        Modelo.InformaInsertLineaArchivo(LineaArchivo.ID_Linea);
                        break;
                    case 4: //se ha modificado un archivo
                        Modelo.InformaUpdateArchivo((int)e.UserState);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                try
                {
                    if (AnalizerEventStringmsg != null)
                        AnalizerEventStringmsg(ex.Message);
                }
                catch (System.Exception ex2)
                {
                    return;
                }
                return;
            }
        }
        private void reportaNuevoObjeto(int id_objeto)
        {
            try
            {
                backgroundWorker1.ReportProgress(1, id_objeto);
            }
            catch(System.Exception)
            {
                return;
            }
        }
        private void reportaNuevoArchivoObjeto(int id_Archivo, int id_objeto)
        {
            ObjetosModelo.CArchivoObjeto obj = new ObjetosModelo.CArchivoObjeto()
            {
                ID_Archivo = id_Archivo,
                ID_Objeto = id_objeto
            };
            try
            {
                backgroundWorker1.ReportProgress(2, obj);
            }
            catch(System.Exception)
            {
                return;
            }

        }
        private void reportaNuevaLineaArchivo(int id_Archivo, int id_objeto, int id_Linea)
        {
            ObjetosModelo.CLineaArchivo obj = new ObjetosModelo.CLineaArchivo()
            {
                ID_Archivo = id_Archivo,
                ID_Linea = id_Linea
            };
            backgroundWorker1.ReportProgress(3, obj);
        }
        private void InformaArchivoActualizado(int id_archivo)
        {
            try
            {
                backgroundWorker1.ReportProgress(4, id_archivo);
            }
            catch(System.Exception)
            {
                return;
            }

        }
        /// <summary>
        /// inicializa la busqueda de objetos en las bases de datos
        /// </summary>
        private void ProcesaCadenas()
        {
            if (Cadenas.Count() == 0)
            {
                procesando = false; //termino el proceso
                return;
            }
            do
            {
                //me traigo la primer cadena encontrada
                if (Cadenas.Count == 0)
                {
                    break;
                }
                    CadenaActual = Cadenas[0];
                    Cadenas.RemoveAt(0);
                    if (CadenaActual.ID_Archivo != Id_ArchivoActual)
                    {
                        if (Id_ArchivoActual != -1)
                        {
                            ObjetosModelo.CArchivo a = Modelo.GetArchivo(Id_ArchivoActual);
                            Modelo.UpdateArchivo(a.ID_Archivo, a.NombreArchivo, a.ID_Carpeta, Color.GreenYellow, a.Comentarios, false);
                            InformaArchivoActualizado(a.ID_Archivo);
                        }
                        Id_ArchivoActual = CadenaActual.ID_Archivo;
                    }
                    //separo la cadena en componentes lexicos
                    lecxer1.Cadena = CadenaActual.Cadena;
                
            }
            while (ProcesaLexema() == false);
        }
        private void mesageErrorDb(MotorDB.IMotorDB m, string msg)
        {

            Mensaje("ERROR: " + m.GetDataBseName()+"->"+msg);
        }
        /// <summary>
        /// inicia el analisis del archivo
        /// </summary>
        /// <param name="archivo"></param>
        private void AnalizaArchivo(ObjetosModelo.CArchivo archivo)
        {
            /*
            IFileAnalizer analizador = DameAnalizador(archivo.Extencion);
            analizador.AddAnalizarObjetoEvent(AnalizaCadena);
            analizador.analiza(archivo);
             * */
            List<            ObjetosModelo.CLineaArchivo >l=Modelo.GetLineasArchivo(archivo.ID_Archivo);
            if (Cadenas == null)
                Cadenas = new List<CLineaArchivoCadena>();
            //agrego las cadenas del archivo a la lista general
            foreach(ObjetosModelo.CLineaArchivo obj in l)
            {
                if (Salir)
                    return;
                AnalizaCadena(archivo.ID_Archivo, obj.ID_Linea, obj.Texto, archivo.NombreCorto);
            }
        }
        /// <summary>
        /// Busca la cadena en las bases de datos para ver si coincide con alguno de los objetos
        /// </summary>
        /// <param name="cadena"></param>
        private void AnalizaCadena(int id_archivo, int linea, string cadena, string nombreArchivo)
        {
            //agrego la cadena al analisis
            if (cadena.Trim() == "")
                return; //ignoro las cadenas vacias
            //verifico que no se repitan las cadenas
            foreach (CLineaArchivoCadena lc in Cadenas)
            {
                if (Salir)
                    return;
                if (lc.ID_Archivo == id_archivo && lc.Cadena.ToUpper().Trim() == cadena.ToUpper().Trim())
                {
                    //ya se encuentra, por lo que ya no la agrego
                    return;
                }
            }
            Cadenas.Add(new CLineaArchivoCadena()
            {
                ID_Archivo = id_archivo,
                NLinea = linea,
                Cadena = cadena.Replace('\"', ' ').Replace('\'', ' '),
                NombreArchivo = nombreArchivo,
                Encontrada = false
            });
        }
        /// <summary>
        /// se encontro una coincidencia dentro de la base de datos, por lo que voy a verificar si coincide al 100%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="objeto"></param>
        private void cBuscadorAvanzado1_OnObjetoEncontrado(Buscador.CBuscadorAvanzado sender, Buscador.CObjetoBusquedaAvanzado objeto)
        {
            AgregaBufferEncontrado(objeto);
            if (objeto.Nombre.ToUpper().Trim() != ObjetoActual.ToUpper().Trim())
            {
                //no es el objeto que busco, por lo que lo ignoro
                return;
            }
            objetoEncontrado = true;
            //me traigo la conexion que le corresponde            
            int id_conexion = BuscaConexion(objeto.Motor);
            //agrego el objeto al modelo
            if (id_conexion != -1)
            {
                ObjetosModelo.CObjeto obj = Modelo.GetObjeto(id_conexion, objeto.Nombre);
                int id_objeto;
                if (obj == null)
                {
                    id_objeto = Modelo.InsertObjeto(id_conexion, objeto.Nombre, objeto.Tipo, false, "", Color.White, false);
                    reportaNuevoObjeto(id_objeto);
                }
                else
                {
                    id_objeto = obj.ID_Objeto;
                }
                //ahora lo agrego al archivo
                if (Modelo.GetArchivoObjeto(CadenaActual.ID_Archivo, id_objeto) == null)
                {
                    Mensaje("Encontrado: " + objeto.Nombre);
                    Modelo.InsertArchivoObjeto(CadenaActual.ID_Archivo, id_objeto, false);
                    reportaNuevoArchivoObjeto(CadenaActual.ID_Archivo, id_objeto);
                }
                //agrego el numero de linea
                if (Modelo.GetLineaArchivo(CadenaActual.NLinea) == null)
                {
                    Modelo.InsertLineaArchivo(CadenaActual.ID_Archivo, CadenaActual.Cadena, false);
                    reportaNuevaLineaArchivo(CadenaActual.ID_Archivo, id_objeto, CadenaActual.NLinea);
                }
            }
        }
        /// <summary>
        /// procesa el siguiente lexema buscando un identificador para mandarlo a buscar en las bases de datos
        /// en caso de que ya no se encuentren mas lexemas para procesar regresa false
        /// </summary>
        private bool ProcesaLexema()
        {
            Compiler.Lexer.Lexema lex = null;
            //me traigo el siguiente lexema
            bool ok = true;
            do
            {
                if (Salir)
                    return false;
                ok = true;
                lex = lecxer1.DameSiguienteLexemaUtil();
                if (lex != null)
                {
                    foreach (string s in PalabrasNoEncontradas)
                    {
                        if (Salir)
                            return false;
                        if (s.ToUpper().Trim() == lex.Texto.ToUpper().Trim())
                        {
                            ok = false;
                            break;
                        }
                    }
                }
            } while (lex != null && lex.Tipo != Compiler.Lexer.LEXTIPE.IDENTIFICADOR || ok == false);

            if (lex == null)
            {
                return false;
            }
            //veo si se encuentra en el buffer
            ObjetoActual = lex.Texto;
            objetoEncontrado = false;
            Mensaje("Buscando: " + CadenaActual.NombreArchivo + "->" + lex.Texto);
            if (BuscaEnBuffer(lex.Texto) == true)
            {
                return false;
            }

            //quito todos los filtros
            cBuscadorAvanzado1.LimpiaFiltros();
            //configuro el filtro
            Buscador.CFiltro filtro = new Buscador.CFiltro()
            {
                Cadena = lex.Texto,
                operador = Buscador.OPERADOR.NONE,
                Tipo = MotorDB.EnumTipoObjeto.NONE
            };
            cBuscadorAvanzado1.AgregarFiltro(filtro);
            //inicio la busqueda
            cBuscadorAvanzado1.Buscar();
            return true;
        }
        /// <summary>
        /// agrega el objeto al buffer
        /// </summary>
        /// <param name="obj"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void AgregaBufferEncontrado(Buscador.CObjetoBusquedaAvanzado obj)
        {
            //veo si no existe
            var x = (from a in ObjetosEncontrados where a.Motor.GetConecctionString() == obj.Motor.GetConecctionString() && a.Nombre.ToUpper().Trim() == obj.Nombre.ToUpper().Trim() && a.Tipo == obj.Tipo select a);
            if (x.Count() > 0)
                return;
            //lo agrego
            ObjetosEncontrados.Add(obj);
        }
        /// <summary>
        /// procesa la palabra en el buffer y si la encuentra reporta los objetos
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool BuscaEnBuffer(string nombre)
        {
            var x = (from a in ObjetosEncontrados where a.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim() select a);
            if (x.Count() == 0)
            {
                //no se encontro en el buffer
                return false;
            }
            foreach(var obj in x)
            {
                if (Salir)
                    return false;
                cBuscadorAvanzado1_OnObjetoEncontrado(null, obj);
            }
            return true;
        }
    }
}
   