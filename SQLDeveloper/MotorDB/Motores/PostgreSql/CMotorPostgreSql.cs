using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace MotorDB
{
    class CMotorPostgreSql : IMotorDB
    {
        static List<CTipoDato> FTiposDato;
        private event MotorDBMessageEvent MessageErrorEvent;
        private string MsgError;
        private List<string> Nombres;
        private string ConnectionName="";
        private string FConnectionString="";
        private List<CObjeto> Buffer;
        private System.DateTime BufferTimer;
        public void AlterTable_AddCheck(string tabla, CCheck check)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_AddColumn(string tabla, CCampo campo, CIdentidad identidad = null)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_AddUnique(string tabla, CUnique unique)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_AlterColumn(string tabla, CCampo actual, CCampo nuevo)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_DropChechk(string tabla, string check)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_DropColumn(string tabla, string campo)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_DropDefault(string tabla, string defaultName)
        {
            throw new NotImplementedException();
        }

        public void AlterTable_DropUnique(string tabla, string unique)
        {
            throw new NotImplementedException();
        }

        public List<CObjeto> BuscaEnTablas(string campo)
        {
            throw new NotImplementedException();
        }

        public List<CObjeto> BuscaEnVistas(string campo)
        {
            throw new NotImplementedException();
        }

        public List<CObjeto> Buscar(string nombre, EnumTipoObjeto tipo = EnumTipoObjeto.NONE)
        {
            if (tipo == EnumTipoObjeto.NONE || tipo == EnumTipoObjeto.TABLE)
            {
                return BuscaEnBuffer(nombre,tipo);
            }
            //regresa el listado de objetos que coincidan con el nombre y tipo seleccionado
            List<CObjeto> l = new List<CObjeto>();
            string query = "";
            switch (tipo)
            {
                case EnumTipoObjeto.CAMPO:
                    query = "select distinct  o.relname as NAME, o.relkind as xtype from pg_attribute c ,pg_class o where c.attname like '" + nombre.Trim() + "%' and c.attrelid=o.oid order by o.relname";
                    break;
                case EnumTipoObjeto.CHECK:
                    query = "select 	CONSTRAINT_NAME as name	,CONSTRAINT_TYPE as xtype from 	INFORMATION_SCHEMA.TABLE_CONSTRAINTS c where 	c.CONSTRAINT_TYPE='CHECK' 	and CONSTRAINT_NAME like '%" + nombre.Trim() + "%' 	and TABLE_SCHEMA='" + GetDataBseName() + "'";
                    break;
                case EnumTipoObjeto.FOREIGNKEY:
                    query = "select 	CONSTRAINT_NAME as name, 'F' as xtype from 	INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS  where CONSTRAINT_SCHEMA ='" + GetDataBseName() + "' and CONSTRAINT_NAME like '%" + nombre.Trim() + "%'";
                    break;
                case EnumTipoObjeto.FUNCION:
                    query = "select proname as NAME,'FUNCTION' as xtype from pg_proc where proname like '" + nombre.Trim() + "%' "; ;
                    break;
                case EnumTipoObjeto.IDENTITY:
                    query = "select column_name as name, 'identity' as xtype from INFORMATION_SCHEMA.COLUMNS where table_schema='" + GetDataBseName() + "' and COLUMN_NAME like'%" + nombre.Trim() + "%' and extra='auto_increment'";
                    break;
                case EnumTipoObjeto.NONE:
                    query = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + GetDataBseName() + "' and ROUTINE_NAME like '" + nombre.Trim() + "%'\n";
                    query = query + "union all\n";
                    query = query + "select table_NAME as NAME,TABLE_TYPE as XTYPE from information_schema.tables where table_SCHEMA='" + GetDataBseName() + "' and table_NAME like '" + nombre.Trim() + "%'\n";
                    query = query + "order by name";
                    break;
                case EnumTipoObjeto.PRIMARYKEY:
                    query = "select distinct CONSTRAINT_NAME as name, 'PK' as xtype from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_SCHEMA='" + GetDataBseName() + "' and CONSTRAINT_NAME like '%" + nombre.Trim() + "%' and CONSTRAINT_TYPE='PRIMARY KEY'";
                    break;
//                case EnumTipoObjeto.PROCEDURE:
  //                  query = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + GetDataBseName() + "' and ROUTINE_NAME like '" + nombre.Trim() + "%' and ROUTINE_TYPE='PROCEDURE'";
    //                break;
                case EnumTipoObjeto.TABLE:
                    query = "select table_name as NAME,table_type as XTYPE from information_schema.tables where table_type=\'BASE TABLE\' and table_name like \'" + nombre.Trim() + "%\' and table_schema=\'" + GetDataBseName() + "\';";
                    break;
                //                case EnumTipoObjeto.TIPEDATA:
                //                  query = "select distinct	name , 'TIPEDATA' as xtype from systypes  where name like'%" + nombre + "%' ";
                //                break;
                case EnumTipoObjeto.TRIGER:
                    query = "select tgname as name,'TR' as xtype from pg_trigger where tgname like '"+ nombre.Trim() + "%'";
                    break;
                case EnumTipoObjeto.UNIQUE:
                    query = "select distinct CONSTRAINT_NAME as name, 'UQ' as xtype from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_SCHEMA='" + GetDataBseName() + "' and CONSTRAINT_NAME like '%" + nombre.Trim() + "%' and CONSTRAINT_TYPE='UNIQUE'";
                    break;
                case EnumTipoObjeto.VIEW:
                    query = "SELECT relname as NAME, relkind as xtype FROM pg_class a where relkind in ('v') and relname like \'" + nombre.Trim() + "%\'";
                    break;
                case EnumTipoObjeto.INDEX:
                    query = "select index_name as name, 'INDEX' as xtype from INFORMATION_SCHEMA.STATISTICS where index_schema='" + GetDataBseName() + "' and index_name like '%" + nombre.Trim() + "%'";
                    break;
                case EnumTipoObjeto.CODE:
                    query = "select tgname as name,'TR' as xtype from pg_trigger where pg_get_triggerdef(oid) like '%" + nombre.Trim() + "%'\n";
                    query += "union\n";
                    query += "select proname as name, 'FN' as xtype  from pg_proc where pg_get_functiondef(oid) like '%" + nombre.Trim() + "%' and prokind='f'\n";
                    query += "union\n";
                    query += "select viewname as name, 'V' as xtype  from pg_views where definition like '%" + nombre.Trim() + "%'\n";
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
                case "R":
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
            NpgsqlConnection Conexion = new NpgsqlConnection(FConnectionString);
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
        private List<CObjeto> BuscaEnBuffer(string nombre, EnumTipoObjeto tipo)
        {
            if (BufferTimer == null)
                BufferTimer = System.DateTime.Now;
            List<CObjeto> l = new List<CObjeto>();
            if (Buffer == null || BufferTimer.AddMinutes(10) > System.DateTime.Now)
            {
                if (Buffer == null)
                    Buffer = new List<CObjeto>();
                Buffer.Clear();
                string query = "";
                IDataReader dr = null;
                //cargo la informacion desde la base
                query = "select proname as NAME,'FUNCTION' as xtype from pg_proc \n";
                dr = EjecutaQuery(query);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        CObjeto obj = new CObjeto();
                        obj.Nombre = dr["name"].ToString();
                        obj.Tipo = DameXType(dr["xtype"].ToString());
                        Buffer.Add(obj);
                    }
                }
                query = "SELECT relname as NAME, relkind as xtype FROM pg_class a, pg_namespace p  where relhasindex=true and relkind in ('r','v') and relnamespace=p.oid and p.nspname='public'\n";
                dr = EjecutaQuery(query);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        CObjeto obj = new CObjeto();
                        obj.Nombre = dr["name"].ToString();
                        obj.Tipo = DameXType(dr["xtype"].ToString());
                        Buffer.Add(obj);
                    }
                }
            }
            foreach (CObjeto obj in Buffer.OrderBy(x=> x.Nombre))
            {
                if (obj.Nombre.ToUpper().Trim().Contains(nombre.ToUpper().Trim()))
                {
                    if (tipo == EnumTipoObjeto.NONE)
                    {
                        l.Add(obj);
                    }
                    else
                    {
                        if (obj.Tipo == tipo)
                        {
                            l.Add(obj);
                        }
                    }
                }
            }
            return l;
        }

        public void CreaForeignKey(CForeignKey fk)
        {
            throw new NotImplementedException();
        }

        public void CreaIndex(Cindex index, string tabla)
        {
            throw new NotImplementedException();
        }

        public void CreaPrimaryKey(CPrimaryKey pk, string tabla)
        {
            throw new NotImplementedException();
        }

        public string CreaScript(List<CObjeto> lista)
        {
            throw new NotImplementedException();
        }

        public void CreaTabla(CTabla tabla)
        {
            throw new NotImplementedException();
        }

        public List<EnumAccionReferencial> DameAccionesReferencialesActualizadoValidos()
        {
            throw new NotImplementedException();
        }

        public List<EnumAccionReferencial> DameAccionesReferencialesBorradoValidos()
        {
            throw new NotImplementedException();
        }


        public List<CCampo> DameCamposTypeTabla(string tabla)
        {
            throw new NotImplementedException();
        }

        public List<CCampoBase> DameCamposVista(string vista)
        {
            List<CCampoBase> l = new List<CCampoBase>();
            String s = "";
            s += "select\n";
            s += "        c.attname as Nombre \n";
            s += "        ,t.typname as TipoDato\n";
            s += "        ,c.atttypmod-4 as Longitud\n";
            s += "from\n";
            s += "        pg_class o\n";
            s += "        ,pg_attribute c\n";
            s += "        ,pg_type t\n";
            s += "where\n";
            s += "        o.relname ='"+vista+"' \n";
            s += "        and o.relkind='v'\n";
            s += "        and c.attrelid=o.oid\n";
            s += "        and c.attnum>0\n";
            s += "        and t.oid=c.atttypid\n";
            s += "order by \n";
            s += "        c.attnum\n";

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


        public string DameCodigoStoreProcedure(string nombre)
        {
            throw new NotImplementedException();
        }

        public string DameCodigoTabla(string nombre)
        {
            throw new NotImplementedException();
        }

        public string DameCodigoTrigger(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "select pg_get_triggerdef(oid) as text from pg_trigger where tgname = '" + nombre+"'";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            dr.Close();
            return s;

        }

        public string DameCodigoTypeTable(string nombre)
        {
            throw new NotImplementedException();
        }

        public string DameCodigoVista(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "select pg_get_viewdef('"+nombre+ "') as text";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "CREATE VIEW "+nombre+" AS\n";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            dr.Close();
            //Conexion.Close();
            return s;
        }

        public List<CObjeto> DameDependenciasDe(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<CObjeto> DameDependientesDe(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<EnumEventTriger> DameEventosTriggerSoportados()
        {
            throw new NotImplementedException();
        }

        public DateTime DameFechaCreacion(string nombreObjeto)
        {
            throw new NotImplementedException();
        }

        public DateTime DameFechaModificacion(string nombreObjeto)
        {
            throw new NotImplementedException();
        }

        public CPrimaryKey DameLLavePrimaria(string tabla)
        {
            //regresa la llave primaria de la tabla
            List<CCampoBase> Campos = new List<CCampoBase>();
            CPrimaryKey pk = new CPrimaryKey();
            string s = "";
            s = s + "select \n";
            s = s + "        ct.conname as nombre\n";
            s = s + "        ,c.attname as Campo \n";
            s = s + "        ,t.typname as TipoDato\n";
            s = s + "        ,atttypmod-4 as Longitud\n";
            s = s + "from \n";
            s = s + "        pg_class o1 \n";
            s = s + "        ,pg_constraint ct\n";
            s = s + "        ,pg_attribute c \n";
            s = s + "        ,pg_type t \n";
            s = s + "where \n";
            s = s + "        o1.relname ='"+tabla+"' \n";
            s = s + "        and ct.conrelid=o1.oid\n";
            s = s + "        and ct.contype='p'\n";
            s = s + "        and c.attrelid=ct.conindid \n";
            s = s + "        and c.attnum>0\n";
            s = s + "        and t.oid=c.atttypid\n";
            s = s + "order by \n";
            s = s + "        c.attnum\n";
            IDataReader dr = EjecutaQuery(s);
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
            dr.Close();
            if (pk.Campos.Count == 0)
            {
                return null;
            }
            return pk;
        }

        public List<CForeignKey> DameLLavesForaneas(string tablaHija)
        {
            //regresa la llave primaria de la tabla
            //regresa las llaves foraneas que tiene la tabla
            //primero me traigo un listado de todas la llaves foraneas que tiene asociada la tabla
            List<CForeignKey> fks = new List<CForeignKey>();
            string s = "";
            s = s + "select \n";
            s = s + "        ct.conname as fk\n";
            s = s + "        ,o1.relname as TablaHija\n";
            s = s + "        ,o2.relname as TablaPadre\n";
            s = s + "        ,case ct.confupdtype when 'a' then 0 when 'c' then 1 when 'n' then 2 when 'd' then 3 when 'r' then 4 end as AccionActualizar\n";
            s = s + "        ,case ct.confdeltype when 'a' then 0 when 'c' then 1 when 'n' then 2 when 'd' then 3 when 'r' then 4 end as AccionBorrar\n";
            s = s + "from \n";
            s = s + "        pg_class o1 \n";
            s = s + "        ,pg_constraint ct\n";
            s = s + "        ,pg_class o2\n";
            s = s + "where \n";
            s = s + "        o1.relname ='"+tablaHija+"' \n";
            s = s + "        and ct.conrelid=o1.oid\n";
            s = s + "        and ct.contype='f'\n";
            s = s + "        and o2.oid=ct.confrelid\n";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CForeignKey fk = new CForeignKey();
                fk.Nombre = dr["FK"].ToString();
                fk.TablaHija = dr["TablaHija"].ToString();
                fk.TablaPadre = dr["TablaPadre"].ToString();
                fk.AccionBorrar = DameReglaFK(int.Parse(dr["AccionBorrar"].ToString()));
                fk.AccionActualizar = DameReglaFK(int.Parse(dr["AccionActualizar"].ToString()));
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
        private EnumAccionReferencial DameReglaFK(int typo)
        {
            EnumAccionReferencial Accion = EnumAccionReferencial.NO_ACTION;
            switch (typo)
            {
                case 0:
                    Accion = EnumAccionReferencial.NO_ACTION;
                    break;
                case 1:
                    Accion = EnumAccionReferencial.CASCADE;
                    break;
                case 2:
                    Accion = EnumAccionReferencial.SET_NULL;
                    break;
                case 3:
                    Accion = EnumAccionReferencial.SET_DEFAULT;
                    break;
                case 4:
                    Accion = EnumAccionReferencial.RESTRICT;
                    break;
            }
            return Accion;
        }
        private string GeneraQueryCamposFk(string nombre)
        {
            string s = "";
            s += "select distinct\n";
            s += "        padre.relname as tabla_padre\n";
            s += "        ,cp.attname as columnaMaestra\n";
            s += "        ,tp.typname as TipoDatoMaestro\n";
            s += "        ,cp.atttypmod-4 as LongitudPadre\n";
            s += "\n";
            s += "        ,hija.relname as tabla_Hija\n";
            s += "        ,ch.attname as columnahija\n";
            s += "        ,th.typname as TipoDatoHijo\n";
            s += "        ,ch.atttypmod-4 as LongitudHijo\n";
            s += "from \n";
            s += "        pg_constraint ct\n";
            s += "        ,pg_class hija\n";
            s += "        ,pg_class padre\n";
            s += "        ,pg_attribute cp --campo padre\n";
            s += "        ,pg_attribute ch --campos hijo\n";
            s += "        ,pg_type th --tipos hijo\n";
            s += "        ,pg_type tp --tipos padre\n";
            s += "where \n";
            s += "        ct.conname='"+nombre+"'\n";
            s += "         and padre.oid=ct.confrelid\n";
            s += "         and cp.attrelid =padre.oid\n";
            s += "         and cp.attnum>0\n";
            s += "         and tp.oid=cp.atttypid\n";
            s += "\n";
            s += "         and hija.oid=ct.conrelid\n";
            s += "         and ch.attrelid =hija.oid\n";
            s += "         and ch.attnum>0\n";
            s += "         and th.oid=ch.atttypid\n";
            s += "         and cp.attnum ||'A'||ch.attnum in(select unnest(confkey) ||'A'|| unnest(conkey)  from pg_constraint where conname='"+nombre+"' )\n";
            s += "\n";
            return s;

        }


        public List<EnumMomentTriger> DameMomentosTriggerSoportados()
        {
            throw new NotImplementedException();
        }

        public List<string> DamePalabrasReservadas()
        {
            throw new NotImplementedException();
        }


        public List<CParametro> DameParametrosStoreProcedure(string sp)
        {
            throw new NotImplementedException();
        }

        public CTabla DamePrimerResultadoProcedimientoAlmacenado(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<CTabla> DameResultadoProcedimientoAlmacenado(string nombre)
        {
            throw new NotImplementedException();
        }


        public string DameTipoDatoNet(CTipoDato tipo)
        {
            throw new NotImplementedException();
        }


        public List<CTrigger> DameTrrigersTabla(string tabla)
        {
            throw new NotImplementedException();
        }

        public CTabla DameTypeTable(string nombre)
        {
            throw new NotImplementedException();
        }

        public CVista DameVista(string nombre)
        {
            CVista vista = null;// new CVista();
            string query = "select distinct	o.relname as name , o.relkind as xtype from pg_class o where o.relname ='" + nombre + "' and o.relkind='v'";
            IDataReader dr = EjecutaQuery(query);
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
            return vista;
        }

        public void Desconectar()
        {
        }


        public void EliminaForeignKey(CForeignKey fk)
        {
            throw new NotImplementedException();
        }

        public void EliminaIndex(string tabla, string indice)
        {
            throw new NotImplementedException();
        }

        public void EliminaPk(string nombre)
        {
            throw new NotImplementedException();
        }


        public string GetConeccionString(int pos)
        {
            throw new NotImplementedException();
        }

        public string GetConecctionString()
        {
            return FConnectionString;
        }

        public string GetConnectionName()
        {
            return ConnectionName;
        }

        public string GetConnectionName(int pos)
        {
            throw new NotImplementedException();
        }

        public int GetConnectionsCount()
        {
            throw new NotImplementedException();
        }

        public string GetDataBseName()
        {
            NpgsqlConnection Conexion = new NpgsqlConnection(FConnectionString);
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
            throw new NotImplementedException();
        }

        public string GetExcecute_StoreProcedure(string nombre)
        {
            throw new NotImplementedException();
        }

        public EnumMotoresDB GetMotor()
        {
            return EnumMotoresDB.POSTGRES;
        }

        public string GetNetProvider()
        {
            throw new NotImplementedException();
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
            // como no existe, lo agrego
            CTipoDato td = new CTipoDato(nombre, TIPO_LONGITUD.OPCIONAL);
            FTiposDato.Add(td);
            return td;
        }

        public bool isExecuting()
        {
            throw new NotImplementedException();
        }

        public string QueryCreaTabla(CTabla tabla)
        {
            throw new NotImplementedException();
        }

        public void SetConnectionName(string nombre)
        {
            ConnectionName = nombre;
        }

        public void SetConnectionString(string connectionString)
        {
            FConnectionString = connectionString;
        }

        public DialogResult ShowDlgConfig()
        {
            Motores.PostgreSql.FormDlgConfigPostgress dlg = new Motores.PostgreSql.FormDlgConfigPostgress();
            NpgsqlConnection Conexion = null;
            if (FConnectionString!="")
                Conexion = new NpgsqlConnection(FConnectionString);
            else
                Conexion = new NpgsqlConnection();
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

        public DialogResult ShowDlgMultiConfig()
        {
            throw new NotImplementedException();
        }

        public void SuscribeErrorMessageEvent(MotorDBMessageEvent e)
        {
            throw new NotImplementedException();
        }
        public CTabla DameTabla(string nombre)
        {
            string s = "";
            CTabla tabla = new CTabla();
            //Busco si existe la tabla
            s = "SELECT relname as NAME, relkind as xtype FROM pg_class a where relhasindex=true and relkind ='r' and relname='" + nombre + "'";
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
                if (dr.RecordsAffected > 0)
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
        public List<CCampo> DameCamposTabla(string tabla)
        {
            List<CCampo> l = new List<CCampo>();
            string s = "select \n";
            s = s + "        c.attname as Nombre, \n";
            s = s + "        t.typname as TipoDato,\n";
            s = s + "        atttypmod-4 as Longitud,\n";
            s = s + "        0 as CampoCalculado,\n";
            s = s + "        case attnotnull when true then 1 else 0 end as AceptaNulo,\n";
            s = s + "        case pg_get_expr(d.adbin,0) when '0' then '0' else '1' end as cdefault,\n";
            s = s + "        case COALESCE( pg_get_expr(d.adbin,0),'') when '' then '0' when null then '0' else pg_get_expr(d.adbin,0) end as Formula\n";
            s = s + "from \n";
            s = s + "        pg_class o \n";
            s = s + "        join pg_attribute c on c.attrelid=o.oid and c.attnum>0\n";
            s = s + "        join pg_type t on t.oid=c.atttypid\n";
            s = s + "        LEFT JOIN pg_attrdef d on  d.adrelid=o.oid and d.adnum=c.attnum\n";
            s = s + "where \n";
            s = s + "        o.relname ='"+tabla+"'\n";
            s = s + "order by \n";
            s = s + "        c.attnum\n";
            s = s + "\n";

            //System.Data.IDataReader dr;
            IDataReader dr;
            dr = EjecutaQuery(s);
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
            return "";
        }
        private List<CCheck> DameChecks(string taba)
        {
            List<CCheck> l = new List<CCheck>();
            string s = "";
            s = s + "select\n";
            s = s + "        c.conname as Nombre ,\n";
            s = s + "        pg_get_constraintdef(c.oid) as Codigo\n";
            s = s + "from\n";
            s = s + "        pg_constraint c,\n";
            s = s + "        pg_class o\n";
            s = s + "where\n";
            s = s + "        o.relname ='" + taba + "'\n";
            s = s + "        and o.oid=conrelid\n";
            s = s + "        and c.contype='c'\n";
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
            string cadena = "select c.conname as nombre from pg_constraint c, pg_class o where o.relname ='" + tabla + "' and o.oid=conrelid and c.contype='u' ";
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
                string s2 = "";
                s2 = s2 + "select         \n";
                s2 = s2 + "        a.attname as campo, \n";
                s2 = s2 + "        t.typname as TipoDato,\n";
                s2 = s2 + "        atttypmod-4 as Longitud\n";
                s2 = s2 + "from \n";
                s2 = s2 + "        pg_constraint c, \n";
                s2 = s2 + "        pg_class o ,\n";
                s2 = s2 + "        pg_attribute a,\n";
                s2 = s2 + "        pg_type t\n";
                s2 = s2 + "where \n";
                s2 = s2 + "        c.conname ='" + un.Nombre + "' \n";
                s2 = s2 + "        and o.oid=conrelid \n";
                s2 = s2 + "        and c.contype='u'\n";
                s2 = s2 + "        and a.attrelid=o.oid \n";
                s2 = s2 + "        and a.attnum>0\n";
                s2 = s2 + "        and t.oid=a.atttypid\n";
                s2 = s2 + "        and a.attnum in(\n";
                s2 = s2 + "                        select         \n";
                s2 = s2 + "                                unnest(c.conkey)\n";
                s2 = s2 + "                        from \n";
                s2 = s2 + "                                pg_constraint c, \n";
                s2 = s2 + "                                pg_class o \n";
                s2 = s2 + "                        where \n";
                s2 = s2 + "                                o.relname ='" + tabla + "' \n";
                s2 = s2 + "                                and o.oid=conrelid \n";
                s2 = s2 + "                                and c.contype='u'\n";
                s2 = s2 + "                        )\n";

                IDataReader dr2 = EjecutaQuery(s2);
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
            List<Cindex> l1 = new List<Cindex>();
            //genero el query para tyraerme los indices asociados a la tabla
            string query = "select\n";
            query = query + "        o1.relname as name\n";
            query = query + "from\n";
            query = query + "        pg_class o,\n";
            query = query + "        pg_class o1,\n";
            query = query + "        pg_index i\n";
            query = query + "where\n";
            query = query + "        o.relname='"+ tabla + "'\n";
            query = query + "        and o.oid=i.indrelid\n";
            query = query + "        and o1.oid=indexrelid\n";

            IDataReader dr = EjecutaQuery(query);
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
            //------------------------------
            query += "select \n";
            query += "        a.attname as COLUMNA,  \n";
            query += "        t.typname as TIPO, \n";
            query += "        atttypmod-4 as LONGITUD, \n";
            query += "        'false' as descendente \n";
            query += "from \n";
            query += "        pg_class o1, \n";
            query += "        pg_index i, \n";
            query += "        pg_class o, \n";
            query += "        pg_type t, \n";
            query += "        pg_attribute a \n";
            query += "where \n";
            query += "        o1.relname='"+ indice + "' \n";
            query += "        and o.relname='"+ tabla + "' \n";
            query += "        and o1.oid=indexrelid \n";
            query += "        and o.oid=i.indrelid \n";
            query += "        and a.attrelid=o.oid  \n";
            query += "        and t.oid=a.atttypid \n";
            query += "        and a.attnum>0 \n";
            query += "        and a.attnum in( \n";
            query += "                                select \n";
            query += "                                        unnest(i.indkey) \n";
            query += "                                from \n";
            query += "                                        pg_index i, \n";
            query += "                                        pg_class o, \n";
            query += "                                        pg_class o1 \n";
            query += "                                where \n";
            query += "                                        o1.relname='"+ indice + "' \n";
            query += "                                        and o.relname='"+ tabla + "' \n";
            query += "                                        and o1.oid=indexrelid \n";
            query += "                                        and o1.oid=indexrelid \n";
            query += "                        ) \n";
            query += "order by \n";
            query += "        a.attnum \n";
            //------------------------------
            List<CCampoIndex> l = new List<CCampoIndex>();
            IDataReader dr = EjecutaQuery(query);
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
            return l;
        }
        private IDataReader EsIdentidad(string tabla, string campo)
        {
            string s = "select";
            s = s + "        case  position('nextval(' in pg_get_expr(d.adbin,0)) when 0 then 0 else 1 end as Identidad\n";
            s = s + "        ,1 as seed_value \n";
            s = s + "        ,1 as increment_value\n";
            s = s + "from \n";
            s = s + "        pg_attribute c ,\n";
            s = s + "        pg_class o ,\n";
            s = s + "        pg_type t,\n";
            s = s + "        pg_attrdef d\n";
            s = s + "where \n";
            s = s + "        o.relname ='"+tabla+"'\n";
            s = s + "        and c.attname='"+campo+"'\n";
            s = s + "        and c.attrelid=o.oid \n";
            s = s + "        and c.attnum>0\n";
            s = s + "        and t.oid=c.atttypid\n";
            s = s + "        and d.adrelid=o.oid\n";
            s = s + "        and d.adnum=c.attnum\n";
            s = s + "order by \n";
            s = s + "        c.attnum\n";

            return EjecutaQuery(s);
        }
        private void GeneraListaTiposDato()
        {
            FTiposDato = new List<CTipoDato>();
            FTiposDato.Add(new CTipoDato("geography", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("geometry", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("xml", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("bit", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("bool", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("tinyint", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("smallint", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("date", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("int", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("int2", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("int4", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("real", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("smalldatetime", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("smallmoney", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("time", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("bigint", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("datetime", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("money", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("timestamp", TIPO_LONGITUD.NOREQUERIDO));
            FTiposDato.Add(new CTipoDato("timestamptz", TIPO_LONGITUD.NOREQUERIDO));
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
            FTiposDato.Add(new CTipoDato("float8", TIPO_LONGITUD.OPCIONAL));
            FTiposDato.Add(new CTipoDato("datetimeoffset", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("decimal", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("numeric", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("binary", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("char", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("nchar", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("nvarchar", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("varbinary", TIPO_LONGITUD.OBLIGATORIO));
            FTiposDato.Add(new CTipoDato("varchar", TIPO_LONGITUD.OBLIGATORIO));
            DameTiposDato();
        }
        public List<CParametro> DameParametrosFuncction(string funcion)
        {
            List<CParametro> l = new List<CParametro>();
            string s = "\n";
            s += "drop table if exists tmp_3_1415164578114;\n";
            s += "create temporary table tmp_3_1415164578114 as\n";
            s += "SELECT\n";
            s += "        unnest(proargnames) as name\n";
            s += "        ,unnest(proargtypes) as typo\n";
            s += "FROM \n";
            s += "        pg_proc \n";
            s += "WHERE proname = '"+funcion+"';\n";
            s += "select \n";
            s += "        a.name\n";
            s += "        ,t.typname as TipoDato\n";
            s += "        , 0 as length\n";
            s += " from \n";
            s += "        tmp_3_1415164578114 a\n";
            s += "        ,pg_type t\n";
            s += "where\n";
            s += "        t.oid=a.typo   \n";
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
        public string DameCodigoFuncction(string nombre)
        {
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "";
            s += "select pg_get_functiondef(oid) as text\n";
            s += "from pg_proc\n";
            s += "where proname = '"+nombre+"';\n";
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
        public List<CTipoDato> DameTiposDato()
        {
            string s = "select typname from pg_type where typtype='b'";
            System.Data.IDataReader dr;
            dr = EjecutaQuery(s);
            s = "";
            while (dr.Read())
            {
                string nombre= dr["typname"].ToString();
                var x = from t in FTiposDato where t.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim() select t;
                if( x.Count()==0)
                {
                    //no existe, por lo que tengo que agregarlo
                    FTiposDato.Add(new CTipoDato(nombre, TIPO_LONGITUD.OPCIONAL));
                }
            }
            dr.Close();
            return FTiposDato;
        }
        public IDataReader EjecutaQuery(string cadena)
        {
            CSQLComandQuery dr = new CSQLComandQuery();
            //asigno el motor de base de datos
            dr.Motor = EnumMotoresDB.POSTGRES;
            //le paso la cadena de conecion
            dr.ConnectionString = FConnectionString;
            //le paso el query
            dr.QueryString = cadena;
            //y lo abro
            try
            {
                dr.Open();
            }
            catch (System.Exception ex)
            {
                //regresa un dr null
                if (MessageErrorEvent != null)
                    MessageErrorEvent(this, ex.Message);
                return null;
            }
            return dr;
        }
        public DataSet Execute(string comando)
        {
            try
            {
                DataSet ds = new DataSet();
                NpgsqlCommand comand = new NpgsqlCommand(comando);
                comand.Connection = new NpgsqlConnection(FConnectionString);
                comand.CommandTimeout = 50000;
                comand.CommandText = comando;
                comand.Connection.Open();
                IDataReader dr = comand.ExecuteReader();
                ds.Load(dr, LoadOption.OverwriteChanges, new string[] { "Tabla 1", "Tabla 2", "Tabla 3", "Tabla 4", "Tabla 5", "Tabla 6", "Tabla 7", "Tabla 8", "Tabla 9", "Tabla 10", "Tabla 11", "Tabla 12", "Tabla 13", "Tabla 14", "Tabla 15" });
                comand.Connection.Close();
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
                    throw ex2;
                }
                return ds;
            }
            catch (Npgsql.PostgresException ex)
            {
                int i, n;
                ExceptionDB ex2 = new ExceptionDB();
                //calculo el numero de linea en la que se encuentra el error
                int linea = 1;
                for(i=0;i<ex.Position; i++)
                {
                    if (comando[i] == '\n')
                        linea++;
                }
                //n = ex.Errors.Count;
               // foreach (NpgsqlError err in ex.Errors)
                //{
                    ex2.Add(new CError(linea, ex.Message));
                //}
                throw ex2;
            }
            catch(System.Exception ex3)
            {
                if (ex3.GetType() == typeof(ExceptionDB))
                    throw ex3;
                ExceptionDB ex4 = new ExceptionDB();
                ex4.Add(new CError(0, ex3.Message));
                throw ex4;
            }

        }
        public List<CForeignKey> DameLLavesForaneasHijas(string tablaPadre)
        {
            //regresa las llaves foraneas que tiene la tabla
            //primero me traigo un listado de todas la llaves foraneas que tiene asociada la tabla
            List<CForeignKey> fks = new List<CForeignKey>();
            string s = "";
            s += "select \n";
            s += "        o2.relname as TablaPadre\n";
            s += "        ,o1.relname as TablaHija\n";
            s += "        ,ct.conname as fk\n";
            s += "        ,case ct.confupdtype when 'a' then 0 when 'c' then 1 when 'n' then 2 when 'd' then 3 when 'r' then 4 end as AccionActualizar\n";
            s += "        ,case ct.confdeltype when 'a' then 0 when 'c' then 1 when 'n' then 2 when 'd' then 3 when 'r' then 4 end as AccionBorrar\n";
            s += "from \n";
            s += "        pg_class o1 \n";
            s += "        ,pg_constraint ct\n";
            s += "        ,pg_class o2\n";
            s += "where \n";
            s += "        o2.relname ='"+tablaPadre+"' \n";
            s += "        and ct.conrelid=o1.oid\n";
            s += "        and ct.contype='f'\n";
            s += "        and o2.oid=ct.confrelid\n";
            IDataReader dr = EjecutaQuery(s);
            while (dr.Read())
            {
                CForeignKey fk = new CForeignKey();
                fk.Nombre = dr["FK"].ToString();
                fk.TablaHija = dr["TablaHija"].ToString();
                fk.TablaPadre = dr["TablaPadre"].ToString();
                fk.AccionBorrar = DameReglaFK(int.Parse(dr["AccionBorrar"].ToString()));
                fk.AccionActualizar = DameReglaFK(int.Parse(dr["AccionActualizar"].ToString()));
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
    }
}
