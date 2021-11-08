using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Drawing;
namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    public partial class CAnalizadorCarpetas : Component,IAnalizer
    {
        List<ObjetosModelo.CExtencion> extenciones;
        ObjetosModelo.AppModel Modelo;
        bool Salir = false;
        public event AnalizerEventString AnalizerEventStringmsg;
        public event AnalizerEvent iniciaAnalisisevent;
        public event AnalizerEvent terminaAnalisisevent;
        public CAnalizadorCarpetas(ObjetosModelo.AppModel modelo)
        {
            Modelo = modelo;
            InitializeComponent();
        }

        public CAnalizadorCarpetas(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #region implementacion de la interface IAnalizer
        public void IniciaAnalisis()
        {
            extenciones = Modelo.GetExtenciones();
            if (iniciaAnalisisevent != null)
                iniciaAnalisisevent();
            if (AnalizerEventStringmsg != null)
                AnalizerEventStringmsg("Inicializa Busqueda de archivos");
            backgroundWorker1.RunWorkerAsync();
        }
       public  void AddInitAnalisisEvent(AnalizerEvent e)
        {
            iniciaAnalisisevent += e;
        }
       public void AddEndAnalisisEvent(AnalizerEvent e)
        {
            terminaAnalisisevent += e;
        }

        public void AddMessageEvent(AnalizerEventString e)
        {
            AnalizerEventStringmsg += e;
        }
        public void cancelarAnalisis()
        {
            Salir = true; //mando a terminar el proceso
        }
        #endregion
        private void Mensaje(string msg)
        {
            backgroundWorker1.ReportProgress(0, msg);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0: //mensajes
                    if (AnalizerEventStringmsg != null)
                        AnalizerEventStringmsg(e.UserState.ToString());
                    break;
                case 1: //agregar directorio

                    Modelo.NotificaNuevaCarpeta((int)e.UserState);
                    break;
                case 2: //agregar directorio

                    Modelo.NotificaNuevoArchivo((int)e.UserState);
                    break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (terminaAnalisisevent != null)
                terminaAnalisisevent();
        }
        private void reportaNuevaCarpeta(int id_carpeta)
        {
            backgroundWorker1.ReportProgress(1, id_carpeta);
        }
        private void reportaNuevoArchivo(int id_archivo)
        {
            backgroundWorker1.ReportProgress(2, id_archivo);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            List<string> carpetasSistema=new List<string>();
            List<ObjetosModelo.CCarpeta> carpetas=new List<ObjetosModelo.CCarpeta>();
            ObjetosModelo.CConfiguracion confi = Modelo.GetConfiguracion("CarpetaInicial");
            int idCarpetaActual = int.Parse(confi.Valor);
            ObjetosModelo.CConfiguracion confiruta= Modelo.GetConfiguracion("Ruta");
            string RutaInicial = confiruta.Valor;
            if (Directory.Exists(RutaInicial) == false)
            {
                Mensaje("No existe la ruta: " + RutaInicial);
                return;
            }
            //mando a analizar la carpeta
            analizaCarpeta(RutaInicial, idCarpetaActual);
        }
        bool ExtencionValida(string archivo)
        {
            string ext = "";
            string[] l = archivo.Split('.');
            if (l.Count() < 2)
                return false;
            ext=l[l.Count()-1];
            foreach(ObjetosModelo.CExtencion ex in extenciones)
            {
                if(ex.Extencion.ToUpper().Trim()==ext.ToUpper().Trim())
                {
                    return true;
                }
            }
            return false;
        }
        private void analizaCarpeta(string carpeta, int id_carpeta)
        {
            if (Salir)
                return;
            Mensaje("Analizando:" + carpeta);
            //cargo la lista de carpetas que hay
            string[] dir = Directory.GetDirectories(carpeta);
            //recorro las carpetas
            foreach (string d in dir)
            {
                if (Salir)
                    return;
                //veo si existe la carpeta
                ObjetosModelo.CCarpeta obj=Modelo.GetCarpetaHija(id_carpeta, d);
                if ( obj== null)
                {
                    //no existe, ppor lo que hay que agregarla
                    int id_carpetaNueva = Modelo.InsertCarpeta(d, "", id_carpeta,false);
                    reportaNuevaCarpeta(id_carpetaNueva);
                    Mensaje("Agregando directorio: "+d);
                    analizaCarpeta(d, id_carpetaNueva);
                    Thread.Sleep(10);
                }
                else
                {
                    analizaCarpeta(d, obj.ID_Carpeta);
                }
            }
            //ahora analizo los archivos
            string[] archivos = Directory.GetFiles(carpeta);
            Mensaje("Buscando Archivos");
            foreach (string archivo in archivos)
            {
                if (Salir)
                    return;
                if (ExtencionValida(archivo))
                {
                    ObjetosModelo.CArchivo obj = Modelo.GetArchivo(id_carpeta, archivo);
                    if (obj == null)
                    {
                        //no lo tengo, por lo que lo agrego
                        int id_archivo = Modelo.InsertArchivo(archivo, id_carpeta,Color.White,"", false);
                        Mensaje("Agregando archivo: " + archivo);
                        reportaNuevoArchivo(id_archivo);
                        Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
   