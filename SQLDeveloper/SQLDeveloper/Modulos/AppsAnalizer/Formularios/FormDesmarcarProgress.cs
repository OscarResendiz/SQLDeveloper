using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    public partial class FormDesmarcarProgress : Form
    {
        bool Desmarcar;
        ObjetosModelo.AppModel Modelo;
		List<ObjetosModelo.CObjeto> Objetos;
        List<ObjetosModelo.CArchivo> Archivos;
        private Color color;
        public FormDesmarcarProgress(ObjetosModelo.AppModel modelo,bool desmarcar=true)
        {
            Modelo = modelo;
            Desmarcar = desmarcar;
            InitializeComponent();
        }

        private void FormDesmarcarProgress_Load(object sender, EventArgs e)
        {
            if (Desmarcar)
            {
                Objetos = Modelo.GetObjetos();
                Archivos = Modelo.GetArchivos();
                progressBar1.Maximum = Objetos.Count + Archivos.Count;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
                dlg.Reset();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                color = dlg.Color;
                progressBar1.ForeColor = color;
                Objetos = new List<ObjetosModelo.CObjeto>();
                //marcar
                Archivos = Modelo.GetArchivos();
                foreach(ObjetosModelo.CArchivo archivo in Archivos)
                {
                    List<ObjetosModelo.CObjeto> l = archivo.getObjetos();
                    foreach(ObjetosModelo.CObjeto obj in l)
                    {
                        bool encontrado = false;
                        foreach(ObjetosModelo.CObjeto obj2 in Objetos)
                        {
                            if(obj.ID_Objeto==obj2.ID_Objeto)
                            {
                                encontrado = true;
                                break;
                            }
                        }
                        if(encontrado==false)
                        {
                            Objetos.Add(obj);
                        }
                    }
                }
                progressBar1.Maximum = Objetos.Count + Archivos.Count;
                backgroundWorker2.RunWorkerAsync();

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = 0;
            foreach (ObjetosModelo.CObjeto obj in Objetos)
            {
                total++;
                if (obj.BKColor.R != Color.White.R || obj.BKColor.G != Color.White.G || obj.BKColor.B != Color.White.B)
                {
                    obj.BKColor = Color.White;
                    obj.update(false);
                    backgroundWorker1.ReportProgress(total, obj);
                }
                else
                {
                    backgroundWorker1.ReportProgress(total, null);
                }
            }
            foreach (ObjetosModelo.CArchivo archivo in Archivos)
            {
                total++;
                if (archivo.BKColor.R != Color.White.R || archivo.BKColor.G != Color.White.G || archivo.BKColor.B != Color.White.B)
                {
                    archivo.BKColor = Color.White;
                    archivo.update(false);
                    backgroundWorker1.ReportProgress(total, archivo);
                }
                else
                {
                    backgroundWorker1.ReportProgress(total, null);
                }
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            /*
            if (e.UserState != null)
            {
                ObjetosModelo.CObjetoBase obj = (ObjetosModelo.CObjetoBase)e.UserState;
                if (obj.GetType() == typeof(ObjetosModelo.CObjeto))
                {
                    ObjetosModelo.CObjeto objeto = (ObjetosModelo.CObjeto)obj;
                    Modelo.InformaUpdateObjeto(objeto.ID_Objeto);
                }
                if (obj.GetType() == typeof(ObjetosModelo.CArchivo))
                {
                    ObjetosModelo.CArchivo archivo = (ObjetosModelo.CArchivo)obj;
                    Modelo.InformaUpdateArchivo(archivo.ID_Archivo);
                }
            }
             */
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int total = 0;
            foreach (ObjetosModelo.CObjeto obj in Objetos)
            {
                total++;
                if (obj.BKColor.R != color.R || obj.BKColor.G != color.G || obj.BKColor.B != color.B)
                {
                    obj.BKColor = color;
                    obj.update(false);
                    backgroundWorker2.ReportProgress(total, obj);
                }
                else
                {
                    backgroundWorker2.ReportProgress(total, null);
                }
            }
            foreach (ObjetosModelo.CArchivo archivo in Archivos)
            {
                total++;
                if (archivo.BKColor.R != color.R || archivo.BKColor.G != color.G || archivo.BKColor.B != color.B)
                {
                    archivo.BKColor = color;
                    archivo.update(false);
                    backgroundWorker2.ReportProgress(total, archivo);
                }
                else
                {
                    backgroundWorker2.ReportProgress(total, null);
                }
            }

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            backgroundWorker1_ProgressChanged(sender, e);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();

        }
    }
}
   