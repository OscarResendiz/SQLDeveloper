using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public partial class CFileManager : UserControl,IFileManager
    {
        public event OnFileNameChangeEvent OnFileNameChange;
        private CFIleInfo Info;
        private FileSystemWatcher Monitor;
        private bool Guardando;
        public CFileManager()
        {
            Guardando = false;
            InitializeComponent();
        }
        public CFIleInfo Abrir()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return null;
            if (Monitor != null)
                Monitor.EnableRaisingEvents = false;

            if (Info == null)
                Info = new CFIleInfo();
            Info.NombreCorto = openFileDialog1.SafeFileName;
            Info.NombreCompleto = openFileDialog1.FileName;
            StreamReader sr = File.OpenText(openFileDialog1.FileName);
            Info.Contenido = sr.ReadToEnd();
            sr.Close();
            InitMonitorFile();
            return Info;
        }
        /*public CFIleInfo Abrir(string archivo)
        {
            if (Monitor != null)
                Monitor.EnableRaisingEvents = false;

            if (Info == null)
                Info = new CFIleInfo();
            string[] l = archivo.Split('\\');
            Info.NombreCorto = l[l.Length - 1];
            Info.NombreCompleto = archivo;
            StreamReader sr = File.OpenText(archivo);
            Info.Contenido = sr.ReadToEnd();
            sr.Close();
            InitMonitorFile();
            return Info;
        }*/
        private string getNombreCorto(string archivo)
        {
            string s = "";
            int i, n,pos=0;
            n = archivo.Length;
            for(i=0;i<n;i++)
            {
                if (archivo[i] == '\\')
                    pos = i+1;
            }
            s = archivo.Substring(pos);
            return s;
        }
        public CFIleInfo Abrir(string archivo)
        {
            if (Monitor != null)
                Monitor.EnableRaisingEvents = false;
            if (Info == null)
                Info = new CFIleInfo();
            Info.NombreCorto = getNombreCorto(archivo);
            Info.NombreCompleto = archivo;
            StreamReader sr = File.OpenText(archivo);
            Info.Contenido = sr.ReadToEnd();
            sr.Close();
            InitMonitorFile();
            return Info;
        }

        public bool EnableAbrir()
        {
            return true;
        }

        public bool EnableGuardar()
        {
            return true;
        }

        public bool EnableGuardarComo()
        {
            return true;
        }
        private string ValidaExtencion(string nombre)
        {
            if (nombre.Contains("."))
                return nombre;
            return nombre + ".sql";
        }
        public string Guardar(CFIleInfo info)
        {
            if (Monitor != null)
                Monitor.EnableRaisingEvents = false;
            string filename = "";
            if (info.NombreCompleto=="")
            {
                if(info.NombreCorto!="")
                {
                    saveFileDialog1.FileName = ValidaExtencion( info.NombreCorto);
                }
                if(saveFileDialog1.ShowDialog()!= DialogResult.OK)
                {
                    return "";
                }
                filename = saveFileDialog1.FileName;
                info.NombreCompleto = filename;
                info.NombreCorto = getNombreCorto(filename);
            }
            else
            {
                filename = info.NombreCompleto;
            }
            Guardando = true;
            StreamWriter sw = File.CreateText(filename);
            sw.Write(info.Contenido);
            sw.Close();
            Info = info;
            InitMonitorFile();
            Guardando = false;
            return filename;
        }
        public string GuardarComo(CFIleInfo info)
        {
            string filename = "";
            if (info.NombreCompleto == "")
            {
                if (info.NombreCorto != "")
                {
                    saveFileDialog1.FileName = ValidaExtencion(info.NombreCorto);
                }
//                filename = saveFileDialog1.FileName;
  //              info.NombreCompleto = filename;
    //            info.NombreCorto = getNombreCorto(filename);
            }
            else
            {
                filename = info.NombreCompleto;
            }
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            if (Monitor != null)
                Monitor.EnableRaisingEvents = false;
            filename = saveFileDialog1.FileName;
            info.NombreCompleto = filename;
            info.NombreCorto = getNombreCorto(filename);
            Guardando = true;
            StreamWriter sw = File.CreateText(filename);
            sw.Write(info.Contenido);
            sw.Close();
            Info = info;
            InitMonitorFile();
            Guardando = false;
            return filename;
        }
        private  void OnChanged(object source, FileSystemEventArgs e)
        {
            if (Guardando)
                return;
            Info.FileChange( TIPOC_AMBIO.CMABIO_CONTENIDO);
        }
        private void OnRenamed(object source, FileSystemEventArgs e)
        {
            Info.FileChange( TIPOC_AMBIO.RENOMBRADO);
        }
        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            Info.FileChange( TIPOC_AMBIO.ELIMINADO);
        }
        private void InitMonitorFile()
        {
            if (Monitor == null)
            {
                Monitor = new FileSystemWatcher(Info.Path, Info.NombreCorto);
                Monitor.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.FileName;
                Monitor.Changed += new FileSystemEventHandler(OnChanged);
                Monitor.Renamed += new RenamedEventHandler(OnRenamed);
                Monitor.Deleted += new FileSystemEventHandler(OnDeleted);
            }
            else
            {
                if (Monitor.Path != Info.Path || Monitor.Filter != Info.NombreCorto)
                {
                    Monitor.Path = Info.Path;
                    Monitor.Filter = Info.NombreCorto;
                }
            }
                Monitor.EnableRaisingEvents = true;
        }
    }
}
 