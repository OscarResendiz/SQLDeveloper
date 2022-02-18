using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;

namespace MotorDB
{
    //clase que se utiliza para controlar las consultas a la base de datos
    internal class CSQLComandQuery : System.Data.IDataReader
    {
        //va a tener un data reader interno
        private System.Data.IDataReader FDataReader;
        private System.Data.IDbCommand FCommand;
        private System.Data.IDbConnection FConnection;
        public EnumMotoresDB Motor
        {
            get;
            set;
        }
        public string ConnectionString
        {
            get;
            set;
        }
        public string QueryString
        {
            get;
            set;
        }
        public void Open(bool lanzarExcepcion=false)
        {
            //crea la conexion
            switch (Motor)
            {
                case EnumMotoresDB.SQLSERVER:
                    //creo la conexion
                    FConnection = new SqlConnection(ConnectionString);
                    //creo el comando
                    FCommand = new System.Data.SqlClient.SqlCommand();
                    break;
                case EnumMotoresDB.MYSQL:
                    //creo la conexion
                    FConnection = new MySqlConnection(ConnectionString);
                    //creo el comando
                    FCommand = new MySqlCommand();
                    break;
                case EnumMotoresDB.POSTGRES:
                    //creo la conexion
                    FConnection = new NpgsqlConnection(ConnectionString);
                    //creo el comando
                    FCommand = new NpgsqlCommand();
                    break;
                default:
                    throw new Exception("Motor no soportado:" + Motor);
            }
            //continuo con la configuracion del comando
            FCommand.CommandType = System.Data.CommandType.Text;
            FCommand.Connection = FConnection;
            FCommand.CommandText = QueryString;
            FCommand.CommandTimeout = 500000;
            try
            {
                FCommand.Connection.Open();
                //RECUPERANDO DATOS
                FDataReader = FCommand.ExecuteReader();
                //FCommand.Connection.Close();
            }
            catch (System.Exception ex)
            {
                if (lanzarExcepcion)
                    throw ex;
            }
        }
        //componenete que va a trabajar con la conexion de la base de datos
        #region Implentacion de la interface IDataReader
        public object this[string name]
        {

            get
            {
                if (FDataReader == null)
                    return null;
                return FDataReader[name];
            }
        }

        public object this[int i]
        {
            get
            {
                return FDataReader[i];
            }
        }

        public int Depth
        {
            get
            {
                return FDataReader.Depth;
            }
        }

        public int FieldCount
        {
            get
            {
                return FDataReader.FieldCount;
            }
        }

        public bool IsClosed
        {
            get
            {
                if (FDataReader == null)
                    return true;
                return FDataReader.IsClosed;
            }
        }

        public int RecordsAffected
        {
            get
            {
                return FDataReader.RecordsAffected;
            }
        }

        public void Close()
        {
            //cierra todo
            if (FCommand != null && FCommand.Connection.State != ConnectionState.Closed)
            {
                FCommand.Connection.Close();
            }
            if (FDataReader != null && !FDataReader.IsClosed)
             FDataReader.Close();
        }

        public void Dispose()
        {
            FDataReader.Dispose();
        }

        public bool GetBoolean(int i)
        {
            return FDataReader.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return FDataReader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return FDataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return FDataReader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return FDataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return FDataReader.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return FDataReader.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            return FDataReader.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return FDataReader.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return FDataReader.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return FDataReader.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return FDataReader.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return FDataReader.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return FDataReader.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return FDataReader.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            return FDataReader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return FDataReader.GetOrdinal(name);
        }

        public DataTable GetSchemaTable()
        {
            return FDataReader.GetSchemaTable();
        }

        public string GetString(int i)
        {
            return FDataReader.GetString(i);
        }

        public object GetValue(int i)
        {
            return FDataReader.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return FDataReader.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return FDataReader.IsDBNull(i);
        }

        public bool NextResult()
        {
            return FDataReader.NextResult();
        }

        public bool Read()
        {
            if (FDataReader!=null && FDataReader.IsClosed==false)
                return FDataReader.Read();
            return false;
        }
        #endregion
    }
}
