using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace SQLDeveloper.Modulos.BuscadorSeguidor
{
    public delegate void OnCBuscadorSeguidorEvent(CBuscadorSeguidor sender);
    public delegate void OnCBuscadorSeguidorMsgEvent(CBuscadorSeguidor sender, string mensaje);
    public delegate void OnCBuscadorSeguidorDetalle(CBuscadorSeguidor sender, Buscador.CObjetoBusquedaAvanzado padre, Buscador.CObjetoBusquedaAvanzado hijo);
    public partial class CBuscadorSeguidor : Component
    {
        public event OnCBuscadorSeguidorEvent OnInicio;
        public event OnCBuscadorSeguidorEvent OnFinProceso;
        public event OnCBuscadorSeguidorDetalle OnObjetoEncontrado;
        public event OnCBuscadorSeguidorMsgEvent OnMensaje;
        private List<Buscador.CObjetoBusquedaAvanzado> Pila; //lista de objetos que hay que buscar
//        private List<Buscador.CObjetoBusquedaAvanzado> Encontrados; //lista de objetos encontrados
        private List<Buscador.CObjetoBusquedaAvanzado> Vistos; //lista de objetos vistos para no repetir la busqueda
        private Buscador.CObjetoBusquedaAvanzado CObjetoActual; //va a indicar que cadena es la que se esta buscando actualmente
        public CBuscadorSeguidor()
        {
            InitializeComponent();
        }
        public string ObjetoBuscar
        {
            set;
            get;
        }

        public CBuscadorSeguidor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void cBuscadorAvanzado1_OnFiltroChange(Buscador.CBuscadorAvanzado sender)
        {

        }


        private void cBuscadorAvanzado1_OnInicioBusqueda(Buscador.CBuscadorAvanzado sender)
        {

        }

        private void cBuscadorAvanzado1_OnMotorChange(Buscador.CBuscadorAvanzado sender)
        {

        }

        #region Gestion de los motores de bases de datos
        /// <summary>
        /// Agrega una base de datos en la cual se tiene que hacer la busqueda
        /// </summary>
        /// <param name="motor"></param>
        public void AgregaMotor(MotorDB.IMotorDB motor)
        {
            cBuscadorAvanzado1.AgregaMotor(motor);
        }
        /// <summary>
        /// quita una base de datos dela busqueda
        /// </summary>
        /// <param name="motor"></param>
        public void QuitaMotor(MotorDB.IMotorDB motor)
        {
            cBuscadorAvanzado1.QuitaMotor(motor);
        }
        /// <summary>
        /// regresa la lista de bases de datos que se tiene registradas
        /// </summary>
        /// <returns></returns>
        public List<MotorDB.IMotorDB> DameMotores()
        {
            return cBuscadorAvanzado1.DameMotores();
        }
        #endregion
        /// <summary>
        /// inicial la busqueda
        /// </summary>
        public void Buscar()
        {
            Pila = new List<Buscador.CObjetoBusquedaAvanzado>();
//            Encontrados = new List<Buscador.CObjetoBusquedaAvanzado>();
            Vistos = new List<Buscador.CObjetoBusquedaAvanzado>();
            CObjetoActual = new Buscador.CObjetoBusquedaAvanzado();
            CObjetoActual.Nombre = ObjetoBuscar;
            AsignaFiltro(CObjetoActual);
            //Pila.Add(obj);
            if (OnInicio != null)
                OnInicio(this);
            cBuscadorAvanzado1.Buscar();
        }
        private void AsignaFiltro(Buscador.CObjetoBusquedaAvanzado obj)
        {
            //agrego el filtro
            List<Buscador.CFiltro> l = cBuscadorAvanzado1.DameFiltros(); ;
            //limpio los filtros
            for (int i = l.Count() - 1; i >= 0; i--)
            {
                Buscador.CFiltro f = l[i];
                cBuscadorAvanzado1.EliminaFiltro(f);
            }
            //agrego el nuevo filtro
            Buscador.CFiltro filtro = new Buscador.CFiltro(obj.Nombre, new MotorDB.CTipoBusqueda("Buscar en el codigo", MotorDB.EnumTipoObjeto.CODE).Tipo, Buscador.OPERADOR.NONE);
            cBuscadorAvanzado1.AgregarFiltro(filtro);
            CObjetoActual = obj;//.Nombre.ToUpper().Trim();

        }
        private void cBuscadorAvanzado1_OnObjetoEncontrado(Buscador.CBuscadorAvanzado sender, Buscador.CObjetoBusquedaAvanzado objeto)
        {
            //se encontro un objeto. hay que aplicarle mas filtros para garantizar que machee el objeto en el codigo
            //hay que usar un analizador lexico
            string codigo = "";
            int px = 0;
            bool encontrado = false;
            //primero veo si no lo he analizado
            //ni en los vistos
            bool ok = true;
            do
            {
                ok = true;
                try
                {
                    while(px<Vistos.Count)
                    {
                        Buscador.CObjetoBusquedaAvanzado obj =Vistos[px];
                        px++;
                        if (obj.Nombre == objeto.Nombre && obj.Motor.GetConnectionName() == obj.Motor.GetConnectionName())
                        {
                            //ya lo analice, por lo que regreso
                            return;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    ok = false;
                }
            }
            while (ok == false);
            //lo agrego a vistos para que no sea procesado nuevamente
            Vistos.Add(objeto);
            #region me traigo el codigo fuente
            switch (objeto.Tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    codigo = objeto.Motor.DameCodigoFuncction(objeto.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    codigo = objeto.Motor.DameCodigoStoreProcedure(objeto.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    codigo = objeto.Motor.DameCodigoTrigger(objeto.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    codigo = objeto.Motor.DameCodigoVista(objeto.Nombre);
                    break;
                default:
                    //no se recobnnoce el codigo fuente, por lo que no tiene caso que continue
                    return;
            }
            if (codigo == "")
                return;
            #endregion
            lecxer1 = new Compiler.Lexer.Lecxer();
            lecxer1.Cadena = codigo;
            //recorro los items buscando el la cadena
            foreach (Compiler.Lexer.Lexema lex in lecxer1)
            {
                if (lex == null)
                    return;
                if (lex.SuperTipo != Compiler.Lexer.LEXTIPE.COMENTARIO)
                {
                    if (lex.Texto.ToUpper().Trim() == CObjetoActual.Nombre.ToUpper().Trim())
                    {
                        //laviso que lo encontre
                        if (OnObjetoEncontrado != null)
                            OnObjetoEncontrado(this, CObjetoActual, objeto);
                        encontrado = true;
                        break;
                    }
                }
            }
            if (encontrado)
            {
                do
                {
                    ok = true;
                    try
                    {
                        px = 0;
                        while(px<Pila.Count)
                        {
                            Buscador.CObjetoBusquedaAvanzado obj=Pila[px];
                            px++;
                            if (obj.Nombre == objeto.Nombre && obj.Motor.GetConnectionName() == objeto.Motor.GetConnectionName())
                            {
                                return;
                            }
                        }
                    }
                    catch(System.Exception ex)
                    {
                        ok = false;
                    }
                }
                while (ok == false);
                //lo agrego a la pila para que sea procesado 
                Pila.Add(objeto);
            }
        }
        private void cBuscadorAvanzado1_OnFinBusqueda(Buscador.CBuscadorAvanzado sender)
        {
            //saco el ultimo objeto de la pila ylo poceso
            if (Pila.Count() == 0)
            {
                //ya no hay mas objetos por procesar
                if (OnFinProceso != null)
                    OnFinProceso(this);
                return;
            }
            //me traigo el primer objeto
            CObjetoActual = Pila[0];
            Pila.RemoveAt(0);
            AsignaFiltro(CObjetoActual);
            cBuscadorAvanzado1.Buscar();
            if (OnMensaje!=null)
                OnMensaje(this,"Analizando: "+CObjetoActual.Nombre);
        }
    }
}
   