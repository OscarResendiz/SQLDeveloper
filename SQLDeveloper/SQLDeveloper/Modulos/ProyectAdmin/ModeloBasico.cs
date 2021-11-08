using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MotorDB;
using System.Threading;
namespace SQLDeveloper.Modulos.ProyectAdmin
{

    public delegate void ONModeloBasicoEvent();
    public delegate void ONModeloBasicoMessageEvent(string msg);
    public delegate void OnModeloBasicoObjectEvent(int id_objeto);
    public delegate void OnCodigoEditableChangeEvent(int id_objeto, string nombre);
    public delegate void OnRenameCodigoEditableEvent(int id_objeto, string nombre, string nuevoNombre);
    public partial class ModeloBasico
    {
        partial class ConexionDataTable
        {
        }
        #region propiedades 
        public event OnCodigoEditableChangeEvent OnCodigoEditableChange;
        public event OnModeloBasicoObjectEvent OnNewCodigoEditable;
        public event OnRenameCodigoEditableEvent OnRenameCodigoEditable;
        public event ONModeloBasicoEvent OnCarpetaModelChange;
        public event ONModeloBasicoEvent OnScriptModelChange;
        public event ONModeloBasicoEvent OnDocumentModelChange;
        public event OnModeloBasicoObjectEvent OnDocumentNameChange;
        public event OnRenameCodigoEditableEvent OnScriptNameChange;
        public event OnModeloBasicoObjectEvent OnCodigoDocumentChange;
        private List<string> Mensajes = new List<string>();
        private DateTime ProximaConsulta;
        partial class CodigoObjetoDataTable
        {
        }

