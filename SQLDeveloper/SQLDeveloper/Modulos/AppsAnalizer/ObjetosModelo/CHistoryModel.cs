using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    public partial class CHistoryModel : Component
    {
        AppModel FModelo;
        bool Continuar;
        List<CObjeto> Objetos;
        private bool FPausa=false;
        public CHistoryModel(AppModel modelo)
        {
            InitializeComponent();
            Continuar = true;
        }
        public AppModel Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                if (FModelo == value)
                    return;
                if (FModelo != null)
                {
                    FModelo.AbrirModeloEvent -= AbrirModelo;
                    FModelo.CerrarModeloEvent -= CerrarModelo;
                    FModelo.NuevoModeloEvent -= NuevoModelo;
                }
                FModelo = value;
                FModelo.AbrirModeloEvent += new OnModeloEventDelegate( AbrirModelo);
                FModelo.CerrarModeloEvent += new OnModeloEventDelegate( CerrarModelo);
                FModelo.NuevoModeloEvent +=new OnModeloEventDelegate( NuevoModelo);

            }
        }

        private void NuevoModelo(AppModel m)
        {
            //se abrio un nuevo modelo, por lo que reinicio el buscado
            DetenBucador();
            //ahora lo reinicio
            IniciaBuscador();
        }
        private void AbrirModelo(AppModel m)
        {
            //se abrio un nuevo modelo, por lo que reinicio el buscado
            DetenBucador();
            //ahora lo reinicio
            IniciaBuscador();
        }
        private void IniciaBuscador()
        {
            if (backgroundWorker1.IsBusy)
                return;
            Continuar = true;
            FPausa = false;
            backgroundWorker1.RunWorkerAsync();
        }
        private void DetenBucador()
        {
            //mando a detenerlo
            Continuar = false;
            //me espero a que se termine
            if(backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                System.Threading.Thread.Sleep(50);
            }

        }
/*        public void Inicializa(AppModel modelo)
        {
            Modelo = modelo;
            Modelo.CerrarModeloEvent += new OnModeloEventDelegate(CerrarModelo);
            backgroundWorker1.RunWorkerAsync();
            Continuar = true;
        }
  */
        private void CerrarModelo(AppModel m)
        {
            DetenBucador();
        }

        public CHistoryModel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(Continuar)
            {
                //me ttraigo la lista de objetos a analizar
                while (Modelo.Modificando || FPausa)
                {
                    System.Threading.Thread.Sleep(60000); //me duermo un minuto
                }
                Objetos = Modelo.GetObjetos();
                foreach(CObjeto obj in Objetos)
                {
                    while (Modelo.Modificando || FPausa)
                    {
                        System.Threading.Thread.Sleep(60000); //me duermo un minuto
                    }
                    if (Continuar == false)
                        return;
                    Analiza(obj);
                }
                System.Threading.Thread.Sleep(60000); //me duermo un minuto
            }
        }
        /// <summary>
        /// se trae el codigo de la ultima captura del historial y lo compara con el codigo actual
        /// </summary>
        /// <param name="obj"></param>
        private void Analiza(CObjeto obj)
        {
            string codigo = "";
            ObjetosModelo.CCodigoObjeto historial = Modelo.GetUltimoHistorial(obj.ID_Objeto);
            if (Continuar == false)
                return;
            if (historial == null)
            {
                //no hay historial, por lo que hay que traelo
                codigo = DameCodigo(obj);
                while (Modelo.Modificando || FPausa)
                {
                    System.Threading.Thread.Sleep(60000); //me duermo un minuto
                    return;
                }
                if (codigo != "")
                {
                    AgregaHistorial(obj, codigo);
                }
                return;
            }
            DateTime actual = DateTime.Now;
           //veo is han pasado 5 minutos
            if(historial.Fecha.AddMinutes(5)>=actual)
            {
                //ya han pasado mas de 5 minutos por lo que hay que verificar si ha cambiado el codigo
                codigo = DameCodigo(obj);
                if(historial.Codigo!=codigo)
                {
                    while (Modelo.Modificando || FPausa)
                    {
                        System.Threading.Thread.Sleep(60000); //me duermo un minuto
                        return;
                    }
                    AgregaHistorial(obj, codigo);
                }
            }
        }
        /// <summary>
        /// regresa el codigo que se tiene en la base de datos
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string DameCodigo(CObjeto obj)
        {
            ObjetosModelo.CConexion con = Modelo.GetConexion(obj.ID_Conexion);
            if (con == null)
                return "";
            ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
            if (server == null)
                return "";
            ManagerConnect.CConexion Conexion = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);


            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(Conexion);
            string s = "";
            switch (obj.TipoObjeto)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s = motor.DameCodigoFuncction(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s = motor.DameCodigoStoreProcedure(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s = motor.DameCodigoTabla(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s = motor.DameCodigoTrigger(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = motor.DameCodigoVista(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s = motor.DameCodigoTypeTable(obj.Nombre);
                    break;
            }
            return s;
        }
        /// <summary>
        /// agrega historial al objeto
        /// </summary>
        /// <param name="obj"></param>
        private void AgregaHistorial(CObjeto obj, string codigo)
        {
            if (Continuar == false)
                return;
            int id_codigo = Modelo.InsertCodigoObjeto(obj.ID_Objeto, DateTime.Now, codigo, false, "", false);
            //informo que se agrego codigo
            backgroundWorker1.ReportProgress(0, id_codigo);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage==0)
            {
                Modelo.InformaInsertCodigoObjeto((int)e.UserState);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //por lagun motivo se cerro el hilo
            if(Continuar)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        public bool Pausa
        {
            get
            {
                return FPausa;
            }
            set
            {
                FPausa = true;
            }
        }
    }
}
   