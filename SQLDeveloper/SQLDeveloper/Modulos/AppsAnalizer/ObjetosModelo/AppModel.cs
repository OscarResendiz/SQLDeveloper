using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MotorDB;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    #region delegados para los eventos
    public delegate void OnAppModelEventDelegate(CObjetoBase obj);
    public delegate void OnModeloEventDelegate(AppModel obj);
    public delegate void OnAppModelEventMoveDelegate(CObjetoBase obj, CObjetoBase ObjOrigen, CObjetoBase ObjDestino);
    public delegate void OnCodigoEditableChangeEvent(int id_objeto, string nombre);
    public delegate void OnRenameCodigoEditableEvent(int id_objeto, string nombre, string nuevoNombre);
    public delegate void OnExcluidoEvent(string texto);
    #endregion
    /// <summary>
    /// contiene el modelo completo
    /// </summary>
    public partial class AppModel
    {
        private bool Fmodificando = false;
        public bool Modificando
        {
            get
            {
                return Fmodificando;
            }
        }
        #region Eventos generales del modelo
        public event OnModeloEventDelegate NuevoModeloEvent;
        public event OnModeloEventDelegate AbrirModeloEvent;
        public event OnModeloEventDelegate CerrarModeloEvent;
        public event OnCodigoEditableChangeEvent OnCodigoEditableChange;
        public event OnRenameCodigoEditableEvent OnRenameCodigoEditable;
        public event OnCodigoEditableChangeEvent OnResaltaNombreObjeto;
        #endregion
        #region Eventos: Altas, Bajas y Actualizaciones
        #region Extencion
        public event OnAppModelEventDelegate ExtencionInsertEvent;
        public event OnAppModelEventDelegate ExtencionDeleteEvent;
        public event OnAppModelEventDelegate ExtencionUpdatetEvent;
        #endregion
        #region ObjetoObjeto
        public event OnAppModelEventDelegate ObjetoObjetoInsertEvent;
        public event OnAppModelEventDelegate ObjetoObjetoDeleteEvent;
        public event OnAppModelEventDelegate ObjetoObjetoUpdatetEvent;
        #endregion
        #region Servidor
        public event OnAppModelEventDelegate ServidorInsertEvent;
        public event OnAppModelEventDelegate ServidorDeleteEvent;
        public event OnAppModelEventDelegate ServidorUpdatetEvent;
        #endregion
        #region Configuracion
        public event OnAppModelEventDelegate ConfiguracionInsertEvent;
        public event OnAppModelEventDelegate ConfiguracionDeleteEvent;
        public event OnAppModelEventDelegate ConfiguracionUpdatetEvent;
        #endregion
        #region Conexion
        public event OnAppModelEventDelegate ConexionInsertEvent;
        public event OnAppModelEventDelegate ConexionDeleteEvent;
        public event OnAppModelEventDelegate ConexionUpdatetEvent;
        #endregion
        #region Archivo
        public event OnAppModelEventDelegate ArchivoInsertEvent;
        public event OnAppModelEventDelegate ArchivoDeleteEvent;
        public event OnAppModelEventDelegate ArchivoUpdatetEvent;
        public event OnAppModelEventMoveDelegate ArchivoMoveEvent;
        #endregion
        #region ArchivoObjeto
        public event OnAppModelEventDelegate ArchivoObjetoInsertEvent;
        public event OnAppModelEventDelegate ArchivoObjetoDeleteEvent;
        public event OnAppModelEventDelegate ArchivoObjetoUpdatetEvent;
        #endregion
        #region LineaArchivo
        public event OnAppModelEventDelegate LineaArchivoInsertEvent;
        public event OnAppModelEventDelegate LineaArchivoDeleteEvent;
        public event OnAppModelEventDelegate LineaArchivoUpdatetEvent;
        #endregion
        #region Carpeta
        public event OnAppModelEventDelegate CarpetaInsertEvent;
        public event OnAppModelEventDelegate CarpetaDeleteEvent;
        public event OnAppModelEventDelegate CarpetaUpdatetEvent;
        public event OnAppModelEventMoveDelegate CarpetaMoveEvent;
        #endregion
        #region Script
        public event OnAppModelEventDelegate ScriptInsertEvent;
        public event OnAppModelEventDelegate ScriptDeleteEvent;
        public event OnAppModelEventDelegate ScriptUpdatetEvent;
        public event OnAppModelEventMoveDelegate ScriptMoveEvent;
        #endregion
        #region Objeto
        public event OnAppModelEventDelegate ObjetoInsertEvent;
        public event OnAppModelEventDelegate ObjetoDeleteEvent;
        public event OnAppModelEventDelegate ObjetoUpdatetEvent;
        #endregion
        #region Documento
        public event OnAppModelEventDelegate DocumentoInsertEvent;
        public event OnAppModelEventDelegate DocumentoDeleteEvent;
        public event OnAppModelEventDelegate DocumentoUpdatetEvent;
        public event OnAppModelEventMoveDelegate DocumentMoveEvent;
        #endregion
        #region ObjetoCarpeta
        public event OnAppModelEventDelegate ObjetoCarpetaInsertEvent;
        public event OnAppModelEventDelegate ObjetoCarpetaDeleteEvent;
        public event OnAppModelEventDelegate ObjetoCarpetaUpdatetEvent;
        #endregion
        #region CodigoObjeto
        public event OnAppModelEventDelegate CodigoObjetoInsertEvent;
        public event OnAppModelEventDelegate CodigoObjetoDeleteEvent;
        public event OnAppModelEventDelegate CodigoObjetoUpdatetEvent;
        #endregion
        #region CodigoEditable
        public event OnAppModelEventDelegate CodigoEditableInsertEvent;
        public event OnAppModelEventDelegate CodigoEditableDeleteEvent;
        public event OnAppModelEventDelegate CodigoEditableUpdatetEvent;
        #endregion
        #region Excluidos
        public event OnExcluidoEvent ExcluidoInsertEvent;
        public event OnExcluidoEvent ExluidoDeleteEvent;
        #endregion
        #endregion
        #region Manejo de nivel general
        private string FFileName = "";
        /// <summary>
        /// nombre del archivo donde se almacena el modelo
        /// </summary>
        public string FileName
        {
            get
            {
                return FFileName;
            }
            set
            {
                FFileName = value;
                if (System.IO.File.Exists(FFileName))
                {
                    //como xiste, lo abro
                    ReadXml(FFileName);
                }
                else
                {
                    //lo crea
                    ActualizaX();
                }
            }
        }
        /// <summary>
        /// hace una copia de seguridad
        /// </summary>
        private void Bakup()
        {
            try
            {
                string nombre = FFileName.Substring(0, FFileName.IndexOf('.')) + "_" + System.DateTime.Now.ToString("ddMMyyyy") + ".bak";
                WriteXml(nombre);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Guarda el modelo en el archivo
        /// </summary>
        /// 
        private void ActualizaX()
        {
            try
            {
                if (FFileName != "")
                {
                    WriteXml(FFileName);
                    //ahora almaceno el bakup
                    Bakup();
                }
                Fmodificando = false;
            }
            catch (System.Exception ex)
            {
                Fmodificando = false;
                return;
            }
        }
        /// <summary>
        /// regresa el nombre del archivo del proyecto sin ruta ni extencion
        /// </summary>
        /// <returns></returns>
        public string getNombreCorto()
        {
            if (FFileName.Trim() == "")
                return "";
            //separo por diagonales
            string[] txt = FFileName.Split('\\');
            //separo la extencion
            string[] txt2 = txt[txt.Length - 1].Split('.');
            return txt2[0];
        }
        /// <summary>
        /// inicializa el modelo para trabajar con datos limpios
        /// </summary>
        public void Nuevo(string fileName)
        {
            string tmpFile = FFileName;
            try
            {
                //guardo lo que tengo hasta ahorita
                ActualizaX();
                //asigno el nuevo nombre
                FFileName = fileName;
                //le asigno extencion si no la tiene
                if (!fileName.Contains("."))
                    FFileName = FFileName + ".anl";
                // limpio los datos
                Clear();
                //vuelvo a guardar
                ActualizaX();
                //hago configuraciones iniciales
                InsertExtenciones("cs");
                InsertExtenciones("xsd");
                InsertConfiguracion("Nombre", getNombreCorto());
                InsertConfiguracion("Ruta", "");
                //creo la carpeta raiz
                int id_Carpeta = InsertCarpeta("Archivos", "Carpeta incial");
                //marco la carpeta raiz
                InsertConfiguracion("CarpetaInicial", id_Carpeta.ToString());
                //mando a generar el evento de nuevo proyecto
                if (NuevoModeloEvent != null)
                    NuevoModeloEvent(this);


            }
            catch (System.Exception ex)
            {
                //paso algo al crear el archivo, por lo que recupero la informacion que se tenia
                if (tmpFile != "")
                {
                    FFileName = tmpFile;
                    ReadXml(FFileName);
                }
                throw ex; //dejo que la excepcion siga su camino
            }
        }
        /// <summary>
        /// abre un archivo
        /// </summary>
        /// <param name="fileName"></param>
        public void Abrir(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("No existe el archivo");
            }
            FFileName = fileName;
            ReadXml(FFileName);
            if (AbrirModeloEvent != null)
                AbrirModeloEvent(this);
        }
        /// <summary>
        /// Cierra el proyecto y detiene todos los procesos que se esten ejecutando en segundo plano
        /// </summary>
        public void Cerrar()
        {
            if (CerrarModeloEvent != null)
                CerrarModeloEvent(this);
        }
        public void ResaltaNombreObjeto(string nombre)
        {
            if (OnResaltaNombreObjeto != null)
                OnResaltaNombreObjeto(0, nombre);
        }
        #endregion
        #region Manejo de objetos. Get, insert Update, Delete
        #region Extencion
        #region Geters
        /// <summary>
        /// regresa una extencion en especifico
        /// </summary>
        /// <param name="ID_Extencion"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CExtencion GetExtencion(int ID_Extencion)
        {

            var x = (from obj in Extenciones where obj.ID_Extencion == ID_Extencion select obj).First();
            return new CExtencion()
            {
                ID_Extencion = x.ID_Extencion
                ,
                Extencion = x.Extencion,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todas las extenciones
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CExtencion> GetExtenciones()
        {
            List<CExtencion> lista = new List<CExtencion>();
            var l = (from obj in Extenciones select obj);
            foreach (var x in l)
            {
                lista.Add(new CExtencion()
                {
                    ID_Extencion = x.ID_Extencion
                    ,
                    Extencion = x.Extencion,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega una extencion
        /// </summary>
        /// <param name="ID_Extencion"></param>
        /// <param name="Extencion"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertExtenciones(string Extencion)
        {
            Fmodificando = true;
            ExtencionesRow r = Extenciones.NewExtencionesRow();
            r.Extencion = Extencion;
            Extenciones.Rows.Add(r);
            ActualizaX();
            Fmodificando = false;
            //genero el evento
            if (ExtencionInsertEvent != null)
                ExtencionInsertEvent(GetExtencion(r.ID_Extencion));
        }
        #endregion
        #region Update
        //actualiza los datos de la extencion
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateExtenciones(int ID_Extencion, string Extencion)
        {
            Fmodificando = true;
            var obj = (from x in Extenciones where x.ID_Extencion == ID_Extencion select x).First();
            obj.ID_Extencion = ID_Extencion;
            obj.Extencion = Extencion;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ExtencionUpdatetEvent != null)
                ExtencionUpdatetEvent(GetExtencion(ID_Extencion));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina la extencion
        /// </summary>
        /// <param name="ID_Extencion"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteExtenciones(int ID_Extencion)
        {
            Fmodificando = true;
            CExtencion extencion = GetExtencion(ID_Extencion);
            var obj = (from x in Extenciones where x.ID_Extencion == ID_Extencion select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ExtencionDeleteEvent != null)
                ExtencionDeleteEvent(extencion);
        }
        #endregion
        #endregion
        #region ObjetoObjeto
        #region Geters
        /// <summary>
        /// regresa un registro especifico
        /// </summary>
        /// <param name="ID_ObjetoPadre"></param>
        /// <param name="ID_ObjetoHijo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CObjetoObjeto GetObjetoObjeto(int ID_ObjetoPadre, int ID_ObjetoHijo)
        {

            var l = (from obj in ObjetoObjeto where obj.ID_ObjetoPadre == ID_ObjetoPadre && obj.ID_ObjetoHijo == ID_ObjetoHijo select obj);
            if (l.Count() == 0)
                return null;
            var x = l.First();
            return new CObjetoObjeto()
            {
                ID_ObjetoPadre = x.ID_ObjetoPadre
                ,
                ID_ObjetoHijo = x.ID_ObjetoHijo,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa los objetos hijos
        /// </summary>
        /// <param name="ID_ObjetoPadre"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjetoObjeto> GetObjetoObjetos(int ID_ObjetoPadre)
        {
            List<CObjetoObjeto> lista = new List<CObjetoObjeto>();
            var l = (from obj in ObjetoObjeto where obj.ID_ObjetoPadre == ID_ObjetoPadre select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjetoObjeto()
                {
                    ID_ObjetoPadre = x.ID_ObjetoPadre
                    ,
                    ID_ObjetoHijo = x.ID_ObjetoHijo,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa la lista de objetos relacionados donde el objeto es el hijo
        /// </summary>
        /// <param name="ID_Objetohijo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjetoObjeto> GetObjetosObjeto(int ID_Objetohijo)
        {
            List<CObjetoObjeto> lista = new List<CObjetoObjeto>();
            var l = (from obj in ObjetoObjeto where obj.ID_ObjetoHijo == ID_Objetohijo select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjetoObjeto()
                {
                    ID_ObjetoPadre = x.ID_ObjetoPadre
                    ,
                    ID_ObjetoHijo = x.ID_ObjetoHijo,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todos los objetos
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjetoObjeto> GetObjetoObjetos()
        {
            List<CObjetoObjeto> lista = new List<CObjetoObjeto>();
            var l = (from obj in ObjetoObjeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjetoObjeto()
                {
                    ID_ObjetoPadre = x.ID_ObjetoPadre
                    ,
                    ID_ObjetoHijo = x.ID_ObjetoHijo,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// inserta un registros
        /// </summary>
        /// <param name="ID_ObjetoPadre"></param>
        /// <param name="ID_ObjetoHijo"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertObjetoObjeto(int ID_ObjetoPadre, int ID_ObjetoHijo)
        {
            Fmodificando = true;
            ObjetoObjetoRow r = ObjetoObjeto.NewObjetoObjetoRow();
            r.ID_ObjetoPadre = ID_ObjetoPadre;
            r.ID_ObjetoHijo = ID_ObjetoHijo;
            ObjetoObjeto.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ObjetoObjetoInsertEvent != null)
                ObjetoObjetoInsertEvent(GetObjetoObjeto(r.ID_ObjetoPadre, r.ID_ObjetoHijo));
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos del registro
        /// </summary>
        /// <param name="ID_ObjetoPadre"></param>
        /// <param name="ID_ObjetoHijo"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateObjetoObjeto(int ID_ObjetoPadre, int ID_ObjetoHijo)
        {
            Fmodificando = true;
            var obj = (from x in ObjetoObjeto where x.ID_ObjetoPadre == ID_ObjetoPadre && x.ID_ObjetoHijo == ID_ObjetoHijo select x).First();
            obj.ID_ObjetoPadre = ID_ObjetoPadre;
            obj.ID_ObjetoHijo = ID_ObjetoHijo;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ObjetoObjetoUpdatetEvent != null)
                ObjetoObjetoUpdatetEvent(GetObjetoObjeto(ID_ObjetoPadre, ID_ObjetoHijo));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el registro
        /// </summary>
        /// <param name="ID_ObjetoPadre"></param>
        /// <param name="ID_ObjetoHijo"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteObjetoObjeto(int ID_ObjetoPadre, int ID_ObjetoHijo)
        {
            Fmodificando = true;
            CObjetoObjeto objeto = GetObjetoObjeto(ID_ObjetoPadre, ID_ObjetoHijo);
            var obj = (from x in ObjetoObjeto where x.ID_ObjetoPadre == ID_ObjetoPadre && x.ID_ObjetoHijo == ID_ObjetoHijo select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ObjetoObjetoDeleteEvent != null)
                ObjetoObjetoDeleteEvent(objeto);
        }
        #endregion
        #endregion
        #region Servidor
        #region Geters
        /// <summary>
        /// regresa un servidor especifico
        /// </summary>
        /// <param name="ID_Servidor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CServidor GetServidor(int ID_Servidor)
        {

            var x = (from obj in Servidor where obj.ID_Servidor == ID_Servidor select obj).First();
            return new CServidor()
            {
                ID_Servidor = x.ID_Servidor
                ,
                Nombre = x.Nombre,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todos los servidores
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CServidor> GetServidores()
        {
            List<CServidor> lista = new List<CServidor>();
            var l = (from obj in Servidor select obj);
            foreach (var x in l)
            {
                lista.Add(new CServidor()
                {
                    ID_Servidor = x.ID_Servidor
                    ,
                    Nombre = x.Nombre,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega un servidor
        /// </summary>
        /// <param name="Nombre"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertServidor(string Nombre)
        {
            Fmodificando = true;
            ServidorRow r = Servidor.NewServidorRow();
            r.Nombre = Nombre;
            Servidor.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ServidorInsertEvent != null)
                ServidorInsertEvent(GetServidor(r.ID_Servidor));
            return r.ID_Servidor;
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos del servidor
        /// </summary>
        /// <param name="ID_Servidor"></param>
        /// <param name="Nombre"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateServidor(int ID_Servidor, string Nombre)
        {
            Fmodificando = true;
            var obj = (from x in Servidor where x.ID_Servidor == ID_Servidor select x).First();
            obj.ID_Servidor = ID_Servidor;
            obj.Nombre = Nombre;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ServidorUpdatetEvent != null)
                ServidorUpdatetEvent(GetServidor(ID_Servidor));
        }
        #endregion
        #region Delete
        /// <summary>
        /// Elimina el servidor
        /// </summary>
        /// <param name="ID_Servidor"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteServidor(int ID_Servidor)
        {
            Fmodificando = true;
            CServidor servidor = GetServidor(ID_Servidor);
            var obj = (from x in Servidor where x.ID_Servidor == ID_Servidor select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ServidorDeleteEvent != null)
                ServidorDeleteEvent(servidor);
        }
        #endregion
        #endregion
        #region Configuracion
        #region Geters
        /// <summary>
        /// regresa una configuracion
        /// </summary>
        /// <param name="Clave"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CConfiguracion GetConfiguracion(string Clave)
        {

            var x = (from obj in Configuracion where obj.Clave == Clave select obj).First();
            return new CConfiguracion()
            {
                Clave = x.Clave
                ,
                Valor = x.Valor,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todas las configuraciones
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CConfiguracion> GetConfiguracions()
        {
            List<CConfiguracion> lista = new List<CConfiguracion>();
            var l = (from obj in Configuracion select obj);
            foreach (var x in l)
            {
                lista.Add(new CConfiguracion()
                {
                    Clave = x.Clave
                    ,
                    Valor = x.Valor,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega una configuracion
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="Valor"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertConfiguracion(string Clave, string Valor)
        {
            Fmodificando = true;
            ConfiguracionRow r = Configuracion.NewConfiguracionRow();
            r.Clave = Clave;
            r.Valor = Valor;
            Configuracion.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ConfiguracionInsertEvent != null)
                ConfiguracionInsertEvent(GetConfiguracion(r.Clave));
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza la configuracion
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="Valor"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateConfiguracion(string Clave, string Valor)
        {
            Fmodificando = true;
            var obj = (from x in Configuracion where x.Clave == Clave select x).First();
            obj.Clave = Clave;
            obj.Valor = Valor;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ConfiguracionUpdatetEvent != null)
                ConfiguracionUpdatetEvent(GetConfiguracion(Clave));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina la configuracion
        /// </summary>
        /// <param name="Clave"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteConfiguracion(string Clave)
        {
            Fmodificando = true;
            CConfiguracion configuracion = GetConfiguracion(Clave);
            var obj = (from x in Configuracion where x.Clave == Clave select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ConfiguracionDeleteEvent != null)
                ConfiguracionDeleteEvent(configuracion);
        }
        #endregion
        #endregion
        #region Conexion
        #region Geters
        /// <summary>
        /// regresa una conexion especifica
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CConexion GetConexion(int ID_Conexion)
        {

            var l = (from obj in Conexion where obj.ID_Conexion == ID_Conexion select obj);
            if (l.Count() == 0)
                return null;
            var x = l.First();
            return new CConexion()
            {
                ID_Conexion = x.ID_Conexion
                ,
                ID_Servidor = x.ID_Servidor
                ,
                Nombre = x.Nombre
                ,
                ConecctionString = x.ConecctionString
                ,
                MotorDB = x.MotorDB,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todas las conexiones del servidor
        /// </summary>
        /// <param name="ID_Servidor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CConexion> GetConexiones(int ID_Servidor)
        {
            List<CConexion> lista = new List<CConexion>();
            var l = (from obj in Conexion where obj.ID_Servidor == ID_Servidor select obj);
            foreach (var x in l)
            {
                lista.Add(new CConexion()
                {
                    ID_Conexion = x.ID_Conexion
                    ,
                    ID_Servidor = x.ID_Servidor
                    ,
                    Nombre = x.Nombre
                    ,
                    ConecctionString = x.ConecctionString
                    ,
                    MotorDB = x.MotorDB,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todas las conexiones
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CConexion> GetConexiones()
        {
            List<CConexion> lista = new List<CConexion>();
            var l = (from obj in Conexion select obj);
            foreach (var x in l)
            {
                lista.Add(new CConexion()
                {
                    ID_Conexion = x.ID_Conexion
                    ,
                    ID_Servidor = x.ID_Servidor
                    ,
                    Nombre = x.Nombre
                    ,
                    ConecctionString = x.ConecctionString
                    ,
                    MotorDB = x.MotorDB,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrea una conexion
        /// </summary>
        /// <param name="ID_Servidor"></param>
        /// <param name="Nombre"></param>
        /// <param name="ConecctionString"></param>
        /// <param name="MotorDB"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertConexion(int ID_Servidor, string Nombre, string ConecctionString, string MotorDB)
        {
            Fmodificando = true;
            ConexionRow r = Conexion.NewConexionRow();
            r.ID_Servidor = ID_Servidor;
            r.Nombre = Nombre;
            r.ConecctionString = ConecctionString;
            r.MotorDB = MotorDB;
            Conexion.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ConexionInsertEvent != null)
                ConexionInsertEvent(GetConexion(r.ID_Conexion));
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos de la conexion
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="ID_Servidor"></param>
        /// <param name="Nombre"></param>
        /// <param name="ConecctionString"></param>
        /// <param name="MotorDB"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateConexion(int ID_Conexion, int ID_Servidor, string Nombre, string ConecctionString, string MotorDB)
        {
            Fmodificando = true;
            var obj = (from x in Conexion where x.ID_Conexion == ID_Conexion select x).First();
            obj.ID_Conexion = ID_Conexion;
            obj.ID_Servidor = ID_Servidor;
            obj.Nombre = Nombre;
            obj.ConecctionString = ConecctionString;
            obj.MotorDB = MotorDB;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ConexionUpdatetEvent != null)
                ConexionUpdatetEvent(GetConexion(ID_Conexion));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina la conexion
        /// </summary>
        /// <param name="ID_Conexion"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteConexion(int ID_Conexion)
        {
            Fmodificando = true;
            CConexion conexion = GetConexion(ID_Conexion);
            var obj = (from x in Conexion where x.ID_Conexion == ID_Conexion select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ConexionDeleteEvent != null)
                ConexionDeleteEvent(conexion);
        }
        #endregion
        #endregion
        #region Archivo
        #region Geters
        /// <summary>
        /// regresa un archivo especifico
        /// </summary>
        /// <param name="id_archivo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CArchivo GetArchivo(int id_archivo)
        {
            var x = (from obj in Archivo where obj.ID_Archivo == id_archivo select obj).First();

            return new CArchivo()
            {
                ID_Archivo = x.ID_Archivo,
                ID_Carpeta = x.ID_Carpeta,
                BKColor = GetColor(x.BKColor),
                NombreArchivo = x.NombreArchivo,
                Comentarios = x.Comentarios,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa el listado de todos los archivos
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CArchivo> GetArchivos()
        {
            List<CArchivo> lista = new List<CArchivo>();
            var l = (from obj in Archivo select obj).OrderBy(o => o.NombreArchivo);
            foreach (var x in l)
            {
                lista.Add(new CArchivo()
                {
                    ID_Archivo = x.ID_Archivo,
                    ID_Carpeta = x.ID_Carpeta,
                    BKColor = GetColor(x.BKColor),
                    NombreArchivo = x.NombreArchivo,
                    Comentarios = x.Comentarios,
                    Modelo = this
                }
                 );
            }
            return lista;
        }
        /// <summary>
        /// regresa toda la lista de archivos que pertenecen a una carpeta
        /// </summary>
        /// <param name="id_Carpeta">identificador de la carpeta</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CArchivo> GetArchivos(int id_Carpeta)
        {
            List<CArchivo> lista = new List<CArchivo>();
            var l = (from obj in Archivo where obj.ID_Carpeta == id_Carpeta select obj).OrderBy(o => o.NombreArchivo); ;
            foreach (var x in l)
            {
                lista.Add(new CArchivo()
                {
                    ID_Archivo = x.ID_Archivo,
                    ID_Carpeta = x.ID_Carpeta,
                    BKColor = GetColor(x.BKColor),
                    NombreArchivo = x.NombreArchivo,
                    Comentarios = x.Comentarios,
                    Modelo = this
                }
                 );
            }
            return lista;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CArchivo GetArchivo(int id_Carpeta, string nombre)
        {
            var l = (from obj in Archivo where obj.ID_Carpeta == id_Carpeta && obj.NombreArchivo == nombre select obj).OrderBy(o => o.NombreArchivo); ;
            foreach (var x in l)
            {
                return new CArchivo()
                {
                    ID_Archivo = x.ID_Archivo,
                    ID_Carpeta = x.ID_Carpeta,
                    BKColor = GetColor(x.BKColor),
                    NombreArchivo = x.NombreArchivo,
                    Comentarios = x.Comentarios,
                    Modelo = this
                };
            }
            return null;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega el archivo dentro de la carpeta
        /// </summary>
        /// <param name="NombreArchivo"></param>
        /// <param name="ID_Carpeta"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertArchivo(string NombreArchivo, int ID_Carpeta, System.Drawing.Color BKColor, string comentarios, bool notificar = true)
        {
            Fmodificando = true;
            ArchivoRow r = Archivo.NewArchivoRow();
            r.NombreArchivo = NombreArchivo;
            r.ID_Carpeta = ID_Carpeta;
            r.BKColor = "#" + BKColor.R.ToString("X2") + BKColor.G.ToString("X2") + BKColor.B.ToString("X2");
            r.Comentarios = comentarios;
            Archivo.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ArchivoInsertEvent != null && notificar)
                ArchivoInsertEvent(GetArchivo(r.ID_Archivo));
            return r.ID_Archivo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void NotificaNuevoArchivo(int ID_Archivo)
        {
            if (ArchivoInsertEvent != null)
                ArchivoInsertEvent(GetArchivo(ID_Archivo));
        }
        #endregion
        #region Move
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void MueveArchivo(int id_Archivo, int id_Carpeta)
        {
            CArchivo archivo = GetArchivo(id_Archivo);
            CCarpeta origen = GetCarpeta(archivo.ID_Carpeta);
            CCarpeta destino = GetCarpeta(id_Carpeta);
            if (archivo.ID_Carpeta == id_Carpeta)
            {
                return; //no hago nada porque ya pertenece a la carpeta
            }
            archivo.ID_Carpeta = id_Carpeta;
            archivo.update();
            //genero el evento
            if (ArchivoMoveEvent != null)
                ArchivoMoveEvent(archivo, origen, destino);
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos del archivo
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="NombreArchivo"></param>
        /// <param name="ID_Carpeta"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateArchivo(int ID_Archivo, string NombreArchivo, int ID_Carpeta, System.Drawing.Color BKColor, string comentarios, bool informa = true)
        {
            Fmodificando = true;
            var obj = (from x in Archivo where x.ID_Archivo == ID_Archivo select x).First();
            obj.NombreArchivo = NombreArchivo;
            obj.ID_Carpeta = ID_Carpeta;
            obj.BKColor = "#" + BKColor.R.ToString("X2") + BKColor.G.ToString("X2") + BKColor.B.ToString("X2");
            obj.Comentarios = comentarios;
            obj.AcceptChanges();
            ActualizaX();
            if (ArchivoUpdatetEvent != null && informa)
                ArchivoUpdatetEvent(GetArchivo(ID_Archivo));
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InformaUpdateArchivo(int ID_Archivo)
        {
            if (ArchivoUpdatetEvent != null)
                ArchivoUpdatetEvent(GetArchivo(ID_Archivo));

        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el archivo
        /// </summary>
        /// <param name="ID_Archivo"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteArchivo(int ID_Archivo)
        {
            Fmodificando = true;
            CArchivo archivo = GetArchivo(ID_Archivo);
            var obj = (from x in Archivo where x.ID_Archivo == ID_Archivo select x).First();
            obj.Delete();
            ActualizaX();
            if (ArchivoDeleteEvent != null)
                ArchivoDeleteEvent(archivo);
        }
        #endregion
        #endregion
        #region ArchivoObjeto
        #region Geters
        /// <summary>
        /// regresa un objeto de relacion de archivo objeto
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CArchivoObjeto GetArchivoObjeto(int ID_Archivo, int ID_Objeto)
        {
            try
            {
                var l = (from obj in ArchivoObjeto where obj.ID_Archivo == ID_Archivo && obj.ID_Objeto == ID_Objeto select obj);
                if (l.Count() == 0)
                    return null;
                var x = l.First();
                return new CArchivoObjeto()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                };
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// regresa todas las relaciones
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CArchivoObjeto> GetArchivoObjetos()
        {
            List<CArchivoObjeto> lista = new List<CArchivoObjeto>();
            var l = (from obj in ArchivoObjeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CArchivoObjeto()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa toda la relacion de objetos que pertenecen al archivo
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CArchivoObjeto> GetArchivoObjetos(int ID_Archivo)
        {
            List<CArchivoObjeto> lista = new List<CArchivoObjeto>();
            var l = (from obj in ArchivoObjeto where obj.ID_Archivo == ID_Archivo select obj);
            foreach (var x in l)
            {
                lista.Add(new CArchivoObjeto()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa la lista de archivos en la que se encuentra almacenado el objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CArchivoObjeto> GetArchivosObjeto(int ID_Objeto)
        {
            List<CArchivoObjeto> lista = new List<CArchivoObjeto>();
            var l = (from obj in ArchivoObjeto where obj.ID_Objeto == ID_Objeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CArchivoObjeto()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega una relaciion a la base
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertArchivoObjeto(int ID_Archivo, int ID_Objeto, bool informar = true)
        {
            Fmodificando = true;
            ArchivoObjetoRow r = ArchivoObjeto.NewArchivoObjetoRow();
            r.ID_Archivo = ID_Archivo;
            r.ID_Objeto = ID_Objeto;
            ArchivoObjeto.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ArchivoObjetoInsertEvent != null && informar)
                ArchivoObjetoInsertEvent(GetArchivoObjeto(r.ID_Archivo, r.ID_Objeto));
        }
        #endregion
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InformaInsertArchivoObjeto(int ID_Archivo, int ID_Objeto)
        {
            if (ArchivoObjetoInsertEvent != null)
                ArchivoObjetoInsertEvent(GetArchivoObjeto(ID_Archivo, ID_Objeto));
        }
        #region Update
        /// <summary>
        /// actualiza la relacion
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateArchivoObjeto(int ID_Archivo, int ID_Objeto)
        {
            Fmodificando = true;
            var obj = (from x in ArchivoObjeto where x.ID_Archivo == ID_Archivo && x.ID_Objeto == ID_Objeto select x).First();
            obj.ID_Archivo = ID_Archivo;
            obj.ID_Objeto = ID_Objeto;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ArchivoObjetoUpdatetEvent != null)
                ArchivoObjetoUpdatetEvent(GetArchivoObjeto(ID_Archivo, ID_Objeto));
        }
        #endregion
        #region Delete
        /// <summary>
        /// quita la relacion 
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteArchivoObjeto(int ID_Archivo, int ID_Objeto)
        {
            Fmodificando = true;
            CArchivoObjeto archivo = GetArchivoObjeto(ID_Archivo, ID_Objeto);
            var obj = (from x in ArchivoObjeto where x.ID_Archivo == ID_Archivo && x.ID_Objeto == ID_Objeto select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ArchivoObjetoDeleteEvent != null)
                ArchivoObjetoDeleteEvent(archivo);
        }
        #endregion
        #endregion
        #region LineaArchivo
        #region Geters
        /// <summary>
        /// regresa la linea especificada
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        /// <param name="ID_Linea"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CLineaArchivo GetLineaArchivo(int NoLinea)
        {

            var l = (from obj in LineaArchivo where obj.ID_Linea == NoLinea select obj);
            if (l.Count() == 0)
                return null;
            var x = l.First();
            return new CLineaArchivo()
            {
                ID_Archivo = x.ID_Archivo
                ,
                ID_Linea = x.ID_Linea
                ,
                Texto = x.Texto,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todas las lineas
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CLineaArchivo> GetLineaArchivos()
        {
            List<CLineaArchivo> lista = new List<CLineaArchivo>();
            var l = (from obj in LineaArchivo select obj);
            foreach (var x in l)
            {
                lista.Add(new CLineaArchivo()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Linea = x.ID_Linea
                    ,
                    Texto = x.Texto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todas las lineas
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CLineaArchivo> GetCoincidenciasLineaArchivos(String cadena)
        {
            List<CLineaArchivo> lista = new List<CLineaArchivo>();
            var l = (from obj in LineaArchivo where obj.Texto == cadena select obj);
            foreach (var x in l)
            {
                lista.Add(new CLineaArchivo()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Linea = x.ID_Linea
                    ,
                    Texto = x.Texto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todas las lineas que pertenecen al archivo
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CLineaArchivo> GetLineasArchivo(int ID_Archivo)
        {
            List<CLineaArchivo> lista = new List<CLineaArchivo>();
            var l = (from obj in LineaArchivo where obj.ID_Archivo == ID_Archivo select obj);
            foreach (var x in l)
            {
                lista.Add(new CLineaArchivo()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Linea = x.ID_Linea
                    ,
                    Texto = x.Texto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todas las lineas de todos los archivos
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CLineaArchivo> GetAllLineasArchivo()
        {
            List<CLineaArchivo> lista = new List<CLineaArchivo>();
            var l = (from obj in LineaArchivo select obj);
            foreach (var x in l)
            {
                lista.Add(new CLineaArchivo()
                {
                    ID_Archivo = x.ID_Archivo
                    ,
                    ID_Linea = x.ID_Linea
                    ,
                    Texto = x.Texto,
                    Modelo = this
                });
            }
            return lista;
        }

        #endregion
        #region Insert
        /// <summary>
        /// inserta una linea
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        /// <param name="NoLinea"></param>
        /// <param name="Texto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertLineaArchivo(int ID_Archivo, string Texto, bool informar = true)
        {
            Fmodificando = true;
            LineaArchivoRow r = LineaArchivo.NewLineaArchivoRow();
            r.ID_Archivo = ID_Archivo;
            r.Texto = Texto;
            LineaArchivo.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (LineaArchivoInsertEvent != null && informar)
                LineaArchivoInsertEvent(GetLineaArchivo(r.ID_Linea));
            return r.ID_Linea;
        }
        #endregion
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InformaInsertLineaArchivo(int ID_Linea)
        {
            if (LineaArchivoInsertEvent != null)
                LineaArchivoInsertEvent(GetLineaArchivo(ID_Linea));
        }
        #region Update
        /// <summary>
        /// actualiza la linea
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        /// <param name="NoLinea"></param>
        /// <param name="Texto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateLineaArchivo(int ID_Archivo, int ID_Linea, string Texto)
        {
            Fmodificando = true;
            var obj = (from x in LineaArchivo where x.ID_Archivo == ID_Archivo && x.ID_Linea == ID_Linea select x).First();
            obj.ID_Archivo = ID_Archivo;
            obj.ID_Linea = ID_Linea;
            obj.Texto = Texto;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (LineaArchivoUpdatetEvent != null)
                LineaArchivoUpdatetEvent(GetLineaArchivo(ID_Linea));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina la linea
        /// </summary>
        /// <param name="ID_Archivo"></param>
        /// <param name="ID_Objeto"></param>
        /// <param name="NoLinea"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteLineaArchivo(int ID_Linea, bool reportar = true)
        {
            Fmodificando = true;
            CLineaArchivo linea = GetLineaArchivo(ID_Linea);
            var obj = (from x in LineaArchivo where x.ID_Linea == ID_Linea select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (LineaArchivoDeleteEvent != null && reportar)
                LineaArchivoDeleteEvent(linea);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ReportaDeleteLineaArchivo(CLineaArchivo linea)
        {
            if (LineaArchivoDeleteEvent != null)
                LineaArchivoDeleteEvent(linea);

        }
        #endregion
        #endregion
        #region Carpeta
        #region Geters
        /// <summary>
        /// regresa ina carpeta especifica
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CCarpeta GetCarpeta(int ID_Carpeta)
        {
            var x = (from obj in Carpeta where obj.ID_Carpeta == ID_Carpeta select obj).First();
            CCarpeta obj2 = new CCarpeta()
            {
                ID_Carpeta = x.ID_Carpeta
                ,
                Nombre = x.Nombre
                ,
                Comentarios = x.Comentarios,
                ID_CarpetaPadre = x.ID_CarpetaPadre,
                Modelo = this
            };
            return obj2;
        }
        /// <summary>
        /// regresa la lista de carpetas que pertenecen a la carpeta padre
        /// </summary>
        /// <param name="ID_CarpetaPadre"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCarpeta> GetCarpetas(int ID_CarpetaPadre)
        {
            List<CCarpeta> lista = new List<CCarpeta>();
            var l = (from obj in Carpeta where obj.ID_CarpetaPadre == ID_CarpetaPadre select obj);
            foreach (var x in l)
            {
                CCarpeta obj2 = new CCarpeta()

                {
                    ID_Carpeta = x.ID_Carpeta
                        ,
                    Nombre = x.Nombre
                        ,
                    Comentarios = x.Comentarios,
                    ID_CarpetaPadre = x.ID_CarpetaPadre,
                    Modelo = this
                };
                lista.Add(obj2);
            }
            return lista;
        }
        /// <summary>
        /// Regresa el listado de carpetas que no tiene archivos asociados
        /// </summary>
        /// <param name="ID_CarpetaPadre"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCarpeta> GetCarpetasVacias()
        {
            List<CCarpeta> lista = new List<CCarpeta>();
            //me traigo todas las carpetas
            var l = (from obj in Carpeta select obj);
            foreach (var x in l)
            {
                bool vacio = true;
                //veo si tiene documentos
                if (GetDocumentos(x.ID_Carpeta).Count() > 0)
                    vacio = false;
                //veo si tiene archivos
                if (GetArchivos(x.ID_Carpeta).Count() > 0)
                    vacio = false;
                //veo si tiene scripts
                if (GetScripts(x.ID_Carpeta).Count() > 0)
                    vacio = false;
                //veo si tiene objetos
                if (GetObjetosCarpeta(x.ID_Carpeta).Count() > 0)
                    vacio = false;
                //veo si tiene carpetas
                if (GetCarpetas(x.ID_Carpeta).Count() > 0)
                    vacio = false;

                if (vacio)
                {
                    CCarpeta obj2 = new CCarpeta()

                    {
                        ID_Carpeta = x.ID_Carpeta
                        ,
                        Nombre = x.Nombre
                        ,
                        Comentarios = x.Comentarios,
                        ID_CarpetaPadre = x.ID_CarpetaPadre,
                        Modelo = this
                    };
                    lista.Add(obj2);
                }
            }
            return lista;
        }
        /// <summary>
        /// regresa la lista de carpetas principa
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCarpeta> GetCarpetas()
        {
            List<CCarpeta> lista = new List<CCarpeta>();
            var l = (from obj in Carpeta where obj.ID_CarpetaPadre == -1 select obj);
            foreach (var x in l)
            {
                CCarpeta obj2 = new CCarpeta()

                {
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Nombre = x.Nombre
                    ,
                    Comentarios = x.Comentarios,
                    ID_CarpetaPadre = x.ID_CarpetaPadre,
                    Modelo = this
                };
                lista.Add(obj2);
            }
            return lista;
        }
        /// <summary>
        /// regresa la carpeta padre de la carpeta solicitada
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CCarpeta GetCarpetaPadre(int ID_Carpeta)
        {
            CCarpeta obj = GetCarpeta(ID_Carpeta);
            if (obj.ID_CarpetaPadre == -1)
                return null; //no tiene padre
            return GetCarpeta(obj.ID_CarpetaPadre);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CCarpeta GetCarpetaHija(int ID_CarpetaPadre, string carpeta)
        {
            var l = (from obj in Carpeta where obj.ID_CarpetaPadre == ID_CarpetaPadre && obj.Nombre.ToUpper().Trim() == carpeta.ToUpper().Trim() select obj);
            foreach (var x in l)
            {
                return new CCarpeta()

                {
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Nombre = x.Nombre
                    ,
                    Comentarios = x.Comentarios,
                    ID_CarpetaPadre = x.ID_CarpetaPadre,
                    Modelo = this
                };
            }
            return null;
        }

        #endregion
        #region Insert
        /// <summary>
        /// agrega una carpeta al modelo
        /// </summary>
        /// <param name="Nombre">nombre de la carpeta</param>
        /// <param name="Comentarios">comentarios echos por el usuario</param>
        /// <param name="ID_CarpetaPadre">carpeta a la que pertenece</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertCarpeta(string Nombre, string Comentarios, int ID_CarpetaPadre = -1, bool notificar = true)
        {
            Fmodificando = true;
            CarpetaRow r = Carpeta.NewCarpetaRow();
            r.Nombre = Nombre;
            r.ID_CarpetaPadre = ID_CarpetaPadre;
            r.Comentarios = Comentarios;
            Carpeta.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (CarpetaInsertEvent != null && notificar)
                CarpetaInsertEvent(GetCarpeta(r.ID_Carpeta));
            return r.ID_Carpeta;
        }
        #endregion
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void NotificaNuevaCarpeta(int ID_Carpeta)
        {
            if (CarpetaInsertEvent != null)
                CarpetaInsertEvent(GetCarpeta(ID_Carpeta));
        }
        #region Update

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateCarpeta(int ID_Carpeta, string Nombre, int ID_CarpetaPadre = -1, string Comentarios = "")
        {
            Fmodificando = true;
            var obj = (from x in Carpeta where x.ID_Carpeta == ID_Carpeta select x).First();
            obj.ID_Carpeta = ID_Carpeta;
            obj.Nombre = Nombre;
            obj.ID_CarpetaPadre = ID_CarpetaPadre;
            obj.Comentarios = Comentarios;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (CarpetaUpdatetEvent != null)
                CarpetaUpdatetEvent(GetCarpeta(ID_Carpeta));
        }
        #endregion
        #region Delete

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteCarpeta(int ID_Carpeta)
        {
            Fmodificando = true;
            CCarpeta carpeta = GetCarpeta(ID_Carpeta);
            var obj = (from x in Carpeta where x.ID_Carpeta == ID_Carpeta select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (CarpetaDeleteEvent != null)
                CarpetaDeleteEvent(carpeta);
        }
        #endregion
        #region move
        /// <summary>
        /// mueve la carpeta a la carpeta padre
        /// </summary>
        /// <param name="idCarpeta">carpeta a mover</param>
        /// <param name="idDestino">Carpeta destino</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void moveCarpeta(int idCarpeta, int idDestino)
        {
            if (idCarpeta == idDestino)
            {
                throw new Exception("La carpeta no se puede mover a si misma");
            }
            //verifico si la carpeta destino no es decendiente de la carpeta a mover
            if (verificaCarpetaHija(idCarpeta, idDestino))
            {
                throw new Exception("La carpeta no se puede mover a una de sus carpetas hijas");
            }
            //veo si la carpeta es hija de la carpeta destino
            CCarpeta origen = GetCarpetaPadre(idCarpeta);
            if (origen != null)
            {
                if (origen.ID_Carpeta == idDestino)
                {
                    return;// no hago nada porque ya es su hija
                }
            }
            //ahora si hago el movimiento de la carpeta
            CCarpeta carpeta = GetCarpeta(idCarpeta);
            carpeta.ID_CarpetaPadre = idDestino;
            carpeta.Update();
            //me traigo la carpeta destino
            CCarpeta destino = GetCarpeta(idDestino);
            //manejo el evento de que se movio la carpeta
            if (CarpetaMoveEvent != null)
                CarpetaMoveEvent(carpeta, origen, destino);
        }
        /// <summary>
        /// rerifica que la carpeta 2 es hija de la carpeta 1
        /// </summary>
        /// <param name="idCarpeta1"></param>
        /// <param name="idCarpeta2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool verificaCarpetaHija(int idCarpeta1, int idCarpeta2)
        {
            if (idCarpeta1 == idCarpeta2)
                return true;
            List<CCarpeta> l = GetCarpetas(idCarpeta1);

            foreach (CCarpeta c in l)
            {
                if (verificaCarpetaHija(c.ID_Carpeta, idCarpeta2))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion
        #region Script
        #region Geters
        /// <summary>
        /// regresa un script especifico
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CScript GetScript(int ID_Script)
        {

            var x = (from obj in Script where obj.ID_Script == ID_Script select obj).First();
            return new CScript()
            {
                ID_Script = x.ID_Script
                ,
                ID_Conexion = x.ID_Conexion
                ,
                ID_Carpeta = x.ID_Carpeta
                ,
                Codigo = x.Codigo
                ,
                Comentarios = x.Comentarios
                ,
                Nombre = x.Nombre,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa los scripts que pertenecen a la carpeta
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CScript> GetScripts(int ID_Carpeta)
        {
            List<CScript> lista = new List<CScript>();
            var l = (from obj in Script where obj.ID_Carpeta == ID_Carpeta select obj);
            foreach (var x in l)
            {
                lista.Add(new CScript()
                {
                    ID_Script = x.ID_Script
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Codigo = x.Codigo
                    ,
                    Comentarios = x.Comentarios
                    ,
                    Nombre = x.Nombre,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa la lista de conexiones relacionadas a la conexion
        /// </summary>
        /// <param name="ID_conexion"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CScript> GetScriptsConexion(int ID_conexion)
        {
            List<CScript> lista = new List<CScript>();
            var l = (from obj in Script where obj.ID_Carpeta == ID_conexion select obj);
            foreach (var x in l)
            {
                lista.Add(new CScript()
                {
                    ID_Script = x.ID_Script
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Codigo = x.Codigo
                    ,
                    Comentarios = x.Comentarios
                    ,
                    Nombre = x.Nombre,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todos los scripts
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CScript> GetScripts()
        {
            List<CScript> lista = new List<CScript>();
            var l = (from obj in Script select obj);
            foreach (var x in l)
            {
                lista.Add(new CScript()
                {
                    ID_Script = x.ID_Script
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Codigo = x.Codigo
                    ,
                    Comentarios = x.Comentarios
                    ,
                    Nombre = x.Nombre,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega un script
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="ID_Carpeta"></param>
        /// <param name="Codigo"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Nombre"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertScript(int ID_Conexion, int ID_Carpeta, string Codigo, string Comentarios, string Nombre)
        {
            Fmodificando = true;
            ScriptRow r = Script.NewScriptRow();
            r.ID_Conexion = ID_Conexion;
            r.ID_Carpeta = ID_Carpeta;
            r.Codigo = Codigo;
            r.Comentarios = Comentarios;
            r.Nombre = Nombre;
            Script.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ScriptInsertEvent != null)
                ScriptInsertEvent(GetScript(r.ID_Script));
            return r.ID_Script;
        }
        #endregion
        #region Update
        //actualiza el script
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateScript(int ID_Script, int ID_Conexion, int ID_Carpeta, string Codigo, string Comentarios, string Nombre)
        {
            Fmodificando = true;
            var obj = (from x in Script where x.ID_Script == ID_Script select x).First();
            obj.ID_Script = ID_Script;
            obj.ID_Conexion = ID_Conexion;
            obj.ID_Carpeta = ID_Carpeta;
            obj.Codigo = Codigo;
            obj.Comentarios = Comentarios;
            obj.Nombre = Nombre;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ScriptUpdatetEvent != null)
                ScriptUpdatetEvent(GetScript(ID_Script));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el script
        /// </summary>
        /// <param name="ID_Script"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteScript(int ID_Script)
        {
            Fmodificando = true;
            CScript script = GetScript(ID_Script);
            var obj = (from x in Script where x.ID_Script == ID_Script select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ScriptDeleteEvent != null)
                ScriptDeleteEvent(script);
        }
        #endregion
        #region Move
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void MueveScript(int id_Script, int id_Carpeta)
        {
            CScript obj = GetScript(id_Script);
            CCarpeta origen = GetCarpeta(obj.ID_Carpeta);
            CCarpeta destino = GetCarpeta(id_Carpeta);
            if (obj.ID_Carpeta == id_Carpeta)
            {
                return; //no hago nada porque ya pertenece a la carpeta
            }
            obj.ID_Carpeta = id_Carpeta;
            obj.update();
            //genero el evento
            if (ScriptMoveEvent != null)
                ScriptMoveEvent(obj, origen, destino);
        }
        #endregion
        #endregion
        #region Objeto
        #region Geters
        /// <summary>
        /// regresa el tipo de objeto por medio del nombre
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private MotorDB.EnumTipoObjeto DameTipoObjeto(string tipo)
        {
            if (MotorDB.EnumTipoObjeto.CAMPO.ToString() == tipo)
                return EnumTipoObjeto.CAMPO;
            if (MotorDB.EnumTipoObjeto.CHECK.ToString() == tipo)
                return EnumTipoObjeto.CHECK;
            if (MotorDB.EnumTipoObjeto.CODE.ToString() == tipo)
                return EnumTipoObjeto.CODE;
            if (MotorDB.EnumTipoObjeto.DATABSE.ToString() == tipo)
                return EnumTipoObjeto.DATABSE;
            if (MotorDB.EnumTipoObjeto.DEFAULT.ToString() == tipo)
                return EnumTipoObjeto.DEFAULT;
            if (MotorDB.EnumTipoObjeto.FOREIGNKEY.ToString() == tipo)
                return EnumTipoObjeto.FOREIGNKEY;
            if (MotorDB.EnumTipoObjeto.FUNCION.ToString() == tipo)
                return EnumTipoObjeto.FUNCION;
            if (MotorDB.EnumTipoObjeto.IDENTITY.ToString() == tipo)
                return EnumTipoObjeto.IDENTITY;
            if (MotorDB.EnumTipoObjeto.INDEX.ToString() == tipo)
                return EnumTipoObjeto.INDEX;
            if (MotorDB.EnumTipoObjeto.PRIMARYKEY.ToString() == tipo)
                return EnumTipoObjeto.PRIMARYKEY;
            if (MotorDB.EnumTipoObjeto.PROCEDURE.ToString() == tipo)
                return EnumTipoObjeto.PROCEDURE;
            if (MotorDB.EnumTipoObjeto.TABLA_FUNCION.ToString() == tipo)
                return EnumTipoObjeto.TABLA_FUNCION;
            if (MotorDB.EnumTipoObjeto.TABLE.ToString() == tipo)
                return EnumTipoObjeto.TABLE;
            if (MotorDB.EnumTipoObjeto.TIPEDATA.ToString() == tipo)
                return EnumTipoObjeto.TIPEDATA;
            if (MotorDB.EnumTipoObjeto.TRIGER.ToString() == tipo)
                return EnumTipoObjeto.TRIGER;
            if (MotorDB.EnumTipoObjeto.UNIQUE.ToString() == tipo)
                return EnumTipoObjeto.UNIQUE;
            if (MotorDB.EnumTipoObjeto.VIEW.ToString() == tipo)
                return EnumTipoObjeto.VIEW;
            if (MotorDB.EnumTipoObjeto.TYPE_TABLE.ToString() == tipo)
                return EnumTipoObjeto.TYPE_TABLE;
            return EnumTipoObjeto.NONE;
        }
        /// <summary>
        /// convierte la cadena al color correspondiente
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private Color GetColor(string Code)
        {
            if (Code == "")
                return Color.White; //no tiene color
            try
            {
                return System.Drawing.ColorTranslator.FromHtml(Code);
            }
            catch (System.Exception)
            {
                return Color.White;
            }

        }
        /// <summary>
        /// regresa un objeto especifico
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CObjeto GetObjeto(int ID_Objeto)
        {

            try
            {
                var l = (from obj in Objeto where obj.ID_Objeto == ID_Objeto select obj);

                if (l.Count() == 0)
                    return null;
                var x = l.First();
                return new CObjeto()
                {
                    ID_Objeto = x.ID_Objeto
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    Nombre = x.Nombre
                    ,
                    TipoObjeto = DameTipoObjeto(x.TipoObjeto)
                    ,
                    Eliminado = x.Eliminado
                    ,
                    Comentarios = x.Comentarios
                    ,
                    BKColor = GetColor(x.BKColor),
                    Modelo = this
                };
            }
            catch (System.Data.DeletedRowInaccessibleException ex)
            {
                return null;
            }
        }
        /// <summary>
        /// regresa el objeto que pertenece a la conexion por medio del nombre
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CObjeto GetObjeto(int ID_Conexion, string nombre)
        {

            var l = (from obj in Objeto where obj.ID_Conexion == ID_Conexion && obj.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim() select obj);
            if (l.Count() > 0)
            {
                var x = l.First();
                return new CObjeto()
                {
                    ID_Objeto = x.ID_Objeto
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    Nombre = x.Nombre
                    ,
                    TipoObjeto = DameTipoObjeto(x.TipoObjeto)
                    ,
                    Eliminado = x.Eliminado
                    ,
                    Comentarios = x.Comentarios
                    ,
                    BKColor = GetColor(x.BKColor),
                    Modelo = this
                };
            }
            return null;
        }
        /// <summary>
        /// regresa los objetos que pertenecen a la conexion
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjeto> GetObjetos(int ID_Conexion)
        {
            List<CObjeto> lista = new List<CObjeto>();
            var l = (from obj in Objeto where obj.ID_Conexion == ID_Conexion select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjeto()
                {
                    ID_Objeto = x.ID_Objeto
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    Nombre = x.Nombre
                    ,
                    TipoObjeto = DameTipoObjeto(x.TipoObjeto)
                    ,
                    Eliminado = x.Eliminado
                    ,
                    Comentarios = x.Comentarios
                    ,
                    BKColor = GetColor(x.BKColor),
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todos los objetos
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjeto> GetObjetos()
        {
            List<CObjeto> lista = new List<CObjeto>();
            var l = (from obj in Objeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjeto()
                {
                    ID_Objeto = x.ID_Objeto
                    ,
                    ID_Conexion = x.ID_Conexion
                    ,
                    Nombre = x.Nombre
                    ,
                    TipoObjeto = DameTipoObjeto(x.TipoObjeto)
                    ,
                    Eliminado = x.Eliminado
                    ,
                    Comentarios = x.Comentarios
                    ,
                    BKColor = GetColor(x.BKColor),
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// inserta el objeto y regresa su clave
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="Nombre"></param>
        /// <param name="TipoObjeto"></param>
        /// <param name="Eliminado"></param>
        /// <param name="Comentarios"></param>
        /// <param name="BKColor"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertObjeto(int ID_Conexion, string Nombre, MotorDB.EnumTipoObjeto TipoObjeto, bool Eliminado, string Comentarios, System.Drawing.Color BKColor, bool informar = true)
        {
            //primero checo si ya existe el objeto
            Fmodificando = true;
            var l = (from a in Objeto where a.ID_Conexion == ID_Conexion && a.Nombre == Nombre select a);
            if (l.Count() > 0)
            {
                var x = l.First();
                return x.ID_Objeto;
            }
            ObjetoRow r = Objeto.NewObjetoRow();
            r.ID_Conexion = ID_Conexion;
            r.Nombre = Nombre;
            r.TipoObjeto = TipoObjeto.ToString();
            r.Eliminado = Eliminado;
            r.Comentarios = Comentarios;
            r.BKColor = "#" + BKColor.R.ToString("X2") + BKColor.G.ToString("X2") + BKColor.B.ToString("X2");
            Objeto.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ObjetoInsertEvent != null && informar)
                ObjetoInsertEvent(GetObjeto(r.ID_Objeto));
            return r.ID_Objeto;
        }
        #endregion
        public void InformaInsertObjeto(int ID_Objeto)
        {
            if (ObjetoInsertEvent != null)
                ObjetoInsertEvent(GetObjeto(ID_Objeto));
        }
        #region Update
        /// <summary>
        /// actualiza los datos del objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <param name="ID_Conexion"></param>
        /// <param name="Nombre"></param>
        /// <param name="TipoObjeto"></param>
        /// <param name="Eliminado"></param>
        /// <param name="Comentarios"></param>
        /// <param name="BKColor"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateObjeto(int ID_Objeto, int ID_Conexion, string Nombre, MotorDB.EnumTipoObjeto TipoObjeto, bool Eliminado, string Comentarios, System.Drawing.Color BKColor, bool informar = true)
        {
            Fmodificando = true;
            var obj = (from x in Objeto where x.ID_Objeto == ID_Objeto select x).First();
            obj.ID_Objeto = ID_Objeto;
            obj.ID_Conexion = ID_Conexion;
            obj.Nombre = Nombre;
            obj.TipoObjeto = TipoObjeto.ToString();
            obj.Eliminado = Eliminado;
            obj.Comentarios = Comentarios;
            obj.BKColor = "#" + BKColor.R.ToString("X2") + BKColor.G.ToString("X2") + BKColor.B.ToString("X2");
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ObjetoUpdatetEvent != null && informar)
                ObjetoUpdatetEvent(GetObjeto(ID_Objeto));
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InformaUpdateObjeto(int ID_Objeto)
        {
            if (ObjetoUpdatetEvent != null)
                ObjetoUpdatetEvent(GetObjeto(ID_Objeto));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteObjeto(int ID_Objeto)
        {
            Fmodificando = true;
            CObjeto objetox = GetObjeto(ID_Objeto);
            var obj = (from x in Objeto where x.ID_Objeto == ID_Objeto select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ObjetoDeleteEvent != null)
                ObjetoDeleteEvent(objetox);
        }
        #endregion
        #endregion
        #region Documento
        #region Geters
        /// <summary>
        /// regresa un documento especifico
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CDocumento GetDocumento(int ID_Document)
        {

            var x = (from obj in Documento where obj.ID_Document == ID_Document select obj).First();
            return new CDocumento()
            {
                ID_Document = x.ID_Document
                ,
                ID_Carpeta = x.ID_Carpeta
                ,
                Texto = x.Texto
                ,
                Nombre = x.Nombre,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todos los documentos de la carpeta
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CDocumento> GetDocumentos(int ID_Carpeta)
        {
            List<CDocumento> lista = new List<CDocumento>();
            var l = (from obj in Documento where obj.ID_Carpeta == ID_Carpeta select obj);
            foreach (var x in l)
            {
                lista.Add(new CDocumento()
                {
                    ID_Document = x.ID_Document
                    ,
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Texto = x.Texto
                    ,
                    Nombre = x.Nombre,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todos los documentos
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CDocumento> GetDocumentos()
        {
            List<CDocumento> lista = new List<CDocumento>();
            var l = (from obj in Documento select obj);
            foreach (var x in l)
            {
                lista.Add(new CDocumento()
                {
                    ID_Document = x.ID_Document
                    ,
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    Texto = x.Texto
                    ,
                    Nombre = x.Nombre,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega un nuevo documento
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <param name="Texto"></param>
        /// <param name="Nombre"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertDocumento(int ID_Carpeta, string Texto, string Nombre)
        {
            Fmodificando = true;
            DocumentoRow r = Documento.NewDocumentoRow();
            r.ID_Carpeta = ID_Carpeta;
            r.Texto = Texto;
            r.Nombre = Nombre;
            Documento.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (DocumentoInsertEvent != null)
                DocumentoInsertEvent(GetDocumento(r.ID_Document));
            return r.ID_Document;
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos del documento
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <param name="ID_Carpeta"></param>
        /// <param name="Texto"></param>
        /// <param name="Nombre"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateDocumento(int ID_Document, int ID_Carpeta, string Texto, string Nombre)
        {
            Fmodificando = true;
            var obj = (from x in Documento where x.ID_Document == ID_Document select x).First();
            obj.ID_Document = ID_Document;
            obj.ID_Carpeta = ID_Carpeta;
            obj.Texto = Texto;
            obj.Nombre = Nombre;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (DocumentoUpdatetEvent != null)
                DocumentoUpdatetEvent(GetDocumento(ID_Document));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el documento
        /// </summary>
        /// <param name="ID_Document"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteDocumento(int ID_Document)
        {
            Fmodificando = true;
            CDocumento documento = GetDocumento(ID_Document);
            var obj = (from x in Documento where x.ID_Document == ID_Document select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (DocumentoDeleteEvent != null)
                DocumentoDeleteEvent(documento);
        }
        #endregion
        #region Move
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void MueveDocumento(int id_document, int id_Carpeta)
        {
            CDocumento obj = GetDocumento(id_document);
            CCarpeta origen = GetCarpeta(obj.ID_Carpeta);
            CCarpeta destino = GetCarpeta(id_Carpeta);
            if (obj.ID_Carpeta == id_Carpeta)
            {
                return; //no hago nada porque ya pertenece a la carpeta
            }
            obj.ID_Carpeta = id_Carpeta;
            obj.update();
            //genero el evento
            if (DocumentMoveEvent != null)
                DocumentMoveEvent(obj, origen, destino);
        }
        #endregion
        #endregion
        #region ObjetoCarpeta
        #region Geters
        /// <summary>
        /// regresa un registro especifico
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CObjetoCarpeta GetObjetoCarpeta(int ID_Carpeta, int ID_Objeto)
        {
            try
            {
                var x = (from obj in ObjetoCarpeta where obj.ID_Carpeta == ID_Carpeta && obj.ID_Objeto == ID_Objeto select obj).First();
                return new CObjetoCarpeta()
                {
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                };
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// regresa todos los objetos de la carpeta
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjetoCarpeta> GetObjetosCarpeta(int ID_Carpeta)
        {
            List<CObjetoCarpeta> lista = new List<CObjetoCarpeta>();
            var l = (from obj in ObjetoCarpeta where obj.ID_Carpeta == ID_Carpeta select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjetoCarpeta()
                {
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todos los registros
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjetoCarpeta> GetObjetoCarpetas()
        {
            List<CObjetoCarpeta> lista = new List<CObjetoCarpeta>();
            var l = (from obj in ObjetoCarpeta select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjetoCarpeta()
                {
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa la lista de carpetas donde se encuenta almacenado el objeto
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CObjetoCarpeta> GetCarpetasObjeto(int ID_Objeto)
        {
            List<CObjetoCarpeta> lista = new List<CObjetoCarpeta>();
            var l = (from obj in ObjetoCarpeta where obj.ID_Objeto == ID_Objeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CObjetoCarpeta()
                {
                    ID_Carpeta = x.ID_Carpeta
                    ,
                    ID_Objeto = x.ID_Objeto,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega un registro
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertObjetoCarpeta(int ID_Carpeta, int ID_Objeto)
        {
            Fmodificando = true;
            ObjetoCarpetaRow r = ObjetoCarpeta.NewObjetoCarpetaRow();
            r.ID_Carpeta = ID_Carpeta;
            r.ID_Objeto = ID_Objeto;
            ObjetoCarpeta.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (ObjetoCarpetaInsertEvent != null)
                ObjetoCarpetaInsertEvent(GetObjetoCarpeta(r.ID_Carpeta, r.ID_Objeto));
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateObjetoCarpeta(int ID_Carpeta, int ID_Objeto)
        {
            Fmodificando = true;
            var obj = (from x in ObjetoCarpeta where x.ID_Carpeta == ID_Carpeta && x.ID_Objeto == ID_Objeto select x).First();
            obj.ID_Carpeta = ID_Carpeta;
            obj.ID_Objeto = ID_Objeto;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (ObjetoCarpetaUpdatetEvent != null)
                ObjetoCarpetaUpdatetEvent(GetObjetoCarpeta(ID_Carpeta, ID_Objeto));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el registro
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <param name="ID_Objeto"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteObjetoCarpeta(int ID_Carpeta, int ID_Objeto)
        {
            Fmodificando = true;
            CObjetoCarpeta objeto = GetObjetoCarpeta(ID_Carpeta, ID_Objeto);
            var obj = (from x in ObjetoCarpeta where x.ID_Carpeta == ID_Carpeta && x.ID_Objeto == ID_Objeto select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (ObjetoCarpetaDeleteEvent != null)
                ObjetoCarpetaDeleteEvent(objeto);
        }
        #endregion
        #region Move
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void MueveObjeto(int id_objeto, int id_origen, int id_destino)
        {
            CObjetoCarpeta obj = GetObjetoCarpeta(id_origen, id_objeto);
            CObjetoCarpeta obj2 = GetObjetoCarpeta(id_destino, id_objeto);
            if (obj == null || obj2 != null)
                return;
            obj.delete();
            InsertObjetoCarpeta(id_destino, id_objeto);
        }
        #endregion
        #endregion
        #region CodigoObjeto
        #region Geters
        /// <summary>
        /// extrae un solo objeto
        /// </summary>
        /// <param name="ID_Codigo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CCodigoObjeto GetCodigoObjeto(int ID_Codigo)
        {
            bool ok = true;
            do
            {
                ok = true;
                try
                {
                    var l = (from obj in CodigoObjeto where obj.ID_Codigo == ID_Codigo select obj);
                    if (l.Count() == 0)
                        return null;
                    var x = l.First();
                    return new CCodigoObjeto()
                    {
                        ID_Objeto = x.ID_Objeto
                        ,
                        ID_Codigo = x.ID_Codigo
                        ,
                        Fecha = x.Fecha
                        ,
                        Codigo = x.Codigo
                        ,
                        Visto = x.Visto
                        ,
                        Cometarios = x.Cometarios,
                        Modelo = this
                    };
                }
                catch (System.Exception)
                {
                    ok = false;
                }
            }
            while (ok == false);
            return null;
        }
        /// <summary>
        /// regresa el ultimo Historial del codigo del objeto. Regresa null si no hay historial
        /// </summary>
        /// <param name="ID_Codigo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CCodigoObjeto GetUltimoHistorial(int ID_Codigo)
        {
            var l = (from obj in CodigoObjeto where obj.ID_Codigo == ID_Codigo select obj).OrderByDescending(obj => obj.Fecha);
            if (l.Count() == 0)
                return null;
            var x = l.First();
            return new CCodigoObjeto()
            {
                ID_Objeto = x.ID_Objeto
                ,
                ID_Codigo = x.ID_Codigo
                ,
                Fecha = x.Fecha
                ,
                Codigo = x.Codigo
                ,
                Visto = x.Visto
                ,
                Cometarios = x.Cometarios,
                Modelo = this
            };
        }
        /// <summary>
        /// extrae todos los codigos del objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCodigoObjeto> GetCodigoObjetos(int ID_Objeto)
        {
            List<CCodigoObjeto> lista = new List<CCodigoObjeto>();
            var l = (from obj in CodigoObjeto where obj.ID_Objeto == ID_Objeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CCodigoObjeto()
                {
                    ID_Objeto = x.ID_Objeto
                    ,
                    ID_Codigo = x.ID_Codigo
                    ,
                    Fecha = x.Fecha
                    ,
                    Codigo = x.Codigo
                    ,
                    Visto = x.Visto
                    ,
                    Cometarios = x.Cometarios,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// se trae todos los codigos
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCodigoObjeto> GetCodigoObjetos()
        {
            List<CCodigoObjeto> lista = new List<CCodigoObjeto>();
            var l = (from obj in CodigoObjeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CCodigoObjeto()
                {
                    ID_Objeto = x.ID_Objeto
                    ,
                    ID_Codigo = x.ID_Codigo
                    ,
                    Fecha = x.Fecha
                    ,
                    Codigo = x.Codigo
                    ,
                    Visto = x.Visto
                    ,
                    Cometarios = x.Cometarios,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega un objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <param name="?"></param>
        /// <param name="Fecha"></param>
        /// <param name="Codigo"></param>
        /// <param name="Visto"></param>
        /// <param name="Cometarios"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertCodigoObjeto(int ID_Objeto, DateTime Fecha, string Codigo, bool Visto, string Cometarios, bool informa = true)
        {
            Fmodificando = true;
            CodigoObjetoRow r = CodigoObjeto.NewCodigoObjetoRow();
            r.ID_Objeto = ID_Objeto;
            r.Fecha = Fecha;
            r.Codigo = Codigo;
            r.Visto = Visto;
            r.Cometarios = Cometarios;
            CodigoObjeto.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (CodigoObjetoInsertEvent != null && informa)
                CodigoObjetoInsertEvent(GetCodigoObjeto(r.ID_Codigo));
            return r.ID_Codigo;
        }
        /// <summary>
        /// avisa a tosods los suscriptores que se agrego codigo al historial
        /// </summary>
        /// <param name="id_Codigo"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InformaInsertCodigoObjeto(int id_Codigo)
        {
            if (CodigoObjetoInsertEvent != null)
                CodigoObjetoInsertEvent(GetCodigoObjeto(id_Codigo));
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <param name="ID_Codigo"></param>
        /// <param name="Fecha"></param>
        /// <param name="Codigo"></param>
        /// <param name="Visto"></param>
        /// <param name="Cometarios"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateCodigoObjeto(int ID_Objeto, int ID_Codigo, DateTime Fecha, string Codigo, bool Visto, string Cometarios)
        {
            Fmodificando = true;
            var obj = (from x in CodigoObjeto where x.ID_Codigo == ID_Codigo select x).First();
            obj.ID_Objeto = ID_Objeto;
            obj.ID_Codigo = ID_Codigo;
            obj.Fecha = Fecha;
            obj.Codigo = Codigo;
            obj.Visto = Visto;
            obj.Cometarios = Cometarios;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (CodigoObjetoUpdatetEvent != null)
                CodigoObjetoUpdatetEvent(GetCodigoObjeto(ID_Codigo));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el codigo
        /// </summary>
        /// <param name="ID_Codigo"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteCodigoObjeto(int ID_Codigo)
        {
            Fmodificando = true;
            CCodigoObjeto codigo = GetCodigoObjeto(ID_Codigo);
            var obj = (from x in CodigoObjeto where x.ID_Codigo == ID_Codigo select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (CodigoObjetoDeleteEvent != null)
                CodigoObjetoDeleteEvent(codigo);
        }
        #endregion
        #endregion
        #region CodigoEditable
        #region Geters
        /// <summary>
        /// regresa un registro unico
        /// </summary>
        /// <param name="ID_CodigoEditable"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public CCodigoEditable GetCodigoEditable(int ID_CodigoEditable)
        {

            var x = (from obj in CodigoEditable where obj.ID_CodigoEditable == ID_CodigoEditable select obj).First();
            return new CCodigoEditable()
            {
                ID_CodigoEditable = x.ID_CodigoEditable
                ,
                ID_Objeto = x.ID_Objeto
                ,
                Fecha = x.Fecha
                ,
                Nombre = x.Nombre
                ,
                Codigo = x.Codigo
                ,
                Comentarios = x.Comentarios,
                Modelo = this
            };
        }
        /// <summary>
        /// regresa todos los codigos editables del objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCodigoEditable> GetCodigoEditables(int ID_Objeto)
        {
            List<CCodigoEditable> lista = new List<CCodigoEditable>();
            var l = (from obj in CodigoEditable where obj.ID_Objeto == ID_Objeto select obj);
            foreach (var x in l)
            {
                lista.Add(new CCodigoEditable()
                {
                    ID_CodigoEditable = x.ID_CodigoEditable
                    ,
                    ID_Objeto = x.ID_Objeto
                    ,
                    Fecha = x.Fecha
                    ,
                    Nombre = x.Nombre
                    ,
                    Codigo = x.Codigo
                    ,
                    Comentarios = x.Comentarios,
                    Modelo = this
                });
            }
            return lista;
        }
        /// <summary>
        /// regresa todos los codigos editables
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<CCodigoEditable> GetCodigoEditables()
        {
            List<CCodigoEditable> lista = new List<CCodigoEditable>();
            var l = (from obj in CodigoEditable select obj);
            foreach (var x in l)
            {
                lista.Add(new CCodigoEditable()
                {
                    ID_CodigoEditable = x.ID_CodigoEditable
                    ,
                    ID_Objeto = x.ID_Objeto
                    ,
                    Fecha = x.Fecha
                    ,
                    Nombre = x.Nombre
                    ,
                    Codigo = x.Codigo
                    ,
                    Comentarios = x.Comentarios,
                    Modelo = this
                });
            }
            return lista;
        }
        #endregion
        #region Insert
        /// <summary>
        /// agrega un dodigo al objeto
        /// </summary>
        /// <param name="ID_Objeto"></param>
        /// <param name="Fecha"></param>
        /// <param name="Nombre"></param>
        /// <param name="Codigo"></param>
        /// <param name="Comentarios"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertCodigoEditable(int ID_Objeto, DateTime Fecha, string Nombre, string Codigo, string Comentarios)
        {
            Fmodificando = true;
            CodigoEditableRow r = CodigoEditable.NewCodigoEditableRow();
            r.ID_Objeto = ID_Objeto;
            r.Fecha = Fecha;
            r.Nombre = Nombre;
            r.Codigo = Codigo;
            r.Comentarios = Comentarios;
            CodigoEditable.Rows.Add(r);
            ActualizaX();
            //genero el evento
            if (CodigoEditableInsertEvent != null)
                CodigoEditableInsertEvent(GetCodigoEditable(r.ID_CodigoEditable));
            return r.ID_CodigoEditable;
        }
        #endregion
        #region Update
        /// <summary>
        /// actualiza los datos del codigo
        /// </summary>
        /// <param name="ID_CodigoEditable"></param>
        /// <param name="ID_Objeto"></param>
        /// <param name="Fecha"></param>
        /// <param name="Nombre"></param>
        /// <param name="Codigo"></param>
        /// <param name="Comentarios"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateCodigoEditable(int ID_CodigoEditable, int ID_Objeto, DateTime Fecha, string Nombre, string Codigo, string Comentarios)
        {
            Fmodificando = true;
            var obj = (from x in CodigoEditable where x.ID_CodigoEditable == ID_CodigoEditable select x).First();
            obj.ID_CodigoEditable = ID_CodigoEditable;
            obj.ID_Objeto = ID_Objeto;
            obj.Fecha = Fecha;
            obj.Nombre = Nombre;
            obj.Codigo = Codigo;
            obj.Comentarios = Comentarios;
            obj.AcceptChanges();
            ActualizaX();
            //genero el evento
            if (CodigoEditableUpdatetEvent != null)
                CodigoEditableUpdatetEvent(GetCodigoEditable(ID_CodigoEditable));
        }
        #endregion
        #region Delete
        /// <summary>
        /// elimina el codigo editable.
        /// </summary>
        /// <param name="ID_CodigoEditable"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteCodigoEditable(int ID_CodigoEditable)
        {
            Fmodificando = true;
            CCodigoEditable codigo = GetCodigoEditable(ID_CodigoEditable);
            var obj = (from x in CodigoEditable where x.ID_CodigoEditable == ID_CodigoEditable select x).First();
            obj.Delete();
            ActualizaX();
            //genero el evento
            if (CodigoEditableDeleteEvent != null)
                CodigoEditableDeleteEvent(codigo);
        }
        #endregion
        #endregion
        #endregion
        #region Reportes
        /// <summary>
        /// regresa el mapeo de todos los objetos encontrados
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public DataTable RepoteMapeo()
        {
            List<CCarpeta> carpetas = GetCarpetas();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nivel1");
            foreach (CCarpeta carpeta in carpetas)
            {
                carpeta.RepoteMapeo(tabla, null, 0);
            }
            return tabla;
        }
        #endregion
        #region Manejo de cadenas excluidas
        public void InsertExcluidos(string s)
        {
            var l = (from x in Excluidos where x.Texto.ToUpper().Trim() == s.ToUpper().Trim() select x);
            if (l.Count() > 0)
                return; //ya existe
            ExcluidosRow dr = Excluidos.NewExcluidosRow();
            dr.Texto = s;
            Excluidos.Rows.Add(dr);
            ActualizaX();
            if (ExcluidoInsertEvent != null)
                ExcluidoInsertEvent(s);
        }
        public void DeleteExcluidos(string s)
        {
            var l = (from x in Excluidos where x.Texto.ToUpper().Trim() == s.ToUpper().Trim() select x);
            if (l.Count() == 0)
                return; //no existe
            var z = l.First();
            z.Delete();
            ActualizaX();
            if (ExluidoDeleteEvent != null)
                ExluidoDeleteEvent(s);
        }
        public List<string> GetExcluidos()
        {
            List<string> lr = new List<string>();
            var l = (from x in Excluidos select x);
            foreach (ExcluidosRow s in l)
            {
                lr.Add(s.Texto);
            }
            return lr;
        }
        #endregion
    }
}
