using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public delegate void CProjectManagerEvent();
    public partial class CProjectManager : Component
    {
        public event CProjectManagerEvent OnProjectHistoruChange;
        private Dictionary<string, ModeloBasico> Proyectos; //lista de proyectos
        public CProjectManager()
        {
            Proyectos = new Dictionary<string, ModeloBasico>();
            InitializeComponent();
        }

        public CProjectManager(IContainer container)
        {
            Proyectos = new Dictionary<string, ModeloBasico>();
            container.Add(this);
            InitializeComponent();
        }
        public ModeloBasico OpenProject(string archivo)
        {
            //veo si el proyecto ya esta habierto
            foreach( var obj in Proyectos )
            {
                if(obj.Key.Trim().ToUpper()==archivo.Trim().ToUpper())
                {
                    ActualizaProyecto(obj.Key);
                    return obj.Value;
                }
            }
            if(!File.Exists(archivo))
            {
                throw new Exception("El proyecto no existe");
            }
            try
            {
                ModeloBasico modelo = new ModeloBasico();
                modelo.FileName = archivo;
                modelo.OnMensaje += new ONModeloBasicoMessageEvent(Mensaje);
                Proyectos.Add(archivo, modelo);
                AddProject(archivo);
                return modelo;

            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }
        public ModeloBasico NewProject(string archivo)
        {
            //veo si el proyecto ya esta habierto
            foreach (var obj in Proyectos)
            {
                if (obj.Key.Trim().ToUpper() == archivo.Trim().ToUpper())
                {
                    throw new Exception("El proyecto ya existe");
                }
            }
            ModeloBasico modelo = new ModeloBasico();
            modelo.FileName = archivo;
            modelo.OnMensaje += new ONModeloBasicoMessageEvent(Mensaje);
            Proyectos.Add(archivo, modelo);
            AddProject(archivo);
            return modelo;


        }
        public void CierraProyecto(string archivo)
        {
            //me traigo el proyecto
            foreach (var obj in Proyectos)
            {
                if(obj.Key.ToUpper().Trim()==archivo.ToUpper().Trim())
                {
                    ModeloBasico modelo = obj.Value;
                    //paro el monitoreo
                    modelo.MonitorearEnable = false;
                    //quito el evento
                    modelo.OnMensaje -= Mensaje;
                }
            }
            Proyectos.Remove(archivo);
        }
        private void Mensaje(string msg)
        {
            notifyIcon1.ShowBalloonTip(2000, "Proyecto", msg, System.Windows.Forms.ToolTipIcon.Info);
        }
        private void AddProject(string fullFilename)
        {
            try
            {
                //me traigo el nombre del archivo
                int pos = fullFilename.LastIndexOf("\\");
                string filename = fullFilename.Substring(pos + 1);
                int posext = filename.LastIndexOf(".");
                if (posext > 0)
                    filename = filename.Substring(0, posext);
                string Archivo = Path.GetDirectoryName(Application.ExecutablePath) + "\\Colores\\HistoryData.xml";
                //veo si el archivo ya existe
                DataTable ProjetFiles = HistoryData.Tables["ProjetFiles"];
                foreach (DataRow dr in ProjetFiles.Rows)
                {
                    string ruta = dr["Path"].ToString();
                    if (ruta.ToUpper().Trim() == fullFilename.ToUpper().Trim())
                    {
                        //ya existe, por lo que no hago nada
                        dr["fecha"] = DateTime.Now;
                        ProjetFiles.WriteXml(Archivo);
                        return;
                    }
                }
                //como no exite lo agrego
                DataRow dr2 = ProjetFiles.NewRow();
                dr2["Path"] = fullFilename;
                dr2["FileName"] = filename;
                dr2["fecha"] = DateTime.Now;
                ProjetFiles.Rows.Add(dr2);
                ProjetFiles.WriteXml(Archivo);
                if (OnProjectHistoruChange != null)
                    OnProjectHistoruChange();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RemoveHistory(string archivo)
        {
            DataTable ProjetFiles = HistoryData.Tables["ProjetFiles"];
            for (int pos = ProjetFiles.Rows.Count - 1; pos >= 0; pos--)
            {
                DataRow dr = ProjetFiles.Rows[pos];
                if (dr["Path"].ToString() == archivo)
                {
                    ProjetFiles.Rows.Remove(dr);
                }
            }
            string Archivo = Path.GetDirectoryName(Application.ExecutablePath) + "\\Colores\\HistoryData.xml";
            ProjetFiles.WriteXml(Archivo);
            if (OnProjectHistoruChange != null)
                OnProjectHistoruChange();
        }
        public Dictionary<string, string> GetHistory()
        {
            List<CProjetFile> archivos = new List<CProjetFile>();
            Dictionary<string, string> l = new Dictionary<string, string>();
            HistoryData.Clear();
            string Archivo = Path.GetDirectoryName(Application.ExecutablePath) + "\\Colores\\HistoryData.xml";
            HistoryData.ReadXml(Archivo);
            DataTable ProjetFiles = HistoryData.Tables["ProjetFiles"];
            foreach (DataRow dr in ProjetFiles.Rows)
            {
                DateTime f = System.DateTime.Now;
                if (DateTime.TryParse(dr["fecha"].ToString(), out f) == false)
                {
                    f = System.DateTime.Now;
                    dr["fecha"] = f;
                }
                archivos.Add(new CProjetFile()
                    {
                        FileName = dr["FileName"].ToString(),
                        Path = dr["Path"].ToString(),
                        fecha = f
                    }
                    );
            }
            ProjetFiles.WriteXml(Archivo);
            var res = (from z in archivos.AsEnumerable() select z).OrderByDescending(z => z.fecha);
            int i = 0;
            foreach (var obj in res)
            {
                if (i >= 10)
                    break;
                bool existe = false;
                foreach (var obj2 in l)
                {
                    if(obj2.Key==obj.FileName)
                    {
                        existe = true;
                        break;
                    }
                }
                if (existe==false)
                {
                    l.Add(obj.FileName, obj.Path);
                    i++;
                }

            }
            return l;
        }
        private void ActualizaProyecto(string nombre)
        {
            string Archivo = Path.GetDirectoryName(Application.ExecutablePath) + "\\Colores\\HistoryData.xml";
            HistoryData.ReadXml(Archivo);
            DataTable ProjetFiles = HistoryData.Tables["ProjetFiles"];
            foreach (DataRow dr in ProjetFiles.Rows)
            {
                if(dr["FileName"].ToString().ToUpper().Trim()==nombre.ToUpper().Trim())
                {
                    dr["fecha"] = DateTime.Now;
                    ProjetFiles.WriteXml(Archivo);
                    return;
                }
            }

        }
    }
}
