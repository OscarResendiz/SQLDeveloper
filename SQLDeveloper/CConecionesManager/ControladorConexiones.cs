using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using MotorDB;

namespace ManagerConnect
{
    //esta clase se encarga de administrar todas las conexiones 
    public class ControladorConexiones
    {
        private static ModeloConexiones FModelo;
        private static string DirConexionesFile
        {
            get
            {
                string s, dir = Application.ExecutablePath;
                int i, n;
                n = dir.Length;
                for (i = n - 1; i > 0; i--)
                {
                    if (dir[i] == '\\')
                        break;
                }
                s = dir.Substring(0, i);
                return s + "\\Conexiones.xml";
            }
        }
        private static void GuardaModelo()
        {
            //guarda el modelo de las conexiones en un archivo en el directorio en que se encuentrra la aplicacion
            if (FModelo == null)
            {
                //creo el modelo
                FModelo = new ModeloConexiones();
            }
            FModelo.WriteXml(DirConexionesFile);
        }
        private static void CargaModelo()
        {
            //lee el modelo del archivo de conexiones
            if (FModelo == null)
            {
                FModelo = new ModeloConexiones();
            }
            if (System.IO.File.Exists(DirConexionesFile))
                FModelo.ReadXml(DirConexionesFile);
        }
        private static ModeloConexiones Modelo
        {
            get
            {
                if (FModelo == null)
                    CargaModelo();
                return FModelo;
            }
        }
        public static void AddGrupo(string grupo)
        {
            //agrega un nuevo grupo al modelo
            //me traigo la tabla de grupos
            var x = from z in Modelo.Grupo where z.Nombre == grupo select z;
            if (x.Count() > 0)
            {
                //si se encontro el grupo por lo que no hago nada
                throw new Exception("El grupo ya existe");
            }
            DataTable dt = Modelo.Tables["Grupo"];
            //creo el nuevo grupo
            DataRow dr = dt.NewRow();
            dr["Nombre"] = grupo;
            //lo agrego a la tabla
            dt.Rows.Add(dr);
            //actualizo el modelo
            GuardaModelo();
        }
        public static List<string> GetGrupos()
        {
            //regresa un listado con todos los grupos almacenados
            List<string> l = new List<string>();
            //hago la consulta de todos los grupos
            var query = from grupos in Modelo.Grupo select grupos;
            foreach (var obj in query)
            {
                l.Add(obj.Nombre);
            }
            return l;
        }
        private static int GetIDGrupo(string grupo)
        {
            //regresa el ID del grupo
            var obj = (from Grupo in Modelo.Grupo where Grupo.Nombre == grupo select Grupo).First();
            if (obj == null)
                return -1;
            return obj.ID_Grupo;
        }
        private static int GetIDConecxion(string grupo, string nombre)
        {
            try
            {
                //regresa el id de la conexion que pertenece al grupo
                var conexion = (from c in Modelo.Conexion
                                join g in Modelo.Grupo on c.ID_Grupo equals g.ID_Grupo
                                where g.Nombre == grupo && c.Nombre == nombre
                                select c).First();
                if (conexion == null)
                    return -1;
                return conexion.ID_Conexion;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public static void AddConexion(string grupo, string motorDataBase, string nombre, string connectionString)
        {
            //agrega una conexion al grupo indicado
            //si el grupo no existe, lo agrega
            //primero busco el grupo
            int id_grupo = GetIDGrupo(grupo);
            //verifico si lo encontro
            if (id_grupo == -1)
            {
                //no existe, por lo que lo agrego
                AddGrupo(grupo);
                //me lo vuelvo a traer
                id_grupo = GetIDGrupo(grupo);
            }
            //verifico si existe la conexion
            int id_conexion = GetIDConecxion(grupo, nombre);
            if (id_conexion != -1)
            {
                //la conexion ya existe, por lo que hay que actualizarla
                var con = (from c in Modelo.Conexion where c.ID_Conexion == id_conexion && c.ID_Grupo == id_grupo select c).First();
                con.MotorDB = motorDataBase;
                con.ConecctionString = CSeguridad.Encriptar(connectionString);
            }
            else
            {
                //agrego la nueva conexion
                DataTable dt = Modelo.Tables["Conexion"];
                DataRow dr = dt.NewRow();
                dr["Nombre"] = nombre;
                dr["ConecctionString"] = CSeguridad.Encriptar(connectionString);
                dr["ID_Grupo"] = id_grupo;
                dr["MotorDB"] = motorDataBase;
                dt.Rows.Add(dr);
            }
            GuardaModelo();
        }
        public static void DeleteConexion(string grupo, string nombre)
        {
            //elimina la conexion del grupo
            //me traigo el ID del grupo
            int id_grupo = GetIDGrupo(grupo);
            if (id_grupo == -1)
            {
                //no se puede eliinar porque no existe el grupo
                return;
            }
            var obj = (from c in Modelo.Conexion where c.Nombre == nombre && c.ID_Grupo == id_grupo select c).First();
            obj.Delete();
            GuardaModelo();
        }
        public static void DeleteGrupo(string nombre)
        {
            //elimina aun grupo incluyendo todas sus conexiones
            //e traigo el ID del grupo
            int id_grupo = GetIDGrupo(nombre);
            //me traigo todas sus conexiones
            //var objs = Modelo.Conexion.Where(x => x.ID_Grupo == id_grupo);
            //            var objs = from c in Modelo.Conexion where c.ID_Grupo == id_grupo select c;
            var objs = (from c in Modelo.Conexion where c.ID_Grupo == id_grupo select c).ToList();

            foreach (var obj in objs)
            {
                obj.Delete();
            }
            //ahora me traigo el grupo
            var grupo = (from g in Modelo.Grupo where g.ID_Grupo == id_grupo select g).First();
            grupo.Delete();
            GuardaModelo();
        }
        public static List<CConexion> GetConexiones(string grupo)
        {
            List<CConexion> l = new List<CConexion>();
            //me traigo el grupo al que pertenece
            int id_grupo = GetIDGrupo(grupo);
            var r = from c in Modelo.Conexion where c.ID_Grupo == id_grupo select c;
            foreach (var obj in r)
            {
                CConexion con = new CConexion();
                con.ConecctionString = CSeguridad.DesEncriptar(obj.ConecctionString);
                con.ID_Conexion = obj.ID_Conexion;
                con.ID_Grupo = obj.ID_Grupo;
                con.MotorDB = obj.MotorDB;
                con.Nombre = obj.Nombre;
                l.Add(con);
            }
            return l;
        }
        public static CConexion GetConexion(string grupo, string nombre)
        {
            //regresa la conexion solicitada
            try
            {
                //regresa el id de la conexion que pertenece al grupo
                var conexion = (from c in Modelo.Conexion
                                join g in Modelo.Grupo on c.ID_Grupo equals g.ID_Grupo
                                where g.Nombre == grupo && c.Nombre == nombre
                                select c).First();
                if (conexion == null)
                    return null;
                CConexion con = new CConexion();
                con.ConecctionString = CSeguridad.DesEncriptar(conexion.ConecctionString);
                con.ID_Conexion = conexion.ID_Conexion;
                con.ID_Grupo = conexion.ID_Grupo;
                con.MotorDB = conexion.MotorDB;
                con.Nombre = conexion.Nombre;
                return con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private static bool ExisteConexion(string grupo, string nombre)
        {
            try
            {
                var conexion = (from c in Modelo.Conexion
                                join g in Modelo.Grupo on c.ID_Grupo equals g.ID_Grupo
                                where g.Nombre == grupo && c.Nombre == nombre
                                select c).First();
                if (conexion == null)
                    return false;
            }
            catch (System.InvalidOperationException ex)
            {
                return false;
            }
            return true;
        }

        public static void ActualizaConexion(string grupo, string nombre, string connectionString, string nuevoNombre)
        {
            if (nombre != nuevoNombre && nuevoNombre != null && nuevoNombre != "")
            {
                if (ExisteConexion(grupo, nuevoNombre))
                {
                    throw new Exception("El nuevo nombre de la conexion ya existe");
                }
            }
            //me traigo la conexion que pertenece al grupo
            var conexion = (from c in Modelo.Conexion
                            join g in Modelo.Grupo on c.ID_Grupo equals g.ID_Grupo
                            where g.Nombre == grupo && c.Nombre == nombre
                            select c).First();
            if (conexion == null)
                return;
            //actualizo los datos
            conexion.ConecctionString = CSeguridad.Encriptar(connectionString);
            if (nombre != nuevoNombre && nuevoNombre != null && nuevoNombre != "")
            {
                conexion.Nombre = nuevoNombre;
            }
            GuardaModelo();

        }
        public static EnumMotoresDB DameTipoMotor(string nombre)
        {
            EnumMotoresDB motor = EnumMotoresDB.SQLSERVER;
            if (nombre == EnumMotoresDB.MYSQL.ToString())
                motor = EnumMotoresDB.MYSQL;
            if (nombre == EnumMotoresDB.POSTGRES.ToString())
                motor = EnumMotoresDB.POSTGRES;
            if (nombre == EnumMotoresDB.SQLSERVER.ToString())
                motor = EnumMotoresDB.SQLSERVER;
            return motor;
        }
        public static IMotorDB DameMotor(CConexion conexion)
        {
            MotorDB.EnumMotoresDB tipoDB = ControladorConexiones.DameTipoMotor(conexion.MotorDB);
            IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(tipoDB);
            motor.SetConnectionString(conexion.ConecctionString);
            return motor;
        }
        /// <summary>
        /// Regresa los datos del modelo que pertenecen al motor 
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        public static CPropiedadesMotor DamePropiedadesMotor(IMotorDB motor)
        {
            CPropiedadesMotor obj = new CPropiedadesMotor();
            string cadenaconexion = motor.GetConecctionString().ToUpper().Trim();
            try
            {
                //me traigo los datos de la conexion
                var res = (from c in Modelo.Conexion
                           join g in Modelo.Grupo on c.ID_Grupo equals g.ID_Grupo
                           where CSeguridad.DesEncriptar(c.ConecctionString).ToUpper().Trim() == cadenaconexion
                           select new
                           {
                               c.ConecctionString,
                               c.ID_Conexion,
                               c.ID_Grupo,
                               c.MotorDB,
                               c.Nombre,
                               Grupo = g.Nombre
                           }).First();
                if (res != null)
                {

                    obj.Conexion.ConecctionString = res.ConecctionString;
                    obj.Conexion.ID_Conexion = res.ID_Conexion;
                    obj.Conexion.ID_Grupo = res.ID_Grupo;
                    obj.Conexion.MotorDB = res.MotorDB;
                    obj.Conexion.Nombre = res.Nombre;
                    obj.Grupo = res.Grupo;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return obj;
        }
    }
}
