using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    public partial class CBucadorCadenas : Component, IAnalizer
    {
        bool Salir = false;
        List<ObjetosModelo.CArchivo> Archivos;
        ObjetosModelo.AppModel Modelo;
        public event AnalizerEventString AnalizerEventStringmsg;
        public event AnalizerEvent iniciaAnalisisevent;
        public event AnalizerEvent terminaAnalisisevent;
        public CBucadorCadenas(ObjetosModelo.AppModel modelo, List<ObjetosModelo.CArchivo> archivos)
        {
            InitializeComponent();
            Modelo = modelo;
            Archivos = archivos;
        }
        #region implementacion de la interface IAnalizer
        /// <summary>
        /// comienza a hacer todo el analisis en segundo plano
        /// </summary>
        public void IniciaAnalisis()
        {
            if (iniciaAnalisisevent != null)
                iniciaAnalisisevent();
            if (AnalizerEventStringmsg != null)
                AnalizerEventStringmsg("Inicializa Busqueda de objetos en archivos");
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
            backgroundWorker1.ReportProgress(0, msg);
        }
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

        /// <summary>
        /// inicia el analisis del archivo
        /// </summary>
        /// <param name="archivo"></param>
        private void AnalizaArchivo(ObjetosModelo.CArchivo archivo)
        {
            IFileAnalizer analizador = DameAnalizador(archivo.Extencion);
            analizador.AddAnalizarObjetoEvent(AnalizaCadena);
            analizador.analiza(archivo);

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int n, max;
            n = 0;
            max = Archivos.Count();
            foreach (ObjetosModelo.CArchivo archivo in Archivos)
            {
                if (Salir)
                    return;
                n++;
                int porcentaje = n * 100 / max;
                Mensaje("Analizando: " + archivo.NombreCorto + " " + porcentaje.ToString() + "%");
                AnalizaArchivo(archivo);
                Modelo.UpdateArchivo(archivo.ID_Archivo, archivo.NombreArchivo, archivo.ID_Carpeta, Color.YellowGreen,archivo.Comentarios, false);
                InformaArchivoActualizado(archivo.ID_Archivo);
            }

        }
        private void InformaArchivoActualizado(int id_archivo)
        {
            backgroundWorker1.ReportProgress(2, id_archivo);

        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (terminaAnalisisevent != null)
                terminaAnalisisevent();

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
                    case 1: //se agrega una linea al archivo
                        Modelo.InformaInsertLineaArchivo((int)e.UserState);
                        break;
                    case 2: //se ha modificado un archivo
                        Modelo.InformaUpdateArchivo((int)e.UserState);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                /*try
                {
                    if (AnalizerEventStringmsg != null)
                        AnalizerEventStringmsg(ex.Message);
                }
                catch (System.Exception ex2)
                {
                    return;
                }
                 * */
                return;
            }
        }

        /// <summary>
        /// Busca la cadena en las bases de datos para ver si coincide con alguno de los objetos
        /// </summary>
        /// <param name="cadena"></param>
        private void AnalizaCadena(int id_archivo, int linea, string cadena, string nombreArchivo)
        {
          int id_linea=  Modelo.InsertLineaArchivo(id_archivo, cadena, false);
          backgroundWorker1.ReportProgress(1, id_linea);

        }

    }
}
   