using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    public partial class CAnalizadorDependencias : Component, IAnalizer
    {
        List<ObjetosModelo.CObjeto> marcarlos;
        private bool Salir = false;
        ObjetosModelo.CObjeto ObjetoActual;
        List<ObjetosModelo.CObjeto> Objetos;
        ObjetosModelo.AppModel Modelo;
        List<CMotorConexion> MotoresConexiones;
        public event AnalizerEventString AnalizerEventStringmsg;
        public event AnalizerEvent iniciaAnalisisevent;
        public event AnalizerEvent terminaAnalisisevent;
        List<String> mensajes;
        bool procesando;
        List<BuscadorDependencias.CObjetoBusquedaDependencia> ObjetosEncontrados;
        public CAnalizadorDependencias(ObjetosModelo.AppModel modelo, List<ObjetosModelo.CObjeto> objetos)
        {
            Modelo = modelo;
            Modelo.ExcluidoInsertEvent += new ObjetosModelo.OnExcluidoEvent(ExcluidoAgregado);
            Objetos = objetos;
            mensajes = new List<string>();
            ObjetosEncontrados = new List<BuscadorDependencias.CObjetoBusquedaDependencia>();
            InitializeComponent();
        }
        private void ExcluidoAgregado(string s)
        {
            cBuscadorDependencias1.AgregarExcluido(s);
        } 
        public CAnalizadorDependencias(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #region Implementacion de la interface IAnalizer
        public void IniciaAnalisis()
        {
            Salir = false;
            //primero cargo la lista de conexiones
            if (iniciaAnalisisevent != null)
                iniciaAnalisisevent();
            if (AnalizerEventStringmsg != null)
                AnalizerEventStringmsg("Inicializa Mapeo de objetos en Base de datos");
            procesando = true;
            CargaExcluidos();
            CargaConexiones();
            MapeaObjeto();
            backgroundWorker1.RunWorkerAsync();
        }
        private void CargaExcluidos()
        {
            List<string> l = Modelo.GetExcluidos();
            foreach(string s in l)
            {
                cBuscadorDependencias1.AgregarExcluido(s);
            }
        }		 
        public void AddMessageEvent(AnalizerEventString e)
        {
            AnalizerEventStringmsg += e;
        }

        public void AddInitAnalisisEvent(AnalizerEvent e)
        {
            iniciaAnalisisevent += e;
        }

        public void AddEndAnalisisEvent(AnalizerEvent e)
        {
            terminaAnalisisevent += e;
        }

        public void cancelarAnalisis()
        {
            Salir = true;
            cBuscadorDependencias1.Cancelar();
        }
        #endregion
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
                    cBuscadorDependencias1.AgregaMotor(motor);
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
        /// regrea la conexion que le corresponde al motor
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>

        private ObjetosModelo.CConexion BuscaConexion(MotorDB.IMotorDB motor)
        {
            foreach (CMotorConexion obj in MotoresConexiones)
            {
                if (obj.Motor == motor)
                {
                    return obj.Conexion;
                }
            }
            return null;
        }
        private void mesageErrorDb(MotorDB.IMotorDB m, string msg)
        {

            Mensaje("ERROR: " + m.GetDataBseName() + "->" + msg);
        }
        /// <summary>
        /// manda un mensaje de texto
        /// </summary>
        /// <param name="msg"></param>
        private void Mensaje(string msg)
        {
            if (AnalizerEventStringmsg != null)
                AnalizerEventStringmsg(msg);
        }
        /// <summary>
        /// marca el objeto para indicar que ya fue analizado
        /// </summary>
        private void MarcaObjetoAnalizado()
        {
            if (ObjetoActual == null)
            {
                //no hay ningun objeto a marcar
                return;
            }
            ObjetoActual.BKColor = Color.YellowGreen;
            ObjetoActual.update();
        }
        private void DesMarcaObjetoAnalizado()
        {
            if (ObjetoActual == null)
            {
                //no hay ningun objeto a marcar
                return;
            }
            ObjetoActual.BKColor = Color.White;
            ObjetoActual.update();
        }
        /// <summary>
        /// obtiene el primer objeto de la lista y lo mapea
        /// </summary>
        private void MapeaObjeto()
        {
            MarcaObjetoAnalizado();
            do
            {
                if (Salir)
                {
                    DesMarcaObjetoAnalizado();
                    if (terminaAnalisisevent != null)
                        terminaAnalisisevent();
                    return;
                }
                if (Objetos.Count() == 0)
                {
                    //ya termine de mapear los objetos
                    if (terminaAnalisisevent != null)
                        terminaAnalisisevent();
                    procesando = false;
                    return;
                }
                //me traigo el ID del objeto
                int id_objeto = Objetos[0].ID_Objeto;
                Objetos.RemoveAt(0);
                //me traigo el Objeto para verificar si no se ha mapeado
                ObjetosModelo.CObjeto obj = Modelo.GetObjeto(id_objeto);
                if (obj.BKColor.R != Color.YellowGreen.R || obj.BKColor.G != Color.YellowGreen.G || obj.BKColor.B != Color.YellowGreen.B)
                {
                    //asigno el objeto actual y me salgo del bucle
                    ObjetoActual = obj;
                    break;
                }

            }
            while (true);
            //mando a analizar el objeto
            Mensaje("Analizando: " + ObjetoActual.GetNombreLargo());
            cBuscadorDependencias1.ObjetoInicial = ObjetoActual.Nombre;
            cBuscadorDependencias1.Buscar();
        }

        private void cBuscadorDependencias1_OnFinBusqueda(BuscadorDependencias.CBuscadorDependencias sender)
        {
            MapeaObjeto();
        }

        private void cBuscadorDependencias1_OnMensaje(BuscadorDependencias.CBuscadorDependencias sender, string msg)
        {
            mensajes.Add(msg);
        }
        /// <summary>
        /// agrega el objeto al modelo
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="hijo"></param>
        private bool AgregaObjeto(ObjetosModelo.CObjeto padre, BuscadorDependencias.CObjetoBusquedaDependencia hijo)
        {
            int id_objeto;
            //me traigo la conexion
            ObjetosModelo.CConexion conexion = BuscaConexion(hijo.Motor);
            ObjetosModelo.CConexion conexionPadre = BuscaConexion(hijo.objetoPadre.Motor);
            if (padre.ID_Conexion != conexionPadre.ID_Conexion)
                return false;
            //veo si ya existe el objeto en el modelo
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(conexion.ID_Conexion, hijo.Nombre);
            if (obj == null)
            {
                //lo agrego
                id_objeto = Modelo.InsertObjeto(conexion.ID_Conexion, hijo.Nombre, hijo.Tipo, false, "", Color.White);
            }
            else
            {
                id_objeto = obj.ID_Objeto;
            }
            //lo agrego al objeto que depende
            if (Modelo.GetObjetoObjeto(padre.ID_Objeto, id_objeto) == null)
            {
                //lo agrego
                Modelo.InsertObjetoObjeto(padre.ID_Objeto, id_objeto);
            }
            return true;
        }
        private void cBuscadorDependencias1_OnObjetoEncontrado(BuscadorDependencias.CBuscadorDependencias sender, BuscadorDependencias.CObjetoBusquedaDependencia objeto)
        {
            ObjetosEncontrados.Add(objeto);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                if (Salir)
                    return;
                //proceso primero todos los mensajes
                while (mensajes.Count > 0)
                {
                    if (Salir)
                        return;
                    String msg = mensajes[0];
                    mensajes.RemoveAt(0);
                    backgroundWorker1.ReportProgress(0, msg);
                }
                while (ObjetosEncontrados.Count > 0)
                {
                    if (Salir)
                        return;
                    BuscadorDependencias.CObjetoBusquedaDependencia obj = ObjetosEncontrados[0];
                    ObjetosEncontrados.RemoveAt(0);
                    backgroundWorker1.ReportProgress(1, obj);
                }
                System.Threading.Thread.Sleep(100);
            }
            while (procesando);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0: //mensajes
                    Mensaje(e.UserState.ToString());
                    break;
                case 1:
                    ProcesaObjeto((BuscadorDependencias.CObjetoBusquedaDependencia)e.UserState);
                    break;
            }
        }
        private void ProcesaObjeto(BuscadorDependencias.CObjetoBusquedaDependencia objeto)
        {
            if (objeto.objetoPadre == null)
            {
                return;
            }
            //me traigo el objeto padre
            List<ObjetosModelo.CObjeto> l = Modelo.GetObjetos();
            //busco uno por uno hasta encontrar el papa
            foreach (ObjetosModelo.CObjeto obj in l)
            {
                if (Salir)
                    return;
                if (obj.Nombre== objeto.objetoPadre.Nombre)
                {
                    //veo si ya existe el 
                    if (AgregaObjeto(obj, objeto))
                    {
                        return;
                    }
                }
            }
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void cBuscadorDependencias1_OnObjetoAnalizado(BuscadorDependencias.CBuscadorDependencias sender, BuscadorDependencias.CObjetoBusquedaDependencia objeto)
        {
            List<ObjetosModelo.CObjeto> l = Modelo.GetObjetos();
            //busco el objeto
            foreach(ObjetosModelo.CObjeto obj in l)
            {
                ObjetosModelo.CConexion conexion = Modelo.GetConexion(obj.ID_Conexion);
                ObjetosModelo.CServidor servidor = Modelo.GetServidor(conexion.ID_Servidor);
                ManagerConnect.CConexion conecion2 = ManagerConnect.ControladorConexiones.GetConexion(servidor.Nombre, conexion.Nombre);
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(conecion2);
                if (obj.Nombre==objeto.Nombre && motor.GetConecctionString()==objeto.Motor.GetConecctionString())
                {
                    if (ObjetoActual.Nombre != obj.Nombre)
                    {
                        if (marcarlos == null)
                            marcarlos = new List<ObjetosModelo.CObjeto>();
                        marcarlos.Add(obj);
                    }
                        return;
                    
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (marcarlos == null)
                return;
            if (marcarlos.Count > 0)
            {
                ObjetosModelo.CObjeto obj = marcarlos[0];
                marcarlos.RemoveAt(0);
                obj.BKColor = Color.YellowGreen;
                obj.update();
            }
        }
    }
}
   