using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.BuscadorDependencias
{
    public delegate void OnBusquedaDependenciaEvent(CBuscadorDependencias sender);
    public delegate void OnObjetoDependenciaEncontradoEvent(CBuscadorDependencias sender, CObjetoBusquedaDependencia objeto);
    public delegate void OnObjetoDependenciaMensajeEvent(CBuscadorDependencias sender, string msg);
    public partial class CBuscadorDependencias : Component
    {
        private string fileNameConfig
        {
            get
            {
                return Application.StartupPath + "\\BuscadorDependenciasDs.xml";
            }
        }

        public event OnBusquedaDependenciaEvent OnMotorChange;
        public event OnObjetoDependenciaEncontradoEvent OnObjetoEncontrado;
        public event OnObjetoDependenciaEncontradoEvent OnObjetoAnalizado;
        public event OnBusquedaDependenciaEvent OnInicioBusqueda;
        public event OnBusquedaDependenciaEvent OnFinBusqueda;
        public event OnObjetoDependenciaMensajeEvent OnMensaje;
        List<MotorDB.IMotorDB> Bases;
        /// <summary>
        /// pila donde se van a ir agregando los objetos que hay que buscar
        /// </summary>
        List<CObjetoBusquedaDependencia> Pila;
        /// <summary>
        /// Lista donde se elmacenan los objetos que ya se procesaron y que servira para evitar busquedas repetidas
        /// //si ya esta en esta lista ya no se vuelve a buscar
        /// </summary>
        List<CObjetoProcesado> Procesados;
        /// <summary>
        /// se consentran las busquedas de objetos encontrados en las bases de datos
        /// </summary>
        List<Buscador.CObjetoBusquedaAvanzado> resultadoBusqueda;
        private bool Buscando = true;

        public CBuscadorDependencias()
        {

            Bases = new List<MotorDB.IMotorDB>();
            InitializeComponent();
            CargaDataSet();
        }
        /// <summary>
        /// objeto en donde va a comenzar la busqueda de dependencias
        /// </summary>
        public String ObjetoInicial
        {
            get;
            set;
        }
        #region Gestion de los motores de bases de datos
        /// <summary>
        /// Agrega una base de datos en la cual se tiene que hacer la busqueda
        /// </summary>
        /// <param name="motor"></param>
        public void AgregaMotor(MotorDB.IMotorDB motor)
        {
            var r = (from m in Bases.AsEnumerable() where m.GetConecctionString() == motor.GetConecctionString() select m);
            if (r.Count() == 0)
            {
                Bases.Add(motor);
                EventoMotor();
            }
        }
        /// <summary>
        /// quita una base de datos dela busqueda
        /// </summary>
        /// <param name="motor"></param>
        public void QuitaMotor(MotorDB.IMotorDB motor)
        {
            var r = (from m in Bases.AsEnumerable() where m.GetConnectionName() == motor.GetConnectionName() select m).Single();
            if (r != null)
            {
                Bases.Remove(r);
                EventoMotor();
            }
        }
        /// <summary>
        /// regresa la lista de bases de datos que se tiene registradas
        /// </summary>
        /// <returns></returns>
        public List<MotorDB.IMotorDB> DameMotores()
        {
            return Bases;
        }
        private void EventoMotor()
        {
            if (OnMotorChange != null)
                OnMotorChange(this);
        }
        #endregion
        private void ObjetoEncontrado(CObjetoBusquedaDependencia obj)
        {
            if (OnObjetoEncontrado != null)
            {
                OnObjetoEncontrado(this, obj);
            }
        }
        /// <summary>
        /// Inicia la busqueda
        /// </summary>
        public void Buscar()
        {
            if (BuscadorBk.IsBusy == false)
            {
                CargaDataSet();
                if (OnInicioBusqueda != null)
                    OnInicioBusqueda(this);
                BuscadorBk.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Cancela la busqueda
        /// </summary>
        public void Cancelar()
        {
            Buscando = false;
        }

        private void BuscadorBk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnFinBusqueda != null)
                OnFinBusqueda(this);
        }

        private void BuscadorBk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (OnObjetoEncontrado != null)
            {
                CObjetoBusquedaDependencia obj = (CObjetoBusquedaDependencia)e.UserState;
                OnObjetoEncontrado(this, obj);
            }
        }
        private bool ObjetoAceptable(MotorDB.EnumTipoObjeto tipo)
        {
            switch (tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    return true;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    return true;
                case MotorDB.EnumTipoObjeto.TABLA_FUNCION:
                    return true;
                case MotorDB.EnumTipoObjeto.TABLE:
                    return true;
                case MotorDB.EnumTipoObjeto.TIPEDATA:
                    return true;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    return true;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    return true;
                case MotorDB.EnumTipoObjeto.VIEW:
                    return true;
            }
            return false;
        }
        private void BuscaEnMotor(MotorDB.IMotorDB motor, CObjetoBusquedaDependencia obj)
        {
            String nombremotor = motor.GetDataBseName();
            //lista donde voy a concentrar los resultados
            List<MotorDB.CObjeto> l = motor.Buscar(obj.Nombre);
            //de la lista de objetos, solo tomo los que tiene exactamente el mismo nombre
            foreach (MotorDB.CObjeto obj2 in l)
            {
                if (Buscando == false)
                    return;
                if (obj.Nombre.ToUpper().Trim() == obj2.Nombre.ToUpper().Trim() && ObjetoAceptable(obj2.Tipo))
                {
                    resultadoBusqueda.Add(new Buscador.CObjetoBusquedaAvanzado()
                        {
                            Motor = motor,
                            Nombre = obj2.Nombre,
                            Tipo = obj2.Tipo
                        });
                }
            }
            nombremotor = "";
        }
        private string obtenCodigoFuente(CObjetoBusquedaDependencia obj)
        {
            string codigoFuente = "";
            switch (obj.Tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    codigoFuente = obj.Motor.DameCodigoFuncction(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    codigoFuente = obj.Motor.DameCodigoStoreProcedure(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    codigoFuente = obj.Motor.DameCodigoTrigger(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    codigoFuente = obj.Motor.DameCodigoVista(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    break;
            }
            return codigoFuente;

        }
        /// <summary>
        /// regresa true si el lexema es una palabra reservada
        /// </summary>
        /// <param name="lex"></param>
        /// <returns></returns>
        private bool palabraReservada(Compiler.Lexer.Lexema lex, MotorDB.IMotorDB motor)
        {
            List<MotorDB.CTipoDato> l = motor.DameTiposDato();
            foreach (MotorDB.CTipoDato td in l)
            {
                if (td.Nombre.ToUpper().Trim() == lex.Texto.ToUpper().Trim())
                    return true;
            }
            List<string> l2 = motor.DamePalabrasReservadas();
            foreach (string s in l2)
            {
                if (s.ToUpper().Trim() == lex.Texto.ToUpper().Trim())
                    return true;

            }
            return false;
        }
        private bool estaProcesado(string Texto, CObjetoBusquedaDependencia origen)
        {
            foreach (CObjetoProcesado obj in Procesados)
            {
                if (obj.Objeto.Nombre.ToUpper().Trim() == Texto.ToUpper().Trim() && obj.Origen.ToUpper().Trim() == origen.Nombre.ToUpper().Trim() && obj.Objeto.Motor.GetDataBseName() == origen.Motor.GetDataBseName() && ManagerConnect.ControladorConexiones.DamePropiedadesMotor(obj.Objeto.Motor).Grupo == ManagerConnect.ControladorConexiones.DamePropiedadesMotor(origen.Motor).Grupo)
                    return true;
            }
            return false;

        }
        private bool estaEnPila(string texto, CObjetoBusquedaDependencia padre)
        {
            foreach (CObjetoBusquedaDependencia obj in Pila)
            {
                if (obj.Nombre.ToUpper().Trim() == texto.ToUpper().Trim() && obj.objetoPadre.Nombre.ToUpper().Trim() == padre.Nombre.ToUpper().Trim() && obj.objetoPadre.Motor.GetDataBseName() == padre.Motor.GetDataBseName() && ManagerConnect.ControladorConexiones.DamePropiedadesMotor(obj.objetoPadre.Motor).Grupo == ManagerConnect.ControladorConexiones.DamePropiedadesMotor(padre.Motor).Grupo)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// verifica si el objeto esta en excluidos
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool existeExcluido(string nombre)
        {
            bool ok = true;
            do
            {
                ok = true;
                try
                {
					DataTable tabla = dataSet1.Tables["Excluido"];
					foreach (DataRow dr in tabla.Rows)
					{
						if (dr["objeto"].ToString().ToUpper().Trim() == nombre.ToUpper().Trim())
						{
							return true;
						}
					}
                }
                catch (System.Exception ex)
                {
                    ok = false; //ocurrio un error
                }
            } while (ok == false);
            return false;
        }
        /// <summary>
        /// regresa el listado de objetos excluidos
        /// </summary>
        /// <returns></returns>
        public List<string> DameExcluidos()
        {
            List<string> l = new List<string>();
            DataTable tabla = dataSet1.Tables["Excluido"];
            foreach (DataRow dr in tabla.Rows)
            {
                l.Add(dr["objeto"].ToString());
            }
            return l;
        }
        /// <summary>
        /// quita el objetos de los excluidos
        /// </summary>
        /// <param name="nombre"></param>
        public void EliminaExcluido(string nombre)
        {
            CargaDataSet();
            DataTable tabla = dataSet1.Tables["Excluido"];
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["objeto"].ToString().ToUpper().Trim() == nombre.ToUpper().Trim())
                {
                    tabla.Rows.Remove(dr);
                }
            }
            GuardaDataSet();
        }
        /// <summary>
        /// carga el archivo del datase
        /// </summary>
        private void CargaDataSet()
        {
            if (System.IO.File.Exists(fileNameConfig))
            {
                dataSet1.Clear();
                dataSet1.ReadXml(fileNameConfig);
            }
        }
        /// <summary>
        /// guarda el dataset en un archivo
        /// </summary>
        private void GuardaDataSet()
        {
            dataSet1.WriteXml(fileNameConfig);
        }
        /// <summary>
        /// muestra la lista de excluciones
        /// </summary>
        public void AdministraExcluidos()
        {
            FormExcluidos dlg = new FormExcluidos(this);
            dlg.ShowDialog();
        }
        private void BuscadorBk_DoWork(object sender, DoWorkEventArgs e)
        {
            //aqui esta lo bueno
            //recorro cada una de las bases y les voy aplicando los filtros
            //lo ejecuto en paralelo para incrementar la velocidad
            #region incializa variables
            if (Pila == null)
            {
                Pila = new List<CObjetoBusquedaDependencia>();
            }
            else
            {
                Pila.Clear();
            }
            if (Procesados == null)
            {
                Procesados = new List<CObjetoProcesado>();
            }
            else
            {
                Procesados.Clear();
            }
            CObjetoBusquedaDependencia obji = new CObjetoBusquedaDependencia()
            {
                objetoPadre = null,
                Motor = null,
                Nombre = ObjetoInicial

            };
            Pila.Add(obji);
            #endregion
            //recorro cada objeto de la pila par hacer la busqueda
            while (Pila.Count > 0)
            {
                if (Buscando == false)
                    return;
                //me traigo el primer objeto de la pila
                CObjetoBusquedaDependencia obj = Pila[0];

                Pila.RemoveAt(0);
                if (resultadoBusqueda == null)
                    resultadoBusqueda = new List<Buscador.CObjetoBusquedaAvanzado>();
                else
                    resultadoBusqueda.Clear();
                //busco el objeto en las bases de datos
                //esto es con programacion en paralelo -> Es rapido
                Parallel.ForEach(Bases, (motor) =>
                {
                    if (Buscando == false)
                        return;
                    BuscaEnMotor(motor, obj);

                });
                //recorro los objetos encontrados en las bases dedatos
                foreach (Buscador.CObjetoBusquedaAvanzado obj3 in resultadoBusqueda)
                {
                    if (Buscando == false)
                        return;
                    ManagerConnect.CPropiedadesMotor propiedades = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(obj3.Motor);
                    string nombrex = propiedades.Grupo + "->" + obj3.Motor.GetDataBseName() + "->" + obj3.Nombre;
                    if (existeExcluido(nombrex) == false)
                    {
                        CObjetoBusquedaDependencia obj4 = new CObjetoBusquedaDependencia()
                        {
                            Motor = obj3.Motor
                             ,
                            Nombre = obj3.Nombre
                             ,
                            objetoPadre = obj.objetoPadre
                             ,
                            Tipo = obj3.Tipo
                             ,
                            NombreLargo = nombrex //obj.NombreLargo
                        };
                        ObjetoEncontrado(obj4);
                        //lo mando a analizar
                        analisaCodigo(obj4);
                        if(OnObjetoAnalizado!=null)
                        {
                            OnObjetoAnalizado(this, obj4);
                        }
                    }
                }
            }
            //y esto es con tareas que tambien se ejecutan en paralelo pero son mucho mas rapidas
            //pero no se espera a que terminen las consultas porque las hace en segundo plano
            //foreach (MotorDB.IMotorDB motor in Bases)
            //{
            //    Task t = Task.Factory.StartNew(() => BuscaEnMotor(motor));
            //}
        }
        private List<CObjetoBusquedaDependencia> Analizados;
        private bool EstaEnAnalizados(CObjetoBusquedaDependencia obj)
        {
            if (Analizados == null)
                return false;
            foreach(CObjetoBusquedaDependencia analizado in Analizados)
            {
                if (obj.Motor.GetConecctionString() == analizado.Motor.GetConecctionString() && obj.Nombre == analizado.Nombre)
                    return true;
            }
            return false;
        }
        private void analisaCodigo(CObjetoBusquedaDependencia obj)
        {
            if (Analizados == null)
                Analizados = new List<CObjetoBusquedaDependencia>();
            if(EstaEnAnalizados(obj))
            {
                return; //ya no lo analizo
            }
            Analizados.Add(obj);
            //si es tabla, no tiene caso que la analise
            if (obj.Tipo == MotorDB.EnumTipoObjeto.TABLE)
                return;
            if (OnMensaje != null)
            {
                ManagerConnect.CPropiedadesMotor propiedades = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(obj.Motor);
                if (obj.objetoPadre != null)
                {
                    ManagerConnect.CPropiedadesMotor propiedadesPadre = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(obj.objetoPadre.Motor);
                    OnMensaje(this, "analizando: " + propiedadesPadre.Grupo + "." + obj.objetoPadre.Motor.GetDataBseName() + "." + obj.objetoPadre.Nombre + " -> " + propiedades.Grupo + "." + obj.Motor.GetDataBseName() + "." + obj.Nombre+" restan "+Pila.Count.ToString()+" por analizar");
                }
                else
                {
                    OnMensaje(this, "analizando: " + propiedades.Grupo + "." + obj.Motor.GetDataBseName() + "." + obj.Nombre + " restan " + Pila.Count.ToString() + " por analizar");

                }
            }
            //lo agrego a los procesados
            string papa = "";
            if (obj.objetoPadre != null)
                papa = obj.objetoPadre.Nombre;
            Procesados.Add(new CObjetoProcesado()
            {
                Objeto = obj,
                Origen = papa
            });
            //me traigo el codigo fuente
            string codigoFuente = obtenCodigoFuente(obj);
            if (codigoFuente.Trim() == "")
                return; //no hago nada porque esta vacio
            //analizo el codigo fuente
            Compiler.Lexer.Lecxer lecxer = new Compiler.Lexer.Lecxer();
            lecxer.Cadena = codigoFuente;
            //recorro cada lexema
            foreach (Compiler.Lexer.Lexema lex in lecxer)
            {
                if (Buscando == false)
                    return;
                if (lex.Tipo == Compiler.Lexer.LEXTIPE.IDENTIFICADOR)
                {
                    if (palabraReservada(lex, obj.Motor) == false)
                    {
                        //no es palabra reservada,
                        //veo si no lo he procesado aun
                        if (estaProcesado(lex.Texto, obj) == false)
                        {
                            if (estaEnPila(lex.Texto, obj) == false)
                            {
                                if (lex.Texto.ToUpper().Trim() != obj.Nombre.ToUpper().Trim())
                                {


                                    //lo agrego a la pila para ser procesado
                                    Pila.Add(new CObjetoBusquedaDependencia()
                                    {
                                        //  Motor = obj.Motor,
                                        Nombre = lex.Texto,
                                        NombreLargo = "",
                                        objetoPadre = new Buscador.CObjetoBusquedaAvanzado()
                                        {
                                            Motor = obj.Motor,
                                            Nombre = obj.Nombre,
                                            Tipo = obj.Tipo
                                        }
                                    });
                                }
                            }
                        }


                    }
                }
            }

        }
        /// <summary>
        /// agrega el objeto a la lista de excludos
        /// </summary>
        /// <param name="nombre"></param>
        public void AgregarExcluido(string nombre)
        {
            CargaDataSet();
            if (existeExcluido(nombre))
                return;
            //lo agrego
            DataTable tabla = dataSet1.Tables["Excluido"];
            DataRow dr = tabla.NewRow();
            dr["objeto"] = nombre;
            tabla.Rows.Add(dr);
            tabla.AcceptChanges();
            GuardaDataSet();
            //ahora lo quito de la pila
            for(int i=Pila.Count-1;i>=0;i--)
            {
                CObjetoBusquedaDependencia obj = Pila[i];
                if (obj.Nombre.ToUpper().Trim()==nombre.ToUpper().Trim())
                {
                    Pila.RemoveAt(i);
                }
            }
        }
    }
}
   