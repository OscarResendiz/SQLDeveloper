using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
namespace MotorDB
{
    internal class CMotorSQLServer : IMotorDB
    {
        static List<CTipoDato> FTiposDato;
        private string ConnectionName;
        private string FConnectionString;
        private void GeneraListaTiposDato()
        {
            FTiposDato = new List<CTipoDato>();
            FTiposDato.Add(new CTipoDato("geography", false));
            FTiposDato.Add(new CTipoDato("geometry", false));
            FTiposDato.Add(new CTipoDato("xml", false));
            FTiposDato.Add(new CTipoDato("bit", false));
            FTiposDato.Add(new CTipoDato("tinyint", false));
            FTiposDato.Add(new CTipoDato("smallint", false));
            FTiposDato.Add(new CTipoDato("date", false));
            FTiposDato.Add(new CTipoDato("int", false));
            FTiposDato.Add(new CTipoDato("real", false));
            FTiposDato.Add(new CTipoDato("smalldatetime", false));
            FTiposDato.Add(new CTipoDato("smallmoney", false));
            FTiposDato.Add(new CTipoDato("time", false));
            FTiposDato.Add(new CTipoDato("bigint", false));
            FTiposDato.Add(new CTipoDato("datetime", false));
            FTiposDato.Add(new CTipoDato("money", false));
            FTiposDato.Add(new CTipoDato("timestamp", false));
            FTiposDato.Add(new CTipoDato("image", false));
            FTiposDato.Add(new CTipoDato("ntext", false));
            FTiposDato.Add(new CTipoDato("text", false));
            FTiposDato.Add(new CTipoDato("uniqueidentifier", false));
            FTiposDato.Add(new CTipoDato("sysname", false));
            FTiposDato.Add(new CTipoDato("hierarchyid", false));
            FTiposDato.Add(new CTipoDato("sql_variant", false));
            FTiposDato.Add(new CTipoDato("datetime2", true));
            FTiposDato.Add(new CTipoDato("float", true));
            FTiposDato.Add(new CTipoDato("datetimeoffset", true));
            FTiposDato.Add(new CTipoDato("decimal", true));
            FTiposDato.Add(new CTipoDato("numeric", true));
            FTiposDato.Add(new CTipoDato("binary", true));
            FTiposDato.Add(new CTipoDato("char", true));
            FTiposDato.Add(new CTipoDato("nchar", true));
            FTiposDato.Add(new CTipoDato("nvarchar", true));
            FTiposDato.Add(new CTipoDato("varbinary", true));
            FTiposDato.Add(new CTipoDato("varchar", true));
        }
        public List<CTipoDato> DameTiposDato()
        {
            if (FTiposDato == null)
                GeneraListaTiposDato();
            return FTiposDato;
        }
        public CTipoDato GetTipoDato(string nombre)
        {
            if (FTiposDato == null)
            {
                FTiposDato = new List<CTipoDato>();
                GeneraListaTiposDato();
            }
            foreach (CTipoDato obj in FTiposDato)
            {
                if (obj.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim())
                {
                    return obj;
                }
            }
            return null;

        }

        public bool isExecuting()
        {
                return false;
        }
        public CMotorSQLServer()
        {
        }
        public string GetConecctionString()
        {
            return FConnectionString; 
        }

        public void SetConnectionString(string connectionString)
        {
            FConnectionString = connectionString;
        }
        public String GetConnectionName()
        {
            return ConnectionName;

        }
        public void SetConnectionName(string nombre)
        {
            ConnectionName = nombre;
        }
        public System.Windows.Forms.DialogResult ShowDlgConfig()
        {
            FormDlgConfigSqlServer dlg = new FormDlgConfigSqlServer();
            System.Data.SqlClient.SqlConnection Conexion = new SqlConnection(FConnectionString);
            dlg.ConnectionString = Conexion.ConnectionString;
            dlg.ConnectioName = ConnectionName;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Conexion.ConnectionString = dlg.ConnectionString;
                ConnectionName = dlg.ConnectioName;
            }
            return dlg.DialogResult;
        }
        public bool Conectar()
        {
            //solo pruebo la conexion y regreso true si se pudo establecer la conexion
            System.Data.SqlClient.SqlConnection Conexion = new SqlConnection(FConnectionString);
            try
            {
                Conexion.Open();
            }
            catch (System.Exception)
            {
                return false;
            }
            Conexion.Close();
            return true;
        }
        public void Desconectar()
        {
        }
        public IDataReader EjecutaQuery(string cadena)
        {
            CSQLComandQuery dr = new CSQLComandQuery();
            //asigno el motor de base de datos
            dr.Motor = EnumMotoresDB.SQLSERVER;
            //le paso la cadena de conecion
            dr.ConnectionString = FConnectionString;
            //le paso el query
            dr.QueryString = cadena;
            //y lo abro
            dr.Open();
            return dr;
        }

