using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    //provee servicios de administracion de conexiones a base de datos
    public enum EnumMotoresDB
    {
        SQLSERVER,
        MYSQL,
        POSTGRES,
    }
    public class CProviderDataBase
    {
        public static IMotorDB DameMotor(EnumMotoresDB motor)
        {
            IMotorDB obj = null;
            switch(motor)
            {
                case EnumMotoresDB.SQLSERVER:
                    obj = new CMotorSQLServer();
                    break;
                case EnumMotoresDB.MYSQL:
                    obj = new CMotorMySQL();
                    break;
                case EnumMotoresDB.POSTGRES:
                    obj = new CMotorPostgreSql();
                    break;
            }
            return obj;
        }
    }
}
