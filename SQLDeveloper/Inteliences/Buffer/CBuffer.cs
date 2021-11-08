using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
using System.Threading;
namespace Inteliences
{
    //implementa un buffer para almacenar en memoria tablas, campos, vistas, procedimientos almacenados, funciones, etc
    //para tenerlos disponibles y no tener que ir a la base de datos a cada momento
    public partial class CBuffer : Component
    {
        #region variables internas
        private DateTime siguienteMonitoreo;
        IMotorDB FMotor; //motor dr base de datos que va agregarle el buffer
        private List<CObjeto> LObjetos; //lista de objetos. solo va a contener los nombres de los objetos
        private List<CTabla> LTablas; //lista de tablas
        private List<CVista> LVistas; //lista de vistas
        private List<CCampoBase> LCampos;
        private bool MonitoreoActivo;
        private bool CambioMotor;
        #endregion
        #region coigo generado automaticamente por visual estudio
        public CBuffer()
        {
            TiempoRefresh = 1; //se refresca cada minuto
            MonitoreoActivo = false;
            if (LObjetos == null)
                LObjetos = new List<CObjeto>();
            if (LTablas == null)
                LTablas = new List<CTabla>();
            if (LVistas == null)
                LVistas = new List<CVista>();
            if (LCampos == null)
                LCampos = new List<CCampoBase>();

            InitializeComponent();
            InciaMonitoreo();
        }
        public CBuffer(IContainer container)
        {
            TiempoRefresh = 1; //se refresca cada minuto
            container.Add(this);
            if (LObjetos == null)
                LObjetos = new List<CObjeto>();
            if (LTablas == null)
                LTablas = new List<CTabla>();
            if (LVistas == null)
                LVistas = new List<CVista>();
            if (LCampos == null)
                LCampos = new List<CCampoBase>();

            InitializeComponent();
            InciaMonitoreo();
        }
        #endregion
        #region Propiedades
        public IMotorDB Motor
        {
            get
            {
                return FMotor;
            }
            set
            {
                FMotor = value;
                CambioMotor = true;
            }
        }
        public int TiempoRefresh
        {
            get;
            set;
        }
        #endregion
        #region Monitoreo de objetos en segundo plano
        private void InciaMonitoreo()
        {
            if (!backgroundWorker1.IsBusy)
            {
                //si no esta ocupado lo arranca
                MonitoreoActivo = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void DetenerMonitoreo()
        {
            MonitoreoActivo = false;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            siguienteMonitoreo = DateTime.Now.AddMinutes(-1);//.AddMinutes(TiempoRefresh);
            do
            {
                try
                {
                    //me espero a que el motor este activo
                    if ((DateTime.Now >= siguienteMonitoreo || CambioMotor) && FMotor != null)
                    {
                        //ya es momento de iniciar el monitoreo
                        CambioMotor = false;
                        //limpio los objetos
                        if (LObjetos == null)
                            LObjetos = new List<CObjeto>();
                        LObjetos.Clear();
                        LTablas.Clear();
                        LVistas.Clear();
                        LCampos.Clear();
                        //me traigo la lista de objetos de la base de datos
                        LObjetos = FMotor.Buscar("", EnumTipoObjeto.NONE);
                        //ahora me traigo las tablas y vista
                        if (LObjetos != null)
                        {
                            foreach (CObjeto obj in LObjetos)
                            {
                                if (CambioMotor)
                                    break;
                                switch (obj.Tipo)
                                {
                                    case EnumTipoObjeto.TABLE:
                                        //me traigo la tabla
                                        try
                                        {
                                            CTabla tbl = FMotor.DameTabla(obj.Nombre);
                                            LTablas.Add(tbl);
                                            if (tbl != null)
                                            {
                                                foreach (CCampo c in tbl.Campos)
                                                {
                                                    if (CambioMotor)
                                                        break;
                                                    AgregaCampo(c);
                                                }
                                            }
                                        }
                                        catch (System.Exception)
                                        {
                                            ; //no hace nada
                                        }
                                        break;
                                    case EnumTipoObjeto.VIEW:
                                        CVista vista = FMotor.DameVista(obj.Nombre);
                                        if (vista != null)
                                        {
                                            LVistas.Add(vista);
                                            foreach (CCampoBase c in vista.Campos)
                                            {
                                                if (CambioMotor)
                                                    break;
                                                AgregaCampo(c);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        siguienteMonitoreo = DateTime.Now.AddMinutes(TiempoRefresh); //calculo el siguiente refresh
                    }
                }
                catch(System.Exception ex)
                {
                    continue;
                }
                if (!CambioMotor)
                    Thread.Sleep(10000); //me duermo por 10 segundos
            }
            while (MonitoreoActivo); //mientras este activo el monitoreo hace todo
        }
        private void AgregaCampo(CCampoBase obj)
        {
            if (obj.Nombre.Trim() == "")
                return;
            try
            {
                foreach (CCampoBase c in LCampos)
                {
                    if (c.Nombre == obj.Nombre)
                        return;
                }
            }
            catch(Exception ex)
            {
                ;
            }
            LCampos.Add(obj);
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //por algun motivo extraño se cerro
            //veo si fue porque se mando a cerrar
            if (MonitoreoActivo == true)
            {
                //deberia estar activo
                //lo vuelvo a lanzar
                InciaMonitoreo();
            }
        }
        #endregion
        #region funciones para extraer informacion
        public List<string> GetSPNames()
        {
            //regresa una lista con los nombres de los procedimientos almacenados
            List<string> l = new List<string>();
            foreach(CObjeto obj in LObjetos)
            {
               if(obj.Tipo== EnumTipoObjeto.PROCEDURE)
               {
                   l.Add(obj.Nombre);
               }
            }
            return l;
        }
        public List<string> GetTableNames()
        {
            //regresa una lista con los nombres de los procedimientos almacenados
            List<string> l = new List<string>();
            if (LObjetos.Count()==0 && FMotor!=null)
            {
                LObjetos = FMotor.Buscar("", EnumTipoObjeto.NONE);
            }
            foreach (CObjeto obj in LObjetos)
            {
                if (obj.Tipo == EnumTipoObjeto.TABLE)
                {
                    l.Add(obj.Nombre);
                }
            }
            return l;
        }
        public List<string> GetViewNames()
        {
            //regresa una lista con los nombres de los procedimientos almacenados
            List<string> l = new List<string>();
            if (LObjetos.Count() == 0 && FMotor != null)
            {
                LObjetos = FMotor.Buscar("", EnumTipoObjeto.NONE);
            }
            foreach (CObjeto obj in LObjetos)
            {
                if (obj.Tipo == EnumTipoObjeto.VIEW)
                {
                    l.Add(obj.Nombre);
                }
            }
            return l;
        }
        public List<string> GetAllFields()
        {
            //regresa todos los campos que se tiene en la base de datos
            List<string> l = new List<string>();
            l.Add("*");
            foreach(CCampoBase c in LCampos)
            {
                l.Add(c.Nombre);
            }
            return l;
        }
        public List<string> GetFields(string tabla)
        {
            List<string> l = new List<string>();
            try
            {
                //regresa el listado de campos pertenecientes a la tabla
                foreach (CTabla obj in LTablas)
                {
                    if (obj.Nombre.ToUpper().Trim() == tabla.ToUpper().Trim())
                    {
                        //ahora obtengo los campos
                        foreach (CCampo campo in obj.Campos)
                        {
                            l.Add(campo.Nombre);
                        }
                    }
                }
            }
            catch(System.Exception ex)
            {
                return l;
            }
            return l;
        }
        #endregion
    }
}