        public event ONModeloBasicoEvent ONModeloChange;
        public event ONModeloBasicoEvent OnMonitoreoParado;
        public event ONModeloBasicoMessageEvent OnMensaje;
        public bool Modificado
        {
            get;
            set;
        }
        public string ComentariosProyecto
        {
            get
            {
                string comentarios = "";
                foreach (DataRow dr in Proyecto.Rows)
                {
                    if (dr["Clave"].ToString() == "Comentarios")
                    {
                        comentarios = dr["Valor"].ToString();
                        break;
                    }
                }
                return comentarios;
            }
            set
            {
                foreach (DataRow dr in Proyecto.Rows)
                {
                    if (dr["Clave"].ToString() == "Comentarios")
                    {
                        dr["Valor"] = value;
                        Actualiza();
                        return;
                    }
                }
                DataRow dr2 = Proyecto.NewRow();
                dr2["Clave"] = "Comentarios";
                dr2["Valor"] = value;
                Proyecto.Rows.Add(dr2);
                Actualiza();

            }
        }
        #endregion
        #region Administracion de servidores
        public List<CModelServidor> DameServidores()
        {
            List<CModelServidor> l = new List<CModelServidor>();
            foreach (DataRow dr in Servidor.Rows)
            {
                CModelServidor obj = new CModelServidor();
                obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                obj.Nombre = dr["Nombre"].ToString();
                l.Add(obj);
            }
            return l;
        }
        public CModelServidor DameServidor(string nombre)
        {
            foreach (DataRow dr in Servidor.Rows)
            {
                if (nombre == dr["Nombre"].ToString())
                {
                    CModelServidor obj = new CModelServidor();
                    obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                    obj.Nombre = dr["Nombre"].ToString();
                    return obj;
                }
            }
            return null;
        }
        public CModelServidor DameServidor(int ID_Servidor)
        {
            foreach (DataRow dr in Servidor.Rows)
            {
                if (ID_Servidor == int.Parse(dr["ID_Servidor"].ToString()))
                {
                    CModelServidor obj = new CModelServidor();
                    obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                    obj.Nombre = dr["Nombre"].ToString();
                    return obj;
                }
            }
            return null;
        }
        public CModelServidor AgregaServidor(string nombre)
        {
            CModelServidor obj = DameServidor(nombre);
            if (obj == null)
            {
                DataRow dr = Servidor.NewRow();
                dr["Nombre"] = nombre;
                Servidor.Rows.Add(dr);
                Actualiza();
                return DameServidor(nombre);
            }
            return obj;
        }
        public void EliminaServidor(string nombre)
        {
            if (DameConexiones(nombre) != null)
            {
                throw new Exception("El servidor tiene conexiones");
            }
            foreach (DataRow dr in Servidor.Rows)
            {
                if (nombre == dr["Nombre"].ToString())
                {
                    Servidor.Rows.Remove(dr);
                    Actualiza();
                    return;
                }
            }

        }
        #endregion
        #region Administracion de conexiones
        public List<CModelConexion> DameConexiones(string servidor)
        {
            CModelServidor srv = DameServidor(servidor);
            List<CModelConexion> l = new List<CModelConexion>();
            if (srv == null)
                return l;
            foreach (DataRow dr in Conexion.Rows)
            {
                if (int.Parse(dr["ID_Servidor"].ToString()) == srv.ID_Servidor)
                {
                    CModelConexion obj = new CModelConexion();
                    obj.ConecctionString = dr["ConecctionString"].ToString();
                    obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                    obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                    obj.MotorDB = dr["MotorDB"].ToString();
                    obj.Nombre = dr["Nombre"].ToString();
                    l.Add(obj);
                }
            }
            return l;
        }
        public List<CModelConexion> DameConexiones()
        {
            List<CModelConexion> l = new List<CModelConexion>();
            foreach (DataRow dr in Conexion.Rows)
            {
                CModelConexion obj = new CModelConexion();
                obj.ConecctionString = dr["ConecctionString"].ToString();
                obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                obj.MotorDB = dr["MotorDB"].ToString();
                obj.Nombre = dr["Nombre"].ToString();
                l.Add(obj);
            }
            return l;
        }
        public CModelConexion DameConexion(string servidor, string nombre)
        {
            CModelConexion obj = null;
            CModelServidor srv = DameServidor(servidor);
            if (srv == null)
                return null;
            List<CModelConexion> l = new List<CModelConexion>();
            foreach (DataRow dr in Conexion.Rows)
            {
                if (int.Parse(dr["ID_Servidor"].ToString()) == srv.ID_Servidor && nombre == dr["Nombre"].ToString())
                {
                    obj = new CModelConexion();
                    obj.ConecctionString = dr["ConecctionString"].ToString();
                    obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                    obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                    obj.MotorDB = dr["MotorDB"].ToString();
                    obj.Nombre = dr["Nombre"].ToString();
                    return obj;
                }
            }
            return obj;
        }
        public CModelConexion DameConexion(int ID_Conexion)
        {
            CModelConexion obj = null;
            foreach (DataRow dr in Conexion.Rows)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == ID_Conexion)
                {
                    obj = new CModelConexion();
                    obj.ConecctionString = dr["ConecctionString"].ToString();
                    obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                    obj.ID_Servidor = int.Parse(dr["ID_Servidor"].ToString());
                    obj.MotorDB = dr["MotorDB"].ToString();
                    obj.Nombre = dr["Nombre"].ToString();
                    return obj;
                }
            }
            return obj;
        }
        public void EliminaConexion(string servidor, string nombre)
        {
            CModelConexion obj = null;
            CModelServidor srv = DameServidor(servidor);
            List<CModelConexion> l = new List<CModelConexion>();
            foreach (DataRow dr in Conexion.Rows)
            {
                if (int.Parse(dr["ID_Servidor"].ToString()) == srv.ID_Servidor && obj.Nombre == dr["Nombre"].ToString())
                {
                    Conexion.Rows.Remove(dr);
                    Actualiza();
                    return;
                }
            }
        }
        public CModelConexion AgregaConexion(string servidor, string Nombre, string MotorDB, string ConecctionString)
        {
            if (DameConexion(servidor, Nombre) != null)
            {
                throw new Exception("La conexion ya existe");
            }

            CModelConexion obj = null;
            CModelServidor srv = DameServidor(servidor);
            DataRow dr = Conexion.NewConexionRow();
            dr["ID_Servidor"] = srv.ID_Servidor;
            dr["Nombre"] = Nombre;
            dr["ConecctionString"] = ConecctionString;
            dr["MotorDB"] = MotorDB;
            Conexion.Rows.Add(dr);
            Actualiza();
            return DameConexion(servidor, Nombre);
        }
        public void ActualizaConecctionString(int ID_Conexion, string ConecctionString)
        {
            CModelConexion obj = null;
            foreach (DataRow dr in Conexion.Rows)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == ID_Conexion)
                {
                    dr["ConecctionString"] = ConecctionString;
                    Conexion.AcceptChanges();
                    Actualiza();
                    return;
                }
            }

        }
        /// <summary>
        /// actualiza las conexiones con los valores mas recientes
        /// </summary>
        public void RefrescaConexiones()
        {
            List<CModelConexion> conexiones = DameConexiones();
            foreach (CModelConexion conexion in conexiones)
            {
                CModelServidor servidor = DameServidor(conexion.ID_Servidor);
                ManagerConnect.CConexion conexionPrimaria = ManagerConnect.ControladorConexiones.GetConexion(servidor.Nombre, conexion.Nombre);
                ActualizaConecctionString(conexion.ID_Conexion, conexionPrimaria.ConecctionString);
            }

        }
        #endregion
        #region Manejo de objetos
        public MotorDB.EnumTipoObjeto DameTipoObjeto(string tipo)
        {
            if (MotorDB.EnumTipoObjeto.CAMPO.ToString() == tipo)
                return EnumTipoObjeto.CAMPO;
            if (MotorDB.EnumTipoObjeto.CHECK.ToString() == tipo)
                return EnumTipoObjeto.CHECK;
            if (MotorDB.EnumTipoObjeto.CODE.ToString() == tipo)
                return EnumTipoObjeto.CODE;
            if (MotorDB.EnumTipoObjeto.DATABSE.ToString() == tipo)
                return EnumTipoObjeto.DATABSE;
            if (MotorDB.EnumTipoObjeto.DEFAULT.ToString() == tipo)
                return EnumTipoObjeto.DEFAULT;
            if (MotorDB.EnumTipoObjeto.FOREIGNKEY.ToString() == tipo)
                return EnumTipoObjeto.FOREIGNKEY;
            if (MotorDB.EnumTipoObjeto.FUNCION.ToString() == tipo)
                return EnumTipoObjeto.FUNCION;
            if (MotorDB.EnumTipoObjeto.IDENTITY.ToString() == tipo)
                return EnumTipoObjeto.IDENTITY;
            if (MotorDB.EnumTipoObjeto.INDEX.ToString() == tipo)
                return EnumTipoObjeto.INDEX;
            if (MotorDB.EnumTipoObjeto.PRIMARYKEY.ToString() == tipo)
                return EnumTipoObjeto.PRIMARYKEY;
            if (MotorDB.EnumTipoObjeto.PROCEDURE.ToString() == tipo)
                return EnumTipoObjeto.PROCEDURE;
            if (MotorDB.EnumTipoObjeto.TABLA_FUNCION.ToString() == tipo)
                return EnumTipoObjeto.TABLA_FUNCION;
            if (MotorDB.EnumTipoObjeto.TABLE.ToString() == tipo)
                return EnumTipoObjeto.TABLE;
            if (MotorDB.EnumTipoObjeto.TIPEDATA.ToString() == tipo)
                return EnumTipoObjeto.TIPEDATA;
            if (MotorDB.EnumTipoObjeto.TRIGER.ToString() == tipo)
                return EnumTipoObjeto.TRIGER;
            if (MotorDB.EnumTipoObjeto.UNIQUE.ToString() == tipo)
                return EnumTipoObjeto.UNIQUE;
            if (MotorDB.EnumTipoObjeto.VIEW.ToString() == tipo)
                return EnumTipoObjeto.VIEW;
            if (MotorDB.EnumTipoObjeto.TYPE_TABLE.ToString() == tipo)
                return EnumTipoObjeto.TYPE_TABLE;
            return EnumTipoObjeto.NONE;
        }
        public List<CModelObjeto> DameObjetosX1(string servidor, string conexion, bool ignorarCarpetas = true)
        {
            List<CModelObjeto> l = new List<CModelObjeto>();
            CModelConexion con = DameConexion(servidor, conexion);
            if (con == null)
                return new List<CModelObjeto>();
            //me traigo todos los objetos que pertenecen a la conecion
            var objetos = from o in Objeto where o.ID_Conexion == con.ID_Conexion select o;
            //recorro la lista para agregarlos a la otra lista
            foreach (var obj in objetos)
            {
                bool agregar = true;
                //veo si ignorarCarpetas=false, hay que regresar los objetos que no tiene carpeta asignada
                if (ignorarCarpetas == false)
                {
                    //veo si el objeto tiene una carpeta asignada
                    if (obj.ID_Carpeta != 0)
                        agregar = false;
                    //veo si el objeto esta en alguna carpeta
                    var oc = from a in ObjetoCarpeta where a.ID_Objeto == obj.ID_Objeto select a;
                    if (oc.Count() != 0)
                        agregar = false;
                }
                if (agregar)
                {
                    CModelObjeto obj2 = new CModelObjeto();
                    obj2.ID_Conexion = obj.ID_Conexion;
                    obj2.ID_Objeto = obj.ID_Objeto;
                    obj2.Nombre = obj.Nombre;
                    obj2.TipoObjeto = DameTipoObjeto(obj.TipoObjeto);
                    obj2.Eliminado = obj.Eliminado;
                    obj2.ID_Carpeta = obj.ID_Carpeta;
                    obj2.Resaltado = obj.Resaltado;
                    l.Add(obj2);
                }
            }
            return l;
        }
        public CModelObjeto DameObjeto(string servidor, string conexion, string nombre)
        {
            CModelConexion con = DameConexion(servidor, conexion);
            foreach (DataRow dr in Objeto.Rows)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == con.ID_Conexion && nombre == dr["Nombre"].ToString())
                {
                    CModelObjeto obj = new CModelObjeto();
                    obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                    obj.ID_Objeto = int.Parse(dr["ID_Objeto"].ToString());
                    obj.Nombre = dr["Nombre"].ToString();
                    obj.TipoObjeto = DameTipoObjeto(dr["TipoObjeto"].ToString());
                    bool eliminado = false;
                    bool.TryParse(dr["Eliminado"].ToString(), out eliminado);
                    obj.Eliminado = eliminado;
                    obj.Comentarios = dr["Comentarios"].ToString();
                    int id_carpeta = 0;
                    if (int.TryParse(dr["ID_Carpeta"].ToString(), out id_carpeta))
                    {
                        obj.ID_Carpeta = id_carpeta;
                    }
                    bool resaltado = false;
                    if (Boolean.TryParse(dr["Resaltado"].ToString(), out resaltado))
                    {
                        obj.Resaltado = resaltado;
                    }
                    return obj;
                }
            }
            return null;
        }
        public CModelObjeto DameObjeto(int ID_Objeto)
        {
            foreach (DataRow dr in Objeto.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto)
                {
                    CModelObjeto obj = new CModelObjeto();
                    obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                    obj.ID_Objeto = int.Parse(dr["ID_Objeto"].ToString());
                    obj.Nombre = dr["Nombre"].ToString();
                    obj.TipoObjeto = DameTipoObjeto(dr["TipoObjeto"].ToString());
                    bool eliminado = false;
                    bool.TryParse(dr["Eliminado"].ToString(), out eliminado);
                    obj.Eliminado = eliminado;
                    obj.Comentarios = dr["Comentarios"].ToString();
                    int id_carpeta = 0;
                    if (int.TryParse(dr["ID_Carpeta"].ToString(), out id_carpeta))
                    {
                        obj.ID_Carpeta = id_carpeta;
                    }
                    bool resaltado = false;
                    if (Boolean.TryParse(dr["Resaltado"].ToString(), out resaltado))
                    {
                        obj.Resaltado = resaltado;
                    }
                    return obj;
                }
            }
            return null;
        }
        public void MarcaObjeto(int ID_Objeto, bool resaltado)
        {
            foreach (DataRow dr in Objeto.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto)
                {
                    dr["Resaltado"] = resaltado;
                    Objeto.AcceptChanges();
                    Actualiza();
                    return;
                }
            }

        }
        private void ObjetoEliminado(CModelObjeto obj, bool eliminado = true)
        {
            foreach (DataRow dr in Objeto.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == obj.ID_Objeto)
                {
                    bool eliminadoActual = false;
                    bool.TryParse(dr["Eliminado"].ToString(), out eliminadoActual);
                    dr["Eliminado"] = eliminado;
                    if (eliminado != eliminadoActual)
                    {
                        if (eliminado)
                            Mensajes.Add("El objeto: " + dr["Nombre"].ToString() + " fue eliminado");
                        else
                            Mensajes.Add("El objeto: " + dr["Nombre"].ToString() + " fue reconstruido");
                    }
                    Actualiza();
                    return;
                }
            }

        }
        private void EliminaObjeto(int ID_Objeto)
        {
            var lobj = from o in Objeto where o.ID_Objeto == ID_Objeto select o;
            if (lobj.Count() == 0)
            {
                //no lo encontre por lo que no hago nada
                return;
            }
            //me traigo el objeto
            var obj = lobj.First();
            //elimino los codigos asociados al objeto
            do
            {
                var cod = from c in CodigoObjeto where c.ID_Objeto == obj.ID_Objeto select c;
                if (cod.Count() == 0)
                    break; //me salgo del bucle
                //me traigo el primero porque no puedo eliminarlo en bucle competo
                var el = cod.First();
                el.Delete();
            } while (true);
            //ahora elimino todas las relaciones que tiene con las carpetas
            do
            {
                var car = from c in ObjetoCarpeta where c.ID_Objeto == obj.ID_Objeto select c;
                if (car.Count() == 0)
                    break;
                var el = car.First();
                el.Delete();
            }
            while (true);
            //ahora elimino el objeto
            obj.Delete();
            Actualiza();

        }
        public void EliminaObjeto(string servidor, string conexion, string nombre)
        {
            CModelConexion con = DameConexion(servidor, conexion);
            //me traigo el objeto a eliminar
            var lobj = from o in Objeto where o.Nombre == nombre && o.ID_Conexion == con.ID_Conexion select o;
            if (lobj.Count() == 0)
            {
                //no lo encontre por lo que no hago nada
                return;
            }
            //me traigo el objeto
            var obj = lobj.First();
            EliminaObjeto(obj.ID_Objeto);
        }
        public void AsignaComentarioObjeto(string servidor, string conexion, string nombre, string Comentarios)
        {
            CModelConexion con = DameConexion(servidor, conexion);
            foreach (DataRow dr in Objeto.Rows)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == con.ID_Conexion && nombre == dr["Nombre"].ToString())
                {
                    dr["Comentarios"] = Comentarios;
                    Actualiza();
                    return;
                }
            }
        }
        public CModelObjeto AgregaObjeto(string servidor, string conexion, string nombre, MotorDB.EnumTipoObjeto tipo, bool ExceptioNoExists = true, int id_carpeta = 0, bool resaltado = false)
        {
            CModelConexion con = DameConexion(servidor, conexion);
            if (DameObjeto(servidor, conexion, nombre) == null)
            {
                DataRow dr = Objeto.NewObjetoRow();
                dr["Nombre"] = nombre;
                dr["ID_Conexion"] = con.ID_Conexion;
                dr["TipoObjeto"] = tipo.ToString();
                dr["Eliminado"] = false;
                dr["ID_Carpeta"] = 0;
                dr["Resaltado"] = resaltado;
                Objeto.Rows.Add(dr);
            }
            CModelObjeto obj = DameObjeto(servidor, conexion, nombre);
            if (id_carpeta != 0)
            {
                AsociaObjetoCarpeta(id_carpeta, obj.ID_Objeto);
            }
            Actualiza();
            return obj;
        }
        #endregion
        #region Administracion de codigo
        public List<CModelCodigoObjeto> DameHistorial(string servidor, string conexion, string nombre)
        {
            CModelObjeto obj = DameObjeto(servidor, conexion, nombre);
            List<CModelCodigoObjeto> l = new List<CModelCodigoObjeto>();
            if (obj == null)
                return l;
            foreach (DataRow dr in CodigoObjeto.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == obj.ID_Objeto)
                {
                    CModelCodigoObjeto obj2 = new CModelCodigoObjeto();
                    obj2.Codigo = dr["Codigo"].ToString();
                    obj2.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    obj2.ID_Codigo = int.Parse(dr["ID_Codigo"].ToString());
                    obj2.ID_Objeto = int.Parse(dr["ID_Objeto"].ToString());
                    bool visto = false;
                    bool.TryParse(dr["Visto"].ToString(), out visto);
                    obj2.Visto = visto;
                    obj2.Cometarios = dr["Cometarios"].ToString();
                    l.Add(obj2);
                }
            }
            //ahora lo ordeno por fecha decscendentemente
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[j].Fecha > l[i].Fecha)
                    {
                        //hay que intercambiarlos
                        CModelCodigoObjeto tmp = l[j];
                        l[j] = l[i];
                        l[i] = tmp;
                    }
                }
            }
            return l;
        }
        public CModelCodigoObjeto DameCodigo(string servidor, string conexion, string nombre, int ID_Codigo)
        {
            CModelObjeto obj = DameObjeto(servidor, conexion, nombre);
            if (obj == null)
                return null;
            foreach (DataRow dr in CodigoObjeto.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == obj.ID_Objeto && int.Parse(dr["ID_Codigo"].ToString()) == ID_Codigo)
                {
                    CModelCodigoObjeto obj2 = new CModelCodigoObjeto();
                    obj2.Codigo = dr["Codigo"].ToString();
                    obj2.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    obj2.ID_Codigo = int.Parse(dr["ID_Codigo"].ToString());
                    obj2.ID_Objeto = int.Parse(dr["ID_Objeto"].ToString());
                    bool visto = false;
                    bool.TryParse(dr["Visto"].ToString(), out visto);
                    obj2.Visto = visto;
                    obj2.Cometarios = dr["Cometarios"].ToString();
                    return obj2;
                }
            }
            return null;
        }
        public void HistoricoVisto(CModelCodigoObjeto obj)
        {
            foreach (DataRow dr in CodigoObjeto.Rows)
            {
                if (int.Parse(dr["ID_Codigo"].ToString()) == obj.ID_Codigo)
                {
                    dr["Visto"] = true;
                    Actualiza();
                    return;
                }
            }

        }
        public void EliminaCodigo(string servidor, string conexion, string nombre, int ID_Codigo)
        {
            CModelObjeto obj = DameObjeto(servidor, conexion, nombre);
            foreach (DataRow dr in CodigoObjeto.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == obj.ID_Objeto && int.Parse(dr["ID_Codigo"].ToString()) == ID_Codigo)
                {
                    CodigoObjeto.Rows.Remove(dr);
                    Actualiza();
                    return;
                }
            }
        }
        public bool TieneCodigo(int ID_Objeto)
        {
            var x = from a in CodigoObjeto where a.ID_Objeto == ID_Objeto select a;
            if (x.Count() > 0)
                return true;
            return false;
        }
        public CModelCodigoObjeto AgregaCodigo(string servidor, string conexion, string nombre, string codigo, bool visto = true)
        {
            CModelObjeto obj = DameObjeto(servidor, conexion, nombre);
            DataRow dr = CodigoObjeto.NewRow();
            dr["ID_Objeto"] = obj.ID_Objeto;
            dr["Fecha"] = DateTime.Now;
            dr["Codigo"] = codigo;
            dr["Visto"] = visto;
            CodigoObjeto.Rows.Add(dr);
            CModelCodigoObjeto obj2 = new CModelCodigoObjeto();
            obj2.Codigo = dr["Codigo"].ToString();
            obj2.Fecha = DateTime.Parse(dr["Fecha"].ToString());
            obj2.ID_Codigo = int.Parse(dr["ID_Codigo"].ToString());
            obj2.ID_Objeto = int.Parse(dr["ID_Objeto"].ToString());
            obj2.Cometarios = dr["Cometarios"].ToString();
            Actualiza();
            Mensajes.Add("El objeto:" + nombre + " ha sido modificado");
            return obj2;

        }
        public CModelCodigoObjeto DameUltimaVersios(string servidor, string conexion, string nombre)
        {
            List<CModelCodigoObjeto> l = DameHistorial(servidor, conexion, nombre);
            CModelCodigoObjeto ultimo = null;
            foreach (CModelCodigoObjeto obj in l)
            {
                if (ultimo == null)
                {
                    ultimo = obj;
                    continue;
                }
                if (obj.Fecha > ultimo.Fecha)
                {
                    ultimo = obj;
                }
            }
            return ultimo;
        }
        public void AsignaComentario(int ID_Codigo, string Comentarios)
        {
            foreach (DataRow dr in CodigoObjeto.Rows)
            {
                if (int.Parse(dr["ID_Codigo"].ToString()) == ID_Codigo)
                {
                    dr["Cometarios"] = Comentarios;
                    Actualiza();
                    return;
                }
            }

        }
        #endregion
        #region Monitoreo del modelo
        private BackgroundWorker backgroundWorker1;
        private string FFileName;
        public string FileName
        {
            get
            {
                return FFileName;
            }
            set
            {
                FFileName = value;
                if (System.IO.File.Exists(FFileName))
                {
                    //como xiste, lo abro
                    ReadXml(FFileName);
                }
                else
                {
                    //lo crea
                    Actualiza();
                }
            }
        }
        private void Bakup()
        {
            try
            {
                string nombre = FFileName.Substring(0, FFileName.IndexOf('.')) + "_" + System.DateTime.Now.ToString("ddMMyyyy") + ".bak";
                WriteXml(nombre);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Guarda el modelo en el archivo
        /// </summary>
        /// 
        private void Actualiza()
        {
            try
            {
                if (FFileName != "")
                {
                    WriteXml(FFileName);
                    //ahora almaceno el bakup
                    Bakup();
                }
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private IContainer components;
        public void Monitorea()
        {
            if (backgroundWorker1 == null)
                InitializeComponent();
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();

        }
        private string DameCodigoFuente(string Nombre, EnumTipoObjeto tipo, IMotorDB motor)
        {
            string s = "";
            switch (tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s = motor.DameCodigoFuncction(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s = motor.DameCodigoStoreProcedure(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s = motor.DameCodigoTabla(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s = motor.DameCodigoTrigger(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = motor.DameCodigoVista(Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s = motor.DameCodigoTypeTable(Nombre);
                    break;
            }
            return s;
        }
        private void IniciaMonitoreo()
        {
            //revisa todo elmodelo buscando cambios en la base de datos
            List<CModelServidor> servidores = DameServidores();
            foreach (CModelServidor servidor in servidores)
            {
                //ahora me traigo las conexiones
                List<CModelConexion> conexiones = DameConexiones(servidor.Nombre);
                foreach (CModelConexion conexion in conexiones)
                {
                    //me traigo el motor
                    ManagerConnect.CConexion con = new ManagerConnect.CConexion();
                    con.ConecctionString = conexion.ConecctionString;
                    con.MotorDB = conexion.MotorDB;
                    con.Nombre = conexion.Nombre;
                    IMotorDB Motor = ManagerConnect.ControladorConexiones.DameMotor(con);
                    //me traigo los objetos
                    List<CModelObjeto> objetos = DameObjetosX1(servidor.Nombre, conexion.Nombre);
                    foreach (CModelObjeto objeto in objetos)
                    {
                        string s = "";
                        //me traigo la fecha de modificacion del objeto de la base de datos
                        DateTime f = Motor.DameFechaModificacion(objeto.Nombre);
                        //me traigo la ultima version guardada
                        CModelCodigoObjeto codigo = DameUltimaVersios(servidor.Nombre, conexion.Nombre, objeto.Nombre);
                        if (codigo == null)
                        {
                            //me traigo el codigo fuente porque no tiene hitorial
                            s = DameCodigoFuente(objeto.Nombre, objeto.TipoObjeto, Motor);
                            if (s.Trim() == "")
                            {
                                //como no trajo nada, asumo que fue eliinado de la base de datos
                                ObjetoEliminado(objeto);
                                Modificado = true;
                                continue;
                            }
                            //lo agrego al modelo
                            AgregaCodigo(servidor.Nombre, conexion.Nombre, objeto.Nombre, s, false);
                            ObjetoEliminado(objeto, false);
                            Modificado = true;
                        }
                        else
                        {
                            if (f != codigo.Fecha)
                            {
                                //cambio la fecha
                                //me traigo el codigo
                                s = DameCodigoFuente(objeto.Nombre, objeto.TipoObjeto, Motor);
                                if (s.Trim() == "")
                                {
                                    //como no trajo nada, asumo que fue eliinado de la base de datos
                                    ObjetoEliminado(objeto);
                                    Modificado = true;
                                    continue;
                                }
                                else
                                {
                                    //si tiene codigo fuente
                                    if (objeto.Eliminado)
                                    {
                                        //hay que deseliminarlo
                                        ObjetoEliminado(objeto, false);
                                        Modificado = true;
                                    }
                                }
                                if (s != codigo.Codigo)
                                {
                                    //lo agrego al modelo
                                    AgregaCodigo(servidor.Nombre, conexion.Nombre, objeto.Nombre, s, false);
                                    ObjetoEliminado(objeto, false);
                                    Modificado = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private bool FMonitorear;
        public bool MonitorearEnable
        {
            get
            {
                return FMonitorear;
            }
            set
            {
                FMonitorear = value;
                if (FMonitorear == true)
                {
                    Monitorea();
                }
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ProximaConsulta = DateTime.Now.AddMinutes(-1);
            while (FMonitorear)
            {
                if (DateTime.Now >= ProximaConsulta)
                {
                    //hay que hacer un monitoreo
                    try
                    {
                        IniciaMonitoreo();
                        ProximaConsulta = DateTime.Now.AddMinutes(15);
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }
                    backgroundWorker1.ReportProgress(0);
                }
                //me duermo durante un segundo
                Thread.Sleep(1000);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (FMonitorear)
            {
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            if (OnMonitoreoParado != null)
                OnMonitoreoParado();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Modificado)
            {
                if (ONModeloChange != null)
                    ONModeloChange();
            }
            //ahora envio los mensajes encontrados
            while (Mensajes.Count > 0)
            {
                string s = Mensajes[0];
                Mensajes.RemoveAt(0);
                if (OnMensaje != null)
                {

                    OnMensaje(s);
                }
            }
            Modificado = false;
        }
        public void Refrescar()
        {
            //forza el monitoreo
            ProximaConsulta = System.DateTime.Now.AddMinutes(-1);
        }
        #endregion
        #region Administracion de codigo editable
        public List<CModelCodigoEditable> DameCodigosEditables(int ID_Objeto)
        {
            List<CModelCodigoEditable> l = new List<CModelCodigoEditable>();
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto)
                {
                    CModelCodigoEditable obj = new CModelCodigoEditable();
                    obj.Codigo = dr["Codigo"].ToString();
                    obj.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    obj.ID_Objeto = ID_Objeto;
                    obj.Nombre = dr["Nombre"].ToString();
                    l.Add(obj);
                }
            }
            return l;
        }
        public CModelCodigoEditable DameCodigoEditable(int ID_Objeto, string Nombre)
        {
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto && Nombre == dr["Nombre"].ToString())
                {
                    CModelCodigoEditable obj = new CModelCodigoEditable();
                    obj.Codigo = dr["Codigo"].ToString();
                    obj.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    obj.ID_Objeto = ID_Objeto;
                    obj.Nombre = dr["Nombre"].ToString();
                    obj.Comentarios = dr["Comentarios"].ToString();
                    return obj;
                }
            }
            return null;
        }
        public void AgregaCodigoEditable(int ID_Objeto, string Nombre, string Codigo)
        {
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto && Nombre == dr["Nombre"].ToString())
                {
                    throw new Exception("El Objeto: " + Nombre + " Ya existe");
                }
            }
            DataRow dr2 = CodigoEditable.NewRow();
            dr2["Codigo"] = Codigo;
            dr2["Fecha"] = DateTime.Now;
            dr2["Nombre"] = Nombre;
            dr2["ID_Objeto"] = ID_Objeto;
            CodigoEditable.Rows.Add(dr2);
            Actualiza();
            if (OnNewCodigoEditable != null)
                OnNewCodigoEditable(ID_Objeto);
        }
        public void AsignaComentariosCodidoEditable(int ID_Objeto, string Nombre, string Comentarios)
        {
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto && Nombre == dr["Nombre"].ToString())
                {
                    dr["Comentarios"] = Comentarios;
                    Actualiza();
                    return;
                }
            }
        }
        public void EliminaCodigoEditable(int ID_Objeto, string Nombre)
        {
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto && Nombre == dr["Nombre"].ToString())
                {
                    CodigoEditable.Rows.Remove(dr);
                    Actualiza();
                    return;
                }
            }
        }
        public void ActualizaCodigoFuenteEditable(int ID_Objeto, string Nombre, string codigo)
        {
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto && Nombre == dr["Nombre"].ToString())
                {
                    dr["Codigo"] = codigo;
                    Actualiza();
                    if (OnCodigoEditableChange != null)
                        OnCodigoEditableChange(ID_Objeto, Nombre);
                    return;
                }
            }

        }
        public void RenombrarCodigoEditable(int ID_Objeto, string Nombre, string nuevoNombre)
        {
            foreach (DataRow dr1 in CodigoEditable.Rows)
            {
                if (int.Parse(dr1["ID_Objeto"].ToString()) == ID_Objeto && nuevoNombre == dr1["Nombre"].ToString())
                {
                    throw new Exception("Ya existe un objeto con este nombre: " + nuevoNombre);
                }
            }
            foreach (DataRow dr in CodigoEditable.Rows)
            {
                if (int.Parse(dr["ID_Objeto"].ToString()) == ID_Objeto && Nombre == dr["Nombre"].ToString())
                {
                    dr["Nombre"] = nuevoNombre;
                    Actualiza();
                    if (OnNewCodigoEditable != null)
                        OnNewCodigoEditable(ID_Objeto);
                    if (OnRenameCodigoEditable != null)
                        OnRenameCodigoEditable(ID_Objeto, Nombre, nuevoNombre);
                    return;
                }
            }

        }
        #endregion
        #region Administracion de carpetas
        public List<CModelCarpeta> DameCarpetasConexion(int ID_Conexion)
        {
            List<CModelCarpeta> l = new List<CModelCarpeta>();
            foreach (DataRow dr in Carpeta)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == ID_Conexion)
                {
                    CModelCarpeta obj = new CModelCarpeta();
                    int ID_CarpetaPadre = 0;
                    if (int.TryParse(dr["ID_CarpetaPadre"].ToString(), out ID_CarpetaPadre))
                    {
                        obj.ID_CarpetaPadre = ID_CarpetaPadre;
                    }
                    if (ID_CarpetaPadre == 0)
                    {
                        // solo se añaden las carpetas raiz
                        obj.ID_Carpeta = int.Parse(dr["ID_Carpeta"].ToString());
                        obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                        obj.Nombre = dr["Nombre"].ToString();
                        obj.ID_Conexion = ID_Conexion;
                        l.Add(obj);
                    }
                }
            }
            return l;
        }
        public CModelCarpeta DameCarpeta(int ID_Carpeta)
        {
            foreach (DataRow dr in Carpeta)
            {
                if (int.Parse(dr["ID_Carpeta"].ToString()) == ID_Carpeta)
                {
                    CModelCarpeta obj = new CModelCarpeta();
                    int ID_CarpetaPadre = 0;
                    if (int.TryParse(dr["ID_CarpetaPadre"].ToString(), out ID_CarpetaPadre))
                    {
                        obj.ID_CarpetaPadre = ID_CarpetaPadre;
                    }
                    // solo se añaden las carpetas raiz
                    obj.ID_Carpeta = int.Parse(dr["ID_Carpeta"].ToString());
                    obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                    obj.Nombre = dr["Nombre"].ToString();
                    return obj; ;
                }
            }
            return null;
        }
        public List<CModelCarpeta> DameCarpetasHijas(int ID_CarpetaPadre)
        {
            List<CModelCarpeta> l = new List<CModelCarpeta>();
            foreach (DataRow dr in Carpeta)
            {
                int ID_CarpetaPadre2 = 0;
                if (int.TryParse(dr["ID_CarpetaPadre"].ToString(), out ID_CarpetaPadre2))
                {
                    if (ID_CarpetaPadre2 == ID_CarpetaPadre)
                    {
                        CModelCarpeta obj = new CModelCarpeta();
                        obj.ID_Carpeta = int.Parse(dr["ID_Carpeta"].ToString());
                        obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
                        obj.Nombre = dr["Nombre"].ToString();
                        obj.ID_CarpetaPadre = ID_CarpetaPadre2;
                        l.Add(obj);
                    }
                }
            }
            return l;
        }
        private void AsociaObjetoCarpeta(int ID_Carpeta, int ID_Objeto)
        {
            if (ID_Carpeta == 0)
            {
                //no se asocia a ninguna carpeta
                return;
            }
            //agrega un objeto a la carpeta si no existe
            var existe = (from e in ObjetoCarpeta where e.ID_Carpeta == ID_Carpeta && e.ID_Objeto == ID_Objeto select e);
            if (existe.Count() == 0)
            {
                //lo agrego
                DataRow dr = ObjetoCarpeta.NewRow();
                dr["ID_Carpeta"] = ID_Carpeta;
                dr["ID_Objeto"] = ID_Objeto;
                ObjetoCarpeta.Rows.Add(dr);
                Actualiza();
            }
        }
        public void EliminaCarpeta(int ID_Carpeta)
        {
            CModelCarpeta obj = DameCarpeta(ID_Carpeta);
            if (obj == null)
                return;
            //me traigo la carpeta a eliminar
            var carpeta = (from c in Carpeta where c.ID_Carpeta == ID_Carpeta select c).First();
            #region Muevo todos los objetos que pertenecen a la carpeta al nivel superior
            //primero todos los que esten asociados a la carpeta de forma indirecta
            var objetosc = from o in ObjetoCarpeta where o.ID_Carpeta == ID_Carpeta select o;
            foreach (var o in objetosc)
            {
                AsociaObjetoCarpeta(carpeta.ID_CarpetaPadre, o.ID_Objeto);
            }
            //para mantener la compatibilidad agreego los objetos que tiene asociada su clave de carpeta
            var objetos = (from o in Objeto where o.ID_Carpeta == ID_Carpeta select o);
            foreach (var o in objetos)
            {
                AsociaObjetoCarpeta(carpeta.ID_CarpetaPadre, o.ID_Objeto);
            }
            #endregion
            #region Muevo todos los script a la carpeta de nivel superior
            var scrips = from s in Script where s.ID_Carpeta == ID_Carpeta select s;
            foreach (var s in scrips)
            {
                s.ID_Carpeta = carpeta.ID_CarpetaPadre;
                s.AcceptChanges();
            }
            #endregion
            #region Muevo todos los documentos a la carpeta de nivel superior
            var documentos = from d in Document where d.ID_Carpeta == carpeta.ID_Carpeta select d;
            foreach (var d in documentos)
            {
                d.ID_Carpeta = carpeta.ID_CarpetaPadre;
                d.AcceptChanges();
            }
            #endregion
            #region Muevo todas las carpetas hijas
            var carpetas = from c in Carpeta where c.ID_CarpetaPadre == carpeta.ID_Carpeta select c;
            foreach (var c in carpetas)
            {
                c.ID_CarpetaPadre = carpeta.ID_CarpetaPadre;
                c.AcceptChanges();
            }
            #endregion
            //ahora elimino la carpeta
            carpeta.Delete();
            //guardo datos y propago el evento
            Actualiza();
            if (OnCarpetaModelChange != null)
                OnCarpetaModelChange();
            #region Codigo Original
            ////Busco la carpeta a eliminat
            //foreach (DataRow dr in Carpeta)
            //{
            //    if (int.Parse(dr["ID_Carpeta"].ToString()) == ID_Carpeta)
            //    {
            //        #region 000
            //        //ya la encontre pero primero paso todos los objetos que pertenecen a la carpeta a su ivel superior
            //        foreach (DataRow dr1 in Objeto.Rows)
            //        {
            //            int ID_CarpetaPadre = 0;
            //            if (int.TryParse(dr1["ID_Carpeta"].ToString(), out ID_CarpetaPadre))
            //            {
            //                if (ID_CarpetaPadre == ID_Carpeta)
            //                {
            //                    dr1["ID_Carpeta"] = obj.ID_CarpetaPadre;
            //                }
            //            }
            //        }
            //        //muevo todos los script a la carpeta de nivel superior
            //        foreach (DataRow dr3 in Script)
            //        {
            //            int ID_CarpetaPadre = 0;
            //            if (int.TryParse(dr3["ID_Carpeta"].ToString(), out ID_CarpetaPadre))
            //            {
            //                if (ID_CarpetaPadre == ID_Carpeta)
            //                {
            //                    dr3["ID_Carpeta"] = obj.ID_CarpetaPadre;
            //                }
            //            }
            //        }
            //        //muevo todos los documentos a la carpeta de nivel superior
            //        foreach (DataRow dr4 in Document)
            //        {
            //            int ID_CarpetaPadre = 0;
            //            if (int.TryParse(dr4["ID_Carpeta"].ToString(), out ID_CarpetaPadre))
            //            {
            //                if (ID_CarpetaPadre == ID_Carpeta)
            //                {
            //                    dr4["ID_Carpeta"] = obj.ID_CarpetaPadre;
            //                }
            //            }
            //        }
            //        #endregion
            //        //y tambien las carpetas hijas
            //        foreach(DataRow dr2 in Carpeta)
            //        {
            //            int ID_CarpetaPadre=0;
            //            if(int.TryParse(dr2["ID_CarpetaPadre"].ToString(),out ID_CarpetaPadre))
            //            {
            //                if(ID_CarpetaPadre==ID_Carpeta)
            //                {
            //                    dr2["ID_CarpetaPadre"] = obj.ID_CarpetaPadre;
            //                }
            //            }
            //        }
            //        Carpeta.Rows.Remove(dr);
            //        Actualiza();
            //        if (OnCarpetaModelChange != null)
            //            OnCarpetaModelChange();
            //        return;
            //    }
            //}
            #endregion
        }
        public void AgregaCarpeta(int ID_Conexion, string Nombre, int ID_CarpetaPadre)
        {
            DataRow dr = Carpeta.NewRow();
            dr["ID_Conexion"] = ID_Conexion;
            dr["Nombre"] = Nombre;
            dr["ID_CarpetaPadre"] = ID_CarpetaPadre;
            Carpeta.Rows.Add(dr);
            Actualiza();
            if (OnCarpetaModelChange != null)
                OnCarpetaModelChange();
        }
        public void MueveCarpeta(int ID_Carpeta, int ID_CarpetaDestino)
        {
            //mueve la carpeta seleccionada a otra carpeta de la misma conexion
            if (ID_Carpeta == 0)
            {
                throw new Exception("Se requiere una carpeta valida para mover");
            }
            if (ID_Carpeta == ID_CarpetaDestino)
            {
                throw new Exception("La carpeta no se puede mover a si misma");
            }
            CModelCarpeta dest = DameCarpeta(ID_CarpetaDestino);
            CModelCarpeta carpeta = DameCarpeta(ID_Carpeta);
            if (ID_CarpetaDestino != 0)
            {
                if (dest.ID_Conexion != carpeta.ID_Conexion)
                {
                    throw new Exception("La carpeta que se va a mover debe pertenecer a la misma conexion que el destino");
                }
            }
            //busco el registro
            foreach (DataRow dr in Carpeta)
            {
                if (int.Parse(dr["ID_Carpeta"].ToString()) == ID_Carpeta)
                {
                    dr["ID_CarpetaPadre"] = ID_CarpetaDestino;
                    Actualiza();
                    if (OnCarpetaModelChange != null)
                        OnCarpetaModelChange();
                    return;
                }
            }
        }
        public void MueveObjeto(int ID_Objeto, int ID_Carpeta, int ID_CarpetaOrigen)
        {
            //mueve un objeto a una carpeta en especifico
            //primero verifico que el objeto y la carpeta pertenescan a la misma conexion
            CModelCarpeta crp = DameCarpeta(ID_Carpeta);
            CModelObjeto obj = DameObjeto(ID_Objeto);
            if (obj != null && crp != null)
            {
                if (obj.ID_Conexion != crp.ID_Conexion)
                {
                    throw new Exception("La carpeta destino no pertenece a la conexion");
                }
            }
            //primero veo si el objeto ya existe en la relacion
            var existe = from e in ObjetoCarpeta where e.ID_Objeto == ID_Objeto && e.ID_Carpeta == ID_Carpeta select e;
            if (existe.Count() != 0)
            {
                //ya existe, por lo que no hago nada
                return;
            }
            //agrego la relacion
            AsociaObjetoCarpeta(ID_Carpeta, ID_Objeto);
            //ahora elimino la relacion anterior
            var obj1 = (from o in Objeto where o.ID_Objeto == ID_Objeto select o).First();
            obj1.ID_Carpeta = 0;
            obj1.AcceptChanges();
            //elimino la relacion de la carpeta original
            var oc = from obc in ObjetoCarpeta where obc.ID_Carpeta == ID_CarpetaOrigen && obc.ID_Objeto == ID_Objeto select obc;
            if (oc.Count() != 0)
            {
                var obc = oc.First();
                obc.Delete();
            }
            Actualiza();
            if (OnCarpetaModelChange != null)
                OnCarpetaModelChange();
        }
        public void RenombraCarpeta(int ID_Carpeta, string nuevoNombre)
        {
            foreach (DataRow dr in Carpeta)
            {
                if (int.Parse(dr["ID_Carpeta"].ToString()) == ID_Carpeta)
                {
                    dr["Nombre"] = nuevoNombre;
                    Actualiza();
                    if (OnCarpetaModelChange != null)
                        OnCarpetaModelChange();
                    return;
                }
            }
        }
        public string DameCoemtariosCarpeta(int ID_Carpeta)
        {
            foreach (DataRow dr in Carpeta)
            {
                if (int.Parse(dr["ID_Carpeta"].ToString()) == ID_Carpeta)
                {
                    return dr["Comentarios"].ToString();
                }
            }
            return "";
        }
        public void AsignaComentariosCarpeta(int ID_Carpeta, string comentarios)
        {
            foreach (DataRow dr in Carpeta)
            {
                if (int.Parse(dr["ID_Carpeta"].ToString()) == ID_Carpeta)
                {
                    dr["Comentarios"] = comentarios;
                    Actualiza();
                    return;
                }
            }

        }
        public List<CModelObjeto> DameObjetosCarpeta(int ID_Carpeta)
        {
            List<CModelObjeto> l = new List<CModelObjeto>();
            //Me traigo los objetos que pertenecen a la carpeta
            var l1 = ((from o in Objeto where o.ID_Carpeta == ID_Carpeta select o).Union(from o in Objeto join oc in ObjetoCarpeta on o.ID_Objeto equals oc.ID_Objeto where oc.ID_Carpeta == ID_Carpeta select o)).Distinct();
            foreach (var o in l1)
            {
                CModelObjeto obj = new CModelObjeto();
                obj.ID_Conexion = o.ID_Conexion;
                obj.ID_Objeto = o.ID_Objeto;
                obj.Nombre = o.Nombre;
                obj.TipoObjeto = DameTipoObjeto(o.TipoObjeto);
                obj.Eliminado = o.Eliminado;
                obj.ID_Carpeta = ID_Carpeta;
                obj.Resaltado = o.Resaltado;
                l.Add(obj);
            }
            return l;
        }
        public void QuitaObjetoCarpeta(int ID_Carpeta, int ID_Objeto)
        {
            var l = from oc in ObjetoCarpeta where oc.ID_Objeto == ID_Objeto && oc.ID_Carpeta == ID_Carpeta select oc;
            if (l.Count() != 0)
            {
                var oc = l.First();
                oc.Delete();
            }
            //veo si el objeto se encuentra en alguna otra carpeta
            var l2 = from oc in ObjetoCarpeta where oc.ID_Objeto == ID_Objeto select oc;
            if (l2.Count() == 0)
            {
                //ya no se encuentra asociado a ninguna otra carpeta, por lo que hay que quitarlo del proyecto
                EliminaObjeto(ID_Objeto);
            }
        }
        #endregion
        #region Manejo de Scripts
        //las opciones que se van a manejar son
        // extraer el comentario de un script
        //asignar el comentario a un script
        /// <summary>
        /// comvierte un DataRow a CModelScript
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private CModelScript RownToScript(DataRow dr)
        {
            CModelScript obj = new CModelScript();
            obj.ID_Script = int.Parse(dr["ID_Script"].ToString());
            obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
            int ID_Carpeta = 0;
            if (int.TryParse(dr["ID_Carpeta"].ToString(), out ID_Carpeta))
            {
                obj.ID_Carpeta = ID_Carpeta;
            }
            obj.Nombre = dr["Nombre"].ToString();
            return obj;
        }
        /// <summary>
        /// Regresa un scrip especifico
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <returns></returns>
        public CModelScript DameScript(int ID_Script)
        {
            foreach (DataRow dr in Script)
            {
                if (int.Parse(dr["ID_Script"].ToString()) == ID_Script)
                {
                    return RownToScript(dr);
                }
            }
            return null;
        }
        /// <summary>
        /// Regresa todos los escrips de la conexion. Si Tosdos=false se trae solo aquellos que no pertenecen a ninguna carpeta
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="Todos"></param>
        /// <returns></returns>
        public List<CModelScript> DameScriptsConexion(int ID_Conexion, bool Todos = true)
        {
            List<CModelScript> l = new List<CModelScript>();
            foreach (DataRow dr in Script)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == ID_Conexion)
                {
                    CModelScript obj = RownToScript(dr);
                    if (Todos == true)
                    {
                        l.Add(obj);
                    }
                    else
                    {
                        //solo llos que no tiene carpeta asignada
                        if (obj.ID_Carpeta == 0)
                        {
                            l.Add(obj);
                        }
                    }
                }
            }
            return l;
        }
        /// <summary>
        /// reresa todos los scripts que pertenecen a ua carpeta
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        public List<CModelScript> DameScriptsCarpeta(int ID_Carpeta)
        {
            List<CModelScript> l = new List<CModelScript>();
            foreach (DataRow dr in Script)
            {
                int id_carpeta = 0;
                if (int.TryParse(dr["ID_Carpeta"].ToString(), out id_carpeta))
                {

                    if (id_carpeta == ID_Carpeta)
                    {
                        CModelScript obj = RownToScript(dr);
                        l.Add(obj);
                    }
                }
            }
            return l;
        }
        /// <summary>
        /// regresa el registro que pertenece al script
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <returns></returns>
        private DataRow GetRowScript(int ID_Script)
        {
            foreach (DataRow dr in Script)
            {
                if (int.Parse(dr["ID_Script"].ToString()) == ID_Script)
                {
                    return dr;
                }
            }
            return null;
        }
        /// <summary>
        /// actualiza los datos del script en la tabla
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateScript(CModelScript obj)
        {
            DataRow dr = GetRowScript(obj.ID_Script);
            if (dr == null)
            {
                throw new Exception("No se encontrò el script ");
            }
            dr["ID_Conexion"] = obj.ID_Conexion;
            dr["ID_Carpeta"] = obj.ID_Carpeta;
            dr["Nombre"] = obj.Nombre;
            Actualiza();
            if (OnScriptModelChange != null)
                OnScriptModelChange();
        }
        /// <summary>
        /// Mueve el script a la carpeta
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <param name="ID_Carpeta"></param>
        public void MueveScript(int ID_Script, int ID_Carpeta, int ID_Conexion)
        {
            CModelScript script = DameScript(ID_Script);
            CModelCarpeta carpeta = DameCarpeta(ID_Carpeta);
            if (script == null)
            {
                throw new Exception("No se reconoce el script");
            }
            if (carpeta == null && ID_Carpeta != 0)
            {
                throw new Exception("No se reconoce la carpeta");
            }
            if (ID_Carpeta == 0 && script.ID_Conexion != ID_Conexion)
            {
                throw new Exception("No se puede mover entre diferentes conexiones");

            }
            //ahora valido que no se trate de mover de una conexion a tras
            if (ID_Carpeta != 0 && script.ID_Conexion != carpeta.ID_Conexion)
            {
                throw new Exception("No se puede mover entre diferentes conexiones");
            }
            //por ultimo valido que no se quiera mover a la misma carpeta
            if (script.ID_Carpeta == ID_Carpeta)
            {
                //no hago nada
                return;
            }
            //ahora muevo la carpeta
            script.ID_Carpeta = ID_Carpeta;
            UpdateScript(script);
        }
        /// <summary>
        /// Agrega un nuevo scrip al modelo
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="ID_Carpeta"></param>
        /// <param name="Nombre"></param>
        /// <param name="Codigo"></param>
        /// <param name="Comentarios"></param>
        public CModelScript AgregaScript(int ID_Conexion, int ID_Carpeta, string Nombre, string Codigo = "", string Comentarios = "")
        {
            DataRow dr = Script.NewRow();
            dr["ID_Conexion"] = ID_Conexion;
            dr["ID_Carpeta"] = ID_Carpeta;
            dr["Nombre"] = Nombre;
            dr["Codigo"] = Codigo;
            dr["Comentarios"] = Comentarios;
            Script.Rows.Add(dr);
            Actualiza();
            if (OnScriptModelChange != null)
                OnScriptModelChange();
            return RownToScript(dr);
        }
        /// <summary>
        /// elimina el scrip del modelo
        /// </summary>
        /// <param name="ID_Script"></param>
        public void EliminaScript(int ID_Script)
        {
            DataRow dr = GetRowScript(ID_Script);
            Script.Rows.Remove(dr);
            Actualiza();
            if (OnScriptModelChange != null)
                OnScriptModelChange();
        }
        /// <summary>
        /// Cambia el nombre del script
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <param name="Nombre"></param>
        public void RenameScript(int ID_Script, string Nombre)
        {

            CModelScript obj = DameScript(ID_Script);
            if (obj == null)
            {
                throw new Exception("No se encontró el script");
            }
            string oldName = obj.Nombre;
            obj.Nombre = Nombre;
            UpdateScript(obj);
            if (OnScriptNameChange != null)
                OnScriptNameChange(ID_Script, oldName, Nombre);
        }
        /// <summary>
        /// regresa el codigo del script
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <returns></returns>
        public string DameCodigoScript(int ID_Script)
        {
            DataRow dr = GetRowScript(ID_Script);
            return dr["Codigo"].ToString();

        }
        /// <summary>
        /// Asigna el codigo del script
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <param name="Codigo"></param>
        public void AsignaCodigoScript(int ID_Script, string Codigo)
        {
            DataRow dr = GetRowScript(ID_Script);
            dr["Codigo"] = Codigo;
            Actualiza();
        }
        /// <summary>
        /// regresa los comentarios del script
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <returns></returns>
        public string DameComentariosScript(int ID_Script)
        {
            DataRow dr = GetRowScript(ID_Script);
            return dr["Comentarios"].ToString();

        }
        /// <summary>
        /// Asigna Comentarios al script
        /// </summary>
        /// <param name="ID_Script"></param>
        /// <param name="Comentarios"></param>
        public void AsignaComentariosScript(int ID_Script, string Comentarios)
        {
            DataRow dr = GetRowScript(ID_Script);
            dr["Comentarios"] = Comentarios;
            Actualiza();
        }
        #endregion
        #region Manejo de Dcoumentos
        //las opciones que se van a manejar son
        // extraer el comentario de un Document
        //asignar el comentario a un Document
        /// <summary>
        /// comvierte un DataRow a CModelDocument
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private CModelDocument RownToDocument(DataRow dr)
        {
            CModelDocument obj = new CModelDocument();
            obj.ID_Document = int.Parse(dr["ID_Document"].ToString());
            obj.ID_Conexion = int.Parse(dr["ID_Conexion"].ToString());
            int ID_Carpeta = 0;
            if (int.TryParse(dr["ID_Carpeta"].ToString(), out ID_Carpeta))
            {
                obj.ID_Carpeta = ID_Carpeta;
            }
            obj.Nombre = dr["Nombre"].ToString();
            return obj;
        }
        /// <summary>
        /// Regresa un Documento especifico
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <returns></returns>
        public CModelDocument DameDocument(int ID_Document)
        {
            foreach (DataRow dr in Document)
            {
                if (int.Parse(dr["ID_Document"].ToString()) == ID_Document)
                {
                    return RownToDocument(dr);
                }
            }
            return null;
        }
        /// <summary>
        /// Regresa todos los documentos de la conexion. Si Tosdos=false se trae solo aquellos que no pertenecen a ninguna carpeta
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="Todos"></param>
        /// <returns></returns>
        public List<CModelDocument> DameDocumentosConexion(int ID_Conexion, bool Todos = true)
        {
            List<CModelDocument> l = new List<CModelDocument>();
            foreach (DataRow dr in Document)
            {
                if (int.Parse(dr["ID_Conexion"].ToString()) == ID_Conexion)
                {
                    CModelDocument obj = RownToDocument(dr);
                    if (Todos == true)
                    {
                        l.Add(obj);
                    }
                    else
                    {
                        //solo llos que no tiene carpeta asignada
                        if (obj.ID_Carpeta == 0)
                        {
                            l.Add(obj);
                        }
                    }
                }
            }
            return l;
        }
        /// <summary>
        /// reresa todos los Documentos que pertenecen a una carpeta
        /// </summary>
        /// <param name="ID_Carpeta"></param>
        /// <returns></returns>
        public List<CModelDocument> DameDocumentosCarpeta(int ID_Carpeta)
        {
            List<CModelDocument> l = new List<CModelDocument>();
            foreach (DataRow dr in Document)
            {
                int id_carpeta = 0;
                if (int.TryParse(dr["ID_Carpeta"].ToString(), out id_carpeta))
                {

                    if (id_carpeta == ID_Carpeta)
                    {
                        CModelDocument obj = RownToDocument(dr);
                        l.Add(obj);
                    }
                }
            }
            return l;
        }
        /// |summary>
        /// regresa el registro que pertenece al Documento
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <returns></returns>
        private DataRow GetRowDocument(int ID_Document)
        {
            foreach (DataRow dr in Document)
            {
                if (int.Parse(dr["ID_Document"].ToString()) == ID_Document)
                {
                    return dr;
                }
            }
            return null;
        }
        /// <summary>
        /// actualiza los datos del Document en la tabla
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateDocument(CModelDocument obj)
        {
            DataRow dr = GetRowDocument(obj.ID_Document);
            if (dr == null)
            {
                throw new Exception("No se encontrò el Document ");
            }
            dr["ID_Conexion"] = obj.ID_Conexion;
            dr["ID_Carpeta"] = obj.ID_Carpeta;
            dr["Nombre"] = obj.Nombre;
            Actualiza();
            if (OnDocumentModelChange != null)
                OnDocumentModelChange();
        }
        /// <summary>
        /// Mueve el Documento a la carpeta
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <param name="ID_Carpeta"></param>
        public void MueveDocumento(int ID_Document, int ID_Carpeta, int ID_Conexion)
        {
            CModelDocument Document = DameDocument(ID_Document);
            CModelCarpeta carpeta = DameCarpeta(ID_Carpeta);
            if (Document == null)
            {
                throw new Exception("No se reconoce el Documento");
            }
            if (carpeta == null && ID_Carpeta != 0)
            {
                throw new Exception("No se reconoce la carpeta");
            }
            //Øhora valido que no se trate de mover de una conexion a tras
            if (ID_Carpeta == 0 && Document.ID_Conexion != ID_Conexion)
            {
                throw new Exception("No se puede mover entre diferentes conexiones");
            }
            if (ID_Carpeta != 0 && Document.ID_Conexion != carpeta.ID_Conexion)
            {
                throw new Exception("No se puede mover entre diferentes conexiones");
            }
            //por ultimo valido que no se quiera mover a la misma carpeta
            if (Document.ID_Carpeta == ID_Carpeta)
            {
                //no hago nada
                return;
            }
            //ahora muevo la carpeta
            Document.ID_Carpeta = ID_Carpeta;
            UpdateDocument(Document);
        }
        /// <summary>
        /// Agrega un nuevo Documento al modelo
        /// </summary>
        /// <param name="ID_Conexion"></param>
        /// <param name="ID_Carpeta"></param>
        /// <param name="Nombre"></param>
        /// <param name="Texto"></param>
        public CModelDocument AgregaDocumento(int ID_Conexion, int ID_Carpeta, string Nombre, string Texto = "")
        {
            DataRow dr = Document.NewRow();
            dr["ID_Conexion"] = ID_Conexion;
            dr["ID_Carpeta"] = ID_Carpeta;
            dr["Nombre"] = Nombre;
            dr["Texto"] = Texto;
            Document.Rows.Add(dr);
            Actualiza();
            if (OnDocumentModelChange != null)
                OnDocumentModelChange();
            return RownToDocument(dr);
        }
        /// <summary>
        /// elimina el documento del modelo
        /// </summary>
        /// <param name="ID_Document"></param>
        public void EliminaDocumento(int ID_Document)
        {
            DataRow dr = GetRowDocument(ID_Document);
            Document.Rows.Remove(dr);
            Actualiza();
            if (OnDocumentModelChange != null)
                OnDocumentModelChange();
        }
        /// <summary>
        /// Cambia el nombre del Document
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <param name="Nombre"></param>
        public void RenameDocument(int ID_Document, string Nombre)
        {
            CModelDocument obj = DameDocument(ID_Document);
            if (obj == null)
            {
                throw new Exception("No se encontró el Documento");
            }
            obj.Nombre = Nombre;
            UpdateDocument(obj);
            if (OnDocumentNameChange != null)
                OnDocumentNameChange(ID_Document);
        }
        /// <summary>
        /// regresa el Texto del Document
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <returns></returns>
        public string DameTextoDocumento(int ID_Document)
        {
            DataRow dr = GetRowDocument(ID_Document);
            return dr["Texto"].ToString();

        }
        /// <summary>
        /// Asigna el Texto del Document
        /// </summary>
        /// <param name="ID_Document"></param>
        /// <param name="Texto"></param>
        public void AsignaTextoDocumento(int ID_Document, string Texto)
        {
            DataRow dr = GetRowDocument(ID_Document);
            dr["Texto"] = Texto;
            dr.AcceptChanges();
            Actualiza();
            if (OnCodigoDocumentChange != null)
                OnCodigoDocumentChange(ID_Document);
        }
        #endregion
    }
}
