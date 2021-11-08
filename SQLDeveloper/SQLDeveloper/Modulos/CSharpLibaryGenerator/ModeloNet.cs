using System.Linq;
using System.Data;
using System.Collections.Generic;
namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    #region Delegados
    public delegate void OnModeloNetEvent(ModeloNet sender);
    #endregion
    public partial class ModeloNet
    {
        #region eventos
        public event OnModeloNetEvent OnProjectNameChange;
        public event OnModeloNetEvent OnServidorChange;
        public event OnModeloNetEvent OnConexionChange;
        public event OnModeloNetEvent OnClassChange;
        public event OnModeloNetEvent OnStoreProcedureChange;
        #endregion
        partial class ConexionDataTable
        {
        }
        #region General
        public string DirectorioDestino
        {
            get
            {
                return GetPropertyString("DirectorioDestino");
            }
            set
            {
                SetPropertyString("DirectorioDestino", value);
            }
        }
        public string TipoLibreria
        {
            get
            {
                return GetPropertyString("TipoLibreria");
            }
            set
            {
                SetPropertyString("TipoLibreria", value);
            }
        }
        public List<string> DameListaGeneradores()
        {
            List<string> l = new List<string>();
            l.Add("Clases LinQ");
            return l;
        }
        /// <summary>
        /// regresa el generador correspondiente al tipo de libreria configurada
        /// </summary>
        /// <returns></returns>
        public Generadores.IGenradorCodigo DameGenerador()
        {
            Generadores.IGenradorCodigo obj = null;
            switch (TipoLibreria)
            {
                case "Clases LinQ":
                    obj = new Generadores.GeneradorCSharp();
                    break;
                default:
                    obj = new Generadores.GeneradorCSharp();
                    break;
            }
            obj.SetModelo(this);
            return obj;
        }
        public string ProjectName
        {
            set
            {
                SetPropertyString("ProjectName", value);
                if (OnProjectNameChange != null)
                    OnProjectNameChange(this);
            }
            get
            {
                return GetPropertyString("ProjectName").Replace(" ", "_");
            }
        }
        public string FileName
        {
            get;
            set;
        }
        public void Abrir()
        {
            ReadXml(FileName);
            //mando a leer todos los datos del modelo
            ServidorChange();
            ConexionChange();
            ClassChange();
            StoreProcedureChange();

        }
        public void Guardar()
        {
            try
            {
                WriteXml(FileName);
                Bakup();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void Bakup()
        {
            try
            {
                string nombre = FileName.Substring(0, FileName.IndexOf('.')) + "_" + System.DateTime.Now.ToString("ddMMyyyy") + ".bak";
                WriteXml(nombre);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        public string GetPropertyString(string propiedad)
        {
            var r = (from obj in General where obj.Propiedad == propiedad select obj.Valor);
            if (r.Count() > 0)
            {
                return r.Single();
            }
            return "";
        }
        public int GetPropertyInt(string propiedad)
        {
            int valor = 0;
            var r = (from obj in General where obj.Propiedad == propiedad select obj.Valor).Single();
            int.TryParse(r, out valor);
            return valor;
        }
        public bool GetPropertyBool(string propiedad)
        {
            bool valor = false;
            var r = (from obj in General where obj.Propiedad == propiedad select obj.Valor).Single();
            bool.TryParse(r, out valor);
            return valor;
        }
        public void SetPropertyString(string propiedad, string valor)
        {
            foreach (DataRow dr in General.Rows)
            {
                if (dr["Propiedad"].ToString() == propiedad)
                {
                    dr["Valor"] = valor;
                    //Guardar();
                    return;
                }
            }
            //como no existe, lo agrego
            DataRow dr2 = General.NewRow();
            dr2["Propiedad"] = propiedad;
            dr2["Valor"] = valor;
            General.Rows.Add(dr2);
            //Guardar();
        }
        public void SetPropertyInt(string propiedad, int valor)
        {
            SetPropertyString(propiedad, valor.ToString());
        }
        public void SetPropertyBool(string propiedad, bool valor)
        {
            SetPropertyString(propiedad, valor.ToString());

        }
        #endregion
        #region Administracion de servidores
        /// <summary>
        /// regresa el listado de todos los servidores que se encuentran en el proyecto
        /// </summary>
        /// <returns></returns>
        public List<Cservidor> DameServidores()
        {
            List<Cservidor> l = new List<Cservidor>();
            var lista = (from servidores in Servidor select servidores);
            foreach (var obj in lista)
            {
                l.Add(
                    new Cservidor
                    {
                        Nombre = obj.Nombre,
                        ID_Servidor = obj.ID_Servidor
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa el servidor por medio de su ID. Si no lo encuentra regresa NULL
        /// </summary>
        /// <param name="id_servidor"></param>
        /// <returns></returns>
        public Cservidor DameServidor(int id_servidor)
        {
            var r = (from servidor in Servidor where servidor.ID_Servidor == id_servidor select servidor).Single();
            if (r == null)
                return null;
            return new Cservidor
            {
                ID_Servidor = r.ID_Servidor,
                Nombre = r.Nombre
            };

        }
        /// <summary>
        /// regresa el servidor por medio del nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Cservidor DameServidor(string nombre)
        {
            var r = (from servidor in Servidor where servidor.Nombre == nombre select servidor);//.Single();
            if (r.Count() == 0)
                return null;
            var r2 = r.First();
            return new Cservidor
            {
                ID_Servidor = r2.ID_Servidor,
                Nombre = r2.Nombre
            };
        }
        /// <summary>
        /// agrega un servidor a la base
        /// </summary>
        /// <param name="nombre"></param>
        /// 
        public void AgregaServidor(string nombre)
        {
            Cservidor obj = DameServidor(nombre);
            if (obj != null)
            {
                throw new System.Exception("El servidor ya existe");
            }
            DataRow dr = Servidor.NewRow();
            dr["Nombre"] = nombre;
            Servidor.Rows.Add(dr);
            ServidorChange();
        }
        /// <summary>
        /// Cambia el nombre del servidor 
        /// </summary>
        /// <param name="id_servidor"></param>
        /// <param name="nuevoNombre"></param>
        public void CambiaNombreServidor(int id_servidor, string nuevoNombre)
        {
            var r = (from servidor in Servidor where servidor.ID_Servidor == id_servidor select servidor).Single();
            if (r == null)
            {
                throw new System.Exception("No se encontó el servidor");
            }
            r.Nombre = nuevoNombre;
            r.AcceptChanges();
            ServidorChange();
        }
        /// <summary>
        /// elimina un srvidor del proyecto
        /// </summary>
        /// <param name="id_servidor"></param>
        public void EliminaServidor(int id_servidor)
        {
            var vexiste = (from con in Conexion where con.ID_Servidor == id_servidor select con).Single();
            if (vexiste != null)
            {
                throw new System.Exception("El servidor tiene conexiones asociadas");
            }
            var r = (from servidor in Servidor where servidor.ID_Servidor == id_servidor select servidor).Single();
            if (r == null)
                return;
            r.Delete();
            ServidorChange();
        }
        #endregion
        #region Administracion de conexiones
        /// <summary>
        /// regresa las conexiones relacionadas a la clase
        /// </summary>
        /// <param name="ID_Class"></param>
        /// <returns></returns>
        public List<CConexion> DameConexionesClase(int ID_Class)
        {
            List<CConexion> l = new List<CConexion>();
            var res = (
                    from con in Conexion
                    join sp in StoreProcedures on con.ID_Conexion equals sp.ID_Conexion
                    where sp.ID_Class == ID_Class
                    select con).Distinct();
            foreach (var r in res)
            {
                l.Add(
                    new CConexion
                    {
                        ID_Conexion = r.ID_Conexion,
                        ID_Servidor = r.ID_Servidor,
                        Nombre = r.Nombre,
                        ConecctionString = r.ConecctionString,
                        MotorDB = r.MotorDB
                    }
                    );
            }
            return l;
        }

        /// <summary>
        /// regresa la lista de conexiones que pertenecen a un servidor
        /// </summary>
        /// <param name="id_servidor"></param>
        /// <returns></returns>
        public List<CConexion> DameConexionesServidor(int id_servidor)
        {
            List<CConexion> l = new List<CConexion>();
            var res = (from con in Conexion where con.ID_Servidor == id_servidor select con);
            foreach (var r in res)
            {
                l.Add(
                    new CConexion
                    {
                        ID_Conexion = r.ID_Conexion,
                        ID_Servidor = r.ID_Servidor,
                        Nombre = r.Nombre,
                        ConecctionString = r.ConecctionString,
                        MotorDB = r.MotorDB
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa todas las conexiones que se tiene almacenadas
        /// </summary>
        /// <returns></returns>
        public List<CConexion> DameConexiones()
        {
            List<CConexion> l = new List<CConexion>();
            var res = (from con in Conexion select con);
            foreach (var r in res)
            {
                l.Add(
                    new CConexion
                    {
                        ID_Conexion = r.ID_Conexion,
                        ID_Servidor = r.ID_Servidor,
                        Nombre = r.Nombre,
                        ConecctionString = r.ConecctionString,
                        MotorDB = r.MotorDB
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa la conexion especificada
        /// </summary>
        /// <param name="id_conexion"></param>
        /// <returns></returns>
        public CConexion DameConexion(int id_conexion)
        {
            var r = (from con in Conexion where con.ID_Conexion == id_conexion select con).Single();
            if (r == null)
                return null;
            return new CConexion
            {
                ID_Conexion = r.ID_Conexion,
                ID_Servidor = r.ID_Servidor,
                Nombre = r.Nombre,
                ConecctionString = r.ConecctionString,
                MotorDB = r.MotorDB
            };
        }
        /// <summary>
        /// regresa una conexion por medio de su cadena de conexion
        /// </summary>
        /// <param name="connectioString"></param>
        /// <returns></returns>
        public CConexion DameConeccionPorCadena(string connectioString)
        {
            var r = (from con in Conexion where con.ConecctionString == connectioString select con);
            if (r.Count() == 0)
                return null;
            var r2 = r.First();
            return new CConexion
            {
                ID_Conexion = r2.ID_Conexion,
                ID_Servidor = r2.ID_Servidor,
                Nombre = r2.Nombre,
                ConecctionString = r2.ConecctionString,
                MotorDB = r2.MotorDB
            };

        }
        /// <summary>
        /// regresa una conexion por medio del nombre
        /// </summary>
        /// <param name="id_servidor"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public CConexion DameConexion(int id_servidor, string nombre)
        {
            var r = (from con in Conexion where con.ID_Servidor == id_servidor && con.Nombre == nombre select con);//.Single();
            if (r.Count() == 0)
                return null;
            var r2 = r.First();
            return new CConexion
            {
                ID_Conexion = r2.ID_Conexion,
                ID_Servidor = r2.ID_Servidor,
                Nombre = r2.Nombre,
                ConecctionString = r2.ConecctionString,
                MotorDB = r2.MotorDB
            };
        }
        /// <summary>
        /// agrega una nueva conexion
        /// </summary>
        /// <param name="id_servidor"></param>
        /// <param name="nombre"></param>
        /// <param name="conecctionString"></param>
        /// <param name="motorDB"></param>
        public void AgregaConexion(int id_servidor, string nombre, string conecctionString, string motorDB)
        {
            Cservidor servidor = DameServidor(id_servidor);
            if (servidor == null)
            {
                throw new System.Exception("No se encuentra el servidor");
            }
            CConexion obj = DameConexion(id_servidor, nombre);
            if (obj != null)
            {
                return;
                //throw new System.Exception("ya existe la conexión");
            }
            DataRow dr = Conexion.NewRow();
            dr["ID_Servidor"] = id_servidor;
            dr["Nombre"] = nombre;
            dr["ConecctionString"] = conecctionString;
            dr["MotorDB"] = motorDB;
            Conexion.Rows.Add(dr);
            ConexionChange();
        }
        /// <summary>
        /// actualiza los datos de la conexion
        /// </summary>
        /// <param name="id_conexion"></param>
        /// <param name="nombre"></param>
        /// <param name="conecctionString"></param>
        /// <param name="motorDB"></param>
        public void ActualizaConexion(int id_conexion, string nombre, string conecctionString, string motorDB)
        {
            var res = (from con in Conexion where con.Nombre == nombre select con).Single();
            if (res == null)
            {
                throw new System.Exception("No existe la conexion");
            }
            var res1 = (
                            from
                                   con
                            in
                                Conexion
                            where
                                con.Nombre == nombre
                                && con.ID_Conexion != id_conexion
                                && con.ID_Servidor == res.ID_Servidor
                            select con
                        ).Single();

            if (res1 != null)
            {
                throw new System.Exception("ya existe una conexión con el mismo nombre");
            }
            res.Nombre = nombre;
            res.ConecctionString = conecctionString;
            res.MotorDB = motorDB;
            res.AcceptChanges();
            ConexionChange();
        }
        /// <summary>
        /// Elimina la conexion 
        /// </summary>
        /// <param name="id_conexion"></param>
        public void EliminaeConexion(int id_conexion)
        {
            var res = (from con in Conexion where con.ID_Conexion == id_conexion select con).Single();
            if (res == null)
                return;
            res.Delete();
            ConexionChange();
        }
        #endregion
        #region Administracion de DataClass
        /// <summary>
        /// regresa el listado de todas los Dataclass
        /// </summary>
        /// <returns></returns>
        public List<CDataClass> DameClases()
        {
            List<CDataClass> l = new List<CDataClass>();
            var r = (from c in DataClass select c);
            foreach (var obj in r)
            {
                l.Add(
                    new CDataClass
                    {
                        ID_Class = obj.ID_Class,
                        Nombre = obj.Nombre
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa un dataclass por medio de su clave
        /// </summary>
        /// <param name="id_class"></param>
        /// <returns></returns>
        public CDataClass DameClase(int id_class)
        {
            var r = (from c in DataClass where c.ID_Class == id_class select c).Single();
            if (r == null)
                return null;
            return new CDataClass
            {
                ID_Class = r.ID_Class,
                Nombre = r.Nombre
            };
        }
        /// <summary>
        /// regresa un DataClass por mediode su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public CDataClass DameClase(string nombre)
        {
            var r = (from c in DataClass where c.Nombre == nombre select c);//.Single();
            if (r.Count() == 0)
                return null;
            var r2 = r.First();
            return new CDataClass
            {
                ID_Class = r2.ID_Class,
                Nombre = r2.Nombre
            };
        }
        /// <summary>
        /// agrega una clase
        /// </summary>
        /// <param name="nombre"></param>
        public void AgregaClase(string nombre)
        {
            CDataClass obj = DameClase(nombre);
            if (obj != null)
            {
                throw new System.Exception("La clase ya existe");
            }
            DataRow dr = DataClass.NewRow();
            dr["Nombre"] = nombre;
            DataClass.Rows.Add(dr);
            ClassChange();
        }
        /// <summary>
        /// actualiza el nombre de la clase
        /// </summary>
        /// <param name="id_dataclass"></param>
        /// <param name="nombre"></param>
        public void ActualizaClase(int id_dataclass, string nombre)
        {
            var r = (from c in DataClass where c.ID_Class != id_dataclass && c.Nombre == nombre select c);//.Single();
            if (r.Count() > 0)
            {
                throw new System.Exception("Existe otra clase con el mismo nombre");
            }
            var r2 = (from c in DataClass where c.ID_Class == id_dataclass select c).Single();
            r2.Nombre = nombre;
            r2.AcceptChanges();
            ClassChange();

        }
        /// <summary>
        /// Elimina un clase
        /// </summary>
        /// <param name="id_dataclass"></param>
        public void EliminaClase(int id_dataclass)
        {
            var r = (from c in DataClass where c.ID_Class == id_dataclass select c);//.Single();
            if (r.Count() == 0)
                return;
            r.Single().Delete();
            ClassChange();
        }
        #endregion
        #region Administracion de procedimientos almacenados
        /// <summary>
        /// regresa la lista de todos los sps que existen
        /// </summary>
        /// <returns></returns>
        public List<CStoreProcedures> DameSps()
        {
            List<CStoreProcedures> l = new List<CStoreProcedures>();
            var res = (from sps in StoreProcedures select sps);
            foreach (var obj in res)
            {
                l.Add(
                    new CStoreProcedures
                    {
                        ID_Store = obj.ID_Store
                        ,
                        ID_Class = obj.ID_Class
                        ,
                        ID_Conexion = obj.ID_Conexion
                        ,
                        Nombre = obj.Nombre
                        ,
                        ObjetoRegreso = obj.ObjetoRegreso
                        ,
                        Simple = obj.Simple
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa todos los PSs que pertenecen a una clase
        /// </summary>
        /// <param name="id_class"></param>
        /// <returns></returns>
        public List<CStoreProcedures> DameSpsClase(int id_class)
        {
            List<CStoreProcedures> l = new List<CStoreProcedures>();
            var res = (from sps in StoreProcedures where sps.ID_Class == id_class select sps);
            foreach (var obj in res)
            {
                l.Add(
                    new CStoreProcedures
                    {
                        ID_Store = obj.ID_Store
                        ,
                        ID_Class = obj.ID_Class
                        ,
                        ID_Conexion = obj.ID_Conexion
                        ,
                        Nombre = obj.Nombre
                        ,
                        ObjetoRegreso = obj.ObjetoRegreso
                        ,
                        Simple = obj.Simple
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa los sps que pertenecen a una conexion
        /// </summary>
        /// <param name="id_conexion"></param>
        /// <returns></returns>
        public List<CStoreProcedures> DameSpsConexion(int id_conexion)
        {
            List<CStoreProcedures> l = new List<CStoreProcedures>();
            var res = (from sps in StoreProcedures where sps.ID_Conexion == id_conexion select sps);
            foreach (var obj in res)
            {
                l.Add(
                    new CStoreProcedures
                    {
                        ID_Store = obj.ID_Store
                        ,
                        ID_Class = obj.ID_Class
                        ,
                        ID_Conexion = obj.ID_Conexion
                        ,
                        Nombre = obj.Nombre
                        ,
                        ObjetoRegreso = obj.ObjetoRegreso
                        ,
                        Simple = obj.Simple
                    }
                    );
            }
            return l;
        }
        /// <summary>
        /// regresa un SP por medio de si ID
        /// </summary>
        /// <param name="ID_Store"></param>
        /// <returns></returns>
        public CStoreProcedures DameSp(int ID_Store)
        {
            var obj = (from sp in StoreProcedures where sp.ID_Store == ID_Store select sp).Single();
            if (obj == null)
                return null;
            return new CStoreProcedures
            {
                Nombre = obj.Nombre
                ,
                ID_Class = obj.ID_Class
                ,
                ID_Conexion = obj.ID_Conexion
                ,
                ID_Store = obj.ID_Store
                        ,
                ObjetoRegreso = obj.ObjetoRegreso
                        ,
                Simple = obj.Simple
            };
        }
        /// <summary>
        /// regresa un SP por medio del nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="id_class"></param>
        /// <param name="id_conexion"></param>
        /// <returns></returns>
        public CStoreProcedures DameSp(string nombre, int id_class, int id_conexion)
        {
            var obj = (from sp in StoreProcedures where sp.Nombre == nombre && sp.ID_Class == id_class && sp.ID_Conexion == id_conexion select sp).Single();
            if (obj == null)
                return null;
            return new CStoreProcedures
            {
                Nombre = obj.Nombre
                ,
                ID_Class = obj.ID_Class
                ,
                ID_Conexion = obj.ID_Conexion
                ,
                ID_Store = obj.ID_Store
                        ,
                ObjetoRegreso = obj.ObjetoRegreso
                        ,
                Simple = obj.Simple
            };
        }
        /// <summary>
        /// Agrega un procedimiento almacenado a un clase
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="ID_Conexion"></param>
        /// <param name="ID_Class"></param>        
        public void AgregaSp(string Nombre, int ID_Conexion, int ID_Class)
        {
            //primero verifico que no exista
            var vexiste = (from existe in StoreProcedures where existe.Nombre.ToUpper().Trim() == Nombre.ToUpper().Trim() && existe.ID_Class == ID_Class && existe.ID_Conexion == ID_Conexion select existe);//.Single();
            if (vexiste.Count() > 0)
            {
                throw new System.Exception("EL procediiento almacenado ya existe");
            }
            if (DameClase(ID_Class) == null)
            {
                throw new System.Exception("La clase no existe");
            }
            if (DameConexion(ID_Conexion) == null)
            {
                throw new System.Exception("La conexion no existe");
            }
            DataRow dr = StoreProcedures.NewRow();
            dr["Nombre"] = Nombre;
            dr["ID_Conexion"] = ID_Conexion;
            dr["ID_Class"] = ID_Class;
            dr["ObjetoRegreso"] = Nombre.Trim() + "Result"; ;
            dr["Simple"] = false;
            StoreProcedures.Rows.Add(dr);
            StoreProcedureChange();
        }
        public void ActualizaSP(int ID_Store, string ObjetoRegreso, bool Simple)
        {
            var obj = (from sp in StoreProcedures where sp.ID_Store == ID_Store select sp).Single();
            obj.Simple = Simple;
            obj.ObjetoRegreso = ObjetoRegreso;
            obj.AcceptChanges();
        }
        /// <summary>
        /// mueve un procedimiento almacenado a otra clase
        /// </summary>
        /// <param name="ID_Store"></param>
        /// <param name="ID_Class"></param>
        public void MueveSPClase(int ID_Store, int ID_Class)
        {
            var vexiste = (from existe in StoreProcedures where existe.ID_Store == ID_Store && existe.ID_Class == ID_Class select existe).Single();
            if (vexiste != null)
            {
                throw new System.Exception("EL procediiento almacenado ya pertenec a la clase");
            }
            var obj = (from existe in StoreProcedures where existe.ID_Store == ID_Store select existe).Single();
            obj.ID_Class = ID_Class;
            obj.AcceptChanges();
            StoreProcedureChange();
        }
        /// <summary>
        /// elimina un procediieto almacenado
        /// </summary>
        /// <param name="id_store"></param>
        public void EliminaSP(int id_store)
        {
            var obj = (from existe in StoreProcedures where existe.ID_Store == id_store select existe).Single();
            if (obj == null)
                return;
            obj.Delete();
            StoreProcedureChange();
        }
        #endregion
        #region llamadas a eventos
        private void ServidorChange()
        {
            try
            {
                if (OnServidorChange != null)
                    OnServidorChange(this);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        private void ConexionChange()
        {
            try
            {
                if (OnConexionChange != null)
                    OnConexionChange(this);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        private void ClassChange()
        {
            try
            {
                if (OnClassChange != null)
                    OnClassChange(this);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        private void StoreProcedureChange()
        {
            try
            {
                if (OnStoreProcedureChange != null)
                    OnStoreProcedureChange(this);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        #endregion
    }
}

