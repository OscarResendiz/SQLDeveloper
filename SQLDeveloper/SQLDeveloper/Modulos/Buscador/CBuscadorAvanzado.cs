using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Buscador
{
    public delegate void OnBusquedaAvanzadaEvent(CBuscadorAvanzado sender);
    public delegate void OnObjetoEncontradoEvent(CBuscadorAvanzado sender, CObjetoBusquedaAvanzado objeto);
    public partial class CBuscadorAvanzado : Component
    {
        public event OnBusquedaAvanzadaEvent OnMotorChange;
        public event OnBusquedaAvanzadaEvent OnFiltroChange;
        public event OnObjetoEncontradoEvent OnObjetoEncontrado;
        public event OnBusquedaAvanzadaEvent OnInicioBusqueda;
        public event OnBusquedaAvanzadaEvent OnFinBusqueda;
        List<MotorDB.IMotorDB> Bases;
        List<CFiltro> Filtros;
        private bool Buscando = false;
        public CBuscadorAvanzado()
        {
            Bases = new List<MotorDB.IMotorDB>();
            Filtros = new List<CFiltro>();
            InitializeComponent();
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
        #region Gestion de los criterios de busqueda
        /// <summary>
        /// Agrega u filtro a la busqueda
        /// </summary>
        /// <param name="filtro"></param>
        public void AgregarFiltro(CFiltro filtro)
        {
            if (Filtros.Count() == 0)
            {
                Filtros.Add(filtro);
                FiltroChange();
                return;
            }
            var r = (from x in Filtros.AsEnumerable() where x == filtro select x);
            if (r.Count() == 0)
            {
                Filtros.Add(filtro);
                FiltroChange();
            }
        }
        /// <summary>
        /// modifica el filtro 1 por las caracteristicas del filtro 2
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="filtro2"></param>
        public void ActualizaFiltro(CFiltro filtro, CFiltro filtro2)
        {
            if (Filtros.Count() == 0)
                return;
            var r = (from x in Filtros.AsEnumerable() where x == filtro select x).Single();
            if (r != null)
            {
                r.Cadena = filtro2.Cadena;
                r.operador = filtro2.operador;
                r.Tipo = filtro2.Tipo;
                FiltroChange();
            }

        }
        /// <summary>
        /// Quita un filtro de la busqueda
        /// </summary>
        /// <param name="filtro"></param>
        public void EliminaFiltro(CFiltro filtro)
        {
            if (Filtros.Count() == 0)
                return;
            var r = (from x in Filtros.AsEnumerable() where x == filtro select x).Single();
            if (r != null)
            {
                Filtros.Remove(r);
                FiltroChange();
            }
        }
        /// <summary>
        /// Elimina todos los filtros
        /// </summary>
        public void LimpiaFiltros()
        {
            Filtros.Clear();
        }
        /// <summary>
        /// regresa la lista de filtros de la busqueda
        /// </summary>
        /// <returns></returns>
        public List<CFiltro> DameFiltros()
        {
            return Filtros;
        }
        private void FiltroChange()
        {
            if (OnFiltroChange != null)
                OnFiltroChange(this);
        }
        #endregion
        private void ObjetoEncontrado(CObjetoBusquedaAvanzado obj)
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
                CObjetoBusquedaAvanzado obj = (CObjetoBusquedaAvanzado)e.UserState;
                OnObjetoEncontrado(this, obj);
            }
        }
        /// <summary>
        /// regresa la lista despues de aplicar el filtro en Lbase con l
        /// </summary>
        /// <param name="lbase"></param>
        /// <param name="l"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private List<MotorDB.CObjeto> AplicaFiltro(List<MotorDB.CObjeto> lbase, List<MotorDB.CObjeto> l, OPERADOR operador)
        {
            List<MotorDB.CObjeto> lr = new List<MotorDB.CObjeto>();
            //recorro ambas listas
            //aplico el filtro
            switch (operador)
            {
                case OPERADOR.AND:// se agrega si esta en ambas listas
                    var res = (
                                from a in lbase.AsEnumerable()
                                join b in l.AsEnumerable()
                                on a.Nombre equals b.Nombre
                                where a.Tipo == b.Tipo
                                select a
                             );
                    foreach (var obj in res)
                    {
                        lr.Add(obj);
                    }
                    break;
                case OPERADOR.OR: //se agregan ambas listas
                    foreach (MotorDB.CObjeto obj1 in l)
                    {
                        lr.Add(obj1);
                    }
                    foreach (MotorDB.CObjeto obj2 in lbase)
                    {
                        lr.Add(obj2);
                    }

                    break;
                case OPERADOR.NOT:
                    //agrega si base no esta en la lista l
                    var res2 = (
                        from a in lbase.AsEnumerable()
                        where !(from b in l.AsEnumerable() select b.Nombre).Contains(a.Nombre)
                        select a
                                 );
                    foreach (var obj in res2)
                    {
                        lr.Add(obj);
                    }
                    break;
                case OPERADOR.NONE:
                    //solo agrega l
                    foreach (MotorDB.CObjeto obj1 in l)
                    {
                        lr.Add(obj1);
                    }
                    break;
            }
            //quito duplicados
            List<MotorDB.CObjeto> lr2 = new List<MotorDB.CObjeto>();
            foreach (MotorDB.CObjeto obj in lr.Distinct())
            {
                lr2.Add(obj);
            }
            return lr2;
        }
        private void BuscaEnMotor(MotorDB.IMotorDB motor)
        {
            //lista donde voy a concentrar los resultados
            List<MotorDB.CObjeto> resultado = new List<MotorDB.CObjeto>();
            //recorro cada filtro par hacer la busqueda
            foreach (CFiltro filtro in Filtros)
            {
                //busco el criterio
                List<MotorDB.CObjeto> l = motor.Buscar(filtro.Cadena, filtro.Tipo);
                resultado = AplicaFiltro(resultado, l, filtro.operador);
            }
            //informo del resultado de la busqueda
            foreach (MotorDB.CObjeto obj in resultado)
            {
                ObjetoEncontrado(new CObjetoBusquedaAvanzado()
                {
                    Nombre = obj.Nombre,
                    Tipo = obj.Tipo,
                    Motor = motor
                }
                );
            }
        }
        private void BuscadorBk_DoWork(object sender, DoWorkEventArgs e)
        {
            //aqui esta lo bueno
            //recorro cada una de las bases y les voy aplicando los filtros
            //lo ejecuto en paralelo para incrementar la velocidad

            //esto es con programacion en paralelo -> Es rapido
            Parallel.ForEach(Bases, (motor) =>
                {
                    BuscaEnMotor(motor);

                }
                );
            
            //y esto es con tareas que tambien se ejecutan en paralelo pero son mucho mas rapidas
            //pero no se espera a que terminen las consultas porque las hace en segundo plano
            //foreach (MotorDB.IMotorDB motor in Bases)
            //{
            //    Task t = Task.Factory.StartNew(() => BuscaEnMotor(motor));
            //}
        }
    }
}
   