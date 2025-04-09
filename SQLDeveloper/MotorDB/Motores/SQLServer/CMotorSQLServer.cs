using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
namespace MotorDB
{
    internal class CMotorSQLServer : IMotorDB
    {
        private event MotorDBMessageEvent MessageErrorEvent;
        private string MsgError;
        static List<CTipoDato> FTiposDato;
        private string ConnectionName;
        private string FConnectionString;
        private List<string> Conexiones;
        private List<string> Nombres;
        private void GeneraListaTiposDato()
        {
            FTiposDato = new List<CTipoDato>();
            FTiposDato.Add(new CTipoDato("geography",TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("geometry", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("xml", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("bit", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("tinyint", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("smallint", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("date", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("int", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("real", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("smalldatetime", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("smallmoney", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("time", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("bigint", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("datetime", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("money", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("timestamp", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("image", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("ntext", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("text", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("uniqueidentifier", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("sysname", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("hierarchyid", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("sql_variant", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("datetime2", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("float", TIPO_LONGITUD.OPCIONAL));
            FTiposDato.Add(new CTipoDato("datetimeoffset", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("decimal", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("numeric", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("binary", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("char", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("nchar", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("nvarchar", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("varbinary", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("varchar", TIPO_LONGITUD.OBLIGATORIO));
        }
        public List<CTipoDato> DameTiposDato()
        {
            if (FTiposDato == null)
                GeneraListaTiposDato();
            return FTiposDato;
        }
        public CTipoDato GetTipoDato(string nombre)
        {
            //quito los parentesis en caso de que los tenga
            if (nombre.Contains('(') == true)
            {
                nombre = nombre.Substring(0, nombre.IndexOf('('));
            }
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
                FConnectionString = Conexion.ConnectionString;
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
            catch (System.Exception ex)
            {
                MsgError = ex.Message;
                return false;
            }
            Conexion.Close();
            return true;
        }
        public string GetStringError()
        {
            return MsgError;
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
            try
            {
                dr.Open();
            }
            catch(System.Exception ex)
            {
                //regresa un dr null
                if (MessageErrorEvent != null)
                    MessageErrorEvent(this,ex.Message);
                return null;
            }
            return dr;
        }
        public EnumMotoresDB GetMotor()
        {
            return EnumMotoresDB.SQLSERVER;
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
                case "IF":
                    Tipo = EnumTipoObjeto.FUNCION;
                    break;
                case "TF":
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
                case "D":
                    Tipo = EnumTipoObjeto.DEFAULT;
                    break;
                case "TT":
                    Tipo = EnumTipoObjeto.TYPE_TABLE;
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
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and (o.xtype='FN' or o.xtype='IF' or o.xtype='TF')";
                    break;
                case EnumTipoObjeto.IDENTITY:
                    query = "select distinct COLUMN_NAME as name ,'identity' as xtype from INFORMATION_SCHEMA.COLUMNS where COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 and COLUMN_NAME like'%" + nombre + "%'";
                    break;
                case EnumTipoObjeto.NONE:
                    query = "select distinct	o.name , o.xtype from sysobjects o where o.name like'%" + nombre + "%' and o.xtype!='TT' union select distinct name,'TT' as xtype from sys.table_types where name like '%" + nombre + "%' ";
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
                    query = "select distinct o.name ,o.xtype from syscomments c ,sysobjects o where c.text like '%" + nombre.Replace("\'","\'\'") + "%' and o.id=c.id";
                    break;
                case EnumTipoObjeto.TYPE_TABLE:
                    query = "select distinct name , 'TT' as xtype from sys.table_types where name like'%" + nombre + "%'";
                    break;
            }
            IDataReader dr = EjecutaQuery(query);
            if (dr == null)
                return l;
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

        private string GetDefaultName(int id)
        {
            string s = "";
            IDataReader dr=EjecutaQuery("select name from sysobjects where id="+id+" and xtype='D'");
            if(dr.Read())
            {
                s = dr["name"].ToString();
            }
            dr.Close();
            return s;
        }

        public List<CCampo> DameCamposTypeTabla(string tabla)
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
            s += "  case c.iscomputed when 1 then(select text from syscomments cc where cc.id = o.type_table_object_id and cc.number = c.colid) else '' end as Formula \n";
            s += " from \n";
            s += "  sys.table_types o, \n";
            s += "  syscolumns c, \n";
            s += "  systypes t \n";
            s += " where \n";
            s += "  o.name = '" + tabla + "' \n";
            s += "  and c.id = o.type_table_object_id \n";
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
                    campo.DefaultName = GetDefaultName(int.Parse(dr["cdefault"].ToString()));
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

        public List<CCampo> DameCamposTabla(string tabla)
        {
            List<CCampo> l = new List<CCampo>();
            String s = "";
            s += " select \n";
            s += "  c.name as Nombre, \n";
            s += "  t.name as TipoDato, \n";
//            s += "  c.length as Longitud, \n";
            s += "  c.prec as Longitud, \n";
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
                    campo.DefaultName = GetDefaultName(int.Parse(dr["cdefault"].ToString()));
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
            s = "select c.text from syscomments c,sysobjects o where c.id=o.id and (o.xtype='FN' or o.xtype='TF' or o.xtype='IF') and o.name = \'" + nombre.Trim() + "\' order by c.colid";
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
            s += " sys.indexes i \n";
            s += " , sysindexkeys ik \n";
            s += " ,syscolumns c \n";
            s += " where \n";
            s += " o.name = '" + tabla + "' \n";
            s += " and pk.parent_obj = o.id \n";
            s += " and pk.xtype = 'PK' \n";
            s += " and i.name = pk.name \n";
            s += " and ik.id = o.id \n";
            s += " and ik.indid = i.index_id \n";
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
                    if (campo.TipoDato.UsaLongitud == TIPO_LONGITUD.OBLIGATORIO)
                    {
                        if (campo.Longitud == -1 && (campo.TipoDato.Nombre.ToUpper() == "VARCHAR" || campo.TipoDato.Nombre.ToUpper() == "NVARCHAR"))
                            s += "(MAX)";
                        else 
                        s += "(" + campo.Longitud + ")";
                    }
                    if (campo.TipoDato.UsaLongitud == TIPO_LONGITUD.OPCIONAL && campo.Longitud>0)
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
                s += "\n\t, CONSTRAINT " + obj.Nombre + " check (" + obj.Regla + ")";
            }
            return s;
        }
        public string QueryCreaTabla(CTabla tabla)
        {
            if (tabla == null)
                return "";
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
        private List<CCampoIndex> DameCamposIndex(string indice)
        {
            string query = "";
            query += " \n";
            //------------------------------
            query += " select \n";
            query += "     c.name AS COLUMNA, \n";
            query += "     type_name(c.xusertype) AS TIPO, \n";
            query += "     convert(int, c.length)AS LONGITUD, \n";
            query += "     is_descending_key as descendente \n";
            query += " from \n";
            query += "     sysindexes i \n";
            query += " 	,sys.index_columns ic \n";
            query += "     , syscolumns c \n";
            query += "  where \n";
            query += "     i.name = '"+ indice + "' \n";
            query += "     and ic. object_id = i.id \n";
            query += "     and ic.index_id = i.indid \n";
            query += "     and c.id = i.id \n";
            query += "     and c.colid = ic.column_id \n";
            query += " order by \n";
            query += "     ic.index_id \n";
            //------------------------------
            List<CCampoIndex> l = new List<CCampoIndex>();
            IDataReader dr = EjecutaQuery(query);
            while (dr.Read())
            {
                CCampoIndex obj = new CCampoIndex();
                obj.Nombre = dr["COLUMNA"].ToString();
                obj.TipoDato = GetTipoDato(dr["TIPO"].ToString());
                obj.Longitud = int.Parse(dr["LONGITUD"].ToString());
                if(bool.Parse(dr["descendente"].ToString()))
                {
                    obj.Ordenamiento = EnumOrdenIndex.DESC;

                }
                else
                {
                    obj.Ordenamiento = EnumOrdenIndex.ASC;
                }
                l.Add(obj);
            }
            dr.Close();
            return l;
        }
        private List<Cindex> CargaIndices(string tabla)
        {
            List<Cindex> l1 = new List<Cindex>();
            //genero el query para tyraerme los indices asociados a la tabla
            string query = "select i.name from sysobjects o ,sys.indexes i where o.name='"+tabla+"' and i.object_id=o.id and i.name<>''";
            IDataReader dr = EjecutaQuery(query);
            while(dr.Read())
            {
                Cindex obj = new Cindex();
                obj.Nombre= dr["name"].ToString();
                //me traigo los campos que perteneces
                obj.Campos = DameCamposIndex(obj.Nombre);
                l1.Add(obj);
            }
            dr.Close();
            return l1;
        }
        public CTabla DameTabla(string nombre)
        {
            string s = "";
            CTabla tabla = new CTabla();
            //Busco si existe la tabla
            //            s = "select name from sysobjects where name='" + nombre + "' and xtype='U' union all select name from sys.table_types where name ='" + nombre + "'";
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
        public CTabla DameTypeTable(string nombre)
        {
            string s = "";
            CTabla tabla = new CTabla();
            //Busco si existe la tabla
            //            s = "select name from sysobjects where name='" + nombre + "' and xtype='U' union all select name from sys.table_types where name ='" + nombre + "'";
            s = "select name from sys.table_types where name='" + nombre + "'";
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
            List<CCampo> campos= DameCamposTypeTabla(nombre);
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
        public string DameCodigoTrigger(string nombre)
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
        public void CreaIndex(Cindex index,string tabla)
        {
            //crea el indice de la tabla
            string s = "create index " + index.Nombre + " on " + tabla + "(";
            bool primero = true;
            foreach(CCampoIndex obj in index.Campos)
            {
                if (primero == false)
                    s +=  ",";
                primero = false;
                s += obj.Nombre+" "+obj.Ordenamiento;
            }
            s += ")";
            EjecutaQuery(s);
        }
        public void CreaPrimaryKey(CPrimaryKey pk, string tabla)
        {
            string s = "alter table " + tabla + " add constraint " + pk.Nombre+ " primary key(";
            bool primero = true;
            foreach (CCampoBase obj in pk.Campos)
            {
                if (primero == false)
                    s += ",";
                primero = false;
                s += obj.Nombre;// + " " + obj.Ordenamiento;
            }
            s += ")";
            EjecutaQuery(s);
        }
        public void EliminaIndex(string tabla, string indice)
        {
            string s = "drop index "+tabla+"."+indice+"";
            EjecutaQuery(s);
        }
        public void EliminaPk(string tabla)
        {
            CPrimaryKey pk= DameLLavePrimaria(tabla);
            string s = "alter table "+tabla+" drop constraint "+pk.Nombre+"";
            EjecutaQuery(s);
        }
        public void AlterTable_AddColumn(string tabla, CCampo campo, CIdentidad identidad=null)
        {
            // creo la estructura basica del query
            string s = "alter table " + tabla + " add " + campo.Nombre + " ";
            // veo si es un campo calculado
            if (campo.CampoCalculado)
            {
                s += " as " + campo.Formula+" ";
            }
            else
            {
               s += campo.GetTipoString()+" ";
            }
            // veo si hacepta nulos
            if (campo.AceptaNulo == false)
            {
                s += " not null ";
            }
            //veo si es valor por default
            if (campo.EsDefault)
            {
                s += "default (" + campo.Formula + ") ";
            }
            //veo si es identidad
            else if (identidad != null)
            {
                s += " identity(" + identidad.ValorInicial + "," + identidad.Incremento + ") ";
            }
            EjecutaQuery(s);
        }
        public void AlterTable_DropColumn(string tabla, string campo)
        {
            string s = "alter table "+tabla+" drop column "+campo;
            EjecutaQuery(s);
        }
        public void AlterTable_AddUnique(string tabla, CUnique unique)
        {
            string s = "alter table "+tabla+ " add CONSTRAINT "+unique.Nombre+ " UNIQUE(";
            bool primero = true;
            foreach(CCampoBase obj in unique.Campos)
            {
                if(primero==false)
                {
                    s = s + ",";
                }
                primero = false;
                s += obj.Nombre;
            }
            s += ")";
            EjecutaQuery(s);
        }
        public void AlterTable_DropUnique(string tabla, string unique)
        {
            string s = "alter table "+tabla+" drop CONSTRAINT "+unique+"";
            EjecutaQuery(s);
        }
        public void AlterTable_DropDefault(string tabla, string defaultName)
        {
            EjecutaQuery("alter table "+tabla+ " DROP CONSTRAINT "+defaultName);
        }
        public void AlterTable_AddCheck(string tabla, CCheck check)
        {
            string s = "ALTER TABLE "+tabla+" ADD CONSTRAINT "+check.Nombre+" CHECK("+check.Regla+")";
            EjecutaQuery(s);
        }
        public void AlterTable_DropChechk(string tabla, string check)
        {
            EjecutaQuery("alter table " + tabla + " DROP CONSTRAINT " + check);
        }
        public void AlterTable_AlterColumn(string tabla, CCampo actual, CCampo nuevo)
        {
            string s = "";
            // modifica el campo conforme se encuentren diferencias
            //primero verifico hay un cabio e el tipo de dato o en si acepta nulos
            if(nuevo.GetTipoString()!=actual.GetTipoString()||nuevo.AceptaNulo!=actual.AceptaNulo)
            {
                //intento cambiar el tipo de dato
                s = "alter table "+tabla+" alter column "+actual.Nombre+" "+nuevo.GetTipoString();
                if (nuevo.AceptaNulo == false)
                    s += " not null";
                else
                    s += " null";
                EjecutaQuery(s);
            }
        }
        public CVista DameVista(string nombre)
        {
            CVista vista = null;// new CVista();
            string query = "select distinct	o.name , o.xtype from sysobjects o where o.name ='" + nombre + "' and o.xtype='V'";
            IDataReader dr = EjecutaQuery(query);
            if(dr.Read())
            {
                vista = new CVista();
                vista.Nombre = dr["name"].ToString();
                //me traigo los campos de la vista
                List<CCampoBase> campos = DameCamposVista(nombre);
                foreach(CCampoBase obj in campos)
                {
                    vista.AddCampo(obj);
                }
                //me traigo el codigo fuente de la vista
                vista.CodigoFuente = DameCodigoVista(nombre);
            }
            return vista;
        }
        public DataSet Execute(string comando)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand comand = new SqlCommand(comando);
                comand.Connection = new SqlConnection(FConnectionString);
                comand.CommandTimeout = 50000;
                comand.CommandText = comando;
                comand.Connection.Open();
                IDataReader dr = comand.ExecuteReader();
                ds.Load(dr, LoadOption.OverwriteChanges, new string[] { "Tabla 1", "Tabla 2", "Tabla 3", "Tabla 4", "Tabla 5", "Tabla 6", "Tabla 7", "Tabla 8", "Tabla 9", "Tabla 10", "Tabla 11", "Tabla 12", "Tabla 13", "Tabla 14", "Tabla 15" });
                comand.Connection.Close();
                //ahora elimino las tablas vacias
                int n = ds.Tables.Count;
                for(int i=n-1;i>=0;i--)
                {
                    DataTable dt = ds.Tables[i];
                    if (dt.Columns.Count==0)
                    {
                        ds.Tables.Remove(dt);
                    }
                }
                //veo si hay tablas 
                if(ds.Tables.Count==0)
                {
                    //no hay tablas, por lo que me traigo el numero de registros encontrados
                    string s = "";
                    if(dr.RecordsAffected==1)
                    {
                        s = "Un registro afectado";
                    }
                    else
                    {
                        s = dr.RecordsAffected.ToString() + " Registros afectados";
                    }
                    /*
                    //agrego una tabla con el mensaje
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Resultado", typeof(string));
                    DataRow registro = dt.NewRow();
                    registro["Resultado"] = s;
                    dt.Rows.Add(registro);
                    ds.Tables.Add(dt);
                    */
                    ExceptionDB ex2 = new ExceptionDB();
                    ex2.Add(new CError(0, s));
                    throw ex2;
                }
                return ds;
                #region Version vieja
                /*                DataSet ds = new DataSet();
                                SqlCommand comand = new SqlCommand(comando);
                                comand.Connection = new SqlConnection(FConnectionString);
                                SqlDataAdapter adaptador = new SqlDataAdapter(comand);
                                comand.Connection.Open();
                                int nregistros = adaptador.Fill(ds);
                                comand.Connection.Close();
                                return ds;
                                */
                #endregion
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                int i, n;
                ExceptionDB ex2 = new ExceptionDB();
                n = ex.Errors.Count;
                foreach(SqlError err in ex.Errors)
                {
                    ex2.Add(new CError(err.LineNumber,err.Message));
                }
                throw ex2;
            }
        }
        public DateTime DameFechaCreacion(string nombreObjeto)
        {
            string s = "select crdate from sysobjects where name='"+nombreObjeto+"'";
            DateTime fecha = DateTime.Now;
            IDataReader dr=            EjecutaQuery(s);
            while(dr.Read())
            {
                fecha = DateTime.Parse(dr["crdate"].ToString());
            }
            return fecha;
        }
        public DateTime DameFechaModificacion(string nombreObjeto)
        {
            string s = "select modify_date  from sys.objects where name='" + nombreObjeto + "'";
            DateTime fecha = DateTime.Now;
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                fecha = DateTime.Parse(dr["modify_date"].ToString());
            }
            return fecha;

        }
        public string GetExcecute_StoreProcedure(string nombre)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(FConnectionString);
            string cadena = "EXECUTE " + sb.InitialCatalog + ".dbo." + nombre + "(";
            List<MotorDB.CParametro> l = DameParametrosStoreProcedure(nombre);
            bool primero = true;
            foreach (MotorDB.CParametro obj in l)
            {
                if (primero)
                {
                    primero = false;
                    cadena += obj.Nombre;
                }
                else
                {
                    cadena += "," + obj.Nombre;
                }

            }
            cadena += ")";
            cadena += "\n IF @@ERROR <> 0";
            cadena += "\n BEGIN";
            cadena += "\n\tRAISERROR('Error al llamar a: "+nombre+ "', 18, 2) WITH SETERROR";
            cadena += "\n END\n";
            return cadena;
        }
        public string GetExcecute_Function(string nombre)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(FConnectionString);
            string cadena = sb.InitialCatalog + ".dbo." + nombre + "(";
            List<MotorDB.CParametro> l =DameParametrosFuncction(nombre);
            bool primero = true;
            foreach (MotorDB.CParametro obj in l)
            {
                if (primero)
                {
                    if (obj.Nombre != "")
                    {
                        primero = false;
                        cadena += obj.Nombre;
                    }
                }
                else
                {
                    cadena += "," + obj.Nombre;
                }

            }
            cadena += ")\n";
            return cadena;
        }
        public string DameCodigoTypeTable(string nombre)
        {
            CTabla tabla = DameTypeTable(nombre);
            string s = QueryCreaTypeTable(tabla);
            return s;
        }
        public string QueryCreaTypeTable(CTabla tabla)
        {
            if (tabla == null)
                return "";
            string s = "create type " + tabla.Nombre+" as table";
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
        private string DameScriptObjeto(CObjeto obj)
        {
            string nl = "\r\n";
            string s = "";
            string Nombre = obj.Nombre;
            switch(obj.Tipo)
            { 
                case MotorDB.EnumTipoObjeto.TABLE:
                    s = "DROP TABLE dbo." + Nombre + nl;
                s += "GO" + nl;
                s += DameCodigoTabla(Nombre) + nl;
                break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s = "DROP PROCEDURE dbo." + Nombre + nl;
                s += "GO" + nl;
                s += DameCodigoStoreProcedure(Nombre) + nl;
                break;
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s = "DROP FUNCTION dbo." + Nombre + nl;
                s += "GO" + nl;
                s += DameCodigoFuncction(Nombre) + nl;
                break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s = "DROP TRIGGER dbo." + Nombre + nl;
                s += "GO" + nl;
                s += DameCodigoTrigger(Nombre) + nl;
                break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = "DROP VIEW dbo." + Nombre + nl;
                s += "GO" + nl;
                s += DameCodigoVista(Nombre) + nl;
                break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s = "DROP TYPE dbo." + Nombre + nl;
                s += "GO" + nl;
                s += DameCodigoTypeTable(Nombre) + nl;
                break;
            }
            s += "GO"+nl;
            return s;
        }
        public string CreaScript(List<CObjeto> lista)
        {
            string nl = "\r\n";
            string s = "USE " + GetDataBseName()+nl;
            s += "GO"+nl;
            //recorro la lista de objetos y voy generando su script
            foreach(CObjeto obj in lista)
            {
                s += DameScriptObjeto(obj);
            }
            return s;
        }
        public string GetNetProvider()
        {
            return "System.Data.SqlClient";
        }
        public string DameTipoDatoNet(CTipoDato tipo)
        {
            string s = "";
            switch (tipo.Nombre.ToUpper().Trim())
            {
                case "BIT":
                    s = "System.Boolean";
                    break;
                case "TINYINT":
                    s = "System.Int16";
                    break;
                case "INT":
                    s = "System.Int32";
                    break;
                case "BIGINT":
                    s = "System.Int64";
                    break;
                case "SMALLMONEY":
                    s = "System.Decimal";
                    break;
                case "MONEY":
                    s = "System.Decimal";
                    break;
                case "DECIMAL":
                    s = "System.Decimal";
                    break;
                case "NUMERIC":
                    s = "System.Decimal";
                    break;
                case "REAL":
                    s = "System.Single";
                    break;
                case "FLOAT":
                    s = "System.Double";
                    break;
                case "SMALLINT":
                    s = "Int64";
                    break;
                case "DATETIME":
                    s = "DateTime";
                    break;
                case "DATE":
                    s = "DateTime";
                    break;
                case "BINARY":
                    s = "Byte";
                    break;
                case "DATETIME2":
                    s = "DateTime";
                    break;
                case "DATETIMEOFFSET":
                    s = "DateTimeOffset";
                    break;
                case "NCHAR":
                    s = "String";
                    break;
                case "CHAR":
                    s = "String";
                    break;
                case "NVARCHAR":
                    s = "String";
                    break;
                case "VARCHAR":
                   s = "String";
                    break;
                case "ROWVERSION":
                    s = "Byte[]";
                    break;
                case "SQL_VARIANT":
                    s = "Object";
                    break;
                case "TIME":
                    s = "TimeSpan";
                    break;
                default:
                    throw new Exception("No se reconoce el tipo de dato");
            }
            return s;
        }
        public List<CTabla> DameResultadoProcedimientoAlmacenado(string Nombre)
        {
            List<CTabla> l = new List<CTabla>();
            int j, k;
            //creo la consulta para extraer la informacion del SP
            System.Data.SqlClient.SqlCommand SqlCommand1;
            SqlCommand1 = new System.Data.SqlClient.SqlCommand();
            SqlCommand1.CommandText = Nombre;
            SqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand1.Connection = new System.Data.SqlClient.SqlConnection(GetConecctionString());
            SqlCommand1.Connection.Open();
            System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(SqlCommand1);
            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
            sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = SqlCommand1;
            //creo el data set en donde me va a traer los datos
            DataSet ds = new DataSet("aaa");
            try
            {
                sqlDataAdapter1.GetFillParameters();
                //se trae la estructura del resultado
                sqlDataAdapter1.FillSchema(ds, SchemaType.Source, "aaa");
                //recorro cada una de las tablas para obtener la informacion
                foreach(DataTable dt in ds.Tables)
                {
                    //creo la tabla
                    CTabla tabla = new CTabla()
                    {
                        Nombre = dt.TableName
                    };
                    //recorro los campos para signarlos a la tabla
                    foreach(System.Data.DataColumn dc in dt.Columns)
                    {
                        CCampo campo = new CCampo()
                        {
                             Nombre=dc.ColumnName
                             , Longitud=dc.MaxLength
                             , AceptaNulo=dc.AllowDBNull
                             , CampoCalculado=(dc.Expression.Trim()!="")
                               , EsDefault=(dc.DefaultValue.ToString()!="")
                               , Formula=dc.Expression.Trim()
                             , TipoDato = GetTipoDato(dc.DataType.Name)
                        };
                        tabla.AddCampo(campo);
                    }
                    l.Add(tabla);
                }
            }
            catch (Exception ex)
            {
                SqlCommand1.Connection.Close();
                throw new Exception(ex.Message);
            }
            SqlCommand1.Connection.Close();
            return l;
        }
        public CTabla DamePrimerResultadoProcedimientoAlmacenado(string nombre)
        {
            CTabla tabla =new CTabla();
            IDataReader dr = EjecutaQuery("sp_describe_first_result_set @tsql = N'"+nombre+"' ");
            //recorro todos los registros
            while (dr.Read())//&& dr.IsClosed==false)
            {
                CCampo campo = new CCampo()
                {
                    Nombre = dr["name"].ToString()
                     ,
                    TipoDato = GetTipoDato(dr["system_type_name"].ToString())
                      ,
                    Longitud = int.Parse(dr["max_length"].ToString())

                };
                tabla.AddCampo(campo);
            }
            dr.Close();
            if (tabla.Campos.Count == 0)
                return null;
            return tabla;
        }
        /// <summary>
        /// regresa el listado de palabras reservadas
        /// </summary>
        /// <returns></returns>
        public List<string> DamePalabrasReservadas()
        {
            List<string> l = new List<string>();
            l.Add("INNER");
            l.Add("JOIN");
            l.Add("LEFT");
            l.Add("RIGHT");
            l.Add("OUTER");
            l.Add("UNION");
            l.Add("ON");
            l.Add("NOCOUNT");
            l.Add("OFF");
            l.Add("FULL");
            l.Add("ALL");
            l.Add("AS");
            l.Add("AND");
            l.Add("OR");
            l.Add("LIKE");
            l.Add("IN");
            l.Add("EXISTS");
            l.Add("BETWEEN");
            l.Add("DROP");
            l.Add("DELETE");
            l.Add("TRUNCATE");
            l.Add("TOP");
            l.Add("DISTINCT");
            l.Add("LIMIT");
            l.Add("OPENDATASOURCE");
            l.Add("GO");
            l.Add("USE");
            l.Add("COMMIMT");
            l.Add("ROLLBACK");
            l.Add("TRANSACTION");
            l.Add("TRAN");
            l.Add("TRY");
            l.Add("CATCH");
            l.Add("RAISERROR");
            l.Add("finally");
            l.Add("CURSOR");
            l.Add("FOR");
            l.Add("OPEN");
            l.Add("FETCH");
            l.Add("NEXT");
            l.Add("CLOSE");
            l.Add("DEALLOCATE");
            l.Add("FOREACH");
            l.Add("NOT");
            l.Add("SET");
            l.Add("DESC");
            l.Add("ASC");
            l.Add("EXEC");
            l.Add("WITH");
            l.Add("EXECUTE");
            l.Add("identity");
            l.Add("NOLOCK");
            l.Add("OUTPUT");
            l.Add("INSERT");
            l.Add("SELECT");
            l.Add("UPDATE");
            l.Add("FROM");
            l.Add("WHERE");
            l.Add("HAVING");
            l.Add("GROUP");
            l.Add("BY");
            l.Add("ORDER");
            l.Add("CREATE");
            l.Add("ALTER");
            l.Add("ADD");
            l.Add("NULL");
            l.Add("INTO");
            l.Add("VALUES");
            l.Add("IS");
            l.Add("VARCHAR");
            l.Add("NVARCHAR");
            l.Add("CHAR");
            l.Add("NCHAR");
            l.Add("INT");
            l.Add("TEXT");
            l.Add("NTEXT");
            l.Add("DOUBLE");
            l.Add("MONEY");
            l.Add("BIT");
            l.Add("DATETIME");
            l.Add("DECIMAL");
            l.Add("FLOAT");
            l.Add("DATE");
            l.Add("DEFAULT");
            l.Add("real");
            l.Add("TinyInt");
            l.Add("TABLE");
            l.Add("PROC");
            l.Add("PROCEDURE");
            l.Add("FUNCTION");
            l.Add("VIEW");
            l.Add("TRIGGER");
            l.Add("INDEX");
            l.Add("DATABASE");
            l.Add("TYPE");
            l.Add("column");
            l.Add("IF");
            l.Add("ELSE");
            l.Add("CASE");
            l.Add("WHEN");
            l.Add("THEN");
            l.Add("WHILE");
            l.Add("WAITFOR");
            l.Add("DELAY");
            l.Add("RETURN");
            l.Add("SWITCH");
            l.Add("BREAK");
            l.Add("DECLARE");
            l.Add("BEGIN");
            l.Add("END");
            l.Add("SUBSTRING");
            l.Add("UPPER");
            l.Add("LOWER");
            l.Add("REVERSE");
            l.Add("REPLACE");
            l.Add("LTRIM");
            l.Add("RTRIM");
            l.Add("CAST");
            l.Add("CONVERT");
            l.Add("ISNULL");
            l.Add("DATEDIFF");
            l.Add("GETDATE");
            l.Add("FLOOR");
            l.Add("openquery");
            l.Add("dateadd");
            l.Add("POWER");
            l.Add("ISDATE");
            l.Add("ROUND");
            l.Add("STRING_SPLIT");
            l.Add("CHARINDEX");
            l.Add("len");
            l.Add("SUM");
            l.Add("COUNT");
            l.Add("MAX");
            l.Add("MIN");
            l.Add("AVG");
            l.Add("month");
            l.Add("YEAR");
            l.Add("DAY");
            l.Add("CURRENT_TIMESTAMP");
            return l;
        }
        public void SuscribeErrorMessageEvent(MotorDBMessageEvent e)
        {
            MessageErrorEvent += e;
        }

        public System.Windows.Forms.DialogResult ShowDlgMultiConfig()
        {
            Motores.SQLServer.FormDlsMultiConfigSqlServer dlg = new Motores.SQLServer.FormDlsMultiConfigSqlServer();
            System.Data.SqlClient.SqlConnection Conexion = new SqlConnection(FConnectionString);
            dlg.ConnectionString = Conexion.ConnectionString;
            //dlg.ConnectioName = ConnectionName;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Conexion.ConnectionString = dlg.ConnectionString;
                FConnectionString = Conexion.ConnectionString;
                //ConnectionName = dlg.ConnectioName;
                Conexiones = dlg.GetConnexciones();
                Nombres = dlg.getNombres();
            }
            return dlg.DialogResult;
        }
        public string GetConeccionString(int pos)
        {
            return Conexiones[pos];

    }
        public string GetConnectionName(int pos)
        {
            return Nombres[pos];
        }
        public int GetConnectionsCount()
        {
            return Conexiones.Count();
        }
    }
}
  