        public List<CObjeto> BuscaEnTablas(string campo)
        {
            //regresa el listado de tablas que contengas el campo buscado
            List<CObjeto> l = new List<CObjeto>();
            string query = "select distinct	o.name from sysobjects o ,syscolumns c where c.name like'%" + campo + "%' and o.id=c.id and o.xtype='U'";
            IDataReader dr = EjecutaQuery(query);
            while (dr.Read())
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = EnumTipoObjeto.TABLE;
                l.Add(obj);
            }
            return l;
        }

        public List<CObjeto> BuscaEnVistas(string campo)
        {
            //regresa el listado de vistas que contengas el campo buscado
            List<CObjeto> l = new List<CObjeto>();
            string query = "select distinct	o.name from sysobjects o ,syscolumns c where c.name like'%" + campo + "%' and o.id=c.id and o.xtype='V'";
            IDataReader dr = EjecutaQuery(query);
            while (dr.Read())
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = EnumTipoObjeto.VIEW;
                l.Add(obj);
            }
            return l;
        }
        private EnumTipoObjeto DameXType(string xtype)
        {
            EnumTipoObjeto Tipo = EnumTipoObjeto.NONE;
            switch (xtype.ToString().ToUpper().Trim())
            {
                case "CAMPO":
                    Tipo = EnumTipoObjeto.CAMPO;
                    break;
                case "C":
                    Tipo = EnumTipoObjeto.CHECK;
                    break;
                case "F":
                    Tipo = EnumTipoObjeto.FOREIGNKEY;
                    break;
                case "FN":
                    Tipo = EnumTipoObjeto.FUNCION;
                    break;
                case "IDENTITY":
                    Tipo = EnumTipoObjeto.IDENTITY;
                    break;
                case "PK":
                    Tipo = EnumTipoObjeto.PRIMARYKEY;
                    break;
                case "P":
                    Tipo = EnumTipoObjeto.PROCEDURE;
                    break;
                case "U":
                    Tipo = EnumTipoObjeto.TABLE;
                    break;
                case "TIPEDATA":
                    Tipo = EnumTipoObjeto.TIPEDATA;
                    break;
                case "TR":
                    Tipo = EnumTipoObjeto.TRIGER;
                    break;
                case "UQ":
                    Tipo = EnumTipoObjeto.UNIQUE;
                    break;
                case "V":
                    Tipo = EnumTipoObjeto.VIEW;
                    break;
                case "INDEX":
                    Tipo = EnumTipoObjeto.INDEX;
                    break;
            }
            return Tipo;
        }
        public List<CObjeto> Buscar(string nombre, EnumTipoObjeto tipo = EnumTipoObjeto.NONE)
        {
            //regresa el listado de objetos que coincidan con el nombre y tipo seleccionado
            List<CObjeto> l = new List<CObjeto>();
            string query = "";
            switch (tipo)
            {
                case EnumTipoObjeto.CAMPO:
                    query = "select 	distinct o.name , o.xtype from syscolumns c ,sysobjects o where o.id=c.id and  c.name like '%" + nombre + "%' ";
                    break;
                case EnumTipoObjeto.CHECK:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='C'";
                    break;
                case EnumTipoObjeto.FOREIGNKEY:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='F'";
                    break;
                case EnumTipoObjeto.FUNCION:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='FN'";
                    break;
                case EnumTipoObjeto.IDENTITY:
                    query = "select distinct COLUMN_NAME as name ,'identity' as xtype from INFORMATION_SCHEMA.COLUMNS where COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 and COLUMN_NAME like'%" + nombre + "%'";
                    break;
                case EnumTipoObjeto.NONE:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%'";
                    break;
                case EnumTipoObjeto.PRIMARYKEY:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='PK'";
                    break;
                case EnumTipoObjeto.PROCEDURE:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='P'";
                    break;
                case EnumTipoObjeto.TABLE:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='U'";
                    break;
                case EnumTipoObjeto.TIPEDATA:
                    query = "select distinct	name , 'TIPEDATA' as xtype from systypes  where name like'%" + nombre + "%' ";
                    break;
                case EnumTipoObjeto.TRIGER:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='TR'";
                    break;
                case EnumTipoObjeto.UNIQUE:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='UQ'";
                    break;
                case EnumTipoObjeto.VIEW:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype='V'";
                    break;
                case EnumTipoObjeto.INDEX:
                    query = "select distinct	o.name , 'INDEX' as xtype from sys.indexes o where o.name like'%" + nombre + "%' ";
                    break;
                case EnumTipoObjeto.CODE:
                    query = "select distinct o.name ,o.xtype from syscomments c ,sysobjects o where c.text like '%" + nombre + "%' and o.id=c.id";
                    break;
            }
            IDataReader dr = EjecutaQuery(query);
            while (dr.Read())
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = DameXType(dr["xtype"].ToString());
                l.Add(obj);
            }
            return l;
        }

        private string DameDefault(string Tabla, string Campo)
        {
            string s2 = "";
            string s = "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + Tabla + "\'\n";
            s = s + "select @campo=\'" + Campo + "\'\n";
            s = s + "--vero si es un valor default\n";
            s = s + "declare @cdefault int\n";
            s = s + "declare @id_tabla int\n";
            s = s + "select @id_tabla=id from sysobjects where name=@tabla\n";
            s = s + "select @cdefault=cdefault from syscolumns where id=@id_tabla and name=@campo\n";
            s = s + "if(@cdefault is null or @cdefault=0)\n";
            s = s + "begin\n";
            s = s + "\tRAISERROR('no es campo default', 16, 1)\n";
            s = s + "\treturn\n";
            s = s + "end\n";
            s = s + "declare @defaulvalue varchar(100)\n";
            s = s + "--me traigo el texto\n";
            s = s + "select @defaulvalue=text from syscomments where id=@cdefault\n";
            s = s + "select @defaulvalue as defaulvalue\n";
            IDataReader dr;
            try
            {
                dr = EjecutaQuery(s);
                if (dr.Read())
                {
                    s2 = dr["defaulvalue"].ToString();
                }
            }
            catch (System.Exception)
            {
                return "";
            }
            return s2;
        }


        public List<CCampo> DameCamposTabla(string tabla)
        {
            List<CCampo> l = new List<CCampo>();
            String s = "";
            s += " select \n";
            s += "  c.name as Nombre, \n";
            s += "  t.name as TipoDato, \n";
            s += "  c.length as Longitud, \n";
            s += "  c.isnullable as AceptaNulo, \n";
            s += "  c.iscomputed as CampoCalculado, \n";
            s += "  c.cdefault , \n";
            s += "  case c.iscomputed when 1 then(select text from syscomments cc where cc.id = o.id and cc.number = c.colid) else '' end as Formula \n";
            s += " from \n";
            s += "  sysobjects o, \n";
            s += "  syscolumns c, \n";
            s += "  systypes t \n";
            s += " where \n";
            s += "  o.name = '" + tabla + "' \n";
            s += "  and o.xtype = 'U' \n";
            s += "  and c.id = o.id \n";
            s += "  and t.xtype = c.xtype \n";
            s += " order by \n";
            s += "  c.colid \n";

            //System.Data.IDataReader dr;
            IDataReader dr;
            dr = EjecutaQuery(s);
            while ( dr.Read())// (dr.IsClosed == false && dr.Read())
            {
                CCampo campo = new CCampo();
                campo.Nombre = dr["Nombre"].ToString();
                campo.Tipo = EnumTipoObjeto.CAMPO;
                campo.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                campo.Longitud = int.Parse(dr["Longitud"].ToString());
                if (int.Parse(dr["AceptaNulo"].ToString()) == 1)
                    campo.AceptaNulo = true;
                else
                    campo.AceptaNulo = false;
                if (int.Parse(dr["CampoCalculado"].ToString()) == 1)
                    campo.CampoCalculado = true;
                else
                    campo.CampoCalculado = false;
                campo.Formula = dr["Formula"].ToString();
                if (int.Parse(dr["cdefault"].ToString()) != 0)
                {
                    campo.EsDefault = true;
                }
                l.Add(campo);

            }
            dr.Close();
            foreach(CCampo obj in l)
            {
                if(obj.EsDefault)
                {
                    obj.Formula = DameDefault(tabla, obj.Nombre);
                }
            }
            return l;
        }

        public List<CCampoBase> DameCamposVista(string vista)
        {
            List<CCampoBase> l = new List<CCampoBase>();
            String s = "";
            s += " select \n";
            s += "  c.name as Nombre, \n";
            s += "  t.name as TipoDato, \n";
            s += "  c.length as Longitud \n";
            s += " from \n";
            s += "  sysobjects o, \n";
            s += "  syscolumns c, \n";
            s += "  systypes t \n";
            s += " where \n";
            s += "  o.name = '" + vista + "' \n";
            s += "  and o.xtype = 'V' \n";
            s += "  and c.id = o.id \n";
            s += "  and t.xtype = c.xtype \n";
            s += " order by \n";
            s += "  c.colid \n";

            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CCampoBase campo = new CCampoBase();
                campo.Nombre = dr["Nombre"].ToString();
                campo.Tipo = EnumTipoObjeto.CAMPO;
                campo.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                campo.Longitud = int.Parse(dr["Longitud"].ToString());
                l.Add(campo);

            }
            return l;
        }

        public string DameCodigoFuncction(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "select c.text from syscomments c,sysobjects o where c.id=o.id and o.xtype='FN' and o.name = \'" + nombre.Trim() + "\' order by c.colid";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }

        public string DameCodigoStoreProcedure(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "select c.text from syscomments c,sysobjects o where c.id=o.id and o.xtype='P' and o.name = \'" + nombre.Trim() + "\' order by c.colid";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            //Conexion.Close();
            return s;
        }


        public string DameCodigoVista(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "select c.text from syscomments c,sysobjects o where c.id=o.id and o.xtype='V' and o.name = \'" + nombre.Trim() + "\' order by c.colid";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }

        public CPrimaryKey DameLLavePrimaria(string tabla)
        {
            //regresa la llave primaria de la tabla
            List<CCampoBase> Campos = new List<CCampoBase>();
            CPrimaryKey pk = new CPrimaryKey();
            string s = "";
            s += " select \n";
            s += " pk.name as nombre \n";
            s += " ,c.name as Campo \n";
            s += " ,type_name(c.xtype) as TipoDato \n";
            s += " ,c.length as Longitud\n";
            s += " from \n";
            s += " sysobjects o, \n";
            s += " sysobjects pk, \n";
            s += " sysindexes i \n";
            s += " , sysindexkeys ik \n";
            s += " ,syscolumns c \n";
            s += " where \n";
            s += " o.name = '" + tabla + "' \n";
            s += " and pk.parent_obj = o.id \n";
            s += " and pk.xtype = 'PK' \n";
            s += " and i.name = pk.name \n";
            s += " and ik.id = o.id \n";
            s += " and c.id = o.id \n";
            s += " and c.colid = ik.colid \n";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CCampoBase campo = new CCampoBase();
                campo.Nombre = dr["Campo"].ToString();
                campo.Tipo = EnumTipoObjeto.CAMPO;
                campo.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                campo.Longitud = int.Parse(dr["Longitud"].ToString());
                pk.Nombre = dr["nombre"].ToString();
                pk.AddCampo(campo);
            }
            if (pk.Campos.Count == 0)
            {
                return null;
            }
            return pk;
        }
        private string GeneraQueryCamposFk(string nombre)
        {
            string s = "";
            s += " select \n";
            s += " cm.name as columnaMaestra \n";
            s += " ,type_name(cm.xtype) as TipoDatoMaestro \n";
            s += " ,cm.length as LongitudPadre \n";
            s += " ,ci.name as columnahija \n";
            s += " ,type_name(ci.xtype) as TipoDatoHijo \n";
            s += " ,ci.length as LongitudHijo \n";
            s += " from \n";
            s += " sysobjects o \n";
            s += " ,sysforeignkeys fk \n";
            s += " , sysobjects  tm \n";
            s += " ,sysobjects ti \n";
            s += " , syscolumns cm \n";
            s += " ,syscolumns ci \n";
            s += " where \n";
            s += " o.xtype = 'f' \n";
            s += " and o.name = '" + nombre + "' \n";
            s += " and fk.constid = o.id \n";
            s += " and tm.id = fk.rkeyid \n";
            s += " and ti.id = fk.fkeyid \n";
            s += " and cm.id = tm.id \n";
            s += " and cm.colid = rkey \n";
            s += " and ci.id = ti.id \n";
            s += " and ci.colid = fkey \n";
            return s;

        }
        public List<CForeignKey> DameLLavesForaneas(string tablaHija)
        {
            //regresa las llaves foraneas que tiene la tabla
            //primero me traigo un listado de todas la llaves foraneas que tiene asociada la tabla
            List<CForeignKey> fks = new List<CForeignKey>();
            string s = "select distinct o.name as TablaHija ,ofk.name as FK ,tp.name as TablaPadre from sysobjects o	,sysforeignkeys fk ,sysobjects ofk ,sysobjects Tp where o.name='" + tablaHija + "' and fk.fkeyid=o.id and ofk.id=fk.constid and tp.id=fk.rkeyid ";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CForeignKey fk = new CForeignKey();
                fk.Nombre = dr["FK"].ToString();
                fk.TablaHija = dr["TablaHija"].ToString();
                fk.TablaPadre = dr["TablaPadre"].ToString();
                fks.Add(fk);
            }
            dr.Close();
            //ahora recoorro todas la llaves foraneas encontradas y busco sus componentes
            foreach (CForeignKey fk in fks)
            {
                //me traigo sus reglas
                Point p = AgregaReglaFK(fk.Nombre);
                switch (p.X)
                {
                    case 0:
                        fk.AccionBorrar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case 1:
                        fk.AccionBorrar = EnumAccionReferencial.CASCADE;
                        break;
                    case 2:
                        fk.AccionBorrar = EnumAccionReferencial.SET_NULL;
                        break;
                    case 3:
                        fk.AccionBorrar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                }
                switch (p.Y)
                {
                    case 0:
                        fk.AccionActualizar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case 1:
                        fk.AccionActualizar = EnumAccionReferencial.CASCADE;
                        break;
                    case 2:
                        fk.AccionActualizar = EnumAccionReferencial.SET_NULL;
                        break;
                    case 3:
                        fk.AccionActualizar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                }
                dr = EjecutaQuery(GeneraQueryCamposFk(fk.Nombre));
                while (dr.Read())
                {
                    CCampoFereneces rf = new CCampoFereneces(dr["columnaMaestra"].ToString(), GetTipoDato(dr["TipoDatoMaestro"].ToString()), int.Parse(dr["LongitudPadre"].ToString()), dr["columnahija"].ToString(), GetTipoDato(dr["TipoDatoHijo"].ToString()), int.Parse(dr["LongitudHijo"].ToString()));
                    fk.Add(rf);
                }
                dr.Close();

            }
            return fks;
        }

        public List<CParametro> DameParametrosFuncction(string funcion)
        {
            List<CParametro> l = new List<CParametro>();
            string s = "select c.name,type_name(c.xtype) as TipoDato ,c.length from sysobjects o ,syscolumns  c where o.name='" + funcion + "' and o.xtype='FN' and c.id=o.id order by c.colid";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CParametro obj = new CParametro();
                obj.Nombre = dr["name"].ToString();
                obj.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                obj.Longitud = int.Parse(dr["length"].ToString());
                l.Add(obj);

            }
            return l;
        }

        public List<CParametro> DameParametrosStoreProcedure(string sp)
        {
            List<CParametro> l = new List<CParametro>();
            string s = "select c.name,type_name(c.xtype) as TipoDato ,c.length from sysobjects o ,syscolumns  c where o.name='" + sp + "' and o.xtype='P' and c.id=o.id order by c.colid";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CParametro obj = new CParametro();
                obj.Nombre = dr["name"].ToString();
                obj.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                obj.Longitud = int.Parse(dr["length"].ToString());
                l.Add(obj);

            }
            return l;
        }
        public void CreaTabla(CTabla tabla)
        {
            //genera el codigo para crear la tabla y lo ejecuta
            string s = QueryCreaTabla(tabla);
            EjecutaQuery(s);
        }
        private string AgregaCamposQueryTabla(CTabla tabla)
        {
            string s = "";
            bool primero = true;
            //creo los campos
            foreach (CCampo campo in tabla.Campos)
            {
                if (primero == true)
                {
                    s += "\n\t ";
                    primero = false;
                }
                else
                {
                    //como no es el primero hay que agregarle una coma
                    s += "\n\t ,";
                }
                s += campo + " ";
                if (campo.CampoCalculado)
                {
                    //es un campo calculado
                    s += " as " + campo.Formula;
                }
                else
                {
                    //pongo el tipo de dato
                    s += campo.TipoDato.ToString();
                    //verifico si hay que especificar la longitud
                    if (campo.TipoDato.UsaLongitud)
                    {
                        s += "(" + campo.Longitud + ")";
                    }
                    if (campo.AceptaNulo == false)
                    {
                        s += " not null ";
                    }
                    //veo si hay valores por default
                    if (campo.EsDefault)
                    {
                        s += " default " + campo.Formula;
                    }
                    //veo si es identidad
                    if (tabla.Identidad != null)
                    {
                        if (tabla.Identidad.Campo.Nombre == campo.Nombre)
                        {
                            s += " IDENTITY (" + tabla.Identidad.ValorInicial + "," + tabla.Identidad.Incremento + ")";
                        }
                    }
                }
            }
            return s;
        }
        private string AgregaQueryTablaPK(CTabla tabla)
        {
            string s = "";
            bool primero = true;
            if (tabla.PrimaryKey != null)
            {
                //si tiene llave primaria
                s += "\n\t ,constraint " + tabla.PrimaryKey.Nombre + " primary key(";
                //recorro los campos
                primero = true;
                foreach (CCampoBase campo in tabla.PrimaryKey.Campos)
                {
                    if (primero)
                    {
                        s += " ";
                        primero = false;
                    }
                    else
                    {
                        s += " ,";
                    }
                    s += campo.Nombre;
                }
                s += ")";
            }
            return s;
        }
        private string AgregaQueryTablaFK(CTabla tabla)
        {
            string s = "";
            string s2 = "";
            bool primero = true;

            //recorro todas las llaves foraneas de la tabla
            foreach (CForeignKey fk in tabla.ForeignKeys)
            {
                s += "\n\t ,constraint " + fk.Nombre + " foreign key(";
                //recorro los campos
                foreach (CCampoFereneces rf in fk.Campos)
                {
                    if (primero)
                    {
                        s += rf.CampoHijo;
                        s2 = "references " + fk.TablaPadre + "(" + rf.CampoPadre;
                        primero = false;
                    }
                    else
                    {
                        s += "," + rf.CampoHijo;
                        s2 += "," + rf.CampoPadre;
                    }
                }
                s += ") " + s2 + ")";
            }
            return s;
        }
        private string AgregaQueryTablaUniques(CTabla tabla)
        {
            string s = "";
            bool primero = true;
            //recorro cada contraint
            foreach (CUnique obj in tabla.Uniques)
            {
                s = s + " \n\t, CONSTRAINT " + obj.Nombre + " UNIQUE(";
                //recorro los campos
                foreach (CCampoBase campo in obj.Campos)
                {
                    if (primero)
                    {
                        primero = false;
                    }
                    else
                    {
                        s += ",";

                    }
                    s += campo.Nombre;
                }
                s += ")";
            }
            return s;
        }
        private string AgregaQueryTablaCheck(CTabla tabla)
        {
            string s = "";
            //recorro todos lo0s checks
            foreach (CCheck obj in tabla.Checks)
            {
                s += "\n\t, CONSTRAINT" + obj.Nombre + "(" + obj.Regla + ")";
            }
            return s;
        }
        public string QueryCreaTabla(CTabla tabla)
        {
            string s = "create table " + tabla.Nombre;
            s += "\n( ";
            //ya agrege loc campos, ahora agrego si llave primaria
            s += AgregaCamposQueryTabla(tabla);
            //agrego la llave primaria
            s += AgregaQueryTablaPK(tabla);
            //ahora asigno las llaves foraneas
            s += AgregaQueryTablaFK(tabla);
            //agrego los campos unicos
            s += AgregaQueryTablaUniques(tabla);
            //agrego las restricciones chek
            s += AgregaQueryTablaCheck(tabla);
            s += "\n)";
            return s;
        }
        private IDataReader EsIdentidad(string tabla, string campo)
        {
            string s = "";
            s += "\n ";
            s += "\n declare @tabla varchar(100) ";
            s += "\n declare @campo varchar(100) ";
            s += "\n select @tabla = '" + tabla + "' ";
            s += "\n select @campo = '" + campo + "' ";
            s += "\n declare @id int ";
            s += "\n --obtengo el id de la tabla ";
            s += "\n select @id = OBJECT_ID(@tabla) ";
            s += "\n declare @seed_value int ";
            s += "\n declare @increment_value int ";
            s += "\n --veo si el campo es identidad ";
            s += "\n declare @ok int ";
            s += "\n SELECT @ok = COLUMNPROPERTY(@id, @campo, 'IsIdentity') ";
            s += "\n if (@ok is null or @ok = 0) ";
            s += "\n begin ";
            s += "\n select 0 as Identidad,0 as seed_value,0 as increment_value ";
            s += "\n return ";
            s += "\n end ";
            s += "\n --como si es identidad, me traigo sus propiedades ";
            s += "\n select @seed_value = IDENT_SEED(@tabla) ";
            s += "\n select @increment_value = IDENT_INCR(@tabla) ";
            s += "\n --regreso los valores ";
            s += "\n select 1 as Identidad, @seed_value as seed_value,@increment_value as increment_value ";
            return EjecutaQuery(s);
        }
        private List<CCheck> DameChecks(string taba)
        {
            List<CCheck> l = new List<CCheck>();
            string s = "select 	ch.name as Nombre ,c.text as Codigo from sysobjects o ,sysobjects ch ,syscomments c where o.name='" + taba + "' and o.xtype='U' and ch.parent_obj=o.id and ch.xtype='C' and c.id=ch.id ";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CCheck obj = new CCheck();
                obj.Nombre = dr["Nombre"].ToString();
                obj.Regla = dr["Codigo"].ToString();
                l.Add(obj);
            }
            dr.Close();
            return l;
        }
        public List<CUnique> DameUnicos(string tabla)
        {
            CUnique obj = null;
            List<CUnique> l = new List<CUnique>();
            string cadena = "select u.name as nombre  from sysobjects o ,sysindexes i ,sysobjects u where o.name='" + tabla + "' and o.xtype='U' and i.id=o.id and u.name=i.name and u.xtype='UQ'";
            IDataReader dr;
            dr = EjecutaQuery(cadena);
            while (dr.Read())
            {
                obj = new CUnique();
                obj.Nombre = dr["nombre"].ToString();
                l.Add(obj);
            }
            dr.Close();
            foreach (CUnique un in l)
            {
                //me traigo sus campos
                IDataReader dr2 = EjecutaQuery("select c.name as campo ,type_name(c.xtype) as TipoDato ,c.length as Longitud from sysindexes i ,sys.index_columns ic ,syscolumns c where i.name='" + un.Nombre + "' and ic.object_id=i.id and ic.index_id=i.indid and c.id=i.id and c.colid=ic.column_id ");
                while (dr2.Read())
                {
                    CCampoBase cb = new CCampoBase();
                    cb.Nombre = dr2["campo"].ToString();
                    cb.TipoDato = GetTipoDato(dr2["TipoDato"].ToString());
                    cb.Longitud = int.Parse(dr2["Longitud"].ToString());
                    un.AddCampo(cb);
                }
                dr2.Close();
            }
            return l;
        }
        private List<Cindex> CargaIndices(string tabla)
        {

        }
        public CTabla DameTabla(string nombre)
        {
            string s = "";
            CTabla tabla = new CTabla();
            //Busco si existe la tabla
            s = "select name from sysobjects where name='" + nombre + "' and xtype='U'";
            IDataReader dr = EjecutaQuery(s);
            if (dr.Read() == false)
            {
                //no se encontro la tabla
                dr.Close();
                //Conexion.Close();
                return null;
            }
            //me traigo el nombre de la tabla
            tabla.Nombre = dr["name"].ToString();
            dr.Close();
            //me traigo los campos
            List<CCampo> campos = DameCamposTabla(nombre);
            foreach (CCampo campo in campos)
            {
                tabla.AddCampo(campo);
                //veo si es identidad
                dr = EsIdentidad(tabla.Nombre, campo.Nombre);
                dr.Read();
                if (int.Parse(dr["Identidad"].ToString()) == 1)
                {
                    //si es identidad, por lo que agrego el campo
                    CIdentidad identidad = new CIdentidad();
                    identidad.Campo = campo;
                    identidad.ValorInicial = int.Parse(dr["seed_value"].ToString());
                    identidad.Incremento = int.Parse(dr["increment_value"].ToString());
                    tabla.Identidad = identidad;
                }
                dr.Close();
            }
            //me traigo la llave primaria
            tabla.PrimaryKey = DameLLavePrimaria(tabla.Nombre);
            //me traigo las llaves foraneas
            tabla.ForeignKeys = DameLLavesForaneas(tabla.Nombre);
            //me traigo los checks
            tabla.Checks = DameChecks(tabla.Nombre);
            //me traigo los valores Unicos
            tabla.Uniques = DameUnicos(tabla.Nombre);
            tabla.Indexs = CargaIndices(tabla.Nombre);
            //regreso la tabla
            return tabla;
        }
        public string DameCodigoTabla(string nombre)
        {
            CTabla tabla = DameTabla(nombre);
            string s = QueryCreaTabla(tabla);
            return s;
        }
        public List<CObjeto> DameDependenciasDe(string nombre)
        {
            //regresa la lista de objetos de los cuales depende el que se le pasa ala funcion
            List<CObjeto> l = new List<CObjeto>();
            string s = "declare @tabla sysname\r\n";
            s = s + "select @tabla=\'" + nombre + "\'\r\n";
            s = s + "declare @idtabla int\r\n";
            s = s + "declare @tipo char(1)\r\n";
            s = s + "select @idtabla=id,@tipo=xtype from sysobjects where name=@tabla\r\n";
            s = s + "if(@tipo='P')\r\n";
            s = s + "\tselect * from sysobjects  where id in(select depid from sysdepends where id=@idtabla) order by name\r\n";
            s = s + "else\r\n";
            s = s + "begin\r\n";
            s = s + "select * from sysobjects where id in( select fkeyid from sysforeignkeys where rkeyid =@idtabla)\r\n";
            s = s + "union\r\n";
            s = s + "select * from sysobjects  where id in(select id from sysdepends where depid=@idtabla)\r\n";
            s = s + "end\r\n";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read() )//&& dr.IsClosed == false)
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = DameXType(dr["xtype"].ToString());
                l.Add(obj);
            }
            dr.Close();
            return l;
        }
        public List<CObjeto> DameDependientesDe(string nombre)
        {
            //regresa la lista de objetos que dependen del pasado a la funcion
            List<CObjeto> l = new List<CObjeto>();
            string s = "declare @tabla sysname\r\n";
            s = s + "select @tabla=\'" + nombre + "\'\r\n";
            s = s + "declare @idtabla int\r\n";
            s = s + "declare @tipo char(1)\r\n";
            s = s + "select @idtabla=id,@tipo=xtype from sysobjects where name=@tabla\r\n";
            s = s + "if(@tipo='P')\r\n";
            s = s + "\tselect * from sysobjects  where id in(select id from sysdepends where depid=@idtabla) order by name\r\n";
            s = s + "else\r\n";
            s = s + "select * from sysobjects  where id in(select depid from sysdepends where id=@idtabla)\r\n";
            s = s + "union\r\n";
            s = s + "select * from sysobjects where id in( select rkeyid from sysforeignkeys where  fkeyid=@idtabla)\r\n";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read() )//&& dr.IsClosed == false)
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = DameXType(dr["xtype"].ToString());
                l.Add(obj);
            }
            dr.Close();
            return l;
        }
        public string GetDataBseName()
        {
            //regrea el nombre de la base de datos a la que estoy conectado
            System.Data.SqlClient.SqlConnection Conexion = new SqlConnection(FConnectionString);
            try
            {
                return Conexion.Database;
            }
            catch (System.Exception)
            {
                return "";
            }
        }
        private Point AgregaReglaFK(string fk)
        {
            Point p = new Point(0, 0);
            string s = "select delete_referential_action as DC,update_referential_action as UC from sys.foreign_keys where name='" + fk + "'";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())// && dr.IsClosed == false)
            {
                p.X = int.Parse(dr["DC"].ToString());
                p.Y = int.Parse(dr["UC"].ToString());
                break;
            }
            dr.Close();
            //Conexion.Close();
            return p;

        }
        public List<CForeignKey> DameLLavesForaneasHijas(string tablaPadre)
        {
            //regresa las llaves foraneas que tiene la tabla
            //primero me traigo un listado de todas la llaves foraneas que tiene asociada la tabla
            List<CForeignKey> fks = new List<CForeignKey>();
            string s = "select 	distinct o.name as TablaPadre ,ofk.name as FK ,th.name as TablaHija from sysobjects o ,sysforeignkeys fk ,sysobjects ofk ,sysobjects Th where o.name='" + tablaPadre + "' and fk.rkeyid =o.id and ofk.id=fk.constid and th.id=fk.fkeyid";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CForeignKey fk = new CForeignKey();
                fk.Nombre = dr["FK"].ToString();
                fk.TablaHija = dr["TablaHija"].ToString();
                fk.TablaPadre = dr["TablaPadre"].ToString();
                fks.Add(fk);
            }
            dr.Close();
            //ahora recoorro todas la llaves foraneas encontradas y busco sus componentes
            foreach (CForeignKey fk in fks)
            {
                //me traigo sus reglas
                Point p = AgregaReglaFK(fk.Nombre);
                switch (p.X)
                {
                    case 0:
                        fk.AccionBorrar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case 1:
                        fk.AccionBorrar = EnumAccionReferencial.CASCADE;
                        break;
                    case 2:
                        fk.AccionBorrar = EnumAccionReferencial.SET_NULL;
                        break;
                    case 3:
                        fk.AccionBorrar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                }
                switch (p.Y)
                {
                    case 0:
                        fk.AccionActualizar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case 1:
                        fk.AccionActualizar = EnumAccionReferencial.CASCADE;
                        break;
                    case 2:
                        fk.AccionActualizar = EnumAccionReferencial.SET_NULL;
                        break;
                    case 3:
                        fk.AccionActualizar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                }
                dr = EjecutaQuery(GeneraQueryCamposFk(fk.Nombre));
                while (dr.Read())
                {
                    CCampoFereneces rf = new CCampoFereneces(dr["columnaMaestra"].ToString(), GetTipoDato(dr["TipoDatoMaestro"].ToString()), int.Parse(dr["LongitudPadre"].ToString()), dr["columnahija"].ToString(), GetTipoDato(dr["TipoDatoHijo"].ToString()), int.Parse(dr["LongitudHijo"].ToString()));
                    fk.Add(rf);
                }
                dr.Close();

            }
            return fks;
        }
        public List<EnumAccionReferencial> DameAccionesReferencialesBorradoValidos()
        {
            List<EnumAccionReferencial> l = new List<EnumAccionReferencial>();
            l.Add(EnumAccionReferencial.NO_ACTION);
            l.Add(EnumAccionReferencial.CASCADE);
            l.Add(EnumAccionReferencial.SET_NULL);
            l.Add(EnumAccionReferencial.SET_DEFAULT);
            return l;
        }
        public List<EnumAccionReferencial> DameAccionesReferencialesActualizadoValidos()
        {
            List<EnumAccionReferencial> l = new List<EnumAccionReferencial>();
            l.Add(EnumAccionReferencial.NO_ACTION);
            l.Add(EnumAccionReferencial.CASCADE);
            l.Add(EnumAccionReferencial.SET_NULL);
            l.Add(EnumAccionReferencial.SET_DEFAULT);
            return l;
        }
        private string GeneraQueryFK(CForeignKey fk)
        {
            //genera el query para crear la llave foranea
            string s = "Alter table " + fk.TablaHija + " add constraint ";
            string s2 = " references " + fk.TablaPadre + " ( ";
            s += fk.Nombre + " foreign key( \n ";
            //recorro todos los campos
            bool primero = true;
            foreach (CCampoFereneces obj in fk.Campos)
            {
                if (primero)
                {
                    primero = false;
                }
                else
                {
                    s += " , ";
                    s2 += ",";
                }
                s += obj.CampoHijo;
                s2 += obj.CampoPadre;
            }
            s += " )\n ";
            s2 += ") \n ";
            s += s2;
            //agrego las reglas de acciones referenciales
            s += " ON DELETE " + AccionReferencial(fk.AccionBorrar);
            s += " \n ";
            s += " ON UPDATE " + AccionReferencial(fk.AccionActualizar);
            s += " \n ";
            return s;
        }
        public void CreaForeignKey(CForeignKey fk)
        {
            string s = GeneraQueryFK(fk);
            EjecutaQuery(s);
        }
        private string AccionReferencial(EnumAccionReferencial op)
        {
            string s = "";
            switch(op)
            {
                case EnumAccionReferencial.CASCADE:
                    s = "Cascade";
                    break;
                case EnumAccionReferencial.NO_ACTION:
                    s = "No Action";
                    break;
                case EnumAccionReferencial.SET_NULL:
                    s = "Set Null";
                    break;
                case EnumAccionReferencial.SET_DEFAULT:
                    s = "Set Default";
                    break;
                default:
                    throw new Exception("Accion refrencial no soportada: "+op);
            }
            return s;
        }
        public void EliminaForeignKey(CForeignKey fk)
        {
            string s = "alter table "+fk.TablaHija+ " drop constraint "+fk.Nombre;
            EjecutaQuery(s);
        }
        private string QueryDameTrrigersTabla(string tabla)
        {
            //genra el query para hacer la consulta
            string s = "";
            s += "SELECT\n";
            s += "     OBJECT_NAME(o.parent_obj) as TABLA\n";
            s += "	, [Trigger] = o.[name]\n";
            s += "	,CASE WHEN OBJECTPROPERTY(o.[id], 'ExecIsInsteadOfTrigger') = 1 THEN 'Instead Of' ELSE 'After' END  as Momento\n";
            s += "	,OBJECTPROPERTY(o.[id], 'ExecIsInsertTrigger') as [Insert]\n";
            s += "	,OBJECTPROPERTY(o.[id], 'ExecIsUpdateTrigger') as [Update]\n";
            s += "	,OBJECTPROPERTY(o.[id], 'ExecIsDeleteTrigger') as [Delete]\n";
            s += "FROM\n";
            s += "    sysobjects o\n";
            s += " WHERE\n";
            s += "    o.xtype='TR'\n";
            s += "    and OBJECT_NAME(o.parent_obj) ='"+tabla+"'\n";
            return s;
        }
        public EnumMomentTriger DameMomento(string s)
        {
            EnumMomentTriger momento = EnumMomentTriger.AFTER;
            if (s.ToUpper().Trim() == "AFTER")
                momento = EnumMomentTriger.AFTER;
            if (s.ToUpper().Trim() == "INSTEAD OF")
                momento = EnumMomentTriger.INSTEAD_OF;
            return momento;
        }
        private string DameCodigoTrigger(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "select c.text from syscomments c,sysobjects o where c.id=o.id and o.xtype='TR' and o.name = \'" + nombre.Trim() + "\' order by c.colid";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }
        public List<CTrigger> DameTrrigersTabla(string tabla)
        {
            List<CTrigger> l = new List<CTrigger>();
            IDataReader dr = EjecutaQuery(QueryDameTrrigersTabla(tabla));
            //recorro todos los registros
            while(dr.Read())//&& dr.IsClosed==false)
            {
                //creo el trigger
                CTrigger obj = new CTrigger();
                obj.Nombre = dr["Trigger"].ToString();
                obj.Momento = DameMomento(dr["Momento"].ToString());
                if (int.Parse(dr["Insert"].ToString()) == 1)
                    obj.Disparador = EnumEventTriger.INSERT;
                if (int.Parse(dr["Update"].ToString()) == 1)
                    obj.Disparador = EnumEventTriger.UPDATE;
                if (int.Parse(dr["Delete"].ToString()) == 1)
                    obj.Disparador = EnumEventTriger.DELETE;
                l.Add(obj);
            }
            dr.Close();
            //ahora me traigo el codigo fuente de cada trigger
            foreach(CTrigger obj in l)
            {
                obj.CodigoFuente = DameCodigoTrigger(obj.Nombre);
            }
            return l;
        }
        public List<EnumMomentTriger> DameMomentosTriggerSoportados()
        {
            List<EnumMomentTriger> l = new List<EnumMomentTriger>();
            l.Add(EnumMomentTriger.AFTER);
            l.Add(EnumMomentTriger.INSTEAD_OF);
            return l;

        }
        public List<EnumEventTriger> DameEventosTriggerSoportados()
        {
            List<EnumEventTriger> l = new List<EnumEventTriger>();
            l.Add(EnumEventTriger.DELETE);
            l.Add(EnumEventTriger.INSERT);
            l.Add(EnumEventTriger.UPDATE);
            return l;

        }
    }
}


