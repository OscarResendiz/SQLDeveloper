using MotorDB.Motores.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace MotorDB 
{
    class CMotorMySQL : IMotorDB
    {
        private event MotorDBMessageEvent MessageErrorEvent;
        private string FConnectionString;
        private string ConnectionName;
        private string MsgError;
        private List<string> Conexiones;
        static List<CTipoDato> FTiposDato;
        private List<string> Nombres;
        private List<CObjeto> Buffer;
        private System.DateTime BufferTimer;
        public void AlterTable_AddCheck(string tabla, CCheck check)
        {
            string s = "ALTER TABLE " + tabla + " ADD CONSTRAINT " + check.Nombre + " CHECK(" + check.Regla + ");";
            EjecutaQuery(s);
        }

        public void AlterTable_AddColumn(string tabla, CCampo campo, CIdentidad identidad = null)
        {
            // creo la estructura basica del query
            string s = "alter table " + tabla + " add " + campo.Nombre + " ";
            // veo si es un campo calculado
            if (campo.CampoCalculado)
            {
                s += " as " + campo.Formula + " ";
            }
            else
            {
                s += campo.GetTipoString() + " ";
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

        public void AlterTable_AddUnique(string tabla, CUnique unique)
        {
            string s = "alter table " + tabla + " add CONSTRAINT " + unique.Nombre + " UNIQUE(";
            bool primero = true;
            foreach (CCampoBase obj in unique.Campos)
            {
                if (primero == false)
                {
                    s = s + ",";
                }
                primero = false;
                s += obj.Nombre;
            }
            s += ")";
            EjecutaQuery(s);
        }

        public void AlterTable_AlterColumn(string tabla, CCampo actual, CCampo nuevo)
        {
            string s = "";
            // modifica el campo conforme se encuentren diferencias
            //primero verifico hay un cabio e el tipo de dato o en si acepta nulos
            if (nuevo.GetTipoString() != actual.GetTipoString() || nuevo.AceptaNulo != actual.AceptaNulo)
            {
                //intento cambiar el tipo de dato
                s = "alter table " + tabla + " alter column " + actual.Nombre + " " + nuevo.GetTipoString();
                if (nuevo.AceptaNulo == false)
                    s += " not null";
                else
                    s += " null";
                EjecutaQuery(s);
            }
        }

        public void AlterTable_DropChechk(string tabla, string check)
        {
            EjecutaQuery("alter table " + tabla + " DROP CONSTRAINT " + check);
        }

        public void AlterTable_DropColumn(string tabla, string campo)
        {
            string s = "alter table " + tabla + " drop column " + campo;
            EjecutaQuery(s);
        }

        public void AlterTable_DropDefault(string tabla, string defaultName)
        {
            EjecutaQuery("alter table " + tabla + " DROP CONSTRAINT " + defaultName);
        }

        public void AlterTable_DropUnique(string tabla, string unique)
        {
            string s = "alter table " + tabla + " drop CONSTRAINT " + unique + "";
            EjecutaQuery(s);
        }

        public List<CObjeto> BuscaEnTablas(string campo)
        {
            //regresa el listado de tablas que contengas el campo buscado
            List<CObjeto> l = new List<CObjeto>();
            
            string query = "select 	DISTINCT o.table_name from information_schema.tables o ,information_schema.columns c where o.table_schema='" + GetDataBseName() + "' and o.table_type='BASE TABLE' and c.table_schema=o.table_schema and c.table_name=o.table_name and c.COLUMN_NAME like '%" + campo + "%'";
            IDataReader dr = EjecutaQuery(query);
            while (dr.Read())
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = EnumTipoObjeto.TABLE;
                l.Add(obj);
            }
            dr.Close();
            return l;
        }

        public List<CObjeto> BuscaEnVistas(string campo)
        {
            //regresa el listado de vistas que contengas el campo buscado
            List<CObjeto> l = new List<CObjeto>();
            string query = "select 	DISTINCT o.table_name from information_schema.tables o ,information_schema.columns c where o.table_schema='" + GetDataBseName() + "' and o.table_type='VIEW' and c.table_schema=o.table_schema and c.table_name=o.table_name and c.COLUMN_NAME like '%" + campo + "%'";
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

        public List<CObjeto> Buscar(string nombre, EnumTipoObjeto tipo = EnumTipoObjeto.NONE)
        {
            //if(tipo == EnumTipoObjeto.NONE || tipo== EnumTipoObjeto.TABLE)
           // {
             //   return BuscaEnBuffer(nombre, tipo);
           // }
            //regresa el listado de objetos que coincidan con el nombre y tipo seleccionado
            List<CObjeto> l = new List<CObjeto>();
            string query = "";
            switch (tipo)
            {
                case EnumTipoObjeto.CAMPO:
                    query = "select 	DISTINCT o.table_name as name,o.table_type as xtype from information_schema.tables o ,information_schema.columns c where o.table_schema='" + GetDataBseName() + "'  and c.table_schema=o.table_schema and c.table_name=o.table_name and UPPER(c.COLUMN_NAME) like UPPER('%" + nombre.Trim() + "%')";
                    break;
                case EnumTipoObjeto.CHECK:
                    query = "select 	CONSTRAINT_NAME as name	,CONSTRAINT_TYPE as xtype from 	INFORMATION_SCHEMA.TABLE_CONSTRAINTS c where 	c.CONSTRAINT_TYPE='CHECK' 	and UPPER(CONSTRAINT_NAME) like UPPER('%" + nombre.Trim() + "%') 	and TABLE_SCHEMA='"+ GetDataBseName() + "'";
                    break;
                case EnumTipoObjeto.FOREIGNKEY:
                    query = "select 	CONSTRAINT_NAME as name, 'F' as xtype from 	INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS  where CONSTRAINT_SCHEMA ='"+ GetDataBseName ()+ "' and UPPER(CONSTRAINT_NAME) like UPPER('%" + nombre.Trim() + "%')";
                    break;
                case EnumTipoObjeto.FUNCION:
                    query = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + GetDataBseName() + "' and UPPER(ROUTINE_NAME) like UPPER('%" + nombre.Trim() + "%') and ROUTINE_TYPE='FUNCTION'"; ;
                    break;
                case EnumTipoObjeto.IDENTITY:
                    query = "select column_name as name, 'identity' as xtype from INFORMATION_SCHEMA.COLUMNS where table_schema='"+ GetDataBseName ()+ "' and UPPER(COLUMN_NAME) like UPPER('%" + nombre.Trim() + "%') and extra='auto_increment'";
                    break;
                case EnumTipoObjeto.NONE:
                    query = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + GetDataBseName() + "' and UPPER(ROUTINE_NAME) like UPPER('%" + nombre.Trim() + "%')\n";
                    query = query + "union all\n";
                    query = query + "select table_NAME as NAME,TABLE_TYPE as XTYPE from information_schema.tables where table_SCHEMA='" + GetDataBseName() + "' and UPPER(table_NAME) like UPPER('%" + nombre.Trim() + "%')\n";
                    query = query + "order by name";
                    break;
                case EnumTipoObjeto.PRIMARYKEY:
                    query = "select distinct CONSTRAINT_NAME as name, 'PK' as xtype from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_SCHEMA='"+ GetDataBseName ()+ "' and UPPER(CONSTRAINT_NAME) like UPPER('%" + nombre.Trim()+"%') and CONSTRAINT_TYPE='PRIMARY KEY'";
                    break;
                case EnumTipoObjeto.PROCEDURE:
                    query = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + GetDataBseName ()+ "' and UPPER(ROUTINE_NAME) like UPPER('%" + nombre.Trim() + "%') and ROUTINE_TYPE='PROCEDURE'";
                    break;
                case EnumTipoObjeto.TABLE:
                    query = "select table_name as NAME,table_type as XTYPE from information_schema.tables where table_type=\'BASE TABLE\' and UPPER(table_name) like UPPER(\'" + nombre.Trim() + "%\') and table_schema=\'" + GetDataBseName ()+ "\';";
                    break;
//                case EnumTipoObjeto.TIPEDATA:
  //                  query = "select distinct	name , 'TIPEDATA' as xtype from systypes  where name like'%" + nombre + "%' ";
    //                break;
                case EnumTipoObjeto.TRIGER:
                    query = "select TRIGGER_NAME as name, 'TR' as type from INFORMATION_SCHEMA.TRIGGERS where TRIGGER_SCHEMA='"+ GetDataBseName ()+ "' and UPPER(TRIGGER_NAME) like UPPER('%" + nombre.Trim()+"%')";
                    break;
                case EnumTipoObjeto.UNIQUE:
                    query = "select distinct CONSTRAINT_NAME as name, 'UQ' as xtype from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_SCHEMA='"+ GetDataBseName ()+ "' and UPPER(CONSTRAINT_NAME) like UPPER('%" + nombre.Trim()+"%') and CONSTRAINT_TYPE='UNIQUE'";
                    break;
                case EnumTipoObjeto.VIEW:
                    query = "select table_name as NAME,\'V\' as XTYPE from information_schema.tables where table_type=\'VIEW\' and table_schema=\'" + GetDataBseName() + "\' and UPPER(table_name) like UPPER(\'%" + nombre.Trim() + "%\')";
                    break;
                case EnumTipoObjeto.INDEX:
                    query = "select index_name as name, 'INDEX' as xtype from INFORMATION_SCHEMA.STATISTICS where index_schema='"+ GetDataBseName ()+ "' and UPPER(index_name) like UPPER('%" + nombre.Trim()+"%')";
                    break;
                case EnumTipoObjeto.CODE:                    
                    query = "select routine_name as name, routine_type as xtype from INFORMATION_SCHEMA.ROUTINES where routine_schema='" + GetDataBseName() + "' and UPPER(routine_definition) like UPPER('%" + nombre.Replace("\'", "\'\'") + "%')";
                    break;
//                case EnumTipoObjeto.TYPE_TABLE:
  //                  query = "select distinct name , 'TT' as xtype from sys.table_types where name like'%" + nombre + "%'";
    //                break;
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
            dr.Close();
            return l;
        }
        private List<CObjeto> BuscaEnBuffer(string nombre, EnumTipoObjeto tipo)
        {
            if (BufferTimer == null)
                BufferTimer = System.DateTime.Now;
            List<CObjeto> l = new List<CObjeto>();
            if (Buffer == null || Buffer.Count==0|| BufferTimer.AddMinutes(10) > System.DateTime.Now)
            {
                if (Buffer == null)
                    Buffer = new List<CObjeto>();
                Buffer.Clear();
                //cargo la informacion desde la base
                string query = "";
                query = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + GetDataBseName() + "'\n";
                query = query + "union all\n";
                query = query + "select table_NAME as NAME,TABLE_TYPE as XTYPE from information_schema.tables where table_SCHEMA='" + GetDataBseName() + "'\n";
                query = query + "order by name";
                IDataReader dr = EjecutaQuery(query);
                if (dr == null)
                    return l;
                while (dr.Read())
                {
                    CObjeto obj = new CObjeto();
                    obj.Nombre = dr["name"].ToString();
                    obj.Tipo = DameXType(dr["xtype"].ToString());
                    Buffer.Add(obj);
                }
                dr.Close();
            }
            foreach(CObjeto obj in Buffer)
            {
                if(obj.Nombre.ToUpper().Trim().Contains(nombre.ToUpper().Trim()))
                {
                    if (tipo == EnumTipoObjeto.NONE)
                    {
                        l.Add(obj);
                    }
                    else
                    {
                        if(obj.Tipo== tipo)
                        {
                            l.Add(obj);
                        }
                    }
                }
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
                case "FOREIGN KEY":
                    Tipo = EnumTipoObjeto.FOREIGNKEY;
                    break;
                case "FN":
                    Tipo = EnumTipoObjeto.FUNCION;
                    break;
                case "FUNCTION":
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
                case "PRIMARY KEY":
                    Tipo = EnumTipoObjeto.PRIMARYKEY;
                    break;
                case "P":
                    Tipo = EnumTipoObjeto.PROCEDURE;
                    break;
                case "PROCEDURE":
                    Tipo = EnumTipoObjeto.PROCEDURE;
                    break;
                case "U":
                    Tipo = EnumTipoObjeto.TABLE;
                    break;
                case "BASE TABLE":
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
                case "UNIQUE":
                    Tipo = EnumTipoObjeto.UNIQUE;
                    break;
                case "V":
                    Tipo = EnumTipoObjeto.VIEW;
                    break;
                case "SYSTEM VIEW":
                    Tipo = EnumTipoObjeto.VIEW;
                    break;
                case "VIEW":
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

        public bool Conectar()
        {
            //solo pruebo la conexion y regreso true si se pudo establecer la conexion
            MySql.Data.MySqlClient.MySqlConnection  Conexion = new MySql.Data.MySqlClient.MySqlConnection(FConnectionString);
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

        public void CreaForeignKey(CForeignKey fk)
        {
            string s = GeneraQueryFK(fk);
            EjecutaQuery(s);
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
        private string AccionReferencial(EnumAccionReferencial op)
        {
            string s = "";
            switch (op)
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
                    throw new Exception("Accion refrencial no soportada: " + op);
            }
            return s;
        }

        public void CreaIndex(Cindex index, string tabla)
        {
            //crea el indice de la tabla
            string s = "create index " + index.Nombre + " on " + tabla + "(";
            bool primero = true;
            foreach (CCampoIndex obj in index.Campos)
            {
                if (primero == false)
                    s += ",";
                primero = false;
                s += obj.Nombre + " " + obj.Ordenamiento;
            }
            s += ")";
            EjecutaQuery(s);
        }

        public void CreaPrimaryKey(CPrimaryKey pk, string tabla)
        {
            string s = "alter table " + tabla + " add constraint " + pk.Nombre + " primary key(";
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

        public string CreaScript(List<CObjeto> lista)
        {
            string nl = "\r\n";
            string s = "USE " + GetDataBseName() + nl;
            s += "GO" + nl;
            //recorro la lista de objetos y voy generando su script
            foreach (CObjeto obj in lista)
            {
                s += DameScriptObjeto(obj);
            }
            return s;
        }
        private string DameScriptObjeto(CObjeto obj)
        {
            string nl = "\r\n";
            string s = "";
            string Nombre = obj.Nombre;
            switch (obj.Tipo)
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
            s += "GO" + nl;
            return s;
        }

        public void CreaTabla(CTabla tabla)
        {
            //genera el codigo para crear la tabla y lo ejecuta
            string s = QueryCreaTabla(tabla);
            EjecutaQuery(s);
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

        public List<EnumAccionReferencial> DameAccionesReferencialesBorradoValidos()
        {
            List<EnumAccionReferencial> l = new List<EnumAccionReferencial>();
            l.Add(EnumAccionReferencial.NO_ACTION);
            l.Add(EnumAccionReferencial.CASCADE);
            l.Add(EnumAccionReferencial.SET_NULL);
            l.Add(EnumAccionReferencial.SET_DEFAULT);
            return l;
        }

        public List<CCampo> DameCamposTabla(string tabla)
        {
            List<CCampo> l = new List<CCampo>();
            string s = "select \n";
            s = s + "	COLUMN_NAME as Nombre,\n";
            s = s + "	DATA_TYPE as TipoDato,\n";
            s = s + "	CHARACTER_MAXIMUM_LENGTH as Longitud,\n";
            s = s + "	0 as CampoCalculado,\n";
            s = s + "	case IS_NULLABLE when 'YES' then 1 else 0 end as AceptaNulo,\n";
            s = s + "  !isnull(column_default)  as cdefault , \n";
            s = s + "column_default as Formula\n";
            s = s + "from \n";
            s = s + "    information_schema.columns\n";
            s = s + "where \n";
            s = s + "    table_schema='" + GetDataBseName() + "' \n";
            s = s + "    and table_name='" + tabla + "'\n";
            s = s + "order by \n";
            s = s + "	ORDINAL_POSITION\n";
            s = s + "\n";

            //System.Data.IDataReader dr;
            IDataReader dr;
            dr = EjecutaQuery(s);
            if (dr == null)
                return l;
            while (dr.Read())// (dr.IsClosed == false && dr.Read())
            {
                CCampo campo = new CCampo();
                campo.Nombre = dr["Nombre"].ToString();
                campo.Tipo = EnumTipoObjeto.CAMPO;
                campo.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                if (dr["Longitud"].ToString().Trim() != "")
                    campo.Longitud = int.Parse(dr["Longitud"].ToString());
                else
                    campo.Longitud = 0;
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
            foreach (CCampo obj in l)
            {
                if (obj.EsDefault)
                {
                    obj.Formula = obj.Formula;// DameDefault(tabla, obj.Nombre);
                }
            }
            return l;
        }
        private string GetDefaultName(int id)
        {
//            string s = "";
  //          IDataReader dr = EjecutaQuery("select name from sysobjects where id=" + id + " and xtype='D'");
    //        if (dr.Read())
      //      {
        //        s = dr["name"].ToString();
          //  }
            //dr.Close();
            return "";
        }


        public List<CCampo> DameCamposTypeTabla(string tabla)
        {
            return DameCamposTabla(tabla);
        }

        public List<CCampoBase> DameCamposVista(string vista)
        {
            List<CCampoBase> l = new List<CCampoBase>();
            string s = "select \n";
            s = s + "	COLUMN_NAME as Nombre,\n";
            s = s + "	DATA_TYPE as TipoDato,\n";
            s = s + "	CHARACTER_MAXIMUM_LENGTH as Longitud\n";
            s = s + "from \n";
            s = s + "    information_schema.columns\n";
            s = s + "where \n";
            s = s + "    table_schema='" + GetDataBseName() + "' \n";
            s = s + "    and table_name='" + vista + "'\n";
            s = s + "order by \n";
            s = s + "	ORDINAL_POSITION\n";
            s = s + "\n";

            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CCampoBase campo = new CCampoBase();
                campo.Nombre = dr["Nombre"].ToString();
                campo.Tipo = EnumTipoObjeto.CAMPO;
                campo.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                if (dr["Longitud"].ToString().Trim() != "")
                    campo.Longitud = int.Parse(dr["Longitud"].ToString());
                else
                    campo.Longitud = 0;
                l.Add(campo);

            }
            dr.Close();
            return l;
        }

        public string DameCodigoFuncction(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "show create function " + nombre.Trim() + "";
            string campo = "Create function";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "SET GLOBAL log_bin_trust_function_creators = 1;\r\ndrop function " + nombre.Trim()+";\r\n";
            while (dr.Read())
            {
                s = s + dr[campo].ToString().Replace('�', 'ñ');
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
            s = "show create procedure " + nombre.Trim() + "";
            string campo = "Create Procedure";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "drop procedure " + nombre.Trim() + ";\r\n";
            while (dr.Read())
            {
                s = s + dr[campo].ToString().Replace('�', 'ñ');
            }
            dr.Close();
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
            s = "show create view " + nombre.Trim() + "";
            string campo = "Create view";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr[campo].ToString().Replace('�', 'ñ');
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }

        public string DameCodigoTabla(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "show create table " + nombre.Trim() + "";
            string campo = "Create table";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr[campo].ToString().Replace('�', 'ñ');
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }

        public string DameCodigoTrigger(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "show create trigger " + nombre.Trim() + "";
            string campo = "SQL Original";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr[campo].ToString().Replace('�', 'ñ');
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }

        public string DameCodigoTypeTable(string nombre)
        {
            return DameCodigoTabla(nombre);
        }


        public List<CObjeto> DameDependenciasDe(string nombre)
        {
            //regresa la lista de objetos de los cuales depende el que se le pasa ala funcion
            List<CObjeto> l = new List<CObjeto>();
            string s = "select distinct  table_name  as NAME,'U' as xtype from information_schema.KEY_COLUMN_USAGE  where table_schema='" + GetDataBseName() + "' and referenced_table_name='" + nombre + "' and constraint_name<>'primary' order by table_name ";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())//&& dr.IsClosed == false)
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
            string s = "select distinct referenced_table_name as NAME,'U' as XTYPE from information_schema.KEY_COLUMN_USAGE  where table_schema='" + GetDataBseName ()+ "' and table_name ='" + nombre + "' and constraint_name<>'primary' order by referenced_table_name";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())//&& dr.IsClosed == false)
            {
                CObjeto obj = new CObjeto();
                obj.Nombre = dr["name"].ToString();
                obj.Tipo = DameXType(dr["xtype"].ToString());
                l.Add(obj);
            }
            dr.Close();
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

        public DateTime DameFechaCreacion(string nombreObjeto)
        {
            string s = "select createtime as crdate from INFORMATION_SCHEMA.TABLES where table_schema='"+GetDataBseName()+"'  and table_name='" + nombreObjeto + "'";
            DateTime fecha = DateTime.Now;
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                fecha = DateTime.Parse(dr["crdate"].ToString());
            }
            return fecha;
        }

        public DateTime DameFechaModificacion(string nombreObjeto)
        {
            string s = "select createtime as crdate from INFORMATION_SCHEMA.TABLES where table_schema='" + GetDataBseName() + "'  and table_name='" + nombreObjeto + "'";
            DateTime fecha = DateTime.Now;
            IDataReader dr = EjecutaQuery(s);
            if(dr==null)
                return System.DateTime.Now;
            while (dr.Read())
            {
                fecha = DateTime.Parse(dr["crdate"].ToString());
            }
            return fecha;
        }

        public CPrimaryKey DameLLavePrimaria(string tabla)
        {
            //regresa la llave primaria de la tabla
            List<CCampoBase> Campos = new List<CCampoBase>();
            CPrimaryKey pk = new CPrimaryKey();
            string s = "";
            s += "select \n";
            s += "	c.column_name as Campo, \n";
            s += "	c.data_type as TipoDato, \n";
            s += " 	c.CHARACTER_MAXIMUM_LENGTH as Longitud,\n";
            s += "	y.CONSTRAINT_NAME as nombre \n";
            s += "from \n";
            s += "	INFORMATION_SCHEMA.COLUMNS c, \n";
            s += "	INFORMATION_SCHEMA.TABLE_CONSTRAINTS y \n";
            s += "	,INFORMATION_SCHEMA.KEY_COLUMN_USAGE C2 \n";
            s += "where \n";
            s += "	y.CONSTRAINT_SCHEMA='"+GetDataBseName()+"' \n";
            s += "	and y.table_name='"+tabla+"' \n";
            s += "	and y.constraint_type='PRIMARY KEY' \n";
            s += "	and c.table_schema=y.CONSTRAINT_SCHEMA \n";
            s += "	and c.table_name=y.table_name \n";
            s += "	AND C2.CONSTRAINT_SCHEMA=y.CONSTRAINT_SCHEMA \n";
            s += "	AND C2.CONSTRAINT_NAME=y.CONSTRAINT_NAME  \n";
            s += "	AND C2.table_name=y.table_name \n";
            s += "	AND C2.column_name=c.column_name \n";

            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            if (dr == null)
                return null;
            while (dr.Read())
            {
                CCampoBase campo = new CCampoBase();
                campo.Nombre = dr["Campo"].ToString();
                campo.Tipo = EnumTipoObjeto.CAMPO;
                campo.TipoDato = GetTipoDato(dr["TipoDato"].ToString());
                if (dr["Longitud"].ToString().Trim() != "")
                    campo.Longitud = int.Parse(dr["Longitud"].ToString());
                else
                    campo.Longitud = 0;
                pk.Nombre = dr["nombre"].ToString();
                pk.AddCampo(campo);
            }
            dr.Close();
            if (pk.Campos.Count == 0)
            {
                return null;
            }
            return pk;
        }

        public List<CForeignKey> DameLLavesForaneas(string tablaHija)
        {
            //regresa las llaves foraneas que tiene la tabla
            //primero me traigo un listado de todas la llaves foraneas que tiene asociada la tabla
            List<CForeignKey> fks = new List<CForeignKey>();
            string s = "select CONSTRAINT_NAME as FK,TABLE_NAME as TablaHija,REFERENCED_TABLE_NAME as TablaPadre, UPDATE_RULE,DELETE_RULE from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS where CONSTRAINT_SCHEMA='" + GetDataBseName()+"' and TABLE_NAME='"+ tablaHija + "'";
            IDataReader dr = EjecutaQuery(s);
            if (dr == null)
                return fks;
            while (dr.Read())
            {
                CForeignKey fk = new CForeignKey();
                fk.Nombre = dr["FK"].ToString();
                fk.TablaHija = dr["TablaHija"].ToString();
                fk.TablaPadre = dr["TablaPadre"].ToString();
                switch (dr["DELETE_RULE"].ToString())
                {
                    case "NO ACTION":
                        fk.AccionBorrar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case "CASCADE":
                        fk.AccionBorrar = EnumAccionReferencial.CASCADE;
                        break;
                    case "SET NULL":
                        fk.AccionBorrar = EnumAccionReferencial.SET_NULL;
                        break;
                    case "SET DEFAULT":
                        fk.AccionBorrar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                    case "RESTRICT":
                        fk.AccionBorrar = EnumAccionReferencial.RESTRICT;
                        break;
                }
                switch (dr["UPDATE_RULE"].ToString())
                {
                    case "NO ACTION":
                        fk.AccionActualizar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case "CASCADE":
                        fk.AccionActualizar = EnumAccionReferencial.CASCADE;
                        break;
                    case "SET NULL":
                        fk.AccionActualizar = EnumAccionReferencial.SET_NULL;
                        break;
                    case "SET DEFAULT":
                        fk.AccionActualizar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                    case "RESTRICT":
                        fk.AccionActualizar = EnumAccionReferencial.RESTRICT;
                        break;
                }
                fks.Add(fk);
            }
            dr.Close();
            //ahora recoorro todas la llaves foraneas encontradas y busco sus componentes
            foreach (CForeignKey fk in fks)
            {
                //me traigo sus reglas            
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
        private string GeneraQueryCamposFk(string nombre)
        {
            string s = "";
            s += "select   \n";
            s += "	m.COLUMN_NAME as columnaMaestra,  \n";
            s += "	m.DATA_TYPE as TipoDatoMaestro,  \n";
            s += "	case isnull(m.CHARACTER_MAXIMUM_LENGTH) when 1 then '0' else m.CHARACTER_MAXIMUM_LENGTH end as LongitudPadre,  \n";
            s += "	m.COLUMN_NAME as columnahija,  \n";
            s += "	m.DATA_TYPE as TipoDatoHijo,  \n";
            s += "	case isnull(m.CHARACTER_MAXIMUM_LENGTH) when 1 then '0' else m.CHARACTER_MAXIMUM_LENGTH end as LongitudHijo  \n";
            s += "from   \n";
            s += "	INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS f,  \n";
            s += "	INFORMATION_SCHEMA.KEY_COLUMN_USAGE c,  \n";
            s += "	INFORMATION_SCHEMA.COLUMNS m,  \n";
            s += "	INFORMATION_SCHEMA.COLUMNS h  \n";
            s += "where  \n";
            s += "	f.CONSTRAINT_SCHEMA='"+GetDataBseName()+"'  \n";
            s += "	and f.CONSTRAINT_NAME='"+nombre+"'  \n";
            s += "	and c.CONSTRAINT_SCHEMA=f.CONSTRAINT_SCHEMA  \n";
            s += "	and c.CONSTRAINT_NAME=f.CONSTRAINT_NAME  \n";
            s += "	and m.TABLE_SCHEMA=c.CONSTRAINT_SCHEMA  \n";
            s += "	and m.TABLE_NAME=c.REFERENCED_TABLE_NAME  \n";
            s += "	and m.column_name=c.REFERENCED_COLUMN_NAME  \n";
            s += "	and h.TABLE_SCHEMA=c.CONSTRAINT_SCHEMA  \n";
            s += "	and h.TABLE_NAME=c.TABLE_NAME  \n";
            s += "	and h.column_name=c.column_name  \n";
            return s;

        }

        public List<CForeignKey> DameLLavesForaneasHijas(string tablaPadre)
        {
            //regresa las llaves foraneas que tiene la tabla
            //primero me traigo un listado de todas la llaves foraneas que tiene asociada la tabla
            List<CForeignKey> fks = new List<CForeignKey>();
            string s = "select CONSTRAINT_NAME as FK,TABLE_NAME as TablaHija,REFERENCED_TABLE_NAME as TablaPadre, UPDATE_RULE,DELETE_RULE from 	INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS where CONSTRAINT_SCHEMA='" + GetDataBseName() + "' and REFERENCED_TABLE_NAME='" + tablaPadre + "'";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CForeignKey fk = new CForeignKey();
                fk.Nombre = dr["FK"].ToString();
                fk.TablaHija = dr["TablaHija"].ToString();
                fk.TablaPadre = dr["TablaPadre"].ToString();
                switch (dr["DELETE_RULE"].ToString())
                {
                    case "NO ACTION":
                        fk.AccionBorrar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case "CASCADE":
                        fk.AccionBorrar = EnumAccionReferencial.CASCADE;
                        break;
                    case "SET NULL":
                        fk.AccionBorrar = EnumAccionReferencial.SET_NULL;
                        break;
                    case "SET DEFAULT":
                        fk.AccionBorrar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                    case "RESTRICT":
                        fk.AccionBorrar = EnumAccionReferencial.RESTRICT;
                        break;
                }
                switch (dr["UPDATE_RULE"].ToString())
                {
                    case "NO ACTION":
                        fk.AccionActualizar = EnumAccionReferencial.NO_ACTION;
                        break;
                    case "CASCADE":
                        fk.AccionActualizar = EnumAccionReferencial.CASCADE;
                        break;
                    case "SET NULL":
                        fk.AccionActualizar = EnumAccionReferencial.SET_NULL;
                        break;
                    case "SET DEFAULT":
                        fk.AccionActualizar = EnumAccionReferencial.SET_DEFAULT;
                        break;
                    case "RESTRICT":
                        fk.AccionActualizar = EnumAccionReferencial.RESTRICT;
                        break;
                }
                fks.Add(fk);
            }
            dr.Close();
            //ahora recoorro todas la llaves foraneas encontradas y busco sus componentes
            foreach (CForeignKey fk in fks)
            {
                //me traigo sus reglas

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

        public List<EnumMomentTriger> DameMomentosTriggerSoportados()
        {
            List<EnumMomentTriger> l = new List<EnumMomentTriger>();
            l.Add(EnumMomentTriger.AFTER);
            l.Add(EnumMomentTriger.BEFORE);
            return l;
        }

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

        public List<CParametro> DameParametrosFuncction(string funcion)
        {
            List<CParametro> l = new List<CParametro>();
            string s = "select PARAMETER_NAME as name,DATA_TYPE as TipoDato, NUMERIC_PRECISION as length from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_SCHEMA='"+GetDataBseName()+"' and SPECIFIC_NAME='"+ funcion + "' and ROUTINE_TYPE='FUNCTION' and PARAMETER_NAME<>'' order by ORDINAL_POSITION";
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
            string s = "select PARAMETER_NAME as name,DATA_TYPE as TipoDato, NUMERIC_PRECISION as length from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_SCHEMA='" + GetDataBseName() + "' and SPECIFIC_NAME='" + sp + "' and ROUTINE_TYPE='PROCEDURE' and PARAMETER_NAME<>'' order by ORDINAL_POSITION";
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

        public CTabla DamePrimerResultadoProcedimientoAlmacenado(string nombre)
        {
            CTabla tabla = new CTabla();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = new MySqlCommand();
            dataAdapter.SelectCommand.CommandText = nombre;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Connection = new MySqlConnection(FConnectionString);
            dataAdapter.SelectCommand.Connection.Open();
            MySqlCommandBuilder.DeriveParameters(dataAdapter.SelectCommand);
            DataSet dataSet = new DataSet("aaa");
            dataAdapter.GetFillParameters();
            dataAdapter.FillSchema(dataSet, SchemaType.Source,"aaa");
            foreach(DataTable table in dataSet.Tables)
            {
                foreach(DataColumn column in table.Columns)
                {
                    CCampo campo = new CCampo()
                    {
                        Nombre = column.ColumnName,
                        TipoDato =  GetTipoDato(column.DataType.ToString()),
                        Longitud =column.MaxLength
                    };
                    tabla.AddCampo(campo);
                }
                break;
            }
            dataAdapter.SelectCommand.Connection.Close();
            return tabla;
        }

        public List<CTabla> DameResultadoProcedimientoAlmacenado(string nombre)
        {
            List<CTabla> l = new List<CTabla>();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = new MySqlCommand();
            dataAdapter.SelectCommand.CommandText = nombre;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Connection = new MySqlConnection(FConnectionString);
            dataAdapter.SelectCommand.Connection.Open();
            MySqlCommandBuilder.DeriveParameters(dataAdapter.SelectCommand);
            DataSet dataSet = new DataSet("aaa");
            dataAdapter.GetFillParameters();
            dataAdapter.FillSchema(dataSet, SchemaType.Source, "aaa");
            foreach (DataTable table in dataSet.Tables)
            {
                CTabla tabla = new CTabla();
                foreach (DataColumn column in table.Columns)
                {
                    CCampo campo = new CCampo()
                    {
                        Nombre = column.ColumnName,
                        TipoDato = GetTipoDato(column.DataType.ToString()),
                        Longitud = column.MaxLength
                    };
                    tabla.AddCampo(campo);
                }
                l.Add(tabla);
            }
            dataAdapter.SelectCommand.Connection.Close();
            return l;
        }

        public CTabla DameTabla(string nombre)
        {
            string s = "";
            CTabla tabla = new CTabla();
            //Busco si existe la tabla
            s = "select TABLE_NAME as name from INFORMATION_SCHEMA.TABLES  where TABLE_SCHEMA ='"+GetDataBseName()+ "' and (TABLE_TYPE='TABLE' or TABLE_TYPE='BASE TABLE' ) and TABLE_NAME='" + nombre+"'";
            IDataReader dr = EjecutaQuery(s);
            if (dr == null)
                return null;
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
                if (dr["Identidad"] != null)
                {
                    if (int.Parse(dr["Identidad"].ToString()) == 1)
                    {
                        //si es identidad, por lo que agrego el campo
                        CIdentidad identidad = new CIdentidad();
                        identidad.Campo = campo;
                        identidad.ValorInicial = int.Parse(dr["seed_value"].ToString());
                        identidad.Incremento = int.Parse(dr["increment_value"].ToString());
                        tabla.Identidad = identidad;
                    }
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
        private List<Cindex> CargaIndices(string tabla)
        {
            List<Cindex> l1 = new List<Cindex>();
            //genero el query para tyraerme los indices asociados a la tabla
            string query = "select distinct index_name as name from INFORMATION_SCHEMA.STATISTICS where table_schema='"+GetDataBseName()+"' and table_name='"+tabla+"'";
            IDataReader dr = EjecutaQuery(query);
            if (dr == null)
                return l1;
            while (dr.Read())
            {
                Cindex obj = new Cindex();
                obj.Nombre = dr["name"].ToString();
                //me traigo los campos que perteneces
                obj.Campos = DameCamposIndex(obj.Nombre, tabla);
                l1.Add(obj);
            }
            dr.Close();
            return l1;
        }
        private List<CCampoIndex> DameCamposIndex(string indice, string tabla)
        {
            string query = "";
            query += " \n";
            //------------------------------
            query += " select \n";
            query += " 	c.column_name as COLUMNA,\n";
            query += " 	c.data_type as TIPO, \n";
            query += " 	c.CHARACTER_MAXIMUM_LENGTH as LONGITUD, \n";
            query += " 	'false' as descendente  \n";
            query += " from \n";
            query += " 	INFORMATION_SCHEMA.STATISTICS i, \n";
            query += " 	INFORMATION_SCHEMA.COLUMNS c  \n";
            query += "  where \n";
            query += " 	i.table_schema='"+GetDataBseName()+"'  \n";
            query += " 	and i.index_name='" + indice + "'	 \n";
            query += " 	and i.table_name='" + tabla + "'	 \n";
            query += " 	and c.table_schema=i.table_schema	 \n";
            query += " 	and c.table_name=i.table_name	\n";
            query += " 	and c.column_name=i.column_name\n";
            query += " order by \n";
            query += "     i.SEQ_IN_INDEX \n";
            //------------------------------
            List<CCampoIndex> l = new List<CCampoIndex>();
            IDataReader dr = null;
            try
            {
                dr = EjecutaQuery(query);
                if (dr == null)
                    return l;
                while (dr.Read())
                {
                    CCampoIndex obj = new CCampoIndex();
                    obj.Nombre = dr["COLUMNA"].ToString();
                    obj.TipoDato = GetTipoDato(dr["TIPO"].ToString());
                    if (dr["Longitud"].ToString().Trim() != "")
                        obj.Longitud = int.Parse(dr["Longitud"].ToString());
                    else
                        obj.Longitud = 0;
                    if (bool.Parse(dr["descendente"].ToString()))
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
            }
            catch (Exception ex)
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }

        public List<CUnique> DameUnicos(string tabla)
        {
            CUnique obj = null;
            List<CUnique> l = new List<CUnique>();
            string cadena = "select CONSTRAINT_NAME as nombre from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE='UNIQUE' and CONSTRAINT_SCHEMA='" + GetDataBseName() + "' and table_name ='"+tabla+"' ";
            IDataReader dr;
            dr = EjecutaQuery(cadena);
            if(dr==null)
                return l;
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
                IDataReader dr2 = EjecutaQuery("select c.column_name as campo, c.data_type as TipoDato, c.CHARACTER_MAXIMUM_LENGTH as Longitud from INFORMATION_SCHEMA.KEY_COLUMN_USAGE o,	INFORMATION_SCHEMA.COLUMNS c where o.table_schema='"+GetDataBseName()+"' and o.constraint_name='"+un.Nombre+"' and c.table_schema=o.table_schema and c.table_name=o.table_name	and c.column_name=o.column_name");
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

        private List<CCheck> DameChecks(string taba)
        {
            List<CCheck> l = new List<CCheck>();
          /*  string s = "select 	ch.name as Nombre ,c.text as Codigo from sysobjects o ,sysobjects ch ,syscomments c where o.name='" + taba + "' and o.xtype='U' and ch.parent_obj=o.id and ch.xtype='C' and c.id=ch.id ";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CCheck obj = new CCheck();
                obj.Nombre = dr["Nombre"].ToString();
                obj.Regla = dr["Codigo"].ToString();
                l.Add(obj);
            }
            dr.Close();*/
            return l;
        }

        private IDataReader EsIdentidad(string tabla, string campo)
        {
            string s = "select case extra when 'auto_increment' then 1 else 0 end as Identidad ,1 as seed_value ,1 as increment_value from INFORMATION_SCHEMA.COLUMNS  where table_schema='"+GetDataBseName()+"' and table_name='"+tabla+"' and column_name='"+campo+"'";
            return EjecutaQuery(s);
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

        public List<CTipoDato> DameTiposDato()
        {
            if (FTiposDato == null)
                GeneraListaTiposDato();
            return FTiposDato;
        }
        private void GeneraListaTiposDato()
        {
            FTiposDato = new List<CTipoDato>();
            FTiposDato.Add(new CTipoDato("geography", TIPO_LONGITUD.NOREQUERIDO));
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
            FTiposDato.Add(new CTipoDato("mediumblob", TIPO_LONGITUD.OBLIGATORIO));
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

        public List<CTrigger> DameTrrigersTabla(string tabla)
        {
            List<CTrigger> l = new List<CTrigger>();
            IDataReader dr = EjecutaQuery(QueryDameTrrigersTabla(tabla));
            //recorro todos los registros
            while (dr.Read())//&& dr.IsClosed==false)
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
            foreach (CTrigger obj in l)
            {
                obj.CodigoFuente = DameCodigoTrigger(obj.Nombre);
            }
            return l;
        }
        public EnumMomentTriger DameMomento(string s)
        {
            EnumMomentTriger momento = EnumMomentTriger.AFTER;
            if (s.ToUpper().Trim() == "AFTER")
                momento = EnumMomentTriger.AFTER;
            if (s.ToUpper().Trim() == "BEFORE")
                momento = EnumMomentTriger.BEFORE;
            return momento;
        }

        private string QueryDameTrrigersTabla(string tabla)
        {
            //genra el query para hacer la consulta
            string s = "";
            s += "select \n";
            s += "	TRIGGER_NAME as 'Trigger' \n";
            s += "	,ACTION_TIMING as Momento \n";
            s += "	,case EVENT_MANIPULATION when 'INSERT' then 1 else 0 end as 'Insert' \n";
            s += "	,case EVENT_MANIPULATION when 'UPDATE' then 1 else 0 end as 'Update' \n";
            s += "	,case EVENT_MANIPULATION when 'DELETE' then 1 else 0 end as 'Delete' \n";
            s += "from  \n";
            s += "	INFORMATION_SCHEMA.TRIGGERS \n";
            s += "where \n";
            s += "	TRIGGER_SCHEMA='"+GetDataBseName()+"' \n";
            s += "	and EVENT_OBJECT_TABLE='"+tabla+"' \n";
            return s;
        }

        public CTabla DameTypeTable(string nombre)
        {
            return DameTabla(nombre);
        }

        public CVista DameVista(string nombre)
        {
            CVista vista = null;// new CVista();
            string query = "select table_name as name, 'V' as xtype from INFORMATION_SCHEMA.VIEWS where table_schema='"+GetDataBseName()+"' and table_name='"+nombre+"'";
            IDataReader dr = EjecutaQuery(query);
            if (dr == null)
                return null;
            if (dr.Read())
            {
                vista = new CVista();
                vista.Nombre = dr["name"].ToString();
                //me traigo los campos de la vista
                List<CCampoBase> campos = DameCamposVista(nombre);
                foreach (CCampoBase obj in campos)
                {
                    vista.AddCampo(obj);
                }
                //me traigo el codigo fuente de la vista
                vista.CodigoFuente = DameCodigoVista(nombre);
            }
            dr.Close();
            return vista;
        }

        public void Desconectar()
        {
        }
        //private CSQLComandQuery MyDataReader;
        public IDataReader EjecutaQuery(string cadena)
        {
            if (cadena == "")
                return null;
            CSQLComandQuery MyDataReader=null;
            if (MyDataReader == null)
            {
                MyDataReader = new CSQLComandQuery();
                //asigno el motor de base de datos
                MyDataReader.Motor = EnumMotoresDB.MYSQL;
                //le paso la cadena de conecion
                MyDataReader.ConnectionString = FConnectionString;
            }
            if (MyDataReader.IsClosed == false)
                MyDataReader.Close();
            //le paso el query
            MyDataReader.QueryString = cadena;
            MyDataReader.QueryString = cadena;
            MyDataReader.QueryString = cadena;
            MyDataReader.QueryString = cadena;
            //y lo abro
            try
            {
                MyDataReader.Open(true);
            }
            catch (System.Exception ex)
            {
                //regresa un dr null
                if (MessageErrorEvent != null)
                    MessageErrorEvent(this, ex.Message);
                return null;
            }
            return MyDataReader;
        }

        public void EliminaForeignKey(CForeignKey fk)
        {
            string s = "alter table " + fk.TablaHija + " drop constraint " + fk.Nombre;
            EjecutaQuery(s);
        }

        public void EliminaIndex(string tabla, string indice)
        {
            string s = "drop index " + tabla + "." + indice + "";
            EjecutaQuery(s);
        }

        public void EliminaPk(string tabla)
        {
            CPrimaryKey pk = DameLLavePrimaria(tabla);
            string s = "alter table " + tabla + " drop constraint " + pk.Nombre + "";
            EjecutaQuery(s);
        }
        private MySqlCommand MyComando;
        public DataSet Execute(string comando)
        {
            try
            {
                DataSet ds = new DataSet();
                if (MyComando == null)
                {
                    MyComando = new MySqlCommand(comando);
                    MyComando.Connection = new MySqlConnection(FConnectionString);
                }
                MyComando.CommandTimeout = 50000;
                MyComando.CommandText = comando;
                if (MyComando.Connection.State == ConnectionState.Open)
                    MyComando.Connection.Close();
                MyComando.Connection.Open();
                IDataReader dr = MyComando.ExecuteReader();
                ds.Load(dr, LoadOption.OverwriteChanges, new string[] { "Tabla 1", "Tabla 2", "Tabla 3", "Tabla 4", "Tabla 5", "Tabla 6", "Tabla 7", "Tabla 8", "Tabla 9", "Tabla 10", "Tabla 11", "Tabla 12", "Tabla 13", "Tabla 14", "Tabla 15" });
//                MyComando.Connection.Close();
  //              MyComando.Connection.Dispose();
    //            MyComando.Dispose();
                //ahora elimino las tablas vacias
                int n = ds.Tables.Count;
                for (int i = n - 1; i >= 0; i--)
                {
                    DataTable dt = ds.Tables[i];
                    if (dt.Columns.Count == 0)
                    {
                        ds.Tables.Remove(dt);
                    }
                }
                //veo si hay tablas 
                if (ds.Tables.Count == 0)
                {
                    //no hay tablas, por lo que me traigo el numero de registros encontrados
                    string s = "";
                    if (dr.RecordsAffected == 1)
                    {
                        s = "Un registro afectado";
                    }
                    else
                    {
                        s = dr.RecordsAffected.ToString() + " Registros afectados";
                    }
                    ExceptionDB ex2 = new ExceptionDB();
                    ex2.Add(new CError(0, s));
                    dr.Close();
                    throw ex2;
                }
                return ds;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                int i, n;
                ExceptionDB ex2 = new ExceptionDB();
                n = ex.Errors.Count;
                foreach (MySqlError err in ex.Errors)
                {
                    ex2.Add(new CError(ObtenLineaError(err.Message), err.Message));
                }
                throw ex2;
            }
            catch(ExceptionDB ex)
            {
                throw ex;
            }
            catch(System.Exception ex)
            {
                int i, n;
                ExceptionDB ex2 = new ExceptionDB();
//                n = ex.Errors.Count;
  //              foreach (MySqlError err in ex.Errors)
//                {
                    ex2.Add(new CError(ObtenLineaError(ex.Message), ex.Message));
  //              }
                throw ex2;

            }

        }
        private int ObtenLineaError(string msg)
        {
            int pos;
            pos = msg.ToLower().IndexOf("at line");
            if (pos == -1)
                return 0;
            string s = msg.Substring(pos);
            string[] ops;
            ops = s.Split();
            pos = 0;
            foreach (string s2 in ops)
            {
                try
                {
                    pos = int.Parse(s2);
                    return pos;
                }
                catch (System.Exception)
                {
                    pos = 0;
                }
            }
            return pos;
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

        public string GetDataBseName()
        {
            //regrea el nombre de la base de datos a la que estoy conectado
            MySqlConnection Conexion = new MySqlConnection(FConnectionString);
            try
            {
                return Conexion.Database;
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        public string GetExcecute_Function(string nombre)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder(FConnectionString);
            string cadena = nombre + "(";
            List<MotorDB.CParametro> l = DameParametrosFuncction(nombre);
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

        public string GetExcecute_StoreProcedure(string nombre)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder(FConnectionString);
            string cadena = "EXECUTE " + nombre + "(";
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
            //                cadena += "\n IF @@ERROR <> 0";
            //              cadena += "\n BEGIN";
            //            cadena += "\n\tRAISERROR('Error al llamar a: " + nombre + "', 18, 2) WITH SETERROR";
            //          cadena += "\n END\n";
            return cadena;
        }

        public EnumMotoresDB GetMotor()
        {
            return EnumMotoresDB.MYSQL;
        }

        public string GetNetProvider()
        {
            return "MySql.Data.MySqlClient";
        }

        public string GetStringError()
        {
            return MsgError;
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


        public void SetConnectionName(string nombre)
        {
            ConnectionName = nombre;
        }

        public void SetConnectionString(string connectionString)
        {
            FConnectionString = connectionString;
        }


        public DialogResult ShowDlgMultiConfig()
        {
            MotorDB.Motores.MySql.FormDlsMultiConfigMySql dlg = new MotorDB.Motores.MySql.FormDlsMultiConfigMySql();
            MySqlConnection Conexion = new MySqlConnection(FConnectionString);
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

        public void SuscribeErrorMessageEvent(MotorDBMessageEvent e)
        {
            MessageErrorEvent += e;
        }
        public DialogResult ShowDlgConfig()
        {
            FormDlgConfigMySql dlg = new FormDlgConfigMySql();
            MySql.Data.MySqlClient.MySqlConnection Conexion = new MySql.Data.MySqlClient.MySqlConnection(FConnectionString);
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
        public string GetConnectionName()
        {
            return ConnectionName;
        }
        public string GetConecctionString()
        {
            return FConnectionString;
        }
        /// <summary>
        /// genera el query para crear una nueva tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
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
                    if (campo.TipoDato.UsaLongitud == TIPO_LONGITUD.OPCIONAL && campo.Longitud > 0)
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
                            s += " AUTO_INCREMENT ";// (" + tabla.Identidad.ValorInicial + "," + tabla.Identidad.Incremento + ")";
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

    }
}
